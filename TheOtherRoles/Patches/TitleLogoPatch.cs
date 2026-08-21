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
using AmongUs.Data;
using UnityEngine.TextCore.Text;

namespace TheOtherRolesEdited;

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
		bgRenderer.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.UI.TORE-BG.png", 150f);

        if (!(Ambience = GameObject.Find("Ambience"))) return;
		if (!(Starfield = Ambience.transform.FindChild("starfield").gameObject)) return;
		var starGen = Starfield.GetComponent<StarGen>();
		starGen.SetDirection(new Vector2(0, -2));
		Starfield.transform.SetParent(Background.transform);
		Object.Destroy(Ambience);

        if (!(ModStamp = GameObject.Find("ModStamp"))) return;
		ModStamp.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        var ModStapRenderer = ModStamp.GetComponent<SpriteRenderer>();
      
		if (ModTranslation.IsChinese())
        {
            ModStapRenderer.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.UI.ModStamp_SCN.png", 150f);
        }
        else
        {
            ModStapRenderer.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.UI.ModStamp_EN.png", 150f);
        }

        if (!(Sizer = GameObject.Find("Sizer"))) return;
		if (!(AULogo = GameObject.Find("LOGO-AU"))) return;
		var now = DateTime.Now;
		var month = now.Month;
		var day = now.Day;
		logoRenderer = AULogo.GetComponent<SpriteRenderer>();
		AULogo.transform.localPosition += new Vector3(-0.4f, 0.28f, 0);
		AULogo.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
		logoSprite1 = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.UI.TORE.png", 150f);
		logoSprite2 = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.UI.AmongUs-Logo.png", 150f);
		logoRenderer.sprite = logoSprite1;
		logoRenderer.color = Color.white;
		__instance.StartCoroutine(GradientSwitchCoroutine());
       
		Color shade = new(0f, 0f, 0f, 0f);
        var standardActiveSprite = __instance.newsButton.activeSprites.GetComponent<SpriteRenderer>().sprite;
        var minorActiveSprite = __instance.quitButton.activeSprites.GetComponent<SpriteRenderer>().sprite;

        Dictionary<List<PassiveButton>, (Sprite, Color, Color, Color, Color)> mainButtons = new()
        {
            {new List<PassiveButton>() {__instance.playButton, __instance.inventoryButton, __instance.shopButton},
                (standardActiveSprite, new(0.0235f, 0.6f, 1f, 0.8f), shade, Color.white, Color.white) },
            {new List<PassiveButton>() {__instance.newsButton, __instance.myAccountButton, __instance.settingsButton, MainMenuSetUpPatch.modPassiveButton},
                (minorActiveSprite, new(0.255f, 0.482f, 1f, 0.8f), shade, Color.white, Color.white) },
            {new List<PassiveButton>() {__instance.creditsButton, __instance.quitButton, MainMenuPatch.PassiveWebsiteButton, MainMenuPatch.passiveGithubButton, MainMenuPatch.passiveCreditsButton, AprilFoolsPatches.modeToggleButton},
                (minorActiveSprite, new(0.333f, 0.255f, 1f, 0.8f), shade, Color.white, Color.white) },
        };

        void FormatButtonColor(PassiveButton button, Sprite borderType, Color inActiveColor, Color activeColor, Color inActiveTextColor, Color activeTextColor)
        {
            button.activeSprites.transform.FindChild("Shine")?.gameObject?.SetActive(false);
            button.inactiveSprites.transform.FindChild("Shine")?.gameObject?.SetActive(false);
            var activeRenderer = button.activeSprites.GetComponent<SpriteRenderer>();
            var inActiveRenderer = button.inactiveSprites.GetComponent<SpriteRenderer>();
            activeRenderer.sprite = minorActiveSprite;
            inActiveRenderer.sprite = minorActiveSprite;
            activeRenderer.color = activeColor.a == 0f ? new Color(inActiveColor.r, inActiveColor.g, inActiveColor.b, 1f) : activeColor;
            inActiveRenderer.color = inActiveColor;
            button.activeTextColor = activeTextColor;
            button.inactiveTextColor = inActiveTextColor;
        }

        foreach (var kvp in mainButtons)
            kvp.Key.Do(button => FormatButtonColor(button, kvp.Value.Item1, kvp.Value.Item2, kvp.Value.Item3, kvp.Value.Item4, kvp.Value.Item5));

        if (!(BottomButtonBounds = GameObject.Find("BottomButtonBounds"))) return;
		BottomButtonBounds.transform.localPosition += new Vector3(-0.36f, 0.58f, 0);

		__instance.playButton.transform.localPosition += new Vector3(-0.4f, 1.06f, 0);
		__instance.inventoryButton.transform.localPosition += new Vector3(-0.4f, 1.06f, 0);
		__instance.shopButton.transform.localPosition += new Vector3(-0.4f, 1.06f, 0);
		__instance.myAccountButton.transform.localPosition += new Vector3(-0.4f, 1.1f, 0);
		__instance.newsButton.transform.localPosition += new Vector3(-0.4f, 1.1f, 0);
		__instance.settingsButton.transform.localPosition += new Vector3(-0.4f, 1.1f, 0);
        __instance.quitButton.transform.GetComponent<AspectPosition>().anchorPoint += new Vector2(0.0026f, 0.0f);
        __instance.creditsButton.transform.GetComponent<AspectPosition>().anchorPoint += new Vector2(-0.0028f, 0f);

        __instance.playButton.transform.localScale += new Vector3(0.02f, 0f, 0);
		__instance.inventoryButton.transform.localScale += new Vector3(0.02f, 0f, 0);
		__instance.shopButton.transform.localScale += new Vector3(0.02f, 0f, 0);
		__instance.myAccountButton.transform.localScale += new Vector3(0.02f, 0f, 0);
		__instance.newsButton.transform.localScale += new Vector3(0.02f, 0f, 0);
		__instance.settingsButton.transform.localScale += new Vector3(0.02f, 0f, 0);
        __instance.quitButton.transform.localScale += new Vector3(0.03f, 0f, 0);

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
		closeRightSpriteRenderer.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.UI.RightPanelCloseButton.png", 100f);
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
        Showpop.fontAssetVersionShower = __instance.text.font;
        RoleIntroduction.fontAssetVersionShower = __instance.text.font;

        __instance.text.fontSize = 1.5f;
        __instance.text.text = $"AmongUs v{DestroyableSingleton<ReferenceDataManager>.Instance.Refdata.userFacingVersion}-{Helpers.GradientColorText("00FFFF", "0000FF", $"{TheOtherRolesEditedPlugin.Title}")} v{TheOtherRolesEditedPlugin.VersionString}";
        __instance.text.text += "\n" + string.Format(ModTranslation.getString("ToDateToday"), ModUsageRequest.visit + 3000);
		__instance.text.gameObject.GetComponent<RectTransform>().transform.localPosition += new Vector3(-0.3f, 0.272f, 0f);
		__instance.text.alignment = AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Started ? TextAlignmentOptions.Bottom : TextAlignmentOptions.BottomLeft;
		__instance.text.gameObject.GetComponent<RectTransform>().sizeDelta = new(2.5f, 0.9f);
	}


	[HarmonyPatch(typeof(AnnouncementPanel), nameof(AnnouncementPanel.SetUp)), HarmonyPostfix]
	public static void SetUpPanel(AnnouncementPanel __instance, [HarmonyArgument(0)] Announcement announcement)
	{
		if (announcement.Number < 100000) return;
		var XtremeWave = new GameObject("XtremeWave") { layer = 5 };
		XtremeWave.transform.SetParent(__instance.transform);
		XtremeWave.transform.localPosition = new Vector3(-0.81f, 0.16f, 0.5f);
		XtremeWave.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
		var sr = XtremeWave.AddComponent<SpriteRenderer>();
		sr.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.UI.XtremeWave.png", 1000f);
		sr.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
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


	[HarmonyPatch(typeof(HostLocalGameButton), nameof(HostLocalGameButton.Start))]
	public static class LocalGameModePatch
	{
		static void Postfix(HostLocalGameButton __instance)
		{
			if (__instance.TryGetComponent(Il2CppType.Of<FreeplayPopover>(), out _)) return;
			__instance.transform.FindChild("CreateHnSGameButton")?.gameObject.SetActive(false);
		}
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

[HarmonyPatch(typeof(ModManager), nameof(ModManager.LateUpdate))]
internal class ModManagerLateUpdatePatch
{
    public static void Prefix(ModManager __instance) => __instance.ShowModStamp();

    public static void Postfix(ModManager __instance)
    {
        float offset_y = HudManager.InstanceExists ? 1.1f : 1.1f;
        __instance.ModStamp.transform.position = AspectPosition.ComputeWorldPosition(
            __instance.localCamera, AspectPosition.EdgeAlignments.RightTop,
            new Vector3(0.4f, offset_y, __instance.localCamera.nearClipPlane + 0.1f));
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
				p.cosmetics.nameText.text = $"<color=#7bbfea>{c.PlayerName}</color>\n<size=60%>{p.GetPlatform()}</size>";
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