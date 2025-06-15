using AmongUs.QuickChat;
using CsvHelper;
using HarmonyLib;
using Rewired.Utils.Platforms.Windows;
using UnityEngine;

namespace TheOtherRolesEdited.Patches;

[HarmonyPatch(typeof(ChatBubble))]
public static class ChatBubblePatch
{

    public static string ColorString(Color32 color, string str) => $"<color=#{color.r:x2}{color.g:x2}{color.b:x2}{color.a:x2}>{str}</color>";

    [HarmonyPatch(nameof(ChatBubble.SetText)), HarmonyPrefix]
    public static void SetTextPrefix(ChatBubble __instance, ref string chatText)
    {
        if (chatText.Contains("░") ||
           chatText.Contains("▄") ||
           chatText.Contains("█") ||
           chatText.Contains("▌") ||
           chatText.Contains("▒") ||
           chatText.Contains("乐子") ||
           chatText.Contains("傻逼") ||
           chatText.Contains("骚") ||
           chatText.Contains("操你妈") ||
           chatText.Contains("操") ||
           chatText.Contains("妈") ||
           chatText.Contains("日") ||
           chatText.Contains("你吗") ||
           chatText.Contains("尼玛") ||
           chatText.Contains("cnm") ||
           chatText.Contains("阴") ||
           chatText.Contains("几把") ||
           chatText.Contains("机霸") ||
           chatText.Contains("鸡巴") ||
           chatText.Contains("寄吧") ||
           chatText.Contains("jerk off") ||
           chatText.Contains("没妈") ||
           chatText.Contains("没马") ||
           chatText.Contains("没木") ||
           chatText.Contains("没母") ||
           chatText.Contains("梅马") ||
           chatText.Contains("梅母") ||
           chatText.Contains("梅木") ||
           chatText.Contains("梅妈") ||
           chatText.Contains("酸萝卜别吃") ||
           chatText.Contains("妈死") ||
           chatText.Contains("妈四") ||
           chatText.Contains("妈亖") ||
           chatText.Contains("马思") ||
           chatText.Contains("马死") ||
           chatText.Contains("马四") ||
           chatText.Contains("马亖") ||
           chatText.Contains("马思") ||
           chatText.Contains("想死") ||
           chatText.Contains("相思") ||
           chatText.Contains("开户") ||
           chatText.Contains("老子") ||
           chatText.Contains("死") ||
           chatText.Contains("你m") ||
           chatText.Contains("草泥马") ||
           chatText.Contains("你妈是不是炸了") ||
           chatText.Contains("泥马") ||
           chatText.Contains("尼玛是不是炸了") ||
           chatText.Contains("lezi") ||
           chatText.Contains("后入") ||
           chatText.Contains("厚入") ||
           chatText.Contains("吃B") ||
           chatText.Contains("贝塔") ||
           chatText.Contains("精子") ||
           chatText.Contains("婊") ||
           chatText.Contains("妓") ||
           chatText.Contains("fuck") ||
           chatText.Contains("bitch") ||
           chatText.Contains("你妈") ||
           chatText.Contains("塞你") ||
           chatText.Contains("塞尼") ||
           chatText.Contains("c你") ||
           chatText.Contains("赛你") ||
           chatText.Contains("rnm") ||
           chatText.Contains("吊") ||
           chatText.Contains("jb") ||
           chatText.Contains("骚逼") ||
           chatText.Contains("贱") ||
           chatText.Contains("鸡巴") ||
           chatText.Contains("机霸") ||
           chatText.Contains("几把") ||
           chatText.Contains("即把") ||
           chatText.Contains("臭B") ||
           chatText.Contains("臭比") ||
           chatText.Contains("臭笔") ||
           chatText.Contains("日尼玛") ||
           chatText.Contains("煞笔") ||
           chatText.Contains("沙比") ||
           chatText.Contains("傻比") ||
           chatText.Contains("啥比") ||
           chatText.Contains("沙壁") ||
           chatText.Contains("傻笔") ||
           chatText.Contains("啥币") ||
           chatText.Contains("莎比") ||
           chatText.Contains("砂壁") ||
           chatText.Contains("nmsl") ||
           chatText.Contains("nm") ||
           chatText.Contains("口吊") ||
           chatText.Contains("尼玛死了") ||
           chatText.Contains("你妈死了") ||
           chatText.Contains("有马") ||
           chatText.Contains("你爸") ||
           chatText.Contains("你爹") ||
           chatText.Contains("sb"))
        {
            chatText = $"{Helpers.GradientColorText("FFFF00", "FF0000", $"【违规消息】")}";
        }
    }
        private static bool IsModdedMsg(string name) => name.EndsWith('\0');


        [HarmonyPatch(nameof(ChatBubble.SetText)), HarmonyPrefix]
        public static void SetText_Prefix(ChatBubble __instance, ref string chatText)
        {
            var bgcolor = ColorHelper.HalfModColor32;
            var sr = __instance.Background;
            Color namecolor = ColorHelper.FaultColor;
            string name = null;
            var modded = IsModdedMsg(__instance.playerInfo.PlayerName);
            if (__instance?.playerInfo?.PlayerId == null)
            {
                bgcolor = ColorHelper.HalfYellow;
            }
            else if (modded)
            {
                bgcolor = Color.black;
                namecolor = ColorHelper.TeamColor32;
                chatText = ColorString(Color.white, chatText.TrimEnd('\0'));
                __instance.SetLeft();
            }
            else if (__instance.NameText.color == Color.green)
            {
                bgcolor = ColorHelper.HalfYellow;
                namecolor = ColorHelper.TeamColor32;
            }
            else
            {
                XtremeLocalHandling.GetChatBubbleText(
                    __instance.playerInfo.PlayerId,
                    ref name,
                    ref bgcolor,
                    ref namecolor
                );

            }

            __instance.NameText.color = namecolor;
            __instance.NameText.text = name ?? __instance.NameText.text;
            sr.color = bgcolor;


        }
    }
//来自YUAC的代码