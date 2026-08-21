using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Reflection;
using TMPro;
using Object = UnityEngine.Object;
using System.Linq;
using System;
using System.Text;
using static UnityEngine.UI.Button;
using UnityEngine.Networking;
using TheOtherRolesEdited.Modules;

namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start)), HarmonyPriority(Priority.First)]
internal class BugButtonPatch
{
    private static int _bugButtonClickCount = 0;

    private static void Postfix(MainMenuManager __instance)
    {
        var UI = GameObject.Find("MainUI");
        var asp = UI.transform.GetChild(1);
        var EcButton = asp.GetChild(4).GetChild(0).GetChild(1);
        asp.GetChild(4).gameObject.SetActive(true);
        //EcButton.gameObject.transform.localPosition = new Vector3(0.18f, -1.1f, 0f);
        //EcButton.gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
        Object.Destroy(EcButton.gameObject);
        var DoNotPress = asp.GetChild(7);
        DoNotPress.gameObject.SetActive(true);
        DoNotPress.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.BugButton_activeSprites.png", 150f);
        DoNotPress.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.BugButton_inactiveSprites.png", 150f);
        DoNotPress.transform.GetChild(0).transform.localPosition += new Vector3(-0.01f, 0.35f, 0);
        DoNotPress.transform.GetChild(1).transform.localPosition += new Vector3(-0.01f, 0.35f, 0);
        SpriteRenderer pedestalSprite = DoNotPress.GetComponent<SpriteRenderer>();
        SpriteRenderer pressedSprite = DoNotPress.GetChild(0).GetComponent<SpriteRenderer>();
        SpriteRenderer unpressedSprite = DoNotPress.GetChild(1).GetComponent<SpriteRenderer>();
        PassiveButton bugButton = DoNotPress.GetComponent<PassiveButton>();
        pedestalSprite.gameObject.SetActive(true);
        pressedSprite.gameObject.SetActive(true);
        unpressedSprite.gameObject.SetActive(true);
        unpressedSprite.enabled = true;
        pressedSprite.enabled = false;

        bugButton.OnClick.RemoveAllListeners();
        bugButton.OnMouseOver.RemoveAllListeners();
        bugButton.OnMouseOut.RemoveAllListeners();

        bugButton.OnMouseOver.AddListener((Action)(() =>
        {
            pressedSprite.enabled = true;
            unpressedSprite.enabled = false;
        }));

        bugButton.OnMouseOut.AddListener((Action)(() =>
        {
            pressedSprite.enabled = false;
            unpressedSprite.enabled = true;
        }));

        bugButton.OnClick.AddListener(new Action(() =>
        {
            _bugButtonClickCount++;

            var oldBugScreen = AccountManager.Instance.transform.Find("BUGSCREEN");
            if (oldBugScreen != null) Object.Destroy(oldBugScreen.gameObject);
            var oldScreen = AccountManager.Instance.transform.Find("SCREEN");
            if (oldScreen != null) Object.Destroy(oldScreen.gameObject);

            var template = AccountManager.Instance.transform.Find("PremissionRequestWindow");
            if (template == null) return;

            if (_bugButtonClickCount == 1)
            {
                GameObject sliderTemplate = Object.Instantiate(template.gameObject, AccountManager.Instance.transform);
                sliderTemplate.name = "BUGSCREEN";
                sliderTemplate.SetActive(true);

                sliderTemplate.transform.Find("TitleText_TMP").GetComponent<TextMeshPro>().text = ModTranslation.getString("BugSubmission");
                Object.Destroy(sliderTemplate.transform.Find("TitleText_TMP").GetComponent<TextTranslatorTMP>());

                sliderTemplate.transform.Find("InfoText_TMP").GetComponent<TextMeshPro>().text = ModTranslation.getString("Tips1");
                Object.Destroy(sliderTemplate.transform.Find("InfoText_TMP").GetComponent<TextTranslatorTMP>());

                sliderTemplate.transform.Find("GuardianEmailTitle_TMP").GetComponent<TextMeshPro>().text = ModTranslation.getString("Tips2");
                Object.Destroy(sliderTemplate.transform.Find("GuardianEmailTitle_TMP").GetComponent<TextTranslatorTMP>());
                sliderTemplate.transform.Find("GuardianEmailTitle_TMP").localPosition = new Vector3(-2.3f, 1.3f, 0f);

                sliderTemplate.transform.Find("GuardianEmailConfirm").localPosition = new Vector3(0f, 0.77f, 0f);
                Object.Destroy(sliderTemplate.transform.Find("GuardianEmailConfirm").GetComponent<EmailTextBehaviour>());
                sliderTemplate.transform.Find("GuardianEmailConfirm").GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(6.8f, 0.65f);
                sliderTemplate.transform.Find("GuardianEmailConfirm").GetComponent<BoxCollider2D>().size = new Vector2(6.8f, 0.65f);
                sliderTemplate.transform.Find("GuardianEmailConfirm").GetChild(1).localPosition = new Vector3(-3.2f, 0f, 0f);

                sliderTemplate.transform.Find("GuardianEmailConfirmTitle_TMP").GetComponent<TextMeshPro>().text = ModTranslation.getString("Tips3");
                Object.Destroy(sliderTemplate.transform.Find("GuardianEmailConfirmTitle_TMP").GetComponent<TextTranslatorTMP>());
                sliderTemplate.transform.Find("GuardianEmailConfirmTitle_TMP").localPosition = new Vector3(-2.3f, 0.3f, 0f);

                var emailInput = sliderTemplate.transform.Find("GuardianEmail");
                emailInput.GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(6.8f, 1.8f);
                emailInput.GetComponent<BoxCollider2D>().size = new Vector2(6.8f, 1.8f);
                Object.Destroy(emailInput.GetComponent<EmailTextBehaviour>());
                emailInput.localPosition = new Vector3(0f, -0.85f, 0f);
                var inputText = emailInput.GetChild(1).GetComponent<TextMeshPro>();
                inputText.transform.localPosition = new Vector3(-0.36f, 0.62f, 0f);
                inputText.enableWordWrapping = true;
                inputText.rectTransform.sizeDelta = new Vector2(6.4f, 0);
                var textBox = emailInput.GetComponent<TextBoxTMP>();
                if (textBox != null)
                {
                    textBox.characterLimit = -1;

                    textBox.OnChange = new ButtonClickedEvent();
                    textBox.OnChange.AddListener((Action)(() =>
                    {
                        inputText.transform.localPosition = new Vector3(-0.36f, 1.8f / 2 - 0.2f * inputText.textInfo.lineCount, 0f);
                    }));
                }

                sliderTemplate.transform.GetChild(9).gameObject.SetActive(false);

                var submitBtn = sliderTemplate.transform.Find("SubmitButton").GetComponent<PassiveButton>();
                submitBtn.OnClick = new ButtonClickedEvent();
                submitBtn.OnClick.AddListener((System.Action)(() =>
                {
                    var bugText = emailInput.GetChild(1).GetComponent<TextMeshPro>();
                    var timeText = sliderTemplate.transform.Find("GuardianEmailConfirm").GetChild(1).GetComponent<TextMeshPro>();

                    var bugBg = emailInput.GetChild(0).GetComponent<SpriteRenderer>();
                    var timeBg = sliderTemplate.transform.Find("GuardianEmailConfirm").GetChild(0).GetComponent<SpriteRenderer>();

                    bool timeEmpty = string.IsNullOrWhiteSpace(timeText.text);
                    bool bugEmpty = string.IsNullOrWhiteSpace(bugText.text);

                    if (timeEmpty || bugEmpty)
                    {
                        if (timeEmpty) timeBg.color = Color.red;
                        if (bugEmpty) bugBg.color = Color.red;
                        return;
                    }


                    // 获取用户信息
                    string token = EOSManager.Instance.UserIDToken;
                    string puid = EOSManager.Instance.ProductUserId;

                    // 读取LogOutput.log文件
                    string logContent = "";
                    string logPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "LogOutput.log");
                    try
                    {
                        if (File.Exists(logPath))
                        {
                            // 使用File.ReadAllText的重载，指定编码为UTF-8，避免文件被占用的问题
                            using (var stream = new FileStream(logPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            using (var reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                logContent = reader.ReadToEnd();
                            }
                        }
                    }
                    catch { }

                    // 构建反馈数据
                    var formData = new Dictionary<string, string>();
                    formData.Add("token", token);
                    formData.Add("puid", puid);
                    formData.Add("time", timeText.text);
                    formData.Add("bug", bugText.text);
                    formData.Add("log", logContent);

                    // 构建 POST 数据
                    string postData = string.Join("&", formData.Select(kvp => $"{UnityWebRequest.EscapeURL(kvp.Key)}={UnityWebRequest.EscapeURL(kvp.Value)}"));

                    // 发送反馈数据到PHP接收端
                    var request = new UnityWebRequest("https://tore.amongusclub.cn/BugReport/receive_feedback.php", "POST");
                    byte[] bodyRaw = Encoding.UTF8.GetBytes(postData);
                    request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                    request.downloadHandler = new DownloadHandlerBuffer();
                    request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                    request.SendWebRequest();

                    // 等待请求完成
                    while (!request.isDone)
                    {
                        // 等待请求完成
                    }

                    if (request.result == UnityWebRequest.Result.Success)
                    {
                        TheOtherRolesEditedPlugin.Logger.LogInfo("反馈发送成功！");
                    }
                    else
                    {
                        TheOtherRolesEditedPlugin.Logger.LogError("反馈发送失败：" + request.error);
                    }
                    request.Dispose();

                    Object.Destroy(sliderTemplate.gameObject);
                    ShowSuccessUI(template);
                }));


                var CloseButton = Object.Instantiate(submitBtn, submitBtn.transform.parent);
                CloseButton.gameObject.name = "CloseButton";
                CloseButton.transform.Find("Text_TMP").GetComponent<TextMeshPro>().text = "";
                Object.Destroy(CloseButton.transform.Find("Text_TMP").GetComponent<TextTranslatorTMP>());
                CloseButton.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.UI.Close.png", 100f);
                CloseButton.transform.localPosition = new Vector3(-3.7f, 2.4f, 0);
                CloseButton.transform.localScale = new Vector3(0.3f, 1.3f, 0);
                CloseButton.OnClick = new ButtonClickedEvent();
                CloseButton.OnClick.AddListener((System.Action)(() =>
                {
                    Object.Destroy(sliderTemplate.gameObject);
                    _bugButtonClickCount = 0;
                }));
            }
            else
            {
                ShowSuccessUI(template);
            }
        }));
    }
    private static void ShowSuccessUI(Transform template)
    {
        GameObject Template = Object.Instantiate(template.gameObject, AccountManager.Instance.transform);
        Template.name = "SCREEN";
        Template.SetActive(true);

        Template.transform.Find("TitleText_TMP").GetComponent<TextMeshPro>().text = ModTranslation.getString("Tips4");
        Template.transform.Find("InfoText_TMP").GetComponent<TextMeshPro>().text = ModTranslation.getString("Tips5");
        Template.transform.Find("InfoText_TMP").localPosition = new Vector3(0f, -1.1f, 0f);
        Template.transform.Find("InfoText_TMP").localScale = new Vector3(2.5f, 2.5f, 1f);
        Object.Destroy(Template.transform.Find("InfoText_TMP").GetComponent<TextTranslatorTMP>());
        Object.Destroy(Template.transform.Find("TitleText_TMP").GetComponent<TextTranslatorTMP>());

        for (int i = 4; i <= 7; i++)
        Template.transform.GetChild(i).gameObject.SetActive(false);
        Template.transform.GetChild(9).gameObject.SetActive(false);

        var SubmitButton = Template.transform.Find("SubmitButton").GetComponent<PassiveButton>();
        SubmitButton.transform.Find("Text_TMP").GetComponent<TextMeshPro>().text = ModTranslation.getString("Close");
        Object.Destroy(SubmitButton.transform.Find("Text_TMP").GetComponent<TextTranslatorTMP>());
        SubmitButton.OnClick = new ButtonClickedEvent();
        SubmitButton.OnClick.AddListener((System.Action)(() =>
        {
            Object.Destroy(Template.gameObject);
        }));
    }

}
