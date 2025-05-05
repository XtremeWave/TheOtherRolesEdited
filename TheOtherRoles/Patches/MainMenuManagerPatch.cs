using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(MainMenuManager))]
public static class MainMenuManagerPatch
{
    public static Action HideRightPanel { get; internal set; }

    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.LateUpdate)), HarmonyPostfix]
    public static void StartPostfix(MainMenuManager __instance)
    {
        __instance.screenTint.gameObject.transform.localPosition += new Vector3(1000f, 0f);
        __instance.screenTint.enabled = false;
        __instance.rightPanelMask.SetActive(true);
        // The background texture (large sprite asset)
        GameObject.Find("BackgroundTexture")?.SetActive(false);
        // The glint on the Among Us Menu
        GameObject.Find("WindowShine")?.SetActive(false);
        GameObject.Find("ScreenCover")?.SetActive(false);

        GameObject leftPanel = __instance.mainMenuUI.FindChild<Transform>("LeftPanel").gameObject;
        GameObject rightPanel = __instance.mainMenuUI.FindChild<Transform>("RightPanel").gameObject;
        rightPanel.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        GameObject maskedBlackScreen = rightPanel.FindChild<Transform>("MaskedBlackScreen").gameObject;
        maskedBlackScreen.GetComponent<SpriteRenderer>().enabled = false;
        //maskedBlackScreen.transform.localPosition = new Vector3(-3.345f, -2.05f); //= new Vector3(0f, 0f);
        //maskedBlackScreen.transform.localScale = new (7.35f, 4.5f, 4f);
        //__instance.mainMenuUI.gameObject.transform.position += new Vector3(-0.2f, 0f);
        leftPanel.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        leftPanel.gameObject.FindChild<SpriteRenderer>("Divider").enabled = false;
        leftPanel.GetComponentsInChildren<SpriteRenderer>(true).Where(r => r.name == "Shine").ToList().ForEach(r => r.enabled = false);



        /*  var howToPlayButton = __instance.howToPlayButton;
          var freeplayButton = howToPlayButton.transform.parent.Find("FreePlayButton");
          if (freeplayButton != null) freeplayButton.gameObject.SetActive(false);
          howToPlayButton.transform.SetLocalX(0);

          var PlayOnlineButton = __instance.PlayOnlineButton;
          var PlayLocalButton = PlayOnlineButton.transform.parent.Find("PlayLocalButton");
          if (PlayLocalButton != null) PlayLocalButton.gameObject.SetActive(false);
          PlayOnlineButton.transform.SetLocalX(0);*/

        __instance.playButton.buttonText.color = Color.white;
        __instance.inventoryButton.buttonText.color = Color.white;
        __instance.shopButton.buttonText.color = Color.white;
        __instance.newsButton.buttonText.color = Color.white;
        __instance.myAccountButton.buttonText.color = Color.white;
        __instance.settingsButton.buttonText.color = Color.white;
        __instance.howToPlayButton.buttonText.color = Color.white;
        __instance.accountCTAButton.buttonText.color = Color.white;
        __instance.freePlayButton.buttonText.color = Color.white;

        __instance.freePlayButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0.191f, 255f);
        __instance.freePlayButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 255f);
        Color originalColorfreePlayButton = __instance.freePlayButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.freePlayButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorfreePlayButton * 0.6f;
        __instance.freePlayButton.activeTextColor = Color.white;
        __instance.freePlayButton.inactiveTextColor = Color.white;

        __instance.accountCTAButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0.191f, 255f);
        __instance.accountCTAButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 255f);
        Color originalColoraccountCTAButton = __instance.accountCTAButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.accountCTAButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColoraccountCTAButton * 0.6f;
        __instance.accountCTAButton.activeTextColor = Color.white;
        __instance.accountCTAButton.inactiveTextColor = Color.white;

        __instance.howToPlayButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0.191f, 255f);
        __instance.howToPlayButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 255f);
        Color originalColorhowToPlayButton = __instance.howToPlayButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.howToPlayButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorhowToPlayButton * 0.6f;
        __instance.howToPlayButton.activeTextColor = Color.white;
        __instance.howToPlayButton.inactiveTextColor = Color.white;

        __instance.playButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0.191f, 255f);
        __instance.playButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 255f);
        Color originalColorPlayButton = __instance.playButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.playButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorPlayButton * 0.6f;
        __instance.playButton.activeSprites.GetComponent<SpriteRenderer>().color = originalColorPlayButton * 0.6f;
        __instance.playButton.activeTextColor = Color.white;
        __instance.playButton.inactiveTextColor = Color.white;

        __instance.inventoryButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0.191f, 255f);
        __instance.inventoryButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 255f);
        Color originalColorInventoryButton = __instance.inventoryButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.inventoryButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorInventoryButton * 0.6f;
        __instance.inventoryButton.activeSprites.GetComponent<SpriteRenderer>().color = originalColorPlayButton * 0.6f;
        __instance.inventoryButton.activeTextColor = Color.white;
        __instance.inventoryButton.inactiveTextColor = Color.white;

        __instance.shopButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0.191f, 255f);
        __instance.shopButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 255f);
        Color originalColorShopButton = __instance.shopButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.shopButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorShopButton * 0.6f;
        __instance.shopButton.activeSprites.GetComponent<SpriteRenderer>().color = originalColorPlayButton * 0.6f;
        __instance.shopButton.activeTextColor = Color.white;
        __instance.shopButton.inactiveTextColor = Color.white;


        __instance.newsButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0.191f, 255f);
        __instance.newsButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 255f);
        Color originalColorNewsButton = __instance.newsButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.newsButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorNewsButton * 0.6f;
        __instance.newsButton.activeTextColor = Color.white;
        __instance.newsButton.inactiveTextColor = Color.white;

        __instance.myAccountButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0.191f, 255f);
        __instance.myAccountButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 255f);
        Color originalColorMyAccount = __instance.myAccountButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.myAccountButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorMyAccount * 0.6f;
        __instance.myAccountButton.activeTextColor = Color.white;
        __instance.myAccountButton.inactiveTextColor = Color.white;
        __instance.accountButtons.transform.position += new Vector3(0f, 0f, -1f);

        __instance.settingsButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0.191f, 255f);
        __instance.settingsButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 255f);
        Color originalColorSettingsButton = __instance.settingsButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.settingsButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorSettingsButton * 0.6f;
        __instance.settingsButton.activeTextColor = Color.white;
        __instance.settingsButton.inactiveTextColor = Color.white;


        __instance.quitButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0.191f, 255f);
        __instance.quitButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 255f);
        Color originalColorQuitButton = __instance.quitButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.quitButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorQuitButton * 0.6f;
        __instance.quitButton.activeTextColor = Color.white;
        __instance.quitButton.inactiveTextColor = Color.white;

        __instance.creditsButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0.191f, 255f);
        __instance.creditsButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 255f);
        Color originalColorCreditsButton = __instance.creditsButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        __instance.creditsButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorCreditsButton * 0.6f;
        __instance.creditsButton.activeTextColor = Color.white;
        __instance.creditsButton.inactiveTextColor = Color.white;
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