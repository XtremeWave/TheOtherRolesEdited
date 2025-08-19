using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Reflection;
using TMPro;
using Object = UnityEngine.Object;
using Assets.InnerNet;
using AmongUs.GameOptions;
using TheOtherRolesEdited.Modules;

namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start)), HarmonyPriority(Priority.First)]
internal class TitleLogoPatch
{
    public static GameObject Background;
    public static GameObject ModStamp;
    public static GameObject AULogo;
    public static GameObject BottomButtonBounds;
    public static GameObject AmongUsLogo;
    public static GameObject Ambience;
    private static TextMeshPro welcomeText;
    public static GameObject Starfield;
    public static GameObject RightPanel;
    public static GameObject CloseRightButton;
    public static GameObject Tint;
    public static Vector3 RightPanelOp;

    private static void Postfix(MainMenuManager __instance)
    {
        //强制屏幕大小为1920x1080
        //ResolutionManager.SetResolution(1920, 1080, true);
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
        var bgRenderer = Background.AddComponent<SpriteRenderer>();
        bgRenderer.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.MainPhoto.TORE-BG.png", 150f);

        if (!(Ambience = GameObject.Find("Ambience"))) return;
        if (!(Starfield = Ambience.transform.FindChild("starfield").gameObject)) return;
        var starGen = Starfield.GetComponent<StarGen>();
        starGen.SetDirection(new Vector2(0, -2));
        Starfield.transform.SetParent(Background.transform);
        Object.Destroy(Ambience);

        if (!(ModStamp = GameObject.Find("ModStamp"))) return;
        ModStamp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        if (!(ModStamp = GameObject.Find("ModStamp"))) return;
        var ModStapRenderer = ModStamp.GetComponent<SpriteRenderer>();
        ModStapRenderer.sprite = LoadSprite("TheOtherRolesEdited.Resources.MainPhoto.ModStamp.png", 150f);

        if (!(AmongUsLogo = GameObject.Find("AmongUsLogo"))) return;
        var AmongUsLogos = AmongUsLogo.GetComponent<SpriteRenderer>();
        AmongUsLogos.sprite = LoadSprite("TheOtherRolesEdited.Resources.MainPhoto.TORE-logo.png", 150f);

        if (!(AULogo = GameObject.Find("LOGO-AU"))) return;
        var logoRenderer = AULogo.GetComponent<SpriteRenderer>();
        logoRenderer.sprite = LoadSprite("TheOtherRolesEdited.Resources.MainPhoto.TORE.png", 150f);
        AULogo.transform.localPosition += new Vector3(-0.35f, 0.19f, 0);
        AULogo.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

        if (!(BottomButtonBounds = GameObject.Find("BottomButtonBounds"))) return;
        BottomButtonBounds.transform.localPosition += new Vector3(-0.35f, 0.68f, 0);
        __instance.playButton.transform.localPosition += new Vector3(-0.35f, 0.68f, 0);
        __instance.inventoryButton.transform.localPosition += new Vector3(-0.35f, 0.68f, 0);
        __instance.shopButton.transform.localPosition += new Vector3(-0.35f, 0.68f, 0);
        __instance.myAccountButton.transform.localPosition += new Vector3(-0.35f, 0.68f, 0);
        __instance.newsButton.transform.localPosition += new Vector3(-0.35f, 0.68f, 0);
        __instance.settingsButton.transform.localPosition += new Vector3(-0.35f, 0.68f, 0);

        if (!(RightPanel = GameObject.Find("RightPanel"))) return;
        var rpap = RightPanel.GetComponent<AspectPosition>();
        if (rpap) Object.Destroy(rpap);
        RightPanelOp = RightPanel.transform.localPosition;
        RightPanel.transform.localPosition = RightPanelOp + new Vector3(10f, 0f, 0f);
        RightPanel.GetComponent<SpriteRenderer>().color = new(0f, 0.6f, 255f);
 
        CloseRightButton = new GameObject("CloseRightPanelButton");
        CloseRightButton.transform.SetParent(RightPanel.transform);
        CloseRightButton.transform.localPosition = new Vector3(-4.78f, 1.3f, 1f);
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
        Tint.transform.localPosition = new Vector3(-0.0824f, 0.0513f, Tint.transform.localPosition.z);
        Tint.transform.localScale = new Vector3(1f, 1f, 1f);
       
        var creditsScreen = __instance.creditsScreen;
        if (creditsScreen)
        {
            var csto = creditsScreen.GetComponent<TransitionOpen>();
            if (csto) Object.Destroy(csto);
            var closeButton = creditsScreen.transform.FindChild("CloseButton");
            closeButton?.gameObject.SetActive(false);
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
        catch
        {

        }
        return null;
    }
    public static Texture2D LoadTextureFromResources(string path)
    {
        try
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            var texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
            using MemoryStream ms = new();
            stream.CopyTo(ms);
            ImageConversion.LoadImage(texture, ms.ToArray(), false);
            return texture;
        }
        catch
        {
        }
        return null;
    }

