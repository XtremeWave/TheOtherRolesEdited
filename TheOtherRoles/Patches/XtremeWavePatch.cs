using HarmonyLib;
using AmongUs.Data;
using Rewired.Utils.Platforms.Windows;
using UnityEngine;
using TheOtherRolesEdited.Players;
using System.Linq;
using System.Text;
using Il2CppSystem.Text.RegularExpressions;

namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(LobbyBehaviour), nameof(LobbyBehaviour.Start))]
public class XtremeWavePatch
{
    private static GameObject Paint;
    public static void Postfix(LobbyBehaviour __instance)
    {
        if (Paint != null) return;
        Paint = Object.Instantiate(__instance.transform.FindChild("Leftbox").gameObject, __instance.transform);
        Paint.name = "XtremeWave Lobby Paint";
        Paint.transform.localPosition = new Vector3(0.042f, -2.59f, -10.5f);
        SpriteRenderer renderer = Paint.GetComponent<SpriteRenderer>();
        renderer.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.XtremeWave.png", 290f);
    }
}
[HarmonyPatch(typeof(ChatBubble))]
public class XtremeWavePatchs
{
    [HarmonyPatch(nameof(ChatBubble.SetText)), HarmonyPrefix]
    public static void SetText_Prefix(ChatBubble __instance, ref string chatText)
    {
        var host = GameData.Instance.GetHost();
        if (chatText.Contains("/XW") ||
            chatText.Contains("/X") ||
            chatText.Contains("/Xw") ||
            chatText.Contains("/xW") ||
            chatText.Contains("/XtremeWave") ||
            chatText.Contains("/xtremewave") ||
            chatText.Contains("/Xtremewave") ||
            chatText.Contains("/xtremeWave") ||
            chatText.Contains("/xw"))
        {
            chatText = $@"<align=""left"">
<color=#cdfffd>【XtermeWave消息】</color>
<B>·</B>欢迎来到
  - {Helpers.GradientColorText("00FFFF", "0000FF", $"{TheOtherRolesEditedPlugin.Id}")}</size> v{TheOtherRolesEditedPlugin.Version.ToString() + (TheOtherRolesEditedPlugin.betaDays > 0 ? "-BETA" : "")}
<B>·</B>房主:
  - {host.PlayerName}
<B>·</B>房间号:
  - {InnerNet.GameCode.IntToGameName(AmongUsClient.Instance.GameId)} 

";
        }
        // __instance.SetLeft();
    }
}
[HarmonyPatch]
public static class XtremeLocalHandling
{

    public static void GetChatBubbleText(byte playerId, ref string name, ref Color32 bgcolor,
        ref Color namecolor)
    {
       
    }
}
public static class StringHelper
{
    public static readonly Encoding shiftJIS = CodePagesEncodingProvider.Instance.GetEncoding("Shift_JIS");

    /// <summary>给字符串添加荧光笔样式的装饰</summary>
    /// <param name="self">字符串</param>
    /// <param name="color">原始颜色，将自动转换为半透明的荧光色</param>
    /// <param name="bright">是否设置为最大亮度。如果想要保持较暗的颜色不变，则设置为false</param>
    /// <returns>标记后的字符串</returns>
    public static string Mark(this string self, Color color, bool bright = true)
    {
        var markingColor = color.ToMarkingColor(bright);
        var markingColorCode = ColorUtility.ToHtmlStringRGBA(markingColor);
        return $"<mark=#{markingColorCode}>{self}</mark>";
    }
    /// <summary>
    /// 计算使用SJIS编码时的字节数
    /// </summary>
    public static int GetByteCount(this string self) => shiftJIS.GetByteCount(self);

    public static string RemoveHtmlTags(this string str) => Regex.Replace(str, "<[^>]*?>", string.Empty);
    public static string RemoveHtmlTagsExcept(this string str, string exceptionLabel) => Regex.Replace(str, "<(?!/*" + exceptionLabel + ")[^>]*?>", string.Empty);
    public static string RemoveColorTags(this string str) => Regex.Replace(str, "</?color(=#[0-9a-fA-F]*)?>", "");
    public static string ColorString(Color32 color, string str) => $"<color=#{color.r:x2}{color.g:x2}{color.b:x2}{color.a:x2}>{str}</color>";
}



//来自YUAC的代码

