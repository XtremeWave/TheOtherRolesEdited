using HarmonyLib;
using UnityEngine;
using TMPro;
using System;
using AmongUs.Data;
using AmongUs.GameOptions;
using InnerNet;
using Object = UnityEngine.Object;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Rewired.Platforms.Custom.CustomPlatformUnifiedKeyboardSource.KeyPropertyMap;

namespace TheOtherRolesEdited.Modules;

[HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Update))]
public static class InGameInfoPanel
{
    private static bool isAspectSizeVisible = true;
    private static GameObject aspectSizeCache;
    private static PassiveButton startButtonCache;
    private static TextMeshPro startButtonTextCache;
    private static bool isEventBound = false;
    private static bool isButtonInstantiated = false;
    private static GameObject shareRoomBtnCache;
    private static GameObject shareRoomTips;
    private static float tipHideTime = -1f;
    private static GameObject warningTips;
    private const float SendCooldown = 120f;
    private static float lastSendTime = -999f;

    private static bool isRequesting = false;

    private static readonly Queue<Action> uiActionQueue = new Queue<Action>();
    private static readonly object queueLock = new object();

    private static GameObject englishTipCache;

    private static void HideTip()
    {
        if (shareRoomTips != null)
            shareRoomTips.SetActive(false);
        if (warningTips != null)
            warningTips.SetActive(false);
        if (englishTipCache != null)
            englishTipCache.SetActive(false);
        tipHideTime = -1f;
    }

    public static class GetPlayer
    {
        public static bool IsOnlineGame =>
            AmongUsClient.Instance != null &&
            AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Started;

        public static int GetImpNums
        {
            get
            {
                int count = 0;
                foreach (var player in GameData.Instance.AllPlayers)
                {
                    if (player != null && player.Role != null && player.Role.IsImpostor)
                        count++;
                }
                return count;
            }
        }
    }

    public static void Info(string message, string tag = "")
    {
        TheOtherRolesEditedPlugin.Logger.LogInfo($"[{tag}] {message}");
    }

