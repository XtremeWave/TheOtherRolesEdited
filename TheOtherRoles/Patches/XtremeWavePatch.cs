using HarmonyLib;
using AmongUs.Data;
using UnityEngine;
using System.Collections;
using BepInEx.Unity.IL2CPP.Utils;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(LobbyBehaviour), nameof(LobbyBehaviour.Start))]
public class XtremeWavePatch
{
    private static GameObject Paint;
   // private static GameObject UI;

    public static void Postfix(LobbyBehaviour __instance)
    {
        if (Paint != null) return;
        Paint = Object.Instantiate(__instance.transform.FindChild("Leftbox").gameObject, __instance.transform);
        Paint.name = "XtremeWave Lobby Paint";
        Paint.transform.localPosition = new Vector3(0.042f, -2.59f, -10.5f);
        SpriteRenderer renderer = Paint.GetComponent<SpriteRenderer>();
        renderer.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.MainPhoto.XtremeWave.png", 290f);

      /*  if (UI != null)Object.Destroy(UI); UI = null;
        UI = Object.Instantiate(__instance.transform.FindChild("panel_Wardrobe").gameObject, __instance.transform);
        UI.name = "Lobby";
        UI.transform.localPosition = new Vector3(-1.556f, 1.21f, -10.5f);
        UI.transform.localScale = new Vector3(0.6f, 0.6f, 0f);
        SpriteRenderer renderer1 = UI.GetComponent<SpriteRenderer>();
        renderer1.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.MainPhoto.XtremeWave.png", 290f);
        __instance.StartCoroutine(FloatUpDown(UI.transform, 0.13f));

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
    }*/
      }
}