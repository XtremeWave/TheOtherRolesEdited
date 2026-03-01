using System.Linq;
using System;
using System.Collections.Generic;

using static TheOtherRolesEdited.TheOtherRolesEdited;
using UnityEngine;
using TheOtherRolesEdited.Utilities;
using TheOtherRolesEdited.CustomGameModes;
using System.Threading.Tasks;
using System.Net.Http;
using TheOtherRolesEdited.Players;
using TheOtherRolesEdited.Modules;

namespace TheOtherRolesEdited
{
    public class RoleInfo {
        public Color color;
        public string name;
        public string introDescription;
        public string shortDescription;
        public RoleId roleId;
        public bool isNeutral;
        public bool isModifier;
        public bool isCrewmate;
        public bool isImpostor => color == Palette.ImpostorRed && !(roleId == RoleId.Spy);
        public static Dictionary<RoleId, RoleInfo> roleInfoById = new();
        public RoleInfo(string name, Color color, string introDescription, string shortDescription, RoleId roleId, bool isNeutral = false, bool isModifier = false, bool isCrewmate = false) {
            this.color = color;
            this.name = name;
            this.introDescription = introDescription;
            this.shortDescription = shortDescription;
            this.roleId = roleId;
            this.isNeutral = isNeutral;
            this.isCrewmate = isCrewmate;
            this.isModifier = isModifier;
            roleInfoById.TryAdd(roleId, this);
        }

