using HarmonyLib;
using UnityEngine;
using Object = UnityEngine.Object;
using Il2CppSystem;
using System.Linq;
using static UnityEngine.UI.Button;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System;
using BepInEx.Unity.IL2CPP.Utils;
using UnityEngine.TextCore.Text;
using System.Text.Json;
using Version = System.Version;
using System.Collections.Generic;
using Reactor.Utilities.Extensions;
using System.Text.RegularExpressions;
using System.Text;
using TheOtherRolesEdited.Utilities;

namespace TheOtherRolesEdited.Modules;

[HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Awake))]
internal static class MainMenuSetUpPatch
{
    public static Sprite sprite;
    public static GameObject modScreen = null;
    internal static GameObject credentialObject;
    internal static GameObject BackButton;
    internal static TMP_FontAsset fontAssetVersionShower;

    public static void Postfix(MainMenuManager __instance)
    {
        loadSprite();
      
        var scalerList = __instance.mainMenuUI.GetComponent<SlicedAspectScaler>();
        var modButton = Object.Instantiate(__instance.settingsButton, __instance.settingsButton.transform.parent);
        modButton.transform.localPosition = new Vector3(-0.3894f, -0.875f, 0f);
        modButton.transform.localScale += new Vector3(0.02f, 0f, 0f);
        modButton.gameObject.name = "TOREButton";
        modButton.gameObject.ForEachChild((Il2CppSystem.Action<GameObject>)((obj) =>
        {
            var icon = obj.transform.FindChild("Icon");
            if (icon != null)
            {
                icon.localScale = new Vector3(0.65f, 0.65f, 1f);
                icon.GetComponent<SpriteRenderer>().sprite = sprite;
            }
        }));
        scalerList.objectsToScale.Add(modButton.GetComponent<AspectScaledAsset>());

        var modPassiveButton = modButton.GetComponent<PassiveButton>();
        modPassiveButton.buttonText.color = Color.white;
        modPassiveButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0.255f, 0.482f, 1f);
        modPassiveButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0.255f, 0.482f, 2f, 0.8f);
        Color originalColormodPassiveButton = modPassiveButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        modPassiveButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColormodPassiveButton * 0.6f;
        modPassiveButton.activeTextColor = Color.white;
        modPassiveButton.inactiveTextColor = Color.white;
        modPassiveButton.OnClick = new ButtonClickedEvent();
        modPassiveButton.OnClick.AddListener((System.Action)(() =>
        {
            __instance.ResetScreen();
            modScreen.SetActive(true);
            __instance.screenTint.enabled = true;
            MainMenuManagerPatch.ShowRightPanel();
            if (LobbyJoinBind.LobbyText != null) LobbyJoinBind.LobbyText.SetActive(false);
            if (LobbyJoinBind.previousLobbyButton != null) LobbyJoinBind.previousLobbyButton.SetActive(false);
            if (LobbyJoinBind.clipboardLobbyButton != null) LobbyJoinBind.clipboardLobbyButton.SetActive(false);
        }));

        modButton.transform.FindChild("FontPlacer")
            .GetChild(0)
            .GetComponent<TextTranslatorTMP>()
            .SetModText("TORE");

        __instance.playButton.GetComponent<PassiveButton>().OnClick.AddListener((System.Action)(() =>
        {
            if (modScreen != null) modScreen.SetActive(false);
            if (credentialObject != null) credentialObject.SetActive(false);
            if (BackButton != null) BackButton.SetActive(false);
            if (LobbyJoinBind.LobbyText != null) LobbyJoinBind.LobbyText.SetActive(true);
            if (LobbyJoinBind.previousLobbyButton != null) LobbyJoinBind.previousLobbyButton.SetActive(true);
            if (LobbyJoinBind.clipboardLobbyButton != null) LobbyJoinBind.clipboardLobbyButton.SetActive(true);
        }));
        __instance.myAccountButton.GetComponent<PassiveButton>().OnClick.AddListener((System.Action)(() =>
        {
            if (modScreen != null) modScreen.SetActive(false);
            if (credentialObject != null) credentialObject.SetActive(false);
            if (BackButton != null) BackButton.SetActive(false);
            if (LobbyJoinBind.LobbyText != null) LobbyJoinBind.LobbyText.SetActive(false);
            if (LobbyJoinBind.previousLobbyButton != null) LobbyJoinBind.previousLobbyButton.SetActive(false);
            if (LobbyJoinBind.clipboardLobbyButton != null) LobbyJoinBind.clipboardLobbyButton.SetActive(false);
        }));
        __instance.creditsButton.GetComponent<PassiveButton>().OnClick.AddListener((System.Action)(() =>
        {
            if (modScreen != null) modScreen.SetActive(false);
            if (credentialObject != null) credentialObject.SetActive(false);
            if (BackButton != null) BackButton.SetActive(false);
            if (LobbyJoinBind.LobbyText != null) LobbyJoinBind.LobbyText.SetActive(false);
            if (LobbyJoinBind.previousLobbyButton != null) LobbyJoinBind.previousLobbyButton.SetActive(false);
            if (LobbyJoinBind.clipboardLobbyButton != null) LobbyJoinBind.clipboardLobbyButton.SetActive(false);
        }));

        modScreen = Object.Instantiate(__instance.accountButtons, __instance.accountButtons.transform.parent);
        modScreen.name = "modScreen";
        modScreen.transform.GetChild(0).GetChild(0).GetComponent<TextTranslatorTMP>().SetModText("The Other Roles Edited");
        __instance.mainButtons.Add(modButton);

        Object.Destroy(modScreen.transform.GetChild(4).gameObject);
