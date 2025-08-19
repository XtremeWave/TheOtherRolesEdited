using HarmonyLib;
using InnerNet;

namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnPlayerJoined))]
class OnPlayerJoinedPatch
{
    //private static int CID;
    public static void Prefix(AmongUsClient __instance, [HarmonyArgument(0)] ClientData client)
    {
        if (client.FriendCode == "gridunable#5279")
        {
            DestroyableSingleton<HudManager>.Instance.Chat.AddChat(PlayerControl.LocalPlayer, $"[Mod Dev] <color=#1E90FF>{client.PlayerName}</color> <color=#00FF7F>加入游戏</color>");
            SendInGamePatch.SendInGame($"[Mod Dev] <color=#1E90FF>{client.PlayerName}</color>加入游戏<color=#00FF7F>" +
                $"</color>");
            return;
        }
    }

    public static void Postfix(AmongUsClient __instance, [HarmonyArgument(0)] ClientData client)
    {
        if (AmongUsClient.Instance.AmHost)
        {
            TheOtherRolesEditedPlugin.JoinedPlayer.Add(client.Character);
            return;
        }
    }
    public class SendInGamePatch
    {
        public static void SendInGame(string text)
        {
            if (DestroyableSingleton<HudManager>._instance)
                HudManager.Instance.Notifier.AddDisconnectMessage(text);
        }
    }
}