        public static RoleInfo jester = new RoleInfo(ModTranslation.getString("Jester"), Jester.color, ModTranslation.getString("JesterDescription1"), ModTranslation.getString("JesterDescription2"), RoleId.Jester, true);
        public static RoleInfo mayor = new RoleInfo(ModTranslation.getString("Mayor"), Mayor.color, ModTranslation.getString("MayorDescription1"), ModTranslation.getString("MayorDescription2"), RoleId.Mayor);
        public static RoleInfo portalmaker = new RoleInfo(ModTranslation.getString("Portalmaker"), Portalmaker.color, ModTranslation.getString("PortalmakerDescription1"), ModTranslation.getString("PortalmakerDescription2"), RoleId.Portalmaker);
        public static RoleInfo engineer = new RoleInfo(ModTranslation.getString("Engineer"), Engineer.color, ModTranslation.getString("EngineerDescription1"), ModTranslation.getString("EngineerDescription2"), RoleId.Engineer);
        public static RoleInfo sheriff = new RoleInfo(ModTranslation.getString("Sheriff"), Sheriff.color, ModTranslation.getString("SheriffDescription1"), ModTranslation.getString("SheriffDescription2"), RoleId.Sheriff);
        public static RoleInfo deputy = new RoleInfo(ModTranslation.getString("Deputy"), Sheriff.color, ModTranslation.getString("DeputyDescription1"), ModTranslation.getString("DeputyDescription2"), RoleId.Deputy);
        public static RoleInfo lighter = new RoleInfo(ModTranslation.getString("Lighter"), Lighter.color, ModTranslation.getString("LighterDescription1"), ModTranslation.getString("LighterDescription2"), RoleId.Lighter);
        public static RoleInfo godfather = new RoleInfo(ModTranslation.getString("Godfather"), Godfather.color, ModTranslation.getString("GodfatherDescription1"), ModTranslation.getString("GodfatherDescription2"), RoleId.Godfather);
        public static RoleInfo mafioso = new RoleInfo(ModTranslation.getString("Mafioso"), Mafioso.color, ModTranslation.getString("MafiosoDescription1"), ModTranslation.getString("MafiosoDescription2"), RoleId.Mafioso);
        public static RoleInfo janitor = new RoleInfo(ModTranslation.getString("Janitor"), Janitor.color, ModTranslation.getString("JanitorDescription1"), ModTranslation.getString("JanitorDescription2"), RoleId.Janitor);
        public static RoleInfo morphling = new RoleInfo(ModTranslation.getString("Morphling"), Morphling.color, ModTranslation.getString("MorphlingDescription1"), ModTranslation.getString("MorphlingDescription2"), RoleId.Morphling);
        public static RoleInfo camouflager = new RoleInfo(ModTranslation.getString("Camouflager"), Camouflager.color, ModTranslation.getString("CamouflagerDescription1"), ModTranslation.getString("CamouflagerDescription2"), RoleId.Camouflager);
        public static RoleInfo vampire = new RoleInfo(ModTranslation.getString("Vampire"), Vampire.color, ModTranslation.getString("VampireDescription1"), ModTranslation.getString("VampireDescription2"), RoleId.Vampire);
        public static RoleInfo eraser = new RoleInfo(ModTranslation.getString("Eraser"), Eraser.color, ModTranslation.getString("EraserDescription1"), ModTranslation.getString("EraserDescription2"), RoleId.Eraser);
        public static RoleInfo trickster = new RoleInfo(ModTranslation.getString("Trickster"), Trickster.color, ModTranslation.getString("TricksterDescription1"), ModTranslation.getString("TricksterDescription2"), RoleId.Trickster);
        public static RoleInfo cleaner = new RoleInfo(ModTranslation.getString("Cleaner"), Cleaner.color, ModTranslation.getString("CleanerDescription1"), ModTranslation.getString("CleanerDescription2"), RoleId.Cleaner);
        public static RoleInfo blackmailer = new RoleInfo(ModTranslation.getString("Blackmailer"), Blackmailer.color, ModTranslation.getString("BlackmailerDescription1"), ModTranslation.getString("BlackmailerDescription2"), RoleId.Blackmailer);
        public static RoleInfo miner = new RoleInfo(ModTranslation.getString("Miner"), Miner.color, ModTranslation.getString("MinerDescription1"), ModTranslation.getString("MinerDescription2"), RoleId.Miner);
        public static RoleInfo undertaker = new RoleInfo(ModTranslation.getString("Undertaker"), Undertaker.color, ModTranslation.getString("UndertakerDescription1"), ModTranslation.getString("UndertakerDescription2"), RoleId.Undertaker);
        public static RoleInfo warlock = new RoleInfo(ModTranslation.getString("Warlock"), Warlock.color, ModTranslation.getString("WarlockDescription1"), ModTranslation.getString("WarlockDescription2"), RoleId.Warlock);
        public static RoleInfo bountyHunter = new RoleInfo(ModTranslation.getString("BountyHunter"), BountyHunter.color, ModTranslation.getString("BountyHunterDescription1"), ModTranslation.getString("BountyHunterDescription2"), RoleId.BountyHunter);
        public static RoleInfo detective = new RoleInfo(ModTranslation.getString("Detective"), Detective.color, ModTranslation.getString("DetectiveDescription1"), ModTranslation.getString("DetectiveDescription2"), RoleId.Detective);
        public static RoleInfo timeMaster = new RoleInfo(ModTranslation.getString("TimeMaster"), TimeMaster.color, ModTranslation.getString("TimeMasterDescription1"), ModTranslation.getString("TimeMasterDescription2"), RoleId.TimeMaster);
        public static RoleInfo medic = new RoleInfo(ModTranslation.getString("Medic"), Medic.color, ModTranslation.getString("MedicDescription1"), ModTranslation.getString("MedicDescription2"), RoleId.Medic);
        public static RoleInfo swapper = new RoleInfo(ModTranslation.getString("Swapper"), Swapper.color, ModTranslation.getString("SwapperDescription1"), ModTranslation.getString("SwapperDescription2"), RoleId.Swapper);
        public static RoleInfo seer = new RoleInfo(ModTranslation.getString("Seer"), Seer.color, ModTranslation.getString("SeerDescription1"), ModTranslation.getString("SeerDescription2"), RoleId.Seer);
        public static RoleInfo hacker = new RoleInfo(ModTranslation.getString("Hacker"), Hacker.color, ModTranslation.getString("HackerDescription1"), ModTranslation.getString("HackerDescription2"), RoleId.Hacker);
        public static RoleInfo tracker = new RoleInfo(ModTranslation.getString("Tracker"), Tracker.color, ModTranslation.getString("TrackerDescription1"), ModTranslation.getString("TrackerDescription2"), RoleId.Tracker);
        public static RoleInfo snitch = new RoleInfo(ModTranslation.getString("Snitch"), Snitch.color, ModTranslation.getString("SnitchDescription1"), ModTranslation.getString("SnitchDescription2"), RoleId.Snitch);
        public static RoleInfo jackal = new RoleInfo(ModTranslation.getString("Jackal"), Jackal.color, ModTranslation.getString("JackalDescription1"), ModTranslation.getString("JackalDescription2"), RoleId.Jackal, true);
        public static RoleInfo sidekick = new RoleInfo(ModTranslation.getString("Sidekick"), Sidekick.color, ModTranslation.getString("SidekickDescription1"), ModTranslation.getString("SidekickDescription2"), RoleId.Sidekick, true);
        public static RoleInfo spy = new RoleInfo(ModTranslation.getString("Spy"), Spy.color, ModTranslation.getString("SpyDescription1"), ModTranslation.getString("SpyDescription2"), RoleId.Spy);
        public static RoleInfo securityGuard = new RoleInfo(ModTranslation.getString("SecurityGuard"), SecurityGuard.color, ModTranslation.getString("SecurityGuardDescription1"), ModTranslation.getString("SecurityGuardDescription2"), RoleId.SecurityGuard);
        public static RoleInfo paranoia = new RoleInfo(ModTranslation.getString("Paranoia"), Paranoia.color, ModTranslation.getString("ParanoiaDescription1"), ModTranslation.getString("ParanoiaDescription2"), RoleId.Paranoia);
        public static RoleInfo veteran = new RoleInfo(ModTranslation.getString("Veteran"), Veteran.color, ModTranslation.getString("VeteranDescription1"), ModTranslation.getString("VeteranDescription2"), RoleId.Veteran);
        public static RoleInfo arsonist = new RoleInfo(ModTranslation.getString("Arsonist"), Arsonist.color, ModTranslation.getString("ArsonistDescription1"), ModTranslation.getString("ArsonistDescription2"), RoleId.Arsonist, true);
        public static RoleInfo plagueDoctor = new RoleInfo(ModTranslation.getString("PlagueDoctor"), PlagueDoctor.color, ModTranslation.getString("PlagueDoctorDescription1"), ModTranslation.getString("PlagueDoctorDescription1"), RoleId.PlagueDoctor,true);
        public static RoleInfo goodGuesser = new RoleInfo(ModTranslation.getString("Vigilante"), Guesser.color, ModTranslation.getString("VigilanteDescription1"), ModTranslation.getString("VigilanteDescription2"), RoleId.NiceGuesser);
        public static RoleInfo badGuesser = new RoleInfo(ModTranslation.getString("Assassin"), Palette.ImpostorRed, ModTranslation.getString("AssassinDescription1"), ModTranslation.getString("AssassinDescription2"), RoleId.EvilGuesser);
        public static RoleInfo vulture = new RoleInfo(ModTranslation.getString("Vulture"), Vulture.color, ModTranslation.getString("VultureDescription1"), ModTranslation.getString("VultureDescription2"), RoleId.Vulture, true);
        public static RoleInfo medium = new RoleInfo(ModTranslation.getString("Medium"), Medium.color, ModTranslation.getString("MediumDescription1"), ModTranslation.getString("MediumDescription2"), RoleId.Medium);
        public static RoleInfo trapper = new RoleInfo(ModTranslation.getString("Trapper"), Trapper.color, ModTranslation.getString("TrapperDescription1"), ModTranslation.getString("TrapperDescription2"), RoleId.Trapper);
        public static RoleInfo lawyer = new RoleInfo(ModTranslation.getString("Lawyer"), Lawyer.color, ModTranslation.getString("LawyerDescription1"), ModTranslation.getString("LawyerDescription2"), RoleId.Lawyer, true);
        public static RoleInfo prosecutor = new RoleInfo(ModTranslation.getString("Prosecutor"), Prosecutor.color, ModTranslation.getString("ProsecutorDescription1"), ModTranslation.getString("ProsecutorDescription2"), RoleId.Prosecutor, true);
        public static RoleInfo pursuer = new RoleInfo(ModTranslation.getString("Pursuer"), Pursuer.color, ModTranslation.getString("PursuerDescription1"), ModTranslation.getString("PursuerDescription2"), RoleId.Pursuer);
        public static RoleInfo impostor = new RoleInfo(ModTranslation.getString("Impostor"), Palette.ImpostorRed, ModTranslation.getString("ImpostorDescription1"), ModTranslation.getString("ImpostorDescription2"), RoleId.Impostor);
        public static RoleInfo crewmate = new RoleInfo(ModTranslation.getString("Crewmate"), Color.white, ModTranslation.getString("CrewmateDescription1"), ModTranslation.getString("CrewmateDescription2"), RoleId.Crewmate);
        public static RoleInfo witch = new RoleInfo(ModTranslation.getString("Witch"), Witch.color, ModTranslation.getString("WitchDescription1"), ModTranslation.getString("WitchDescription2"), RoleId.Witch);
        public static RoleInfo ninja = new RoleInfo(ModTranslation.getString("Ninja"), Ninja.color, ModTranslation.getString("NinjaDescription1"), ModTranslation.getString("NinjaDescription2"), RoleId.Ninja);
        public static RoleInfo thief = new RoleInfo(ModTranslation.getString("Thief"), Thief.color, ModTranslation.getString("ThiefDescription1"), ModTranslation.getString("ThiefDescription2"), RoleId.Thief, true);
        public static RoleInfo bomber = new RoleInfo(ModTranslation.getString("Bomber"), Bomber.color, ModTranslation.getString("BomberDescription1"), ModTranslation.getString("BomberDescription2"), RoleId.Bomber);
        public static RoleInfo yoyo = new RoleInfo(ModTranslation.getString("YoYo"), Yoyo.color, ModTranslation.getString("YoYoDescription1"), ModTranslation.getString("YoYoDescription2"), RoleId.Yoyo);
        public static RoleInfo hunter = new RoleInfo(ModTranslation.getString("Hunter"), Palette.ImpostorRed, ModTranslation.getString("HunterDescription1"), ModTranslation.getString("HunterDescription2"), RoleId.Impostor);
        public static RoleInfo hunted = new RoleInfo(ModTranslation.getString("Hunted"), Color.white, ModTranslation.getString("HuntedDescription1"), ModTranslation.getString("HuntedDescription2"), RoleId.Crewmate);
        public static RoleInfo prop = new RoleInfo(ModTranslation.getString("Prop"), Color.white, ModTranslation.getString("PropDescription1"), ModTranslation.getString("PropDescription2"), RoleId.Crewmate);

