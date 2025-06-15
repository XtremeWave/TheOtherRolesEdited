using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Reflection;
using TMPro;
using Object = UnityEngine.Object;
using Assets.InnerNet;
using AmongUs.GameOptions;

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
    private static void Postfix(MainMenuManager __instance)
    {
        Background = new GameObject("TORE Background");
        Background.transform.position = new Vector3(0, 0, 520f);
        var bgRenderer = Background.AddComponent<SpriteRenderer>();
        bgRenderer.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.TORE-BG.png", 150f);

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
        ModStapRenderer.sprite = LoadSprite("TheOtherRolesEdited.Resources.ModStamp.png", 150f);

        if (!(AmongUsLogo = GameObject.Find("AmongUsLogo"))) return;
        var AmongUsLogos = AmongUsLogo.GetComponent<SpriteRenderer>();
        AmongUsLogos.sprite = LoadSprite("TheOtherRolesEdited.Resources.TORE-logo.png", 150f);

        if (!(AULogo = GameObject.Find("LOGO-AU"))) return;
        var logoRenderer = AULogo.GetComponent<SpriteRenderer>();
        logoRenderer.sprite = LoadSprite("TheOtherRolesEdited.Resources.TORE.png", 150f);
        AULogo.transform.localPosition += new Vector3(-0.4f, 0.15f, 0);
        AULogo.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

        if (!(BottomButtonBounds = GameObject.Find("BottomButtonBounds"))) return;
        BottomButtonBounds.transform.localPosition += new Vector3(-0.3f, 0.6f, 0);
        __instance.playButton.transform.localPosition += new Vector3(-0.3f, 0.6f, 0);
        __instance.inventoryButton.transform.localPosition += new Vector3(-0.3f, 0.6f, 0);
        __instance.shopButton.transform.localPosition += new Vector3(-0.3f, 0.6f, 0);
        __instance.myAccountButton.transform.localPosition += new Vector3(-0.3f, 0.6f, 0);
        __instance.newsButton.transform.localPosition += new Vector3(-0.3f, 0.6f, 0);
        __instance.settingsButton.transform.localPosition += new Vector3(-0.3f, 0.6f, 0);

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
        __instance.text.alignment = TextAlignmentOptions.BottomLeft;
        __instance.text.fontSize = 1.85f;
        __instance.text.text = $"v{Application.version}-{Helpers.GradientColorText("00FFFF", "0000FF", $"{TheOtherRolesEditedPlugin.Id}")} v{TheOtherRolesEditedPlugin.VersionString} ";
    }
    static Sprite XtremeWaveSprite = LoadSprite("TheOtherRolesEdited.Resources.XtremeWave.png", 1000f);

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
        welcomeText.text = $"{Helpers.GradientColorText("FF09B1", "09C5FF", $"welcome to the other roles edited")}";
        welcomeText.DestroyChildren();
        welcomeText.DestroySubMeshObjects();
        welcomeText.alignment = TextAlignmentOptions.Center;
        welcomeText.outlineColor = Color.white;
        welcomeText.outlineWidth = 0.30f;
        welcomeText.transform.localPosition += new Vector3(-0.55f, -0.25f, 0f);
        welcomeText.transform.localScale = new(0.7f, 0.7f, 1f);
    }
    [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Update))]
    public static class GameStartManagePatch
    {
        public static void Postfix(GameStartManager __instance)
        {
            var AspectSize = GameObject.Find("AspectSize");
            AspectSize.transform.FindChild("Divider").gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GameObject mapImage = AspectSize.FindChild<Transform>("MapImage").gameObject;
            mapImage.transform.localPosition = new Vector3(-16.8918f, -8.483f, -2f);
            GameObject sb = AspectSize.FindChild<Transform>("ModeLabel").gameObject;
            sb.transform.localPosition = new Vector3(1111f, -8.483f, -2f);
            GameObject sp = AspectSize.FindChild<Transform>("PrivacyLabel").gameObject;
            sp.transform.localPosition = new Vector3(1111f, -8.483f, -2f);
            GameObject sc = AspectSize.FindChild<Transform>("CapacityLabel").gameObject;
            sc.transform.localPosition = new Vector3(1111f, -8.483f, -2f);
            GameObject sd = AspectSize.FindChild<Transform>("Background").gameObject;
            sd.transform.localPosition = new Vector3(-1.0986f, -4.7321f, 0f);
            sd.transform.localScale = new Vector3(0.7009f, 0.6009f, 0f);
            sd.GetComponent<SpriteRenderer>().color = new(0f, 0f, 1f);

            if (__instance == null) return;

            TextMeshPro temp = __instance.PlayerCounter;


            if (AmongUsClient.Instance.AmHost)
            {
                __instance.EditButton.transform.localPosition = new Vector3(-0.4815f, -0.11f);
                __instance.EditButton.transform.localScale = new Vector3(1.24f, 0.8f);

                __instance.HostViewButton.transform.localPosition = new Vector3(-0.4815f, 0.52f);
                __instance.HostViewButton.transform.localScale = new Vector3(1.24f, 0.8f);
            }
            else
            {
                __instance.ClientViewButton.transform.localPosition = new Vector3(0.7823f, 0.5357f);
                __instance.ClientViewButton.transform.localScale = new Vector3(0.592f, 0.6f);
            }
        }
    }
}
