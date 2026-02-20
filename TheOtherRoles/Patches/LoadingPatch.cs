using System;
using System.Collections;
using BepInEx.Unity.IL2CPP.Utils.Collections;
using HarmonyLib;
using TheOtherRolesEdited.Modules;
using TheOtherRolesEdited.Modules.CustomHats;
using TheOtherRolesEdited.Utilities;
using TMPro;
using UnityEngine;

namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(SplashManager), nameof(SplashManager.Update))]
public static class LoadPatch
{
    static Sprite logoSprite;
    static Sprite bgSprite;

    static TMPro.TextMeshPro loadText = null!;
    static TMPro.TextMeshPro aprilFoolsText = null!;

    private static bool IsAprilFoolsDay => DateTime.Now.Month == 12 && DateTime.Now.Day == 27;

    public static string LoadingText { set { loadText.text = value; } }
   
    static LoadPatch()
    {
        string aprilFoolBgPath = "TheOtherRolesEdited.Resources.MainPhoto.TORE-Loading-BG_AprilFool.png";
        string aprilFoolLogoPath = "TheOtherRolesEdited.Resources.MainPhoto.TORE-Banner2_AprilFool.png";

        string normalBgPath = "TheOtherRolesEdited.Resources.MainPhoto.TORE-Loading-BG-2.png";
        string normalLogoPath = "TheOtherRolesEdited.Resources.MainPhoto.TORE-Banner2.png";

        bgSprite = IsAprilFoolsDay
            ? Helpers.loadSpriteFromResources(aprilFoolBgPath, 100f)
            : Helpers.loadSpriteFromResources(normalBgPath, 100f);

        logoSprite = IsAprilFoolsDay
            ? Helpers.loadSpriteFromResources(aprilFoolLogoPath, 140f)
            : Helpers.loadSpriteFromResources(normalLogoPath, 140f);
    }

    static IEnumerator CoLoadTheOtherRoles(SplashManager __instance)
    {       
        ModTranslation.Load();

        var bg = UnityHelper.CreateObject<SpriteRenderer>("TheOtherRolesEditedBG", null, new Vector3(0, 0.5f, -10f));
        bg.sprite = bgSprite;
        bg.color = Color.clear;
        var logo = UnityHelper.CreateObject<SpriteRenderer>("TheOtherRolesEditedLogo", null, new Vector3(0, 0.5f, -15f));
        logo.sprite = logoSprite;
        logo.color = Color.clear;
        logo.transform.localScale = new Vector3(0.9f, 0.9f, 1f);

        float bgFadeInDuration = 0.5f;
        float elapsedTime = 0f;

        while (elapsedTime < bgFadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / bgFadeInDuration);
            bg.color = Color.white.AlphaMultiplied(alpha);
            yield return null;
        }
        bg.color = Color.white;
        yield return new WaitForSeconds(0.5f);

        float logoFadeInDuration = 1.5f;
        elapsedTime = 0f;
        while (elapsedTime < logoFadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / logoFadeInDuration);
            logo.color = Color.white.AlphaMultiplied(alpha);
            float scale = Mathf.Lerp(0.9f, 1.0f, alpha);
            logo.transform.localScale = new Vector3(scale, scale, 1f);
            yield return null;
        }
        logo.color = Color.white;
        logo.transform.localScale = Vector3.one; 
        yield return new WaitForSeconds(0.5f);

        if (IsAprilFoolsDay)
        {
            aprilFoolsText = GameObject.Instantiate(__instance.errorPopup.InfoText, null);
            aprilFoolsText.transform.localPosition = new(0f, -0.28f, -10f);
            aprilFoolsText.text = ModTranslation.getString("AprilFoolsDay");
            aprilFoolsText.fontStyle = FontStyles.Bold;
            aprilFoolsText.color = Color.clear;
            Color aprilFoolsColor = new Color(0f, 1f, 0f);

            float aprilFadeIn = 0.8f;
            elapsedTime = 0f;
            while (elapsedTime < aprilFadeIn)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Clamp01(elapsedTime / aprilFadeIn);
                aprilFoolsText.color = aprilFoolsColor.AlphaMultiplied(alpha);
                yield return null;
            }

            float aprilWaitTime = 3f;
            elapsedTime = 0f;
            while (elapsedTime < aprilWaitTime)
            {
                elapsedTime += Time.deltaTime;
                float flicker = Mathf.Sin(Time.time * 8f) * 0.1f;
                aprilFoolsText.alpha = Mathf.Clamp01(1f + flicker);
                yield return null;
            }

            float aprilFadeOut = 0.8f;
            elapsedTime = 0f;
            while (elapsedTime < aprilFadeOut)
            {
                elapsedTime += Time.deltaTime;
                float alpha = 1f - Mathf.Clamp01(elapsedTime / aprilFadeOut);
                aprilFoolsText.color = aprilFoolsColor.AlphaMultiplied(alpha);
                yield return null;
            }
            UnityEngine.Object.Destroy(aprilFoolsText.gameObject);
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
        }

        loadText = GameObject.Instantiate(__instance.errorPopup.InfoText, null);
        loadText.transform.localPosition = new(0f, -0.28f, -10f);
        loadText.fontStyle = TMPro.FontStyles.Bold;
        loadText.text = ModTranslation.getString("Loading");
        loadText.color = Color.clear;

        float loadFadeIn = 0.5f;
        elapsedTime = 0f;
        while (elapsedTime < loadFadeIn)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / loadFadeIn);
            loadText.color = Color.white.AlphaMultiplied(alpha); 
            yield return null;
        }

        {
            yield return TextFadeTransition(ModTranslation.getString("Motd"));
            _ = Patches.CredentialsPatch.MOTD.loadMOTDs();

            yield return TextFadeTransition(ModTranslation.getString("Server"));
            TheOtherRolesEditedPlugin.UpdateRegions();

            yield return TextFadeTransition(ModTranslation.getString("Harmony"));
            TheOtherRolesEditedPlugin.Instance.Harmony.PatchAll();

            yield return TextFadeTransition(ModTranslation.getString("Building"));
            CustomOptionHolder.Load();

            yield return TextFadeTransition(ModTranslation.getString("Modcolor"));
            CustomColors.Load();

            yield return TextFadeTransition(ModTranslation.getString("Modhat"));
            CustomHatManager.LoadHats();

            var hatsLoader = CustomHatManager.Loader;
            float downloadStartTime = Time.time;
            int lastDownloadedCount = 0;
            float lastProgressTime = Time.time;
            const float maxWaitTime = 120f;
            const float stallTimeout = 30f;

            while (!hatsLoader.isRunning && Time.time - downloadStartTime < 2f)
            {
                yield return null;
            }

            while (hatsLoader.isRunning &&
                   Time.time - downloadStartTime < maxWaitTime &&
                   Time.time - lastProgressTime < stallTimeout)
            {
                string downloadText = $"{ModTranslation.getString("Downloadhat")}: {hatsLoader.downloadedFiles}/{hatsLoader.totalFilesToDownload}";
                loadText.text = downloadText;

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
                    yield return TextFadeTransition(ModTranslation.getString("Toolong"));
                }
                else if (Time.time - lastProgressTime >= stallTimeout)
                {
                    yield return TextFadeTransition(ModTranslation.getString("Skipping"));
                }
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return TextFadeTransition(ModTranslation.getString("Hatcomplete"));
            }

