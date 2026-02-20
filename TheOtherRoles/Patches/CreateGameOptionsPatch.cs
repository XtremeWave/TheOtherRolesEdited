using HarmonyLib;
using Reactor.Utilities.Extensions;
using System;
using TheOtherRolesEdited.Modules;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TheOtherRolesEdited.Patches;

internal class CreateGameOptionsPatch
{
    public static PassiveButton modeButtonGS;
    public static PassiveButton modeButtonHK;
    public static PassiveButton modeButtonPH;

    public static bool One = true;

    [HarmonyPatch(typeof(CreateGameOptions), nameof(CreateGameOptions.Show))]
    static class CreateGameOptionsOpenShowPatch
    {
        static void Postfix(CreateGameOptions __instance)
        {
            if ((modeButtonGS != null && modeButtonGS.IsSelected()) ||
                (modeButtonHK != null && modeButtonHK.IsSelected()) ||
                (modeButtonPH != null && modeButtonPH.IsSelected()))
            {
                __instance.modeButtons[0].SelectButton(false);
                __instance.modeButtons[1].SelectButton(false);
            }
        }
    }

    [HarmonyPatch(typeof(CreateGameOptions), nameof(CreateGameOptions.Start))]
    public static class CreateGameOptionsStartPatch
    {
        private static void Postfix(CreateGameOptions __instance)
        {
            __instance.levelButtons[0].transform.parent.gameObject.SetActive(false);
            GameObject.Find("ModeOptions").transform.SetLocalY(-2.52f);
            GameObject.Find("ServerOption").transform.SetLocalY(-0.86f);
            GameObject.Find("ModeOptions").transform.GetChild(2).gameObject.SetActive(false);

            __instance.serverDropdown.transform.SetLocalY(-0.6f);

            __instance.modeButtons[0].OnClick.AddListener((Action)(() =>
            {
                modeButtonGS.SelectButton(false);
                modeButtonHK.SelectButton(false);
                modeButtonPH.SelectButton(false);
            }
            ));

            __instance.modeButtons[1].OnClick.AddListener((Action)(() =>
            {
                modeButtonGS.SelectButton(false);
                modeButtonHK.SelectButton(false);
                modeButtonPH.SelectButton(false);
            }
            ));

            modeButtonGS = Object.Instantiate(__instance.modeButtons[0], __instance.modeButtons[0].transform);
            modeButtonGS.name = "TORGUESSER";
            changeButtonText(modeButtonGS, $"{ModTranslation.getString("Guesser")}");
            modeButtonGS.transform.SetLocalX(2.9296f);
            modeButtonGS.OnClick.RemoveAllListeners();
            __instance.StartCoroutine(Effects.Lerp(0.1f, new Action<float>(p => modeButtonGS.SelectButton(false))));
            modeButtonGS.OnMouseOver.AddListener((Action)(() => __instance.tooltip.SetText($"{ModTranslation.getString("GuesserTip")}")));
            modeButtonGS.OnClick.AddListener((Action)(() => __instance.tooltip.SetText($"{ModTranslation.getString("GuesserTip")}")));
            modeButtonGS.OnClick.AddListener((Action)(() =>
            {
                TORMapOptions.gameMode = CustomGamemodes.Guesser;
                modeButtonGS.SelectButton(true);
                __instance.modeButtons[0].SelectButton(false);
                __instance.modeButtons[1].SelectButton(false);
                modeButtonHK.SelectButton(false);
                modeButtonPH.SelectButton(false);
            }
            ));

            modeButtonHK = Object.Instantiate(modeButtonGS, __instance.modeButtons[0].transform);
            modeButtonHK.name = "TORHIDENSEEK";
            changeButtonText(modeButtonHK, $"{ModTranslation.getString("HideNSeek")}");
            modeButtonHK.transform.SetLocalX(5.8608f);
            modeButtonHK.OnClick.RemoveAllListeners();
            __instance.StartCoroutine(Effects.Lerp(0.1f, new Action<float>(p => modeButtonHK.SelectButton(false))));
            modeButtonHK.OnMouseOver.AddListener((Action)(() => __instance.tooltip.SetText($"{ModTranslation.getString("HideNSeekTip")}")));
            modeButtonHK.OnClick.AddListener((Action)(() => __instance.tooltip.SetText($"{ModTranslation.getString("HideNSeekTip")}")));
            modeButtonHK.OnClick.AddListener((Action)(() =>
            {
                TORMapOptions.gameMode = CustomGamemodes.HideNSeek;
                modeButtonHK.SelectButton(true);
                __instance.modeButtons[0].SelectButton(false);
                __instance.modeButtons[1].SelectButton(false);
                modeButtonGS.SelectButton(false);
                modeButtonPH.SelectButton(false);
            }
            ));

            modeButtonPH = Object.Instantiate(modeButtonHK, __instance.modeButtons[0].transform);
            modeButtonPH.name = "TORPROPHUNT";
            changeButtonText(modeButtonPH, $"{ModTranslation.getString("PropHunt")}");
            modeButtonPH.transform.SetLocalX(0);
            modeButtonPH.transform.SetLocalY(-0.9f);
            modeButtonPH.OnClick.RemoveAllListeners();
            __instance.StartCoroutine(Effects.Lerp(0.1f, new Action<float>(p => modeButtonPH.SelectButton(false))));
            modeButtonPH.OnMouseOver.AddListener((Action)(() => __instance.tooltip.SetText($"{ModTranslation.getString("PropHuntTip")}")));
            modeButtonPH.OnClick.AddListener((Action)(() => __instance.tooltip.SetText($"{ModTranslation.getString("PropHuntTip")}")));
            modeButtonPH.OnClick.AddListener((Action)(() =>
            {
                TORMapOptions.gameMode = CustomGamemodes.PropHunt;
                modeButtonPH.SelectButton(true);
                __instance.modeButtons[0].SelectButton(false);
                __instance.modeButtons[1].SelectButton(false);
                modeButtonGS.SelectButton(false);
                modeButtonHK.SelectButton(false);
            }
            ));
        }
        internal static void changeButtonText(PassiveButton passiveButton, string buttonText)
        {
            passiveButton.transform.FindChild("SelectedInactive/ClassicText").gameObject.GetComponentInChildren<TextTranslatorTMP>().Destroy();
            passiveButton.transform.FindChild("Inactive/ClassicText").gameObject.GetComponentInChildren<TextTranslatorTMP>().Destroy();
            passiveButton.transform.FindChild("Highlight/ClassicText").gameObject.GetComponentInChildren<TextTranslatorTMP>().Destroy();
            passiveButton.transform.FindChild("SelectedHighlight/ClassicText").gameObject.GetComponentInChildren<TextTranslatorTMP>().Destroy();

            passiveButton.transform.FindChild("SelectedInactive/ClassicText").gameObject.GetComponentInChildren<TMP_Text>().SetText(buttonText);
            passiveButton.transform.FindChild("Inactive/ClassicText").gameObject.GetComponentInChildren<TMP_Text>().SetText(buttonText);
            passiveButton.transform.FindChild("Highlight/ClassicText").gameObject.GetComponentInChildren<TMP_Text>().SetText(buttonText);
            passiveButton.transform.FindChild("SelectedHighlight/ClassicText").gameObject.GetComponentInChildren<TMP_Text>().SetText(buttonText);
        }
    }
    [HarmonyPatch(typeof(CreateGameOptions), nameof(CreateGameOptions.OpenConfirmPopup))]
    static class CreateGameOptionsOpenConfirmPopupPatch
    {
        static string getModeText(CustomGamemodes customGamemodes)
        {
            switch (customGamemodes)
            {
                case CustomGamemodes.Classic:
                    return DestroyableSingleton<TranslationController>.Instance.GetString(StringNames.GameTypeClassic);
                case CustomGamemodes.Guesser:
                    return $"{ModTranslation.getString("Guesser")}";
                case CustomGamemodes.HideNSeek:
                    return $"{ModTranslation.getString("HideNSeek")}";
                case CustomGamemodes.PropHunt:
                    return $"{ModTranslation.getString("PropHunt")}";
                default:
                    return DestroyableSingleton<TranslationController>.Instance.GetString(StringNames.GameTypeHideAndSeek);
            }
        }

        static void Postfix(CreateGameOptions __instance)
        {            
            __instance.containerConfirm.GetChild(10).gameObject.SetActive(false);
            __instance.containerConfirm.GetChild(8).localPosition = new(4f, -0.47f, -0.1f);
            __instance.containerConfirm.GetChild(5).GetChild(2).GetComponent<TextMeshPro>().SetText(getModeText(TORMapOptions.gameMode));
        }
    }
}