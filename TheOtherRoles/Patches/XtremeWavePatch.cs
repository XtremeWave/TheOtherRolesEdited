using HarmonyLib;
using AmongUs.Data;
using UnityEngine;
using TheOtherRolesEdited.Players;
using System.Linq;
using System.Text;
using Il2CppSystem.Text.RegularExpressions;

namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(LobbyBehaviour), nameof(LobbyBehaviour.Start))]
public class XtremeWavePatch
{
    private static GameObject Paint;
    public static void Postfix(LobbyBehaviour __instance)
    {
        if (Paint != null) return;
        Paint = Object.Instantiate(__instance.transform.FindChild("Leftbox").gameObject, __instance.transform);
        Paint.name = "XtremeWave Lobby Paint";
        Paint.transform.localPosition = new Vector3(0.042f, -2.59f, -10.5f);
        SpriteRenderer renderer = Paint.GetComponent<SpriteRenderer>();
        renderer.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.MainPhoto.XtremeWave.png", 290f);
    }
}
//来自YUAC的代码

