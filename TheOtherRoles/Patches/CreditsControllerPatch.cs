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

                $"★slok★",
                $"★喜★",
                $"★方块★",
                $"★{TheOtherRolesEditedPlugin.Dev}★",
                $"★Elinmei★",
                $"★Zxylem★",
                $"★照路行不行★",
                $"★一念旧情丶★",
                $"★小黄117★",
                $"★中立小黑★",
                $"★JMS★",
                $"★空水梦冰★",
                $"★KpCam★",
                $"★刻刻刻刻刻薄★",
                $"★玖咪~啾啾猫猫好爱★",
                $"★核聚变砂糖橘TvT★",
                $"★Hartex★",
                $"★ Crewmate Ender&Impostor Ender★",
                $"★清风★",
                $"★ZEYAN★",
                $"★白糖咖啡★",
                $"★崩pz衫★",

            };

        var devList = new List<string>()
            {
                $"{TheOtherRolesEditedPlugin.Dev} - 开发者({Helpers.GradientColorText("00BFFF", "0000FF", $"TheOtherRolesEdited")})",
                $"Eisbison - 开发者(<color=#FF0000>TheOtherRoles</color>)",
                $"尤路丽丝 - 美工",
                $"JMS - 美工",
            };
        var translatorList = new List<string>()
            {
                $"方块 - 贡献者",
                $"Elinmei - 贡献者",
            };
        var acList = new List<string>()
            {
                //Mods
                $"{Helpers.GradientColorText("FC0000", "FEE50A", $"TheOtherRolesGMIA")}",
                $"<color=#FF0000>TheOtherUs</color>",
                $"<color=#FF0000>TheOtherUsEdited</color>",
                $"<color=#FF0000>TheOtherRolesRework</color>",
                $"<color=#001EFC>YuET</color>",
                $"<color=#FC77D1>TownOfNext</color>",

                // Sponsor
                $"小叨院长",
                $"屑杰鱼",
                $"A master",
                $"TAIKonguo",
                $"Elinmei",
                $"Imp11",
                $"...",
            };

        var credits = new List<CreditsController.CreditStruct>();
        AddTitleToCredits($" <size=500%>★<color=#cdfffd>{TheOtherRolesEditedPlugin.Team}</color>★</size>");
        AddPersonToCredits(TeamList);
        AddSpcaeToCredits();

        AddTitleToCredits("★<color=#FCF300>模组开发者</color>★");
        AddPersonToCredits(devList);
        AddSpcaeToCredits();

        AddTitleToCredits("★<color=#00BDFC>模组贡献者</color>★");
        AddPersonToCredits(translatorList);
        AddSpcaeToCredits();

        AddTitleToCredits($"★{Helpers.GradientColorText("0011FC", "FC00AC", $"帮助我们的模组及个人")}★");
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