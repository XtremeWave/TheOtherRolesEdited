using BepInEx.Unity.IL2CPP.Utils;
using HarmonyLib;
using System.Collections;
using UnityEngine;

namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(LobbyBehaviour), nameof(LobbyBehaviour.Start))]
public class LobbyStartPatch
{
    private static GameObject Paint;
    private static GameObject XtremeWave;

    public static void Postfix(LobbyBehaviour __instance)
    {
        if (Paint != null) return;
        Paint = Object.Instantiate(__instance.transform.FindChild("Leftbox").gameObject, __instance.transform);
        Paint.name = "TheOtherRolesEdited Lobby Paint";
        Paint.transform.localPosition = new Vector3(0.069f, 3.85f, -10.5f);
        SpriteRenderer renderer = Paint.GetComponent<SpriteRenderer>();
        renderer.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.UI.TORE-Banner1.png", 280f);

        if (XtremeWave != null) Object.Destroy(XtremeWave); XtremeWave = null;
        XtremeWave = Object.Instantiate(__instance.transform.FindChild("Leftbox").gameObject, __instance.transform);
        XtremeWave.name = "XtremeWave Lobby XtremeWave";
        XtremeWave.transform.localPosition = new Vector3(0.042f, -2.59f, -10.5f);
        SpriteRenderer picture = XtremeWave.GetComponent<SpriteRenderer>();
        picture.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.UI.XtremeWave.png", 290f);
        __instance.StartCoroutine(FloatUpDown(XtremeWave.transform, 0.13f));
    }

    private static IEnumerator FloatUpDown(Transform targetTransform, float distance)
    {
        Vector3 startPosition = targetTransform.localPosition;
        float elapsedTime = 0f;

        while (true)
        {
            float newY = startPosition.y + Mathf.Sin(elapsedTime) * distance;
            targetTransform.localPosition = new Vector3(startPosition.x, newY, startPosition.z);
            elapsedTime += Time.deltaTime * 2f;
            yield return null;
        }
    }
}