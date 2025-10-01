using System.Collections;
using BepInEx.Unity.IL2CPP.Utils.Collections;
using HarmonyLib;
using TheOtherRolesEdited.Modules;
using TheOtherRolesEdited.Modules.CustomHats;
using TheOtherRolesEdited.Utilities;
using UnityEngine;

namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(SplashManager), nameof(SplashManager.Update))]
public static class LoadPatch
{
    static Sprite logoSprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.MainPhoto.TORE-Banner2.png", 140f);
    static Sprite bgSprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.MainPhoto.TORE-Loading-BG.png", 100f);
    static TMPro.TextMeshPro loadText = null!;

    private static float _scaleSpeed = 0.4f;    // 缩放动画速度（值越大越快）
    private static float _scaleRange = 0.15f;   // 缩放幅度（0.15 = 最大放大15%）
    private static Coroutine _scaleCoroutine;   // 用于存储缩放协程，方便后续停止

    public static string LoadingText { set { loadText.text = value; } }

    static IEnumerator CoLoadTheOtherRoles(SplashManager __instance)
    {
        var logo = UnityHelper.CreateObject<SpriteRenderer>("TheOtherRolesEditedLogo", null, new Vector3(0, 0.5f, -15f));
        logo.sprite = logoSprite;

        var bg = UnityHelper.CreateObject<SpriteRenderer>("TheOtherRolesEditedBG", null, new Vector3(0, 0.5f, -10f));
        bg.sprite = bgSprite;

        float p = 1f;
        while (p > 0f)
        {
            p -= Time.deltaTime * 2.8f;
            float alpha = 1 - p;
            logo.color = Color.white.AlphaMultiplied(alpha);
            logo.transform.localScale = Vector3.one * (p * p * 0.012f + 1f);
            yield return null;
        }
        logo.color = Color.white;
        logo.transform.localScale = Vector3.one;

        float q = 1f;
        while (q > 0f)
        {
            q -= Time.deltaTime * 3.8f;
            float alpha = 1 - q;
            bg.color = Color.white.AlphaMultiplied(alpha);
            bg.transform.localScale = Vector3.one * (q * q * 0.012f + 1f);
            yield return null;
        }
        bg.color = Color.white;
        bg.transform.localScale = Vector3.one;

        Vector3 originalLogoScale = logo.transform.localScale;
        _scaleCoroutine = __instance.StartCoroutine(ScaleLoop(logo.transform, originalLogoScale).WrapToIl2Cpp());

        loadText = GameObject.Instantiate(__instance.errorPopup.InfoText, null);
        loadText.transform.localPosition = new(0f, -0.28f, -10f);
        loadText.fontStyle = TMPro.FontStyles.Bold;
        loadText.text = "正在加载...";
        loadText.color = Color.white.AlphaMultiplied(0.3f);
        {
            loadText.text = "正在加载语言...";
            ModTranslation.Load();
            yield return new WaitForSeconds(0.5f);
            loadText.text = "正在加载开发者头衔...";
            DevManager.Init();
            yield return new WaitForSeconds(0.5f);
            loadText.text = "正在加载今日模组热点...";
            _ = Patches.CredentialsPatch.MOTD.loadMOTDs();
            yield return new WaitForSeconds(0.5f);
            loadText.text = "正在加载服务器...";
            TheOtherRolesEditedPlugin.UpdateRegions();
            yield return new WaitForSeconds(0.5f);
#if PC
            loadText.text = "加载Harmony Patch...";
            TheOtherRolesEditedPlugin.Instance.Harmony.PatchAll();
            yield return new WaitForSeconds(0.5f);
#endif
            loadText.text = "正在构建设置...";
            CustomOptionHolder.Load();
            yield return new WaitForSeconds(0.5f);
            loadText.text = "正在加载模组颜色...";
            CustomColors.Load();
            yield return new WaitForSeconds(0.5f);
            loadText.text = "正在加载模组帽子...";
            CustomHatManager.LoadHats();
            yield return new WaitForSeconds(0.5f);
            loadText.text = "正在加载模组音效...";
            SoundEffectsManager.Load();
#if PC
            var hatsLoader = CustomHatManager.Loader;
            float downloadStartTime = Time.time;
            int lastDownloadedCount = 0;
            float lastProgressTime = Time.time;
            const float maxWaitTime = 120f; // 最大等待时间2分钟
            const float stallTimeout = 30f; // 停滞超时30秒

            while (!hatsLoader.isRunning && Time.time - downloadStartTime < 5f)
            {
                yield return null;
            }

            while (hatsLoader.isRunning &&
                   Time.time - downloadStartTime < maxWaitTime &&
                   Time.time - lastProgressTime < stallTimeout)
            {
                loadText.text = $"正在下载帽子: {hatsLoader.downloadedFiles}/{hatsLoader.totalFilesToDownload}";

                if (hatsLoader.downloadedFiles > lastDownloadedCount)
                {
                    lastDownloadedCount = hatsLoader.downloadedFiles;
                    lastProgressTime = Time.time;
                }

                yield return null;
            }

            if (hatsLoader.isRunning)
            {
                if (Time.time - downloadStartTime >= maxWaitTime)
                {
                    loadText.text = "帽子下载时间过长，正在后台继续...";
                }
                else if (Time.time - lastProgressTime >= stallTimeout)
                {
                    loadText.text = "帽子下载暂停，正在跳过...";
                }
                yield return new WaitForSeconds(1f);
            }
            else
            {
                loadText.text = "帽子加载成功!";
                yield return new WaitForSeconds(0.5f);
            }
#endif
            loadText.text = "尝试加载模组光标...";
            if (TheOtherRolesEditedPlugin.ToggleCursor.Value) Helpers.enableCursor(true);
            yield return new WaitForSeconds(0.5f);

#if PC
            if (BepInExUpdater.UpdateRequired)
            {
                loadText.text = "正在更新BepInEx...";
                TheOtherRolesEditedPlugin.Instance.AddComponent<BepInExUpdater>();
                yield return new WaitForSeconds(0.5f);
                yield return null;
            }
#endif
            loadText.text = "正在加载模组更新...";
            TheOtherRolesEditedPlugin.Instance.AddComponent<ModUpdater>();
            yield return new WaitForSeconds(0.5f);
            loadText.text = "加载愚人节事件检测...";
            EventUtility.Load();
            yield return new WaitForSeconds(0.5f);
            loadText.text = "尝试加载Submerged...";
            SubmergedCompatibility.Initialize();
            yield return new WaitForSeconds(0.5f);
            loadText.text = "正在加载模组主界面...";
            MainMenuPatch.addSceneChangeCallbacks();
            yield return new WaitForSeconds(0.5f);
            loadText.text = "正在加载模组职业介绍...";
            _ = RoleInfo.loadReadme();
            yield return new WaitForSeconds(0.5f);

            AddToKillDistanceSetting.addKillDistance();

            TheOtherRolesEditedPlugin.Logger.LogInfo("Loading TORE completed!");
        }

        loadText.text = "加载完成";
        for (int i = 0; i < 3; i++)
        {
            loadText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.03f);
            loadText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.03f);
        }
        GameObject.Destroy(loadText.gameObject);

        if (_scaleCoroutine != null)
        {
            __instance.StopCoroutine(_scaleCoroutine);
            logo.transform.localScale = Vector3.one; 
        }

        p = 1f;
        while (p > 0f)
        {
            p -= Time.deltaTime * 1.2f;
            logo.color = Color.white.AlphaMultiplied(p);
            yield return null;
        }
        logo.color = Color.clear;

        __instance.sceneChanger.AllowFinishLoadingScene();
        __instance.startedSceneLoad = true;
    }

    private static IEnumerator ScaleLoop(Transform targetTransform, Vector3 originalScale)
    {
        while (true) 
        {
            float pingPongValue = Mathf.PingPong(Time.time * _scaleSpeed, 1f);
            float currentScaleRatio = 1f + (pingPongValue * _scaleRange);
            targetTransform.localScale = originalScale * currentScaleRatio;
            yield return null; 
        }
    }

    static bool loadedTheOtherRoles = false;
    public static bool Prefix(SplashManager __instance)
    {
        if (__instance.doneLoadingRefdata && !__instance.startedSceneLoad && Time.time - __instance.startTime > 4.2f && !loadedTheOtherRoles)
        {
            loadedTheOtherRoles = true;
            __instance.StartCoroutine(CoLoadTheOtherRoles(__instance).WrapToIl2Cpp());
        }
        return false;
    }
}

public static class UnityHelper
{
    public static GameObject CreateObject(string objName, Transform parent, Vector3 localPosition, int? layer = null)
    {
        var obj = new GameObject(objName);
        obj.transform.SetParent(parent);
        obj.transform.localPosition = localPosition;
        obj.transform.localScale = new Vector3(1f, 1f, 1f);
        if (layer.HasValue)
            obj.layer = layer.Value;
        else if (parent != null)
            obj.layer = parent.gameObject.layer;
        return obj;
    }

    public static T CreateObject<T>(string objName, Transform parent, Vector3 localPosition, int? layer = null) where T : Component
    {
        return CreateObject(objName, parent, localPosition, layer).AddComponent<T>();
    }
}