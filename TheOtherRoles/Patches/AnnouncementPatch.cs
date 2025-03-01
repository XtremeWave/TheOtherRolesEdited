using System;
using System.Collections.Generic;
using System.Linq;
using AmongUs.Data;
using AmongUs.Data.Player;
using Assets.InnerNet;
using HarmonyLib;

namespace TheOtherRolesEdited;

// ##https://github.com/Yumenopai/TownOfHost_Y
public class ModNews
{
    public int Number;
    public int BeforeNumber;
    public string Title;
    public string SubTitle;
    public string ShortTitle;
    public string Text;
    public string Date;

    public Announcement ToAnnouncement()
    {
        var result = new Announcement
        {
            Number = Number,
            Title = Title,
            SubTitle = SubTitle,
            ShortTitle = ShortTitle,
            Text = Text,
            Language = (uint)DataManager.Settings.Language.CurrentLanguage,
            Date = Date,
            Id = "ModNews"
        };

        return result;
    }
}
[HarmonyPatch]
public class ModNewsHistory
{
    public static List<ModNews> AllModNews = new();
    public static void Init()
    {
        // 创建新公告时，不能删除旧公告   
        {
            {
                // TORE v1.2.2
                var news = new ModNews
                {
                    Number = 100003,
                    Title = $"TheOtherRolesEdited  v1.2.2",
                    SubTitle = "求善待！(真是没想到我做到了周更:)",
                    ShortTitle = $"★TORE",
                    Text = "<size=100%>欢迎来到 TORE v1.2.2.适配Among us v2024.11.26s</size>\n"
                        + "\n<b>声明</b>\n·本模组不隶属于 Among Us 或 Innersloth LLC 其中包含的内容未得到 Innersloth LLC 的认可或以其他方式赞助 此处包含的部分材料是 Innersloth LLC的财产 ©Innersloth"
                        + "\n<b>对应官方版本</b>\n · TOR v.4.8.0\r"
                        + "\n<b>澄清</b>\n · 上个版本说的话当我没说(主要是没想到TOR会更新480)"
                        + "\n<b>修改</b>\n · 修复了变形躲猫猫中玩家无法转化为道具的错误"
                        + "\n<b>新增</b>\n · 轮抽选角(by:TOR)\n ·更改的Ping延迟文字在会议中的位置"
                        + "\n<b>温馨提示</b>\n · 在轮抽选职模式中如果想听音乐应调节AU原版的音量大小:>"
                        + "\n<b>huh</b>\n · Have a great time！",
                    Date = "2025-3-1T00:00:00Z"
                };
                AllModNews.Add(news);
            }
            {
                // TORE v1.2.1
                var news = new ModNews
                {
                    Number = 100002,
                    Title = $"TheOtherRolesEdited  v1.2.1",
                    SubTitle = "开学后的第一更！",
                    ShortTitle = $"★TORE",
                    Text = "<size=100%>欢迎来到 TORE v1.2.1.适配Among us v2024.11.26s</size>\n"
                        + "\n<b>声明</b>\n·本模组不隶属于 Among Us 或 Innersloth LLC 其中包含的内容未得到 Innersloth LLC 的认可或以其他方式赞助 此处包含的部分材料是 Innersloth LLC的财产 ©Innersloth"
                        + "\n<b>对应官方版本</b>\n · TOR v.4.7.0\r"
                        + "\n<b>画饼</b>\n · 下个版本一定出新职业(确信)doge"
                        + "\n<b>修改</b>\n · 超多帽子由方块服务器提供(不用加速器也能用了捏)\n · 聊天框改为蓝色\n · 更改游戏水印的排版\n · 修改汉化错误"
                        + "\n<b>新增</b>\n · 添加点击主页按钮动画 \n · 添加一键更新背景与提示 \n · 增加更换地图样式按钮(保安室)\n · 增加主页星点装饰\n · 增加大厅开始游戏倒计时\n · 增加右下角水印 \n · 增加FPS\n · 增加服务器(方块服 & Niko服)\n · 增加大厅服务器辨识\n · 增加XW标识\n · 增加模组光标\n · 增加光标开关键",
                    Date = "2025-2-23T00:00:00Z"
                };
                AllModNews.Add(news);
            }
        }
        {
            // TORE v1.2.0
            var news = new ModNews
            {
                Number = 100001,
                Title = $"TheOtherRolesEdited  v1.2.0",
                SubTitle = "更新了",
                ShortTitle = $"★TORE",
                Text = "<size=100%>欢迎来到 TORE v1.2.0.适配Among us v2024.11.26s</size>\n"
                    + "\n<b>声明</b>\n·本模组不隶属于 Among Us 或 Innersloth LLC 其中包含的内容未得到 Innersloth LLC 的认可或以其他方式赞助 此处包含的部分材料是 Innersloth LLC的财产 ©Innersloth"
                    + "\n<b>对应官方版本</b>\n · TOR v.4.7.0\r"
                    + "\n<b>新职业</b>\n · 装甲兵\n -你可以抵御一次击杀\r"
                    + "\n<b>修复</b>\n · 无"
                    + "\n<b>更新</b>\n · 无法在TORE中使用官方服务器(By TOR)"
                    + "\n<b>UI更新</b>\n · 无",
                Date = "2025-1-23T00:00:00Z"
            };
            AllModNews.Add(news);
        }
        { 
            // TORE v1.1.5
            var news = new ModNews
            {
                Number = 100000,
                Title = $"TheOtherRolesEdited  v1.1.5",
                SubTitle = "关于更新",
                ShortTitle = $"★TORE",
                Text = "<size=100%>欢迎来到 TORE v1.1.5.适配Among us v2024.9.4s</size>\n"
                    + "\n<b>声明</b>\n·本模组不隶属于 Among Us 或 Innersloth LLC 其中包含的内容未得到 Innersloth LLC 的认可或以其他方式赞助 此处包含的部分材料是 Innersloth LLC的财产 ©Innersloth"
                    + "\n<b>对应官方版本</b>\n · TOR v.4.6.0\r"
                    + "\n<b>新职业</b>\n · 内鬼职业：矿工(By farewell)\r \n -铸造自己的管道网络\r \n · 内鬼职业：勒索者(By farewell)\r \n -让他们闭嘴吧!\r \n · 内鬼职业：Yo-yo(By TOR) \r \n -在地图内随意穿梭！\r \n · 附加职业: -分散者(潜艇地图暂无法使用)\r \n -分散船员们！\r"
                    + "\n<b>修复</b>\n · 修复yoyo职业BUG(By farewell)\n · 修复适配所存在的问题(By fangkuai)\n · 修复职业分配"
                    + "\n<b>更新</b>\n · 无法在TORE中使用官方服务器(By TOR)\n · 无法在TORE中发送违禁词(By farewell & Yu)\n · 游戏大厅内加入XtremeWave的标识(By farewell)"
                    + "\n<b>UI更新</b>\n · 对应树懒更新的设置界面进行更改(By TOR)\n · 删除原左界面的职业展示，统一放进右边查看按钮（By TOR）\n · 适配原复制粘贴按钮(By TOR)\n · 适配原游戏内查看职业按钮(By TOR)\n · 主界面UI大更新(By farewell)",
                Date = "2024-10-20T00:00:00Z"
            };
            AllModNews.Add(news);
        }
    }

[HarmonyPatch(typeof(PlayerAnnouncementData), nameof(PlayerAnnouncementData.SetAnnouncements)), HarmonyPrefix]
    public static bool SetModAnnouncements(PlayerAnnouncementData __instance, [HarmonyArgument(0)] ref Il2CppReferenceArray<Announcement> aRange)
    {
        if (AllModNews.Count < 1)
        {
            Init();
            AllModNews.Sort((a1, a2) => { return DateTime.Compare(DateTime.Parse(a2.Date), DateTime.Parse(a1.Date)); });
        }

        List<Announcement> FinalAllNews = new();
        AllModNews.Do(n => FinalAllNews.Add(n.ToAnnouncement()));
        foreach (var news in aRange)
        {
            if (!AllModNews.Any(x => x.Number == news.Number))
                FinalAllNews.Add(news);
        }
        FinalAllNews.Sort((a1, a2) => { return DateTime.Compare(DateTime.Parse(a2.Date), DateTime.Parse(a1.Date)); });

        aRange = new(FinalAllNews.Count);
        for (int i = 0; i < FinalAllNews.Count; i++)
            aRange[i] = FinalAllNews[i];

        return true;
    }
}
