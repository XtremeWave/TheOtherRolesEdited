using HarmonyLib;
using BepInEx.Unity.IL2CPP;
using TheOtherRolesEdited.Modules;
using System.Linq;
using UnityEngine;
using TMPro;
using static UnityEngine.UI.Button;
using System.Collections.Generic;

namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(SignInStatusComponent), nameof(SignInStatusComponent.SetOnline))]
public static class SignInStatusComponentSetOnlinePatch
{
    private static readonly string[] cheatModKeywords = { "MalumMenu", "TONE", "The Other Roles GM IA", "TONX", "UnityExplorer" };
    private static bool cheatWarningShown = false;
    private static bool pluginWarningShown = false;

    private static void Postfix()
    {
        var allPlugins = IL2CPPChainloader.Instance.Plugins.Values;
        int pluginCount = allPlugins.Count;
        TheOtherRolesEditedPlugin.Logger.LogInfo($"{pluginCount} Plugins detected");

        List<string> cheatModNames = new List<string>();
        foreach (var plugin in allPlugins)
        {
            string modName = plugin.Metadata.Name;
            foreach (string keyword in cheatModKeywords)
            {
                if (modName.Contains(keyword, System.StringComparison.OrdinalIgnoreCase))
                {
                    cheatModNames.Add(modName);
                    break;
                }
            }
        }

        if (cheatModNames.Count > 0)
        {
            if (cheatWarningShown) return;

            cheatWarningShown = true;
            string modJoinText = string.Join("\n", cheatModNames);
            DisconnectPopup.Instance.gameObject.SetActive(true);
            DisconnectPopup.Instance._textArea.enableWordWrapping = false;
            DisconnectPopup.Instance._textArea.text = string.Format(ModTranslation.getString("DetectCheatMod"), modJoinText);
            DisconnectPopup.Instance.transform.GetChild(1).gameObject.SetActive(false);
            Transform QuitButton = DisconnectPopup.Instance.transform.GetChild(4);
            QuitButton.transform.GetChild(0).GetComponent<TextMeshPro>().text = ModTranslation.getString("Quit");
            Object.Destroy(QuitButton.transform.GetChild(0).GetComponent<TextTranslatorTMP>());
            DisconnectPopup.Instance.transform.GetChild(2).gameObject.SetActive(false);
            QuitButton.GetComponent<PassiveButton>().OnClick.RemoveAllListeners();
            QuitButton.GetComponent<PassiveButton>().OnClick = new ButtonClickedEvent();
            QuitButton.GetComponent<PassiveButton>().OnClick.AddListener((System.Action)(() =>
            {
                Application.Quit();
            }));
            return;
        }

        if (pluginCount > 3)
        {
            if (pluginWarningShown) return;
            pluginWarningShown = true;

            DisconnectPopup.Instance.gameObject.SetActive(true);
            DisconnectPopup.Instance._textArea.enableWordWrapping = false;
            DisconnectPopup.Instance._textArea.text = ModTranslation.getString("PluginWarning");
        }
    }
}
//part of code copy from AmongUsRevamped 