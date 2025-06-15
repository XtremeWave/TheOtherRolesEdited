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

        public static RoleInfo jester = new RoleInfo("小丑", Jester.color, "让他们把你投出去！", "让他们把你投出去！", RoleId.Jester, true);
        public static RoleInfo mayor = new RoleInfo("市长", Mayor.color, "你的票比别人更有分量", "你在会议上拥有绝对的优势", RoleId.Mayor);
        public static RoleInfo portalmaker = new RoleInfo("传送师", Portalmaker.color, "欸嘿我过来了~欸嘿我又过去了~~", "你可以创建传送门", RoleId.Portalmaker);
        public static RoleInfo engineer = new RoleInfo("工程师", Engineer.color, "飞船没了你都运行不了", "修理飞船是强项", RoleId.Engineer);
        public static RoleInfo sheriff = new RoleInfo("警长", Sheriff.color, "声张正义,维护飞船！", "毙了<color=#FF1919FF>内鬼</color>", RoleId.Sheriff);
        public static RoleInfo deputy = new RoleInfo("捕快", Sheriff.color, "给<color=#FF1919FF>内鬼</color>戴上手铐", "铐住内鬼", RoleId.Deputy);
        public static RoleInfo lighter = new RoleInfo("执灯人", Lighter.color, "你的光芒永不熄灭", "你的光芒永不熄灭", RoleId.Lighter);
        public static RoleInfo godfather = new RoleInfo("教父", Godfather.color, "杀了所有船员", "杀了所有船员", RoleId.Godfather);
        public static RoleInfo mafioso = new RoleInfo("小弟", Mafioso.color, "帮助<color=#FF1919FF>教父</color>做掉所有船员", "做掉所有船员", RoleId.Mafioso);
        public static RoleInfo janitor = new RoleInfo("清洁工", Janitor.color, "帮助<color=#FF1919FF>教父</color>隐藏作案痕迹", "隐藏鸡腿", RoleId.Janitor);
        public static RoleInfo morphling = new RoleInfo("化形者", Morphling.color, "猜猜我是谁？", "隐藏至人群之中", RoleId.Morphling);
        public static RoleInfo camouflager = new RoleInfo("隐蔽者", Camouflager.color, "利用幻术隐匿在船员之中", "隐匿在他们之中", RoleId.Camouflager);
        public static RoleInfo vampire = new RoleInfo("吸血鬼", Vampire.color, "今天的血液是我最喜欢的！", "咬死船员", RoleId.Vampire);
        public static RoleInfo eraser = new RoleInfo("抹除者", Eraser.color, "让他们不知所措吧！", "擦除他们的职业", RoleId.Eraser);
        public static RoleInfo trickster = new RoleInfo("骗术师", Trickster.color, "使用惊吓盒子搭建的管道网络", "开盲盒咯~", RoleId.Trickster);
        public static RoleInfo cleaner = new RoleInfo("清理者", Cleaner.color, "杀人于无形之中", "清理你的作案痕迹", RoleId.Cleaner);
        public static RoleInfo blackmailer = new RoleInfo("勒索者", Blackmailer.color, "嘘~~~~~~~~~~~", "不许说话哦~", RoleId.Blackmailer);
        public static RoleInfo miner = new RoleInfo("矿工", Miner.color, "建立新的管道网络", "建立新的管道", RoleId.Miner);
        public static RoleInfo warlock = new RoleInfo("术士", Warlock.color, "画个圈圈诅咒你", "利用诅咒杀掉船员", RoleId.Warlock);
        public static RoleInfo bountyHunter = new RoleInfo("赏金猎人", BountyHunter.color, "赏金我让欲罢不能", "无休止的获得赏金吧", RoleId.BountyHunter);
        public static RoleInfo detective = new RoleInfo("侦探", Detective.color, "寻找<color=#FF1919FF>内鬼</color>留下的作案痕迹吧", "在脚印中寻找线索", RoleId.Detective);
        public static RoleInfo timeMaster = new RoleInfo("时间之主", TimeMaster.color, "时间~~~倒流！！！", "用时间之盾保护自己", RoleId.TimeMaster);
        public static RoleInfo medic = new RoleInfo("医生", Medic.color, "保护船员", "保护你应该保护的人", RoleId.Medic);
        public static RoleInfo swapper = new RoleInfo("换票师", Swapper.color, "禁止小脑行为投出<color=#FF1919FF>小丑</color>！！", "扭转乾坤", RoleId.Swapper);
        public static RoleInfo seer = new RoleInfo("灵媒", Seer.color, "你可以预见玩家的死亡", "你可以预见玩家的死亡", RoleId.Seer);
        public static RoleInfo hacker = new RoleInfo("黑客", Hacker.color, "黑入设备，找出<color=#FF1919FF>内鬼</color>", "找出内鬼", RoleId.Hacker);
        public static RoleInfo tracker = new RoleInfo("追踪者", Tracker.color, "利用GPS找出我们之中的<color=#FF1919FF>内鬼</color>", "跟踪内鬼的脚步", RoleId.Tracker);
        public static RoleInfo snitch = new RoleInfo("告密者", Snitch.color, "观察四周,谨防<color=#FF1919FF>内鬼</color>", "完成任务，找出<color=#FF1919FF>内鬼</color>", RoleId.Snitch);
        public static RoleInfo jackal = new RoleInfo("豺狼", Jackal.color, "杀了船员和<color=#FF1919FF>内鬼</color>来获得胜利", "击杀所有人", RoleId.Jackal, true);
        public static RoleInfo sidekick = new RoleInfo("跟班", Sidekick.color, "帮助豺狼获得胜利", "帮助豺狼杀掉所有人", RoleId.Sidekick, true);
        public static RoleInfo spy = new RoleInfo("卧底", Spy.color, "隐藏在<color=#FF1919FF>内鬼</color>之主", "让内鬼们相互猜疑", RoleId.Spy);
        public static RoleInfo securityGuard = new RoleInfo("保安", SecurityGuard.color, "嘿咻咻~不多不少好极了", "放置摄像头和封锁管道", RoleId.SecurityGuard);
        public static RoleInfo arsonist = new RoleInfo("纵火犯", Arsonist.color, "要来一起吃烤肉吗？", "我最喜欢烟花！", RoleId.Arsonist, true);
        public static RoleInfo goodGuesser = new RoleInfo("正义的赌怪", Guesser.color, "生命即是豪赌", "生命即是豪赌", RoleId.NiceGuesser);
        public static RoleInfo badGuesser = new RoleInfo("邪恶的赌怪", Palette.ImpostorRed, "生命即是豪赌", "生命即是豪赌", RoleId.EvilGuesser);
        public static RoleInfo vulture = new RoleInfo("秃鹫", Vulture.color, "好饿啊~飞船上有没有好吃的鸡腿啊~", "吃掉鸡腿", RoleId.Vulture, true);
        public static RoleInfo medium = new RoleInfo("通灵师", Medium.color, "询问幽灵获得线索", "询问幽灵", RoleId.Medium);
        public static RoleInfo trapper = new RoleInfo("猎人", Trapper.color, "放置陷阱捉住内鬼", "放置陷阱", RoleId.Trapper);
        public static RoleInfo lawyer = new RoleInfo("律师", Lawyer.color, "保护你的客户", "保护你的客户", RoleId.Lawyer, true);
        public static RoleInfo prosecutor = new RoleInfo("检察官", Prosecutor.color, "投出你的客户", "投出你的客户", RoleId.Prosecutor, true);
        public static RoleInfo pursuer = new RoleInfo("起诉人", Pursuer.color, "利用空包弹保护船员", "利用空包弹保护船员", RoleId.Pursuer);
        public static RoleInfo impostor = new RoleInfo("内鬼", Palette.ImpostorRed, Helpers.cs(Palette.ImpostorRed, "击杀所有人"), "击杀所有人", RoleId.Impostor);
        public static RoleInfo crewmate = new RoleInfo("船员", Color.white, "找出内鬼", "找出内鬼", RoleId.Crewmate);
        public static RoleInfo witch = new RoleInfo("女巫", Witch.color, "毒药为你准备好了哦~", "为所有人下咒", RoleId.Witch);
        public static RoleInfo ninja = new RoleInfo("忍者", Ninja.color, "杀人于无形之中", "杀人于无形之中", RoleId.Ninja);
        public static RoleInfo thief = new RoleInfo("强盗", Thief.color, "这些都是我的啦！", "先杀人再盗窃", RoleId.Thief, true);
        public static RoleInfo bomber = new RoleInfo("爆炸狂", Bomber.color, "我可是比纵火犯还喜欢烟花呢~", "炸死所有船员", RoleId.Bomber);
        public static RoleInfo yoyo = new RoleInfo("悠悠球", Yoyo.color, "欻~~~~~~~~~~~", "瞬移到你所标记的位置", RoleId.Yoyo);
        public static RoleInfo hunter = new RoleInfo("猎人", Palette.ImpostorRed, Helpers.cs(Palette.ImpostorRed, "找到并击杀所有人"), "找到并击杀所有人", RoleId.Impostor);
        public static RoleInfo hunted = new RoleInfo("躲藏者", Color.white, "躲躲藏藏又是一年", "躲藏", RoleId.Crewmate);
        public static RoleInfo prop = new RoleInfo("变形者", Color.white, "伪装成物体并生存", "伪装成物体并生存", RoleId.Crewmate);



        // Modifier
        public static RoleInfo bloody = new RoleInfo("溅血者", Bloody.color, "杀了你的人会留下痕迹", "杀了你的人会留下痕迹", RoleId.Bloody, false, true);
        public static RoleInfo antiTeleport = new RoleInfo("厄运儿",AntiTeleport.color, "你不会被传送", "你不会被传送", RoleId.AntiTeleport, false, true);
        public static RoleInfo tiebreaker = new RoleInfo("破平者", Tiebreaker.color, "你打破了平局", "你有1.5票", RoleId.Tiebreaker, false, true);
        public static RoleInfo bait = new RoleInfo("诱饵", Bait.color, "恭喜你杀了我你就中大奖了", "你敢杀我吗？", RoleId.Bait, false, true);
        public static RoleInfo sunglasses = new RoleInfo("太阳镜", Sunglasses.color, "你戴上了太阳镜", "你的视野变得更加开阔", RoleId.Sunglasses, false, true);
        public static RoleInfo lover = new RoleInfo("恋人", Lovers.color, $"你坠入了爱河", $"你坠入了爱河", RoleId.Lover, false, true);
        public static RoleInfo mini = new RoleInfo("迷你船员", Mini.color, "在你长大之前没人能伤害你", "在你长大之前没人能伤害你", RoleId.Mini, false, true);
        public static RoleInfo vip = new RoleInfo("VIP", Vip.color, "你是一个VIP", "所有人都会知道你被杀害了", RoleId.Vip, false, true);
        public static RoleInfo invert = new RoleInfo("醉鬼", Invert.color, "向上欸~其实是向下，向左欸~其实是向右", "你的行动被颠倒了", RoleId.Invert, false, true);
        public static RoleInfo chameleon = new RoleInfo("变色龙", Chameleon.color, "你不动的时候很难被看到", "你不动的时候很难被看到", RoleId.Chameleon, false, true);
        public static RoleInfo shifter = new RoleInfo("窃贼", Shifter.color, "我要偷走你的职业", "你的职业归我了", RoleId.Shifter, false, true);
        public static RoleInfo armored = new RoleInfo("装甲兵", Armored.color, "您受到保护,免于一次谋杀未遂", "您受到保护,免于一次谋杀未遂", RoleId.Armored, false, true);
        public static RoleInfo disperser = new RoleInfo("分散者", Color.red, "分散所有船员", "分散所有船员", RoleId.Disperser, false, true);


        public static List<RoleInfo> allRoleInfos = new List<RoleInfo>() {
            impostor,
            godfather,
            mafioso,
            janitor,
            morphling,
            camouflager,
            vampire,
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
            if (p == Yoyo.yoyo) infos.Add(yoyo);
            if (p == Miner.miner) infos.Add(miner);
            if (p == Blackmailer.blackmailer) infos.Add(blackmailer);
            if (p == Detective.detective) infos.Add(detective);
            if (p == TimeMaster.timeMaster) infos.Add(timeMaster);
            if (p == Medic.medic) infos.Add(medic);
            if (p == Swapper.swapper) infos.Add(swapper);
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
                        roleName = Helpers.cs(Ninja.color, "(被选定为目标) ") + roleName;
                    if (Pursuer.blankedList.Contains(p) && !p.Data.IsDead)
                        roleName = Helpers.cs(Pursuer.color, "(被塞入空包弹) ") + roleName;
                    if (Witch.futureSpelled.Contains(p) && !MeetingHud.Instance) // This is already displayed in meetings!
                        roleName = Helpers.cs(Witch.color, "☆ ") + roleName;
                    if (BountyHunter.bounty == p)
                        roleName = Helpers.cs(BountyHunter.color, "(赏金目标) ") + roleName;
                    if (Arsonist.dousedPlayers.Contains(p))
                        roleName = Helpers.cs(Arsonist.color, "♨ ") + roleName;
                    if (p == Arsonist.arsonist)
                        roleName = roleName + Helpers.cs(Arsonist.color, $" ({CachedPlayer.AllPlayers.Count(x => { return x.PlayerControl != Arsonist.arsonist && !x.Data.IsDead && !x.Data.Disconnected && !Arsonist.dousedPlayers.Any(y => y.PlayerId == x.PlayerId); })} left)");
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
        public static async Task loadReadme() {
            if (ReadmePage == "") {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/TheOtherRolesAU/TheOtherRoles/main/README.md");
                response.EnsureSuccessStatusCode();
                string httpres = await response.Content.ReadAsStringAsync();
                ReadmePage = httpres;
            }
        }
        public static string GetRoleDescription(RoleInfo roleInfo) {
            while (ReadmePage == "") {
            }
                
            int index = ReadmePage.IndexOf($"## {roleInfo.name}");
            int endindex = ReadmePage.Substring(index).IndexOf("### Game Options");
            return ReadmePage.Substring(index, endindex);

        }
    }
}
