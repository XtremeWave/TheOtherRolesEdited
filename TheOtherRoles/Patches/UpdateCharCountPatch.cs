using HarmonyLib;
using TheOtherRolesEdited.Modules;
using UnityEngine;

namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(FreeChatInputField), nameof(FreeChatInputField.UpdateCharCount))]
internal class UpdateCharCountPatch
{
    public static void Postfix(FreeChatInputField __instance)
    {
        int len = __instance.textArea.text.Length;
        __instance.charCountText.SetText(len <= 0 ? $"{ModTranslation.getString("ThankYouForPlayingTORE")}" : $"{len}/{__instance.textArea.characterLimit}");
        __instance.charCountText.enableWordWrapping = false;
        int max = AmongUsClient.Instance.AmHost ? 1111 : 777;
        int warn = AmongUsClient.Instance.AmHost ? 888 : 444;
        __instance.charCountText.color = len >= max ? Color.red : len >= warn ? Color.yellow : Color.black;
    }
}