    [HarmonyPatch(typeof(VersionShower), nameof(VersionShower.Start))]
    public static void Postfix(VersionShower __instance)
    {
        __instance.text.gameObject.GetComponent<RectTransform>().transform.localPosition +=  new Vector3(-0.2f, 0f, 0f);
        __instance.text.alignment = AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Started ? TextAlignmentOptions.Bottom : TextAlignmentOptions.BottomLeft;
        __instance.text.fontSize = 1.45f;
        //__instance.text.gameObject.GetComponent<RectTransform>().sizeDelta = new(2.5f, 0.35f);
        __instance.text.text = $"AmongUs v{DestroyableSingleton<ReferenceDataManager>.Instance.Refdata.userFacingVersion}-{Helpers.GradientColorText("00FFFF", "0000FF", $"{TheOtherRolesEditedPlugin.Id}")} v{TheOtherRolesEditedPlugin.VersionString}" ;
    }
    static Sprite XtremeWaveSprite = LoadSprite("TheOtherRolesEdited.Resources.MainPhoto.XtremeWave.png", 1000f);

    //YuEzTool
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
        if (AmongUsClient.Instance.AmHost)
        {
            welcomeText = Object.Instantiate(__instance.PlayerCounter, __instance.StartButton.transform.parent);
        }
        else
        {
            welcomeText = Object.Instantiate(__instance.PlayerCounter, __instance.StartButtonClient.transform.parent);
        }
        welcomeText.fontSize = 6.2f;
        welcomeText.autoSizeTextContainer = true;
        welcomeText.name = "welcome";
        welcomeText.text =  $"{Helpers.GradientColorText("FF09B1", "09C5FF", $"welcome to the other roles edited")}";
        welcomeText.DestroyChildren();
        welcomeText.DestroySubMeshObjects();
        welcomeText.alignment = TextAlignmentOptions.Center;
        welcomeText.outlineColor = Color.black;
        welcomeText.outlineWidth = 0.28f;
        welcomeText.transform.localPosition += new Vector3(-0.55f, -0.25f, 0f);
        welcomeText.transform.localScale = new(0.7f, 0.7f, 1f);
    }
    [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Update))]
    public static class GameStartManagePatch
    {
        public static void Postfix(GameStartManager __instance)
        {
            var AspectSize = GameObject.Find("AspectSize");
            AspectSize.transform.FindChild("Background").gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.4f);
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
        public static void Prefix(ModManager __instance)
        {
            __instance.ShowModStamp();

        }
        public static void Postfix(ModManager __instance)
        {
            var offset_y = HudManager.InstanceExists ? 2.1f : 1.1f;
            __instance.ModStamp.transform.position = AspectPosition.ComputeWorldPosition(
                __instance.localCamera, AspectPosition.EdgeAlignments.RightTop,
                new Vector3(0.4f, offset_y, __instance.localCamera.nearClipPlane + 0.1f));
        }
    }
}