#if ANDROID
        foreach (var button in __instance.mainButtons.GetFastEnumerator())
        {
            if (button.activeSprites)
            {
                var name = button.name;
                bool shouldRotate = name != "TOREButton" && name != "Inventory Button";
                bool shouldMove = name != "TOREButton";
                var rendererTransform = button.activeSprites.transform.FindChild("Icon");
                if (rendererTransform)
                {

                    if (shouldRotate) rendererTransform.localEulerAngles -= new Vector3(0f, 0f, 10f);
                    rendererTransform.localScale += new Vector3(0.12f, 0.12f, 0f);

                    if (shouldMove)
                    {
                        var aspectPos = rendererTransform.GetComponent<AspectPosition>();
                        if (aspectPos)
                        {
                            aspectPos.DistanceFromEdge += new Vector3(-0.02f, 0.1f, 0f);
                            aspectPos.AdjustPosition();
                        }
                        else
                        {
                            rendererTransform.localPosition += new Vector3(-0.02f, 0.1f, 0f);
                        }
                    }
                }
            }
        }
#endif
        foreach (var asset in modScreen.GetComponentsInChildren<AspectScaledAsset>()) scalerList.objectsToScale.Add(asset);

        var temp = modScreen.transform.GetChild(3);
        int index = 0;
        void SetUpButton(string button, System.Action clickAction)
        {
            GameObject obj = temp.gameObject;
            if (index > 0) obj = Object.Instantiate(obj, obj.transform.parent);

            obj.transform.GetChild(0).GetChild(0).GetComponent<TextTranslatorTMP>().SetModText(button);
            var passiveButton = obj.GetComponent<PassiveButton>();
            passiveButton.OnClick = new ButtonClickedEvent();
            passiveButton.OnClick.AddListener((System.Action)(() =>
            {
                clickAction.Invoke();
            }));
            obj.transform.localPosition = new Vector3(0f, 0.98f - index * 0.68f, 0f);
            index++;
            scalerList.objectsToScale.Add(passiveButton.GetComponent<AspectScaledAsset>());
            passiveButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0.255f, 0.482f, 1f);
            passiveButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0.255f, 0.482f, 2f);
            Color originalColorpassiveButton = passiveButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
            passiveButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorpassiveButton * 0.5f;
            passiveButton.activeSprites.GetComponent<SpriteRenderer>().color = originalColorpassiveButton * 0.55f;
            passiveButton.activeTextColor = Color.white;
            passiveButton.inactiveTextColor = Color.white;
            passiveButton.activeSprites.transform.FindChild("Shine")?.gameObject?.SetActive(false);
            passiveButton.inactiveSprites.transform.FindChild("Shine")?.gameObject?.SetActive(false);
            passiveButton.activeSprites.transform.FindChild("Icon")?.gameObject?.SetActive(true);
            passiveButton.inactiveSprites.transform.FindChild("Icon")?.gameObject?.SetActive(true);
            passiveButton.activeSprites.transform.FindChild("Icon").transform.localScale = new Vector3(0.7f, 0.7f, 1f);
            passiveButton.inactiveSprites.transform.FindChild("Icon").transform.localScale = new Vector3(0.7f, 0.7f, 1f);
        }
        SetUpButton(ModTranslation.getString("modHowToPlay"), () =>
        {
            PlayManager.Open(__instance);
        });
        SetUpButton(ModTranslation.getString("modAbout"), () =>
        {
            GameObject rightPanel = GameObject.Find("RightPanel");
            if (credentialObject == null)
            {
                string farewell = "作为一个超800小时的AmongUs玩家，\n从2020年第一次的游玩就让我深深的爱上了这款游戏，\n而模组的产生，多样化的职业让AmongUs更有游玩价值，作为一个0基础小白，\n我带着对AU的热爱而创造了TORE";
                string fangkuai = "一个人的成功不在于永不跌倒，而在于每次跌倒后都能选择站起；\n一个人的失败不在于迷失方向，而在于从未尝试寻找光。";
                string linmei = "我是TownOfNext，ClashOfGods，XtremeWave的主要开发者，\nTheOtherRolesGM IA 和 TheOtherRolesEdited的贡献者，我希望这个模组会做的越来越好。";
                string talkguo = "风与故事的种子带来的序幕。";
                credentialObject = new GameObject("credentialsTOR");
                credentialObject.transform.SetParent(rightPanel.transform, false);
                var credentials = credentialObject.AddComponent<TextMeshPro>();
                credentials.SetText($"<size=160%>关于模组</size>\n\n<B> farewell</B>（模组作者 + 美工 + 中文翻译）\n<b>介绍:</b>{farewell}</b>\n<B> FangkuaiYa</B>（模组作者 + 中文翻译）\n<b>留言:</b>{fangkuai}\n<B> Elinmei</B>（贡献者）\n<b>介绍:</b>{linmei}\n<B>太空果</B>（服务器支持）\n<b>留言:</b>{talkguo} ");
                credentials.alignment = TMPro.TextAlignmentOptions.Center;
                credentials.fontSize *= 0.05f;
            }
            credentialObject.SetActive(true);
            if (modScreen != null) modScreen.SetActive(false);
            if (BackButton == null)
            {
                var backButton = __instance.onlineButtons.transform.GetChild(1).GetChild(1);
                BackButton = Object.Instantiate(backButton, backButton.transform.parent).gameObject;
                BackButton.transform.SetParent(rightPanel.transform, false);
                BackButton.GetComponent<AspectPosition>().anchorPoint += new Vector2(-0.1f, 0.34f);
                BackButton.transform.localScale = new Vector3(1f, 1f, 1f);
                BackButton.GetComponent<PassiveButton>().OnClick = new ButtonClickedEvent();
                BackButton.GetComponent<PassiveButton>().OnClick.AddListener((System.Action)(() =>
                {
                    modScreen.SetActive(true);
                    credentialObject.SetActive(false);
                    BackButton.gameObject.SetActive(false);
                }));
            }
            BackButton.gameObject.SetActive(true);
        });
        SetUpButton(ModTranslation.getString("modUpdate"), () =>
        {
            Transform closeBtn = null;

            void CreateCheckPopup(string displayText = "")
            {
                var popup = GameObject.Instantiate(DiscordManager.Instance.discordPopup, Camera.main!.transform);

                var background = popup.transform.Find("Background");
                if (background != null)
                    UnityEngine.Object.Destroy(background.gameObject);

                var textArea = popup.TextAreaTMP;
                if (textArea != null)
                {
                    textArea.alignment = TextAlignmentOptions.Left;
                    textArea.fontSizeMin = 1.2f;
                    textArea.font = fontAssetVersionShower;
                    textArea.richText = true;
                    textArea.SetText(displayText);
                }

                closeBtn = popup.transform.Find("ExitGame");
                if (closeBtn != null)
                {
                    var btnSpriteRenderer = closeBtn.GetComponent<SpriteRenderer>();
                    if (btnSpriteRenderer != null)
                    {
                        Sprite customBgSprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.MainPhoto.Button.png", 100f);
                        if (customBgSprite != null)
                        {
                            btnSpriteRenderer.sprite = customBgSprite;
                        }
                    }
                    closeBtn.localScale = new Vector3(0.7f, 0.7f, 1f);
                    closeBtn.localPosition = new Vector3(0, -2.6f, closeBtn.localPosition.z);
                    var buttonText = closeBtn.transform.GetComponentInChildren<TMPro.TMP_Text>();
                    if (buttonText != null && __instance != null)
                    {
                        __instance.StartCoroutine(Effects.Lerp(0.5f, new System.Action<float>((p) =>
                        {
                            buttonText.SetText($"{ModTranslation.getString("Close")}");
                            buttonText.font = fontAssetVersionShower;
                        })));
                    }
                }

                popup.Show(displayText);
            }

            string ExtractChineseSection(string releaseBody)
            {
                const string startMarker = "★【更新内容】★";
                const string endMarker = "★【适配】★";

                int startIndex = releaseBody.IndexOf(startMarker, System.StringComparison.Ordinal);
                if (startIndex == -1)
                    return "未找到中文更新说明";

                startIndex += startMarker.Length;

                int endIndex = releaseBody.IndexOf(endMarker, startIndex, System.StringComparison.Ordinal);
                if (endIndex == -1)
                    return releaseBody.Substring(startIndex).Trim();

                return releaseBody.Substring(startIndex, endIndex - startIndex).Trim();
            }

            string ConvertMarkdown(string input)
            {
                if (string.IsNullOrEmpty(input))
                    return input;

                string result = input;
                result = Regex.Replace(result, @"\*\*(.*?)\*\*", "<b>$1</b>", RegexOptions.Singleline);
                result = Regex.Replace(result, @"_(.*?)_", "<i>$1</i>", RegexOptions.Singleline);
                result = Regex.Replace(result, @"-(.*?)", "$1", RegexOptions.Singleline);

                return result;
            }

            IEnumerator SimpleCheckUpdateCoroutine()
            {
                string apiUrl = "https://api.github.com/repos/XtremeWave/TheOtherRolesEdited/releases";
                UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl);
                webRequest.SetRequestHeader("User-Agent", "ModUpdateCheck");
                yield return webRequest.SendWebRequest();

                bool hasNewUpdate = false;
                string displayText = "";

                try
                {
                    if (webRequest.result != UnityWebRequest.Result.Success)
                    {
                        displayText = $"无法检测更新: {webRequest.error}";
                    }
                    else if (string.IsNullOrEmpty(webRequest.downloadHandler.text))
                    {
                        displayText = "更新信息为空";
                    }
                    else
                    {
                        var releases = JsonSerializer.Deserialize<List<GithubRelease>>(webRequest.downloadHandler.text);

                        if (releases == null || releases.Count == 0)
                        {
                            displayText = "未获取到版本信息";
                        }
                        else
                        {
                            var latest = releases[0];
                            Version latestVersion;

                            if (!Version.TryParse(latest.tag_name?.TrimStart('v', 'V'), out latestVersion))
                            {
                                displayText = $"最新版本号解析失败: {latest.tag_name}";
                            }
                            else
                            {
                                Version currentVersion = TheOtherRolesEditedPlugin.Version is Version v
                                    ? v
                                    : new Version(TheOtherRolesEditedPlugin.Version.ToString());

                                hasNewUpdate = latestVersion > currentVersion;

                                string chineseContent = ExtractChineseSection(latest.body);
                                string formattedContent = ConvertMarkdown(chineseContent);

                                if (hasNewUpdate)
                                {
                                    displayText = $"<size=150%>{string.Format(ModTranslation.getString("PleaseUpdate"), latest.tag_name)}</size>\n\n{formattedContent}";
                                }
                                else
                                {
                                    displayText = $"<size=150%> 没有可更新版本 (当前版本: {currentVersion}, 最新版本: {latestVersion})</size>";
                                }
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    displayText = $"加载更新信息失败: {ex.Message}";
                    Debug.LogError($"[UpdateChecker] 版本检查异常: {ex}");
                }

                CreateCheckPopup(displayText);
                webRequest.Dispose();
            }

            __instance.StartCoroutine(SimpleCheckUpdateCoroutine());
        });
    }

    private class GithubRelease
    {
        public string tag_name { get; set; }
        public string body { get; set; }
    }

    public static void loadSprite()
    {
        if (sprite == null)
            sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.MainPhoto.Icon.png", 100f);
    }

}
public class PlayManager : MonoBehaviour
{
    static PlayManager() => ClassInjector.RegisterTypeInIl2Cpp<PlayManager>();
    public static MainMenuManager MainMenu;

