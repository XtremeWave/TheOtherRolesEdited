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

namespace TheOtherRolesEdited.Modules
{
    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start)), HarmonyPriority(Priority.First)]
    class Showpop
    {
        internal static TMP_FontAsset fontAssetVersionShower;
        private static bool hasShownPopup = false;
        private static readonly string AnnouncementUrl = "https://tore.amongusclub.cn/Announcement.json";
        private static readonly string githubApiUrl = "https://api.github.com/repos/XtremeWave/TheOtherRolesEdited/releases";
        public static void showPopup(string text, bool isUpdate = false)
        {
            if (hasShownPopup) return;
            hasShownPopup = true;

            string formattedText = ConvertMarkdown(text);

            string title = isUpdate ? ModTranslation.getString("UpdateAnnouncement") : ModTranslation.getString("Announcement");
            string fullContent = $"<size=300%>{title}</size>\n\n\n" + formattedText;

            var popup = UnityEngine.Object.Instantiate(DiscordManager.Instance.discordPopup, Camera.main!.transform);

            var background = popup.transform.Find("Background");
            if (background != null)
                UnityEngine.Object.Destroy(background.gameObject);

            var exitBtn = popup.transform.Find("ExitGame");
            if (exitBtn != null)
            {
                exitBtn.transform.localScale = new(0.6f, 0.6f, 1f);
                var pos = exitBtn.localPosition;
                pos.y -= 2.5f;
                exitBtn.localPosition = pos;
            }

            popup.TextAreaTMP.richText = true;
            popup.TextAreaTMP.fontSizeMin = 2;
            popup.TextAreaTMP.SetOutlineColor(Color.black);
            popup.TextAreaTMP.SetOutlineThickness(0.1f);
            popup.TextAreaTMP.font = fontAssetVersionShower;
            if (isUpdate)
            {
               // popup.TextAreaTMP.alignment = TextAlignmentOptions.Left;
                popup.TextAreaTMP.rectTransform.localScale = new Vector3(0.55f, 0.55f, 1f);
               // popup.TextAreaTMP.rectTransform.localPosition = new Vector3(-1.0309f, 0.2564f, 1f);

            }
            else
            {
                popup.TextAreaTMP.rectTransform.localScale = new Vector3(0.85f, 0.85f, 1f);
                popup.TextAreaTMP.rectTransform.localPosition -= new Vector3(0f, 0.3f, 0f);
            }

            popup.Show(fullContent);
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
            __instance.StartCoroutine(CheckForUpdates());
        }

        private static IEnumerator CheckForUpdates()
        {
            UnityWebRequest www = UnityWebRequest.Get(githubApiUrl);
            www.SetRequestHeader("User-Agent", "UnityMod");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                showPopup($"无法检测更新: {www.error}");
                yield break;
            }

            List<GithubRelease> releases = null;
            try
            {
                releases = JsonSerializer.Deserialize<List<GithubRelease>>(www.downloadHandler.text);
            }
            catch (Exception ex)
            {
                showPopup($"加载更新信息失败: {ex.Message}");
                yield break;
            }

            if (releases == null || releases.Count == 0)
            {
                yield return LoadAnnouncement();
                yield break;
            }

            var latest = releases[0];

            Version currentVersion = TheOtherRolesEditedPlugin.Version is Version v
                ? v
                : new Version(TheOtherRolesEditedPlugin.Version.ToString());

            Version latestVersion;
            if (!Version.TryParse(latest.tag_name.TrimStart('v', 'V'), out latestVersion))
            {
                yield return LoadAnnouncement();
                yield break;
            }

            if (latestVersion > currentVersion)
            {
                string chineseContent = ExtractChineseSection(latest.body);
                string content = $"<size=200%>{string.Format(ModTranslation.getString("PleaseUpdate"),latest.tag_name)}</size>\n\n{chineseContent}";
                showPopup(content, true);
            }
            else
            {
                yield return LoadAnnouncement();
            }

            www.Dispose();
        }

        private static string ExtractChineseSection(string releaseBody)
        {
            const string startMarker = "### **中文**";
            const string endMarker = "___________________________________________________________";

            int startIndex = releaseBody.IndexOf(startMarker, StringComparison.Ordinal);
            if (startIndex == -1)
                return "未找到中文更新说明";

            startIndex += startMarker.Length;

            int endIndex = releaseBody.IndexOf(endMarker, startIndex, StringComparison.Ordinal);
            if (endIndex == -1)
                return releaseBody.Substring(startIndex).Trim();

            return releaseBody.Substring(startIndex, endIndex - startIndex).Trim();
        }

        private static IEnumerator LoadAnnouncement()
        {
            UnityWebRequest www = UnityWebRequest.Get(AnnouncementUrl);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                showPopup($"加载公告失败: {www.error}");
            }
            else
            {
                string content = www.downloadHandler.text;
                showPopup(content);
            }

            www.Dispose();
        }

        private class GithubRelease
        {
            public string tag_name { get; set; }
            public string body { get; set; }
        }
    }
}