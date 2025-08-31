using HarmonyLib;
using UnityEngine;

namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(LobbyBehaviour), nameof(LobbyBehaviour.Start))]
public class LobbyStartPatch
{
    private static GameObject Paint;
    public static void Postfix(LobbyBehaviour __instance)
    {
        if (Paint != null) return;
        Paint = Object.Instantiate(__instance.transform.FindChild("Leftbox").gameObject, __instance.transform);
        Paint.name = "TheOtherRolesEdited Lobby Paint";
        Paint.transform.localPosition = new Vector3(0.069f,3.85f,-10.5f);
        SpriteRenderer renderer = Paint.GetComponent<SpriteRenderer>();
        renderer.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.MainPhoto.TORE-LTS.png", 280f);
    }
}