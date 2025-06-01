using HarmonyLib;

namespace TheOtherRolesEdited.Modules;

[HarmonyPatch]
[HarmonyPriority(Priority.First)]
public class Debugger
{
    public static bool DebugMode => CustomOptionHolder.debugMode.getBool();
    public static bool DisableGameEnd => DebugMode && CustomOptionHolder.disableGameEnd.getBool();

    [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Update))]
    public static class CountdownPatch
    {
        public static void Prefix(GameStartManager __instance)
        {
            if (DebugMode) __instance.countDownTimer = 0;
        }
    }


    [HarmonyPatch(typeof(LogicGameFlow), nameof(LogicGameFlow.CheckEndCriteria))]
    [HarmonyPatch(typeof(LogicGameFlowHnS), nameof(LogicGameFlowHnS.CheckEndCriteria))]
    [HarmonyPatch(typeof(LogicGameFlowNormal), nameof(LogicGameFlowNormal.CheckEndCriteria))]
    public static bool Prefix()
    {
        return !DisableGameEnd;
    }

    [HarmonyPatch(typeof(EndGameNavigation), nameof(EndGameNavigation.ShowDefaultNavigation))]
    internal static class AutoPlayAgainPatch
    {

        public static void Postfix(EndGameNavigation __instance)
        {
            if (!DebugMode) return;
            if (AmongUsClient.Instance.AmHost) return;
            __instance.NextGame();
        }
    }
}
