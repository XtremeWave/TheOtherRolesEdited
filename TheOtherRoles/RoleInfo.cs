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
using TheOtherRolesEdited.Patches;

namespace TheOtherRolesEdited
{
    public class RoleInfo {
        public string name => ModTranslation.getString(nameKey);
        public string introDescription => ModTranslation.getString(nameKey + "Description1");
        public string shortDescription => ModTranslation.getString(nameKey + "Description2");
        public string fullDescription => ModTranslation.getString(nameKey + "FullDesc");

        public Color color;
        public RoleId roleId;
        public RoleType roleType;
        public bool isNeutral;
        public bool isModifier;
        public bool isCrewmate;
        public string nameKey;

        public bool isImpostor => color == Palette.ImpostorRed && !(roleId == RoleId.Spy);
        public static Dictionary<RoleId, RoleInfo> roleInfoById = new();
        public RoleInfo(string name, Color color, RoleId roleId, RoleType roleType, bool isNeutral = false, bool isModifier = false, bool isCrewmate = false) 
        {
           
            this.color = color;
            this.roleId = roleId;
            this.roleType = roleType;
            this.isNeutral = isNeutral;
            this.isCrewmate = isCrewmate;
            this.isModifier = isModifier;
            nameKey = name;
            roleInfoById.TryAdd(roleId, this);
        }
        //Impostor
        public static RoleInfo godfather = new RoleInfo("Godfather", Godfather.color, RoleId.Godfather, RoleType.Impostor);
        public static RoleInfo mafioso = new RoleInfo("Mafioso", Mafioso.color, RoleId.Mafioso, RoleType.Impostor);
        public static RoleInfo janitor = new RoleInfo("Janitor", Janitor.color, RoleId.Janitor, RoleType.Impostor);
        public static RoleInfo morphling = new RoleInfo("Morphling", Morphling.color, RoleId.Morphling, RoleType.Impostor);
        public static RoleInfo camouflager = new RoleInfo("Camouflager", Camouflager.color, RoleId.Camouflager, RoleType.Impostor);
        public static RoleInfo vampire = new RoleInfo("Vampire", Vampire.color, RoleId.Vampire, RoleType.Impostor);
        public static RoleInfo eraser = new RoleInfo("Eraser", Eraser.color, RoleId.Eraser, RoleType.Impostor);
        public static RoleInfo trickster = new RoleInfo("Trickster", Trickster.color, RoleId.Trickster, RoleType.Impostor);
        public static RoleInfo cleaner = new RoleInfo("Cleaner", Cleaner.color, RoleId.Cleaner, RoleType.Impostor);
        public static RoleInfo blackmailer = new RoleInfo("Blackmailer", Blackmailer.color, RoleId.Blackmailer, RoleType.Impostor);
        public static RoleInfo miner = new RoleInfo("Miner", Miner.color, RoleId.Miner, RoleType.Impostor);
        public static RoleInfo undertaker = new RoleInfo("Undertaker", Undertaker.color, RoleId.Undertaker, RoleType.Impostor);
        public static RoleInfo warlock = new RoleInfo("Warlock", Warlock.color, RoleId.Warlock, RoleType.Impostor);
        public static RoleInfo bountyHunter = new RoleInfo("BountyHunter", BountyHunter.color, RoleId.BountyHunter, RoleType.Impostor);
        public static RoleInfo badGuesser = new RoleInfo("BadGuesser", Palette.ImpostorRed, RoleId.EvilGuesser, RoleType.Impostor);
        public static RoleInfo bomber = new RoleInfo("Bomber", Bomber.color, RoleId.Bomber, RoleType.Impostor);
        public static RoleInfo yoyo = new RoleInfo("YoYo", Yoyo.color, RoleId.Yoyo, RoleType.Impostor);
        public static RoleInfo impostor = new RoleInfo("Impostor", Palette.ImpostorRed, RoleId.Impostor, RoleType.Impostor);
        public static RoleInfo ninja = new RoleInfo("Ninja", Ninja.color, RoleId.Ninja, RoleType.Impostor);
        public static RoleInfo witch = new RoleInfo("Witch", Witch.color, RoleId.Witch, RoleType.Impostor);

