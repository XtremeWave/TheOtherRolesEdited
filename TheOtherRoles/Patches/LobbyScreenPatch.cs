using System.Text.RegularExpressions;
using AmongUs.Data;
using HarmonyLib;
using InnerNet;
using TheOtherRolesEdited.Modules;
using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace TheOtherRolesEdited.Patches;

[HarmonyPatch]
public sealed class LobbyJoinBind
{
    private static int GameId;
    private static GameObject LobbyText;
    internal static TMP_FontAsset fontAssetPingTracker;
    private static GameObject previousLobbyButton;
    private static GameObject clipboardLobbyButton;

    [HarmonyPatch(typeof(InnerNetClient), nameof(InnerNetClient.JoinGame))]
    [HarmonyPostfix]
    public static void Postfix(InnerNetClient __instance)
    {
        GameId = __instance.GameId;
    }

    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    [HarmonyPostfix]
    public static void Postfix()
    {
        if (!LobbyText)
        {
            LobbyText = new GameObject("lobbycode");
            var comp = LobbyText.AddComponent<TextMeshPro>();
            comp.fontSize = 2.5f;
            comp.font = fontAssetPingTracker;
            comp.outlineWidth = -2f;
            LobbyText.transform.localPosition = new Vector3(10.67f, -0.55f, 0);
            LobbyText.SetActive(true);
        }
    }

    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.LateUpdate))]
    [HarmonyPostfix]
    public static void Postfix(MainMenuManager __instance)
    {
        var template = GameObject.Find("CreditsButton");
        if (!template) return;

        CreatePreviousLobbyButton(template, __instance);

        CreateClipboardLobbyButton(template, __instance);

        HandleLobbyTextAndHotkeys(__instance);
    }


    private static void CreatePreviousLobbyButton(GameObject template, MainMenuManager instance)
    {
        if (previousLobbyButton == null)
        {
            previousLobbyButton = Object.Instantiate(template, template.transform.parent);
            previousLobbyButton.name = "PreviousLobbyButton";
            previousLobbyButton.transform.localScale = new Vector3(0.3f, 0.7f, 0);
            previousLobbyButton.GetComponent<AspectPosition>().anchorPoint = new Vector2(1.48f, 1.06f);

            var TMP_1 = previousLobbyButton.transform.FindChild("FontPlacer").gameObject;
            TMP_1.transform.localScale = new Vector3(2.4f, 1f, 1f);
            TMP_1.transform.localPosition -= new Vector3(1.8f, 0f, 1f);

            var passiveButton = previousLobbyButton.GetComponent<PassiveButton>();
            passiveButton.OnClick = new Button.ButtonClickedEvent();
            passiveButton.OnClick.AddListener((System.Action)delegate 
            {
                if (GameId != 0)
                    instance.StartCoroutine(AmongUsClient.Instance.CoJoinOnlineGameFromCode(GameId));
            });
        }

        var text = previousLobbyButton.transform.GetComponentInChildren<TMP_Text>();
        var code = GameId != 0 ? GameCode.IntToGameName(GameId) : "";
        text.SetText($"¢Ù");

        var passiveBtn = previousLobbyButton.GetComponent<PassiveButton>();
        passiveBtn.enabled = GameId != 0 && GameId != 32;
        var color = passiveBtn.enabled ? new Color(0f, 1f, 0.5f) : new Color(0.5f, 0.5f, 0.5f);
        passiveBtn.inactiveSprites.GetComponent<SpriteRenderer>().color = color * 0.6f;
        passiveBtn.activeSprites.GetComponent<SpriteRenderer>().color = color;
    }

    private static void CreateClipboardLobbyButton(GameObject template, MainMenuManager instance)
    {
        var code2 = GUIUtility.systemCopyBuffer;
        if (code2.Length != 6 || !Regex.IsMatch(code2, @"^[a-zA-Z]+$"))
            code2 = "";

        if (clipboardLobbyButton == null)
        {
            clipboardLobbyButton = Object.Instantiate(template, template.transform.parent);
            clipboardLobbyButton.name = "ClipboardLobbyButton";
            clipboardLobbyButton.transform.localScale = new Vector3(0.3f, 0.7f, 0);
            clipboardLobbyButton.GetComponent<AspectPosition>().anchorPoint = new Vector2(1.48f, 0.992f);

            var TMP_2 = clipboardLobbyButton.transform.FindChild("FontPlacer").gameObject;
            TMP_2.transform.localScale = new Vector3(2.4f, 1f, 1f);
            TMP_2.transform.localPosition -= new Vector3(1.8f, 0f, 1f);

            var passiveButton = clipboardLobbyButton.GetComponent<PassiveButton>();
            passiveButton.OnClick = new Button.ButtonClickedEvent();
            passiveButton.OnClick.AddListener((System.Action)delegate
            {
                if (!string.IsNullOrEmpty(code2))
                    instance.StartCoroutine(AmongUsClient.Instance.CoJoinOnlineGameFromCode(GameCode.GameNameToInt(code2)));
            });
        }

        var text = clipboardLobbyButton.transform.GetComponentInChildren<TMP_Text>();
        var code2Disp = DataManager.Settings.Gameplay.StreamerMode ? "****" : code2.ToUpper();
        text.SetText($"¢Ú");

        var passiveBtn = clipboardLobbyButton.GetComponent<PassiveButton>();
        passiveBtn.enabled = !string.IsNullOrEmpty(code2);
        var color = passiveBtn.enabled ? new Color(1f, 0.8f, 0.2f) : new Color(0.5f, 0.5f, 0.5f);
        passiveBtn.inactiveSprites.GetComponent<SpriteRenderer>().color = color * 0.6f;
        passiveBtn.activeSprites.GetComponent<SpriteRenderer>().color = color;
    }

    private static void HandleLobbyTextAndHotkeys(MainMenuManager instance)
    {
        var code2 = GUIUtility.systemCopyBuffer;
        if (code2.Length != 6 || !Regex.IsMatch(code2, @"^[a-zA-Z]+$"))
            code2 = "";
        var code2Disp = DataManager.Settings.Gameplay.StreamerMode ? "****" : code2.ToUpper();

        if (GameId != 0 && Input.GetKeyDown(KeyCode.LeftShift))
            instance.StartCoroutine(AmongUsClient.Instance.CoJoinOnlineGameFromCode(GameId));
        else if (Input.GetKeyDown(KeyCode.RightShift) && code2 != "")
            instance.StartCoroutine(AmongUsClient.Instance.CoJoinOnlineGameFromCode(GameCode.GameNameToInt(code2)));

        if (LobbyText)
        {
            var textComp = LobbyText.GetComponent<TextMeshPro>();
            textComp.text = "";

            if (GameId != 0 && GameId != 32)
            {
                var code = GameCode.IntToGameName(GameId);
                if (code != "")
                {
                    code = DataManager.Settings.Gameplay.StreamerMode ? "<color=#F64343>****</color>" : code;
                    textComp.text = $"{ModTranslation.getString("PrevLobby")}: <color=#3ED1FE>{code}</color>   [LShift] <size=50%>¢Ù</size>";
                }
            }

            if (code2 != "")
                textComp.text += $"\n{ModTranslation.getString("Clipboard")}: <color=#FEC73E>{code2Disp}</color>  [RShift] <size=50%>¢Ú</size>";
        }
    }
}