    public static void Open(MainMenuManager mainMenu)
    {
        MainMenu = mainMenu;

        var obj = Helpers.CreateObject<PlayManager>("HowToPlay", Camera.main.transform, new Vector3(0, 0, -30f));
        TransitionFade.Instance.DoTransitionFade(null!, obj.gameObject, () => { mainMenu.mainMenuUI.SetActive(false); }, () => { obj.OnShown(); });
    }

    public void OnShown()
    {
        gameObject.SetActive(true);
        GameObject screen = Helpers.CreateObject("Screen", transform, new Vector3(0, -0.1f, -10f));
        var roleText = screen.AddComponent<TextMeshPro>();
        string content = $"<size=160%>{ModTranslation.getString("modHowToPlay")}\n\n</size><size=70%>{ModTranslation.getString("howToPlayCrewmate")}\n\n{ModTranslation.getString("howToPlayImpostor")}\n\n{ModTranslation.getString("howToPlayNeutral")}\n\n{ModTranslation.getString("howToPlayModifier")}</size>";
        roleText.SetText(content);
        roleText.alignment = TextAlignmentOptions.Top;
        roleText.enableWordWrapping = true;
        roleText.autoSizeTextContainer = true;
        Helpers.TextFeatures features = Helpers.AnalyzeTextFeatures(content);

        roleText.fontSize = 3f * features.fontSizeMultiplier;
        roleText.lineSpacing = features.lineSpacingOffset;
        roleText.ForceMeshUpdate();

        float textHeight = roleText.preferredHeight * features.heightMultiplier;
        float screenHeight = Camera.main.orthographicSize * 2f;
        float visibleHeight = screenHeight * 0.8f;

        GameObject centerContainer = Helpers.CreateObject("CenterContainer", screen.transform, new Vector3(0, 0f, -10f));
        var containerRect = centerContainer.AddComponent<RectTransform>();
        containerRect.sizeDelta = new Vector2(screenHeight * Camera.main.aspect * 0.9f, visibleHeight);

        roleText.transform.SetParent(centerContainer.transform);
        roleText.rectTransform.anchoredPosition = Vector2.zero;
        roleText.rectTransform.sizeDelta = containerRect.sizeDelta;
        roleText.ForceMeshUpdate();
        textHeight = roleText.preferredHeight * features.heightMultiplier;

        var scroller = screen.AddComponent<Scroller>();
        scroller.Inner = containerRect;
        scroller.allowY = true;
        scroller.velocity = Vector2.zero;

        if (textHeight > visibleHeight)
        {
            float scrollRange = (textHeight - visibleHeight) / 2f;
            scroller.ContentYBounds = new FloatRange(-scrollRange, scrollRange);
            scroller.ScrollWheelSpeed = Mathf.Clamp(textHeight * 0.05f, 0.5f, 3f);
            containerRect.anchoredPosition = Vector2.zero;
        }
        else
        {
            scroller.enabled = false;
            containerRect.anchoredPosition = Vector2.zero;
        }

        roleText.alignment = TextAlignmentOptions.Center;
    }