        //Crewmate
        public static RoleInfo mayor = new RoleInfo("Mayor", Mayor.color, RoleId.Mayor, RoleType.Crewmate);
        public static RoleInfo portalmaker = new RoleInfo("Portalmaker", Portalmaker.color, RoleId.Portalmaker, RoleType.Crewmate);
        public static RoleInfo engineer = new RoleInfo("Engineer", Engineer.color, RoleId.Engineer, RoleType.Crewmate);
        public static RoleInfo sheriff = new RoleInfo("Sheriff", Sheriff.color, RoleId.Sheriff, RoleType.Crewmate);
        public static RoleInfo deputy = new RoleInfo("Deputy", Sheriff.color, RoleId.Deputy, RoleType.Crewmate);
        public static RoleInfo lighter = new RoleInfo("Lighter", Lighter.color, RoleId.Lighter, RoleType.Crewmate);
        public static RoleInfo detective = new RoleInfo("Detective", Detective.color, RoleId.Detective, RoleType.Crewmate);
        public static RoleInfo timeMaster = new RoleInfo("TimeMaster", TimeMaster.color, RoleId.TimeMaster, RoleType.Crewmate);
        public static RoleInfo medic = new RoleInfo("Medic", Medic.color, RoleId.Medic, RoleType.Crewmate);
        public static RoleInfo swapper = new RoleInfo("Swapper", Swapper.color, RoleId.Swapper, RoleType.Crewmate);
        public static RoleInfo seer = new RoleInfo("Seer", Seer.color, RoleId.Seer, RoleType.Crewmate);
        public static RoleInfo hacker = new RoleInfo("Hacker", Hacker.color, RoleId.Hacker, RoleType.Crewmate);
        public static RoleInfo tracker = new RoleInfo("Tracker", Tracker.color, RoleId.Tracker, RoleType.Crewmate);
        public static RoleInfo snitch = new RoleInfo("Snitch", Snitch.color, RoleId.Snitch, RoleType.Crewmate);
        public static RoleInfo spy = new RoleInfo("Spy", Spy.color, RoleId.Spy, RoleType.Crewmate);
        public static RoleInfo securityGuard = new RoleInfo("SecurityGuard", SecurityGuard.color, RoleId.SecurityGuard, RoleType.Crewmate);
        public static RoleInfo veteran = new RoleInfo("Veteran", Veteran.color, RoleId.Veteran, RoleType.Crewmate);
        public static RoleInfo goodGuesser = new RoleInfo("NiceGuesser", Guesser.color, RoleId.NiceGuesser, RoleType.Crewmate);
        public static RoleInfo medium = new RoleInfo("Medium", Medium.color, RoleId.Medium, RoleType.Crewmate);
        public static RoleInfo trapper = new RoleInfo("Trapper", Trapper.color, RoleId.Trapper, RoleType.Crewmate);
        public static RoleInfo crewmate = new RoleInfo("Crewmate", Color.white, RoleId.Crewmate, RoleType.Crewmate);

        //Neutral
        public static RoleInfo jester = new RoleInfo("Jester", Jester.color, RoleId.Jester, RoleType.Neutral, true);
        public static RoleInfo jackal = new RoleInfo("Jackal", Jackal.color, RoleId.Jackal, RoleType.Neutral, true);
        public static RoleInfo sidekick = new RoleInfo("Sidekick", Sidekick.color, RoleId.Sidekick, RoleType.Neutral, true);
        public static RoleInfo arsonist = new RoleInfo("Arsonist", Arsonist.color, RoleId.Arsonist, RoleType.Neutral, true);
        public static RoleInfo plagueDoctor = new RoleInfo("PlagueDoctor", PlagueDoctor.color, RoleId.PlagueDoctor, RoleType.Neutral, true);
        public static RoleInfo vulture = new RoleInfo("Vulture", Vulture.color, RoleId.Vulture, RoleType.Neutral, true);
        public static RoleInfo lawyer = new RoleInfo("Lawyer", Lawyer.color, RoleId.Lawyer, RoleType.Neutral, true);
        public static RoleInfo prosecutor = new RoleInfo("Prosecutor", Prosecutor.color, RoleId.Prosecutor, RoleType.Neutral, true);
        public static RoleInfo pursuer = new RoleInfo("Pursuer", Pursuer.color, RoleId.Pursuer, RoleType.Neutral);
        public static RoleInfo thief = new RoleInfo("Thief", Thief.color, RoleId.Thief, RoleType.Neutral, true);

