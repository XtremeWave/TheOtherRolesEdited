using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Reflection;
using TMPro;
using Object = UnityEngine.Object;
using Assets.InnerNet;
using System.Linq;
using System;
using Assets.CoreScripts;
using System.Text;
using InnerNet;
using System.Collections;
using BepInEx.Unity.IL2CPP.Utils;
using TheOtherRolesEdited.Modules;
using Reactor.Utilities.Extensions;
using TheOtherRolesEdited.Patches;
using static TheOtherRolesEdited.Patches.CredentialsPatch;
using Il2CppSystem.Security.Cryptography;
using static UnityEngine.UI.Button;
using UnityEngine.Networking;
using Il2CppSystem.CodeDom.Compiler;

namespace TheOtherRolesEdited.Modules;

[HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start)), HarmonyPriority(Priority.First)]
internal class TitleLogoPatch
{
    public static GameObject Background;
    public static GameObject ModStamp;
    public static GameObject AULogo;
    public static GameObject BottomButtonBounds;
    public static GameObject Ambience;
    public static GameObject Starfield;
    public static GameObject RightPanel;
    public static GameObject CloseRightButton;
    public static GameObject Tint;
    public static GameObject Sizer;

    public static Vector3 RightPanelOp;

    private static Sprite logoSprite1;
    private static Sprite logoSprite2;
    private static SpriteRenderer logoRenderer;
    private static bool isShowingSprite1 = true;
    public static float switchInterval = 4f;
    public static float fadeDuration = 0.8f;

    private static int _bugButtonClickCount = 0;

    public static float GetResolutionOffset()
    {
        return (float)Screen.width / Screen.height / (16f / 9f);
    }

