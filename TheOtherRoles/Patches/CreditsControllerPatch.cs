using HarmonyLib;
using System.Collections.Generic;
using System.Linq;

namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(CreditsController))]
public class CreditsControllerPatch
{
    private static List<CreditsController.CreditStruct> GetModCredits()
    {

        var TeamList = new List<string>()
            {

                $"slok",
                $"喜",
                $"方块",
                $"{TheOtherRolesEditedPlugin.Dev}",
                $"Zxylem",
                $"照路行不行",
                $"一念旧情丶",
                $"小黄117",
                $"中立小黑",
                $"JMS",
                $"空水梦冰",
                $"KpCam",
                $"刻刻刻刻刻薄",
                $"玖咪~啾啾猫猫好爱",
                $"核聚变砂糖橘TvT",
                $"Hartex",
                $"Crewmate Ender&Impostor Ender",
                $"清风",
                $"ZEYAN",
                $"白糖咖啡",
                $"崩pz衫",

            };

        var devList = new List<string>()
            {
                //$"<color=#bd262a><size=150%>{GetString("FromChina")}</size></color>",

                $"{TheOtherRolesEditedPlugin.Dev} - 开发者({Helpers.GradientColorText("00BFFF", "0000FF", $"TheOtherRolesEdited")})",
                $"Eisbison - 开发者(<color=#FF0000>TheOtherRoles</color>)",
                $"尤路丽丝 - 美工",
                $"JMS - 美工",
            };
        var translatorList = new List<string>()
            {
                $"方块 - 贡献者",
                $"YU - 贡献者(<color=#EEC900>MCI</color>)",
            };
        var acList = new List<string>()
            {
                //Mods
                $"<color=#FF0000>TheOtherRoles</color>",
                $"<color=#FF0000>TheOtherRolesGMIA</color>",
                $"<color=#FF0000>TheOtherUs</color>",
                $"<color=#000FFF>YuET</color>",
                $"<color=#00Bfff>TownOfNext</color>",
                $"<color=#00FFFF>TownOfNewEpic_Xtreme</color>",

                // Sponsor
                $"小叨院长",
                $"<color=#FFFF00>屑杰鱼</color>",
                $"A master",
                $"...",
            };

        var credits = new List<CreditsController.CreditStruct>();
        AddTitleToCredits($" <size=500%><color=#cdfffd>{TheOtherRolesEditedPlugin.Team}</color> </size>");
        AddPersonToCredits(TeamList);
        AddSpcaeToCredits();

        AddTitleToCredits("<color=#FF0000>模组开发者</color>");
        AddPersonToCredits(devList);
        AddSpcaeToCredits();

        AddTitleToCredits("<color=#FF0000>模组贡献者</color>");
        AddPersonToCredits(translatorList);
        AddSpcaeToCredits();

        AddTitleToCredits("<color=#FF0000>帮助我们的模组及个人</color>");
        AddPersonToCredits(acList);
        AddSpcaeToCredits();

        return credits;

        void AddSpcaeToCredits()
        {
            AddTitleToCredits(string.Empty);
        }
        void AddTitleToCredits(string title)
        {
            credits.Add(new()
            {
                format = "title",
                columns = new[] { title },
            });
        }
        void AddPersonToCredits(List<string> list)
        {
            foreach (var line in list)
            {
                var cols = line.Split(" - ").ToList();
                if (cols.Count < 2) cols.Add(string.Empty);
                credits.Add(new()
                {
                    format = "person",
                    columns = cols.ToArray(),
                });
            }
        }
    }

    [HarmonyPatch(nameof(CreditsController.AddCredit)), HarmonyPrefix]
    public static void AddCreditPrefix(CreditsController __instance, [HarmonyArgument(0)] CreditsController.CreditStruct originalCredit)
    {
        if (originalCredit.columns[0] != "logoImage") return;

        foreach (var credit in GetModCredits())
        {
            __instance.AddCredit(credit);
            __instance.AddFormat(credit.format);
        }
    }
}