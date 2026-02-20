using HarmonyLib;
using UnityEngine;
using TMPro;
using System;
using Object = UnityEngine.Object;
using UnityEngine.UI;

namespace TheOtherRolesEdited.Modules;

[HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Update))]
public static class abbb
{
    private static bool isAspectSizeVisible = true;
    private static GameObject aspectSizeCache;
    private static PassiveButton startButtonCache;
    private static TextMeshPro startButtonTextCache;
    private static bool isEventBound = false;
    private static bool isButtonInstantiated = false;

    public static void Postfix(GameStartManager __instance)
    {
        InitCaches(__instance);

        if (aspectSizeCache == null || startButtonCache == null || startButtonTextCache == null) return;

        if (!isEventBound)
        {
            startButtonCache.OnClick.AddListener((Action)(() => ToggleAspectSizeVisibility()));
            isEventBound = true;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            ToggleAspectSizeVisibility();
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
            startButtonTextCache.text = isAspectSizeVisible ? "Òþ²Ø" : "ÏÔÊ¾";
        }
    }
}