    protected void Close()
    {
        TransitionFade.Instance.DoTransitionFade(gameObject, null!, () => MainMenu?.mainMenuUI.SetActive(true), () => GameObject.Destroy(gameObject));
    }

    public void Awake()
    {
        if (MainMenu != null)
        {
            var backBlackPrefab = MainMenu.playerCustomizationPrefab.transform.GetChild(1);
            GameObject.Instantiate(backBlackPrefab.gameObject, transform);
            var backGroundPrefab = MainMenu.playerCustomizationPrefab.transform.GetChild(2);
            var backGround = GameObject.Instantiate(backGroundPrefab.gameObject, transform);
            GameObject.Destroy(backGround.transform.GetChild(2).gameObject);

            var closeButtonPrefab = MainMenu.playerCustomizationPrefab.transform.GetChild(0).GetChild(0);
            var closeButton = GameObject.Instantiate(closeButtonPrefab.gameObject, transform);
            GameObject.Destroy(closeButton.GetComponent<AspectPosition>());
            var button = closeButton.GetComponent<PassiveButton>();
            button.gameObject.SetActive(true);
            button.OnClick = new UnityEngine.UI.Button.ButtonClickedEvent();
            button.OnClick.AddListener((System.Action)(() => Close()));
            button.gameObject.SetAsUIAspectContent(AspectPosition.EdgeAlignments.LeftTop, new(0.4f, 0.4f, -50f));
        }
    }
}
//thanks GMIA