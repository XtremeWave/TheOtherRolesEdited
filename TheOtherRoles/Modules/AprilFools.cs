using HarmonyLib;
using Reactor.Utilities.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using System.Collections;
using InnerNet;
using System;

namespace TheOtherRolesEdited.Modules;

[HarmonyPatch]
public static class AprilFoolsPatches
{
    public enum FoolMode
    {
        Default = 0,
        Horse = 1,
    }

    public static FoolMode CurrentMode = FoolMode.Default;
    internal static PassiveButton modeToggleButton; // 模式切换按钮引用
    private static TMPro.TMP_Text modeButtonText; // 按钮文本引用

    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    [HarmonyPrefix]
    public static void StartPrefix(MainMenuManager __instance)
    {
        CreateModeToggleButton(__instance);
    }

    private static void CreateModeToggleButton(MainMenuManager __instance)
    {
        var template = GameObject.Find("CreditsButton");
        var modeButton = Object.Instantiate(template, template.transform.parent);
        modeButton.name = "FoolModeToggleButton";
        var scale = __instance.creditsButton.transform.localScale;
        var scalerList = __instance.mainMenuUI.GetComponent<SlicedAspectScaler>();
        scalerList.objectsToScale.Add(modeButton.GetComponent<AspectScaledAsset>());
        var aspectPos = modeButton.GetComponent<AspectPosition>();
        if (aspectPos != null)
        {
            aspectPos.anchorPoint = new Vector2(0.586f, 0.43f);
            aspectPos.AdjustPosition();
        }

        modeButtonText = modeButton.transform.GetComponentInChildren<TMPro.TMP_Text>();
        __instance.StartCoroutine(Effects.Lerp(0.5f, new System.Action<float>((p) =>
        {
            if (modeButtonText != null)
            {
                modeButtonText.text = string.Empty;
                UpdateModeButtonText();
                modeButtonText.ForceMeshUpdate();
            }
        })));
        modeToggleButton = modeButton.GetComponent<PassiveButton>();
        if (modeToggleButton != null)
        {
            modeToggleButton.activeTextColor = new Color32(0, 191, 255, byte.MaxValue);
            modeToggleButton.OnClick = new Button.ButtonClickedEvent();
            modeToggleButton.OnClick.AddListener((System.Action)(() =>
            {
                CurrentMode = (FoolMode)((int)CurrentMode + 1);
                if ((int)CurrentMode > 1)
                {
                    CurrentMode = FoolMode.Default;
                }
                UpdateModeButtonText();
            }));
        }
    }

    private static void UpdateModeButtonText()
    {
        if (modeButtonText == null) return;

        switch (CurrentMode)
        {
            case FoolMode.Default:
                modeButtonText.SetText(ModTranslation.getString("DefaultMode")); //正常模式
                break;
            case FoolMode.Horse:
                modeButtonText.SetText(ModTranslation.getString("HorseMode")); // 马模式
                break;
        }

        modeButtonText.ForceMeshUpdate();
    }

    [HarmonyPatch(typeof(PlayerPhysics), nameof(PlayerPhysics.SetBodyType))]
    [HarmonyPrefix]
    public static void SetBodyTypePrefix(ref PlayerBodyTypes bodyType)
    {
        if (GameManager.Instance != null && GameManager.Instance.IsHideAndSeek())
        {
            return;
        }

        switch (CurrentMode)
        {
            case FoolMode.Horse:
                bodyType = PlayerBodyTypes.Horse;
                break;
        }
    }
}