        // Modifier
        public static RoleInfo bloody = new RoleInfo(ModTranslation.getString("Bloody"), Bloody.color, ModTranslation.getString("BloodyDescription1"), ModTranslation.getString("BloodyDescription2"), RoleId.Bloody, false, true);
        public static RoleInfo antiTeleport = new RoleInfo(ModTranslation.getString("AntiTeleport"), AntiTeleport.color, ModTranslation.getString("AntiTeleportDescription1"), ModTranslation.getString("AntiTeleportDescription2"), RoleId.AntiTeleport, false, true);
        public static RoleInfo tiebreaker = new RoleInfo(ModTranslation.getString("Tiebreaker"), Tiebreaker.color, ModTranslation.getString("TiebreakerDescription1"), ModTranslation.getString("TiebreakerDescription2"), RoleId.Tiebreaker, false, true);
        public static RoleInfo bait = new RoleInfo(ModTranslation.getString("Bait"), Bait.color, ModTranslation.getString("BaitDescription1"), ModTranslation.getString("BaitDescription2"), RoleId.Bait, false, true);
        public static RoleInfo sunglasses = new RoleInfo(ModTranslation.getString("Sunglasses"), Sunglasses.color, ModTranslation.getString("SunglassesDescription1"), ModTranslation.getString("SunglassesDescription2"), RoleId.Sunglasses, false, true);
        public static RoleInfo lover = new RoleInfo(ModTranslation.getString("Lover"), Lovers.color, ModTranslation.getString("LoverDescription1"), ModTranslation.getString("LoverDescription2"), RoleId.Lover, false, true);
        public static RoleInfo mini = new RoleInfo(ModTranslation.getString("Mini"), Mini.color, ModTranslation.getString("MiniDescription1"), ModTranslation.getString("MiniDescription2"), RoleId.Mini, false, true);
        public static RoleInfo vip = new RoleInfo(ModTranslation.getString("VIP"), Vip.color, ModTranslation.getString("VIPDescription1"), ModTranslation.getString("VIPDescription2"), RoleId.Vip, false, true);
        public static RoleInfo invert = new RoleInfo(ModTranslation.getString("Invert"), Invert.color, ModTranslation.getString("InvertDescription1"), ModTranslation.getString("InvertDescription2"), RoleId.Invert, false, true);
        public static RoleInfo chameleon = new RoleInfo(ModTranslation.getString("Chameleon"), Chameleon.color, ModTranslation.getString("ChameleonDescription1"), ModTranslation.getString("ChameleonDescription2"), RoleId.Chameleon, false, true);
        public static RoleInfo shifter = new RoleInfo(ModTranslation.getString("Shifter"), Shifter.color, ModTranslation.getString("ShifterDescription1"), ModTranslation.getString("ShifterDescription2"), RoleId.Shifter, false, true);
        public static RoleInfo armored = new RoleInfo(ModTranslation.getString("Armored"), Armored.color, ModTranslation.getString("ArmoredDescription1"), ModTranslation.getString("ArmoredDescription2"), RoleId.Armored, false, true);
        public static RoleInfo disperser = new RoleInfo(ModTranslation.getString("Disperser"), Color.red, ModTranslation.getString("DisperserDescription1"), ModTranslation.getString("DisperserDescription2"), RoleId.Disperser, false, true);
       
