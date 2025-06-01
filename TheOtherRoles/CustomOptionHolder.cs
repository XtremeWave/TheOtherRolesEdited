using System.Collections.Generic;
using UnityEngine;
using static TheOtherRolesEdited.TheOtherRolesEdited;
using Types = TheOtherRolesEdited.CustomOption.CustomOptionType;

namespace TheOtherRolesEdited {
    public class CustomOptionHolder {
        public static string[] rates = new string[]{"0%", "10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%"};
        public static string[] ratesModifier = new string[]{"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" };
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
        
        //轮抽选职
        public static CustomOption isDraftMode;
        public static CustomOption draftModeAmountOfChoices;
        public static CustomOption draftModeTimeToChoose;
        public static CustomOption draftModeShowRoles;
        public static CustomOption draftModeHideImpRoles;
        public static CustomOption draftModeHideNeutralRoles;
        public static CustomOption draftModeHideCrewRoles;
        public static CustomOption draftModeCanChat;

        internal static Dictionary<byte, byte[]> blockedRolePairings = new Dictionary<byte, byte[]>();

        public static string cs(Color c, string s) {
            return string.Format("<color=#{0:X2}{1:X2}{2:X2}{3:X2}>{4}</color>", ToByte(c.r), ToByte(c.g), ToByte(c.b), ToByte(c.a), s);
        }
 
        private static byte ToByte(float f) {
            f = Mathf.Clamp01(f);
            return (byte)(f * 255);
        }

        public static bool isMapSelectionOption(CustomOption option) {
            return option == CustomOptionHolder.propHuntMap && option == CustomOptionHolder.hideNSeekMap;
        }

        public static void Load()
        {
            CustomOption.vanillaSettings = TheOtherRolesEditedPlugin.Instance.Config.Bind("Preset0", "VanillaOptions", "");

            // Role Options
            presetSelection = CustomOption.Create(0, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "预设"), presets, null, true, heading: "游戏预设");
            activateRoles = CustomOption.Create(1, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "启用模组角色并禁止使用原版角色"), true, null, true, heading: "模组选项");

            if (Utilities.EventUtility.canBeEnabled) enableEventMode = CustomOption.Create(10423, Types.General, cs(Color.green, "启用特别模式"), true, null, true, heading: "特别模式");

            isDraftMode = CustomOption.Create(600, Types.General, cs(Color.yellow, "启用轮抽选职模式"), false, null, true, null, "轮抽选职");
            draftModeAmountOfChoices = CustomOption.Create(601, Types.General, cs(Color.yellow, "最大可选职业数量"), 5f, 2f, 15f, 1f, isDraftMode, false);
            draftModeTimeToChoose = CustomOption.Create(602, Types.General, cs(Color.yellow, "单人选择时常"), 5f, 3f, 20f, 1f, isDraftMode, false);
            draftModeCanChat = CustomOption.Create(606, Types.General, cs(Color.yellow, "轮抽选职时可以聊天"), false, isDraftMode, false);
            draftModeShowRoles = CustomOption.Create(603, Types.General, cs(Color.yellow, "显示已选择过的职业"), false, isDraftMode, false);
            draftModeHideImpRoles = CustomOption.Create(604, Types.General, cs(Color.yellow, "隐藏内鬼职业"), false, draftModeShowRoles, false);
            draftModeHideNeutralRoles = CustomOption.Create(605, Types.General, cs(Color.yellow, "隐藏中立职业"), false, draftModeShowRoles, false);
            draftModeHideCrewRoles = CustomOption.Create(607, Types.General, cs(Color.yellow, "隐藏船员职业"), false, draftModeShowRoles, false);

