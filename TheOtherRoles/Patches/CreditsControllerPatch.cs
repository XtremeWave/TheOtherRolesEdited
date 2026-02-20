#if PC
using HarmonyLib;
using Rewired.Utils.Platforms.Windows;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(CreditsScreenPopUp))]
internal class CreditsScreenPopUpPatch
{
    [HarmonyPatch(nameof(CreditsScreenPopUp.OnEnable))]
    public static void Postfix(CreditsScreenPopUp __instance)
    {
        __instance.BackButton.transform.parent.FindChild("Background").gameObject.SetActive(false);

        var followUs = __instance.BackButton.transform.parent.FindChild("FollowUs");
        followUs.FindChild("TwitterIcon").gameObject.SetActive(false);

        var qqIcon = followUs.FindChild("FacebookIcon");
        qqIcon.GetComponent<TwitterLink>().LinkUrl = "https://qm.qq.com/q/roXbwr7R2S";
        qqIcon.GetComponent<SpriteRenderer>().sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.MainPhoto.qqlogo.png", 1000f);
        qqIcon.gameObject.SetActive(true);

        var dcIcon = followUs.FindChild("Discord-Logo-Color");
        dcIcon.GetComponent<TwitterLink>().LinkUrl = "https://space.bilibili.com/1049954492?spm_id_from=333.1007.0.0";
        dcIcon.GetComponent<SpriteRenderer>().sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.MainPhoto.bilibililogo.png", 200f);
        dcIcon.gameObject.SetActive(true);
    }
}

[HarmonyPatch(typeof(CreditsController))]
public class CreditsControllerPatch
{
    private static List<CreditsController.CreditStruct> GetModCredits()
    {

        var TeamList = new List<string>()
            {

                $"★喜★",
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
                $"{TheOtherRolesEditedPlugin.Dev} - 开发者",
                $"方块 - 开发者 || 服务器支持",
                $"尤路丽丝 - 美工",
                $"JMS - 美工",
            };
        var translatorList = new List<string>()
            {
                $"Imp11 - 贡献者",
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
                $"宇航员",
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
#endif