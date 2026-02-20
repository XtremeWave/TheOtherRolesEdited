#if PC
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Il2CppSystem;
using TheOtherRolesEdited.Modules;
using UnityEngine;

namespace TheOtherRolesEdited;

[HarmonyPatch]
public class MainMenuButtonHoverAnimation
{
    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    [HarmonyPostfix]
    [HarmonyPriority(Priority.Last)]

    private static void Start_Postfix(MainMenuManager __instance)
    {
        var mainButtons = GameObject.Find("Main Buttons");

        mainButtons.ForEachChild((Action<GameObject>)Init);
    }
    public static Dictionary<GameObject, (Vector3, bool)> AllButtons = new();

    private static void SetButtonStatus(GameObject obj, bool active)
    {
        AllButtons.TryAdd(obj, (obj.transform.position, active));
        AllButtons[obj] = (AllButtons[obj].Item1, active);
    }

    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.LateUpdate))]
    [HarmonyPostfix]
    private static void Update_Postfix(MainMenuManager __instance)
    {
        if (GameObject.Find("MainUI") == null) return;

        foreach (var kvp in AllButtons.Where(x => x.Key != null && x.Key.active))
        {
            var button = kvp.Key;
            var pos = button.transform.position;
            var targetPos = kvp.Value.Item1 + new Vector3(kvp.Value.Item2 ? 0.35f : 0f, 0f, 0f);
            if (kvp.Value.Item2 && pos.x > (kvp.Value.Item1.x + 2f)) continue;
            button.transform.position = kvp.Value.Item2
                ? Vector3.Lerp(pos, targetPos, Time.deltaTime * 2f)
                : Vector3.MoveTowards(pos, targetPos, Time.deltaTime * 2f);
        }
    }

    public static void RefreshButtons(GameObject obj)
    {
        AllButtons = new Dictionary<GameObject, (Vector3, bool)>();
        obj.ForEachChild((Action<GameObject>)Init);
    }

    private static void Init(GameObject obj)
    {
        if (obj.name is "Divider") return;
        if (AllButtons.ContainsKey(obj)) return;
        SetButtonStatus(obj, false);
        var pb = obj.GetComponent<PassiveButton>();
        pb.OnMouseOver.AddListener((global::System.Action)(() => SetButtonStatus(obj, true)));
        pb.OnMouseOut.AddListener((global::System.Action)(() => SetButtonStatus(obj, false)));
    }
}
#endif