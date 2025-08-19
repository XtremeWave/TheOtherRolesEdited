using System.Collections.Generic;
using UnityEngine;
using static TheOtherRolesEdited.TheOtherRolesEdited;
using Types = TheOtherRolesEdited.CustomOption.CustomOptionType;

namespace TheOtherRolesEdited {
    public class CustomOptionHolder {
        public static string[] rates = new string[]{"0%", "10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%"};
        public static string[] ratesModifier = new string[]{"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" };
        public static string[] presets = new string[] { "Ԥ�� 1", "Ԥ��  2", "�������ô�Ԥ�� ", "���������ܲ�Ԥ�� ", "���ò�³˹Ԥ�� ", "���÷�ͧԤ�� ", "����ǱͧԤ�� " };

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
        public static CustomOption modifierShifterShiftsMedicShield;

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
        
        //�ֳ�ѡְ
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
            presetSelection = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Ԥ��"), presets, null, true, heading: "��ϷԤ��");
            activateRoles = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "����ģ���ɫ����ֹʹ��ԭ���ɫ"), true, null, true, heading: "ģ��ѡ��");
            if (Utilities.EventUtility.canBeEnabled) enableEventMode = CustomOption.Create(Types.General, cs(Color.green, "�����ر�ģʽ"), true, null, true, heading: "�ر�ģʽ");
            
            isDraftMode = CustomOption.Create(Types.General, cs(Color.yellow, "�����ֳ�ѡְģʽ"), false, null, true, null, "�ֳ�ѡְ");
            draftModeAmountOfChoices = CustomOption.Create(Types.General, cs(Color.yellow, "����ѡְҵ����"), 5f, 2f, 15f, 1f, isDraftMode, false);
            draftModeTimeToChoose = CustomOption.Create(Types.General, cs(Color.yellow, "����ѡ��ʱ��"), 5f, 3f, 20f, 1f, isDraftMode, false);
            draftModeCanChat = CustomOption.Create(Types.General, cs(Color.yellow, "�ֳ�ѡְʱ��������"), false, isDraftMode, false);
            draftModeShowRoles = CustomOption.Create(Types.General, cs(Color.yellow, "��ʾ��ѡ�����ְҵ"), false, isDraftMode, false);
            draftModeHideImpRoles = CustomOption.Create(Types.General, cs(Color.yellow, "�����ڹ�ְҵ"), false, draftModeShowRoles, false);
            draftModeHideNeutralRoles = CustomOption.Create(Types.General, cs(Color.yellow, "��������ְҵ"), false, draftModeShowRoles, false);
            draftModeHideCrewRoles = CustomOption.Create(Types.General, cs(Color.yellow, "���ش�Աְҵ"), false, draftModeShowRoles, false);
            
            // Using new id's for the options to not break compatibilty with older versions
           
            crewmateRolesCountMin = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "���ٴ�Աְҵ"), 15f, 0f, 15f, 1f, null, true, heading: "ְҵ��С��������");
            crewmateRolesCountMax = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "��ബԱְҵ"), 15f, 0f, 15f, 1f);
            neutralRolesCountMin = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "��������ְҵ"), 15f, 0f, 15f, 1f);
            neutralRolesCountMax = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "�������ְҵ"), 15f, 0f, 15f, 1f);
            impostorRolesCountMin = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "�����ڹ�ְҵ"), 15f, 0f, 15f, 1f);
            impostorRolesCountMax = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "����ڹ�ְҵ"), 15f, 0f, 15f, 1f);
            modifiersCountMin = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "���ٸ���ְҵ"), 15f, 0f, 15f, 1f);
            modifiersCountMax = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "��฽��ְҵ"), 15f, 0f, 15f, 1f);
            crewmateRolesFill = CustomOption.Create(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "���д�Աְҵ(��������/���ֵ)"), false);
            
            mafiaSpawnRate = CustomOption.Create(Types.Impostor, cs(Janitor.color, "���ֵ�"), rates, null, true);
            janitorCooldown = CustomOption.Create(Types.Impostor, "��๤������ȴʱ��", 30f, 10f, 60f, 2.5f, mafiaSpawnRate);
            
            morphlingSpawnRate = CustomOption.Create(Types.Impostor, cs(Morphling.color, "������"), rates, null, true);
            morphlingCooldown = CustomOption.Create(Types.Impostor, "ȡ����ȴʱ��", 30f, 10f, 60f, 2.5f, morphlingSpawnRate);
            morphlingDuration = CustomOption.Create(Types.Impostor, "���γ���ʱ��", 10f, 1f, 20f, 0.5f, morphlingSpawnRate);
            
            camouflagerSpawnRate = CustomOption.Create(Types.Impostor, cs(Camouflager.color, "������"), rates, null, true);
            camouflagerCooldown = CustomOption.Create(Types.Impostor, "���μ�����ȴʱ��", 30f, 10f, 60f, 2.5f, camouflagerSpawnRate);
            camouflagerDuration = CustomOption.Create(Types.Impostor, "���μ��ܳ���ʱ��", 10f, 1f, 20f, 0.5f, camouflagerSpawnRate);
            
            vampireSpawnRate = CustomOption.Create(Types.Impostor, cs(Vampire.color, "��Ѫ��"), rates, null, true);
            vampireKillDelay = CustomOption.Create(Types.Impostor, "��Ѫ�����ӳٻ�ɱʱ��", 10f, 1f, 20f, 1f, vampireSpawnRate);
            vampireCooldown = CustomOption.Create(Types.Impostor, "��Ѫ������ȴʱ��", 30f, 10f, 60f, 2.5f, vampireSpawnRate);
            vampireCanKillNearGarlics = CustomOption.Create(Types.Impostor, "��Ѫ������ڴ��ⷶΧ�ڻ�ɱ", true, vampireSpawnRate);
            
            eraserSpawnRate = CustomOption.Create(Types.Impostor, cs(Eraser.color, "Ĩ����"), rates, null, true);
            eraserCooldown = CustomOption.Create(Types.Impostor, "Ĩ��������ȴʱ��", 30f, 10f, 120f, 5f, eraserSpawnRate);
            eraserCanEraseAnyone = CustomOption.Create(Types.Impostor, "����Ĩ�������˵�ְҵ(�������ѣ�", false, eraserSpawnRate);
            
            tricksterSpawnRate = CustomOption.Create(Types.Impostor, cs(Trickster.color, "ƭ��ʦ"), rates, null, true);
            tricksterPlaceBoxCooldown = CustomOption.Create(Types.Impostor, "���ú��Ӽ�����ȴʱ��", 10f, 2.5f, 30f, 2.5f, tricksterSpawnRate);
            tricksterLightsOutCooldown = CustomOption.Create(Types.Impostor, "Ϩ�Ƽ�����ȴʱ��", 30f, 10f, 60f, 5f, tricksterSpawnRate);
            tricksterLightsOutDuration = CustomOption.Create(Types.Impostor, "Ϩ�Ƽ��ܳ���ʱ��", 15f, 5f, 60f, 2.5f, tricksterSpawnRate);
            
            cleanerSpawnRate = CustomOption.Create(Types.Impostor, cs(Cleaner.color, "������"), rates, null, true);
            cleanerCooldown = CustomOption.Create(Types.Impostor, "��������ȴʱ��", 30f, 10f, 60f, 2.5f, cleanerSpawnRate);
           
            warlockSpawnRate = CustomOption.Create(Types.Impostor, cs(Cleaner.color, "��ʿ"), rates, null, true);
            warlockCooldown = CustomOption.Create(Types.Impostor, "���似����ȴʱ��", 30f, 10f, 60f, 2.5f, warlockSpawnRate);
            warlockRootTime = CustomOption.Create(Types.Impostor, "��ʿ����ʱ��", 5f, 0f, 15f, 1f, warlockSpawnRate);
            
            bountyHunterSpawnRate = CustomOption.Create(Types.Impostor, cs(BountyHunter.color, "�ͽ�����"), rates, null, true);
            bountyHunterBountyDuration = CustomOption.Create(Types.Impostor, "�ͽ�Ŀ���л�ʱ��", 60f, 10f, 180f, 10f, bountyHunterSpawnRate);
            bountyHunterReducedCooldown = CustomOption.Create(Types.Impostor, "��ɱ�ͽ�Ŀ����ɱ������ȴʱ��", 2.5f, 0f, 30f, 2.5f, bountyHunterSpawnRate);
            bountyHunterPunishmentTime = CustomOption.Create(Types.Impostor, "��ɱ���ͽ�Ŀ����ɱ������ȴʱ��", 20f, 0f, 60f, 2.5f, bountyHunterSpawnRate);
            bountyHunterShowArrow = CustomOption.Create(Types.Impostor, "��ʾָ���ͽ�Ŀ��ļ�ͷ", true, bountyHunterSpawnRate);
            bountyHunterArrowUpdateIntervall = CustomOption.Create(Types.Impostor, "�ͽ�Ŀ��λ�ø����ӳ�", 15f, 2.5f, 60f, 2.5f, bountyHunterShowArrow);
           
            witchSpawnRate = CustomOption.Create(Types.Impostor, cs(Witch.color, "Ů��"), rates, null, true);
            witchCooldown = CustomOption.Create(Types.Impostor, "Ů�����似����ȴʱ��", 30f, 10f, 120f, 5f, witchSpawnRate);
            witchAdditionalCooldown = CustomOption.Create(Types.Impostor, "Ů�׼�����ȴ����ʱ��", 10f, 0f, 60f, 5f, witchSpawnRate);
            witchCanSpellAnyone = CustomOption.Create(Types.Impostor, "Ů�׿�������������", false, witchSpawnRate);
            witchSpellCastingDuration = CustomOption.Create(Types.Impostor, "Ů�����似�ܳ���ʱ��", 1f, 0f, 10f, 1f, witchSpawnRate);
            witchTriggerBothCooldowns = CustomOption.Create(Types.Impostor, "Ů������ͻ�ɱ������ȴʱ��", true, witchSpawnRate);
            witchVoteSavesTargets = CustomOption.Create(Types.Impostor, "Ů�������Ͷ���������߻��", true, witchSpawnRate);
           
            ninjaSpawnRate = CustomOption.Create(Types.Impostor, cs(Ninja.color, "����"), rates, null, true);
            ninjaCooldown = CustomOption.Create(Types.Impostor, "����ѡ��Ŀ����ȴʱ��", 30f, 10f, 120f, 5f, ninjaSpawnRate);
            ninjaKnowsTargetLocation = CustomOption.Create(Types.Impostor, "���߿�֪Ŀ���λ��", true, ninjaSpawnRate);
            ninjaTraceTime = CustomOption.Create(Types.Impostor, "��ɴ�ɱ����Ҷ���ٳ���ʱ��", 5f, 1f, 20f, 0.5f, ninjaSpawnRate);
            ninjaTraceColorTime = CustomOption.Create(Types.Impostor, "��Ҷ��ɫ��ʱ��", 2f, 0f, 20f, 0.5f, ninjaSpawnRate);
            ninjaInvisibleDuration = CustomOption.Create(Types.Impostor, "��������ʱ��", 3f, 0f, 20f, 1f, ninjaSpawnRate);
           
            bomberSpawnRate = CustomOption.Create(Types.Impostor, cs(Bomber.color, "��ը��"), rates, null, true);
            bomberBombDestructionTime = CustomOption.Create(Types.Impostor, "ը������ʱ��", 20f, 2.5f, 120f, 2.5f, bomberSpawnRate);
            bomberBombDestructionRange = CustomOption.Create(Types.Impostor, "ը���ƻ���Χ", 50f, 5f, 150f, 5f, bomberSpawnRate);
            bomberBombHearRange = CustomOption.Create(Types.Impostor, "ը����ը��Χ", 60f, 5f, 150f, 5f, bomberSpawnRate);
            bomberDefuseDuration = CustomOption.Create(Types.Impostor, "�𵯳���ʱ��", 3f, 0.5f, 30f, 0.5f, bomberSpawnRate);
            bomberBombCooldown = CustomOption.Create(Types.Impostor, "ը��������ȴʱ��", 15f, 2.5f, 30f, 2.5f, bomberSpawnRate);
            bomberBombActiveAfter = CustomOption.Create(Types.Impostor, "ը����������ʱ��", 3f, 0.5f, 15f, 0.5f, bomberSpawnRate);
            
            yoyoSpawnRate = CustomOption.Create(Types.Impostor, cs(Yoyo.color, "������"), rates, null, true);
            yoyoBlinkDuration = CustomOption.Create(Types.Impostor, "˲�Ƴ���ʱ��", 20f, 2.5f, 120f, 2.5f, yoyoSpawnRate);
            yoyoMarkCooldown = CustomOption.Create(Types.Impostor, "���λ����ȴʱ��", 20f, 2.5f, 120f, 2.5f, yoyoSpawnRate);
            yoyoMarkStaysOverMeeting = CustomOption.Create(Types.Impostor, "��ǵ�λ�û����������", true, yoyoSpawnRate);
            yoyoHasAdminTable = CustomOption.Create(Types.Impostor, "ӵ�б�Яʽ��ͼ", true, yoyoSpawnRate);
            yoyoAdminTableCooldown = CustomOption.Create(Types.Impostor, "��Яʽ��ͼ��ȴʱ��", 20f, 2.5f, 120f, 2.5f, yoyoHasAdminTable);
            yoyoSilhouetteVisibility = CustomOption.Create(Types.Impostor, "��Ӱ�ɼ���", new string[] { "0%", "10%", "20%", "30%", "40%", "50%" }, yoyoSpawnRate);
           
            minerSpawnRate = CustomOption.Create(Types.Impostor, cs(Miner.color, "��"), rates, null, true);
            minerCooldown = CustomOption.Create(Types.Impostor, "�ھ���ȴʱ��", 25f, 10f, 60f, 2.5f, minerSpawnRate);
            
            blackmailerSpawnRate = CustomOption.Create(Types.Impostor, cs(Blackmailer.color, "������"), rates, null, true);
            blackmailerCooldown = CustomOption.Create(Types.Impostor, "������ȴʱ��", 30f, 5f, 120f, 5f, blackmailerSpawnRate);
            guesserSpawnRate = CustomOption.Create(Types.Neutral, cs(Guesser.color, "�Ĺ�"), rates, null, true);
            
            guesserIsImpGuesserRate = CustomOption.Create(Types.Neutral, "�Ĺ����ڹ�Ļ���", rates, guesserSpawnRate);
            guesserNumberOfShots = CustomOption.Create(Types.Neutral, "�ĹֵĶ�ɱ����", 2f, 1f, 15f, 1f, guesserSpawnRate);
            guesserHasMultipleShotsPerMeeting = CustomOption.Create(Types.Neutral, "�Ĺֿ����ڻ����϶�ζ�ɱ", false, guesserSpawnRate);
            guesserKillsThroughShield = CustomOption.Create(Types.Neutral, "�Ĺֶ�ɱʱ����ҽ���Ķ�", true, guesserSpawnRate);
            guesserEvilCanKillSpy = CustomOption.Create(Types.Neutral, "а��ĶĹֿ��Զ�ɱ�Ե�", true, guesserSpawnRate);
            guesserSpawnBothRate = CustomOption.Create(Types.Neutral, "�����ĹֵĻ���", rates, guesserSpawnRate);
            guesserCantGuessSnitchIfTaksDone = CustomOption.Create(Types.Neutral, "�Ĺ��޷���ɱ�������ĸ�����", true, guesserSpawnRate);
            
            jesterSpawnRate = CustomOption.Create(Types.Neutral, cs(Jester.color, "С��"), rates, null, true);
            jesterCanCallEmergency = CustomOption.Create(Types.Neutral, "С������ٿ���������", true, jesterSpawnRate);
            jesterHasImpostorVision = CustomOption.Create(Types.Neutral, "С�����ڹ����Ұ", false, jesterSpawnRate);
            arsonistSpawnRate = CustomOption.Create(Types.Neutral, cs(Arsonist.color, "�ݻ�"), rates, null, true);
            arsonistCooldown = CustomOption.Create(Types.Neutral, "���ͼ�����ȴʱ��", 12.5f, 2.5f, 60f, 2.5f, arsonistSpawnRate);
            arsonistDuration = CustomOption.Create(Types.Neutral, "���ͼ��ܳ���ʱ��", 3f, 1f, 10f, 1f, arsonistSpawnRate);
          
            jackalSpawnRate = CustomOption.Create(Types.Neutral, cs(Jackal.color, "����"), rates, null, true);
            jackalKillCooldown = CustomOption.Create(Types.Neutral, "����/����Ļ�ɱ��ȴʱ��", 30f, 10f, 60f, 2.5f, jackalSpawnRate);
            jackalCreateSidekickCooldown = CustomOption.Create(Types.Neutral, "������ļ������ȴʱ��", 30f, 10f, 60f, 2.5f, jackalSpawnRate);
            jackalCanUseVents = CustomOption.Create(Types.Neutral, "���ǿ���ʹ�ùܵ�", true, jackalSpawnRate);
            sidekickCanSabotageLights = CustomOption.Create(Types.Neutral, "��������ƻ��ƹ�", true, jackalSpawnRate);
            jackalCanCreateSidekick = CustomOption.Create(Types.Neutral, "���ǿ�����ļһ������", false, jackalSpawnRate);
            jackalCanSabotageLights = CustomOption.Create(Types.Neutral, "���ǿ����ƻ��ƹ�", true, jackalSpawnRate);
            sidekickPromotesToJackal = CustomOption.Create(Types.Neutral, "�����ڲ��������������", false, jackalCanCreateSidekick);
            sidekickCanKill = CustomOption.Create(Types.Neutral, "������Ի�ɱ", false, jackalCanCreateSidekick);
            sidekickCanUseVents = CustomOption.Create(Types.Neutral, "�������ʹ�ùܵ�", true, jackalCanCreateSidekick);
            jackalPromotedFromSidekickCanCreateSidekick = CustomOption.Create(Types.Neutral, "�����ĸ������ӵ����ļ����", true, sidekickPromotesToJackal);
            jackalCanCreateSidekickFromImpostor = CustomOption.Create(Types.Neutral, "���ǿ�����ļ�ڹ�Ϊ�Լ��ĸ���", true, jackalCanCreateSidekick);
            jackalAndSidekickHaveImpostorVision = CustomOption.Create(Types.Neutral, "���Ǻ͸���ӵ���ڹ����Ұ", false, jackalSpawnRate);
            
            vultureSpawnRate = CustomOption.Create(Types.Neutral, cs(Vulture.color, "ͺ��"), rates, null, true);
            vultureCooldown = CustomOption.Create(Types.Neutral, "���ɼ�����ȴʱ��", 15f, 10f, 60f, 2.5f, vultureSpawnRate);
            vultureNumberToWin = CustomOption.Create(Types.Neutral, "��Ҫ�Ե���ʬ������", 4f, 1f, 10f, 1f, vultureSpawnRate);
            vultureCanUseVents = CustomOption.Create(Types.Neutral, "ͺ�տ���ʹ�ùܵ�", true, vultureSpawnRate);
            vultureShowArrows = CustomOption.Create(Types.Neutral, "ͺ����ָ��ʬ��ļ�ͷ", true, vultureSpawnRate);
           
            lawyerSpawnRate = CustomOption.Create(Types.Neutral, cs(Lawyer.color, "��ʦ"), rates, null, true);
            lawyerIsProsecutorChance = CustomOption.Create(Types.Neutral, "���ٵĿ�����", rates, lawyerSpawnRate);
            lawyerVision = CustomOption.Create(Types.Neutral, "��Ұ��С", 1f, 0.25f, 3f, 0.25f, lawyerSpawnRate);
            lawyerKnowsRole = CustomOption.Create(Types.Neutral, "��ʦ/����֪��Ŀ���ְҵ", false, lawyerSpawnRate);
            lawyerCanCallEmergency = CustomOption.Create(Types.Neutral, "��ʦ/���ٿ����ٿ���������", true, lawyerSpawnRate);
            lawyerTargetCanBeJester = CustomOption.Create(Types.Neutral, "��ʦ/���ٵĿͻ�������С��", false, lawyerSpawnRate);
            pursuerCooldown = CustomOption.Create(Types.Neutral, "�����˿հ���������ȴʱ��", 30f, 5f, 60f, 2.5f, lawyerSpawnRate);
            pursuerBlanksNumber = CustomOption.Create(Types.Neutral, "�����˿հ���������", 5f, 1f, 20f, 1f, lawyerSpawnRate);
          
            mayorSpawnRate = CustomOption.Create(Types.Crewmate, cs(Mayor.color, "�г�"), rates, null, true);
            mayorCanSeeVoteColors = CustomOption.Create(Types.Crewmate, "�г����Կ���ͶƱ�ߵ���ɫ", false, mayorSpawnRate);
            mayorTasksNeededToSeeVoteColors = CustomOption.Create(Types.Crewmate, "�鿴ͶƱ��ɫ������ɵ�����", 5f, 0f, 20f, 1f, mayorCanSeeVoteColors);
            mayorMeetingButton = CustomOption.Create(Types.Crewmate, "���ñ�Яʽ�ƶ���������", true, mayorSpawnRate);
            mayorMaxRemoteMeetings = CustomOption.Create(Types.Crewmate, "��������Ĵ���", 1f, 1f, 5f, 1f, mayorMeetingButton);
            mayorChooseSingleVote = CustomOption.Create(Types.Crewmate, "�г�����ѡ��Ʊ", new string[] { "�ر�", "����(����֮ǰ)", "����(�����)" }, mayorSpawnRate);
            
            engineerSpawnRate = CustomOption.Create(Types.Crewmate, cs(Engineer.color, "����ʦ"), rates, null, true);
            engineerNumberOfFixes = CustomOption.Create(Types.Crewmate, "�����ܴ���", 1f, 1f, 3f, 1f, engineerSpawnRate);
            engineerHighlightForImpostors = CustomOption.Create(Types.Crewmate, "�ڹ���Կ�������ʦ�ڹܵ���", true, engineerSpawnRate);
            engineerHighlightForTeamJackal = CustomOption.Create(Types.Crewmate, "���Ǻ͸�����Կ�������ʦ�ڹܵ���", true, engineerSpawnRate);
           
            sheriffSpawnRate = CustomOption.Create(Types.Crewmate, cs(Sheriff.color, "����"), rates, null, true);
            sheriffCooldown = CustomOption.Create(Types.Crewmate, "��ɱ��ȴʱ��", 30f, 10f, 60f, 2.5f, sheriffSpawnRate);
            sheriffCanKillNeutrals = CustomOption.Create(Types.Crewmate, "�������Ի�ɱ������Ӫ�����", false, sheriffSpawnRate);
            deputySpawnRate = CustomOption.Create(Types.Crewmate, cs(Sheriff.color, "����"), rates, sheriffSpawnRate);
            deputyNumberOfHandcuffs = CustomOption.Create(Types.Crewmate, "��������������", 3f, 1f, 10f, 1f, deputySpawnRate);
            deputyHandcuffCooldown = CustomOption.Create(Types.Crewmate, "����������ȴʱ��", 30f, 10f, 60f, 2.5f, deputySpawnRate);
            deputyHandcuffDuration = CustomOption.Create(Types.Crewmate, "�����������ʱ��", 15f, 5f, 60f, 2.5f, deputySpawnRate);
            deputyKnowsSheriff = CustomOption.Create(Types.Crewmate, "�����Ͳ��������ʶ", true, deputySpawnRate);
            deputyGetsPromoted = CustomOption.Create(Types.Crewmate, "�������󲶿���Խ�������", new string[] { "�ر�", "����(����)", "����(�����)" }, deputySpawnRate);
            deputyKeepsHandcuffs = CustomOption.Create(Types.Crewmate, "���������������������", true, deputyGetsPromoted);
           
            lighterSpawnRate = CustomOption.Create(Types.Crewmate, cs(Lighter.color, "ִ����"), rates, null, true);
            lighterModeLightsOnVision = CustomOption.Create(Types.Crewmate, "�ƹ⿪����Ұ", 1.5f, 0.25f, 5f, 0.25f, lighterSpawnRate);
            lighterModeLightsOffVision = CustomOption.Create(Types.Crewmate, "�ƹ�ر���Ұ", 0.5f, 0.25f, 5f, 0.25f, lighterSpawnRate);
            lighterFlashlightWidth = CustomOption.Create(Types.Crewmate, "�ƹ���Ұ���", 0.3f, 0.1f, 1f, 0.1f, lighterSpawnRate);
           
            detectiveSpawnRate = CustomOption.Create(Types.Crewmate, cs(Detective.color, "��̽"), rates, null, true);
            detectiveAnonymousFootprints = CustomOption.Create(Types.Crewmate, "������ӡ", false, detectiveSpawnRate);
            detectiveFootprintIntervall = CustomOption.Create(Types.Crewmate, "��ӡ���", 0.5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
            detectiveFootprintDuration = CustomOption.Create(Types.Crewmate, "��ӡ����ʱ��", 5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
            detectiveReportNameDuration = CustomOption.Create(Types.Crewmate, "��һ����ʱ������̽���������ֵ�����", 0, 0, 60, 2.5f, detectiveSpawnRate);
            detectiveReportColorDuration = CustomOption.Create(Types.Crewmate, "��һ����ʱ������̽��������ɫ����", 20, 0, 120, 2.5f, detectiveSpawnRate);
           
            timeMasterSpawnRate = CustomOption.Create(Types.Crewmate, cs(TimeMaster.color, "ʱ��֮��"), rates, null, true);
            timeMasterCooldown = CustomOption.Create(Types.Crewmate, "ʱ��֮����ȴʱ��", 30f, 10f, 120f, 2.5f, timeMasterSpawnRate);
            timeMasterShieldDuration = CustomOption.Create(Types.Crewmate, "ʱ��֮�ܳ���ʱ��", 3f, 1f, 20f, 1f, timeMasterSpawnRate);
            timeMasterRewindTime = CustomOption.Create(Types.Crewmate, "����ʱ��", 3f, 1f, 10f, 1f, timeMasterSpawnRate);
           
            medicSpawnRate = CustomOption.Create(Types.Crewmate, cs(Medic.color, "ҽ��"), rates, null, true);
            medicShowShielded = CustomOption.Create(Types.Crewmate, "�����˿ɼ����ܱ��������", new string[] { "�����˿ɼ�", "�������ߺ�ҽ���ɼ�", "��ҽ���ɼ�" }, medicSpawnRate);
            medicShowAttemptToShielded = CustomOption.Create(Types.Crewmate, "�����ܱ���������类��ɱ��������һ�����ʾ", false, medicSpawnRate);
            medicSetOrShowShieldAfterMeeting = CustomOption.Create(Types.Crewmate, "���ܽ�������", new string[] { "����", "�����\n�����ɼ�", "�����" }, medicSpawnRate);
            medicShowAttemptToMedic = CustomOption.Create(Types.Crewmate, "�����ܱ���������类��ɱҽ��������ʾ", false, medicSpawnRate);
            medicSetShieldAfterMeeting = CustomOption.Create(Types.Crewmate, "ҽ���ڻ�������û���", false, medicSpawnRate);
           
            swapperSpawnRate = CustomOption.Create(Types.Crewmate, cs(Swapper.color, "��Ʊʦ"), rates, null, true);
            swapperCanCallEmergency = CustomOption.Create(Types.Crewmate, "��Ʊʦ���Կ�����������", false, swapperSpawnRate);
            swapperCanOnlySwapOthers = CustomOption.Create(Types.Crewmate, "��Ʊʦֻ�ܽ������˵�Ʊ��", false, swapperSpawnRate);
            swapperSwapsNumber = CustomOption.Create(Types.Crewmate, "��ʼ��Ʊ����", 1f, 0f, 5f, 1f, swapperSpawnRate);
            swapperRechargeTasksNumber = CustomOption.Create(Types.Crewmate, "�����������������", 2f, 1f, 10f, 1f, swapperSpawnRate);
           
            seerSpawnRate = CustomOption.Create(Types.Crewmate, cs(Seer.color, "��ý"), rates, null, true);
            seerMode = CustomOption.Create(Types.Crewmate, "��ý����Ϸ�еļ���", new string[] { "��ʾ�������� + ���", "ֻ��ʾ��������", "ֻ��ʾ���" }, seerSpawnRate);
            seerLimitSoulDuration = CustomOption.Create(Types.Crewmate, "��ý�ɿ������", false, seerSpawnRate);
            seerSoulDuration = CustomOption.Create(Types.Crewmate, "��ý�������ĳ���ʱ��", 15f, 0f, 120f, 5f, seerLimitSoulDuration);
           
            hackerSpawnRate = CustomOption.Create(Types.Crewmate, cs(Hacker.color, "�ڿ�"), rates, null, true);
            hackerCooldown = CustomOption.Create(Types.Crewmate, "���뼼����ȴʱ��", 30f, 5f, 60f, 5f, hackerSpawnRate);
            hackerHackeringDuration = CustomOption.Create(Types.Crewmate, "���뼼�ܳ���ʱ��", 10f, 2.5f, 60f, 2.5f, hackerSpawnRate);
            hackerOnlyColorType = CustomOption.Create(Types.Crewmate, "�ڿ�ֻ���ڹ����ҿ��������ɫ", false, hackerSpawnRate);
            hackerToolsNumber = CustomOption.Create(Types.Crewmate, "����ƶ���ͼ�ĳ��ܴ���", 5f, 1f, 30f, 1f, hackerSpawnRate);
            hackerRechargeTasksNumber = CustomOption.Create(Types.Crewmate, "��ͼ���������������", 2f, 1f, 5f, 1f, hackerSpawnRate);
            hackerNoMove = CustomOption.Create(Types.Crewmate, "��ʹ���ƶ���ͼʱ�޷��ƶ�", true, hackerSpawnRate);
           
            trackerSpawnRate = CustomOption.Create(Types.Crewmate, cs(Tracker.color, "׷����"), rates, null, true);
            trackerUpdateIntervall = CustomOption.Create(Types.Crewmate, "׷���߼�ͷ�����ӳ�", 5f, 1f, 30f, 1f, trackerSpawnRate);
            trackerResetTargetAfterMeeting = CustomOption.Create(Types.Crewmate, "׷�����ڻ��������׷��", false, trackerSpawnRate);
            trackerCanTrackCorpses = CustomOption.Create(Types.Crewmate, "׷���߿���׷��ʬ��", true, trackerSpawnRate);
            trackerCorpsesTrackingCooldown = CustomOption.Create(Types.Crewmate, "׷��ʬ����ȴʱ��", 30f, 5f, 120f, 5f, trackerCanTrackCorpses);
            trackerCorpsesTrackingDuration = CustomOption.Create(Types.Crewmate, "׷��ʬ�����ʱ��", 5f, 2.5f, 30f, 2.5f, trackerCanTrackCorpses);
            trackerTrackingMethod = CustomOption.Create(Types.Crewmate, "׷������λ�ȡĿ��λ��", new string[] { "1.����ͷ", "2.���ӽ������", "1 + 2" }, trackerSpawnRate);
           
            snitchSpawnRate = CustomOption.Create(Types.Crewmate, cs(Snitch.color, "������"), rates, null, true);
            snitchLeftTasksForReveal = CustomOption.Create(Types.Crewmate, "��������ʣ�¶���ʱִ���ߵõ�����λ��", 5f, 0f, 25f, 1f, snitchSpawnRate);
            snitchMode = CustomOption.Create(Types.Crewmate, "�ṩ����Ϣģʽ", new string[] { "1.����", "2.��ͼ", "1 + 2" }, snitchSpawnRate);
            snitchTargets = CustomOption.Create(Types.Crewmate, "����Ŀ��", new string[] { "�����ڹ� & �������", "�������" }, snitchSpawnRate);
            
            spySpawnRate = CustomOption.Create(Types.Crewmate, cs(Spy.color, "�Ե�"), rates, null, true);
            spyCanDieToSheriff = CustomOption.Create(Types.Crewmate, "�Ե׿��Է��������Ļ�ɱ", false, spySpawnRate);
            spyImpostorsCanKillAnyone = CustomOption.Create(Types.Crewmate, "�����Ե�ʱ�ڹ���Ի�ɱ������(��������)", true, spySpawnRate);
            spyCanEnterVents = CustomOption.Create(Types.Crewmate, "�Ե׿���ʹ�ùܵ�", false, spySpawnRate);
            spyHasImpostorVision = CustomOption.Create(Types.Crewmate, "�Ե����ڹ���Ұ", false, spySpawnRate);
            
            portalmakerSpawnRate = CustomOption.Create(Types.Crewmate, cs(Portalmaker.color, "����ʦ"), rates, null, true);
            portalmakerCooldown = CustomOption.Create(Types.Crewmate, "������ż�����ȴʱ��", 30f, 10f, 60f, 2.5f, portalmakerSpawnRate);
            portalmakerUsePortalCooldown = CustomOption.Create(Types.Crewmate, "ʹ�ô�������ȴʱ��", 30f, 10f, 60f, 2.5f, portalmakerSpawnRate);
            portalmakerLogOnlyColorType = CustomOption.Create(Types.Crewmate, "����ʦ����־��ʾ��ɫ����", true, portalmakerSpawnRate);
            portalmakerLogHasTime = CustomOption.Create(Types.Crewmate, "��־��ʾʱ��", true, portalmakerSpawnRate);
            portalmakerCanPortalFromAnywhere = CustomOption.Create(Types.Crewmate, "����ʦ���Դ��κεط�ֱ�ﴫ���Ŵ�", true, portalmakerSpawnRate);
          
            securityGuardSpawnRate = CustomOption.Create(Types.Crewmate, cs(SecurityGuard.color, "����"), rates, null, true);
            securityGuardCooldown = CustomOption.Create(Types.Crewmate, "����������ȴʱ��", 30f, 10f, 60f, 2.5f, securityGuardSpawnRate);
            securityGuardTotalScrews = CustomOption.Create(Types.Crewmate, "������˿����", 7f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardCamPrice = CustomOption.Create(Types.Crewmate, "ÿ�����������˿����", 2f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardVentPrice = CustomOption.Create(Types.Crewmate, "ÿ���ܵ�������˿����", 1f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardCamDuration = CustomOption.Create(Types.Crewmate, "�������ܳ���ʱ��", 10f, 2.5f, 60f, 2.5f, securityGuardSpawnRate);
            securityGuardCamMaxCharges = CustomOption.Create(Types.Crewmate, "��˿������", 5f, 1f, 30f, 1f, securityGuardSpawnRate);
            securityGuardCamRechargeTasksNumber = CustomOption.Create(Types.Crewmate, "��Яʽ��������������������", 3f, 1f, 10f, 1f, securityGuardSpawnRate);
            securityGuardNoMove = CustomOption.Create(Types.Crewmate, "��ʹ�ñ�Яʽ�����ʱ�޷��ƶ�", true, securityGuardSpawnRate);
           
            mediumSpawnRate = CustomOption.Create(Types.Crewmate, cs(Medium.color, "ͨ��ʦ"), rates, null, true);
            mediumCooldown = CustomOption.Create(Types.Crewmate, "ͨ�鼼����ȴʱ��", 30f, 5f, 120f, 5f, mediumSpawnRate);
            mediumDuration = CustomOption.Create(Types.Crewmate, "ͨ�鼼�ܳ���ʱ��", 3f, 0f, 15f, 1f, mediumSpawnRate);
            mediumOneTimeUse = CustomOption.Create(Types.Crewmate, "ÿ�����ֻ�ܱ�ͨ��һ��", false, mediumSpawnRate);
            mediumChanceAdditionalInfo = CustomOption.Create(Types.Crewmate, "��Ϣ�Ļ��� \n ������Ϣ", rates, mediumSpawnRate);
           
            thiefSpawnRate = CustomOption.Create(Types.Neutral, cs(Thief.color, "ǿ��"), rates, null, true);
            thiefCooldown = CustomOption.Create(Types.Neutral, "���Ἴ����ȴʱ��", 30f, 5f, 120f, 5f, thiefSpawnRate);
            thiefCanKillSheriff = CustomOption.Create(Types.Neutral, "ǿ�����Ի�ɱ����", true, thiefSpawnRate);
            thiefHasImpVision = CustomOption.Create(Types.Neutral, "ǿ��ӵ���ڹ����Ұ", true, thiefSpawnRate);
            thiefCanUseVents = CustomOption.Create(Types.Neutral, "ǿ������ʹ�ùܵ�", true, thiefSpawnRate);
            thiefCanStealWithGuess = CustomOption.Create(Types.Neutral, "ǿ������ͨ����ɱ�õ�ְҵ(�Ĺ�ģʽ)", false, thiefSpawnRate);
            
            trapperSpawnRate = CustomOption.Create(Types.Crewmate, cs(Trapper.color, "����"), rates, null, true);
            trapperCooldown = CustomOption.Create(Types.Crewmate, "���弼����ȴʱ��", 30f, 5f, 120f, 5f, trapperSpawnRate);
            trapperMaxCharges = CustomOption.Create(Types.Crewmate, "�����������ĳ���", 5f, 1f, 15f, 1f, trapperSpawnRate);
            trapperRechargeTasksNumber = CustomOption.Create(Types.Crewmate, "���������������", 2f, 1f, 15f, 1f, trapperSpawnRate);
            trapperTrapNeededTriggerToReveal = CustomOption.Create(Types.Crewmate, "������Ҫ���������ܽ�ʾ", 3f, 2f, 10f, 1f, trapperSpawnRate);
            trapperAnonymousMap = CustomOption.Create(Types.Crewmate, "��ʾ������ͼ", false, trapperSpawnRate);
            trapperInfoType = CustomOption.Create(Types.Crewmate, "������Ϣ����", new string[] { "ְҵ", "����/а���ְҵ", "�������" }, trapperSpawnRate);
            trapperTrapDuration = CustomOption.Create(Types.Crewmate, "�������ʱ��", 5f, 1f, 15f, 1f, trapperSpawnRate);
            // Modifier (1000 - 1999)
            //modifiersAreHidden = CustomOption.Create(1009, Types.Modifier, cs(Color.yellow, "�������ظ���ְҵ"), true, null, true); �輧farewell�������
            modifiersAreHidden = CustomOption.Create(Types.Modifier, cs(Color.yellow, "����VIP, �ն� & ��Ѫ��"), true, null, true, heading: cs(Color.yellow, "�������ظ���ְҵЧ��"));
          
            modifierBloody = CustomOption.Create(Types.Modifier, cs(Bloody.color, "��Ѫ��"), rates, null, true);
            modifierBloodyQuantity = CustomOption.Create(Types.Modifier, "��Ѫ������", ratesModifier, modifierBloody);
            modifierBloodyDuration = CustomOption.Create(Types.Modifier, "Ѫ������ʱ��", 10f, 3f, 60f, 1f, modifierBloody);
           
            modifierAntiTeleport = CustomOption.Create(Types.Modifier, cs(AntiTeleport.color, "���˶�"), rates, null, true);
            modifierAntiTeleportQuantity = CustomOption.Create(Types.Modifier, "���˶�����", ratesModifier, modifierAntiTeleport);
          
            modifierTieBreaker = CustomOption.Create(Types.Modifier, cs(Tiebreaker.color, "��ƽ��"), rates, null, true);
           
            modifierBait = CustomOption.Create(Types.Modifier, cs(Bait.color, "�ն�"), rates, null, true);
            modifierBaitQuantity = CustomOption.Create(Types.Modifier, "�ն�����", ratesModifier, modifierBait);
            modifierBaitReportDelayMin = CustomOption.Create(Types.Modifier, "�ն������ӳ���Сֵ", 0f, 0f, 10f, 1f, modifierBait);
            modifierBaitReportDelayMax = CustomOption.Create(Types.Modifier, "�ն������ӳ����ֵ", 0f, 0f, 10f, 1f, modifierBait);
            modifierBaitShowKillFlash = CustomOption.Create(Types.Modifier, "�����⾯������", true, modifierBait);
           
            modifierLover = CustomOption.Create(Types.Modifier, cs(Lovers.color, "����"), rates, null, true);
            modifierLoverImpLoverRate = CustomOption.Create(Types.Modifier, "һ���ڹ����˵Ļ���", rates, modifierLover);
            modifierLoverBothDie = CustomOption.Create(Types.Modifier, "����ͬ������", true, modifierLover);
            modifierLoverEnableChat = CustomOption.Create(Types.Modifier, "��������˽������", true, modifierLover);
            
            modifierSunglasses = CustomOption.Create(Types.Modifier, cs(Sunglasses.color, "̫����"), rates, null, true);
            modifierSunglassesQuantity = CustomOption.Create(Types.Modifier, "̫��������", ratesModifier, modifierSunglasses);
            modifierSunglassesVision = CustomOption.Create(Types.Modifier, "̫������Ұ", new string[] { "-10%", "-20%", "-30%", "-40%", "-50%" }, modifierSunglasses);
           
            modifierMini = CustomOption.Create(Types.Modifier, cs(Mini.color, "���㴬Ա"), rates, null, true);
            modifierMiniGrowingUpDuration = CustomOption.Create(Types.Modifier, "���㴬Ա�ɳ�ʱ��", 400f, 100f, 1500f, 100f, modifierMini);
            modifierMiniGrowingUpInMeeting = CustomOption.Create(Types.Modifier, "���㴬Ա�ڻ����гɳ�", true, modifierMini);
            if (Utilities.EventUtility.canBeEnabled || Utilities.EventUtility.isEnabled)
            {
                eventKicksPerRound = CustomOption.Create(Types.Modifier, cs(Color.green, "���㴬Ա���ɳ����߳�����"), 4f, 0f, 14f, 1f, modifierMini);
                eventHeavyAge = CustomOption.Create(Types.Modifier, cs(Color.green, "���㴬Ա��������"), 12f, 6f, 18f, 0.5f, modifierMini);
                eventReallyNoMini = CustomOption.Create(Types.Modifier, cs(Color.green, "����������㴬Ա:("), false, modifierMini, invertedParent: true);
            }
            modifierVip = CustomOption.Create(Types.Modifier, cs(Vip.color, "VIP"), rates, null, true);
            modifierVipQuantity = CustomOption.Create(Types.Modifier, "VIP����", ratesModifier, modifierVip);
            modifierVipShowColor = CustomOption.Create(Types.Modifier, "��ʾ�Ŷ���ɫ", true, modifierVip);
           
            modifierInvert = CustomOption.Create(Types.Modifier, cs(Invert.color, "�ƹ�"), rates, null, true);
            modifierInvertQuantity = CustomOption.Create(Types.Modifier, "�ƹ�����", ratesModifier, modifierInvert);
            modifierInvertDuration = CustomOption.Create(Types.Modifier, "�ߵ��Ļ������", 3f, 1f, 15f, 1f, modifierInvert);
           
            modifierChameleon = CustomOption.Create(Types.Modifier, cs(Chameleon.color, "��ɫ��"), rates, null, true);
            modifierChameleonQuantity = CustomOption.Create(Types.Modifier, "��ɫ������", ratesModifier, modifierChameleon);
            modifierChameleonHoldDuration = CustomOption.Create(Types.Modifier, "��ɫ��ʼʱ��", 3f, 1f, 10f, 0.5f, modifierChameleon);
            modifierChameleonFadeDuration = CustomOption.Create(Types.Modifier, "͸������ʱ��", 1f, 0.25f, 10f, 0.25f, modifierChameleon);
            modifierChameleonMinVisibility = CustomOption.Create(Types.Modifier, "��Ϳɼ���", new string[] { "0%", "10%", "20%", "30%", "40%", "50%" }, modifierChameleon);
           
            modifierShifter = CustomOption.Create(Types.Modifier, cs(Shifter.color, "����ʦ"), rates, null, true);
            modifierShifterShiftsMedicShield = CustomOption.Create(Types.Modifier, "���Խ���ҽ���Ļ���", false, modifierShifter);
           
            modifierArmored = CustomOption.Create(Types.Modifier, cs(Armored.color, "װ�ױ�"), rates, null, true);
           
            modifierDisperser = CustomOption.Create(Types.Modifier, cs(Color.red, "��ɢ��"), rates, null, true);
            modifierDisperserCooldown = CustomOption.Create(Types.Modifier, cs(Color.red, "��ɢ������ȴʱ��"), 30f, 10f, 60f, 2.5f, modifierDisperser);
            modifierDisperserNumberOfUses = CustomOption.Create(Types.Modifier, cs(Color.red, "��ɢ���ܴ���"), 1, 1, 10, 1, modifierDisperser);
            
            // Guesser Gamemode (2000 - 2999)
            guesserGamemodeCrewNumber = CustomOption.Create(Types.Guesser, cs(Guesser.color, "��Ա�ǵĶ�ɱ����"), 15f, 0f, 15f, 1f, null, true, heading: "��ɱ����");
            guesserGamemodeNeutralNumber = CustomOption.Create(Types.Guesser, cs(Guesser.color, "�����ǵĶ�ɱ����"), 15f, 0f, 15f, 1f, null);
            guesserGamemodeImpNumber = CustomOption.Create(Types.Guesser, cs(Guesser.color, "�ڹ��ǵĶ�ɱ����"), 15f, 0f, 15f, 1f, null);
            guesserForceJackalGuesser = CustomOption.Create(Types.Guesser, "ǿ�Ʋ���Ϊ�Ĺ�", false, null, true, heading: "ǿ�ƶĹ�");
            guesserGamemodeSidekickIsAlwaysGuesser = CustomOption.Create(Types.Guesser, "���ø���Ϊ�Ĺ�", false, null);
            guesserForceThiefGuesser = CustomOption.Create(Types.Guesser, "ǿ�ƽ���ʦΪ�Ĺ�", false, null);
            guesserGamemodeHaveModifier = CustomOption.Create(Types.Guesser, "�Ĺֿ����и���ְҵ", true, null, true, heading: "��ͨ�Ĺ�����");
            guesserGamemodeNumberOfShots = CustomOption.Create(Types.Guesser, "�ĹֵĶ�ɱ����", 3f, 1f, 15f, 1f, null);
            guesserGamemodeHasMultipleShotsPerMeeting = CustomOption.Create(Types.Guesser, "�Ĺֿ����ڻ����ڼ��ζ�ɱ", false, null);
            guesserGamemodeCrewGuesserNumberOfTasks = CustomOption.Create(Types.Guesser, "���ڴ�Ա�Ĺ�\n���ö�ɱ����������������", 0f, 0f, 15f, 1f, null);
            guesserGamemodeKillsThroughShield = CustomOption.Create(Types.Guesser, "��ɱ��������ҽ���Ļ���", true, null);
            guesserGamemodeEvilCanKillSpy = CustomOption.Create(Types.Guesser, "а��Ĺֿ��Զ�ɱ�Ե�", true, null);
            guesserGamemodeCantGuessSnitchIfTaksDone = CustomOption.Create(Types.Guesser, "�Ĺֲ��ܶ�ɱ��������˵ĸ�����", true, null);
           
            // Hide N Seek Gamemode (3000 - 3999)
            hideNSeekMap = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "��ͼ"), new string[] { "���ý�", "����HQ", "��³˹", "�߿շ�ͧ", "�������", "�Ǳͧ" }, null, true, onChange: () => { int map = hideNSeekMap.selection; if (map >= 3) map++; GameOptionsManager.Instance.currentNormalGameOptions.MapId = (byte)map; }, heading: "׽�Բص�ͼ����");
            hideNSeekHunterCount = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "��������"), 1f, 1f, 3f, 1f, null, true, heading: "׽�Բ���ͨ����");
            hideNSeekKillCooldown = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "��ɱ��ȴ"), 10f, 2.5f, 60f, 2.5f);
            hideNSeekHunterVision = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "������Ұ"), 0.5f, 0.25f, 2f, 0.25f);
            hideNSeekHuntedVision = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "�������Ұ"), 2f, 0.25f, 5f, 0.25f);
            hideNSeekCommonTasks = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "��ͨ������"), 1f, 0f, 4f, 1f);
            hideNSeekShortTasks = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "��������"), 3f, 1f, 23f, 1f);
            hideNSeekLongTasks = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "��������"), 3f, 0f, 15f, 1f);
            hideNSeekTimer = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "��ʱ����Сֵ"), 5f, 1f, 30f, 0.5f);
            hideNSeekTaskWin = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "���������ʤ"), false);
            hideNSeekTaskPunish = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "���������ٵ�����"), 10f, 0f, 30f, 1f);
            hideNSeekCanSabotage = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "�����ƻ�"), false);
            hideNSeekHunterWaiting = CustomOption.Create(Types.HideNSeekMain, cs(Color.yellow, "������Ҫ�ȴ���ʱ��"), 15f, 2.5f, 60f, 2.5f);
           
            hunterLightCooldown = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "���˵����ȴʱ��"), 30f, 5f, 60f, 1f, null, true, heading: "���˵������");
            hunterLightDuration = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "���˵�Ƴ���ʱ��"), 5f, 1f, 60f, 1f);
            hunterLightVision = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "���˵����Ұ"), 3f, 1f, 5f, 0.25f);
            hunterLightPunish = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "���˵�Ƴͷ�����"), 5f, 0f, 30f, 1f);
            hunterAdminCooldown = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "���˵�ͼ��ȴʱ��"), 30f, 5f, 60f, 1f);
            hunterAdminDuration = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "���˵�ͼʹ��ʱ��"), 5f, 1f, 60f, 1f);
            hunterAdminPunish = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "���˵�ͼ���ٵ�����"), 5f, 0f, 30f, 1f);
            hunterArrowCooldown = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "����Ѱ����ȴʱ��"), 30f, 5f, 60f, 1f);
            hunterArrowDuration = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "����Ѱ�ҳ���ʱ��"), 5f, 0f, 60f, 1f);
            hunterArrowPunish = CustomOption.Create(Types.HideNSeekRoles, cs(Color.red, "��Ѱ���ٳͷ�����"), 5f, 0f, 30f, 1f);
            
            huntedShieldCooldown = CustomOption.Create(Types.HideNSeekRoles, cs(Color.gray, "����߻�����ȴʱ��"), 30f, 5f, 60f, 1f, null, true, heading: "����߻�������");
            huntedShieldDuration = CustomOption.Create(Types.HideNSeekRoles, cs(Color.gray, "����߻��ܳ���ʱ��"), 5f, 1f, 60f, 1f);
            huntedShieldRewindTime = CustomOption.Create(Types.HideNSeekRoles, cs(Color.gray, "����߻���ʱ��"), 3f, 1f, 10f, 1f);
            huntedShieldNumber = CustomOption.Create(Types.HideNSeekRoles, cs(Color.gray, "����߻�������"), 3f, 1f, 15f, 1f);
           
            // Prop Hunt General Options
            propHuntMap = CustomOption.Create(Types.PropHunt, cs(Color.yellow, "��ͼ"), new string[] { "���ý�", "�����ܲ�", "��³˹", "��ͧ��ͼ", "�������", "Ǳͧ��ͼ", "�Զ����ͼ" }, null, true, onChange: () => { int map = propHuntMap.selection; if (map >= 3) map++; GameOptionsManager.Instance.currentNormalGameOptions.MapId = (byte)map; }, heading: "���ζ�èè��ͼ����");
            propHuntTimer = CustomOption.Create(Types.PropHunt, cs(Color.yellow, "��ʱ����Сֵ"), 5f, 1f, 30f, 0.5f, null, true, heading: "���ζ�èè��ͨ����");
            propHuntUnstuckCooldown = CustomOption.Create(Types.PropHunt, cs(Color.yellow, "��ǽ��ȴʱ��"), 30f, 2.5f, 60f, 2.5f);
            propHuntUnstuckDuration = CustomOption.Create(Types.PropHunt, cs(Color.yellow, "��ǽ����ʱ��"), 2f, 1f, 60f, 1f);
            propHunterVision = CustomOption.Create(Types.PropHunt, cs(Color.yellow, "������Ұ"), 0.5f, 0.25f, 2f, 0.25f);
            propVision = CustomOption.Create(Types.PropHunt, cs(Color.yellow, "������Ұ"), 2f, 0.25f, 5f, 0.25f);
           
            // Hunter Options
            propHuntNumberOfHunters = CustomOption.Create(Types.PropHunt, cs(Color.red, "��������"), 1f, 1f, 5f, 1f, null, true, heading: "��������");
            hunterInitialBlackoutTime = CustomOption.Create(Types.PropHunt, cs(Color.red, "���˳�ʼ�ȴ�ʱ��"), 10f, 5f, 20f, 1f);
            hunterMissCooldown = CustomOption.Create(Types.PropHunt, cs(Color.red, "�����ɱ�����ȴʱ��"), 10f, 2.5f, 60f, 2.5f);
            hunterHitCooldown = CustomOption.Create(Types.PropHunt, cs(Color.red, "��ɱ�����ȴʱ��"), 10f, 2.5f, 60f, 2.5f);
            propHuntRevealCooldown = CustomOption.Create(Types.PropHunt, cs(Color.red, "������ȴʱ��"), 30f, 10f, 90f, 2.5f);
            propHuntRevealDuration = CustomOption.Create(Types.PropHunt, cs(Color.red, "���γ���ʱ��"), 5f, 1f, 60f, 1f);
            propHuntRevealPunish = CustomOption.Create(Types.PropHunt, cs(Color.red, "��ʾ�ͷ�ʱ��"), 10f, 0f, 1800f, 5f);
            propHuntAdminCooldown = CustomOption.Create(Types.PropHunt, cs(Color.red, "���˹����ͼ��ȴʱ��"), 30f, 2.5f, 1800f, 2.5f);
            propHuntFindCooldown = CustomOption.Create(Types.PropHunt, cs(Color.red, "Ѱ����ȴʱ��"), 60f, 2.5f, 1800f, 2.5f);
            propHuntFindDuration = CustomOption.Create(Types.PropHunt, cs(Color.red, "Ѱ�ҳ���ʱ��"), 5f, 1f, 15f, 1f);
           
            // Prop Options
            propBecomesHunterWhenFound = CustomOption.Create(Types.PropHunt, cs(Palette.CrewmateBlue, "�����߱���ɱ��������"), false, null, true, heading: "���������");
            propHuntInvisEnabled = CustomOption.Create(Types.PropHunt, cs(Palette.CrewmateBlue, "����������"), true, null, true);
            propHuntInvisCooldown = CustomOption.Create(Types.PropHunt, cs(Palette.CrewmateBlue, "������ȴʱ��"), 120f, 10f, 1800f, 2.5f, propHuntInvisEnabled);
            propHuntInvisDuration = CustomOption.Create(Types.PropHunt, cs(Palette.CrewmateBlue, "�������ʱ��"), 5f, 1f, 30f, 1f, propHuntInvisEnabled);
            propHuntSpeedboostEnabled = CustomOption.Create(Types.PropHunt, cs(Palette.CrewmateBlue, "���ü��ټ���"), true, null, true);
            propHuntSpeedboostCooldown = CustomOption.Create(Types.PropHunt, cs(Palette.CrewmateBlue, "������ȴʱ��"), 60f, 2.5f, 1800f, 2.5f, propHuntSpeedboostEnabled);
            propHuntSpeedboostDuration = CustomOption.Create(Types.PropHunt, cs(Palette.CrewmateBlue, "���ٳ���ʱ��"), 5f, 1f, 15f, 1f, propHuntSpeedboostEnabled);
            propHuntSpeedboostSpeed = CustomOption.Create(Types.PropHunt, cs(Palette.CrewmateBlue, "���������ٶ�"), 2f, 1.25f, 5f, 0.25f, propHuntSpeedboostEnabled);
            
            // Other options
            CanUseSwitchShipCostumeButton = CustomOption.Create(Types.General, "�л���ͼƤ��(��֧�����ý�)", false, null, true, heading: "�л���ͼƤ��");
            debugMode = CustomOption.Create(Types.General, "����ģʽ", false, null, true, heading: "����ģʽ");
            disableGameEnd = CustomOption.Create(Types.General, "��Ϸ������", false, debugMode);
            maxNumberOfMeetings = CustomOption.Create(Types.General, "�����ܴ��� (�������г�)", 10, 0, 15, 1, null, true, heading: "��Ϸ�趨");
            anyPlayerCanStopStart = CustomOption.Create(Types.General, "������Ҷ�������ͣ��ʼ��Ϸ", false, null, false);
            blockSkippingInEmergencyMeetings = CustomOption.Create(Types.General, "���û�������Ʊ", false);
            noVoteIsSelfVote = CustomOption.Create(Types.General, "��ͶƱ����Ͷ�Լ�", false, blockSkippingInEmergencyMeetings);
            hidePlayerNames = CustomOption.Create(Types.General, "�����������", false);
            allowParallelMedBayScans = CustomOption.Create(Types.General, "����ͬʱ����ɨ��", false);
            shieldFirstKill = CustomOption.Create(Types.General, "��һ�ֱ����׵����", false);
            finishTasksBeforeHauntingOrZoomingOut = CustomOption.Create(Types.General, "��δ�����������ǰ������ʹ�ù�Ӱ���Ƽ�ǧ����", true);
            deadImpsBlockSabotage = CustomOption.Create(Types.General, "��ȥ���ڹ��Ƿ���Խ����ƻ��", false, null, false);
            camsNightVision = CustomOption.Create(Types.General, "�ڵƹⱻ�ر�ʱ���ʹ�ú�ҹģʽ", false, null, true, heading: "ҹ��ģʽ");
            camsNoNightVisionIfImpVision = CustomOption.Create(Types.General, "ӵ���ڹ���Ұ��������Ӻ�ҹģʽ", false, camsNightVision, false);
           
            dynamicMap = CustomOption.Create(Types.General, "�����һ����ͼ����", false, null, true, heading: "�����ͼ");
            dynamicMapEnableSkeld = CustomOption.Create(Types.General, "���ý�", rates, dynamicMap, false);
            dynamicMapEnableMira = CustomOption.Create(Types.General, "����HQ", rates, dynamicMap, false);
            dynamicMapEnablePolus = CustomOption.Create(Types.General, "��³˹", rates, dynamicMap, false);
            dynamicMapEnableAirShip = CustomOption.Create(Types.General, "�߿շ�ͧ", rates, dynamicMap, false);
            dynamicMapEnableFungle = CustomOption.Create(Types.General, "�������", rates, dynamicMap, false);
            dynamicMapEnableSubmerged = CustomOption.Create(Types.General, "�Ǳͧ", rates, dynamicMap, false);
            dynamicMapSeparateSettings = CustomOption.Create(Types.General, "���õ�ͼ��Ԥ��", false, dynamicMap, false);

            blockedRolePairings.Add((byte)RoleId.Vampire, new [] { (byte)RoleId.Warlock});
            blockedRolePairings.Add((byte)RoleId.Warlock, new [] { (byte)RoleId.Vampire});
            blockedRolePairings.Add((byte)RoleId.Spy, new [] { (byte)RoleId.Mini});
            blockedRolePairings.Add((byte)RoleId.Mini, new [] { (byte)RoleId.Spy});
            blockedRolePairings.Add((byte)RoleId.Vulture, new [] { (byte)RoleId.Cleaner});
            blockedRolePairings.Add((byte)RoleId.Cleaner, new [] { (byte)RoleId.Vulture});
            
        }
    }
}
