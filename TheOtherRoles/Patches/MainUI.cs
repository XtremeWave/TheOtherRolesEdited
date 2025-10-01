using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(MainMenuManager))]
public static class MainUIPatch
{
    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.LateUpdate)), HarmonyPostfix]
    public static void StartPostfix(MainMenuManager __instance)
    {
        //移除边框
        GameObject leftPanel = __instance.mainMenuUI.FindChild<Transform>("LeftPanel").gameObject;
        leftPanel.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        leftPanel.gameObject.FindChild<SpriteRenderer>("Divider").enabled = false;

        //移除搜索游戏按钮
        var scaler = __instance.onlineButtonsContainer.GetChild(1);
        scaler.GetChild(0).localPosition = new(-1f, 0.5f, 0f);//CreateLobby
        scaler.GetChild(1).localPosition = new(1.5f, 0.5f, 0f);//JoinGame
        scaler.GetChild(2).gameObject.SetActive(false);//FindGame
        scaler.GetChild(3).gameObject.SetActive(false);//Line

        //移除自由模式
        /* var howToPlayButton = __instance.howToPlayButton;
        var freeplayButton = howToPlayButton.transform.parent.Find("FreePlayButton");
        if (freeplayButton != null) freeplayButton.gameObject.SetActive(false);
        howToPlayButton.transform.SetLocalX(0);*/

        //移除本地
        /*var PlayOnlineButton = __instance.PlayOnlineButton;
        var PlayLocalButton = PlayOnlineButton.transform.parent.Find("PlayLocalButton");
        if (PlayLocalButton != null) PlayLocalButton.gameObject.SetActive(false);
        PlayOnlineButton.transform.SetLocalX(0);*/

        //给Button染色
        __instance.playButton.buttonText.color = Color.white;
        __instance.inventoryButton.buttonText.color = Color.white;
        __instance.shopButton.buttonText.color = Color.white;
        __instance.newsButton.buttonText.color = Color.white;
        __instance.myAccountButton.buttonText.color = Color.white;
        __instance.settingsButton.buttonText.color = Color.white;
        __instance.howToPlayButton.buttonText.color = Color.white;
        __instance.freePlayButton.buttonText.color = Color.white;

        __instance.playButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0.0235f, 0.6f, 1f);
        __instance.playButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0.0235f, 0.6f, 2f);
        Color originalColorPlayButton = __instance.playButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.playButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorPlayButton * 0.6f;
        __instance.playButton.activeSprites.GetComponent<SpriteRenderer>().color = originalColorPlayButton * 0.75f;
        __instance.playButton.activeTextColor = Color.white;
        __instance.playButton.inactiveTextColor = Color.white;
        __instance.playButton.activeSprites.transform.FindChild("Shine")?.gameObject?.SetActive(false);
        __instance.playButton.inactiveSprites.transform.FindChild("Shine")?.gameObject?.SetActive(false);

        __instance.inventoryButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0.0235f, 0.6f, 1f);
        __instance.inventoryButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0.0235f, 0.6f, 2f);
        Color originalColorInventoryButton = __instance.inventoryButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.inventoryButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorInventoryButton * 0.6f;
        __instance.inventoryButton.activeSprites.GetComponent<SpriteRenderer>().color = originalColorPlayButton * 0.75f;
        __instance.inventoryButton.activeTextColor = Color.white;
        __instance.inventoryButton.inactiveTextColor = Color.white;
        __instance.inventoryButton.activeSprites.transform.FindChild("Shine")?.gameObject?.SetActive(false);
        __instance.inventoryButton.inactiveSprites.transform.FindChild("Shine")?.gameObject?.SetActive(false);

        __instance.shopButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0.0235f, 0.6f, 1f);
        __instance.shopButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0.0235f, 0.6f, 2f);
        Color originalColorShopButton = __instance.shopButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.shopButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorShopButton * 0.6f;
        __instance.shopButton.activeSprites.GetComponent<SpriteRenderer>().color = originalColorPlayButton * 0.75f;
        __instance.shopButton.activeTextColor = Color.white;
        __instance.shopButton.inactiveTextColor = Color.white;
        __instance.shopButton.activeSprites.transform.FindChild("Shine")?.gameObject?.SetActive(false);
        __instance.shopButton.inactiveSprites.transform.FindChild("Shine")?.gameObject?.SetActive(false);

        __instance.newsButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0.255f, 0.482f, 1f);
        __instance.newsButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0.255f, 0.482f, 2f, 0.8f);
        Color originalColorNewsButton = __instance.newsButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.newsButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorNewsButton * 0.6f;
        __instance.newsButton.activeTextColor = Color.white;
        __instance.newsButton.inactiveTextColor = Color.white;

        __instance.myAccountButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0.255f, 0.482f, 1f);
        __instance.myAccountButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0.255f, 0.482f, 2f, 0.8f);
        Color originalColorMyAccount = __instance.myAccountButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.myAccountButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorMyAccount * 0.6f;
        __instance.myAccountButton.activeTextColor = Color.white;
        __instance.myAccountButton.inactiveTextColor = Color.white;
        __instance.accountButtons.transform.position += new Vector3(0f, 0f, -1f);

        __instance.settingsButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0.255f, 0.482f, 1f);
        __instance.settingsButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0.255f, 0.482f, 2f, 0.8f);
        Color originalColorSettingsButton = __instance.settingsButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.settingsButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorSettingsButton * 0.6f;
        __instance.settingsButton.activeTextColor = Color.white;
        __instance.settingsButton.inactiveTextColor = Color.white;

        __instance.quitButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0.333f, 0.255f, 1f);
        __instance.quitButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0.333f, 0.255f, 2f, 0.8f);
        Color originalColorQuitButton = __instance.quitButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.quitButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorQuitButton * 0.6f;
        __instance.quitButton.activeTextColor = Color.white;
        __instance.quitButton.inactiveTextColor = Color.white;
        __instance.quitButton.transform.localPosition += new Vector3(0.03f, 0f, 0);
        __instance.quitButton.transform.localScale = new Vector3(0.838f, 0.84f, 0);

        __instance.creditsButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0.333f, 0.255f, 1f);
        __instance.creditsButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0.333f, 0.255f, 2f, 0.8f);
        Color originalColorCreditsButton = __instance.creditsButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.creditsButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorCreditsButton * 0.6f;
        __instance.creditsButton.activeTextColor = Color.white;
        __instance.creditsButton.inactiveTextColor = Color.white;
        __instance.creditsButton.transform.localPosition += new Vector3(-0.03f, 0f, 0);
        __instance.creditsButton.transform.localScale = new Vector3(0.803f, 0.84f, 0);

        __instance.freePlayButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0.191f, 255f);
        __instance.freePlayButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 255f, 0.8f);
        Color originalColorfreePlayButton = __instance.freePlayButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.freePlayButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorfreePlayButton * 0.6f;
        __instance.freePlayButton.activeTextColor = Color.white;
        __instance.freePlayButton.inactiveTextColor = Color.white;

        __instance.howToPlayButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0.191f, 255f);
        __instance.howToPlayButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 255f,0.8f);
        Color originalColorhowToPlayButton = __instance.howToPlayButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.howToPlayButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorhowToPlayButton * 0.6f;
        __instance.howToPlayButton.activeTextColor = Color.white;
        __instance.howToPlayButton.inactiveTextColor = Color.white;

    }
    public static void Modify(this PassiveButton passiveButton, Action action)
    {
        if (passiveButton == null) return;
        passiveButton.OnClick = new Button.ButtonClickedEvent();
        passiveButton.OnClick.AddListener(action);
    }
    public static T FindChild<T>(this MonoBehaviour obj, string name) where T : Object
    {
        string name2 = name;
        return obj.GetComponentsInChildren<T>().First((T c) => c.name == name2);
    }
    public static T FindChild<T>(this GameObject obj, string name) where T : Object
    {
        string name2 = name;
        return obj.GetComponentsInChildren<T>().First((T c) => c.name == name2);
    }
    public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
    {
        //if (source == null) throw new ArgumentNullException("source");
        if (source == null) throw new ArgumentNullException(nameof(source));

        IEnumerator<TSource> enumerator = source.GetEnumerator();
        while (enumerator.MoveNext())
        {
            action(enumerator.Current);
        }

        enumerator.Dispose();
    }
}