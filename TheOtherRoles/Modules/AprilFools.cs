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
        Long = 2,
        LongSeeker = 3
    }

    public static FoolMode CurrentMode = FoolMode.Default;
    private static PassiveButton modeToggleButton; // 模式切换按钮引用
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

            if (modeToggleButton.inactiveSprites != null)
            {
                var inactiveSprite = modeToggleButton.inactiveSprites.GetComponent<SpriteRenderer>();
                if (inactiveSprite != null)
                {
                    inactiveSprite.color = new Color(0.333f, 0.255f, 1f) * 0.6f;
                }
            }

            if (modeToggleButton.activeSprites != null)
            {
                var activeSprite = modeToggleButton.activeSprites.GetComponent<SpriteRenderer>();
                if (activeSprite != null)
                {
                    activeSprite.color = new Color(0.333f, 0.255f, 2f, 0.8f);
                }
            }

            modeToggleButton.OnClick.AddListener((System.Action)(() =>
            {
                CurrentMode = (FoolMode)((int)CurrentMode + 1);
                if ((int)CurrentMode > 3)
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
            case FoolMode.Long:
                modeButtonText.SetText(ModTranslation.getString("LongMode")); // 长颈豆模式
                break;
            case FoolMode.LongSeeker:
                modeButtonText.SetText(ModTranslation.getString("LongSeekerMode")); // 长颈马模式
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
            case FoolMode.Long:
                bodyType = PlayerBodyTypes.Long;
                break;
            case FoolMode.LongSeeker:
                bodyType = PlayerBodyTypes.LongSeeker;
                break;
            default:
                break;
        }
    }

    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.BodyType), MethodType.Getter)]
    [HarmonyPrefix]
    public static bool GetBodyTypePrefix(ref PlayerBodyTypes __result)
    {
        if (GameManager.Instance != null && GameManager.Instance.IsHideAndSeek())
        {
            return true;
        }

        switch (CurrentMode)
        {
            case FoolMode.Horse:
                __result = PlayerBodyTypes.Horse;
                return false;
            case FoolMode.Long:
                __result = PlayerBodyTypes.Long;
                return false;
            case FoolMode.LongSeeker:
                __result = PlayerBodyTypes.LongSeeker;
                return false;
            default:
                return true;
        }
    }
    [HarmonyPatch(typeof(LongBoiPlayerBody))]
    public static class LongBoiPatches
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(LongBoiPlayerBody), nameof(LongBoiPlayerBody.Awake))]
        public static bool LongBodyAwakePatch(LongBoiPlayerBody __instance)
        {
            __instance.cosmeticLayer.OnSetBodyAsGhost += (Action)__instance.SetPoolableGhost;
            __instance.cosmeticLayer.OnColorChange += (Action<int>)__instance.SetHeightFromColor;
            __instance.cosmeticLayer.OnCosmeticSet +=(Action<string, int, CosmeticsLayer.CosmeticKind>)__instance.OnCosmeticSet;
            __instance.gameObject.layer = 8;

            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(LongBoiPlayerBody), nameof(LongBoiPlayerBody.SetHeightFromColor))]
        public static bool SetHeightColorPatch(LongBoiPlayerBody __instance)
        {
            if (!__instance.isPoolablePlayer)
            {
                if (GameManager.Instance.IsHideAndSeek() &&
                    AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Started &&
                    __instance.myPlayerControl.Data.Role != null &&
                    __instance.myPlayerControl.Data.Role.TeamType == RoleTeamTypes.Impostor)
                {
                    return false;
                }

                __instance.targetHeight = __instance.heightsPerColor[0] - 0.5f;
                if (LobbyBehaviour.Instance)
                {
                    __instance.SetupNeckGrowth(false, false);
                    return false;
                }

                __instance.SetupNeckGrowth(true, false);
            }

            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(LongBoiPlayerBody), nameof(LongBoiPlayerBody.Start))]
        public static bool LongBodyStartPatch(LongBoiPlayerBody __instance)
        {
            __instance.ShouldLongAround = true;
            __instance.skipNeckAnim = true;
            if (__instance.hideCosmeticsQC)
            {
                __instance.cosmeticLayer.SetHatVisorVisible(false);
            }

            __instance.SetupNeckGrowth(true);
            if (__instance.isExiledPlayer)
            {
                var instance = ShipStatus.Instance;
                if (instance == null || instance.Type != ShipStatus.MapType.Fungle)
                {
                    __instance.cosmeticLayer.AdjustCosmeticRotations(-17.75f);
                }
            }

            if (!__instance.isPoolablePlayer)
            {
                __instance.cosmeticLayer.ValidateCosmetics();
            }

            if (__instance.myPlayerControl)
            {
                __instance.StopAllCoroutines();
                __instance.SetHeightFromColor(__instance.myPlayerControl.Data.DefaultOutfit.ColorId);
            }

            return false;
        }
    }
}