        // Modifier
        public static RoleInfo bloody = new RoleInfo("Bloody", Bloody.color, RoleId.Bloody, RoleType.Modifier, false, true);
        public static RoleInfo antiTeleport = new RoleInfo("AntiTeleport", AntiTeleport.color, RoleId.AntiTeleport, RoleType.Modifier, false, true);
        public static RoleInfo tiebreaker = new RoleInfo("Tiebreaker", Tiebreaker.color, RoleId.Tiebreaker, RoleType.Modifier, false, true);
        public static RoleInfo bait = new RoleInfo("Bait", Bait.color, RoleId.Bait, RoleType.Modifier, false, true);
        public static RoleInfo sunglasses = new RoleInfo("Sunglasses", Sunglasses.color, RoleId.Sunglasses, RoleType.Modifier, false, true);
        public static RoleInfo lover = new RoleInfo("Lover", Lovers.color, RoleId.Lover, RoleType.Modifier, false, true);
        public static RoleInfo mini = new RoleInfo("Mini", Mini.color, RoleId.Mini, RoleType.Modifier, false, true);
        public static RoleInfo vip = new RoleInfo("VIP", Vip.color, RoleId.Vip, RoleType.Modifier, false, true);
        public static RoleInfo invert = new RoleInfo("Invert", Invert.color, RoleId.Invert, RoleType.Modifier, false, true);
        public static RoleInfo chameleon = new RoleInfo("Chameleon", Chameleon.color, RoleId.Chameleon, RoleType.Modifier, false, true);
        public static RoleInfo shifter = new RoleInfo("Shifter", Shifter.color, RoleId.Shifter, RoleType.Modifier, false, true);
        public static RoleInfo armored = new RoleInfo("Armored", Armored.color, RoleId.Armored, RoleType.Modifier, false, true);
        public static RoleInfo disperser = new RoleInfo("Disperser", Color.red, RoleId.Disperser, RoleType.Modifier, false, true);

        //Others
        public static RoleInfo hunter = new RoleInfo("Hunter", Palette.ImpostorRed, RoleId.Impostor, RoleType.Impostor);
        public static RoleInfo hunted = new RoleInfo("Hunted", Color.white, RoleId.Crewmate, RoleType.Crewmate);
        public static RoleInfo prop = new RoleInfo("Prop", Color.white, RoleId.Crewmate, RoleType.Crewmate);

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
            if (HandleGuesser.isGuesserGm && HandleGuesser.isGuesser(p.PlayerId)) roleName += $" ({ModTranslation.getString("guesserSpawnRate")})";

