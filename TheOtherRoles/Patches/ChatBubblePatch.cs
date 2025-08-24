using AmongUs.QuickChat;
using CsvHelper;
using HarmonyLib;
using Rewired.Utils.Platforms.Windows;
using TheOtherRolesEdited.Modules;
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
           chatText.Contains("中华民国") ||
           chatText.Contains("ROC") ||
           chatText.Contains("roc") ||
           chatText.Contains("台湾国") ||
           chatText.Contains("台湾独立") ||
           chatText.Contains("台独") ||
           chatText.Contains("香港独立") ||
           chatText.Contains("港独") ||
           chatText.Contains("澳门独立") ||
           chatText.Contains("澳独") ||
           chatText.Contains("西藏独立") ||
           chatText.Contains("藏独") ||
           chatText.Contains("新疆独立") ||
           chatText.Contains("疆独") ||
           chatText.Contains("赖清德") ||
           chatText.Contains("蔡英文") ||
           chatText.Contains("要独立") ||
           chatText.Contains("搞独立") ||
           chatText.Contains("中华人民共和国") ||
           chatText.Contains("中国") ||
           chatText.Contains("习近平") ||
           chatText.Contains("邓小平") ||
           chatText.Contains("江泽民") ||
           chatText.Contains("毛泽东") ||
           chatText.Contains("PRC") ||
           chatText.Contains("共产党") ||
           chatText.Contains("国民党") ||
           chatText.Contains("民进党") ||
           chatText.Contains("台湾当局") ||
           chatText.Contains("总统") ||
           chatText.Contains("主席") ||
           chatText.Contains("民主") ||
           chatText.Contains("政治") ||
           chatText.Contains("独裁") ||
           chatText.Contains("Taiwanese")||
           chatText.Contains("Republic of China") ||
           chatText.Contains("Republic of Taiwan") ||
           chatText.Contains("Taiwan independence") ||
           chatText.Contains("Hong Kong independence") ||
           chatText.Contains("Macao independence") ||
           chatText.Contains("Tibet independence") ||
           chatText.Contains("xinjiang independence") ||
           chatText.Contains("XinJing independence") ||
           chatText.Contains("Lai Ching-te") ||
           chatText.Contains("Tsai Ing-wen") ||
           chatText.Contains("want to be independent") ||
           chatText.Contains("engage in independence") ||
           chatText.Contains("People's Republic of China") ||
           chatText.Contains("Xi JingPing") ||
           chatText.Contains("XiJingPing") ||
           chatText.Contains("XIJINGPING") ||
           chatText.Contains("Communist Party") ||
           chatText.Contains("Kuomintang") ||
           chatText.Contains("Democratic Progressive Party") ||
           chatText.Contains("Taiwan authorities") ||
           chatText.Contains("president") ||
           chatText.Contains("chairman") ||
           chatText.Contains("democracy") ||
           chatText.Contains("politics") ||
           chatText.Contains("dictatorship"))
        {
            chatText = $"{Helpers.GradientColorText("FFFF00", "FF0000", $"\n{ModTranslation.getString("Politics")}")}";
        }
    }
        private static bool IsModdedMsg(string name) => name.EndsWith('\0');
    }
//来自YUAC的代码