    public static void Postfix(GameStartManager __instance)
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ToggleAspectSizeVisibility();
        }

        if (tipHideTime > 0 && Time.time >= tipHideTime)
        {
            HideTip();
        }

        lock (queueLock)
        {
            while (uiActionQueue.Count > 0)
            {
                try
                {
                    uiActionQueue.Dequeue()?.Invoke();
                }
                catch (Exception ex)
                {
                    Info($"UI Queue execution error: {ex}", "InGameInfoPanel");
                }
            }
        }

        if (shareRoomBtnCache != null && shareRoomTips != null && warningTips != null)
            return;

        GameObject aspectSizeObj = GameObject.Find("AspectSize");
        if (aspectSizeObj == null) return;

        Transform codeSection = aspectSizeObj.transform.Find("GameCodeSection");
        if (codeSection == null) return;

        Transform sendtips = codeSection.Find("CopiedGameCode");
        sendtips.transform.GetChild(1).GetComponent<TextMeshPro>().text = ModTranslation.getString("CopyTips");
        Object.Destroy(sendtips.transform.GetChild(1).GetComponent<TextTranslatorTMP>());
        
        Transform copyCodeBtnTrans = codeSection.Find("CopyGameCodeButton");
        if (copyCodeBtnTrans == null) return;
        GameObject buttonTemplate = copyCodeBtnTrans.gameObject;
        GameObject shareRoomBtn = Object.Instantiate(buttonTemplate);
        shareRoomBtn.transform.SetParent(codeSection, false);
        shareRoomBtn.transform.localPosition += new Vector3(-0.65f, 0, 0);
        shareRoomBtn.name = "ShareRoomButton";

        SpriteRenderer spr = shareRoomBtn.transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (spr != null)
            spr.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.UI.AddPeople.png", 115f);


        PassiveButton btn = shareRoomBtn.GetComponent<PassiveButton>();
        btn.OnClick = new Button.ButtonClickedEvent();

        if (ModTranslation.IsChinese())
        {
            btn.OnClick.AddListener((Action)(() => HandleShareButtonClick()));
        }
        else if (ModTranslation.IsEnglish())
        {
            btn.OnClick.AddListener((Action)(() => ShowEnglishTip()));
        }

        shareRoomBtnCache = shareRoomBtn;

        if (sendtips != null)
        {
            GameObject template = sendtips.gameObject;

            GameObject Sendtips = Object.Instantiate(template);
            Sendtips.transform.SetParent(codeSection, false);
            Sendtips.transform.localPosition += new Vector3(0, -1.3f, 0);
            Sendtips.name = "SendTips";
            Sendtips.SetActive(false);
            TextTranslatorTMP trans1 = Sendtips.transform.GetChild(1).GetComponent<TextTranslatorTMP>();
            if (trans1 != null) Object.Destroy(trans1);
            Sendtips.transform.GetChild(1).GetComponent<TextMeshPro>().text = ModTranslation.getString("SendingTips");
            Sendtips.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.blue;
            shareRoomTips = Sendtips;

            GameObject WarningTips = Object.Instantiate(template);
            WarningTips.transform.SetParent(codeSection, false);
            WarningTips.transform.localPosition += new Vector3(0, -1.3f, 0);
            WarningTips.name = "WarningTips";
            WarningTips.SetActive(false);
            TextTranslatorTMP trans2 = WarningTips.transform.GetChild(1).GetComponent<TextTranslatorTMP>();
            if (trans2 != null) Object.Destroy(trans2);
            WarningTips.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.yellow;
            warningTips = WarningTips;

            if (ModTranslation.IsEnglish())
            {
                GameObject EnglishTip = Object.Instantiate(template);
                EnglishTip.transform.SetParent(codeSection, false);
                EnglishTip.transform.localPosition += new Vector3(0, -1.3f, 0);
                EnglishTip.name = "EnglishTip";
                EnglishTip.SetActive(false);
                TextTranslatorTMP trans3 = EnglishTip.transform.GetChild(1).GetComponent<TextTranslatorTMP>();
                if (trans3 != null) Object.Destroy(trans3);
                EnglishTip.transform.GetChild(1).GetComponent<TextMeshPro>().text = "Room sharing under development";
                EnglishTip.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.grey;
                englishTipCache = EnglishTip;
            }
        }

        InitCaches(__instance);
        if (aspectSizeCache == null || startButtonCache == null || startButtonTextCache == null) return;
        if (!isEventBound)
        {
            startButtonCache.OnClick.AddListener((Action)(() => ToggleAspectSizeVisibility()));
            isEventBound = true;
        }
    }

    private static void ShowEnglishTip()
    {
        if (englishTipCache != null)
        {
            englishTipCache.SetActive(true);
            if (shareRoomTips != null) shareRoomTips.SetActive(false);
            if (warningTips != null) warningTips.SetActive(false);
            tipHideTime = Time.time + 2f;
        }
    }

    private static void HandleShareButtonClick()
    {
        if (!ModTranslation.IsChinese())
        {
            ShowEnglishTip();
            return;
        }

        if (shareRoomTips == null || warningTips == null) return;
        if (isRequesting) return;

        float now = Time.time;
        float passTime = now - lastSendTime;

        if (passTime < SendCooldown)
        {
            ShowWarning($"WarningTips", Mathf.CeilToInt((SendCooldown - passTime) / 60f));
            return;
        }

        EnqueueUIUpdate(() => {
            shareRoomTips.SetActive(true);
            warningTips.SetActive(false);
        });

        isRequesting = true;

        Task.Run(() => ShareRoomAsync(now));
    }

    private static async Task ShareRoomAsync(float clickTime)
    {
        try
        {
            var maxPlayers = TheOtherRolesEditedPlugin.NormalOptions.TryGetInt(Int32OptionNames.MaxPlayers, out var a) ? a : 0;
            var roomCode = GameStartManager.Instance.GameRoomNameCode.text;
            var playerCount = GameData.Instance.PlayerCount;
            var regionName = ServerManager.Instance.CurrentRegion.Name;
            var playerName = DataManager.player.customization.name;
            var hostName = GameData.Instance.GetHost()?.PlayerName ?? "Unknown";

            int result = await Task.Run(() => QQHelper.AddRoom(
                roomCode, playerCount, maxPlayers, regionName,
                playerName, hostName, GetPlayer.GetImpNums, "TORE", TheOtherRolesEditedPlugin.VersionString, Application.version
            ));

            Info($"Res:{result}\nResq:{roomCode},{playerCount},{maxPlayers},{regionName},{playerName},{hostName},{GetPlayer.GetImpNums},TORE,{TheOtherRolesEditedPlugin.VersionString}, {Application.version}",
                "InGameInfoPanel");

            EnqueueUIUpdate(() => HandleShareResult(result, clickTime));
        }
        catch (Exception ex)
        {
            Info($"ShareRoomAsync error: {ex}", "InGameInfoPanel");
            EnqueueUIUpdate(() => ShowError("NetworkError"));
        }
        finally
        {
            isRequesting = false;
        }
    }

    private static void HandleShareResult(int result, float clickTime)
    {
        float now = Time.time;

        switch (result)
        {
            case 200:
                var lobbyInfoPane = LobbyInfoPane.Instance;
                if (lobbyInfoPane != null && lobbyInfoPane.CopyCodeSound != null)
                {
                    SoundManager.Instance.PlaySoundImmediate(lobbyInfoPane.CopyCodeSound, false, 1f, 1f, null);
                }
                lastSendTime = now;
                shareRoomTips.SetActive(true);
                warningTips.SetActive(false);
                tipHideTime = now + 2f;
                break;

            case 429:
                ShowWarning("WarningTips", 0);
                break;

            case 201:
                ShowRoomFilled("RoomFilled");
                break;

            default:
                ShowError(string.Format(ModTranslation.getString("NotCorrect"), result));
                break;
        }
    }

    private static void ShowWarning(string key, int minutes)
    {
        TextMeshPro warnText = warningTips.transform.GetChild(1).GetComponent<TextMeshPro>();
        if (warnText != null)
        {
            if (key == "WarningTips")
                warnText.text = string.Format(ModTranslation.getString(key), minutes);
            else
                warnText.text = ModTranslation.getString(key);
        }

        warningTips.SetActive(true);
        shareRoomTips.SetActive(false);
        if (englishTipCache != null) englishTipCache.SetActive(false);
        tipHideTime = Time.time + 2f;
    }

    private static void ShowRoomFilled(string key)
    {
        TextMeshPro warnText = warningTips.transform.GetChild(1).GetComponent<TextMeshPro>();
        if (warnText != null)
            warnText.text = ModTranslation.getString(key);

        warningTips.SetActive(true);
        shareRoomTips.SetActive(false);
        if (englishTipCache != null) englishTipCache.SetActive(false);
        tipHideTime = Time.time + 2f;
    }

    private static void ShowError(string errorKey)
    {
        TextMeshPro warnText = warningTips.transform.GetChild(1).GetComponent<TextMeshPro>();
        if (warnText != null)
        {
            string errorMsg = ModTranslation.getString(errorKey);
            if (string.IsNullOrEmpty(errorMsg))
                errorMsg = $"Error: {errorKey}";
            warnText.text = errorMsg;
        }

        warningTips.SetActive(true);
        shareRoomTips.SetActive(false);
        if (englishTipCache != null) englishTipCache.SetActive(false);
        tipHideTime = Time.time + 2f;
    }

    private static void EnqueueUIUpdate(Action action)
    {
        lock (queueLock)
        {
            uiActionQueue.Enqueue(action);
        }
    }

    private static void InitCaches(GameStartManager __instance)
    {
        if (aspectSizeCache == null)
        {
            aspectSizeCache = GameObject.Find("AspectSize");

            if (aspectSizeCache != null)
            {
                isAspectSizeVisible = aspectSizeCache.activeSelf;
            }
        }

        if ((!isButtonInstantiated || startButtonCache == null || !startButtonCache.gameObject.activeInHierarchy)
            && __instance.StartButton != null)
        {
            if (startButtonCache != null)
            {
                Object.Destroy(startButtonCache.gameObject);
            }

            GameObject newButtonObj = Object.Instantiate(__instance.StartButton.gameObject, __instance.StartButton.transform.parent);
            newButtonObj.name = "ShowHideButton";
            newButtonObj.SetActive(true);
            startButtonCache = newButtonObj.GetComponent<PassiveButton>();
            startButtonCache.transform.Find("Inactive")?.gameObject.SetActive(true);
            startButtonCache.enabled = true;
            startButtonCache.gameObject.SetActive(true);
            startButtonCache.transform.GetChild(5).gameObject.SetActive(false);
            startButtonCache.OnClick = new Button.ButtonClickedEvent();
            startButtonTextCache = newButtonObj.GetComponentInChildren<TextMeshPro>();
            startButtonCache.transform.localPosition = new Vector3(1.1073f, -0.26f, 0f);
            startButtonCache.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            startButtonCache.OnClick.AddListener((Action)(() => ToggleAspectSizeVisibility()));
            isEventBound = true;
            UpdateStartButtonText();
            isButtonInstantiated = true;
        }
    }

    private static void ToggleAspectSizeVisibility()
    {
        isAspectSizeVisible = !isAspectSizeVisible;
        if (aspectSizeCache != null)
        {
            aspectSizeCache.SetActive(isAspectSizeVisible);
        }
        UpdateStartButtonText();
    }

    private static void UpdateStartButtonText()
    {
        if (startButtonTextCache != null)
        {
            startButtonTextCache.text = isAspectSizeVisible ? ModTranslation.getString("Hide") : ModTranslation.getString("Show");
        }
    }
}