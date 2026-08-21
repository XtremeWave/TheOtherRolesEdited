using HarmonyLib;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using UnityEngine;
using UnityEngine.UIElements;

namespace TheOtherRolesEdited;

[HarmonyPatch]
public class ModUsageRequest
{
    public static bool firstStart = true;
    public static int visit = 0;

    private static readonly string URL_2018k = "http://api.2018k.cn";
    public static string UrlSetId(string url) => url + "?id=A9F4F129CA2049F4A50B874748D86B91";
    public static string UrlSetInfo(string url) => url + "/getExample";

    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start)), HarmonyPostfix, HarmonyPriority(Priority.LowerThanNormal)]
    public static void StartPostfix()
    {
        AddVisit();
        firstStart = false;
    }

    public static void AddVisit()
    {
        if (!firstStart) return;
        TheOtherRolesEditedPlugin.Logger.LogMessage("AddVisit | 开始从2018k检查visit");
        string url = UrlSetId(UrlSetInfo(URL_2018k)) + "&data=visit";
        try
        {
            string[] data = Get(url).Split("|");
            visit = int.TryParse(data[0], out int x) ? x : 0;

            TheOtherRolesEditedPlugin.Logger.LogInfo("2018k | Visit: " + data[0]);
        }
        catch (Exception ex)
        {
            TheOtherRolesEditedPlugin.Logger.LogError("AddVisit | 增加Visit时发生错误，已忽略\n" + ex);
            return;
        }
    }
    public static string Get(string url)
    {
        string result = string.Empty;
        HttpClient req = new HttpClient();
        var res = req.GetAsync(url).Result;
        Stream stream = res.Content.ReadAsStreamAsync().Result;
        try
        {
            using StreamReader reader = new(stream);
            result = reader.ReadToEnd();
        }
        finally
        {
            stream.Close();
        }
        return result;
    }
}