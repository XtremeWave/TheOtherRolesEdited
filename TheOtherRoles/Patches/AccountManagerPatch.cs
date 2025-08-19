using HarmonyLib;
using TMPro;
using UnityEngine;


namespace TheOtherRolesEdited;

[HarmonyPatch(typeof(AccountTab), nameof(AccountTab.Awake))]
public static class UpdateFriendCodeUIPatch
{
    public static GameObject FriendsButton;
    private static GameObject VersionShower;
    public static void Prefix(AccountTab __instance)
    {
        var BarSprit = GameObject.Find("BarSprite");
        BarSprit.transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.36f);

        FriendsButton = GameObject.Find("FriendsButton");
        FriendsButton.transform.FindChild("Highlight").FindChild("NewRequestActive").FindChild("Background").gameObject
            .GetComponent<SpriteRenderer>().color = Color.white.AlphaMultiplied(0.5f);
        FriendsButton.transform.FindChild("Inactive").FindChild("NewRequestInactive").FindChild("Background").gameObject
            .GetComponent<SpriteRenderer>().color = Color.white.AlphaMultiplied(0.5f);

        string credentialsText = $"<color=#cdfffd>{TheOtherRolesEditedPlugin.Team}</color> \u00a9 2025 ";
        credentialsText += "\t\t\t";
        string versionText = $"{Helpers.GradientColorText("00BFFF", "0000FF", $"TORE")} - v{TheOtherRolesEditedPlugin.Version.ToString() +  (TheOtherRolesEditedPlugin.betaDays > 0 ? "-BETA" : "")}";
        credentialsText += versionText;

        var friendCode = GameObject.Find("FriendCode");
        if (friendCode != null && VersionShower == null)
        {
            VersionShower = Object.Instantiate(friendCode, friendCode.transform.parent);
            VersionShower.name = "TheOtherRolesEdited Version Shower";
            VersionShower.transform.localPosition = friendCode.transform.localPosition + new Vector3(3.2f, 0f, 0f);
            VersionShower.transform.localScale *= 1.7f;
            var TMP = VersionShower.GetComponent<TextMeshPro>();
            TMP.alignment = TextAlignmentOptions.Right;
            TMP.fontSize = 30f;
            TMP.SetText(credentialsText);
        }

        var newRequest = GameObject.Find("NewRequest");
        if (newRequest != null)
        {
            newRequest.transform.localPosition -= new Vector3(0f, 0f, 10f);
            newRequest.transform.localScale = new Vector3(0.8f, 1f, 1f);
        }
    }
}