    private static void Postfix(MainMenuManager __instance)
    {
        EnterCodePatch.ifFirst = true;
        GameObject.Find("BackgroundTexture")?.SetActive(!MainMenuManagerPatch.ShowedBak);

        var friendsButton = UpdateFriendCodeUIPatch.FriendsButton.GetComponent<PassiveButton>();
        friendsButton.buttonText.color = Color.white;
        friendsButton.activeTextColor = Color.white;
        friendsButton.inactiveTextColor = Color.white;
        friendsButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0.0235f, 0.6f, 1f);
        friendsButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0.0235f, 0.6f, 2f);
        Color originalColorfriendsButton = friendsButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        friendsButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorfriendsButton * 0.6f;
        friendsButton.activeSprites.GetComponent<SpriteRenderer>().color = originalColorfriendsButton * 0.75f;

        Background = new GameObject("TORE Background");
        Background.transform.position = new Vector3(0, 0, 520f);
        Background.transform.localScale = new Vector3(Mathf.Max(GetResolutionOffset(), 1), Mathf.Max(GetResolutionOffset(), 1), 1);
        var bgRenderer = Background.AddComponent<SpriteRenderer>();
        bgRenderer.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.MainPhoto.TORE-BG.png", 150f);

        var UI = GameObject.Find("MainUI");
        var asp = UI.transform.GetChild(1);
        var DoNotPress = asp.GetChild(6);
        DoNotPress.gameObject.SetActive(true);
        DoNotPress.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = LoadSprite("TheOtherRolesEdited.Resources.BugButton_activeSprites.png", 150f);
        DoNotPress.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = LoadSprite("TheOtherRolesEdited.Resources.BugButton_inactiveSprites.png", 150f);
        DoNotPress.transform.GetChild(0).transform.localPosition += new Vector3(-0.01f, 0.35f, 0);
        DoNotPress.transform.GetChild(1).transform.localPosition += new Vector3(-0.01f, 0.35f, 0);
        SpriteRenderer pedestalSprite = DoNotPress.GetComponent<SpriteRenderer>();
        SpriteRenderer pressedSprite = DoNotPress.GetChild(0).GetComponent<SpriteRenderer>();
        SpriteRenderer unpressedSprite = DoNotPress.GetChild(1).GetComponent<SpriteRenderer>();
        PassiveButton bugButton = DoNotPress.GetComponent<PassiveButton>();
        pedestalSprite.gameObject.SetActive(true);
        pressedSprite.gameObject.SetActive(true);
        unpressedSprite.gameObject.SetActive(true);
        unpressedSprite.enabled = true;
        pressedSprite.enabled = false;

        bugButton.OnClick.RemoveAllListeners();
        bugButton.OnMouseOver.RemoveAllListeners();
        bugButton.OnMouseOut.RemoveAllListeners();

        bugButton.OnMouseOver.AddListener((Action)(() =>
        {
            pressedSprite.enabled = true;
            unpressedSprite.enabled = false;
        }));

        bugButton.OnMouseOut.AddListener((Action)(() =>
        {
            pressedSprite.enabled = false;
            unpressedSprite.enabled = true;
        }));

        bugButton.OnClick.AddListener(new Action(() =>
        {
            _bugButtonClickCount++; 

            var oldBugScreen = AccountManager.Instance.transform.Find("BUGSCREEN");
            if (oldBugScreen != null) Object.Destroy(oldBugScreen.gameObject);
            var oldScreen = AccountManager.Instance.transform.Find("SCREEN");
            if (oldScreen != null) Object.Destroy(oldScreen.gameObject);

            var template = AccountManager.Instance.transform.Find("PremissionRequestWindow");
            if (template == null) return;

            if (_bugButtonClickCount == 1)
            {
                GameObject sliderTemplate = Object.Instantiate(template.gameObject, AccountManager.Instance.transform);
                sliderTemplate.name = "BUGSCREEN";
                sliderTemplate.SetActive(true);

                sliderTemplate.transform.Find("TitleText_TMP").GetComponent<TextMeshPro>().text = "BUG反馈";
                Object.Destroy(sliderTemplate.transform.Find("TitleText_TMP").GetComponent<TextTranslatorTMP>());

                sliderTemplate.transform.Find("InfoText_TMP").GetComponent<TextMeshPro>().text = "如果您在游戏中遇到任何问题您都可以在下方，并请发送";
                Object.Destroy(sliderTemplate.transform.Find("InfoText_TMP").GetComponent<TextTranslatorTMP>());
                sliderTemplate.transform.Find("InfoText_TMP").localPosition = new Vector3(-0.7f, 1.2f, 0f);

                sliderTemplate.transform.Find("GuardianEmailTitle_TMP").GetComponent<TextMeshPro>().text = "请在下方输入遇到BUG的时间";
                Object.Destroy(sliderTemplate.transform.Find("GuardianEmailTitle_TMP").GetComponent<TextTranslatorTMP>());
                sliderTemplate.transform.Find("GuardianEmailTitle_TMP").localPosition = new Vector3(-2.3f, 1.3f, 0f);

                sliderTemplate.transform.Find("GuardianEmailConfirm").localPosition = new Vector3(0f, 0.67f, 0f);
                Object.Destroy(sliderTemplate.transform.Find("GuardianEmailConfirm").GetComponent<EmailTextBehaviour>());

                sliderTemplate.transform.Find("GuardianEmailConfirmTitle_TMP").GetComponent<TextMeshPro>().text = "请在下方输入您遇到的BUG";
                Object.Destroy(sliderTemplate.transform.Find("GuardianEmailConfirmTitle_TMP").GetComponent<TextTranslatorTMP>());
                sliderTemplate.transform.Find("GuardianEmailConfirmTitle_TMP").localPosition = new Vector3(-2.3f, 0f, 0f);

                var emailInput = sliderTemplate.transform.Find("GuardianEmail");
                emailInput.GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(6.8f, 1.35f);
                Object.Destroy(emailInput.GetComponent<EmailTextBehaviour>());
                emailInput.localPosition = new Vector3(0f, -0.98f, 0f);
                emailInput.GetComponent<BoxCollider2D>().size = new Vector2(6.8f, 1.35f);
                emailInput.GetChild(1).localPosition = new Vector3(-3.3f, 0.45f, 0f);

                sliderTemplate.transform.GetChild(9).gameObject.SetActive(false);

                var submitBtn = sliderTemplate.transform.Find("SubmitButton").GetComponent<PassiveButton>();
                submitBtn.OnClick = new ButtonClickedEvent();
                submitBtn.OnClick.AddListener((System.Action)(() =>
                {
                    var timeText = emailInput.GetChild(1).GetComponent<TextMeshPro>();
                    var bugText = sliderTemplate.transform.Find("GuardianEmailConfirm").GetChild(1).GetComponent<TextMeshPro>();
                    var timeBg = emailInput.GetChild(0).GetComponent<SpriteRenderer>();
                    var bugBg = sliderTemplate.transform.Find("GuardianEmailConfirm").GetChild(0).GetComponent<SpriteRenderer>();

                    bool timeEmpty = string.IsNullOrWhiteSpace(timeText.text);
                    bool bugEmpty = string.IsNullOrWhiteSpace(bugText.text);

                    if (timeEmpty || bugEmpty)
                    {
                        if (timeEmpty) timeBg.color = Color.red;
                        if (bugEmpty) bugBg.color = Color.red;
                        return;
                    }

                    Object.Destroy(sliderTemplate.gameObject);
                    ShowSuccessUI(template);
                }));
             
                var logErrorButton = Object.Instantiate(submitBtn, submitBtn.transform.parent);
                logErrorButton.gameObject.name = "LogErrorButton";
                logErrorButton.transform.Find("Text_TMP").GetComponent<TextMeshPro>().text = "LogOutput.log";
                Object.Destroy(logErrorButton.transform.Find("Text_TMP").GetComponent<TextTranslatorTMP>());
                logErrorButton.transform.Find("Text_TMP").GetComponent<TextMeshPro>().color = Color.green;
                logErrorButton.OnMouseOver.AddListener((System.Action)(() =>
                {
                    logErrorButton.transform.Find("Text_TMP").GetComponent<TextMeshPro>().color = Color.green + Color.gray;
                }));
                logErrorButton.OnMouseOut.AddListener((System.Action)(() =>
                {
                    logErrorButton.transform.Find("Text_TMP").GetComponent<TextMeshPro>().color = Color.green;
                }));
                logErrorButton.transform.GetChild(0).gameObject.SetActive(false);
                logErrorButton.transform.localPosition = new Vector3(2.77f, 1.69f, 0);
                logErrorButton.transform.localScale = new Vector3(0.9f, 0.9f, 0);
                logErrorButton.OnClick = new ButtonClickedEvent();
                logErrorButton.OnClick.AddListener((System.Action)(() =>
                {
                    sliderTemplate.SetActive(false);

                    var template2 = AccountManager.Instance.transform.Find("PremissionRequestWindow");
                    if (template2 == null) return;

                    GameObject Templates = Object.Instantiate(template2.gameObject, AccountManager.Instance.transform);
                    Templates.name = "SCREEN";
                    Templates.SetActive(true);

                    for (int i = 4; i <= 7; i++)
                        Templates.transform.GetChild(i).gameObject.SetActive(false);
                    Templates.transform.GetChild(9).gameObject.SetActive(false);

                    Templates.transform.Find("TitleText_TMP").GetComponent<TextMeshPro>().text = "LogOutput.log";
                    Templates.transform.Find("InfoText_TMP").GetComponent<TextMeshPro>().text = "请打开您的游戏根目录找到BepInEx文件夹\n将LogOutput.log文件复制下来\n发送至我的QQ（QQ号:1500689499）";
                    Object.Destroy(Templates.transform.Find("TitleText_TMP").GetComponent<TextTranslatorTMP>());
                    Object.Destroy(Templates.transform.Find("InfoText_TMP").GetComponent<TextTranslatorTMP>());
                    Templates.transform.Find("InfoText_TMP").localPosition = new Vector3(0f, 0f, 0f);
                  
                    var SubmitButton = Templates.transform.Find("SubmitButton").GetComponent<PassiveButton>();
                    SubmitButton.transform.Find("Text_TMP").GetComponent<TextMeshPro>().text = "返回";
                    Object.Destroy(SubmitButton.transform.Find("Text_TMP").GetComponent<TextTranslatorTMP>());
                    SubmitButton.OnClick = new ButtonClickedEvent();
                    SubmitButton.OnClick.AddListener((System.Action)(() =>
                    {
                        sliderTemplate.gameObject.SetActive(true);
                        Object.Destroy(Templates.gameObject);
                    }));
                }));
            }
            else
            {
                ShowSuccessUI(template);
            }
        }));

        if (!(Ambience = GameObject.Find("Ambience"))) return;
        if (!(Starfield = Ambience.transform.FindChild("starfield").gameObject)) return;
        var starGen = Starfield.GetComponent<StarGen>();
        starGen.SetDirection(new Vector2(0, -2));
        Starfield.transform.SetParent(Background.transform);
        Object.Destroy(Ambience);

        if (!(ModStamp = GameObject.Find("ModStamp"))) return;
        ModStamp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        var ModStapRenderer = ModStamp.GetComponent<SpriteRenderer>();
        ModStapRenderer.sprite = LoadSprite("TheOtherRolesEdited.Resources.MainPhoto.ModStamp.png", 150f);

        if (!(Sizer = GameObject.Find("Sizer"))) return;
        if (!(AULogo = GameObject.Find("LOGO-AU"))) return;
        var now = DateTime.Now;
        var month = now.Month;
        var day = now.Day;
        logoRenderer = AULogo.GetComponent<SpriteRenderer>();
        AULogo.transform.localPosition += new Vector3(-0.4f, 0.28f, 0);
        AULogo.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        string logoPath = "TheOtherRolesEdited.Resources.MainPhoto.TORE.png";
        if (month == 4 && day == 1) logoPath = "TheOtherRolesEdited.Resources.MainPhoto.TORE-AFT.png";
        logoSprite1 = Helpers.loadSpriteFromResources(logoPath, 150f);
        logoSprite2 = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.MainPhoto.AmongUs-Logo.png", 150f);
        logoRenderer.sprite = logoSprite1;
        logoRenderer.color = Color.white;
        __instance.StartCoroutine(GradientSwitchCoroutine());

        if (!(BottomButtonBounds = GameObject.Find("BottomButtonBounds"))) return;
        BottomButtonBounds.transform.localPosition += new Vector3(-0.4f, 0.58f, 0);

        __instance.playButton.transform.localPosition += new Vector3(-0.4f, 1.06f, 0);
        __instance.inventoryButton.transform.localPosition += new Vector3(-0.4f, 1.06f, 0);
        __instance.shopButton.transform.localPosition += new Vector3(-0.4f, 1.06f, 0);
        __instance.myAccountButton.transform.localPosition += new Vector3(-0.4f, 1.1f, 0);
        __instance.newsButton.transform.localPosition += new Vector3(-0.4f, 1.1f, 0);
        __instance.settingsButton.transform.localPosition += new Vector3(-0.4f, 1.1f, 0);

        __instance.playButton.transform.localScale += new Vector3(0.02f, 0f, 0);
        __instance.inventoryButton.transform.localScale += new Vector3(0.02f, 0f, 0);
        __instance.shopButton.transform.localScale += new Vector3(0.02f, 0f, 0);
        __instance.myAccountButton.transform.localScale += new Vector3(0.02f, 0f, 0);
        __instance.newsButton.transform.localScale += new Vector3(0.02f, 0f, 0);
        __instance.settingsButton.transform.localScale += new Vector3(0.02f, 0f, 0);

        if (!(RightPanel = GameObject.Find("RightPanel"))) return;
        var rpap = RightPanel.GetComponent<AspectPosition>();
        if (rpap) Object.Destroy(rpap);
        RightPanelOp = RightPanel.transform.localPosition;
        RightPanel.transform.localPosition = RightPanelOp + new Vector3(20f, 0f, 0f);
        RightPanel.GetComponent<SpriteRenderer>().color = new(0f, 0.6f, 255f);
        CloseRightButton = new GameObject("CloseRightPanelButton");
        CloseRightButton.transform.SetParent(RightPanel.transform);
        CloseRightButton.transform.localPosition = new Vector3(-4.78f * GetResolutionOffset(), 1.3f, 1f);
        CloseRightButton.transform.localScale = new(1f, 1f, 1f);
        CloseRightButton.AddComponent<BoxCollider2D>().size = new(0.6f, 1.5f);
        var closeRightSpriteRenderer = CloseRightButton.AddComponent<SpriteRenderer>();
        closeRightSpriteRenderer.sprite = LoadSprite("TheOtherRolesEdited.Resources.MainPhoto.RightPanelCloseButton.png", 100f);
        closeRightSpriteRenderer.color = new(0f, 0.6f, 255f);
        var closeRightPassiveButton = CloseRightButton.AddComponent<PassiveButton>();
        closeRightPassiveButton.OnClick = new();
        closeRightPassiveButton.OnClick.AddListener((System.Action)MainMenuManagerPatch.HideRightPanel);
        closeRightPassiveButton.OnMouseOut = new();
        closeRightPassiveButton.OnMouseOut.AddListener((System.Action)(() => closeRightSpriteRenderer.color = new(0f, 0.6f, 255f)));
        closeRightPassiveButton.OnMouseOver = new();
        closeRightPassiveButton.OnMouseOver.AddListener((System.Action)(() => closeRightSpriteRenderer.color = new(0f, 0f, 205f)));

        Tint = __instance.screenTint.gameObject;
        var ttap = Tint.GetComponent<AspectPosition>();
        if (ttap) Object.Destroy(ttap);
        Tint.transform.SetParent(RightPanel.transform);
        Tint.transform.localPosition = new Vector3(-0.0824f * GetResolutionOffset(), 0.0513f, Tint.transform.localPosition.z);
        Tint.transform.localScale = new Vector3(1f, 1f, 1f);

        var creditsScreen = __instance.creditsScreen;
        if (creditsScreen)
        {
            var csto = creditsScreen.GetComponent<TransitionOpen>();
            if (csto) Object.Destroy(csto);
            var closeButton = creditsScreen.transform.FindChild("CloseButton");
            closeButton?.gameObject.SetActive(false);
        }

        var mainButtonsobj = GameObject.Find("Main Buttons");
        mainButtonsobj.transform.localScale = new Vector3(0.9f, 0.9f, 1f);
        mainButtonsobj.transform.position = new Vector3(-3.4f * GetResolutionOffset(), mainButtonsobj.transform.position.y, mainButtonsobj.transform.position.z);
    }

    private static void ShowSuccessUI(Transform template)
    {
        GameObject Template = Object.Instantiate(template.gameObject, AccountManager.Instance.transform);
        Template.name = "SCREEN";
        Template.SetActive(true);

        Template.transform.Find("TitleText_TMP").GetComponent<TextMeshPro>().text = "已反馈";
        Template.transform.Find("InfoText_TMP").GetComponent<TextMeshPro>().text = "请等待反馈结果";
        Template.transform.Find("InfoText_TMP").localPosition = new Vector3(0f, -1.1f, 0f);
        Template.transform.Find("InfoText_TMP").localScale = new Vector3(2.5f, 2.5f, 1f);
        Object.Destroy(Template.transform.Find("InfoText_TMP").GetComponent<TextTranslatorTMP>());
        Object.Destroy(Template.transform.Find("TitleText_TMP").GetComponent<TextTranslatorTMP>());

        for (int i = 4; i <= 7; i++)
            Template.transform.GetChild(i).gameObject.SetActive(false);
        Template.transform.GetChild(9).gameObject.SetActive(false);

        var SubmitButton = Template.transform.Find("SubmitButton").GetComponent<PassiveButton>();
        SubmitButton.transform.Find("Text_TMP").GetComponent<TextMeshPro>().text = "关闭";
        Object.Destroy(SubmitButton.transform.Find("Text_TMP").GetComponent<TextTranslatorTMP>());
        SubmitButton.OnClick = new ButtonClickedEvent();
        SubmitButton.OnClick.AddListener((System.Action)(() =>
        {
            Object.Destroy(Template.gameObject);
        }));
    }

    private static IEnumerator GradientSwitchCoroutine()
    {
        while (logoRenderer != null && AULogo != null)
        {
            yield return new WaitForSeconds(switchInterval - fadeDuration);

            float fadeTimer = 0;
            while (fadeTimer < fadeDuration)
            {
                fadeTimer += Time.deltaTime;
                float alpha = 1 - (fadeTimer / fadeDuration);
                logoRenderer.color = new Color(1, 1, 1, alpha);
                yield return null;
            }

            isShowingSprite1 = !isShowingSprite1;
            logoRenderer.sprite = isShowingSprite1 ? logoSprite1 : logoSprite2;

            fadeTimer = 0;
            while (fadeTimer < fadeDuration)
            {
                fadeTimer += Time.deltaTime;
                float alpha = fadeTimer / fadeDuration;
                logoRenderer.color = new Color(1, 1, 1, alpha);
                yield return null;
            }
        }
    }

    public static Dictionary<string, Sprite> CachedSprites = new();
    public static Sprite LoadSprite(string path, float pixelsPerUnit = 1f)
    {
        try
        {
            if (CachedSprites.TryGetValue(path + pixelsPerUnit, out var sprite)) return sprite;
            Texture2D texture = LoadTextureFromResources(path);
            sprite = Sprite.Create(texture, new(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), pixelsPerUnit);
            sprite.hideFlags |= HideFlags.HideAndDontSave | HideFlags.DontSaveInEditor;
            return CachedSprites[path + pixelsPerUnit] = sprite;
        }
        catch { }
        return null;
    }

    public static Texture2D LoadTextureFromResources(string path)
    {
        try
        {
            var texture = new Texture2D(0, 0, TextureFormat.RGBA32, false) { wrapMode = TextureWrapMode.Clamp };
            Stream myStream = Assembly.GetCallingAssembly().GetManifestResourceStream(path);
            byte[] data = myStream.ReadFully();
            ImageConversion.LoadImage(texture, data, false);
            return texture;
        }
        catch
        {
            System.Console.WriteLine("Error loading texture from resources: " + path);
        }
        return null;
    }

    [HarmonyPatch(typeof(VersionShower), nameof(VersionShower.Start))]
    public static void Postfix(VersionShower __instance)
    {
        MainMenuPatch.fontAssetVersionShower = __instance.text.font;
        Showpop.fontAssetVersionShower = __instance.text.font;
        MainMenuSetUpPatch.fontAssetVersionShower = __instance.text.font;

        __instance.text.fontSize = 1.5f;
        __instance.text.text = $"AmongUs v{DestroyableSingleton<ReferenceDataManager>.Instance.Refdata.userFacingVersion}-{Helpers.GradientColorText("00FFFF", "0000FF", $"{TheOtherRolesEditedPlugin.Title}")} v{TheOtherRolesEditedPlugin.VersionString}";
        __instance.text.text += "\n" + string.Format(ModTranslation.getString("ToDateToday"), TheOtherRolesEditedPlugin.ModUsageCount);
        __instance.text.gameObject.GetComponent<RectTransform>().transform.localPosition += new Vector3(-0.2f, 0.272f, 0f);
        __instance.text.alignment = AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Started ? TextAlignmentOptions.Bottom : TextAlignmentOptions.BottomLeft;
        __instance.text.gameObject.GetComponent<RectTransform>().sizeDelta = new(2.5f, 0.9f);
    }

    static Sprite XtremeWaveSprite = LoadSprite("TheOtherRolesEdited.Resources.MainPhoto.XtremeWave.png", 1000f);

    [HarmonyPatch(typeof(AnnouncementPanel), nameof(AnnouncementPanel.SetUp)), HarmonyPostfix]
    public static void SetUpPanel(AnnouncementPanel __instance, [HarmonyArgument(0)] Announcement announcement)
    {
        if (announcement.Number < 100000) return;
        var XtremeWave = new GameObject("XtremeWave") { layer = 5 };
        XtremeWave.transform.SetParent(__instance.transform);
        XtremeWave.transform.localPosition = new Vector3(-0.81f, 0.16f, 0.5f);
        XtremeWave.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        var sr = XtremeWave.AddComponent<SpriteRenderer>();
        sr.sprite = XtremeWaveSprite;
        sr.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }

    [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Start))]
    public static void Postfix(GameStartManager __instance)
    {
        TextMeshPro countdownText;
        if (AmongUsClient.Instance.AmHost)
            countdownText = Object.Instantiate(__instance.PlayerCounter, __instance.StartButton.transform.parent);
        else
            countdownText = Object.Instantiate(__instance.PlayerCounter, __instance.StartButtonClient.transform.parent);

        countdownText.fontSize = 6.2f;
        countdownText.autoSizeTextContainer = true;
        countdownText.name = "countdown";
        countdownText.DestroyChildren();
        countdownText.DestroySubMeshObjects();
        countdownText.alignment = TextAlignmentOptions.Center;
        countdownText.outlineColor = Color.white;
        countdownText.outlineWidth = 0.18f;
        countdownText.transform.localPosition += new Vector3(-0.55f, -0.25f, 0f);
        countdownText.transform.localScale = new(0.7f, 0.7f, 1f);

        __instance.StartCoroutine(CountdownCoroutine(countdownText));
    }

    private static IEnumerator CountdownCoroutine(TextMeshPro textElement)
    {
        int totalSeconds = 10 * 60;
        while (totalSeconds > 0)
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            textElement.text = Helpers.GradientColorText("FF09B1", "09C5FF", $"{minutes:D2}:{seconds:D2}");
            yield return new WaitForSeconds(1f);
            totalSeconds--;
        }
        yield return new WaitForSeconds(2f);
        if (AmongUsClient.Instance != null)
            AmongUsClient.Instance.ExitGame(DisconnectReasons.Kicked);
        SceneChanger.ChangeScene("MainMenu");
    }

    [HarmonyPatch]
    class LobbyViewSettingsPanePatch
    {
        [HarmonyPatch(typeof(LobbyViewSettingsPane), nameof(LobbyViewSettingsPane.Awake)), HarmonyPostfix]
        static void Awake()
        {
            GameObject.Find("RulesPopOutWindow").transform.localPosition += new Vector3(-0.5f, 0f, 0f);
        }
    }

    [HarmonyPatch(typeof(CreditsScreenPopUp))]
    internal class CreditsScreenPopUpPatch
    {
        [HarmonyPatch(nameof(CreditsScreenPopUp.OnEnable))]
        public static void Postfix(CreditsScreenPopUp __instance)
        {
            __instance.BackButton.transform.parent.FindChild("Background").gameObject.SetActive(false);
        }
    }

    [HarmonyPatch(typeof(ModManager), nameof(ModManager.LateUpdate))]
    internal class ModManagerLateUpdatePatch
    {
        public static void Prefix(ModManager __instance) => __instance.ShowModStamp();
        public static void Postfix(ModManager __instance)
        {
            float offset_y = HudManager.InstanceExists ? 2.1f : 1.1f;
            __instance.ModStamp.transform.position = AspectPosition.ComputeWorldPosition(
                __instance.localCamera, AspectPosition.EdgeAlignments.RightTop,
                new Vector3(0.4f, offset_y, __instance.localCamera.nearClipPlane + 0.1f));
        }
    }

    [HarmonyPatch(typeof(HostLocalGameButton), nameof(HostLocalGameButton.Start))]
    public static class LocalGameModePatch
    {
        static void Postfix(HostLocalGameButton __instance)
        {
            if (__instance.TryGetComponent(Il2CppType.Of<FreeplayPopover>(), out _)) return;
            __instance.transform.FindChild("CreateHnSGameButton")?.gameObject.SetActive(false);
        }
    }

    [HarmonyPatch(typeof(ServerDropdown))]
    public static class ServerDropdownPatch
    {
        public static int CurrentPage = 1;
        public static int MaxPage = 1;
        public static int ButtonsPerPage = 4;
        public static ServerListButton PreviousPageButton;
        public static ServerListButton NextPageButton;

        [HarmonyPatch(nameof(ServerDropdown.FillServerOptions)), HarmonyPostfix]
        public static void FillServerOptions_Postfix(ServerDropdown __instance)
        {
            List<ServerListButton> serverListButton = __instance.ButtonPool.GetComponentsInChildren<ServerListButton>()
                .Where(x => x.name != "PreviousPageButton" && x.name != "NextPageButton").OrderByDescending(x => x.transform.localPosition.y).ToList();

            __instance.background.size = new Vector2(__instance.background.size.x, __instance.background.size.y / serverListButton.Count * (ButtonsPerPage + 2f));
            __instance.background.transform.localPosition = new Vector3(0f, (1f - ButtonsPerPage * 0.5f) / 2, 0f);

            MaxPage = serverListButton.Count / ButtonsPerPage + 1;
            if (CurrentPage > MaxPage) CurrentPage = MaxPage;
            List<ServerListButton> currentPageButton = new();
            int max = CurrentPage * ButtonsPerPage > serverListButton.Count ? serverListButton.Count : CurrentPage * ButtonsPerPage;
            for (int i = (CurrentPage - 1) * ButtonsPerPage; i < max; i++) currentPageButton.Add(serverListButton[i]);

            foreach (var btn in serverListButton) btn.gameObject.SetActive(currentPageButton.Contains(btn));
            for (int i = 0; i < currentPageButton.Count; i++)
                currentPageButton[i].transform.localPosition = new Vector3(0f, -1f + i * -0.5f, -1f);

            var template = serverListButton[0];
            if (PreviousPageButton == null || !PreviousPageButton.gameObject)
                PreviousPageButton = CreateServerListButton(template, "PreviousPageButton", $"{ModTranslation.getString("PreviousPageButton")}",
                    new(0f, -0.5f, -1f), () => { if (CurrentPage > 1) { CurrentPage--; RefreshServerOptions(__instance); } });
            PreviousPageButton.gameObject.SetActive(true);

            if (NextPageButton == null || !NextPageButton.gameObject)
                NextPageButton = CreateServerListButton(template, "NextPageButton", $"{ModTranslation.getString("NextPageButton")}",
                    new(0f, -1f + ButtonsPerPage * -0.5f, -1f), () => { if (CurrentPage < MaxPage) { CurrentPage++; RefreshServerOptions(__instance); } });
            NextPageButton.gameObject.SetActive(true);
        }

        public static ServerListButton CreateServerListButton(ServerListButton template, string name, string text, Vector3 pos, Action act)
        {
            var btn = Object.Instantiate(template, template.transform.parent);
            btn.name = name;
            btn.Text.text = text;
            btn.transform.localPosition = pos;
            btn.Button.OnClick = new();
            btn.Button.OnClick.AddListener(act);
            return btn;
        }

        public static void RefreshServerOptions(ServerDropdown __instance)
        {
            foreach (var btn in __instance.ButtonPool.GetComponentsInChildren<ServerListButton>()) btn.gameObject.SetActive(false);
            __instance.FillServerOptions();
        }

        [HarmonyPatch(typeof(ResolutionManager))]
        internal class ResolutionManagerPatch
        {
            [HarmonyPatch(nameof(ResolutionManager.SetResolution))]
            public static void Postfix(int width, int height)
            {
                _ = new LateTask(() =>
                {
                    if (!GameObject.Find("MainUI")) return;
                    float offset = GetResolutionOffset();
                    CloseRightButton.transform.localPosition = new(-4.78f * offset, 1.3f, 1f);
                    Tint.transform.localPosition = new(-0.0824f * offset, 0.0513f, Tint.transform.localPosition.z);
                    Sizer.transform.localPosition = new(-4.0f * offset, 1.4f, -1f);
                    Background.transform.localScale = new Vector3(Mathf.Max(offset, 1), Mathf.Max(offset, 1), 1);
                    CloseRightButton.transform.localPosition = new(-4.78f * offset, 1.3f, 1f);
                }, 0.01f, "RefreshMenu");
            }
        }
    }
}

