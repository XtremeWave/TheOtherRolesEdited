/*using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TheOtherRolesEdited;

// Thanks Galster (https://github.com/Galster-dev), taken from https://github.com/Tommy-XL/Unlock-dlekS-ehT/blob/main/Patches/CoStartGameHostPatch.cs
[HarmonyPatch(typeof(AmongUsClient._CoStartGameHost_d__28), nameof(AmongUsClient._CoStartGameHost_d__28.MoveNext))]
public static class CoStartGameHostPatch
{
    public static bool Prefix(AmongUsClient._CoStartGameHost_d__28 __instance, ref bool __result)
    {
        if (__instance.__1__state != 0)
        {
            return true;
        }

        __instance.__1__state = -1;
        if (LobbyBehaviour.Instance)
        {
            LobbyBehaviour.Instance.Despawn();
        }

        if (ShipStatus.Instance)
        {
            __instance.__2__current = null;
            __instance.__1__state = 2;
            __result = true;
            return false;
        }

        // removed dleks check as it's always false
        var num2 = Mathf.Clamp(GameOptionsManager.Instance.CurrentGameOptions.MapId, 0, Constants.MapNames.Length - 1);
        __instance.__2__current = __instance.__4__this.ShipLoadingAsyncHandle = __instance.__4__this.ShipPrefabs[num2].InstantiateAsync();
        __instance.__1__state = 1;

        __result = true;
        return false;
    }
}
[HarmonyPatch(typeof(StringOption), nameof(StringOption.Start))]
public static class DleksClampPatch
{
    [HarmonyPostfix]
    private static void Postfix(StringOption __instance)
    {
        if (__instance.Title == StringNames.GameMapName)
        {
            // vanilla clamps this to not auto select dlekS
            __instance.Value = GameOptionsManager.Instance.CurrentGameOptions.MapId;
        }
    }
}
[HarmonyPatch]
public static class DleksMapOptionPickerPatches
{
    [HarmonyPatch(typeof(GameOptionsMapPicker), nameof(GameOptionsMapPicker.Initialize))]
    [HarmonyPriority(Priority.First)]
    [HarmonyPrefix]
    public static void LobbyOptionsDleksPatch(GameOptionsMapPicker __instance)
    {
        if (!__instance.AllMapIcons._items.Any(x => x.Name == MapNames.Dleks))
        {
            __instance.AllMapIcons.Insert((int)MapNames.Dleks, new MapIconByName
            {
                Name = MapNames.Dleks,
                MapImage = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.AprilFools.DleksBanner.png", 100f),
                MapIcon = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.AprilFools.DleksIcon.png", 100f),
                NameImage = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.AprilFools.DleksText.png", 100f),
            });
        }
    }

    [HarmonyPatch(typeof(CreateGameMapPicker), nameof(CreateGameMapPicker.Initialize))]
    [HarmonyPriority(Priority.First)]
    [HarmonyPrefix]
    public static void CreateGameDleksPatch(CreateGameMapPicker __instance)
    {
        if (!__instance.AllMapIcons._items.Any(x => x.Name == MapNames.Dleks))
        {
            __instance.AllMapIcons.Insert((int)MapNames.Dleks, new MapIconByName
            {
                Name = MapNames.Dleks,
                MapImage = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.AprilFools.DleksBanner.png", 100f),
                MapIcon = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.AprilFools.DleksIcon.png", 100f),
                NameImage = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.AprilFools.DleksText.png", 100f),
            });
        }
    }

    [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Start))]
    [HarmonyPriority(Priority.First)]
    [HarmonyPrefix]
    public static void GameManagerDleksPatch(GameStartManager __instance)
    {
        if (!__instance.AllMapIcons._items.Any(x => x.Name == MapNames.Dleks))
        {
            __instance.AllMapIcons.Insert((int)MapNames.Dleks, new MapIconByName
            {
                Name = MapNames.Dleks,
                MapIcon = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.AprilFools.DleksText.png", 150f),
            });
        }
    }

    [HarmonyPatch(typeof(FreeplayPopover), nameof(FreeplayPopover.Show))]
    [HarmonyPrefix]
    public static void AdjustFreeplayMenuPatch(FreeplayPopover __instance)
    {
        if (__instance.buttons.Any(b => b != null && b.name == "DleksButton"))
            return;

        if (__instance.buttons.Length <= 4)
            return;

        FreeplayPopoverButton fungleButton = __instance.buttons[4];

        FreeplayPopoverButton dleksButton = Object.Instantiate(fungleButton, fungleButton.transform.parent);

        dleksButton.name = "DleksButton";
        dleksButton.map = MapNames.Dleks;

        var sr = dleksButton.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.AprilFools.DleksText.png", 170f);
        }

        dleksButton.OnPressEvent = fungleButton.OnPressEvent;
        fungleButton.transform.position = new Vector3(__instance.buttons[0].transform.position.x,fungleButton.transform.position.y,fungleButton.transform.position.z);
        dleksButton.transform.position = new Vector3(__instance.buttons[1].transform.position.x,fungleButton.transform.position.y,fungleButton.transform.position.z);

        SwapPositionsTroll(fungleButton, dleksButton);
        __instance.buttons = __instance.buttons.Concat(new[] { dleksButton }).ToArray();
    }

    private static void SwapPositionsTroll(Component one, Component two)
    {
        (one.transform.position, two.transform.position) =(two.transform.position, one.transform.position);
    }
}*/