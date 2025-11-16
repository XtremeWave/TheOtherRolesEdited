using System.Collections.Generic;
using UnityEngine;
using static TheOtherRolesEdited.TheOtherRolesEdited;
using Types = TheOtherRolesEdited.CustomOption.CustomOptionType;

namespace TheOtherRolesEdited
{
    public class CustomOptionHolder
    {
        public static string[] rates = new string[] { "0%", "10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%" };
        public static string[] ratesModifier = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" };
        public static string[] presets = new string[] { "预设 1", "预设  2", "启用骷髅船预设 ", "启用米拉总部预设 ", "启用波鲁斯预设 ", "启用飞艇预设 ", "启用潜艇预设 " };

        public static CustomOption presetSelection;
        public static CustomOption activateRoles;
        public static CustomOption crewmateRolesCountMin;
        public static CustomOption crewmateRolesCountMax;
        public static CustomOption crewmateRolesFill;
        public static CustomOption neutralRolesCountMin;
        public static CustomOption neutralRolesCountMax;
        public static CustomOption impostorRolesCountMin;
        public static CustomOption impostorRolesCountMax;
        public static CustomOption modifiersCountMin;
        public static CustomOption modifiersCountMax;
        public static CustomOption anyPlayerCanStopStart;
        public static CustomOption enableEventMode;
        public static CustomOption eventReallyNoMini;
        public static CustomOption eventKicksPerRound;
        public static CustomOption eventHeavyAge;
        public static CustomOption deadImpsBlockSabotage;
        public static CustomOption CanUseSwitchShipCostumeButton;
        public static CustomOption modifierShifterShiftsMedicShield;
        public static CustomOption HostName;

        public static CustomOption debugMode;
        public static CustomOption disableGameEnd;

        public static CustomOption mafiaSpawnRate;
        public static CustomOption janitorCooldown;

        public static CustomOption morphlingSpawnRate;
        public static CustomOption morphlingCooldown;
        public static CustomOption morphlingDuration;

        public static CustomOption camouflagerSpawnRate;
        public static CustomOption camouflagerCooldown;
        public static CustomOption camouflagerDuration;

        public static CustomOption vampireSpawnRate;
        public static CustomOption vampireKillDelay;
        public static CustomOption vampireCooldown;
        public static CustomOption vampireCanKillNearGarlics;

        public static CustomOption minerSpawnRate;
        public static CustomOption minerCooldown;

        public static CustomOption eraserSpawnRate;
        public static CustomOption eraserCooldown;
        public static CustomOption eraserCanEraseAnyone;
        public static CustomOption guesserSpawnRate;
        public static CustomOption guesserIsImpGuesserRate;
        public static CustomOption guesserNumberOfShots;
        public static CustomOption guesserHasMultipleShotsPerMeeting;
        public static CustomOption guesserKillsThroughShield;
        public static CustomOption guesserEvilCanKillSpy;
        public static CustomOption guesserSpawnBothRate;
        public static CustomOption guesserCantGuessSnitchIfTaksDone;

        public static CustomOption jesterSpawnRate;
        public static CustomOption jesterCanCallEmergency;
        public static CustomOption jesterHasImpostorVision;

        public static CustomOption arsonistSpawnRate;
        public static CustomOption arsonistCooldown;
        public static CustomOption arsonistDuration;

        public static CustomOption jackalSpawnRate;
        public static CustomOption jackalKillCooldown;
        public static CustomOption jackalCreateSidekickCooldown;
        public static CustomOption jackalCanSabotageLights;
        public static CustomOption jackalCanUseVents;
        public static CustomOption jackalCanCreateSidekick;
        public static CustomOption sidekickPromotesToJackal;
        public static CustomOption sidekickCanKill;
        public static CustomOption sidekickCanUseVents;
        public static CustomOption sidekickCanSabotageLights;
        public static CustomOption jackalPromotedFromSidekickCanCreateSidekick;
        public static CustomOption jackalCanCreateSidekickFromImpostor;
        public static CustomOption jackalAndSidekickHaveImpostorVision;

        public static CustomOption bountyHunterSpawnRate;
        public static CustomOption bountyHunterBountyDuration;
        public static CustomOption bountyHunterReducedCooldown;
        public static CustomOption bountyHunterPunishmentTime;
        public static CustomOption bountyHunterShowArrow;
        public static CustomOption bountyHunterArrowUpdateIntervall;

        public static CustomOption witchSpawnRate;
        public static CustomOption witchCooldown;
        public static CustomOption witchAdditionalCooldown;
        public static CustomOption witchCanSpellAnyone;
        public static CustomOption witchSpellCastingDuration;
        public static CustomOption witchTriggerBothCooldowns;
        public static CustomOption witchVoteSavesTargets;

        public static CustomOption ninjaSpawnRate;
        public static CustomOption ninjaCooldown;
        public static CustomOption ninjaKnowsTargetLocation;
        public static CustomOption ninjaTraceTime;
        public static CustomOption ninjaTraceColorTime;
        public static CustomOption ninjaInvisibleDuration;

        public static CustomOption mayorSpawnRate;
        public static CustomOption mayorCanSeeVoteColors;
        public static CustomOption mayorTasksNeededToSeeVoteColors;
        public static CustomOption mayorMeetingButton;
        public static CustomOption mayorMaxRemoteMeetings;
        public static CustomOption mayorChooseSingleVote;

        public static CustomOption portalmakerSpawnRate;
        public static CustomOption portalmakerCooldown;
        public static CustomOption portalmakerUsePortalCooldown;
        public static CustomOption portalmakerLogOnlyColorType;
        public static CustomOption portalmakerLogHasTime;
        public static CustomOption portalmakerCanPortalFromAnywhere;

        public static CustomOption engineerSpawnRate;
        public static CustomOption engineerNumberOfFixes;
        public static CustomOption engineerHighlightForImpostors;
        public static CustomOption engineerHighlightForTeamJackal;

        public static CustomOption sheriffSpawnRate;
        public static CustomOption sheriffCooldown;
        public static CustomOption sheriffCanKillNeutrals;
        public static CustomOption deputySpawnRate;

        public static CustomOption deputyNumberOfHandcuffs;
        public static CustomOption deputyHandcuffCooldown;
        public static CustomOption deputyGetsPromoted;
        public static CustomOption deputyKeepsHandcuffs;
        public static CustomOption deputyHandcuffDuration;
        public static CustomOption deputyKnowsSheriff;

        public static CustomOption lighterSpawnRate;
        public static CustomOption lighterModeLightsOnVision;
        public static CustomOption lighterModeLightsOffVision;
        public static CustomOption lighterFlashlightWidth;

        public static CustomOption detectiveSpawnRate;
        public static CustomOption detectiveAnonymousFootprints;
        public static CustomOption detectiveFootprintIntervall;
        public static CustomOption detectiveFootprintDuration;
        public static CustomOption detectiveReportNameDuration;
        public static CustomOption detectiveReportColorDuration;

        public static CustomOption timeMasterSpawnRate;
        public static CustomOption timeMasterCooldown;
        public static CustomOption timeMasterCanRewind;
        public static CustomOption timeMasterReviveDuringRewind;
        public static CustomOption timeMasterRewindCooldown;
        public static CustomOption timeMasterRewindTime;
        public static CustomOption timeMasterShieldDuration;

        public static CustomOption medicSpawnRate;
        public static CustomOption medicShowShielded;
        public static CustomOption medicShowAttemptToShielded;
        public static CustomOption medicSetOrShowShieldAfterMeeting;
        public static CustomOption medicShowAttemptToMedic;
        public static CustomOption medicSetShieldAfterMeeting;

        public static CustomOption swapperSpawnRate;
        public static CustomOption swapperCanCallEmergency;
        public static CustomOption swapperCanOnlySwapOthers;
        public static CustomOption swapperSwapsNumber;
        public static CustomOption swapperRechargeTasksNumber;

        public static CustomOption seerSpawnRate;
        public static CustomOption seerMode;
        public static CustomOption seerSoulDuration;
        public static CustomOption seerLimitSoulDuration;

        public static CustomOption hackerSpawnRate;
        public static CustomOption hackerCooldown;
        public static CustomOption hackerHackeringDuration;
        public static CustomOption hackerOnlyColorType;
        public static CustomOption hackerToolsNumber;
        public static CustomOption hackerRechargeTasksNumber;
        public static CustomOption hackerNoMove;

        public static CustomOption trackerSpawnRate;
        public static CustomOption trackerUpdateIntervall;
        public static CustomOption trackerResetTargetAfterMeeting;
        public static CustomOption trackerCanTrackCorpses;
        public static CustomOption trackerCorpsesTrackingCooldown;
        public static CustomOption trackerCorpsesTrackingDuration;
        public static CustomOption trackerTrackingMethod;

        public static CustomOption snitchSpawnRate;
        public static CustomOption snitchLeftTasksForReveal;
        public static CustomOption snitchMode;
        public static CustomOption snitchTargets;

        public static CustomOption spySpawnRate;
        public static CustomOption spyCanDieToSheriff;
        public static CustomOption spyImpostorsCanKillAnyone;
        public static CustomOption spyCanEnterVents;
        public static CustomOption spyHasImpostorVision;

        public static CustomOption tricksterSpawnRate;
        public static CustomOption tricksterPlaceBoxCooldown;
        public static CustomOption tricksterLightsOutCooldown;
        public static CustomOption tricksterLightsOutDuration;

        public static CustomOption blackmailerSpawnRate;
        public static CustomOption blackmailerCooldown;

        public static CustomOption cleanerSpawnRate;
        public static CustomOption cleanerCooldown;

