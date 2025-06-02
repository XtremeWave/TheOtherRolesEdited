using AmongUs.Data;
using AmongUs.GameOptions;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using TheOtherRolesEdited;
using TheOtherRolesEdited.CustomGameModes;
using TheOtherRolesEdited.Players;
using TheOtherRolesEdited.Utilities;
using TMPro;
using UnityEngine;
using Color = UnityEngine.Color;

namespace TheOtherRolesEdited.Patches
{
    [HarmonyPatch]
    public static class CredentialsPatch
    {
        public static string fullCredentialsVersion =
$@"<size=150%>{Helpers.GradientColorText("00BFFF", "0000FF", $"{TheOtherRolesEditedPlugin.Id}")}</size> v{TheOtherRolesEditedPlugin.Version.ToString() + (TheOtherRolesEditedPlugin.betaDays > 0 ? "-BETA" : "")}";
        public static string fullCredentials =
            $@"<size=75%>{Helpers.GradientColorText("FFD700", "FF0000", $"TOR")}模组作者:<color=#FCCE03FF>Eisbison</color>, <color=#FCCE03FF>EndOfFile</color>
<color=#FCCE03FF>Thunderstorm584</color>, <color=#FCCE03FF>Mallöris</color> & <color=#FCCE03FF>Gendelo</color>
美术:<color=#FCCE03FF>Bavari</color>
{Helpers.GradientColorText("00BFFF", "0000FF", $"{TheOtherRolesEditedPlugin.Name}")}模组作者:<color=#FCCE03FF>{TheOtherRolesEditedPlugin.Dev}</color>
美术:<color=#FCCE03FF>{TheOtherRolesEditedPlugin.Dev}</color>, <color=#FCCE03FF>尤路丽丝</color> & <color=#FCCE03FF>JMS</color>
中文翻译:<color=#FCCE03FF>{TheOtherRolesEditedPlugin.Dev}</color> & <color=#FCCE03FF>FangKuaiYa</color>";