        public static List<RoleInfo> allRoleInfos = new List<RoleInfo>() {
            impostor,
            godfather,
            mafioso,
            janitor,
            morphling,
            camouflager,
            vampire,
            undertaker,
            eraser,
            trickster,
            cleaner,
            warlock,
            bountyHunter,
            witch,
            ninja,
            bomber,
            yoyo,
            miner,
            blackmailer,
            goodGuesser,
            badGuesser,
            lover,
            jester,
            arsonist,
            jackal,
            sidekick,
            vulture,
            pursuer,
            lawyer,
            thief,
            prosecutor,
            plagueDoctor,
            crewmate,
            mayor,
            portalmaker,
            engineer,
            sheriff,
            deputy,
            lighter,
            detective,
            timeMaster,
            medic,
            swapper,
            seer,
            paranoia,
            veteran,
            hacker,
            tracker,
            snitch,
            spy,
            securityGuard,
            bait,
            medium,
            trapper,
            bloody,
            antiTeleport,
            tiebreaker,
            sunglasses,
            mini,
            vip,
            invert,
            chameleon,
            armored,
            disperser,
            shifter
        };

        public static List<RoleInfo> getRoleInfoForPlayer(PlayerControl p, bool showModifier = true) {
            List<RoleInfo> infos = new List<RoleInfo>();
            if (p == null) return infos;

            // Modifier
            if (showModifier) {
                // after dead modifier
                if (!CustomOptionHolder.modifiersAreHidden.getBool() || PlayerControl.LocalPlayer.Data.IsDead || AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Ended)
                {
                    if (Bait.bait.Any(x => x.PlayerId == p.PlayerId)) infos.Add(bait);
                    if (Bloody.bloody.Any(x => x.PlayerId == p.PlayerId)) infos.Add(bloody);
                    if (Vip.vip.Any(x => x.PlayerId == p.PlayerId)) infos.Add(vip);
                }
                if (p == Lovers.lover1 || p == Lovers.lover2) infos.Add(lover);
                if (p == Tiebreaker.tiebreaker) infos.Add(tiebreaker);
                if (AntiTeleport.antiTeleport.Any(x => x.PlayerId == p.PlayerId)) infos.Add(antiTeleport);
                if (Sunglasses.sunglasses.Any(x => x.PlayerId == p.PlayerId)) infos.Add(sunglasses);
                if (p == Mini.mini) infos.Add(mini);
                if (Invert.invert.Any(x => x.PlayerId == p.PlayerId)) infos.Add(invert);
                if (Chameleon.chameleon.Any(x => x.PlayerId == p.PlayerId)) infos.Add(chameleon);
                if (p == Armored.armored) infos.Add(armored);
                if (p == Shifter.shifter) infos.Add(shifter);
            }

            int count = infos.Count;  // Save count after modifiers are added so that the role count can be checked

            // Special roles
            if (p == Jester.jester) infos.Add(jester);
            if (p == Mayor.mayor) infos.Add(mayor);
            if (p == Portalmaker.portalmaker) infos.Add(portalmaker);
            if (p == Engineer.engineer) infos.Add(engineer);
            if (p == Sheriff.sheriff || p == Sheriff.formerSheriff) infos.Add(sheriff);
            if (p == Deputy.deputy) infos.Add(deputy);
            if (p == Lighter.lighter) infos.Add(lighter);
            if (p == Godfather.godfather) infos.Add(godfather);
            if (p == Mafioso.mafioso) infos.Add(mafioso);
            if (p == Janitor.janitor) infos.Add(janitor);
            if (p == Morphling.morphling) infos.Add(morphling);
            if (p == Camouflager.camouflager) infos.Add(camouflager);
            if (p == Vampire.vampire) infos.Add(vampire);
            if (p == Eraser.eraser) infos.Add(eraser);
            if (p == Trickster.trickster) infos.Add(trickster);
            if (p == Cleaner.cleaner) infos.Add(cleaner);
            if (p == Warlock.warlock) infos.Add(warlock);
            if (p == Witch.witch) infos.Add(witch);
            if (p == Ninja.ninja) infos.Add(ninja);
            if (p == Bomber.bomber) infos.Add(bomber);
            if (p == Undertaker.undertaker) infos.Add(undertaker);
            if (p == Yoyo.yoyo) infos.Add(yoyo);
            if (p == Miner.miner) infos.Add(miner);
            if (p == Blackmailer.blackmailer) infos.Add(blackmailer);
            if (p == Detective.detective) infos.Add(detective);
            if (p == TimeMaster.timeMaster) infos.Add(timeMaster);
            if (p == Medic.medic) infos.Add(medic);
            if (p == Swapper.swapper) infos.Add(swapper);
            if (p == Paranoia.paranoia) infos.Add(paranoia);
            if (p == Veteran.veteran) infos.Add(veteran);
            if (p == Seer.seer) infos.Add(seer);
            if (p == Hacker.hacker) infos.Add(hacker);
            if (p == Tracker.tracker) infos.Add(tracker);
            if (p == Snitch.snitch) infos.Add(snitch);
            if (p == Jackal.jackal || (Jackal.formerJackals != null && Jackal.formerJackals.Any(x => x.PlayerId == p.PlayerId))) infos.Add(jackal);
            if (p == Sidekick.sidekick) infos.Add(sidekick);
            if (p == Spy.spy) infos.Add(spy);
            if (p == SecurityGuard.securityGuard) infos.Add(securityGuard);
            if (p == Arsonist.arsonist) infos.Add(arsonist);
            if (p == Guesser.niceGuesser) infos.Add(goodGuesser);
            if (p == Guesser.evilGuesser) infos.Add(badGuesser);
            if (p == BountyHunter.bountyHunter) infos.Add(bountyHunter);
            if (p == Vulture.vulture) infos.Add(vulture);
            if (p == Medium.medium) infos.Add(medium);
            if (p == Lawyer.lawyer && !Lawyer.isProsecutor) infos.Add(lawyer);
            if (p == Lawyer.lawyer && Lawyer.isProsecutor) infos.Add(prosecutor);
            if (p == Trapper.trapper) infos.Add(trapper);
            if (p == Pursuer.pursuer) infos.Add(pursuer);
            if (p == Disperser.disperser) infos.Add(disperser);
            if (p == Thief.thief) infos.Add(thief);
            if (p == PlagueDoctor.plagueDoctor) infos.Add(plagueDoctor);


            // Default roles (just impostor, just crewmate, or hunter / hunted for hide n seek, prop hunt prop ...
            if (infos.Count == count) {
                if (p.Data.Role.IsImpostor)
                    infos.Add(TORMapOptions.gameMode == CustomGamemodes.HideNSeek || TORMapOptions.gameMode == CustomGamemodes.PropHunt ? RoleInfo.hunter : RoleInfo.impostor);
                else
                    infos.Add(TORMapOptions.gameMode == CustomGamemodes.HideNSeek ? RoleInfo.hunted : TORMapOptions.gameMode == CustomGamemodes.PropHunt ? RoleInfo.prop : RoleInfo.crewmate);
            }

            return infos;
        }