        public static CustomOption warlockSpawnRate;
        public static CustomOption warlockCooldown;
        public static CustomOption warlockRootTime;

        public static CustomOption securityGuardSpawnRate;
        public static CustomOption securityGuardCooldown;
        public static CustomOption securityGuardTotalScrews;
        public static CustomOption securityGuardCamPrice;
        public static CustomOption securityGuardVentPrice;
        public static CustomOption securityGuardCamDuration;
        public static CustomOption securityGuardCamMaxCharges;
        public static CustomOption securityGuardCamRechargeTasksNumber;
        public static CustomOption securityGuardNoMove;

        public static CustomOption vultureSpawnRate;
        public static CustomOption vultureCooldown;
        public static CustomOption vultureNumberToWin;
        public static CustomOption vultureCanUseVents;
        public static CustomOption vultureShowArrows;

        public static CustomOption mediumSpawnRate;
        public static CustomOption mediumCooldown;
        public static CustomOption mediumDuration;
        public static CustomOption mediumOneTimeUse;
        public static CustomOption mediumChanceAdditionalInfo;

        public static CustomOption lawyerSpawnRate;
        public static CustomOption lawyerIsProsecutorChance;
        public static CustomOption lawyerTargetCanBeJester;
        public static CustomOption lawyerVision;
        public static CustomOption lawyerKnowsRole;
        public static CustomOption lawyerCanCallEmergency;
        public static CustomOption pursuerCooldown;
        public static CustomOption pursuerBlanksNumber;

        public static CustomOption thiefSpawnRate;
        public static CustomOption thiefCooldown;
        public static CustomOption thiefHasImpVision;
        public static CustomOption thiefCanUseVents;
        public static CustomOption thiefCanKillSheriff;
        public static CustomOption thiefCanStealWithGuess;


        public static CustomOption trapperSpawnRate;
        public static CustomOption trapperCooldown;
        public static CustomOption trapperMaxCharges;
        public static CustomOption trapperRechargeTasksNumber;
        public static CustomOption trapperTrapNeededTriggerToReveal;
        public static CustomOption trapperAnonymousMap;
        public static CustomOption trapperInfoType;
        public static CustomOption trapperTrapDuration;

        public static CustomOption bomberSpawnRate;
        public static CustomOption bomberBombDestructionTime;
        public static CustomOption bomberBombDestructionRange;
        public static CustomOption bomberBombHearRange;
        public static CustomOption bomberDefuseDuration;
        public static CustomOption bomberBombCooldown;
        public static CustomOption bomberBombActiveAfter;

        public static CustomOption yoyoSpawnRate;
        public static CustomOption yoyoBlinkDuration;
        public static CustomOption yoyoMarkCooldown;
        public static CustomOption yoyoMarkStaysOverMeeting;
        public static CustomOption yoyoHasAdminTable;
        public static CustomOption yoyoAdminTableCooldown;
        public static CustomOption yoyoSilhouetteVisibility;



        public static CustomOption modifiersAreHidden;

        public static CustomOption modifierBait;
        public static CustomOption modifierBaitQuantity;
        public static CustomOption modifierBaitReportDelayMin;
        public static CustomOption modifierBaitReportDelayMax;
        public static CustomOption modifierBaitShowKillFlash;

        public static CustomOption modifierLover;
        public static CustomOption modifierLoverImpLoverRate;
        public static CustomOption modifierLoverBothDie;
        public static CustomOption modifierLoverEnableChat;

        public static CustomOption modifierBloody;
        public static CustomOption modifierBloodyQuantity;
        public static CustomOption modifierBloodyDuration;

        public static CustomOption modifierAntiTeleport;
        public static CustomOption modifierAntiTeleportQuantity;

        public static CustomOption modifierTieBreaker;

        public static CustomOption modifierSunglasses;
        public static CustomOption modifierSunglassesQuantity;
        public static CustomOption modifierSunglassesVision;

        public static CustomOption modifierDisperser;
        public static CustomOption modifierDisperserCooldown;
        public static CustomOption modifierDisperserNumberOfUses;

        public static CustomOption modifierMini;
        public static CustomOption modifierMiniGrowingUpDuration;
        public static CustomOption modifierMiniGrowingUpInMeeting;

        public static CustomOption modifierVip;
        public static CustomOption modifierVipQuantity;
        public static CustomOption modifierVipShowColor;

        public static CustomOption modifierInvert;
        public static CustomOption modifierInvertQuantity;
        public static CustomOption modifierInvertDuration;

        public static CustomOption modifierChameleon;
        public static CustomOption modifierChameleonQuantity;
        public static CustomOption modifierChameleonHoldDuration;
        public static CustomOption modifierChameleonFadeDuration;
        public static CustomOption modifierChameleonMinVisibility;

        public static CustomOption modifierArmored;

        public static CustomOption modifierShifter;

        public static CustomOption maxNumberOfMeetings;
        public static CustomOption blockSkippingInEmergencyMeetings;
        public static CustomOption noVoteIsSelfVote;
        public static CustomOption hidePlayerNames;
        public static CustomOption allowParallelMedBayScans;
        public static CustomOption shieldFirstKill;
        public static CustomOption finishTasksBeforeHauntingOrZoomingOut;
        public static CustomOption camsNightVision;
        public static CustomOption camsNoNightVisionIfImpVision;

        public static CustomOption dynamicMap;
        public static CustomOption dynamicMapEnableSkeld;
        public static CustomOption dynamicMapEnableMira;
        public static CustomOption dynamicMapEnablePolus;
        public static CustomOption dynamicMapEnableAirShip;
        public static CustomOption dynamicMapEnableFungle;
        public static CustomOption dynamicMapEnableSubmerged;
        public static CustomOption dynamicMapSeparateSettings;

        //Guesser Gamemode
        public static CustomOption guesserGamemodeCrewNumber;
        public static CustomOption guesserGamemodeNeutralNumber;
        public static CustomOption guesserGamemodeImpNumber;
        public static CustomOption guesserForceJackalGuesser;
        public static CustomOption guesserForceThiefGuesser;
        public static CustomOption guesserGamemodeHaveModifier;
        public static CustomOption guesserGamemodeNumberOfShots;
        public static CustomOption guesserGamemodeHasMultipleShotsPerMeeting;
        public static CustomOption guesserGamemodeKillsThroughShield;
        public static CustomOption guesserGamemodeEvilCanKillSpy;
        public static CustomOption guesserGamemodeCantGuessSnitchIfTaksDone;
        public static CustomOption guesserGamemodeCrewGuesserNumberOfTasks;
        public static CustomOption guesserGamemodeSidekickIsAlwaysGuesser;

        // Hide N Seek Gamemode
        public static CustomOption hideNSeekHunterCount;
        public static CustomOption hideNSeekKillCooldown;
        public static CustomOption hideNSeekHunterVision;
        public static CustomOption hideNSeekHuntedVision;
        public static CustomOption hideNSeekTimer;
        public static CustomOption hideNSeekCommonTasks;
        public static CustomOption hideNSeekShortTasks;
        public static CustomOption hideNSeekLongTasks;
        public static CustomOption hideNSeekTaskWin;
        public static CustomOption hideNSeekTaskPunish;
        public static CustomOption hideNSeekCanSabotage;
        public static CustomOption hideNSeekMap;
        public static CustomOption hideNSeekHunterWaiting;

        public static CustomOption hunterLightCooldown;
        public static CustomOption hunterLightDuration;
        public static CustomOption hunterLightVision;
        public static CustomOption hunterLightPunish;
        public static CustomOption hunterAdminCooldown;
        public static CustomOption hunterAdminDuration;
        public static CustomOption hunterAdminPunish;
        public static CustomOption hunterArrowCooldown;
        public static CustomOption hunterArrowDuration;
        public static CustomOption hunterArrowPunish;

        public static CustomOption huntedShieldCooldown;
        public static CustomOption huntedShieldDuration;
        public static CustomOption huntedShieldRewindTime;
        public static CustomOption huntedShieldNumber;

        // Prop Hunt Settings
        public static CustomOption propHuntMap;
        public static CustomOption propHuntTimer;
        public static CustomOption propHuntNumberOfHunters;
        public static CustomOption hunterInitialBlackoutTime;
        public static CustomOption hunterMissCooldown;
        public static CustomOption hunterHitCooldown;
        public static CustomOption hunterMaxMissesBeforeDeath;
        public static CustomOption propBecomesHunterWhenFound;
        public static CustomOption propHunterVision;
        public static CustomOption propVision;
        public static CustomOption propHuntRevealCooldown;
        public static CustomOption propHuntRevealDuration;
        public static CustomOption propHuntRevealPunish;
        public static CustomOption propHuntUnstuckCooldown;
        public static CustomOption propHuntUnstuckDuration;
        public static CustomOption propHuntInvisCooldown;
        public static CustomOption propHuntInvisDuration;
        public static CustomOption propHuntSpeedboostCooldown;
        public static CustomOption propHuntSpeedboostDuration;
        public static CustomOption propHuntSpeedboostSpeed;
        public static CustomOption propHuntSpeedboostEnabled;
        public static CustomOption propHuntInvisEnabled;
        public static CustomOption propHuntAdminCooldown;
        public static CustomOption propHuntFindCooldown;
        public static CustomOption propHuntFindDuration;

        //轮抽选角
        public static CustomOption isDraftMode;
        public static CustomOption draftModeAmountOfChoices;
        public static CustomOption draftModeTimeToChoose;
        public static CustomOption draftModeShowRoles;
        public static CustomOption draftModeHideRandomRoles;
        public static CustomOption draftModeHideImpRoles;
        public static CustomOption draftModeHideNeutralRoles;
        public static CustomOption draftModeHideCrewRoles;
        public static CustomOption draftModeCanChat;

