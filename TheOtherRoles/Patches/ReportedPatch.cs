using HarmonyLib;

namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.CoIntro))]
internal class ShipStatus_CoStartMeeting
{
    static void Postfix(MeetingHud __instance, NetworkedPlayerInfo reporter, NetworkedPlayerInfo reportedBody, Il2CppReferenceArray<NetworkedPlayerInfo> deadBodies)
    {
        if (MeetingHud.Instance != null && reportedBody != null)
        {
            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
            {
                if (player.TargetPlayerId == reportedBody.PlayerId)
                {
                    player.Megaphone.enabled = true;
                    player.Megaphone.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.VoteReportedButton.png", 75f);
                }
            }
        }
    }
}