[HarmonyPatch(typeof(FreeChatInputField), nameof(FreeChatInputField.UpdateCharCount))]
internal class UpdateCharCountPatch
{
    public static void Postfix(FreeChatInputField __instance)
    {
        int len = __instance.textArea.text.Length;
        __instance.charCountText.SetText(len <= 0 ? $"{ModTranslation.getString("ThankYouForPlayingTORE")}" : $"{len}/{__instance.textArea.characterLimit}");
        __instance.charCountText.enableWordWrapping = false;
        int max = AmongUsClient.Instance.AmHost ? 1111 : 777;
        int warn = AmongUsClient.Instance.AmHost ? 888 : 444;
        __instance.charCountText.color = len >= max ? Color.red : len >= warn ? Color.yellow : Color.black;
    }
}

[HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Update))]
public static class GameStartManagerUpdatePatch
{
    public static void Prefix(GameStartManager __instance)
    {
        foreach (ClientData c in AmongUsClient.Instance.allClients.ToArray())
        {
            try
            {
                PlayerControl p = Helpers.playerById(GameData.Instance.GetPlayerByClient(c).PlayerId);
                p.cosmetics.nameText.text = $"<color=#7bbfea>{c.PlayerName}</color>{(ModOption.HostName ? Helpers.GradientColorText("00BFFF", "0000FF", " ★TORE") : "")}\n<size=60%>{p.GetPlatform()}</size>";
            }
            catch { }
        }
    }