        [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
        internal static class PingTrackerPatch
        {
            private static string PingTextColor;
            private static float deltaTime;
            public static string ServerName = "";
            private static Sprite commsdown;

            static void Postfix(PingTracker __instance)
            {
                if (!__instance.GetComponentInChildren<SpriteRenderer>())
                {
                    var spriteObject = new GameObject("WIFI Sprite");
                    spriteObject.AddComponent<SpriteRenderer>().sprite = commsdown;
                    spriteObject.transform.parent = __instance.transform;
                    spriteObject.transform.localPosition = new Vector3(3.5958f, -3.2061f, -1);
                    spriteObject.transform.localScale *= 0.72f;
                    var TORE = spriteObject.GetComponent<SpriteRenderer>();
                    TORE.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.TORE - Photo.png", 450f);

                }
                var ping = AmongUsClient.Instance.Ping;
                if (ping < 10) PingTextColor = ("<color=#ff0000>");
                else if (ping < 50) PingTextColor = ("<color=#00ffff>");
                else if (ping < 100) PingTextColor = ("<color=#00ec00>");
                else if (ping < 200) PingTextColor = ("<color=#ff44ff>");
                else if (ping < 300) PingTextColor = ("<color=#8600ff>");
                else if (ping < 400) PingTextColor = ("<color=#ff0000>");
                else if (ping > 700) PingTextColor = ("<color=#ff0000>");

                deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
                float fps = Mathf.Ceil(1.0f / deltaTime);

                __instance.text.alignment = AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Started ? TextAlignmentOptions.Top : TextAlignmentOptions.TopLeft;
                var position = __instance.GetComponent<AspectPosition>();
                position.Alignment = AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Started ? AspectPosition.EdgeAlignments.Top : AspectPosition.EdgeAlignments.LeftTop;

                if (AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Started)
                {
                    string gameModeText = $"";
                    if (HideNSeek.isHideNSeekGM) gameModeText = $"捉迷藏模式";
                    else if (HandleGuesser.isGuesserGm) gameModeText = $"赌怪模式";
                    else if (PropHunt.isPropHuntGM) gameModeText = $"变形躲猫猫模式";
                    if (gameModeText != "") gameModeText = Helpers.cs(Color.yellow, gameModeText) + "\n";
                    if (ModOption.DebugMode) gameModeText += "<color=#FF0000>(Debug Mode)</color>\n";
                    __instance.text.alignment = TextAlignmentOptions.TopRight;
                    __instance.text.text = $"<size=130%>{Helpers.GradientColorText("00FFFF", "0000FF", $"TheOtherRolesEdited")}</size> v{TheOtherRolesEditedPlugin.Version.ToString() + (TheOtherRolesEditedPlugin.betaDays > 0 ? "-BETA" : "")}\n<size=100%>By:<color=#cdfffd>{TheOtherRolesEditedPlugin.Team}</color>\n{PingTextColor}{AmongUsClient.Instance.Ping}<size=40%>ping</size></color>       <color=#01A4F4>{fps}<size=40%>fps</size></color>\n{gameModeText}";
                    __instance.text.outlineColor = Color.black;
                    __instance.text.outlineWidth = 0.25f;
                    position.DistanceFromEdge = new Vector3(2.7f, 0.11f, 0);
                }
                else
                {
                    string gameModeText = $"";
                    if (TORMapOptions.gameMode == CustomGamemodes.HideNSeek) gameModeText = $"捉迷藏模式";
                    else if (TORMapOptions.gameMode == CustomGamemodes.Guesser) gameModeText = $"赌怪模式";
                    else if (TORMapOptions.gameMode == CustomGamemodes.PropHunt) gameModeText = $"变形躲猫猫模式";
                    if (gameModeText != "") gameModeText = Helpers.cs(Color.yellow, gameModeText) + "\n";
                    if (ModOption.DebugMode) gameModeText += "<color=#FF0000>(Debug Mode)</color>\n";
                    __instance.text.text = $"{fullCredentialsVersion}\n{gameModeText + fullCredentials}\n" + $"{PingTextColor}{AmongUsClient.Instance.Ping}<size=40%>ping</size></color>        <color=#01A4F4>{fps}<size=40%>fps</size></color>" +
                        $"\n  <size=80%><color=#FFDCB1>◈" + $"{XtremeGameData.GameStates.GetRegionName()}</color></size>";
                    __instance.text.outlineColor = Color.black;
                    __instance.text.outlineWidth = 0.25f;
                    position.DistanceFromEdge = new Vector3(0.5f, 0.11f);

                    try
                    {
                        var GameModeText = GameObject.Find("GameModeText")?.GetComponent<TextMeshPro>();
                        GameModeText.text = gameModeText == "" ? (GameOptionsManager.Instance.currentGameOptions.GameMode == GameModes.HideNSeek ? "官方躲猫猫" : "经典模式") : gameModeText;
                        var ModeLabel = GameObject.Find("ModeLabel")?.GetComponentInChildren<TextMeshPro>();
                        ModeLabel.text = "游戏模式";
                    }
                    catch { }
                }
                position.AdjustPosition();
            }
        }

        [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
        public static class LogoPatch
        {
            public static SpriteRenderer renderer;
            public static Sprite bannerSprite;
            public static Sprite horseBannerSprite;
            public static Sprite banner2Sprite;
            private static PingTracker instance;
            public static GameObject motdObject;
            public static TextMeshPro motdText;
            static void Postfix(PingTracker __instance)
            {
                var torLogo = new GameObject("bannerLogo_TOR");
                motdObject = new GameObject("torMOTD");
                motdText = motdObject.AddComponent<TextMeshPro>();
                motdText.alignment = TMPro.TextAlignmentOptions.Center;
                motdText.fontSize *= 0.045f;

                motdText.transform.SetParent(torLogo.transform);
                motdText.enableWordWrapping = true;
                var rect = motdText.gameObject.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(5.2f, 0.25f);

                motdText.transform.localPosition = Vector3.down * 2.7f;
                motdText.color = new Color(1, 53f / 255, 31f / 255);
                Material mat = motdText.fontSharedMaterial;
                mat.shaderKeywords = new string[] { "OUTLINE_ON" };
                motdText.SetOutlineColor(Color.white);
                motdText.SetOutlineThickness(0.095f);
            }

            public static void updateSprite()
            {
                //      loadSprites();
                if (renderer != null)
                {
                    float fadeDuration = 1f;
                    instance.StartCoroutine(Effects.Lerp(fadeDuration, new Action<float>((p) =>
                    {
                        renderer.color = new Color(1, 1, 1, 1 - p);
                        if (p == 1)
                        {
                            renderer.sprite = TORMapOptions.enableHorseMode ? horseBannerSprite : bannerSprite;
                            instance.StartCoroutine(Effects.Lerp(fadeDuration, new Action<float>((p) =>
                            {
                                renderer.color = new Color(1, 1, 1, p);
                            })));
                        }
                    })));
                }
            }
        }

        [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.LateUpdate))]
        public static class MOTD
        {
            public static List<string> motds = new List<string>();
            private static float timer = 0f;
            private static float maxTimer = 5f;
            private static int currentIndex = 0;

            public static void Postfix()
            {
                if (motds.Count == 0)
                {
                    timer = maxTimer;
                    return;
                }
                if (motds.Count > currentIndex && LogoPatch.motdText != null)
                    LogoPatch.motdText.SetText(motds[currentIndex]);
                else return;

                // fade in and out:
                float alpha = Mathf.Clamp01(Mathf.Min(new float[] { timer, maxTimer - timer }));
                if (motds.Count == 1) alpha = 1;
                LogoPatch.motdText.color = LogoPatch.motdText.color.SetAlpha(alpha);
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = maxTimer;
                    currentIndex = (currentIndex + 1) % motds.Count;
                }
            }

            public static async Task loadMOTDs()
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://api.fangkuai.fun:22022/XtremeWave/MOTD/main/motd.txt");
                response.EnsureSuccessStatusCode();
                string motds = await response.Content.ReadAsStringAsync();
                foreach (string line in motds.Split("\n", StringSplitOptions.RemoveEmptyEntries))
                {
                    MOTD.motds.Add(line);
                }

            }
        }
    }
}