#if PC
            yield return TextFadeTransition(ModTranslation.getString("Modcursor"));
            if (TheOtherRolesEditedPlugin.ToggleCursor.Value) Helpers.enableCursor(true);

            if (BepInExUpdater.UpdateRequired)
            {
                yield return TextFadeTransition(ModTranslation.getString("BepInEx"));
                TheOtherRolesEditedPlugin.Instance.AddComponent<BepInExUpdater>();
                yield return new WaitForSeconds(0.5f);
                yield return null;
            }
#endif
            yield return TextFadeTransition(ModTranslation.getString("Modupdates"));
            TheOtherRolesEditedPlugin.Instance.AddComponent<ModUpdater>();

            yield return TextFadeTransition(ModTranslation.getString("AFD"));
            EventUtility.Load();

            yield return TextFadeTransition(ModTranslation.getString("Submerged"));
            SubmergedCompatibility.Initialize();

            yield return TextFadeTransition(ModTranslation.getString("UI"));
            MainMenuPatch.addSceneChangeCallbacks();

            yield return TextFadeTransition(ModTranslation.getString("Rolesintroduction"));
            _ = RoleInfo.loadReadme();

            AddToKillDistanceSetting.addKillDistance();

            TheOtherRolesEditedPlugin.Logger.LogInfo("Loading TORE completed!");
        }

        yield return TextFadeTransition(ModTranslation.getString("LoadingComplete"));

        for (int i = 0; i < 3; i++)
        {
            loadText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.03f);
            loadText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.03f);
        }

        float completeFadeOut = 0.8f;
        elapsedTime = 0f;
        while (elapsedTime < completeFadeOut)
        {
            elapsedTime += Time.deltaTime;
            float alpha = 1f - Mathf.Clamp01(elapsedTime / completeFadeOut);
            loadText.color = Color.white.AlphaMultiplied(alpha);
            yield return null;
        }
        UnityEngine.Object.Destroy(loadText.gameObject);

        float fadeOutDuration = 2f;
        elapsedTime = 0f;
        while (elapsedTime < fadeOutDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = 1f - Mathf.Clamp01(elapsedTime / fadeOutDuration);
            bg.color = Color.white.AlphaMultiplied(alpha);
            logo.color = Color.white.AlphaMultiplied(alpha);
            yield return null;
        }
        bg.color = Color.clear;
        logo.color = Color.clear;

        __instance.sceneChanger.AllowFinishLoadingScene();
        __instance.startedSceneLoad = true;
    }

    private static IEnumerator TextFadeTransition(string newText, float fadeOutTime = 0.3f, float fadeInTime = 0.3f, float waitTime = 0.5f)
    {
        float elapsed = 0f;
        while (elapsed < fadeOutTime)
        {
            elapsed += Time.deltaTime;
            float alpha = 1f - Mathf.Clamp01(elapsed / fadeOutTime);
            loadText.color = Color.white.AlphaMultiplied(alpha); 
            yield return null;
        }

        loadText.text = newText;
        elapsed = 0f;
        while (elapsed < fadeInTime)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / fadeInTime);
            loadText.color = Color.white.AlphaMultiplied(alpha);
            yield return null;
        }

        yield return new WaitForSeconds(waitTime);
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