            if (!suppressGhostInfo && p != null)
            {
                if (p == Shifter.shifter && (CachedPlayer.LocalPlayer.PlayerControl == Shifter.shifter || Helpers.shouldShowGhostInfo()) && Shifter.futureShift != null)
                    roleName += Helpers.cs(Color.yellow, " ← " + Shifter.futureShift.Data.PlayerName);
                if (p == Vulture.vulture && (CachedPlayer.LocalPlayer.PlayerControl == Vulture.vulture || Helpers.shouldShowGhostInfo()))
                    roleName = roleName + Helpers.cs(Vulture.color, $" ({Vulture.vultureNumberToWin - Vulture.eatenBodies} {ModTranslation.getString("Left")})");
                if (Helpers.shouldShowGhostInfo())
                {
                    if (Eraser.futureErased.Contains(p))
                        roleName = Helpers.cs(Color.gray, ModTranslation.getString("Erased")) + roleName;
                    if (Vampire.vampire != null && !Vampire.vampire.Data.IsDead && Vampire.bitten == p && !p.Data.IsDead)
                        roleName = Helpers.cs(Vampire.color, $"({ModTranslation.getString("Bitten")} {(int)HudManagerStartPatch.vampireKillButton.Timer + 1}) ") + roleName;
                    if (Deputy.handcuffedPlayers.Contains(p.PlayerId))
                        roleName = Helpers.cs(Color.gray, ModTranslation.getString("Cuffed")) + roleName;
                    if (Deputy.handcuffedKnows.ContainsKey(p.PlayerId))  // Active cuff
                        roleName = Helpers.cs(Deputy.color, ModTranslation.getString("Cuffed")) + roleName;
                    if (p == Warlock.curseVictim)
                        roleName = Helpers.cs(Warlock.color, ModTranslation.getString("Cursed")) + roleName;
                    if (p == Ninja.ninjaMarked)
                        roleName = Helpers.cs(Ninja.color, ModTranslation.getString("Marked")) + roleName;
                    if (Pursuer.blankedList.Contains(p) && !p.Data.IsDead)
                        roleName = Helpers.cs(Pursuer.color, ModTranslation.getString("Blanked")) + roleName;
                    if (Witch.futureSpelled.Contains(p) && !MeetingHud.Instance) // This is already displayed in meetings!
                        roleName = Helpers.cs(Witch.color, "☆ ") + roleName;
                    if (BountyHunter.bounty == p)
                        roleName = Helpers.cs(BountyHunter.color, ModTranslation.getString("Bounty")) + roleName;
                    if (Arsonist.dousedPlayers.Contains(p))
                        roleName = Helpers.cs(Arsonist.color, "♨ ") + roleName;
                    if (p == Arsonist.arsonist)
                        roleName = roleName + Helpers.cs(Arsonist.color, $" ({CachedPlayer.AllPlayers.Count(x => { return x.PlayerControl != Arsonist.arsonist && !x.Data.IsDead && !x.Data.Disconnected && !Arsonist.dousedPlayers.Any(y => y.PlayerId == x.PlayerId); })} {ModTranslation.getString("Left")})");
                    if (p == Jackal.fakeSidekick)
                        roleName = Helpers.cs(Sidekick.color, ModTranslation.getString("FakeSK")) + roleName;

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
                                    deathReasonString = $" - {ModTranslation.getString("Disconnected")}";
                                    break;
                                case DeadPlayer.CustomDeathReason.Exile:
                                    deathReasonString = $" - {ModTranslation.getString("VotedOut")}";
                                    break;
                                case DeadPlayer.CustomDeathReason.Kill:
                                    deathReasonString = $" -{string.Format(ModTranslation.getString("Killed"), Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName))}";
                                    break;
                                case DeadPlayer.CustomDeathReason.Guess:
                                    if (deadPlayer.killerIfExisting.Data.PlayerName == p.Data.PlayerName)
                                        deathReasonString = $" - {ModTranslation.getString("FailedGuess")}";
                                    else
                                        deathReasonString = $" - {string.Format(ModTranslation.getString("Guessed"), Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName))}";
                                    break;
                                case DeadPlayer.CustomDeathReason.Shift:
                                    deathReasonString = $" - {Helpers.cs(Color.yellow, ModTranslation.getString("Shifted"))} {Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)}";
                                    break;
                                case DeadPlayer.CustomDeathReason.WitchExile:
                                    deathReasonString = $" - {Helpers.cs(Witch.color, ModTranslation.getString("Witched"))} {Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)}";
                                    break;
                                case DeadPlayer.CustomDeathReason.LoverSuicide:
                                    deathReasonString = $" - {Helpers.cs(Lovers.color, ModTranslation.getString("LoverDied"))}";
                                    break;
                                case DeadPlayer.CustomDeathReason.LawyerSuicide:
                                    deathReasonString = $" - {Helpers.cs(Lawyer.color, ModTranslation.getString("BadLawyer"))}";
                                    break;
                                case DeadPlayer.CustomDeathReason.Bomb:
                                    deathReasonString = $" - {string.Format(ModTranslation.getString("Bombed"), Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName))}";
                                    break;
                                case DeadPlayer.CustomDeathReason.Arson:
                                    deathReasonString = $" - {string.Format(ModTranslation.getString("Burnt"), Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName))}";
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