        internal static Dictionary<byte, byte[]> blockedRolePairings = new Dictionary<byte, byte[]>();

        public static string cs(Color c, string s)
        {
            return string.Format("<color=#{0:X2}{1:X2}{2:X2}{3:X2}>{4}</color>", ToByte(c.r), ToByte(c.g), ToByte(c.b), ToByte(c.a), s);
        }

        private static byte ToByte(float f)
        {
            f = Mathf.Clamp01(f);
            return (byte)(f * 255);
        }

        public static bool isMapSelectionOption(CustomOption option)
        {
            return option == CustomOptionHolder.propHuntMap && option == CustomOptionHolder.hideNSeekMap;
        }

        public static void Load()
        {
            CustomOption.vanillaSettings = TheOtherRolesEditedPlugin.Instance.Config.Bind("Preset0", "VanillaOptions", "");

            // Role Options
            presetSelection = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "预设"), presets, null, true, heading: "游戏预设");
            activateRoles = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "启用模组角色并禁止使用原版角色"), true, null, true, heading: "模组选项");
            if (Utilities.EventUtility.canBeEnabled) enableEventMode = CustomOption.Create(Types.General, cs(Color.green, "启用特别模式"), true, null, true, heading: "特别模式");

            isDraftMode = CustomOption.Create(Types.General, cs(Color.yellow, "启用轮抽选角模式"), false, null, true, null, "轮抽选角");
            draftModeAmountOfChoices = CustomOption.Create(Types.General, cs(Color.yellow, "最大可选职业数量"), 5f, 2f, 7f, 1f, isDraftMode, false);
            draftModeTimeToChoose = CustomOption.Create(Types.General, cs(Color.yellow, "单人选择时常"), 5f, 3f, 20f, 1f, isDraftMode, false);
            draftModeCanChat = CustomOption.Create(Types.General, cs(Color.yellow, "轮抽选角时可以聊天"), false, isDraftMode, false);
            draftModeShowRoles = CustomOption.Create(Types.General, cs(Color.yellow, "显示已选择过的职业"), false, isDraftMode, false);
            draftModeHideRandomRoles = CustomOption.Create(Types.General, cs(Color.yellow, "隐藏随机职业"), false, draftModeShowRoles, false);
            draftModeHideImpRoles = CustomOption.Create(Types.General, cs(Color.yellow, "隐藏内鬼职业"), false, draftModeShowRoles, false);
            draftModeHideNeutralRoles = CustomOption.Create(Types.General, cs(Color.yellow, "隐藏中立职业"), false, draftModeShowRoles, false);
            draftModeHideCrewRoles = CustomOption.Create(Types.General, cs(Color.yellow, "隐藏船员职业"), false, draftModeShowRoles, false);

            // Using new id's for the options to not break compatibilty with older versions

            crewmateRolesCountMin = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最少船员职业"), 15f, 0f, 15f, 1f, null, true, heading: "职业大小数量设置");
            crewmateRolesCountMax = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最多船员职业"), 15f, 0f, 15f, 1f);
            neutralRolesCountMin = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最少中立职业"), 15f, 0f, 15f, 1f);
            neutralRolesCountMax = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最多中立职业"), 15f, 0f, 15f, 1f);
            impostorRolesCountMin = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最少内鬼职业"), 15f, 0f, 15f, 1f);
            impostorRolesCountMax = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最多内鬼职业"), 15f, 0f, 15f, 1f);
            modifiersCountMin = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最少附加职业"), 15f, 0f, 15f, 1f);
            modifiersCountMax = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最多附加职业"), 15f, 0f, 15f, 1f);
            crewmateRolesFill = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "所有船员职业(忽略最少/最多值)"), false);

            mafiaSpawnRate = CustomOption.Create(Types.Impostor, cs(Janitor.color, "黑手党"), rates, null, true);
            janitorCooldown = CustomOption.Create(Types.Impostor, "清洁工技能冷却时间", 30f, 10f, 60f, 2.5f, mafiaSpawnRate);

            morphlingSpawnRate = CustomOption.Create(Types.Impostor, cs(Morphling.color, "化形者"), rates, null, true);
            morphlingCooldown = CustomOption.Create(Types.Impostor, "取样冷却时间", 30f, 10f, 60f, 2.5f, morphlingSpawnRate);
            morphlingDuration = CustomOption.Create(Types.Impostor, "化形持续时间", 10f, 1f, 20f, 0.5f, morphlingSpawnRate);

            camouflagerSpawnRate = CustomOption.Create(Types.Impostor, cs(Camouflager.color, "隐蔽者"), rates, null, true);
            camouflagerCooldown = CustomOption.Create(Types.Impostor, "隐蔽技能冷却时间", 30f, 10f, 60f, 2.5f, camouflagerSpawnRate);
            camouflagerDuration = CustomOption.Create(Types.Impostor, "隐蔽技能持续时间", 10f, 1f, 20f, 0.5f, camouflagerSpawnRate);

            vampireSpawnRate = CustomOption.Create(Types.Impostor, cs(Vampire.color, "吸血鬼"), rates, null, true);
            vampireKillDelay = CustomOption.Create(Types.Impostor, "吸血技能延迟击杀时间", 10f, 1f, 20f, 1f, vampireSpawnRate);
            vampireCooldown = CustomOption.Create(Types.Impostor, "吸血技能冷却时间", 30f, 10f, 60f, 2.5f, vampireSpawnRate);
            vampireCanKillNearGarlics = CustomOption.Create(Types.Impostor, "吸血鬼可以在大蒜范围内击杀", true, vampireSpawnRate);

            eraserSpawnRate = CustomOption.Create(Types.Impostor, cs(Eraser.color, "抹除者"), rates, null, true);
            eraserCooldown = CustomOption.Create(Types.Impostor, "抹除技能冷却时间", 30f, 10f, 120f, 5f, eraserSpawnRate);
            eraserCanEraseAnyone = CustomOption.Create(Types.Impostor, "可以抹除所有人的职业(包括队友）", false, eraserSpawnRate);

            tricksterSpawnRate = CustomOption.Create(Types.Impostor, cs(Trickster.color, "骗术师"), rates, null, true);
            tricksterPlaceBoxCooldown = CustomOption.Create(Types.Impostor, "放置盒子技能冷却时间", 10f, 2.5f, 30f, 2.5f, tricksterSpawnRate);
            tricksterLightsOutCooldown = CustomOption.Create(Types.Impostor, "熄灯技能冷却时间", 30f, 10f, 60f, 5f, tricksterSpawnRate);
            tricksterLightsOutDuration = CustomOption.Create(Types.Impostor, "熄灯技能持续时间", 15f, 5f, 60f, 2.5f, tricksterSpawnRate);

            cleanerSpawnRate = CustomOption.Create(Types.Impostor, cs(Cleaner.color, "清理者"), rates, null, true);
            cleanerCooldown = CustomOption.Create(Types.Impostor, "清理技能冷却时间", 30f, 10f, 60f, 2.5f, cleanerSpawnRate);

            warlockSpawnRate = CustomOption.Create(Types.Impostor, cs(Cleaner.color, "术士"), rates, null, true);
            warlockCooldown = CustomOption.Create(Types.Impostor, "诅咒技能冷却时间", 30f, 10f, 60f, 2.5f, warlockSpawnRate);
            warlockRootTime = CustomOption.Create(Types.Impostor, "术士定身时间", 5f, 0f, 15f, 1f, warlockSpawnRate);

            bountyHunterSpawnRate = CustomOption.Create(Types.Impostor, cs(BountyHunter.color, "赏金猎人"), rates, null, true);
            bountyHunterBountyDuration = CustomOption.Create(Types.Impostor, "赏金目标切换时间", 60f, 10f, 180f, 10f, bountyHunterSpawnRate);
            bountyHunterReducedCooldown = CustomOption.Create(Types.Impostor, "击杀赏金目标后击杀技能冷却时间", 2.5f, 0f, 30f, 2.5f, bountyHunterSpawnRate);
            bountyHunterPunishmentTime = CustomOption.Create(Types.Impostor, "击杀非赏金目标后击杀技能冷却时间", 20f, 0f, 60f, 2.5f, bountyHunterSpawnRate);
            bountyHunterShowArrow = CustomOption.Create(Types.Impostor, "显示指向赏金目标的箭头", true, bountyHunterSpawnRate);
            bountyHunterArrowUpdateIntervall = CustomOption.Create(Types.Impostor, "赏金目标位置更新延迟", 15f, 2.5f, 60f, 2.5f, bountyHunterShowArrow);

            witchSpawnRate = CustomOption.Create(Types.Impostor, cs(Witch.color, "女巫"), rates, null, true);
            witchCooldown = CustomOption.Create(Types.Impostor, "女巫下咒技能冷却时间", 30f, 10f, 120f, 5f, witchSpawnRate);
            witchAdditionalCooldown = CustomOption.Create(Types.Impostor, "女巫技能冷却增加时间", 10f, 0f, 60f, 5f, witchSpawnRate);
            witchCanSpellAnyone = CustomOption.Create(Types.Impostor, "女巫可以下咒所有人", false, witchSpawnRate);
            witchSpellCastingDuration = CustomOption.Create(Types.Impostor, "女巫下咒技能持续时间", 1f, 0f, 10f, 1f, witchSpawnRate);
            witchTriggerBothCooldowns = CustomOption.Create(Types.Impostor, "女巫下咒和击杀共用冷却时间", true, witchSpawnRate);
            witchVoteSavesTargets = CustomOption.Create(Types.Impostor, "女巫如果被投出则被诅咒者获救", true, witchSpawnRate);

            ninjaSpawnRate = CustomOption.Create(Types.Impostor, cs(Ninja.color, "忍者"), rates, null, true);
            ninjaCooldown = CustomOption.Create(Types.Impostor, "忍者选定目标冷却时间", 30f, 10f, 120f, 5f, ninjaSpawnRate);
            ninjaKnowsTargetLocation = CustomOption.Create(Types.Impostor, "忍者可知目标的位置", true, ninjaSpawnRate);
            ninjaTraceTime = CustomOption.Create(Types.Impostor, "完成刺杀后树叶跟踪持续时间", 5f, 1f, 20f, 0.5f, ninjaSpawnRate);
            ninjaTraceColorTime = CustomOption.Create(Types.Impostor, "树叶褪色的时间", 2f, 0f, 20f, 0.5f, ninjaSpawnRate);
            ninjaInvisibleDuration = CustomOption.Create(Types.Impostor, "忍者隐身时间", 3f, 0f, 20f, 1f, ninjaSpawnRate);

            bomberSpawnRate = CustomOption.Create(Types.Impostor, cs(Bomber.color, "爆炸狂"), rates, null, true);
            bomberBombDestructionTime = CustomOption.Create(Types.Impostor, "炸弹销毁时间", 20f, 2.5f, 120f, 2.5f, bomberSpawnRate);
            bomberBombDestructionRange = CustomOption.Create(Types.Impostor, "炸弹破坏范围", 50f, 5f, 150f, 5f, bomberSpawnRate);
            bomberBombHearRange = CustomOption.Create(Types.Impostor, "炸弹爆炸范围", 60f, 5f, 150f, 5f, bomberSpawnRate);
            bomberDefuseDuration = CustomOption.Create(Types.Impostor, "拆弹持续时间", 3f, 0.5f, 30f, 0.5f, bomberSpawnRate);
            bomberBombCooldown = CustomOption.Create(Types.Impostor, "炸弹技能冷却时间", 15f, 2.5f, 30f, 2.5f, bomberSpawnRate);
            bomberBombActiveAfter = CustomOption.Create(Types.Impostor, "炸弹激活所需时间", 3f, 0.5f, 15f, 0.5f, bomberSpawnRate);

            yoyoSpawnRate = CustomOption.Create(Types.Impostor, cs(Yoyo.color, "悠悠球"), rates, null, true);
            yoyoBlinkDuration = CustomOption.Create(Types.Impostor, "瞬移持续时间", 20f, 2.5f, 120f, 2.5f, yoyoSpawnRate);
            yoyoMarkCooldown = CustomOption.Create(Types.Impostor, "标记位置冷却时间", 20f, 2.5f, 120f, 2.5f, yoyoSpawnRate);
            yoyoMarkStaysOverMeeting = CustomOption.Create(Types.Impostor, "标记的位置会议结束后保留", true, yoyoSpawnRate);
            yoyoHasAdminTable = CustomOption.Create(Types.Impostor, "拥有便携式地图", true, yoyoSpawnRate);
            yoyoAdminTableCooldown = CustomOption.Create(Types.Impostor, "便携式地图冷却时间", 20f, 2.5f, 120f, 2.5f, yoyoHasAdminTable);
            yoyoSilhouetteVisibility = CustomOption.Create(Types.Impostor, "人影可见度", new string[] { "0%", "10%", "20%", "30%", "40%", "50%" }, yoyoSpawnRate);

            minerSpawnRate = CustomOption.Create(Types.Impostor, cs(Miner.color, "矿工"), rates, null, true);
            minerCooldown = CustomOption.Create(Types.Impostor, "挖掘冷却时间", 25f, 10f, 60f, 2.5f, minerSpawnRate);

            blackmailerSpawnRate = CustomOption.Create(Types.Impostor, cs(Blackmailer.color, "勒索者"), rates, null, true);
            blackmailerCooldown = CustomOption.Create(Types.Impostor, "勒索冷却时间", 30f, 5f, 120f, 5f, blackmailerSpawnRate);
            guesserSpawnRate = CustomOption.Create(Types.Neutral, cs(Guesser.color, "赌怪"), rates, null, true);

            guesserIsImpGuesserRate = CustomOption.Create(Types.Neutral, "赌怪是内鬼的机率", rates, guesserSpawnRate);
            guesserNumberOfShots = CustomOption.Create(Types.Neutral, "赌怪的赌杀次数", 2f, 1f, 15f, 1f, guesserSpawnRate);
            guesserHasMultipleShotsPerMeeting = CustomOption.Create(Types.Neutral, "赌怪可以在会议上多次赌杀", false, guesserSpawnRate);
            guesserKillsThroughShield = CustomOption.Create(Types.Neutral, "赌怪赌杀时忽略医生的盾", true, guesserSpawnRate);
            guesserEvilCanKillSpy = CustomOption.Create(Types.Neutral, "邪恶的赌怪可以赌杀卧底", true, guesserSpawnRate);
            guesserSpawnBothRate = CustomOption.Create(Types.Neutral, "两个赌怪的机率", rates, guesserSpawnRate);
            guesserCantGuessSnitchIfTaksDone = CustomOption.Create(Types.Neutral, "赌怪无法赌杀完成任务的告密者", true, guesserSpawnRate);

            jesterSpawnRate = CustomOption.Create(Types.Neutral, cs(Jester.color, "小丑"), rates, null, true);
            jesterCanCallEmergency = CustomOption.Create(Types.Neutral, "小丑可以召开紧急会议", true, jesterSpawnRate);
            jesterHasImpostorVision = CustomOption.Create(Types.Neutral, "小丑有内鬼的视野", false, jesterSpawnRate);
            arsonistSpawnRate = CustomOption.Create(Types.Neutral, cs(Arsonist.color, "纵火犯"), rates, null, true);
            arsonistCooldown = CustomOption.Create(Types.Neutral, "浇油技能冷却时间", 12.5f, 2.5f, 60f, 2.5f, arsonistSpawnRate);
            arsonistDuration = CustomOption.Create(Types.Neutral, "浇油技能持续时间", 3f, 1f, 10f, 1f, arsonistSpawnRate);

            jackalSpawnRate = CustomOption.Create(Types.Neutral, cs(Jackal.color, "豺狼"), rates, null, true);
            jackalKillCooldown = CustomOption.Create(Types.Neutral, "豺狼/跟班的击杀冷却时间", 30f, 10f, 60f, 2.5f, jackalSpawnRate);
            jackalCreateSidekickCooldown = CustomOption.Create(Types.Neutral, "豺狼招募技能冷却时间", 30f, 10f, 60f, 2.5f, jackalSpawnRate);
            jackalCanUseVents = CustomOption.Create(Types.Neutral, "豺狼可以使用管道", true, jackalSpawnRate);
            sidekickCanSabotageLights = CustomOption.Create(Types.Neutral, "跟班可以破坏灯光", true, jackalSpawnRate);
            jackalCanCreateSidekick = CustomOption.Create(Types.Neutral, "豺狼可以招募一个跟班", false, jackalSpawnRate);
            jackalCanSabotageLights = CustomOption.Create(Types.Neutral, "豺狼可以破坏灯光", true, jackalSpawnRate);
            sidekickPromotesToJackal = CustomOption.Create(Types.Neutral, "跟班在豺狼死后晋升豺狼", false, jackalCanCreateSidekick);
            sidekickCanKill = CustomOption.Create(Types.Neutral, "跟班可以击杀", false, jackalCanCreateSidekick);
            sidekickCanUseVents = CustomOption.Create(Types.Neutral, "跟班可以使用管道", true, jackalCanCreateSidekick);
            jackalPromotedFromSidekickCanCreateSidekick = CustomOption.Create(Types.Neutral, "晋升的跟班可以拥有招募技能", true, sidekickPromotesToJackal);
            jackalCanCreateSidekickFromImpostor = CustomOption.Create(Types.Neutral, "豺狼可以招募内鬼为自己的跟班", true, jackalCanCreateSidekick);
            jackalAndSidekickHaveImpostorVision = CustomOption.Create(Types.Neutral, "豺狼和跟班拥有内鬼的视野", false, jackalSpawnRate);

            vultureSpawnRate = CustomOption.Create(Types.Neutral, cs(Vulture.color, "秃鹫"), rates, null, true);
            vultureCooldown = CustomOption.Create(Types.Neutral, "吞噬技能冷却时间", 15f, 10f, 60f, 2.5f, vultureSpawnRate);
            vultureNumberToWin = CustomOption.Create(Types.Neutral, "需要吃掉的尸体数量", 4f, 1f, 10f, 1f, vultureSpawnRate);
            vultureCanUseVents = CustomOption.Create(Types.Neutral, "秃鹫可以使用管道", true, vultureSpawnRate);
            vultureShowArrows = CustomOption.Create(Types.Neutral, "秃鹫有指向尸体的箭头", true, vultureSpawnRate);

            lawyerSpawnRate = CustomOption.Create(Types.Neutral, cs(Lawyer.color, "律师"), rates, null, true);
            lawyerIsProsecutorChance = CustomOption.Create(Types.Neutral, "检察官的可能性", rates, lawyerSpawnRate);
            lawyerVision = CustomOption.Create(Types.Neutral, "视野大小", 1f, 0.25f, 3f, 0.25f, lawyerSpawnRate);
            lawyerKnowsRole = CustomOption.Create(Types.Neutral, "律师/检察官知道目标的职业", false, lawyerSpawnRate);
            lawyerCanCallEmergency = CustomOption.Create(Types.Neutral, "律师/检察官可以召开紧急会议", true, lawyerSpawnRate);
            lawyerTargetCanBeJester = CustomOption.Create(Types.Neutral, "律师/检察官的客户可以是小丑", false, lawyerSpawnRate);
            pursuerCooldown = CustomOption.Create(Types.Neutral, "起诉人空包弹技能冷却时间", 30f, 5f, 60f, 2.5f, lawyerSpawnRate);
            pursuerBlanksNumber = CustomOption.Create(Types.Neutral, "起诉人空包弹的数量", 5f, 1f, 20f, 1f, lawyerSpawnRate);

            mayorSpawnRate = CustomOption.Create(Types.Crewmate, cs(Mayor.color, "市长"), rates, null, true);
            mayorCanSeeVoteColors = CustomOption.Create(Types.Crewmate, "市长可以看见投票者的颜色", false, mayorSpawnRate);
            mayorTasksNeededToSeeVoteColors = CustomOption.Create(Types.Crewmate, "查看投票颜色所需完成的任务", 5f, 0f, 20f, 1f, mayorCanSeeVoteColors);
            mayorMeetingButton = CustomOption.Create(Types.Crewmate, "启用便携式移动紧急会议", true, mayorSpawnRate);
            mayorMaxRemoteMeetings = CustomOption.Create(Types.Crewmate, "紧急会议的次数", 1f, 1f, 5f, 1f, mayorMeetingButton);
            mayorChooseSingleVote = CustomOption.Create(Types.Crewmate, "市长可以选择单票", new string[] { "关闭", "开启(会议之前)", "开启(会议后)" }, mayorSpawnRate);

            engineerSpawnRate = CustomOption.Create(Types.Crewmate, cs(Engineer.color, "工程师"), rates, null, true);
            engineerNumberOfFixes = CustomOption.Create(Types.Crewmate, "修理技能次数", 1f, 1f, 3f, 1f, engineerSpawnRate);
            engineerHighlightForImpostors = CustomOption.Create(Types.Crewmate, "内鬼可以看见工程师在管道里", true, engineerSpawnRate);
            engineerHighlightForTeamJackal = CustomOption.Create(Types.Crewmate, "豺狼和跟班可以看见工程师在管道里", true, engineerSpawnRate);

            sheriffSpawnRate = CustomOption.Create(Types.Crewmate, cs(Sheriff.color, "警长"), rates, null, true);
            sheriffCooldown = CustomOption.Create(Types.Crewmate, "击杀冷却时间", 30f, 10f, 60f, 2.5f, sheriffSpawnRate);
            sheriffCanKillNeutrals = CustomOption.Create(Types.Crewmate, "警长可以击杀中立阵营的玩家", false, sheriffSpawnRate);
            deputySpawnRate = CustomOption.Create(Types.Crewmate, cs(Sheriff.color, "捕快"), rates, sheriffSpawnRate);
            deputyNumberOfHandcuffs = CustomOption.Create(Types.Crewmate, "戴上手铐技能数量", 3f, 1f, 10f, 1f, deputySpawnRate);
            deputyHandcuffCooldown = CustomOption.Create(Types.Crewmate, "戴上手铐冷却时间", 30f, 10f, 60f, 2.5f, deputySpawnRate);
            deputyHandcuffDuration = CustomOption.Create(Types.Crewmate, "戴上手铐持续时间", 15f, 5f, 60f, 2.5f, deputySpawnRate);
            deputyKnowsSheriff = CustomOption.Create(Types.Crewmate, "警长和捕快可以相识", true, deputySpawnRate);
            deputyGetsPromoted = CustomOption.Create(Types.Crewmate, "警长死后捕快可以晋升警长", new string[] { "关闭", "开启(立即)", "开启(会议后)" }, deputySpawnRate);
            deputyKeepsHandcuffs = CustomOption.Create(Types.Crewmate, "捕快晋升后保留戴上手铐技能", true, deputyGetsPromoted);

            lighterSpawnRate = CustomOption.Create(Types.Crewmate, cs(Lighter.color, "执灯人"), rates, null, true);
            lighterModeLightsOnVision = CustomOption.Create(Types.Crewmate, "灯光开启视野", 1.5f, 0.25f, 5f, 0.25f, lighterSpawnRate);
            lighterModeLightsOffVision = CustomOption.Create(Types.Crewmate, "灯光关闭视野", 0.5f, 0.25f, 5f, 0.25f, lighterSpawnRate);
            lighterFlashlightWidth = CustomOption.Create(Types.Crewmate, "灯光视野宽度", 0.3f, 0.1f, 1f, 0.1f, lighterSpawnRate);

            detectiveSpawnRate = CustomOption.Create(Types.Crewmate, cs(Detective.color, "侦探"), rates, null, true);
            detectiveAnonymousFootprints = CustomOption.Create(Types.Crewmate, "匿名脚印", false, detectiveSpawnRate);
            detectiveFootprintIntervall = CustomOption.Create(Types.Crewmate, "脚印间隔", 0.5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
            detectiveFootprintDuration = CustomOption.Create(Types.Crewmate, "脚印持续时间", 5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
            detectiveReportNameDuration = CustomOption.Create(Types.Crewmate, "在一定的时间内侦探报告有凶手的名字", 0, 0, 60, 2.5f, detectiveSpawnRate);
            detectiveReportColorDuration = CustomOption.Create(Types.Crewmate, "在一定的时间内侦探报告有颜色类型", 20, 0, 120, 2.5f, detectiveSpawnRate);

            timeMasterSpawnRate = CustomOption.Create(Types.Crewmate, cs(TimeMaster.color, "时间之主"), rates, null, true);
            timeMasterCooldown = CustomOption.Create(Types.Crewmate, "时间之盾冷却时间", 30f, 10f, 120f, 2.5f, timeMasterSpawnRate);
            timeMasterShieldDuration = CustomOption.Create(Types.Crewmate, "时间之盾持续时间", 3f, 1f, 20f, 1f, timeMasterSpawnRate);
            timeMasterRewindTime = CustomOption.Create(Types.Crewmate, "时间之盾倒退时间", 3f, 1f, 10f, 1f, timeMasterSpawnRate);
            timeMasterCanRewind = CustomOption.Create(Types.Crewmate, "可以使用时间回溯", true, timeMasterSpawnRate);
            timeMasterRewindCooldown = CustomOption.Create(Types.Crewmate, "时间回溯冷却时间", 30f, 2.5f, 60f, 2.5f, timeMasterCanRewind);
            timeMasterReviveDuringRewind = CustomOption.Create(Types.Crewmate, "在回溯期间复活玩家", true, timeMasterCanRewind);

            medicSpawnRate = CustomOption.Create(Types.Crewmate, cs(Medic.color, "医生"), rates, null, true);
            medicShowShielded = CustomOption.Create(Types.Crewmate, "所有人可见护盾保护的玩家", new string[] { "所有人可见", "被保护者和医生可见", "仅医生可见" }, medicSpawnRate);
            medicShowAttemptToShielded = CustomOption.Create(Types.Crewmate, "被护盾保护的玩家如被击杀被保护玩家会有提示", false, medicSpawnRate);
            medicSetOrShowShieldAfterMeeting = CustomOption.Create(Types.Crewmate, "护盾将被激活", new string[] { "立即", "会议后\n立即可见", "会议后" }, medicSpawnRate);
            medicShowAttemptToMedic = CustomOption.Create(Types.Crewmate, "被护盾保护的玩家如被击杀医生会有提示", false, medicSpawnRate);
            medicSetShieldAfterMeeting = CustomOption.Create(Types.Crewmate, "医生在会议后启用护盾", false, medicSpawnRate);

            swapperSpawnRate = CustomOption.Create(Types.Crewmate, cs(Swapper.color, "换票师"), rates, null, true);
            swapperCanCallEmergency = CustomOption.Create(Types.Crewmate, "换票师可以开启紧急会议", false, swapperSpawnRate);
            swapperCanOnlySwapOthers = CustomOption.Create(Types.Crewmate, "换票师只能交换他人的票数", false, swapperSpawnRate);
            swapperSwapsNumber = CustomOption.Create(Types.Crewmate, "初始换票充能", 1f, 0f, 5f, 1f, swapperSpawnRate);
            swapperRechargeTasksNumber = CustomOption.Create(Types.Crewmate, "充能所需的任务数量", 2f, 1f, 10f, 1f, swapperSpawnRate);

            seerSpawnRate = CustomOption.Create(Types.Crewmate, cs(Seer.color, "灵媒"), rates, null, true);
            seerMode = CustomOption.Create(Types.Crewmate, "灵媒在游戏中的技能", new string[] { "显示死亡闪光 + 灵魂", "只显示死亡闪光", "只显示灵魂" }, seerSpawnRate);
            seerLimitSoulDuration = CustomOption.Create(Types.Crewmate, "灵媒可看到灵魂", false, seerSpawnRate);
            seerSoulDuration = CustomOption.Create(Types.Crewmate, "灵媒看到灵魂的持续时间", 15f, 0f, 120f, 5f, seerLimitSoulDuration);

            hackerSpawnRate = CustomOption.Create(Types.Crewmate, cs(Hacker.color, "黑客"), rates, null, true);
            hackerCooldown = CustomOption.Create(Types.Crewmate, "黑入技能冷却时间", 30f, 5f, 60f, 5f, hackerSpawnRate);
            hackerHackeringDuration = CustomOption.Create(Types.Crewmate, "黑入技能持续时间", 10f, 2.5f, 60f, 2.5f, hackerSpawnRate);
            hackerOnlyColorType = CustomOption.Create(Types.Crewmate, "黑客只能在管理室看到玩家颜色", false, hackerSpawnRate);
            hackerToolsNumber = CustomOption.Create(Types.Crewmate, "最多移动地图的充能次数", 5f, 1f, 30f, 1f, hackerSpawnRate);
            hackerRechargeTasksNumber = CustomOption.Create(Types.Crewmate, "地图充能所需的任务数", 2f, 1f, 5f, 1f, hackerSpawnRate);
            hackerNoMove = CustomOption.Create(Types.Crewmate, "在使用移动地图时无法移动", true, hackerSpawnRate);

            trackerSpawnRate = CustomOption.Create(Types.Crewmate, cs(Tracker.color, "追踪者"), rates, null, true);
            trackerUpdateIntervall = CustomOption.Create(Types.Crewmate, "追踪者箭头更新延迟", 5f, 1f, 30f, 1f, trackerSpawnRate);
            trackerResetTargetAfterMeeting = CustomOption.Create(Types.Crewmate, "追踪者在会议后重新追踪", false, trackerSpawnRate);
            trackerCanTrackCorpses = CustomOption.Create(Types.Crewmate, "追踪者可以追踪尸体", true, trackerSpawnRate);
            trackerCorpsesTrackingCooldown = CustomOption.Create(Types.Crewmate, "追踪尸体冷却时间", 30f, 5f, 120f, 5f, trackerCanTrackCorpses);
            trackerCorpsesTrackingDuration = CustomOption.Create(Types.Crewmate, "追踪尸体持续时间", 5f, 2.5f, 30f, 2.5f, trackerCanTrackCorpses);
            trackerTrackingMethod = CustomOption.Create(Types.Crewmate, "追踪者如何获取目标位置", new string[] { "1.仅箭头", "2.仅接近检测器", "1 + 2" }, trackerSpawnRate);

            snitchSpawnRate = CustomOption.Create(Types.Crewmate, cs(Snitch.color, "告密者"), rates, null, true);
            snitchLeftTasksForReveal = CustomOption.Create(Types.Crewmate, "当任务数剩下多少时执刃者得到具体位置", 5f, 0f, 25f, 1f, snitchSpawnRate);
            snitchMode = CustomOption.Create(Types.Crewmate, "提供的信息模式", new string[] { "1.聊天", "2.地图", "1 + 2" }, snitchSpawnRate);
            snitchTargets = CustomOption.Create(Types.Crewmate, "告密目标", new string[] { "所有内鬼 & 中立玩家", "带刀玩家" }, snitchSpawnRate);

            spySpawnRate = CustomOption.Create(Types.Crewmate, cs(Spy.color, "卧底"), rates, null, true);
            spyCanDieToSheriff = CustomOption.Create(Types.Crewmate, "卧底可以反弹警长的击杀", false, spySpawnRate);
            spyImpostorsCanKillAnyone = CustomOption.Create(Types.Crewmate, "当有卧底时内鬼可以击杀所有人(包括队友)", true, spySpawnRate);
            spyCanEnterVents = CustomOption.Create(Types.Crewmate, "卧底可以使用管道", false, spySpawnRate);
            spyHasImpostorVision = CustomOption.Create(Types.Crewmate, "卧底有内鬼视野", false, spySpawnRate);

            portalmakerSpawnRate = CustomOption.Create(Types.Crewmate, cs(Portalmaker.color, "传送师"), rates, null, true);
            portalmakerCooldown = CustomOption.Create(Types.Crewmate, "搭建传送门技能冷却时间", 30f, 10f, 60f, 2.5f, portalmakerSpawnRate);
            portalmakerUsePortalCooldown = CustomOption.Create(Types.Crewmate, "使用传送门冷却时间", 30f, 10f, 60f, 2.5f, portalmakerSpawnRate);
            portalmakerLogOnlyColorType = CustomOption.Create(Types.Crewmate, "传送师仅日志显示颜色类型", true, portalmakerSpawnRate);
            portalmakerLogHasTime = CustomOption.Create(Types.Crewmate, "日志显示时间", true, portalmakerSpawnRate);
            portalmakerCanPortalFromAnywhere = CustomOption.Create(Types.Crewmate, "传送师可以从任何地方直达传送门处", true, portalmakerSpawnRate);

            securityGuardSpawnRate = CustomOption.Create(Types.Crewmate, cs(SecurityGuard.color, "保安"), rates, null, true);
            securityGuardCooldown = CustomOption.Create(Types.Crewmate, "保安技能冷却时间", 30f, 10f, 60f, 2.5f, securityGuardSpawnRate);
            securityGuardTotalScrews = CustomOption.Create(Types.Crewmate, "保安螺丝数量", 7f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardCamPrice = CustomOption.Create(Types.Crewmate, "每个监控所需螺丝数量", 2f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardVentPrice = CustomOption.Create(Types.Crewmate, "每个管道所需螺丝数量", 1f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardCamDuration = CustomOption.Create(Types.Crewmate, "保安技能持续时间", 10f, 2.5f, 60f, 2.5f, securityGuardSpawnRate);
            securityGuardCamMaxCharges = CustomOption.Create(Types.Crewmate, "螺丝最大充能", 5f, 1f, 30f, 1f, securityGuardSpawnRate);
            securityGuardCamRechargeTasksNumber = CustomOption.Create(Types.Crewmate, "便携式监控器充能所需的任务数", 3f, 1f, 10f, 1f, securityGuardSpawnRate);
            securityGuardNoMove = CustomOption.Create(Types.Crewmate, "在使用便携式监控器时无法移动", true, securityGuardSpawnRate);

            mediumSpawnRate = CustomOption.Create(Types.Crewmate, cs(Medium.color, "通灵师"), rates, null, true);
            mediumCooldown = CustomOption.Create(Types.Crewmate, "通灵技能冷却时间", 30f, 5f, 120f, 5f, mediumSpawnRate);
            mediumDuration = CustomOption.Create(Types.Crewmate, "通灵技能持续时间", 3f, 0f, 15f, 1f, mediumSpawnRate);
            mediumOneTimeUse = CustomOption.Create(Types.Crewmate, "每个灵魂只能被通灵一次", false, mediumSpawnRate);
            mediumChanceAdditionalInfo = CustomOption.Create(Types.Crewmate, "信息的机率 \n 其他信息", rates, mediumSpawnRate);

            thiefSpawnRate = CustomOption.Create(Types.Neutral, cs(Thief.color, "强盗"), rates, null, true);
            thiefCooldown = CustomOption.Create(Types.Neutral, "抢夺技能冷却时间", 30f, 5f, 120f, 5f, thiefSpawnRate);
            thiefCanKillSheriff = CustomOption.Create(Types.Neutral, "强盗可以击杀警长", true, thiefSpawnRate);
            thiefHasImpVision = CustomOption.Create(Types.Neutral, "强盗拥有内鬼的视野", true, thiefSpawnRate);
            thiefCanUseVents = CustomOption.Create(Types.Neutral, "强盗可以使用管道", true, thiefSpawnRate);
            thiefCanStealWithGuess = CustomOption.Create(Types.Neutral, "强盗可以通过赌杀得到职业(赌怪模式)", false, thiefSpawnRate);

            trapperSpawnRate = CustomOption.Create(Types.Crewmate, cs(Trapper.color, "猎人"), rates, null, true);
            trapperCooldown = CustomOption.Create(Types.Crewmate, "陷阱技能冷却时间", 30f, 5f, 120f, 5f, trapperSpawnRate);
            trapperMaxCharges = CustomOption.Create(Types.Crewmate, "最大陷阱所需的充能", 5f, 1f, 15f, 1f, trapperSpawnRate);
            trapperRechargeTasksNumber = CustomOption.Create(Types.Crewmate, "充能所需的任务数", 2f, 1f, 15f, 1f, trapperSpawnRate);
            trapperTrapNeededTriggerToReveal = CustomOption.Create(Types.Crewmate, "陷阱需要触发器才能揭示", 3f, 2f, 10f, 1f, trapperSpawnRate);
            trapperAnonymousMap = CustomOption.Create(Types.Crewmate, "显示匿名地图", false, trapperSpawnRate);
            trapperInfoType = CustomOption.Create(Types.Crewmate, "陷阱信息类型", new string[] { "职业", "正义/邪恶的职业", "玩家名字" }, trapperSpawnRate);
            trapperTrapDuration = CustomOption.Create(Types.Crewmate, "陷阱持续时间", 5f, 1f, 15f, 1f, trapperSpawnRate);
            // Modifier (1000 - 1999)
            //modifiersAreHidden = CustomOption.Create(1009, Types.Modifier, cs(Color.yellow, "死后隐藏附加职业"), true, null, true); 歌姬farewell翻译错了
            modifiersAreHidden = CustomOption.Create(Types.Modifier, cs(Color.yellow, "隐藏VIP, 诱饵 & 溅血者"), true, null, true, heading: cs(Color.yellow, "死后隐藏附加职业效果"));

            modifierBloody = CustomOption.Create(Types.Modifier, cs(Bloody.color, "溅血者"), rates, null, true);
            modifierBloodyQuantity = CustomOption.Create(Types.Modifier, "溅血者数量", ratesModifier, modifierBloody);
            modifierBloodyDuration = CustomOption.Create(Types.Modifier, "血迹持续时间", 10f, 3f, 60f, 1f, modifierBloody);

            modifierAntiTeleport = CustomOption.Create(Types.Modifier, cs(AntiTeleport.color, "厄运儿"), rates, null, true);
            modifierAntiTeleportQuantity = CustomOption.Create(Types.Modifier, "厄运儿数量", ratesModifier, modifierAntiTeleport);

            modifierTieBreaker = CustomOption.Create(Types.Modifier, cs(Tiebreaker.color, "破平者"), rates, null, true);

            modifierBait = CustomOption.Create(Types.Modifier, cs(Bait.color, "诱饵"), rates, null, true);
            modifierBaitQuantity = CustomOption.Create(Types.Modifier, "诱饵数量", ratesModifier, modifierBait);
            modifierBaitReportDelayMin = CustomOption.Create(Types.Modifier, "诱饵报告延迟最小值", 0f, 0f, 10f, 1f, modifierBait);
            modifierBaitReportDelayMax = CustomOption.Create(Types.Modifier, "诱饵报告延迟最大值", 0f, 0f, 10f, 1f, modifierBait);
            modifierBaitShowKillFlash = CustomOption.Create(Types.Modifier, "用闪光警告凶手", true, modifierBait);

            modifierLover = CustomOption.Create(Types.Modifier, cs(Lovers.color, "恋人"), rates, null, true);
            modifierLoverImpLoverRate = CustomOption.Create(Types.Modifier, "一对内鬼恋人的机率", rates, modifierLover);
            modifierLoverBothDie = CustomOption.Create(Types.Modifier, "恋人同生共死", true, modifierLover);
            modifierLoverEnableChat = CustomOption.Create(Types.Modifier, "启用恋人私密聊天", true, modifierLover);

            modifierSunglasses = CustomOption.Create(Types.Modifier, cs(Sunglasses.color, "太阳镜"), rates, null, true);
            modifierSunglassesQuantity = CustomOption.Create(Types.Modifier, "太阳镜数量", ratesModifier, modifierSunglasses);
            modifierSunglassesVision = CustomOption.Create(Types.Modifier, "太阳镜视野", new string[] { "-10%", "-20%", "-30%", "-40%", "-50%" }, modifierSunglasses);

            modifierMini = CustomOption.Create(Types.Modifier, cs(Mini.color, "迷你船员"), rates, null, true);
            modifierMiniGrowingUpDuration = CustomOption.Create(Types.Modifier, "迷你船员成长时间", 400f, 100f, 1500f, 100f, modifierMini);
            modifierMiniGrowingUpInMeeting = CustomOption.Create(Types.Modifier, "迷你船员在会议中成长", true, modifierMini);
            if (Utilities.EventUtility.canBeEnabled || Utilities.EventUtility.isEnabled)
            {
                eventKicksPerRound = CustomOption.Create(Types.Modifier, cs(Color.green, "迷你船员最大可承受踢出次数"), 4f, 0f, 14f, 1f, modifierMini);
                eventHeavyAge = CustomOption.Create(Types.Modifier, cs(Color.green, "迷你船员成年年龄"), 12f, 6f, 18f, 0.5f, modifierMini);
                eventReallyNoMini = CustomOption.Create(Types.Modifier, cs(Color.green, "不是真的迷你船员:("), false, modifierMini, invertedParent: true);
            }
            modifierVip = CustomOption.Create(Types.Modifier, cs(Vip.color, "VIP"), rates, null, true);
            modifierVipQuantity = CustomOption.Create(Types.Modifier, "VIP数量", ratesModifier, modifierVip);
            modifierVipShowColor = CustomOption.Create(Types.Modifier, "显示团队颜色", true, modifierVip);

            modifierInvert = CustomOption.Create(Types.Modifier, cs(Invert.color, "酒鬼"), rates, null, true);
            modifierInvertQuantity = CustomOption.Create(Types.Modifier, "酒鬼数量", ratesModifier, modifierInvert);
            modifierInvertDuration = CustomOption.Create(Types.Modifier, "颠倒的会议次数", 3f, 1f, 15f, 1f, modifierInvert);

            modifierChameleon = CustomOption.Create(Types.Modifier, cs(Chameleon.color, "变色龙"), rates, null, true);
            modifierChameleonQuantity = CustomOption.Create(Types.Modifier, "变色龙数量", ratesModifier, modifierChameleon);
            modifierChameleonHoldDuration = CustomOption.Create(Types.Modifier, "变色开始时间", 3f, 1f, 10f, 0.5f, modifierChameleon);
            modifierChameleonFadeDuration = CustomOption.Create(Types.Modifier, "透明持续时间", 1f, 0.25f, 10f, 0.25f, modifierChameleon);
            modifierChameleonMinVisibility = CustomOption.Create(Types.Modifier, "最低可见度", new string[] { "0%", "10%", "20%", "30%", "40%", "50%" }, modifierChameleon);

            modifierShifter = CustomOption.Create(Types.Modifier, cs(Shifter.color, "交换师"), rates, null, true);
            modifierShifterShiftsMedicShield = CustomOption.Create(Types.Modifier, "可以交换医生的护盾", false, modifierShifter);

            modifierArmored = CustomOption.Create(Types.Modifier, cs(Armored.color, "装甲兵"), rates, null, true);

            modifierDisperser = CustomOption.Create(Types.Modifier, cs(Color.red, "分散者"), rates, null, true);
            modifierDisperserCooldown = CustomOption.Create(Types.Modifier, cs(Color.red, "分散技能冷却时间"), 30f, 10f, 60f, 2.5f, modifierDisperser);
            modifierDisperserNumberOfUses = CustomOption.Create(Types.Modifier, cs(Color.red, "分散技能次数"), 1, 1, 10, 1, modifierDisperser);

            // Guesser Gamemode (2000 - 2999)
            guesserGamemodeCrewNumber = CustomOption.Create(Types.Guesser, cs(Guesser.color, "船员们的赌杀次数"), 15f, 0f, 15f, 1f, null, true, heading: "赌杀次数");
            guesserGamemodeNeutralNumber = CustomOption.Create(Types.Guesser, cs(Guesser.color, "中立们的赌杀次数"), 15f, 0f, 15f, 1f, null);
            guesserGamemodeImpNumber = CustomOption.Create(Types.Guesser, cs(Guesser.color, "内鬼们的赌杀次数"), 15f, 0f, 15f, 1f, null);
            guesserForceJackalGuesser = CustomOption.Create(Types.Guesser, "强制豺狼为赌怪", false, null, true, heading: "强制赌怪");
            guesserGamemodeSidekickIsAlwaysGuesser = CustomOption.Create(Types.Guesser, "设置跟班为赌怪", false, null);
            guesserForceThiefGuesser = CustomOption.Create(Types.Guesser, "强制交换师为赌怪", false, null);
            guesserGamemodeHaveModifier = CustomOption.Create(Types.Guesser, "赌怪可以有附加职业", true, null, true, heading: "普通赌怪设置");
            guesserGamemodeNumberOfShots = CustomOption.Create(Types.Guesser, "赌怪的赌杀次数", 3f, 1f, 15f, 1f, null);
            guesserGamemodeHasMultipleShotsPerMeeting = CustomOption.Create(Types.Guesser, "赌怪可以在会议期间多次赌杀", false, null);
            guesserGamemodeCrewGuesserNumberOfTasks = CustomOption.Create(Types.Guesser, "对于船员赌怪\n启用赌杀所需做的任务数量", 0f, 0f, 15f, 1f, null);
            guesserGamemodeKillsThroughShield = CustomOption.Create(Types.Guesser, "赌杀可以无视医生的护盾", true, null);
            guesserGamemodeEvilCanKillSpy = CustomOption.Create(Types.Guesser, "邪恶赌怪可以赌杀卧底", true, null);
            guesserGamemodeCantGuessSnitchIfTaksDone = CustomOption.Create(Types.Guesser, "赌怪不能赌杀完成任务了的告密者", true, null);

            // Hide N Seek Gamemode (3000 - 3999)
            hideNSeekMap = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "地图"), new string[] { "骷髅舰", "米拉HQ", "波鲁斯", "高空飞艇", "真菌世界", "深海潜艇" }, null, true, onChange: () => { int map = hideNSeekMap.selection; if (map >= 3) map++; GameOptionsManager.Instance.currentNormalGameOptions.MapId = (byte)map; }, heading: "捉迷藏地图设置");
            hideNSeekHunterCount = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "猎人数量"), 1f, 1f, 3f, 1f, null, true, heading: "捉迷藏普通设置");
            hideNSeekKillCooldown = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "击杀冷却"), 10f, 2.5f, 60f, 2.5f);
            hideNSeekHunterVision = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "猎人视野"), 0.5f, 0.25f, 2f, 0.25f);
            hideNSeekHuntedVision = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "躲藏者视野"), 2f, 0.25f, 5f, 0.25f);
            hideNSeekCommonTasks = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "普通任务数"), 1f, 0f, 4f, 1f);
            hideNSeekShortTasks = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "短任务数"), 3f, 1f, 23f, 1f);
            hideNSeekLongTasks = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "长任务数"), 3f, 0f, 15f, 1f);
            hideNSeekTimer = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "计时器最小值"), 5f, 1f, 30f, 0.5f);
            hideNSeekTaskWin = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "可以任务获胜"), false);
            hideNSeekTaskPunish = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "完成任务减少的秒数"), 10f, 0f, 30f, 1f);
            hideNSeekCanSabotage = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "启用破坏"), false);
            hideNSeekHunterWaiting = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "猎人需要等待的时间"), 15f, 2.5f, 60f, 2.5f);

            hunterLightCooldown = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "猎人点灯冷却时间"), 30f, 5f, 60f, 1f, null, true, heading: "猎人点灯设置");
            hunterLightDuration = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "猎人点灯持续时间"), 5f, 1f, 60f, 1f);
            hunterLightVision = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "猎人点灯视野"), 3f, 1f, 5f, 0.25f);
            hunterLightPunish = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "猎人点灯惩罚秒数"), 5f, 0f, 30f, 1f);
            hunterAdminCooldown = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "猎人地图冷却时间"), 30f, 5f, 60f, 1f);
            hunterAdminDuration = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "猎人地图使用时间"), 5f, 1f, 60f, 1f);
            hunterAdminPunish = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "猎人地图减少的秒数"), 5f, 0f, 30f, 1f);
            hunterArrowCooldown = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "猎人寻找冷却时间"), 30f, 5f, 60f, 1f);
            hunterArrowDuration = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "猎人寻找持续时间"), 5f, 0f, 60f, 1f);
            hunterArrowPunish = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "猎寻找踪惩罚秒数"), 5f, 0f, 30f, 1f);

            huntedShieldCooldown = CustomOption.Create(Types.HideNSeekRoles, cs(Color.gray, "躲藏者护盾冷却时间"), 30f, 5f, 60f, 1f, null, true, heading: "躲藏者护盾设置");
            huntedShieldDuration = CustomOption.Create(Types.HideNSeekRoles, cs(Color.gray, "躲藏者护盾持续时间"), 5f, 1f, 60f, 1f);
            huntedShieldRewindTime = CustomOption.Create(Types.HideNSeekRoles, cs(Color.gray, "躲藏者回溯时间"), 3f, 1f, 10f, 1f);
            huntedShieldNumber = CustomOption.Create(Types.HideNSeekRoles, cs(Color.gray, "躲藏者护盾数量"), 3f, 1f, 15f, 1f);

            // Prop Hunt General Options
            propHuntMap = CustomOption.Create(Types.PropHunt, cs(Color.yellow, "地图"), new string[] { "骷髅舰", "米拉总部", "波鲁斯", "飞艇地图", "真菌世界", "潜艇地图", "自定义地图" }, null, true, onChange: () => { int map = propHuntMap.selection; if (map >= 3) map++; GameOptionsManager.Instance.currentNormalGameOptions.MapId = (byte)map; }, heading: "变形狩猎地图设置");
            propHuntTimer = CustomOption.Create(Types.PropHunt, cs(Color.yellow, "计时器最小值"), 5f, 1f, 30f, 0.5f, null, true, heading: "变形狩猎普通设置");
            propHuntUnstuckCooldown = CustomOption.Create(Types.PropHunt, cs(Color.yellow, "穿墙冷却时间"), 30f, 2.5f, 60f, 2.5f);
            propHuntUnstuckDuration = CustomOption.Create(Types.PropHunt, cs(Color.yellow, "穿墙持续时间"), 2f, 1f, 60f, 1f);
            propHunterVision = CustomOption.Create(Types.PropHunt, cs(Color.yellow, "猎人视野"), 0.5f, 0.25f, 2f, 0.25f);
            propVision = CustomOption.Create(Types.PropHunt, cs(Color.yellow, "道具视野"), 2f, 0.25f, 5f, 0.25f);

            // Hunter Options
            propHuntNumberOfHunters = CustomOption.Create(Types.PropHunt, cs(Color.red, "猎人数量"), 1f, 1f, 5f, 1f, null, true, heading: "猎人设置");
            hunterInitialBlackoutTime = CustomOption.Create(Types.PropHunt, cs(Color.red, "猎人初始等待时间"), 10f, 5f, 20f, 1f);
            hunterMissCooldown = CustomOption.Create(Types.PropHunt, cs(Color.red, "错误击杀后的冷却时间"), 10f, 2.5f, 60f, 2.5f);
            hunterHitCooldown = CustomOption.Create(Types.PropHunt, cs(Color.red, "击杀后的冷却时间"), 10f, 2.5f, 60f, 2.5f);
            propHuntRevealCooldown = CustomOption.Create(Types.PropHunt, cs(Color.red, "变形冷却时间"), 30f, 10f, 90f, 2.5f);
            propHuntRevealDuration = CustomOption.Create(Types.PropHunt, cs(Color.red, "变形持续时间"), 5f, 1f, 60f, 1f);
            propHuntRevealPunish = CustomOption.Create(Types.PropHunt, cs(Color.red, "揭示惩罚时间"), 10f, 0f, 1800f, 5f);
            propHuntAdminCooldown = CustomOption.Create(Types.PropHunt, cs(Color.red, "猎人管理地图冷却时间"), 30f, 2.5f, 1800f, 2.5f);
            propHuntFindCooldown = CustomOption.Create(Types.PropHunt, cs(Color.red, "寻找冷却时间"), 60f, 2.5f, 1800f, 2.5f);
            propHuntFindDuration = CustomOption.Create(Types.PropHunt, cs(Color.red, "寻找持续时间"), 5f, 1f, 15f, 1f);

            // Prop Options
            propBecomesHunterWhenFound = CustomOption.Create(Types.PropHunt, cs(Palette.CrewmateBlue, "变形者被击杀后变成猎人"), false, null, true, heading: "躲藏者设置");
            propHuntInvisEnabled = CustomOption.Create(Types.PropHunt, cs(Palette.CrewmateBlue, "启用隐身技能"), true, null, true);
            propHuntInvisCooldown = CustomOption.Create(Types.PropHunt, cs(Palette.CrewmateBlue, "隐身冷却时间"), 120f, 10f, 1800f, 2.5f, propHuntInvisEnabled);
            propHuntInvisDuration = CustomOption.Create(Types.PropHunt, cs(Palette.CrewmateBlue, "隐身持续时间"), 5f, 1f, 30f, 1f, propHuntInvisEnabled);
            propHuntSpeedboostEnabled = CustomOption.Create(Types.PropHunt, cs(Palette.CrewmateBlue, "启用加速技能"), true, null, true);
            propHuntSpeedboostCooldown = CustomOption.Create(Types.PropHunt, cs(Palette.CrewmateBlue, "加速冷却时间"), 60f, 2.5f, 1800f, 2.5f, propHuntSpeedboostEnabled);
            propHuntSpeedboostDuration = CustomOption.Create(Types.PropHunt, cs(Palette.CrewmateBlue, "加速持续时间"), 5f, 1f, 15f, 1f, propHuntSpeedboostEnabled);
            propHuntSpeedboostSpeed = CustomOption.Create(Types.PropHunt, cs(Palette.CrewmateBlue, "加速提升速度"), 2f, 1.25f, 5f, 0.25f, propHuntSpeedboostEnabled);

            // Other options
            CanUseSwitchShipCostumeButton = CustomOption.Create(Types.General, "切换地图皮肤(仅支持骷髅舰)", false, null, true, heading: "其他设置");
            HostName = CustomOption.Create(Types.General, "启用TORE头衔", false);
            debugMode = CustomOption.Create(Types.General, "测试模式", false, null, true, heading: "测试模式");
            disableGameEnd = CustomOption.Create(Types.General, "游戏不结束", false, debugMode);
            maxNumberOfMeetings = CustomOption.Create(Types.General, "会议总次数 (不计入市长)", 10, 0, 15, 1, null, true, heading: "游戏设定");
            anyPlayerCanStopStart = CustomOption.Create(Types.General, "所有玩家都可以暂停开始游戏", false, null, false);
            blockSkippingInEmergencyMeetings = CustomOption.Create(Types.General, "禁用会议中弃票", false);
            noVoteIsSelfVote = CustomOption.Create(Types.General, "不投票看作投自己", false, blockSkippingInEmergencyMeetings);
            hidePlayerNames = CustomOption.Create(Types.General, "隐藏玩家名称", false);
            allowParallelMedBayScans = CustomOption.Create(Types.General, "允许同时进行扫描", false);
            shieldFirstKill = CustomOption.Create(Types.General, "下一轮保护首刀玩家", false);
            finishTasksBeforeHauntingOrZoomingOut = CustomOption.Create(Types.General, "在未完成所有任务前不可以使用鬼影悠悠及千里眼", true);
            deadImpsBlockSabotage = CustomOption.Create(Types.General, "死去的内鬼是否可以进行破坏活动", false, null, false);
            camsNightVision = CustomOption.Create(Types.General, "在灯光被关闭时监控使用黑夜模式", false, null, true, heading: "夜视模式");
            camsNoNightVisionIfImpVision = CustomOption.Create(Types.General, "拥有内鬼视野的玩家无视黑夜模式", false, camsNightVision, false);

            dynamicMap = CustomOption.Create(Types.General, "在随机一个地图上玩", false, null, true, heading: "随机地图");
            dynamicMapEnableSkeld = CustomOption.Create(Types.General, "骷髅舰", rates, dynamicMap, false);
            dynamicMapEnableMira = CustomOption.Create(Types.General, "米拉HQ", rates, dynamicMap, false);
            dynamicMapEnablePolus = CustomOption.Create(Types.General, "波鲁斯", rates, dynamicMap, false);
            dynamicMapEnableAirShip = CustomOption.Create(Types.General, "高空飞艇", rates, dynamicMap, false);
            dynamicMapEnableFungle = CustomOption.Create(Types.General, "真菌世界", rates, dynamicMap, false);
            dynamicMapEnableSubmerged = CustomOption.Create(Types.General, "深海潜艇", rates, dynamicMap, false);
            dynamicMapSeparateSettings = CustomOption.Create(Types.General, "启用地图的预设", false, dynamicMap, false);

            blockedRolePairings.Add((byte)RoleId.Vampire, new[] { (byte)RoleId.Warlock });
            blockedRolePairings.Add((byte)RoleId.Warlock, new[] { (byte)RoleId.Vampire });
            blockedRolePairings.Add((byte)RoleId.Spy, new[] { (byte)RoleId.Mini });
            blockedRolePairings.Add((byte)RoleId.Mini, new[] { (byte)RoleId.Spy });
            blockedRolePairings.Add((byte)RoleId.Vulture, new[] { (byte)RoleId.Cleaner });
            blockedRolePairings.Add((byte)RoleId.Cleaner, new[] { (byte)RoleId.Vulture });

        }
    }
}
