using System.Text.RegularExpressions;
using AmongUs.Data;
using HarmonyLib;
using InnerNet;
using TheOtherRolesEdited.Modules;
using TMPro;
using UnityEngine;

namespace TheOtherRolesEdited.Patches;

[HarmonyPatch]
public sealed class LobbyJoinBind
{
    private static int GameId;

    private static GameObject LobbyText;
    internal static TMP_FontAsset fontAssetPingTracker;

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
            LobbyText.transform.localPosition = new Vector3(10.9f, -0.6f, 0);
            LobbyText.SetActive(true);
        }
    }

    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.LateUpdate))]
    [HarmonyPostfix]
    public static void Postfix(MainMenuManager __instance)
    {
        var code2 = GUIUtility.systemCopyBuffer;

        if (code2.Length != 6 || !Regex.IsMatch(code2, @"^[a-zA-Z]+$"))
            code2 = "";
        var code2Disp = DataManager.Settings.Gameplay.StreamerMode ? "****" : code2.ToUpper();
        if (GameId != 0 && Input.GetKeyDown(KeyCode.LeftShift))
            __instance.StartCoroutine(AmongUsClient.Instance.CoJoinOnlineGameFromCode(GameId));
        else if (Input.GetKeyDown(KeyCode.RightShift) && code2 != "")
            __instance.StartCoroutine(AmongUsClient.Instance.CoJoinOnlineGameFromCode(GameCode.GameNameToInt(code2)));

        if (LobbyText)
        {
            LobbyText.GetComponent<TextMeshPro>().text = "";
            if (GameId != 0 && GameId != 32)
            {
                var code = GameCode.IntToGameName(GameId);
                if (code != "")
                {
                    code = DataManager.Settings.Gameplay.StreamerMode ? "<color=#F64343>****</color>" : code;
                    LobbyText.GetComponent<TextMeshPro>().text = $"{ModTranslation.getString("PrevLobby")}: <color=#3ED1FE>{code}</color>   [LShift]";
                }
            }

            if (code2 != "") LobbyText.GetComponent<TextMeshPro>().text += $"\n{ModTranslation.getString("Clipboard")}: <color=#FEC73E>{code2Disp}</color>  [RShift]";
        }
    }
}