    public static ClientData GetClient(this PlayerControl p)
    {
        try { return AmongUsClient.Instance.allClients.ToArray().FirstOrDefault(c => c.Character.PlayerId == p.PlayerId); }
        catch { return null; }
    }

    public static string GetPlatform(this PlayerControl p)
    {
        try
        {
            var c = p.GetClient();
            if (c == null) return "";
            return c.PlatformData.Platform switch
            {
                Platforms.StandaloneEpicPC => "<color=#905CDA>Epic</color>",
                Platforms.StandaloneSteamPC => "<color=#4391CD>Steam</color>",
                Platforms.StandaloneMac => "<color=#e3e3e3>Mac</color>",
                Platforms.StandaloneWin10 => "<color=#FFF88D>Windows</color>",
                Platforms.StandaloneItch => "<color=#E35F5F>Itch</color>",
                Platforms.IPhone => "<color=#e3e3e3>iPhone</color>",
                Platforms.Android => "<color=#5DE2E7>Android</color>",
                Platforms.Switch => "<color=#00B2FF>Nintendo</color><color=#ff0000>Switch</color>",
                Platforms.Xbox => "<color=#07ff00>Xbox</color>",
                Platforms.Playstation => "<color=#0014b4>PlayStation</color>",
                _ => ""
            };
        }
        catch { return ""; }
    }
}