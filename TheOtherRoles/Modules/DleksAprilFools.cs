using HarmonyLib;
using Reactor.Localization.Utilities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using TheOtherRolesEdited.Modules;

namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(AmongUsClient._CoStartGameHost_d__28),"MoveNext")]
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
    public static StringNames DleksName => CustomStringName.CreateAndRegister("dlekS");
    public static StringNames DleksTooltip => CustomStringName.CreateAndRegister(ModTranslation.getString("DleksAprilFools"));

    [HarmonyPatch(typeof(GameOptionsMapPicker), nameof(GameOptionsMapPicker.SetupMapButtons))]
    [HarmonyPrefix]
    public static void AddToGameOptionsUI(GameOptionsMapPicker __instance)
    {
        if (__instance.AllMapIcons.ToArray().Any(x => x.Name == MapNames.Dleks))
        {
            return;
        }

        __instance.AllMapIcons.Insert((int)MapNames.Dleks, new MapIconByName
        {
            Name = MapNames.Dleks,
            MapImage = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.AprilFools.DleksBanner.png", 100f),
            MapIcon = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.AprilFools.DleksIcon.png", 100f),
            NameImage = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.AprilFools.DleksText.png", 100f),
        });
    }

    [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Start))]
    [HarmonyPriority(Priority.First)]
    [HarmonyPrefix]
    public static void GameManagerDleksPatch(GameStartManager __instance)
    {
        if (__instance.AllMapIcons.ToArray().Any(x => x.Name == MapNames.Dleks))
        {
            return;
        }

        __instance.AllMapIcons.Insert((int)MapNames.Dleks, new MapIconByName
        {
            Name = MapNames.Dleks,
            MapIcon = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.AprilFools.DleksText.png", 150f),
        });
    }

    [HarmonyPriority(Priority.VeryLow)]
    [HarmonyPatch(typeof(MapSelectionGameSetting), nameof(MapSelectionGameSetting.GetValueString))]
    [HarmonyPrefix]
    public static void AddToActualOptions(MapSelectionGameSetting __instance)
    {
        if (__instance.Values.All(x => (int)x != (int)DleksName))
        {
            var list = __instance.Values.ToList();
            list.Insert((int)MapNames.Dleks, DleksName);
            __instance.Values = list.ToArray();
        }
    }

    [HarmonyPatch(typeof(CreateGameOptions), nameof(CreateGameOptions.MapChanged))]
    [HarmonyPrefix]
    public static bool MapChangedPrefix(CreateGameOptions __instance, OptionBehaviour behaviour)
    {
        if (__instance.mapPicker.GetSelectedID() is (int)MapNames.Dleks)
        {
            __instance.mapBanner.flipX = false;
            __instance.rendererBGCrewmates.sprite = __instance.bgCrewmates[0];
            __instance.mapBanner.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.AprilFools.DleksText.png", 100f);
            __instance.TurnOffCrewmates();
            __instance.currentCrewSprites = __instance.skeldCrewSprites;
            __instance.SetCrewmateGraphic(__instance.capacityOption.Value - 1f);
            return false;
        }

        return true;
    }

    [HarmonyPatch(typeof(CreateGameOptions), nameof(CreateGameOptions.Start))]
    [HarmonyPrefix]
    public static void SetupMapBackground(CreateGameOptions __instance)
    {
        if (__instance.currentCrewSprites == null)
        {
            __instance.mapBanner.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.AprilFools.DleksText.png", 100f);
        }
        __instance.currentCrewSprites ??= __instance.skeldCrewSprites;
        __instance.mapTooltips[3] = DleksTooltip;
    }

    // __instance method is patched to fix issues on Epic Games
    [HarmonyPatch(typeof(FreeplayPopover), nameof(FreeplayPopover.OnMapButtonPressed))]
    [HarmonyPrefix]
    public static bool ButtonPressPatch(FreeplayPopover __instance, FreeplayPopoverButton button)
    {
        __instance.background.GetComponent<PassiveButton>().OnClick
            .RemoveListener((System.Action)(() => __instance.Close()));
        FreeplayPopoverButton[] array = __instance.buttons;
        for (int i = 0; i < array.Length; i++)
        {
            array[i].Button.enabled = false;
        }

        AmongUsClient.Instance.TutorialMapId = (int)button.Map;
        __instance.hostGameButton.OnClick();
        return false;
    }

    private static FreeplayPopover _lastInstance;

    [HarmonyPatch(typeof(FreeplayPopover), nameof(FreeplayPopover.Show))]
    [HarmonyPriority(Priority.First)]
    [HarmonyPrefix]
    public static void AdjustFreeplayMenuPatch(FreeplayPopover __instance)
    {
        if (_lastInstance == __instance) return;
        _lastInstance = __instance;

        FreeplayPopoverButton fungleButton = __instance.buttons[4];
        FreeplayPopoverButton dleksButton = UnityEngine.Object.Instantiate(fungleButton, fungleButton.transform.parent);

        dleksButton.name = "DleksButton";
        dleksButton.map = MapNames.Dleks;
        dleksButton.GetComponent<SpriteRenderer>().sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.AprilFools.DleksText.png", 170f);
        dleksButton.OnPressEvent = fungleButton.OnPressEvent;

        dleksButton.transform.position = new Vector3(fungleButton.transform.position.x, __instance.buttons[0].transform.position.y + 0.7f, fungleButton.transform.position.z);

        __instance.buttons = new List<FreeplayPopoverButton>(__instance.buttons) { dleksButton }.ToArray();
    }
}
