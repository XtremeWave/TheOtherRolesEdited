using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using TheOtherRolesEdited.Modules;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(MainMenuManager))]
public static class MainMenuManagerPatch
{
    public static bool ShowedBak = false;
    private static bool ShowingPanel = false;
    public static MainMenuManager Instance { get; private set; }
    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.OpenGameModeMenu))]
    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.OpenAccountMenu))]
    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.OpenCredits))]
    [HarmonyPrefix, HarmonyPriority(Priority.Last)]
    public static void ShowRightPanel() => ShowingPanel = true;

    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    [HarmonyPatch(typeof(OptionsMenuBehaviour), nameof(OptionsMenuBehaviour.Open))]
    [HarmonyPatch(typeof(AnnouncementPopUp), nameof(AnnouncementPopUp.Show))]
    [HarmonyPrefix, HarmonyPriority(Priority.Last)]
    public static void HideRightPanel()
    {
        ShowingPanel = false;
        AccountManager.Instance?.transform?.FindChild("AccountTab/AccountWindow")?.gameObject?.SetActive(false);
    }

    public static void ShowRightPanelImmediately()
    {
        ShowingPanel = true;
        TitleLogoPatch.RightPanel.transform.localPosition = TitleLogoPatch.RightPanelOp;
        Instance.OpenGameModeMenu();
    }

    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.LateUpdate)), HarmonyPostfix]
    public static void MainMenuManager_LateUpdate()
    {
        if (GameObject.Find("MainUI") == null) ShowingPanel = false;

        if (TitleLogoPatch.RightPanel != null)
        {
            var pos1 = TitleLogoPatch.RightPanel.transform.localPosition;
            Vector3 lerp1 = Vector3.Lerp(pos1, TitleLogoPatch.RightPanelOp + new Vector3((ShowingPanel ? 0f : 10f), 0f, 0f), Time.deltaTime * (ShowingPanel ? 3f : 2f));
            if (ShowingPanel
                ? TitleLogoPatch.RightPanel.transform.localPosition.x > TitleLogoPatch.RightPanelOp.x + 0.03f
                : TitleLogoPatch.RightPanel.transform.localPosition.x < TitleLogoPatch.RightPanelOp.x + 9f
                ) TitleLogoPatch.RightPanel.transform.localPosition = lerp1;
        }

        if (ShowedBak) return;
        var bak = GameObject.Find("BackgroundTexture");
        if (bak == null || !bak.active) return;
        var pos2 = bak.transform.position;
        Vector3 lerp2 = Vector3.Lerp(pos2, new Vector3(pos2.x, 7.1f, pos2.z), Time.deltaTime * 1.4f);
        bak.transform.position = lerp2;
        if (pos2.y > 7f) ShowedBak = true;
    }
    //∑¿÷π ˜¿¡§Œsbº‡ª§»ÀºÏ≤‚
    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.LateUpdate))]
    public static void Prefix(MainMenuManager __instance)
    {
        GameObject.Find("AccountManager/UpdateGuardianEmail")?.SetActive(false);
    }
}
//github:https://github.com/fangkuaiclub/AdultPermissionsAmongUs/releases/tag/v1.0.0