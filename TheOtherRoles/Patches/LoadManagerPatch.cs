using Image = UnityEngine.UI.Image;
using HarmonyLib;
using UnityEngine;
using Object = UnityEngine.Object;
using TheOtherRolesEdited;
using InnerNet;
namespace TheOtherRolesEdited.Patches;

[HarmonyPatch(typeof(LoadingBarManager))]
public class LoadingBarManagerPatch
{
    private static GameObject _amongUsLogo;
    private static GameObject _modLogo;
    private static Vector3 _logoVector;
    private static bool _hasSetVec;
    public static bool IsNotJoined => AmongUsClient.Instance.GameState == InnerNetClient.GameStates.NotJoined;

    [HarmonyPatch(nameof(LoadingBarManager.ToggleLoadingBar))]
    public static void Prefix(LoadingBarManager __instance, ref bool on)
    {
        _amongUsLogo = __instance.loadingBar.transform.FindChild("Canvas").FindChild("Logo").gameObject;
        if (_amongUsLogo)
        {
            var trans = _amongUsLogo.GetComponent<RectTransform>();
            var cr = _amongUsLogo.GetComponent<CanvasRenderer>();
            if (!_hasSetVec)
            {
                _hasSetVec = true;
                _logoVector = trans.localPosition;
            }

            if (!_modLogo)
            {
                _modLogo = Object.Instantiate(_amongUsLogo, trans.parent);
                _modLogo.GetComponent<Image>().sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.MainPhoto.TORE-Banner.png", 150f);
            }

            trans.localScale = new Vector3(0.3f, 0.3f, 1);
            cr.transform.localPosition = new Vector3(_logoVector.x, _logoVector.y + 60, _logoVector.z);
            trans.localPosition = new Vector3(_logoVector.x, _logoVector.y + 60, _logoVector.z);
            cr.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            _modLogo.GetComponent<RectTransform>().localPosition =
                new Vector3(_logoVector.x, _logoVector.y - 80, _logoVector.z);
            _modLogo.GetComponent<CanvasRenderer>().transform.localPosition =
                new Vector3(_logoVector.x, _logoVector.y - 80, _logoVector.z);
            _modLogo.GetComponent<RectTransform>().localScale = new Vector3(1.4f, 1f, 1);
            _modLogo.GetComponent<CanvasRenderer>().transform.localScale = new Vector3(1.4f, 1f, 1);
        }

        __instance.loadingBar.barFill.color = new(0, 0, 255, 255);
        __instance.loadingBar.crewmate.gameObject.SetActive(false);

        try
        {
            if (!IsNotJoined) return;
            on = false;
        }
        catch
        {
            on = false;
        }
    }
}