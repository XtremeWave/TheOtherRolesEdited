using AmongUs.QuickChat;
using CsvHelper;
using HarmonyLib;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using TheOtherRolesEdited.Modules;
namespace TheOtherRolesEdited.Patches;

[HarmonyPatch(typeof(ChatBubble))]
public static class ChatBubblePatch
{
    private static readonly string[] SensitiveContents;

    static ChatBubblePatch()
    {
        string Banwords = "TheOtherRolesEdited.Resources.BanWords.BanWords.txt";

        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(Banwords);
        using var reader = new StreamReader(stream);

        SensitiveContents = reader.ReadToEnd()
            .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Trim())
            .ToArray();
    }

    [HarmonyPatch(nameof(ChatBubble.SetText)), HarmonyPrefix]
    public static void SetTextPrefix(ChatBubble __instance, ref string chatText)
    {
        string chatTextWithoutSpaces = chatText.Replace(" ", "");

        foreach (var sensitiveWord in SensitiveContents)
        {
            string sensitiveWordWithoutSpaces = sensitiveWord.Replace(" ", "");

            if (string.IsNullOrEmpty(sensitiveWordWithoutSpaces))
                continue;

            if (chatTextWithoutSpaces.Contains(sensitiveWordWithoutSpaces))
            {
                chatText = ReplaceIgnoringSpaces(chatText, sensitiveWord, "**");
            }
        }

    }

    private static string ReplaceIgnoringSpaces(string originalText, string sensitiveWord, string replacement)
    {
        string sensitivePattern = sensitiveWord.Replace(" ", "");
        if (string.IsNullOrEmpty(sensitivePattern))
            return originalText;

        string textWithoutSpaces = originalText.Replace(" ", "");
        int index = textWithoutSpaces.IndexOf(sensitivePattern, StringComparison.Ordinal);

        while (index != -1)
        {
            int startPos = GetOriginalPosition(originalText, 0, index);
            int endPos = GetOriginalPosition(originalText, startPos, sensitivePattern.Length);

            originalText = originalText.Remove(startPos, endPos - startPos).Insert(startPos, replacement);

            textWithoutSpaces = originalText.Replace(" ", "");
            index = textWithoutSpaces.IndexOf(sensitivePattern, StringComparison.Ordinal);
        }

        return originalText;
    }

    private static int GetOriginalPosition(string originalText, int startSearch, int targetLength)
    {
        int currentLength = 0;
        for (int i = startSearch; i < originalText.Length; i++)
        {
            if (originalText[i] != ' ')
            {
                currentLength++;
                if (currentLength > targetLength)
                    return i;
            }
        }
        return originalText.Length;
    }

    private static bool IsModdedMsg(string name) => name.EndsWith('\0');
}