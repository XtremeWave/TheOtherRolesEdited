using HarmonyLib;
using System;
using System.Collections.Generic;
using TheOtherRolesEdited.Modules;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace TheOtherRolesEdited.Patches;

public static class RoleIntroduction
{
    internal static TMP_FontAsset fontAsset;
    internal static TMP_FontAsset fontAssetVersionShower;
    public static GameObject RolesSummaryUI { get; set; }
    public static GameObject RoleInfosOnclick { get; set; }
    private static TextMeshPro infoButtonText;
    private static TextMeshPro infoTitleText;
    public static GameObject CloseButton;
    public static GameObject BackButton;
    private static RoleType lastSelectTeam;

    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]

    public static void RoleSummaryOnClick()
    {
        if (RolesSummaryUI != null) return;

        SpriteRenderer container = new GameObject("RoleSummaryMenuContainer").AddComponent<SpriteRenderer>();
        container.sprite =  Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.LobbyRoleInfo.TeamScreen.png", 110f);
        container.transform.SetParent(HudManager.Instance.transform);
        container.gameObject.transform.SetLocalZ(-200);
        container.transform.localPosition = new Vector3(0, -0.2f, -50f);
        container.transform.localScale = new Vector3(.75f, .7f, 1f);
        container.gameObject.layer = 5;

        RolesSummaryUI = container.gameObject;

        Transform buttonTemplate = HudManager.Instance.SettingsButton.transform;
        TextMeshPro textTemplate = HudManager.Instance.TaskPanel.taskText;

        TextMeshPro newtitle = Object.Instantiate(textTemplate, container.transform);
        newtitle.text = ModTranslation.getString("RoleIntroduction");
        newtitle.color = Color.white;
        newtitle.outlineWidth = 0.05f;
        newtitle.transform.localPosition = new Vector3(2f, -0.7f, -2f);
        newtitle.transform.localScale = Vector3.one * 3f;

        CloseButton = new GameObject("CloseButton");
        CloseButton.transform.SetParent(container.transform);
        CloseButton.transform.localPosition = new Vector3(-4.5f, 3.45f, 0);
        CloseButton.transform.localScale = new(0.65f, 0.7f, 1f);
        CloseButton.AddComponent<BoxCollider2D>().size = new(0.6f, 1.5f);
        CloseButton.transform.gameObject.layer = 5;
        var closeRightSpriteRenderer = CloseButton.AddComponent<SpriteRenderer>();
        closeRightSpriteRenderer.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.LobbyRoleInfo.ExitButton.png", 100f);
        var closeRightPassiveButton = CloseButton.AddComponent<PassiveButton>();
        closeRightPassiveButton.OnClick = new();
        closeRightPassiveButton.OnClick.AddListener((Action)(() =>{ Object.Destroy(RolesSummaryUI); }));
        closeRightPassiveButton.OnMouseOut = new();
        closeRightPassiveButton.OnMouseOut.AddListener((System.Action)(() => closeRightSpriteRenderer.color = Color.white));
        closeRightPassiveButton.OnMouseOver = new();
        closeRightPassiveButton.OnMouseOver.AddListener((System.Action)(() => closeRightSpriteRenderer.color = Color.green));

        List<Transform> buttons = new();

        foreach (RoleType teamId in Enum.GetValues(typeof(RoleType)))
        {

            Transform buttonTransform = Object.Instantiate(buttonTemplate, container.transform);
            buttonTransform.name = teamId.ToString() + "Button";
            buttonTransform.GetComponent<BoxCollider2D>().size = new Vector2(2.5f, 0.55f);
            buttonTransform.transform.Find("Inactive").GetComponent<SpriteRenderer>().sprite =  Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.LobbyRoleInfo.RolePlate.png", 120f);
            buttonTransform.transform.Find("Active").GetComponent<SpriteRenderer>().sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.LobbyRoleInfo.RolePlate2.png", 120f);
            buttonTransform.transform.Find("Background").gameObject.SetActive(false);
            buttons.Add(buttonTransform);
            Object.Destroy(buttonTransform.transform.GetComponent<AspectPosition>());
            buttonTransform.transform.localPosition -= Vector3.up * 1.1f;
            buttonTransform.localPosition = new Vector3(0f, -1.3f, -5);
            buttonTransform.localPosition += Vector3.up * 0.8f * (buttons.Count - 1);
            buttonTransform.localScale = new Vector3(2f, 1.5f, 1f);

            TextMeshPro label = Object.Instantiate(textTemplate, buttonTransform);
            label.text = Helpers.cs(Helpers.getTeamColor(teamId), ModTranslation.getString(teamId.ToString() + "RolesText"));
            label.alignment = TextAlignmentOptions.Center;
            label.transform.localPosition = new Vector3(0, 0, label.transform.localPosition.z);
            label.transform.localScale = new Vector3(1.4f, 2f, 1f);
            label.font = fontAsset;
            label.fontStyle = FontStyles.Bold;
            label.outlineWidth = 0.1f;  
            label.outlineColor = Color.black; 
            PassiveButton button = buttonTransform.GetComponent<PassiveButton>();
            button.OnClick.RemoveAllListeners();
            button.OnClick = new Button.ButtonClickedEvent();
            button.OnClick.AddListener((Action)(() =>
            {
                Object.Destroy(container.gameObject);
                roleInfosOnclick(teamId);
            }));
        }
    }

    public static void roleInfosOnclick(RoleType teamId)
    {
        lastSelectTeam = teamId;

        SpriteRenderer container = new GameObject("RoleListMenuContainer").AddComponent<SpriteRenderer>();
        container.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.LobbyRoleInfo.RoleListScreen.png", 110f);
        container.transform.SetParent(HudManager.Instance.transform);
        container.transform.localPosition = new Vector3(0, -0.18f, -75f);
        container.transform.localScale = new Vector3(.7f, .7f, 1f);
        container.gameObject.layer = 5;
        RoleInfosOnclick = container.gameObject;

        Transform buttonTemplate = HudManager.Instance.SettingsButton.transform;
        TextMeshPro textTemplate = HudManager.Instance.TaskPanel.taskText;

        TextMeshPro newtitle = Object.Instantiate(textTemplate, container.transform);
        newtitle.text = Helpers.cs(Helpers.getTeamColor(teamId),ModTranslation.getString(teamId.ToString() + "RolesText"));
        newtitle.outlineWidth = 0.02f;
        newtitle.outlineColor = Color.black;
        newtitle.transform.localPosition = new Vector3(5.4f, -5.7f, -2f);
        newtitle.transform.localScale = Vector3.one * 2.5f;

        // 添加退出按钮
        CloseButton = new GameObject("CloseButton");
        CloseButton.transform.SetParent(container.transform);
        CloseButton.transform.localPosition = new Vector3(-6f, 3.15f, 0);
        CloseButton.transform.localScale = new(0.7f, 0.7f, 1f);
        CloseButton.AddComponent<BoxCollider2D>().size = new(0.6f, 1.5f);
        CloseButton.transform.gameObject.layer = 5;
        var closeRightSpriteRenderer = CloseButton.AddComponent<SpriteRenderer>();
        closeRightSpriteRenderer.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.LobbyRoleInfo.ExitButton.png", 100f);
        var closeRightPassiveButton = CloseButton.AddComponent<PassiveButton>();
        closeRightPassiveButton.OnClick = new();
        closeRightPassiveButton.OnClick.AddListener((Action)(() => { Object.Destroy(RoleInfosOnclick); }));
        closeRightPassiveButton.OnMouseOut = new();
        closeRightPassiveButton.OnMouseOut.AddListener((System.Action)(() => closeRightSpriteRenderer.color = Color.white));
        closeRightPassiveButton.OnMouseOver = new();
        closeRightPassiveButton.OnMouseOver.AddListener((System.Action)(() => closeRightSpriteRenderer.color = Color.green));

        //返回按钮
        BackButton = new GameObject("BackButton");
        BackButton.transform.SetParent(container.transform);
        BackButton.transform.localPosition = new Vector3(-6f, 2.2f, 0);
        BackButton.transform.localScale = new(0.7f, 0.7f, 1f);
        BackButton.AddComponent<BoxCollider2D>().size = new(0.6f, 1.5f);
        BackButton.transform.gameObject.layer = 5;
        var BackButtonSpriteRenderer = BackButton.AddComponent<SpriteRenderer>();
        BackButtonSpriteRenderer.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.LobbyRoleInfo.BackButton.png", 100f);
        var BackButtonPassiveButton = BackButton.AddComponent<PassiveButton>();
        BackButtonPassiveButton.OnClick = new();
        BackButtonPassiveButton.OnClick.AddListener((Action)(() =>
        {
            Object.Destroy(RoleInfosOnclick);
            RoleSummaryOnClick();
        }));
        BackButtonPassiveButton.OnMouseOut = new();
        BackButtonPassiveButton.OnMouseOut.AddListener((System.Action)(() => BackButtonSpriteRenderer.color = Color.white));
        BackButtonPassiveButton.OnMouseOver = new();
        BackButtonPassiveButton.OnMouseOver.AddListener((System.Action)(() => BackButtonSpriteRenderer.color = Color.green));

        List<Transform> buttons = new();
        int count = 0;
        bool gameStarted = AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Started;
        foreach (RoleInfo roleInfo in RoleInfo.allRoleInfos)
        {
            if (roleInfo.roleType == RoleType.Modifier && teamId != RoleType.Modifier) continue;
            else if (roleInfo.roleType == RoleType.Neutral && teamId != RoleType.Neutral) continue;
            else if (roleInfo.roleType == RoleType.Impostor && teamId != RoleType.Impostor) continue;
            else if (roleInfo.roleType == RoleType.Crewmate && teamId != RoleType.Crewmate) continue;

            Transform buttonTransform = Object.Instantiate(buttonTemplate, container.transform);
            buttonTransform.name = Helpers.cs(roleInfo.color, roleInfo.name) + " Button";
            buttonTransform.GetComponent<BoxCollider2D>().size = new Vector2(2.5f, 0.55f);
            TextMeshPro label = Object.Instantiate(textTemplate, buttonTransform);
            buttonTransform.transform.Find("Inactive").GetComponent<SpriteRenderer>().sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.LobbyRoleInfo.RoleIntroduction.png", 90f);
            buttonTransform.transform.Find("Active").GetComponent<SpriteRenderer>().sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.LobbyRoleInfo.RoleIntroduction2.png", 90f);
            buttonTransform.transform.Find("Background").gameObject.SetActive(false);
            Object.Destroy(buttonTransform.transform.GetComponent<AspectPosition>());
            buttons.Add(buttonTransform);
            int row = count / 3, col = count % 3;
            buttonTransform.localPosition = new Vector3(-3.205f + (col * 3.2f), 2.9f - (row * 0.75f), -5);
            buttonTransform.localScale = new Vector3(1.125f, 1.125f, 1f);
            label.text = Helpers.cs(roleInfo.color, roleInfo.name);
            label.alignment = TextAlignmentOptions.Center;
            label.transform.localPosition = new Vector3(0, 0, label.transform.localPosition.z);
            label.transform.localScale *= 1.5f;
            label.font = fontAssetVersionShower;
            label.fontStyle = FontStyles.Bold;
            label.outlineWidth = 0.09f;    
            label.outlineColor = Color.black; 
            PassiveButton button = buttonTransform.GetComponent<PassiveButton>();
            button.OnClick.RemoveAllListeners();
            button.OnClick = new Button.ButtonClickedEvent();
            button.OnClick.AddListener((Action)(() =>
            {
                Object.Destroy(container.gameObject);
                AddInfoCard(roleInfo);
            }));
            count++;
        }
    }

    public static void AddInfoCard(RoleInfo roleInfo)
    {
        string roleSettingDescription = roleInfo.fullDescription != "" ? roleInfo.fullDescription : roleInfo.shortDescription;
        string coloredHelp = Helpers.cs(Color.white, roleSettingDescription);

        SpriteRenderer roleCard = new GameObject("RoleCard").AddComponent<SpriteRenderer>();
        roleCard.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.LobbyRoleInfo.SummaryScreen.png", 110f);
        roleCard.transform.SetParent(HudManager.Instance.transform);
        roleCard.transform.localPosition = new Vector3(-0.1f, -0.1f, -150f);
        roleCard.transform.localScale = new Vector3(0.77f, 0.77f, 1f);
        roleCard.gameObject.layer = 5;
        RolesSummaryUI = roleCard.gameObject;

        // 添加退出按钮
        CloseButton = new GameObject("CloseButton");
        CloseButton.transform.SetParent(roleCard.transform);
        CloseButton.transform.localPosition = new Vector3(-5.3f, 3f, 0);
        CloseButton.transform.localScale = new(0.7f, 0.7f, 1f);
        CloseButton.AddComponent<BoxCollider2D>().size = new(0.6f, 1.5f);
        CloseButton.transform.gameObject.layer = 5;
        var closeRightSpriteRenderer = CloseButton.AddComponent<SpriteRenderer>();
        closeRightSpriteRenderer.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.LobbyRoleInfo.ExitButton.png", 100f);
        var closeRightPassiveButton = CloseButton.AddComponent<PassiveButton>();
        closeRightPassiveButton.OnClick = new();
        closeRightPassiveButton.OnClick.AddListener((Action)(() => { Object.Destroy(RolesSummaryUI); }));
        closeRightPassiveButton.OnMouseOut = new();
        closeRightPassiveButton.OnMouseOut.AddListener((System.Action)(() => closeRightSpriteRenderer.color = Color.white));
        closeRightPassiveButton.OnMouseOver = new();
        closeRightPassiveButton.OnMouseOver.AddListener((System.Action)(() => closeRightSpriteRenderer.color = Color.green));

        //返回按钮
        BackButton = new GameObject("BackButton");
        BackButton.transform.SetParent(roleCard.transform);
        BackButton.transform.localPosition = new Vector3(-5.3f, 2f, 0);
        BackButton.transform.localScale = new(0.7f, 0.7f, 1f);
        BackButton.AddComponent<BoxCollider2D>().size = new(0.6f, 1.5f);
        BackButton.transform.gameObject.layer = 5;
        var BackButtonSpriteRenderer = BackButton.AddComponent<SpriteRenderer>();
        BackButtonSpriteRenderer.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.LobbyRoleInfo.BackButton.png", 100f);
        var BackButtonPassiveButton = BackButton.AddComponent<PassiveButton>();
        BackButtonPassiveButton.OnClick = new();

        BackButtonPassiveButton.OnClick.AddListener((Action)(() =>
        {
            Object.Destroy(RolesSummaryUI);
            roleInfosOnclick(lastSelectTeam);
        }));

        BackButtonPassiveButton.OnMouseOut = new();
        BackButtonPassiveButton.OnMouseOut.AddListener((System.Action)(() => BackButtonSpriteRenderer.color = Color.white));
        BackButtonPassiveButton.OnMouseOver = new();
        BackButtonPassiveButton.OnMouseOver.AddListener((System.Action)(() => BackButtonSpriteRenderer.color = Color.green));

        infoButtonText = Object.Instantiate(HudManager.Instance.TaskPanel.taskText, roleCard.transform);
        infoButtonText.color = Color.white;
        infoButtonText.text = coloredHelp;
        infoButtonText.enableWordWrapping = false;
        infoButtonText.transform.localScale = Vector3.one * 1.25f;
        infoButtonText.transform.localPosition = new Vector3(-2.9f, 0f, -50f);
        infoButtonText.alignment = TextAlignmentOptions.TopLeft;
        infoButtonText.fontStyle = FontStyles.Bold;

        infoTitleText = Object.Instantiate(HudManager.Instance.TaskPanel.taskText, roleCard.transform);
        infoTitleText.color = Color.white;
        infoTitleText.text = Helpers.cs(roleInfo.color, roleInfo.name);
        infoTitleText.enableWordWrapping = false;
        infoTitleText.transform.localScale = Vector3.one * 3f;
        infoTitleText.transform.localPosition = new Vector3(0f, 2.4f, -50f);
        infoTitleText.alignment = TextAlignmentOptions.Center;
        infoTitleText.fontStyle = FontStyles.Bold;
    }
}

[HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Start))]
internal class GameStartPatch
{
    public static void Prefix(ShipStatus __instance)
    {
        if (RoleIntroduction.RolesSummaryUI != null) RoleIntroduction.RolesSummaryUI.SetActive(false);
    }
}