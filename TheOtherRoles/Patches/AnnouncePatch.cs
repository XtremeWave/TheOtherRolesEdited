using HarmonyLib;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using TMPro;
using UnityEngine.UI;
using BepInEx.Unity.IL2CPP.Utils;
using UnityEngine.Events;
using System;
using System.Text.RegularExpressions;
using Object = UnityEngine.Object;

namespace TheOtherRolesEdited.Modules
{
    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start)), HarmonyPriority(Priority.First)]
    class Showpop
    {
        internal static TMP_FontAsset fontAsset;
        internal static TMP_FontAsset fontAssetVersionShower;
        private static bool hasShownPopup = false;
        private static readonly string AnnouncementUrl = Helpers.isChinese() ? "https://tore.amongusclub.cn/Announcement.json": "https://github.com/XtremeWave/MOTD/blob/main/Announcement.txt";
        private static readonly string githubApiUrl = "https://api.github.com/repos/XtremeWave/TheOtherRolesEdited/releases";

        private const float MinYOffset = 2.5f;    // 最低减少值
        private const float BaseYOffset = 0.7f;   // 少于4行时的基础减少值
        private const float LineOffset = 0.1f;   // 每增加一行额外减少值
        private const int BaseLineCount = 4;      // 基础行数阈值

        public static void showPopup(string text, bool isUpdate = false, MainMenuManager __instance = null)
        {
            if (hasShownPopup) return;
            hasShownPopup = true;
            string formattedText = ConvertMarkdown(text);
            string title = isUpdate ? ModTranslation.getString("UpdateAnnouncement") : ModTranslation.getString("Announcement");

            var popup = UnityEngine.Object.Instantiate(DiscordManager.Instance.discordPopup, Camera.main!.transform);

            var originalTMP = popup.transform.Find("Text_TMP");
            if (originalTMP != null)
            {
                var titleTMP = Object.Instantiate(originalTMP.gameObject, popup.transform);
                titleTMP.name = "Title_TMP";
                var titleTMPComponent = titleTMP.GetComponent<TMP_Text>();
                if (titleTMPComponent != null)
                {
                    titleTMPComponent.richText = true;
                    titleTMPComponent.font = fontAsset;
                    titleTMPComponent.fontSize = 80;
                    titleTMPComponent.color = Color.white;
                    titleTMPComponent.alignment = TextAlignmentOptions.Center;
                    titleTMPComponent.text = title;
                    titleTMPComponent.rectTransform.localScale = new Vector3(2.8f, 2.8f, 1f);
                    titleTMPComponent.rectTransform.localPosition += new Vector3(0f, 1.5f, 0f);
                  
                }
            }
            var background = popup.transform.Find("Background");
            if (background != null)
                UnityEngine.Object.Destroy(background.gameObject);

            var exitBtn = popup.transform.Find("ExitGame");
            if (exitBtn != null)
            {
                var btnSpriteRenderer = exitBtn.GetComponent<SpriteRenderer>();
                if (btnSpriteRenderer != null)
                {
                    Sprite customBgSprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.MainPhoto.Button.png", 100f);
                    if (customBgSprite != null)
                    {
                        btnSpriteRenderer.sprite = customBgSprite;
                    }
                }
                exitBtn.transform.localScale = new(0.6f, 0.6f, 1f);
                var pos = exitBtn.localPosition;

                int lineCount = CalculateLineCount(formattedText);
                float yOffset = CalculateYOffset(lineCount);
                pos.y -= yOffset;
                exitBtn.localPosition = pos;
                var buttonText = exitBtn.transform.GetComponentInChildren<TMPro.TMP_Text>();
                if (buttonText != null && __instance != null)
                {
                    __instance.StartCoroutine(Effects.Lerp(0.5f, new System.Action<float>((p) =>
                    {
                        buttonText.SetText($"{ModTranslation.getString("Close")}");
                        buttonText.font = fontAsset;
                    })));
                }
            }

            popup.TextAreaTMP.richText = true;
            popup.TextAreaTMP.fontSizeMin = 2;
            popup.TextAreaTMP.SetOutlineColor(Color.black);
            popup.TextAreaTMP.SetOutlineThickness(0.12f);
            popup.TextAreaTMP.font = fontAssetVersionShower;
            popup.TextAreaTMP.rectTransform.localScale = new Vector3(0.85f, 0.85f, 1f);
            popup.TextAreaTMP.rectTransform.localPosition -= new Vector3(0f, 0.3f, 0f);
            popup.Show(formattedText);
        }

        private static int CalculateLineCount(string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0;

            string[] lines = text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            int validLineCount = 0;
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                    validLineCount++;
            }

            return validLineCount;
        }

        private static float CalculateYOffset(int lineCount)
        {
            if (lineCount <= BaseLineCount)
                return BaseYOffset;

            int extraLines = lineCount - BaseLineCount;
            float calculatedOffset = BaseYOffset + (extraLines * LineOffset);

            return Mathf.Min(calculatedOffset, MinYOffset);
        }

        private static string ConvertMarkdown(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string result = input;
            result = Regex.Replace(result, @"\*\*(.*?)\*\*", "<b>$1</b>", RegexOptions.Singleline);
            result = Regex.Replace(result, @"_(.*?)_", "<i>$1</i>", RegexOptions.Singleline);
            result = Regex.Replace(result, @"-(.*?)", "$1", RegexOptions.Singleline);

            return result;
        }

        private static void Postfix(MainMenuManager __instance)
        {
            __instance.StartCoroutine(CheckForUpdates(__instance));
        }

        private static IEnumerator CheckForUpdates(MainMenuManager __instance)
        {
            UnityWebRequest www = UnityWebRequest.Get(githubApiUrl);
            www.SetRequestHeader("User-Agent", "UnityMod");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                showPopup($"无法检测更新: {www.error}", false, __instance);
                yield break;
            }

            List<GithubRelease> releases = null;
            try
            {
                releases = JsonSerializer.Deserialize<List<GithubRelease>>(www.downloadHandler.text);
            }
            catch (Exception ex)
            {
                showPopup($"加载更新信息失败: {ex.Message}", false, __instance);
                yield break;
            }

            if (releases == null || releases.Count == 0)
            {
                yield return LoadAnnouncement(__instance);
                yield break;
            }

            var latest = releases[0];

            Version currentVersion = TheOtherRolesEditedPlugin.Version is Version v
                ? v
                : new Version(TheOtherRolesEditedPlugin.Version.ToString());

            Version latestVersion;
            if (!Version.TryParse(latest.tag_name.TrimStart('v', 'V'), out latestVersion))
            {
                yield return LoadAnnouncement(__instance);
                yield break;
            }

            if (latestVersion > currentVersion)
            {
                string content = @$"<size=120%>请更新至 {latest.tag_name} 最新版本
如果您想知道更新内容可以在<b>TORE按钮</b>中查看<b>更新日志</b>
如果您想快速更新模组建议您使用 <b>[一键更新]</b> 按钮（境内）
如果您无法更新的话建议使用 <b>[手动更新]</b> 按钮（境内/境外）
如果您在境外无法打开模组官网建议使用 <b>[Github]</b> 按钮手动更新（仅境外）</size>";
                showPopup(content, true, __instance);
            }
            else
            {
                yield return LoadAnnouncement(__instance);
            }

            www.Dispose();
        }

        private static IEnumerator LoadAnnouncement(MainMenuManager __instance)
        {
            UnityWebRequest www = UnityWebRequest.Get(AnnouncementUrl);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                showPopup($"加载公告失败: {www.error}", false, __instance);
            }
            else
            {
                string content = www.downloadHandler.text;
                showPopup(content, false, __instance);
            }

            www.Dispose();
        }

        private class GithubRelease
        {
            public string tag_name { get; set; }
        }
    }
}