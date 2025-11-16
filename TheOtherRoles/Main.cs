global using Il2CppInterop.Runtime;
global using Il2CppInterop.Runtime.Attributes;
global using Il2CppInterop.Runtime.InteropTypes;
global using Il2CppInterop.Runtime.InteropTypes.Arrays;
global using Il2CppInterop.Runtime.Injection;

using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Hazel;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using TheOtherRolesEdited.Modules;
using TheOtherRolesEdited.Utilities;
using Il2CppSystem.Security.Cryptography;
using Il2CppSystem.Text;
using Reactor.Networking.Attributes;
using AmongUs.Data;
using TheOtherRolesEdited.Modules.CustomHats;
using static TheOtherRolesEdited.Modules.ModUpdater;
using AmongUs.Data.Player;
using AmongUs.GameOptions;
using Reactor.Patches;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;
using System.Threading.Tasks;

namespace TheOtherRolesEdited
{
    [BepInPlugin(Id, "The Other Roles Edited", VersionString)]
    [BepInDependency(SubmergedCompatibility.SUBMERGED_GUID, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInProcess("Among Us.exe")]
    [ReactorModFlags(Reactor.Networking.ModFlags.RequireOnAllClients)]

    public class TheOtherRolesEditedPlugin : BasePlugin
    {
        public const string Id = "TheOtherRolesEdited";
        public const string Name = "TORE";
        public const string VersionString = "1.3.1";
        public const string Dev = "farewell";
        public const string ModColor = "#FF0000";
        public const string Team = "XtremeWave ";
        public static bool isChatCommand = false;
        public static bool VisibleTasksCount = false;
        public static uint betaDays = 0;  // amount of days for the build to be usable (0 for infinite!)

        public static Version Version = Version.Parse(VersionString);
        internal static BepInEx.Logging.ManualLogSource Logger;
        public Harmony Harmony { get; } = new Harmony(Id);
        public static TheOtherRolesEditedPlugin Instance;

        public static int optionsPage = 2;
        public static ConfigEntry<string> DebugMode { get; private set; }
        public static ConfigEntry<bool> GhostsSeeInformation { get; set; }
        public static ConfigEntry<bool> GhostsSeeRoles { get; set; }
        public static ConfigEntry<bool> GhostsSeeModifier { get; set; }
        public static ConfigEntry<bool> GhostsSeeVotes { get; set; }
        public static ConfigEntry<bool> ShowRoleSummary { get; set; }
        public static ConfigEntry<bool> ShowLighterDarker { get; set; }
        public static ConfigEntry<bool> EnableSoundEffects { get; set; }
        public static ConfigEntry<bool> EnableHorseMode { get; set; }
        public static ConfigEntry<bool> ShowVentsOnMap { get; set; }
        public static ConfigEntry<bool> ShowChatNotifications { get; set; }
        public static ConfigEntry<string> Ip { get; set; }
        public static ConfigEntry<ushort> Port { get; set; }
        public static ConfigEntry<string> ShowPopUpVersion { get; set; }
        public static int ModUsageCount { get; set; } = 0;
        public static ConfigEntry<bool> ToggleCursor { get; set; }
        public static List<PlayerControl> JoinedPlayer = new();
        public static Sprite ModStamp;
        public static IRegionInfo[] defaultRegions;
        // This is part of the Mini.RegionInstaller, Licensed under GPLv3
        // file="RegionInstallPlugin.cs" company="miniduikboot">
        private async void SendModUsageRequest()
        {
            try
            {
                string url = "https://player.amongusclub.cn/api/modusage/register?modName=TheOtherRolesEdited";
                var request = UnityWebRequest.Get(url);

                var operation = request.SendWebRequest();

                while (!operation.isDone)
                    await Task.Delay(100);

                if (request.result == UnityWebRequest.Result.Success)
                {
                    if (int.TryParse(request.downloadHandler.text, out int count))
                    {
                        ModUsageCount = count;
                        Logger.LogInfo($"Mod usage count: {count}");
                    }
                }
                else
                {
                    Logger.LogError($"Failed to register mod: {request.error}");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error sending mod usage request: {ex.Message}");
            }
        }
        public static void UpdateRegions()
        {
            ServerManager serverManager = FastDestroyableSingleton<ServerManager>.Instance;
            var regions = new IRegionInfo[]
            {
                new StaticHttpRegionInfo("<color=#49F0FC>方块服</color> <color=#8732FF>[宿迁]</color>", StringNames.NoTranslation, "https://player.amongusclub.cn", new Il2CppReferenceArray<ServerInfo>(new ServerInfo[1] { new ServerInfo("<color=#49F0FC>方块服</color> <color=#8732FF>[宿迁]</color>", "https://player.amongusclub.cn", 443, false) })).CastFast<IRegionInfo>(),
                new StaticHttpRegionInfo("<color=#49F0FC>方块服</color> <color=#00bfff>[香港]</color>", StringNames.NoTranslation, "https://auhk.amongusclub.cn", new Il2CppReferenceArray<ServerInfo>(new ServerInfo[1] { new ServerInfo("<color=#49F0FC>方块服</color> <color=#00bfff>[香港]</color>", "https://auhk.amongusclub.cn", 443, false) })).CastFast<IRegionInfo>(),
                new StaticHttpRegionInfo("<color=#cdfffd>XtremeWave服</color> <color=#00bfff>[香港]</color>", StringNames.NoTranslation, "https://imp.xtreme.net.cn", new Il2CppReferenceArray<ServerInfo>(new ServerInfo[1] { new ServerInfo("<color=#cdfffd>XtremeWave服</color> <color=#00bfff>[香港]</color>", "https://imp.xtreme.net.cn", 443, false) })).CastFast<IRegionInfo>(),
            };
            IRegionInfo currentRegion = serverManager.CurrentRegion;
            Logger.LogInfo($"Adding {regions.Length} regions");
            foreach (IRegionInfo region in regions)
            {
                if (region == null)
                    Logger.LogError("Could not add region");
                else
                {
                    if (currentRegion != null && region.Name.Equals(currentRegion.Name, StringComparison.OrdinalIgnoreCase))
                        currentRegion = region;
                    serverManager.AddOrUpdateRegion(region);
                }
            }

            // AU remembers the previous region that was set, so we need to restore it
            if (currentRegion != null)
            {
                Logger.LogDebug("Resetting previous region");
                serverManager.SetRegion(currentRegion);
            }
        }
        public override void Load()
        {
            SendModUsageRequest();
            Logger = Log;
            Instance = this;
            ReactorVersionShower.TextUpdated += text =>
            {
                text.text = "";
            };
#if PC
            if (BepInExUpdater.UpdateRequired)
            {
                AddComponent<BepInExUpdater>();
                return;
            }

            _ = Helpers.checkBeta(); // Exit if running an expired beta
            _ = Patches.CredentialsPatch.MOTD.loadMOTDs();

#endif
            DebugMode = Config.Bind("Custom", "Enable Debug Mode", "false");
            GhostsSeeInformation = Config.Bind("Custom", "Ghosts See Remaining Tasks", true);
            GhostsSeeRoles = Config.Bind("Custom", "Ghosts See Roles", true);
            GhostsSeeModifier = Config.Bind("Custom", "Ghosts See Modifier", true);
            GhostsSeeVotes = Config.Bind("Custom", "Ghosts See Votes", true);
            ShowRoleSummary = Config.Bind("Custom", "Show Role Summary", true);
            ShowLighterDarker = Config.Bind("Custom", "Show Lighter / Darker", true);
            EnableSoundEffects = Config.Bind("Custom", "Enable Sound Effects", true);
            EnableHorseMode = Config.Bind("Custom", "Enable Horse Mode", false);
            ShowPopUpVersion = Config.Bind("Custom", "Show PopUp", "0");
            ShowVentsOnMap = Config.Bind("Custom", "Show vent positions on minimap", false);
            ShowChatNotifications = Config.Bind("Custom", "Show Chat Notifications", true);
            ToggleCursor = Config.Bind("Custom", "Better Cursor", true);

            Ip = Config.Bind("Custom", "Custom Server IP", "127.0.0.1");
            Port = Config.Bind("Custom", "Custom Server Port", (ushort)22023);
            defaultRegions = ServerManager.DefaultRegions;
            // Removes vanilla Servers
            ServerManager.DefaultRegions = new Il2CppReferenceArray<IRegionInfo>(new IRegionInfo[0]);

            Harmony.PatchAll(typeof(LoadPatch));

            // Reactor Credits (future use?)
            // Reactor.Utilities.ReactorCredits.Register("TheOtherRolesEdited", VersionString, betaDays > 0, location => location == Reactor.Utilities.ReactorCredits.Location.PingTracker);

            DebugMode = Config.Bind("Custom", "Enable Debug Mode", "false");
        }
    }
    internal class ModOption
    {
        public static int NumImpostors => GameOptionsManager.Instance.currentNormalGameOptions.NumImpostors;
        public static bool DebugMode => CustomOptionHolder.debugMode.getBool();
        public static bool HostName => CustomOptionHolder.HostName.getBool();

        public static bool DisableGameEnd => DebugMode && CustomOptionHolder.disableGameEnd.getBool();
    }

    public static partial class XtremeGameData
    {
        public static class GameStates
        {
            public static string GetRegionName(IRegionInfo region = null)
            {
                region ??= ServerManager.Instance.CurrentRegion;

                string name = region.Name;

                if (AmongUsClient.Instance.NetworkMode != NetworkModes.OnlineGame)
                {
                    name = "本地";
                    return name;
                }

                if (region.PingServer.EndsWith("among.us", StringComparison.Ordinal))
                {
                    // Official server
                    if (name == "North America") name = "北美服";
                    else if (name == "Europe") name = "欧服";
                    else if (name == "Asia") name = "亚服";

                    return name;
                }

                var Ip = region.Servers.FirstOrDefault()?.Ip ?? string.Empty;

                if (Ip.Contains("aumods.us", StringComparison.Ordinal)
                    || Ip.Contains("duikbo.at", StringComparison.Ordinal))
                {
                    // Official Modded Server
                    if (Ip.Contains("au-eu")) name = "Modded EU(EU)";
                    else if (Ip.Contains("au-as")) name = "Modded ASIA(MAS)";
                    else if (Ip.Contains("www.")) name = "Modded NA(MNA)";

                    return name;
                }
                return name;
            }

        }
    }
    // Deactivate bans, since I always leave my local testing game and ban myself
    [HarmonyPatch(typeof(PlayerBanData), nameof(PlayerBanData.IsBanned), MethodType.Getter)]
    public static class IsBannedPatch
    {
        public static void Postfix(out bool __result)
        {
            __result = false;
        }
    }
    [HarmonyPatch(typeof(ChatController), nameof(ChatController.Awake))]
    public static class ChatControllerAwakePatch
    {
        private static void Prefix()
        {
            if (!EOSManager.Instance.isKWSMinor)
            {
                DataManager.Settings.Multiplayer.ChatMode = InnerNet.QuickChatModes.FreeChatOrQuickChat;
            }
        }
    }

    // Debugging tools
    [HarmonyPatch(typeof(KeyboardJoystick), nameof(KeyboardJoystick.Update))]
    public static class DebugManager
    {
        private static readonly string passwordHash = "d1f51dfdfd8d38027fd2ca9dfeb299399b5bdee58e6c0b3b5e9a45cd4e502848";
        private static readonly System.Random random = new System.Random((int)DateTime.Now.Ticks);
        private static List<PlayerControl> bots = new List<PlayerControl>();

        public static void Postfix(KeyboardJoystick __instance)
        {
            // Check if debug mode is active.
            StringBuilder builder = new StringBuilder();
            SHA256 sha = SHA256Managed.Create();
            Byte[] hashed = sha.ComputeHash(Encoding.UTF8.GetBytes(TheOtherRolesEditedPlugin.DebugMode.Value));
            foreach (var b in hashed)
            {
                builder.Append(b.ToString("x2"));
            }
            string enteredHash = builder.ToString();
            if (enteredHash != passwordHash) return;


            // Spawn dummys
            /*if (Input.GetKeyDown(KeyCode.F)) {
                var playerControl = UnityEngine.Object.Instantiate(AmongUsClient.Instance.PlayerPrefab);
                var i = playerControl.PlayerId = (byte) GameData.Instance.GetAvailableId();

                bots.Add(playerControl);
                GameData.Instance.AddPlayer(playerControl, new InnerNet.ClientData(0));
                AmongUsClient.Instance.Spawn(playerControl, -2, InnerNet.SpawnFlags.None);
                
                playerControl.transform.position = PlayerControl.LocalPlayer.transform.position;
                playerControl.GetComponent<DummyBehaviour>().enabled = true;
                playerControl.NetTransform.enabled = false;
                playerControl.SetName(RandomString(10));
                playerControl.SetColor((byte) random.Next(Palette.PlayerColors.Length));
                playerControl.Data.RpcSetTasks(new byte[0]);
            }*/

            // Terminate round
            if (Input.GetKeyDown(KeyCode.L))
            {
                MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.ForceEnd, Hazel.SendOption.Reliable, -1);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                RPCProcedure.forceEnd();
            }
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