            // Using new id's for the options to not break compatibilty with older versions
            crewmateRolesCountMin = CustomOption.Create(300, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最少船员职业"), 15f, 0f, 15f, 1f, null, true, heading: "职业大小数量设置");
            crewmateRolesCountMax = CustomOption.Create(301, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最多船员职业"), 15f, 0f, 15f, 1f);
            neutralRolesCountMin = CustomOption.Create(302, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最少中立职业"), 15f, 0f, 15f, 1f);
            neutralRolesCountMax = CustomOption.Create(303, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最多中立职业"), 15f, 0f, 15f, 1f);
            impostorRolesCountMin = CustomOption.Create(304, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最少内鬼职业"), 15f, 0f, 15f, 1f);
            impostorRolesCountMax = CustomOption.Create(305, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最多内鬼职业"), 15f, 0f, 15f, 1f);
            modifiersCountMin = CustomOption.Create(306, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最少附加职业"), 15f, 0f, 15f, 1f);
            modifiersCountMax = CustomOption.Create(307, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最多附加职业"), 15f, 0f, 15f, 1f);
            crewmateRolesFill = CustomOption.Create(308, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "所有船员职业(忽略最少/最多值)"), false);
            mafiaSpawnRate = CustomOption.Create(18, Types.Impostor, cs(Janitor.color, "黑手党"), rates, null, true);
            janitorCooldown = CustomOption.Create(19, Types.Impostor, "清洁工技能冷却时间", 30f, 10f, 60f, 2.5f, mafiaSpawnRate);

            morphlingSpawnRate = CustomOption.Create(20, Types.Impostor, cs(Morphling.color, "化形者"), rates, null, true);
            morphlingCooldown = CustomOption.Create(21, Types.Impostor, "取样冷却时间", 30f, 10f, 60f, 2.5f, morphlingSpawnRate);
            morphlingDuration = CustomOption.Create(22, Types.Impostor, "化形持续时间", 10f, 1f, 20f, 0.5f, morphlingSpawnRate);

            camouflagerSpawnRate = CustomOption.Create(30, Types.Impostor, cs(Camouflager.color, "隐蔽者"), rates, null, true);
            camouflagerCooldown = CustomOption.Create(31, Types.Impostor, "隐蔽技能冷却时间", 30f, 10f, 60f, 2.5f, camouflagerSpawnRate);
            camouflagerDuration = CustomOption.Create(32, Types.Impostor, "隐蔽技能持续时间", 10f, 1f, 20f, 0.5f, camouflagerSpawnRate);

            vampireSpawnRate = CustomOption.Create(40, Types.Impostor, cs(Vampire.color, "吸血鬼"), rates, null, true);
            vampireKillDelay = CustomOption.Create(41, Types.Impostor, "吸血技能延迟击杀时间", 10f, 1f, 20f, 1f, vampireSpawnRate);
            vampireCooldown = CustomOption.Create(42, Types.Impostor, "吸血技能冷却时间", 30f, 10f, 60f, 2.5f, vampireSpawnRate);
            vampireCanKillNearGarlics = CustomOption.Create(43, Types.Impostor, "吸血鬼可以在大蒜范围内击杀", true, vampireSpawnRate);

            eraserSpawnRate = CustomOption.Create(230, Types.Impostor, cs(Eraser.color, "抹除者"), rates, null, true);
            eraserCooldown = CustomOption.Create(231, Types.Impostor, "抹除技能冷却时间", 30f, 10f, 120f, 5f, eraserSpawnRate);
            eraserCanEraseAnyone = CustomOption.Create(232, Types.Impostor, "可以抹除所有人的职业(包括队友）", false, eraserSpawnRate);

            tricksterSpawnRate = CustomOption.Create(250, Types.Impostor, cs(Trickster.color, "骗术师"), rates, null, true);
            tricksterPlaceBoxCooldown = CustomOption.Create(251, Types.Impostor, "放置盒子技能冷却时间", 10f, 2.5f, 30f, 2.5f, tricksterSpawnRate);
            tricksterLightsOutCooldown = CustomOption.Create(252, Types.Impostor, "熄灯技能冷却时间", 30f, 10f, 60f, 5f, tricksterSpawnRate);
            tricksterLightsOutDuration = CustomOption.Create(253, Types.Impostor, "熄灯技能持续时间", 15f, 5f, 60f, 2.5f, tricksterSpawnRate);

            cleanerSpawnRate = CustomOption.Create(260, Types.Impostor, cs(Cleaner.color, "清理者"), rates, null, true);
            cleanerCooldown = CustomOption.Create(261, Types.Impostor, "清理技能冷却时间", 30f, 10f, 60f, 2.5f, cleanerSpawnRate);

            warlockSpawnRate = CustomOption.Create(270, Types.Impostor, cs(Cleaner.color, "术士"), rates, null, true);
            warlockCooldown = CustomOption.Create(271, Types.Impostor, "诅咒技能冷却时间", 30f, 10f, 60f, 2.5f, warlockSpawnRate);
            warlockRootTime = CustomOption.Create(272, Types.Impostor, "术士定身时间", 5f, 0f, 15f, 1f, warlockSpawnRate);

            bountyHunterSpawnRate = CustomOption.Create(320, Types.Impostor, cs(BountyHunter.color, "赏金猎人"), rates, null, true);
            bountyHunterBountyDuration = CustomOption.Create(321, Types.Impostor, "赏金目标切换时间", 60f, 10f, 180f, 10f, bountyHunterSpawnRate);
            bountyHunterReducedCooldown = CustomOption.Create(322, Types.Impostor, "击杀赏金目标后击杀技能冷却时间", 2.5f, 0f, 30f, 2.5f, bountyHunterSpawnRate);
            bountyHunterPunishmentTime = CustomOption.Create(323, Types.Impostor, "击杀非赏金目标后击杀技能冷却时间", 20f, 0f, 60f, 2.5f, bountyHunterSpawnRate);
            bountyHunterShowArrow = CustomOption.Create(324, Types.Impostor, "显示指向赏金目标的箭头", true, bountyHunterSpawnRate);
            bountyHunterArrowUpdateIntervall = CustomOption.Create(325, Types.Impostor, "赏金目标位置更新延迟", 15f, 2.5f, 60f, 2.5f, bountyHunterShowArrow);

            witchSpawnRate = CustomOption.Create(370, Types.Impostor, cs(Witch.color, "女巫"), rates, null, true);
            witchCooldown = CustomOption.Create(371, Types.Impostor, "女巫下咒技能冷却时间", 30f, 10f, 120f, 5f, witchSpawnRate);
            witchAdditionalCooldown = CustomOption.Create(372, Types.Impostor, "女巫技能冷却增加时间", 10f, 0f, 60f, 5f, witchSpawnRate);
            witchCanSpellAnyone = CustomOption.Create(373, Types.Impostor, "女巫可以下咒所有人", false, witchSpawnRate);
            witchSpellCastingDuration = CustomOption.Create(374, Types.Impostor, "女巫下咒技能持续时间", 1f, 0f, 10f, 1f, witchSpawnRate);
            witchTriggerBothCooldowns = CustomOption.Create(375, Types.Impostor, "女巫下咒和击杀共用冷却时间", true, witchSpawnRate);
            witchVoteSavesTargets = CustomOption.Create(376, Types.Impostor, "女巫如果被投出则被诅咒者获救", true, witchSpawnRate);

            ninjaSpawnRate = CustomOption.Create(380, Types.Impostor, cs(Ninja.color, "忍者"), rates, null, true);
            ninjaCooldown = CustomOption.Create(381, Types.Impostor, "忍者选定目标冷却时间", 30f, 10f, 120f, 5f, ninjaSpawnRate);
            ninjaKnowsTargetLocation = CustomOption.Create(382, Types.Impostor, "忍者可知目标的位置", true, ninjaSpawnRate);
            ninjaTraceTime = CustomOption.Create(383, Types.Impostor, "完成刺杀后树叶跟踪持续时间", 5f, 1f, 20f, 0.5f, ninjaSpawnRate);
            ninjaTraceColorTime = CustomOption.Create(384, Types.Impostor, "树叶褪色的时间", 2f, 0f, 20f, 0.5f, ninjaSpawnRate);
            ninjaInvisibleDuration = CustomOption.Create(385, Types.Impostor, "忍者隐身时间", 3f, 0f, 20f, 1f, ninjaSpawnRate);

            bomberSpawnRate = CustomOption.Create(460, Types.Impostor, cs(Bomber.color, "爆炸狂"), rates, null, true);
            bomberBombDestructionTime = CustomOption.Create(461, Types.Impostor, "炸弹销毁时间", 20f, 2.5f, 120f, 2.5f, bomberSpawnRate);
            bomberBombDestructionRange = CustomOption.Create(462, Types.Impostor, "炸弹破坏范围", 50f, 5f, 150f, 5f, bomberSpawnRate);
            bomberBombHearRange = CustomOption.Create(463, Types.Impostor, "炸弹爆炸范围", 60f, 5f, 150f, 5f, bomberSpawnRate);
            bomberDefuseDuration = CustomOption.Create(464, Types.Impostor, "拆弹持续时间", 3f, 0.5f, 30f, 0.5f, bomberSpawnRate);
            bomberBombCooldown = CustomOption.Create(465, Types.Impostor, "炸弹技能冷却时间", 15f, 2.5f, 30f, 2.5f, bomberSpawnRate);
            bomberBombActiveAfter = CustomOption.Create(466, Types.Impostor, "炸弹激活所需时间", 3f, 0.5f, 15f, 0.5f, bomberSpawnRate);

            yoyoSpawnRate = CustomOption.Create(470, Types.Impostor, cs(Yoyo.color, "悠悠球"), rates, null, true);
            yoyoBlinkDuration = CustomOption.Create(471, Types.Impostor, "瞬移持续时间", 20f, 2.5f, 120f, 2.5f, yoyoSpawnRate);
            yoyoMarkCooldown = CustomOption.Create(472, Types.Impostor, "标记位置冷却时间", 20f, 2.5f, 120f, 2.5f, yoyoSpawnRate);
            yoyoMarkStaysOverMeeting = CustomOption.Create(473, Types.Impostor, "标记的位置会议结束后保留", true, yoyoSpawnRate);
            yoyoHasAdminTable = CustomOption.Create(474, Types.Impostor, "拥有便携式地图", true, yoyoSpawnRate);
            yoyoAdminTableCooldown = CustomOption.Create(475, Types.Impostor, "便携式地图冷却时间", 20f, 2.5f, 120f, 2.5f, yoyoHasAdminTable);
            yoyoSilhouetteVisibility = CustomOption.Create(476, Types.Impostor, "人影可见度", new string[] { "0%", "10%", "20%", "30%", "40%", "50%" }, yoyoSpawnRate);

            minerSpawnRate = CustomOption.Create(1120, Types.Impostor, cs(Miner.color, "矿工"), rates, null, true);
            minerCooldown = CustomOption.Create(1121, Types.Impostor, "挖掘冷却时间", 25f, 10f, 60f, 2.5f, minerSpawnRate);

            blackmailerSpawnRate = CustomOption.Create(710, Types.Impostor, cs(Blackmailer.color, "勒索者"), rates, null, true);
            blackmailerCooldown = CustomOption.Create(711, Types.Impostor, "勒索冷却时间", 30f, 5f, 120f, 5f, blackmailerSpawnRate);

            guesserSpawnRate = CustomOption.Create(310, Types.Neutral, cs(Guesser.color, "赌怪"), rates, null, true);
            guesserIsImpGuesserRate = CustomOption.Create(311, Types.Neutral, "赌怪是内鬼的机率", rates, guesserSpawnRate);
            guesserNumberOfShots = CustomOption.Create(312, Types.Neutral, "赌怪的赌杀次数", 2f, 1f, 15f, 1f, guesserSpawnRate);
            guesserHasMultipleShotsPerMeeting = CustomOption.Create(313, Types.Neutral, "赌怪可以在会议上多次赌杀", false, guesserSpawnRate);
            guesserKillsThroughShield = CustomOption.Create(315, Types.Neutral, "赌怪赌杀时忽略医生的盾", true, guesserSpawnRate);
            guesserEvilCanKillSpy = CustomOption.Create(316, Types.Neutral, "邪恶的赌怪可以赌杀卧底", true, guesserSpawnRate);
            guesserSpawnBothRate = CustomOption.Create(317, Types.Neutral, "两个赌怪的机率", rates, guesserSpawnRate);
            guesserCantGuessSnitchIfTaksDone = CustomOption.Create(318, Types.Neutral, "赌怪无法赌杀完成任务的告密者", true, guesserSpawnRate);

            jesterSpawnRate = CustomOption.Create(60, Types.Neutral, cs(Jester.color, "小丑"), rates, null, true);
            jesterCanCallEmergency = CustomOption.Create(61, Types.Neutral, "小丑可以召开紧急会议", true, jesterSpawnRate);
            jesterHasImpostorVision = CustomOption.Create(62, Types.Neutral, "小丑有内鬼的视野", false, jesterSpawnRate);

            arsonistSpawnRate = CustomOption.Create(290, Types.Neutral, cs(Arsonist.color, "纵火犯"), rates, null, true);
            arsonistCooldown = CustomOption.Create(291, Types.Neutral, "浇油技能冷却时间", 12.5f, 2.5f, 60f, 2.5f, arsonistSpawnRate);
            arsonistDuration = CustomOption.Create(292, Types.Neutral, "浇油技能持续时间", 3f, 1f, 10f, 1f, arsonistSpawnRate);

            jackalSpawnRate = CustomOption.Create(220, Types.Neutral, cs(Jackal.color, "豺狼"), rates, null, true);
            jackalKillCooldown = CustomOption.Create(221, Types.Neutral, "豺狼/跟班的击杀冷却时间", 30f, 10f, 60f, 2.5f, jackalSpawnRate);
            jackalCreateSidekickCooldown = CustomOption.Create(222, Types.Neutral, "豺狼招募技能冷却时间", 30f, 10f, 60f, 2.5f, jackalSpawnRate);
            jackalCanUseVents = CustomOption.Create(223, Types.Neutral, "豺狼可以使用管道", true, jackalSpawnRate);
            sidekickCanSabotageLights= CustomOption.Create(223, Types.Neutral, "跟班可以破坏灯光",true,jackalSpawnRate);
            jackalCanCreateSidekick = CustomOption.Create(225, Types.Neutral, "豺狼可以招募一个跟班", false, jackalSpawnRate);
            jackalCanSabotageLights = CustomOption.Create(231, Types.Neutral, "豺狼可以破坏灯光", true, jackalSpawnRate);
            sidekickPromotesToJackal = CustomOption.Create(226, Types.Neutral, "跟班在豺狼死后晋升豺狼", false, jackalCanCreateSidekick);
            sidekickCanKill = CustomOption.Create(227, Types.Neutral, "跟班可以击杀", false, jackalCanCreateSidekick);
            sidekickCanUseVents = CustomOption.Create(228, Types.Neutral, "跟班可以使用管道", true, jackalCanCreateSidekick);
            jackalPromotedFromSidekickCanCreateSidekick = CustomOption.Create(229, Types.Neutral, "晋升的跟班可以拥有招募技能", true, sidekickPromotesToJackal);
            jackalCanCreateSidekickFromImpostor = CustomOption.Create(230, Types.Neutral, "豺狼可以招募内鬼为自己的跟班", true, jackalCanCreateSidekick);
            jackalAndSidekickHaveImpostorVision = CustomOption.Create(430, Types.Neutral, "豺狼和跟班拥有内鬼的视野", false, jackalSpawnRate);


            vultureSpawnRate = CustomOption.Create(340, Types.Neutral, cs(Vulture.color, "秃鹫"), rates, null, true);
            vultureCooldown = CustomOption.Create(341, Types.Neutral, "吞噬技能冷却时间", 15f, 10f, 60f, 2.5f, vultureSpawnRate);
            vultureNumberToWin = CustomOption.Create(342, Types.Neutral, "需要吃掉的尸体数量", 4f, 1f, 10f, 1f, vultureSpawnRate);
            vultureCanUseVents = CustomOption.Create(343, Types.Neutral, "秃鹫可以使用管道", true, vultureSpawnRate);
            vultureShowArrows = CustomOption.Create(344, Types.Neutral, "秃鹫有指向尸体的箭头", true, vultureSpawnRate);

            lawyerSpawnRate = CustomOption.Create(350, Types.Neutral, cs(Lawyer.color, "律师"), rates, null, true);
            lawyerIsProsecutorChance = CustomOption.Create(358, Types.Neutral, "检察官的可能性", rates, lawyerSpawnRate);
            lawyerVision = CustomOption.Create(354, Types.Neutral, "视野大小", 1f, 0.25f, 3f, 0.25f, lawyerSpawnRate);
            lawyerKnowsRole = CustomOption.Create(355, Types.Neutral, "律师/检察官知道目标的职业", false, lawyerSpawnRate);
            lawyerCanCallEmergency = CustomOption.Create(352, Types.Neutral, "律师/检察官可以召开紧急会议", true, lawyerSpawnRate);
            lawyerTargetCanBeJester = CustomOption.Create(351, Types.Neutral, "律师/检察官的客户可以是小丑", false, lawyerSpawnRate);
            pursuerCooldown = CustomOption.Create(356, Types.Neutral, "起诉人空包弹技能冷却时间", 30f, 5f, 60f, 2.5f, lawyerSpawnRate);
            pursuerBlanksNumber = CustomOption.Create(357, Types.Neutral, "起诉人空包弹的数量", 5f, 1f, 20f, 1f, lawyerSpawnRate);

            mayorSpawnRate = CustomOption.Create(80, Types.Crewmate, cs(Mayor.color, "市长"), rates, null, true);
            mayorCanSeeVoteColors = CustomOption.Create(81, Types.Crewmate, "市长可以看见投票者的颜色", false, mayorSpawnRate);
            mayorTasksNeededToSeeVoteColors = CustomOption.Create(82, Types.Crewmate, "查看投票颜色所需完成的任务", 5f, 0f, 20f, 1f, mayorCanSeeVoteColors);
            mayorMeetingButton = CustomOption.Create(83, Types.Crewmate, "启用便携式移动紧急会议", true, mayorSpawnRate);
            mayorMaxRemoteMeetings = CustomOption.Create(84, Types.Crewmate, "紧急会议的次数", 1f, 1f, 5f, 1f, mayorMeetingButton);
            mayorChooseSingleVote = CustomOption.Create(85, Types.Crewmate, "市长可以选择单票", new string[] { "关闭", "开启(会议之前)", "开启(会议后)" }, mayorSpawnRate);

            engineerSpawnRate = CustomOption.Create(90, Types.Crewmate, cs(Engineer.color, "工程师"), rates, null, true);
            engineerNumberOfFixes = CustomOption.Create(91, Types.Crewmate, "修理技能次数", 1f, 1f, 3f, 1f, engineerSpawnRate);
            engineerHighlightForImpostors = CustomOption.Create(92, Types.Crewmate, "内鬼可以看见工程师在管道里", true, engineerSpawnRate);
            engineerHighlightForTeamJackal = CustomOption.Create(93, Types.Crewmate, "豺狼和跟班可以看见工程师在管道里", true, engineerSpawnRate);

            sheriffSpawnRate = CustomOption.Create(100, Types.Crewmate, cs(Sheriff.color, "警长"), rates, null, true);
            sheriffCooldown = CustomOption.Create(101, Types.Crewmate, "击杀冷却时间", 30f, 10f, 60f, 2.5f, sheriffSpawnRate);
            sheriffCanKillNeutrals = CustomOption.Create(102, Types.Crewmate, "警长可以击杀中立阵营的玩家", false, sheriffSpawnRate);
            deputySpawnRate = CustomOption.Create(103, Types.Crewmate, cs(Sheriff.color, "捕快"), rates, sheriffSpawnRate);
            deputyNumberOfHandcuffs = CustomOption.Create(104, Types.Crewmate, "戴上手铐技能数量", 3f, 1f, 10f, 1f, deputySpawnRate);
            deputyHandcuffCooldown = CustomOption.Create(105, Types.Crewmate, "戴上手铐冷却时间", 30f, 10f, 60f, 2.5f, deputySpawnRate);
            deputyHandcuffDuration = CustomOption.Create(106, Types.Crewmate, "戴上手铐持续时间", 15f, 5f, 60f, 2.5f, deputySpawnRate);
            deputyKnowsSheriff = CustomOption.Create(107, Types.Crewmate, "警长和捕快可以相识", true, deputySpawnRate);
            deputyGetsPromoted = CustomOption.Create(108, Types.Crewmate, "警长死后捕快可以晋升警长", new string[] { "关闭", "开启(立即)", "开启(会议后)" }, deputySpawnRate);
            deputyKeepsHandcuffs = CustomOption.Create(109, Types.Crewmate, "捕快晋升后保留戴上手铐技能", true, deputyGetsPromoted);

            lighterSpawnRate = CustomOption.Create(110, Types.Crewmate, cs(Lighter.color, "执灯人"), rates, null, true);
            lighterModeLightsOnVision = CustomOption.Create(111, Types.Crewmate, "灯光开启视野", 1.5f, 0.25f, 5f, 0.25f, lighterSpawnRate);
            lighterModeLightsOffVision = CustomOption.Create(112, Types.Crewmate, "灯光关闭视野", 0.5f, 0.25f, 5f, 0.25f, lighterSpawnRate);
            lighterFlashlightWidth = CustomOption.Create(113, Types.Crewmate, "灯光视野宽度", 0.3f, 0.1f, 1f, 0.1f, lighterSpawnRate);

            detectiveSpawnRate = CustomOption.Create(120, Types.Crewmate, cs(Detective.color, "侦探"), rates, null, true);
            detectiveAnonymousFootprints = CustomOption.Create(121, Types.Crewmate, "匿名脚印", false, detectiveSpawnRate);
            detectiveFootprintIntervall = CustomOption.Create(122, Types.Crewmate, "脚印间隔", 0.5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
            detectiveFootprintDuration = CustomOption.Create(123, Types.Crewmate, "脚印持续时间", 5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
            detectiveReportNameDuration = CustomOption.Create(124, Types.Crewmate, "在一定的时间内侦探报告有凶手的名字", 0, 0, 60, 2.5f, detectiveSpawnRate);
            detectiveReportColorDuration = CustomOption.Create(125, Types.Crewmate, "在一定的时间内侦探报告有颜色类型", 20, 0, 120, 2.5f, detectiveSpawnRate);

            timeMasterSpawnRate = CustomOption.Create(130, Types.Crewmate, cs(TimeMaster.color, "时间之主"), rates, null, true);
            timeMasterCooldown = CustomOption.Create(131, Types.Crewmate, "时间之盾冷却时间", 30f, 10f, 120f, 2.5f, timeMasterSpawnRate);
            timeMasterShieldDuration = CustomOption.Create(133, Types.Crewmate, "时间之盾持续时间", 3f, 1f, 20f, 1f, timeMasterSpawnRate);
            timeMasterRewindTime = CustomOption.Create(132, Types.Crewmate, "倒退时间", 3f, 1f, 10f, 1f, timeMasterSpawnRate);

            medicSpawnRate = CustomOption.Create(140, Types.Crewmate, cs(Medic.color, "医生"), rates, null, true);
            medicShowShielded = CustomOption.Create(143, Types.Crewmate, "所有人可见护盾保护的玩家", new string[] { "所有人可见", "被保护者和医生可见", "仅医生可见" }, medicSpawnRate);
            medicShowAttemptToShielded = CustomOption.Create(144, Types.Crewmate, "被护盾保护的玩家如被击杀被保护玩家会有提示", false, medicSpawnRate);
            medicSetOrShowShieldAfterMeeting = CustomOption.Create(145, Types.Crewmate, "护盾将被激活", new string[] { "立即", "会议后\n立即可见", "会议后" }, medicSpawnRate);
            medicShowAttemptToMedic = CustomOption.Create(146, Types.Crewmate, "被护盾保护的玩家如被击杀医生会有提示", false, medicSpawnRate);
            medicSetShieldAfterMeeting = CustomOption.Create(147, Types.Crewmate, "医生在会议后启用护盾", false, medicSpawnRate);

            swapperSpawnRate = CustomOption.Create(150, Types.Crewmate, cs(Swapper.color, "换票师"), rates, null, true);
            swapperCanCallEmergency = CustomOption.Create(151, Types.Crewmate, "换票师可以开启紧急会议", false, swapperSpawnRate);
            swapperCanOnlySwapOthers = CustomOption.Create(152, Types.Crewmate, "换票师只能交换他人的票数", false, swapperSpawnRate);
            swapperSwapsNumber = CustomOption.Create(153, Types.Crewmate, "初始换票充能", 1f, 0f, 5f, 1f, swapperSpawnRate);
            swapperRechargeTasksNumber = CustomOption.Create(154, Types.Crewmate, "充能所需的任务数量", 2f, 1f, 10f, 1f, swapperSpawnRate);


            seerSpawnRate = CustomOption.Create(160, Types.Crewmate, cs(Seer.color, "灵媒"), rates, null, true);
            seerMode = CustomOption.Create(161, Types.Crewmate, "灵媒在游戏中的技能", new string[] { "显示死亡闪光 + 灵魂", "只显示死亡闪光", "只显示灵魂" }, seerSpawnRate);
            seerLimitSoulDuration = CustomOption.Create(163, Types.Crewmate, "灵媒可看到灵魂", false, seerSpawnRate);
            seerSoulDuration = CustomOption.Create(162, Types.Crewmate, "灵媒看到灵魂的持续时间", 15f, 0f, 120f, 5f, seerLimitSoulDuration);

            hackerSpawnRate = CustomOption.Create(170, Types.Crewmate, cs(Hacker.color, "黑客"), rates, null, true);
            hackerCooldown = CustomOption.Create(171, Types.Crewmate, "黑入技能冷却时间", 30f, 5f, 60f, 5f, hackerSpawnRate);
            hackerHackeringDuration = CustomOption.Create(172, Types.Crewmate, "黑入技能持续时间", 10f, 2.5f, 60f, 2.5f, hackerSpawnRate);
            hackerOnlyColorType = CustomOption.Create(173, Types.Crewmate, "黑客只能在管理室看到玩家颜色", false, hackerSpawnRate);
            hackerToolsNumber = CustomOption.Create(174, Types.Crewmate, "最多移动地图的充能次数", 5f, 1f, 30f, 1f, hackerSpawnRate);
            hackerRechargeTasksNumber = CustomOption.Create(175, Types.Crewmate, "地图充能所需的任务数", 2f, 1f, 5f, 1f, hackerSpawnRate);
            hackerNoMove = CustomOption.Create(176, Types.Crewmate, "在使用移动地图时无法移动", true, hackerSpawnRate);

            trackerSpawnRate = CustomOption.Create(200, Types.Crewmate, cs(Tracker.color, "追踪者"), rates, null, true);
            trackerUpdateIntervall = CustomOption.Create(201, Types.Crewmate, "追踪者箭头更新延迟", 5f, 1f, 30f, 1f, trackerSpawnRate);
            trackerResetTargetAfterMeeting = CustomOption.Create(202, Types.Crewmate, "追踪者在会议后重新追踪", false, trackerSpawnRate);
            trackerCanTrackCorpses = CustomOption.Create(203, Types.Crewmate, "追踪者可以追踪尸体", true, trackerSpawnRate);
            trackerCorpsesTrackingCooldown = CustomOption.Create(204, Types.Crewmate, "追踪尸体冷却时间", 30f, 5f, 120f, 5f, trackerCanTrackCorpses);
            trackerCorpsesTrackingDuration = CustomOption.Create(205, Types.Crewmate, "追踪尸体持续时间", 5f, 2.5f, 30f, 2.5f, trackerCanTrackCorpses);
            trackerTrackingMethod = CustomOption.Create(206, Types.Crewmate, "追踪者如何获取目标位置", new string[] { "1.仅箭头", "2.仅接近检测器", "1 + 2" }, trackerSpawnRate);


            snitchSpawnRate = CustomOption.Create(210, Types.Crewmate, cs(Snitch.color, "告密者"), rates, null, true);
            snitchLeftTasksForReveal = CustomOption.Create(219, Types.Crewmate, "当任务数剩下多少时执刃者得到具体位置", 5f, 0f, 25f, 1f, snitchSpawnRate);
            snitchMode = CustomOption.Create(211, Types.Crewmate, "提供的信息模式", new string[] { "1.聊天", "2.地图", "1 + 2" }, snitchSpawnRate);
            snitchTargets = CustomOption.Create(212, Types.Crewmate, "告密目标", new string[] { "所有内鬼 & 中立玩家", "带刀玩家" }, snitchSpawnRate);

            spySpawnRate = CustomOption.Create(240, Types.Crewmate, cs(Spy.color, "卧底"), rates, null, true);
            spyCanDieToSheriff = CustomOption.Create(241, Types.Crewmate, "卧底可以反弹警长的击杀", false, spySpawnRate);
            spyImpostorsCanKillAnyone = CustomOption.Create(242, Types.Crewmate, "当有卧底时内鬼可以击杀所有人(包括队友)", true, spySpawnRate);
            spyCanEnterVents = CustomOption.Create(243, Types.Crewmate, "卧底可以使用管道", false, spySpawnRate);
            spyHasImpostorVision = CustomOption.Create(244, Types.Crewmate, "卧底有内鬼视野", false, spySpawnRate);

            portalmakerSpawnRate = CustomOption.Create(390, Types.Crewmate, cs(Portalmaker.color, "传送师"), rates, null, true);
            portalmakerCooldown = CustomOption.Create(391, Types.Crewmate, "搭建传送门技能冷却时间", 30f, 10f, 60f, 2.5f, portalmakerSpawnRate);
            portalmakerUsePortalCooldown = CustomOption.Create(392, Types.Crewmate, "使用传送门冷却时间", 30f, 10f, 60f, 2.5f, portalmakerSpawnRate);
            portalmakerLogOnlyColorType = CustomOption.Create(393, Types.Crewmate, "传送师仅日志显示颜色类型", true, portalmakerSpawnRate);
            portalmakerLogHasTime = CustomOption.Create(394, Types.Crewmate, "日志显示时间", true, portalmakerSpawnRate);
            portalmakerCanPortalFromAnywhere = CustomOption.Create(395, Types.Crewmate, "传送师可以从任何地方直达传送门处", true, portalmakerSpawnRate);

            securityGuardSpawnRate = CustomOption.Create(280, Types.Crewmate, cs(SecurityGuard.color, "保安"), rates, null, true);
            securityGuardCooldown = CustomOption.Create(281, Types.Crewmate, "保安技能冷却时间", 30f, 10f, 60f, 2.5f, securityGuardSpawnRate);
            securityGuardTotalScrews = CustomOption.Create(282, Types.Crewmate, "保安螺丝数量", 7f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardCamPrice = CustomOption.Create(283, Types.Crewmate, "每个监控所需螺丝数量", 2f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardVentPrice = CustomOption.Create(284, Types.Crewmate, "每个管道所需螺丝数量", 1f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardCamDuration = CustomOption.Create(285, Types.Crewmate, "保安技能持续时间", 10f, 2.5f, 60f, 2.5f, securityGuardSpawnRate);
            securityGuardCamMaxCharges = CustomOption.Create(286, Types.Crewmate, "螺丝最大充能", 5f, 1f, 30f, 1f, securityGuardSpawnRate);
            securityGuardCamRechargeTasksNumber = CustomOption.Create(287, Types.Crewmate, "便携式监控器充能所需的任务数", 3f, 1f, 10f, 1f, securityGuardSpawnRate);
            securityGuardNoMove = CustomOption.Create(288, Types.Crewmate, "在使用便携式监控器时无法移动", true, securityGuardSpawnRate);

            mediumSpawnRate = CustomOption.Create(360, Types.Crewmate, cs(Medium.color, "通灵师"), rates, null, true);
            mediumCooldown = CustomOption.Create(361, Types.Crewmate, "通灵技能冷却时间", 30f, 5f, 120f, 5f, mediumSpawnRate);
            mediumDuration = CustomOption.Create(362, Types.Crewmate, "通灵技能持续时间", 3f, 0f, 15f, 1f, mediumSpawnRate);
            mediumOneTimeUse = CustomOption.Create(363, Types.Crewmate, "每个灵魂只能被通灵一次", false, mediumSpawnRate);
            mediumChanceAdditionalInfo = CustomOption.Create(364, Types.Crewmate, "信息的机率 \n 其他信息", rates, mediumSpawnRate);

            thiefSpawnRate = CustomOption.Create(400, Types.Neutral, cs(Thief.color, "强盗"), rates, null, true);
            thiefCooldown = CustomOption.Create(401, Types.Neutral, "抢夺技能冷却时间", 30f, 5f, 120f, 5f, thiefSpawnRate);
            thiefCanKillSheriff = CustomOption.Create(402, Types.Neutral, "强盗可以击杀警长", true, thiefSpawnRate);
            thiefHasImpVision = CustomOption.Create(403, Types.Neutral, "强盗拥有内鬼的视野", true, thiefSpawnRate);
            thiefCanUseVents = CustomOption.Create(404, Types.Neutral, "强盗可以使用管道", true, thiefSpawnRate);
            thiefCanStealWithGuess = CustomOption.Create(405, Types.Neutral, "强盗可以通过赌杀得到职业(赌怪模式)", false, thiefSpawnRate);

            trapperSpawnRate = CustomOption.Create(410, Types.Crewmate, cs(Trapper.color, "猎人"), rates, null, true);
            trapperCooldown = CustomOption.Create(420, Types.Crewmate, "陷阱技能冷却时间", 30f, 5f, 120f, 5f, trapperSpawnRate);
            trapperMaxCharges = CustomOption.Create(440, Types.Crewmate, "最大陷阱所需的充能", 5f, 1f, 15f, 1f, trapperSpawnRate);
            trapperRechargeTasksNumber = CustomOption.Create(450, Types.Crewmate, "充能所需的任务数", 2f, 1f, 15f, 1f, trapperSpawnRate);
            trapperTrapNeededTriggerToReveal = CustomOption.Create(451, Types.Crewmate, "陷阱需要触发器才能揭示", 3f, 2f, 10f, 1f, trapperSpawnRate);
            trapperAnonymousMap = CustomOption.Create(452, Types.Crewmate, "显示匿名地图", false, trapperSpawnRate);
            trapperInfoType = CustomOption.Create(453, Types.Crewmate, "陷阱信息类型", new string[] { "职业", "正义/邪恶的职业", "玩家名字" }, trapperSpawnRate);
            trapperTrapDuration = CustomOption.Create(454, Types.Crewmate, "陷阱持续时间", 5f, 1f, 15f, 1f, trapperSpawnRate);

            // Modifier (1000 - 1999)
            //modifiersAreHidden = CustomOption.Create(1009, Types.Modifier, cs(Color.yellow, "死后隐藏附加职业"), true, null, true); 歌姬farewell翻译错了
            modifiersAreHidden = CustomOption.Create(1009, Types.Modifier, cs(Color.yellow, "隐藏VIP, 诱饵 & 溅血者"), true, null, true, heading: cs(Color.yellow, "死后隐藏附加职业效果"));

            modifierBloody = CustomOption.Create(1000, Types.Modifier, cs(Bloody.color, "溅血者"), rates, null, true);
            modifierBloodyQuantity = CustomOption.Create(1001, Types.Modifier,"溅血者数量", ratesModifier, modifierBloody);
            modifierBloodyDuration = CustomOption.Create(1002, Types.Modifier, "血迹持续时间", 10f, 3f, 60f, 1f, modifierBloody);

            modifierAntiTeleport = CustomOption.Create(1010, Types.Modifier, cs(AntiTeleport.color, "厄运儿"), rates, null, true);
            modifierAntiTeleportQuantity = CustomOption.Create(1011, Types.Modifier, "厄运儿数量", ratesModifier, modifierAntiTeleport);

            modifierTieBreaker = CustomOption.Create(1020, Types.Modifier, cs(Tiebreaker.color, "破平者"), rates, null, true);

            modifierBait = CustomOption.Create(1030, Types.Modifier, cs(Bait.color, "诱饵"), rates, null, true);
            modifierBaitQuantity = CustomOption.Create(1031, Types.Modifier,"诱饵数量", ratesModifier, modifierBait);
            modifierBaitReportDelayMin = CustomOption.Create(1032, Types.Modifier, "诱饵报告延迟最小值", 0f, 0f, 10f, 1f, modifierBait);
            modifierBaitReportDelayMax = CustomOption.Create(1033, Types.Modifier, "诱饵报告延迟最大值", 0f, 0f, 10f, 1f, modifierBait);
            modifierBaitShowKillFlash = CustomOption.Create(1034, Types.Modifier, "用闪光警告凶手", true, modifierBait);

            modifierLover = CustomOption.Create(1040, Types.Modifier, cs(Lovers.color, "恋人"), rates, null, true);
            modifierLoverImpLoverRate = CustomOption.Create(1041, Types.Modifier, "一对内鬼恋人的机率", rates, modifierLover);
            modifierLoverBothDie = CustomOption.Create(1042, Types.Modifier, "恋人同生共死", true, modifierLover);
            modifierLoverEnableChat = CustomOption.Create(1043, Types.Modifier, "启用恋人私密聊天", true, modifierLover);

            modifierSunglasses = CustomOption.Create(1050, Types.Modifier, cs(Sunglasses.color, "太阳镜"), rates, null, true);
            modifierSunglassesQuantity = CustomOption.Create(1051, Types.Modifier,"太阳镜数量", ratesModifier, modifierSunglasses);
            modifierSunglassesVision = CustomOption.Create(1052, Types.Modifier, "太阳镜视野", new string[] { "-10%", "-20%", "-30%", "-40%", "-50%" }, modifierSunglasses);

            modifierMini = CustomOption.Create(1061, Types.Modifier, cs(Mini.color, "迷你船员"), rates, null, true);
            modifierMiniGrowingUpDuration = CustomOption.Create(1062, Types.Modifier, "迷你船员成长时间", 400f, 100f, 1500f, 100f, modifierMini);
            modifierMiniGrowingUpInMeeting = CustomOption.Create(1063, Types.Modifier, "迷你船员在会议中成长", true, modifierMini);
            if (Utilities.EventUtility.canBeEnabled || Utilities.EventUtility.isEnabled)
            {
                eventKicksPerRound = CustomOption.Create(10424, Types.Modifier, cs(Color.green, "迷你船员最大可承受踢出次数"), 4f, 0f, 14f, 1f, modifierMini);
                eventHeavyAge = CustomOption.Create(10425, Types.Modifier, cs(Color.green, "迷你船员成年年龄"), 12f, 6f, 18f, 0.5f, modifierMini);
                eventReallyNoMini = CustomOption.Create(10426, Types.Modifier, cs(Color.green, "不是真的迷你船员:("), false, modifierMini, invertedParent: true);
            }
            modifierVip = CustomOption.Create(1070, Types.Modifier, cs(Vip.color, "VIP"), rates, null, true);
            modifierVipQuantity = CustomOption.Create(1071, Types.Modifier,"VIP数量", ratesModifier, modifierVip);
            modifierVipShowColor = CustomOption.Create(1072, Types.Modifier, "显示团队颜色", true, modifierVip);

            modifierInvert = CustomOption.Create(1080, Types.Modifier, cs(Invert.color, "酒鬼"), rates, null, true);
            modifierInvertQuantity = CustomOption.Create(1081, Types.Modifier,"酒鬼数量", ratesModifier, modifierInvert);
            modifierInvertDuration = CustomOption.Create(1082, Types.Modifier, "颠倒的会议次数", 3f, 1f, 15f, 1f, modifierInvert);

            modifierChameleon = CustomOption.Create(1090, Types.Modifier, cs(Chameleon.color, "变色龙"), rates, null, true);
            modifierChameleonQuantity = CustomOption.Create(1091, Types.Modifier,"变色龙数量", ratesModifier, modifierChameleon);
            modifierChameleonHoldDuration = CustomOption.Create(1092, Types.Modifier, "变色开始时间", 3f, 1f, 10f, 0.5f, modifierChameleon);
            modifierChameleonFadeDuration = CustomOption.Create(1093, Types.Modifier, "透明持续时间", 1f, 0.25f, 10f, 0.25f, modifierChameleon);
            modifierChameleonMinVisibility = CustomOption.Create(1094, Types.Modifier, "最低可见度", new string[] { "0%", "10%", "20%", "30%", "40%", "50%" }, modifierChameleon);


            modifierShifter = CustomOption.Create(1100, Types.Modifier, cs(Shifter.color, "交换师"), rates, null, true);


            modifierArmored = CustomOption.Create(1101, Types.Modifier, cs(Armored.color, "装甲兵"), rates, null, true);

            modifierDisperser = CustomOption.Create(1200, Types.Modifier, cs(Color.red, "分散者"), rates, null, true);

            // Guesser Gamemode (2000 - 2999)
            guesserGamemodeCrewNumber = CustomOption.Create(2001, Types.Guesser, cs(Guesser.color, "船员们的赌杀次数"), 15f, 0f, 15f, 1f, null, true, heading: "赌杀次数");
            guesserGamemodeNeutralNumber = CustomOption.Create(2002, Types.Guesser, cs(Guesser.color, "中立们的赌杀次数"), 15f, 0f, 15f, 1f, null);
            guesserGamemodeImpNumber = CustomOption.Create(2003, Types.Guesser, cs(Guesser.color, "内鬼们的赌杀次数"), 15f, 0f, 15f, 1f, null);
            guesserForceJackalGuesser = CustomOption.Create(2007, Types.Guesser, "强制豺狼为赌怪", false, null, true, heading: "强制赌怪");
            guesserGamemodeSidekickIsAlwaysGuesser = CustomOption.Create(2012, Types.Guesser, "设置跟班为赌怪", false, null);
            guesserForceThiefGuesser = CustomOption.Create(2011, Types.Guesser, "强制交换师为赌怪", false, null);
            guesserGamemodeHaveModifier = CustomOption.Create(2004, Types.Guesser, "赌怪可以有附加职业", true, null, true, heading: "普通赌怪设置");
            guesserGamemodeNumberOfShots = CustomOption.Create(2005, Types.Guesser, "赌怪的赌杀次数", 3f, 1f, 15f, 1f, null);
            guesserGamemodeHasMultipleShotsPerMeeting = CustomOption.Create(2006, Types.Guesser, "赌怪可以在会议期间多次赌杀", false, null);
            guesserGamemodeCrewGuesserNumberOfTasks = CustomOption.Create(2013, Types.Guesser, "对于船员赌怪\n启用赌杀所需做的任务数量", 0f, 0f, 15f, 1f, null);
            guesserGamemodeKillsThroughShield = CustomOption.Create(2008, Types.Guesser, "赌杀可以无视医生的护盾", true, null);
            guesserGamemodeEvilCanKillSpy = CustomOption.Create(2009, Types.Guesser, "邪恶赌怪可以赌杀卧底", true, null);
            guesserGamemodeCantGuessSnitchIfTaksDone = CustomOption.Create(2010, Types.Guesser, "赌怪不能赌杀完成任务了的告密者", true, null);

            // Hide N Seek Gamemode (3000 - 3999)
            hideNSeekMap = CustomOption.Create(3020, Types.HideNSeekMain, cs(Color.yellow, "地图"), new string[] { "骷髅舰", "米拉HQ", "波鲁斯", "高空飞艇", "真菌世界", "深海潜艇" }, null, true, onChange: () => { int map = hideNSeekMap.selection; if (map >= 3) map++; GameOptionsManager.Instance.currentNormalGameOptions.MapId = (byte)map; },heading: "捉迷藏地图设置");
            hideNSeekHunterCount = CustomOption.Create(3000, Types.HideNSeekMain, cs(Color.yellow, "猎人数量"), 1f, 1f, 3f, 1f, null, true, heading: "捉迷藏普通设置");
            hideNSeekKillCooldown = CustomOption.Create(3021, Types.HideNSeekMain, cs(Color.yellow, "击杀冷却"), 10f, 2.5f, 60f, 2.5f);
            hideNSeekHunterVision = CustomOption.Create(3001, Types.HideNSeekMain, cs(Color.yellow, "猎人视野"), 0.5f, 0.25f, 2f, 0.25f);
            hideNSeekHuntedVision = CustomOption.Create(3002, Types.HideNSeekMain, cs(Color.yellow, "躲藏者视野"), 2f, 0.25f, 5f, 0.25f);
            hideNSeekCommonTasks = CustomOption.Create(3023, Types.HideNSeekMain, cs(Color.yellow, "普通任务数"), 1f, 0f, 4f, 1f);
            hideNSeekShortTasks = CustomOption.Create(3024, Types.HideNSeekMain, cs(Color.yellow, "短任务数"), 3f, 1f, 23f, 1f);
            hideNSeekLongTasks = CustomOption.Create(3025, Types.HideNSeekMain, cs(Color.yellow, "长任务数"), 3f, 0f, 15f, 1f);
            hideNSeekTimer = CustomOption.Create(3003, Types.HideNSeekMain, cs(Color.yellow, "计时器最小值"), 5f, 1f, 30f, 0.5f);
            hideNSeekTaskWin = CustomOption.Create(3004, Types.HideNSeekMain, cs(Color.yellow, "可以任务获胜"), false);
            hideNSeekTaskPunish = CustomOption.Create(3017, Types.HideNSeekMain, cs(Color.yellow, "完成任务减少的秒数"), 10f, 0f, 30f, 1f);
            hideNSeekCanSabotage = CustomOption.Create(3019, Types.HideNSeekMain, cs(Color.yellow, "启用破坏"), false);
            hideNSeekHunterWaiting = CustomOption.Create(3022, Types.HideNSeekMain, cs(Color.yellow, "猎人需要等待的时间"), 15f, 2.5f, 60f, 2.5f);

            hunterLightCooldown = CustomOption.Create(3005, Types.HideNSeekRoles, cs(Color.red, "猎人点灯冷却时间"), 30f, 5f, 60f, 1f, null, true, heading: "猎人点灯设置");
            hunterLightDuration = CustomOption.Create(3006, Types.HideNSeekRoles, cs(Color.red, "猎人点灯持续时间"), 5f, 1f, 60f, 1f);
            hunterLightVision = CustomOption.Create(3007, Types.HideNSeekRoles, cs(Color.red, "猎人点灯视野"), 3f, 1f, 5f, 0.25f);
            hunterLightPunish = CustomOption.Create(3008, Types.HideNSeekRoles, cs(Color.red, "猎人点灯惩罚秒数"), 5f, 0f, 30f, 1f);
            hunterAdminCooldown = CustomOption.Create(3009, Types.HideNSeekRoles, cs(Color.red, "猎人地图冷却时间"), 30f, 5f, 60f, 1f);
            hunterAdminDuration = CustomOption.Create(3010, Types.HideNSeekRoles, cs(Color.red, "猎人地图使用时间"), 5f, 1f, 60f, 1f);
            hunterAdminPunish = CustomOption.Create(3011, Types.HideNSeekRoles, cs(Color.red, "猎人地图减少的秒数"), 5f, 0f, 30f, 1f);
            hunterArrowCooldown = CustomOption.Create(3012, Types.HideNSeekRoles, cs(Color.red, "猎人寻找冷却时间"), 30f, 5f, 60f, 1f);
            hunterArrowDuration = CustomOption.Create(3013, Types.HideNSeekRoles, cs(Color.red, "猎人寻找持续时间"), 5f, 0f, 60f, 1f);
            hunterArrowPunish = CustomOption.Create(3014, Types.HideNSeekRoles, cs(Color.red, "猎寻找踪惩罚秒数"), 5f, 0f, 30f, 1f);

            huntedShieldCooldown = CustomOption.Create(3015, Types.HideNSeekRoles, cs(Color.gray, "躲藏者护盾冷却时间"), 30f, 5f, 60f, 1f, null, true, heading: "躲藏者护盾设置");
            huntedShieldDuration = CustomOption.Create(3016, Types.HideNSeekRoles, cs(Color.gray, "躲藏者护盾持续时间"), 5f, 1f, 60f, 1f);
            huntedShieldRewindTime = CustomOption.Create(3018, Types.HideNSeekRoles, cs(Color.gray, "躲藏者回溯时间"), 3f, 1f, 10f, 1f);
            huntedShieldNumber = CustomOption.Create(3026, Types.HideNSeekRoles, cs(Color.gray, "躲藏者护盾数量"), 3f, 1f, 15f, 1f);

            // Prop Hunt General Options
            propHuntMap = CustomOption.Create(4020, Types.PropHunt, cs(Color.yellow, "地图"), new string[] { "骷髅舰", "米拉总部", "波鲁斯", "飞艇地图", "真菌世界", "潜艇地图", "自定义地图" }, null, true, onChange: () => { int map = propHuntMap.selection; if (map >= 3) map++; GameOptionsManager.Instance.currentNormalGameOptions.MapId = (byte)map; }, heading: "变形躲猫猫地图设置");
            propHuntTimer = CustomOption.Create(4021, Types.PropHunt, cs(Color.yellow, "计时器最小值"), 5f, 1f, 30f, 0.5f, null, true, heading: "变形躲猫猫普通设置");
            propHuntUnstuckCooldown = CustomOption.Create(4011, Types.PropHunt, cs(Color.yellow, "穿墙冷却时间"), 30f, 2.5f, 60f, 2.5f);
            propHuntUnstuckDuration = CustomOption.Create(4012, Types.PropHunt, cs(Color.yellow, "穿墙持续时间"), 2f, 1f, 60f, 1f);
            propHunterVision = CustomOption.Create(4006, Types.PropHunt, cs(Color.yellow, "猎人视野"), 0.5f, 0.25f, 2f, 0.25f);
            propVision = CustomOption.Create(4007, Types.PropHunt, cs(Color.yellow, "道具视野"), 2f, 0.25f, 5f, 0.25f);
            // Hunter Options
            propHuntNumberOfHunters = CustomOption.Create(4000, Types.PropHunt, cs(Color.red, "猎人数量"), 1f, 1f, 5f, 1f, null, true, heading: "猎人设置");
            hunterInitialBlackoutTime = CustomOption.Create(4001, Types.PropHunt, cs(Color.red, "猎人初始等待时间"), 10f, 5f, 20f, 1f);
            hunterMissCooldown = CustomOption.Create(4004, Types.PropHunt, cs(Color.red, "错误击杀后的冷却时间"), 10f, 2.5f, 60f, 2.5f);
            hunterHitCooldown = CustomOption.Create(4005, Types.PropHunt, cs(Color.red, "击杀后的冷却时间"), 10f, 2.5f, 60f, 2.5f);
            propHuntRevealCooldown = CustomOption.Create(4008, Types.PropHunt, cs(Color.red, "变形冷却时间"), 30f, 10f, 90f, 2.5f);
            propHuntRevealDuration = CustomOption.Create(4009, Types.PropHunt, cs(Color.red, "变形持续时间"), 5f, 1f, 60f, 1f);
            propHuntRevealPunish = CustomOption.Create(4010, Types.PropHunt, cs(Color.red, "揭示惩罚时间"), 10f, 0f, 1800f, 5f);
            propHuntAdminCooldown = CustomOption.Create(4022, Types.PropHunt, cs(Color.red, "猎人管理地图冷却时间"), 30f, 2.5f, 1800f, 2.5f);
            propHuntFindCooldown = CustomOption.Create(4023, Types.PropHunt, cs(Color.red, "寻找冷却时间"), 60f, 2.5f, 1800f, 2.5f);
            propHuntFindDuration = CustomOption.Create(4024, Types.PropHunt, cs(Color.red, "寻找持续时间"), 5f, 1f, 15f, 1f);
            // Prop Options
            propBecomesHunterWhenFound = CustomOption.Create(4003, Types.PropHunt, cs(Palette.CrewmateBlue, "变形者被击杀后变成猎人"), false, null, true, heading: "躲藏者设置");
            propHuntInvisEnabled = CustomOption.Create(4013, Types.PropHunt, cs(Palette.CrewmateBlue, "启用隐身技能"), true, null, true);
            propHuntInvisCooldown = CustomOption.Create(4014, Types.PropHunt, cs(Palette.CrewmateBlue, "隐身冷却时间"), 120f, 10f, 1800f, 2.5f, propHuntInvisEnabled);
            propHuntInvisDuration = CustomOption.Create(4015, Types.PropHunt, cs(Palette.CrewmateBlue, "隐身持续时间"), 5f, 1f, 30f, 1f, propHuntInvisEnabled);
            propHuntSpeedboostEnabled = CustomOption.Create(4016, Types.PropHunt, cs(Palette.CrewmateBlue, "启用加速技能"), true, null, true);
            propHuntSpeedboostCooldown = CustomOption.Create(4017, Types.PropHunt, cs(Palette.CrewmateBlue, "加速冷却时间"), 60f, 2.5f, 1800f, 2.5f, propHuntSpeedboostEnabled);
            propHuntSpeedboostDuration = CustomOption.Create(4018, Types.PropHunt, cs(Palette.CrewmateBlue, "加速持续时间"), 5f, 1f, 15f, 1f, propHuntSpeedboostEnabled);
            propHuntSpeedboostSpeed = CustomOption.Create(4019, Types.PropHunt, cs(Palette.CrewmateBlue, "加速提升速度"), 2f, 1.25f, 5f, 0.25f, propHuntSpeedboostEnabled);


            // Other options
            CanUseSwitchShipCostumeButton = CustomOption.Create(14, Types.General, "切换地图皮肤(仅支持骷髅舰)", false, null, true, heading: "切换地图皮肤");
            debugMode = CustomOption.Create(9, Types.General, "测试模式", false, null, true, heading:"测试模式");
            disableGameEnd = CustomOption.Create(951, Types.General, "游戏不结束", false, debugMode);
            maxNumberOfMeetings = CustomOption.Create(3, Types.General, "会议总次数 (不计入市长)", 10, 0, 15, 1, null, true, heading: "游戏设定");
            anyPlayerCanStopStart = CustomOption.Create(2, Types.General, "所有玩家都可以暂停开始游戏", false, null, false);
            blockSkippingInEmergencyMeetings = CustomOption.Create(4, Types.General, "禁用会议中弃票", false);
            noVoteIsSelfVote = CustomOption.Create(5, Types.General, "不投票看作投自己", false, blockSkippingInEmergencyMeetings);
            hidePlayerNames = CustomOption.Create(6, Types.General, "隐藏玩家名称", false);
            allowParallelMedBayScans = CustomOption.Create(7, Types.General, "允许同时进行扫描", false);
            shieldFirstKill = CustomOption.Create(8, Types.General, "下一轮保护首刀玩家", false);
            finishTasksBeforeHauntingOrZoomingOut = CustomOption.Create(9, Types.General, "在未完成所有任务前不可以使用鬼影悠悠及千里眼", true);
            deadImpsBlockSabotage = CustomOption.Create(13, Types.General, "死去的内鬼是否可以进行破坏活动", false, null, false);
            camsNightVision = CustomOption.Create(11, Types.General, "在灯光被关闭时监控使用黑夜模式", false, null, true, heading: "夜视模式");
            camsNoNightVisionIfImpVision = CustomOption.Create(12, Types.General, "拥有内鬼视野的玩家无视黑夜模式", false, camsNightVision, false);


            dynamicMap = CustomOption.Create(500, Types.General, "在随机一个地图上玩", false, null, true, heading: "随机地图");
            dynamicMapEnableSkeld = CustomOption.Create(501, Types.General, "骷髅舰", rates, dynamicMap, false);
            dynamicMapEnableMira = CustomOption.Create(502, Types.General, "米拉HQ", rates, dynamicMap, false);
            dynamicMapEnablePolus = CustomOption.Create(503, Types.General, "波鲁斯", rates, dynamicMap, false);
            dynamicMapEnableAirShip = CustomOption.Create(504, Types.General, "高空飞艇", rates, dynamicMap, false);
            dynamicMapEnableFungle = CustomOption.Create(506, Types.General, "真菌世界", rates, dynamicMap, false);
            dynamicMapEnableSubmerged = CustomOption.Create(505, Types.General, "深海潜艇", rates, dynamicMap, false);
            dynamicMapSeparateSettings = CustomOption.Create(509, Types.General, "启用地图的预设", false, dynamicMap, false);

            blockedRolePairings.Add((byte)RoleId.Vampire, new [] { (byte)RoleId.Warlock});
            blockedRolePairings.Add((byte)RoleId.Warlock, new [] { (byte)RoleId.Vampire});
            blockedRolePairings.Add((byte)RoleId.Spy, new [] { (byte)RoleId.Mini});
            blockedRolePairings.Add((byte)RoleId.Mini, new [] { (byte)RoleId.Spy});
            blockedRolePairings.Add((byte)RoleId.Vulture, new [] { (byte)RoleId.Cleaner});
            blockedRolePairings.Add((byte)RoleId.Cleaner, new [] { (byte)RoleId.Vulture});
            
        }
    }
}