        public static String GetRolesString(PlayerControl p, bool useColors, bool showModifier = true, bool suppressGhostInfo = false)
        {
            string roleName;
            roleName = String.Join(" ", getRoleInfoForPlayer(p, showModifier).Select(x => useColors ? Helpers.cs(x.color, x.name) : x.name).ToArray());
            if (Lawyer.target != null && p.PlayerId == Lawyer.target.PlayerId && CachedPlayer.LocalPlayer.PlayerControl != Lawyer.target)
                roleName += (useColors ? Helpers.cs(Pursuer.color, " §") : " §");
            if (HandleGuesser.isGuesserGm && HandleGuesser.isGuesser(p.PlayerId)) roleName += " (赌怪)";

            if (!suppressGhostInfo && p != null)
            {
                if (p == Shifter.shifter && (CachedPlayer.LocalPlayer.PlayerControl == Shifter.shifter || Helpers.shouldShowGhostInfo()) && Shifter.futureShift != null)
                    roleName += Helpers.cs(Color.yellow, " ← " + Shifter.futureShift.Data.PlayerName);
                if (p == Vulture.vulture && (CachedPlayer.LocalPlayer.PlayerControl == Vulture.vulture || Helpers.shouldShowGhostInfo()))
                    roleName = roleName + Helpers.cs(Vulture.color, $" ({Vulture.vultureNumberToWin - Vulture.eatenBodies} 个)");
                if (Helpers.shouldShowGhostInfo())
                {
                    if (Eraser.futureErased.Contains(p))
                        roleName = Helpers.cs(Color.gray, "(被抹除) ") + roleName;
                    if (Vampire.vampire != null && !Vampire.vampire.Data.IsDead && Vampire.bitten == p && !p.Data.IsDead)
                        roleName = Helpers.cs(Vampire.color, $"(被咬死了{(int)HudManagerStartPatch.vampireKillButton.Timer + 1}) ") + roleName;
                    if (Deputy.handcuffedPlayers.Contains(p.PlayerId))
                        roleName = Helpers.cs(Color.gray, "(被戴上手铐) ") + roleName;
                    if (Deputy.handcuffedKnows.ContainsKey(p.PlayerId))  // Active cuff
                        roleName = Helpers.cs(Deputy.color, "(被戴上手铐) ") + roleName;
                    if (p == Warlock.curseVictim)
                        roleName = Helpers.cs(Warlock.color, "(被诅咒) ") + roleName;
                    if (p == Ninja.ninjaMarked)
                        roleName = Helpers.cs(Ninja.color, "(被刺客选定为目标) ") + roleName;
                    if (Pursuer.blankedList.Contains(p) && !p.Data.IsDead)
                        roleName = Helpers.cs(Pursuer.color, "(被塞入空包弹) ") + roleName;
                    if (Witch.futureSpelled.Contains(p) && !MeetingHud.Instance) // This is already displayed in meetings!
                        roleName = Helpers.cs(Witch.color, "☆ ") + roleName;
                    if (BountyHunter.bounty == p)
                        roleName = Helpers.cs(BountyHunter.color, "(赏金目标) ") + roleName;
                    if (Arsonist.dousedPlayers.Contains(p))
                        roleName = Helpers.cs(Arsonist.color, "♨ ") + roleName;
                    if (p == Arsonist.arsonist)
                        roleName = roleName + Helpers.cs(Arsonist.color, $" ({CachedPlayer.AllPlayers.Count(x => { return x.PlayerControl != Arsonist.arsonist && !x.Data.IsDead && !x.Data.Disconnected && !Arsonist.dousedPlayers.Any(y => y.PlayerId == x.PlayerId); })} 个)");
                    if (p == Jackal.fakeSidekick)
                        roleName = Helpers.cs(Sidekick.color, $" (跟班)") + roleName;

                    // Death Reason on Ghosts
                    if (p.Data.IsDead)
                    {
                        string deathReasonString = "";
                        var deadPlayer = GameHistory.deadPlayers.FirstOrDefault(x => x.player.PlayerId == p.PlayerId);

                        Color killerColor = new();
                        if (deadPlayer != null && deadPlayer.killerIfExisting != null)
                        {
                            killerColor = RoleInfo.getRoleInfoForPlayer(deadPlayer.killerIfExisting, false).FirstOrDefault().color;
                        }

                        if (deadPlayer != null)
                        {
                            switch (deadPlayer.deathReason)
                            {
                                case DeadPlayer.CustomDeathReason.Disconnect:
                                    deathReasonString = " - 断开连接";
                                    break;
                                case DeadPlayer.CustomDeathReason.Exile:
                                    deathReasonString = " - 被投出去了";
                                    break;
                                case DeadPlayer.CustomDeathReason.Kill:
                                    deathReasonString = $" - 被{Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)}击杀";
                                    break;
                                case DeadPlayer.CustomDeathReason.Guess:
                                    if (deadPlayer.killerIfExisting.Data.PlayerName == p.Data.PlayerName)
                                        deathReasonString = $" - 赌杀失败";
                                    else
                                        deathReasonString = $" - 赌杀 {Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)} 成功";
                                    break;
                                case DeadPlayer.CustomDeathReason.Shift:
                                    deathReasonString = $" - {Helpers.cs(Color.yellow, "被偷身份")} {Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)}";
                                    break;
                                case DeadPlayer.CustomDeathReason.WitchExile:
                                    deathReasonString = $" - {Helpers.cs(Witch.color, "被下咒")} {Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)}";
                                    break;
                                case DeadPlayer.CustomDeathReason.LoverSuicide:
                                    deathReasonString = $" - {Helpers.cs(Lovers.color, "殉情")}";
                                    break;
                                case DeadPlayer.CustomDeathReason.LawyerSuicide:
                                    deathReasonString = $" - {Helpers.cs(Lawyer.color, "邪恶律师")}";
                                    break;
                                case DeadPlayer.CustomDeathReason.Bomb:
                                    deathReasonString = $" - {Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)}被炸死了";
                                    break;
                                case DeadPlayer.CustomDeathReason.Arson:
                                    deathReasonString = $" - {Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)}被烧死了";
                                    break;
                            }
                            roleName = roleName + deathReasonString;
                        }
                    }
                }
            }
            return roleName;
        }


        static string ReadmePage = "";
        public static async Task loadReadme()
        {
            if (ReadmePage == "")
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(Helpers.isChinese() ? "https://download.hayashiume.top/" : "" + "https://raw.githubusercontent.com/TheOtherRolesAU/TheOtherRoles/main/README.md");
                response.EnsureSuccessStatusCode();
                string httpres = await response.Content.ReadAsStringAsync();
                ReadmePage = httpres;
            }
        }
        public static string GetRoleDescription(RoleInfo roleInfo)
        {
            while (ReadmePage == "") { }
            int index = ReadmePage.IndexOf($"## {roleInfo.name}");
            if (index == -1)
            {
                return $"未找到角色 {roleInfo.name} 的描述";
            }
            int endindex = ReadmePage.Substring(index).IndexOf("### Game Options");
            if (endindex == -1)
            {
                return ReadmePage.Substring(index);
            }
            return ReadmePage.Substring(index, endindex);
        }
    }
}
