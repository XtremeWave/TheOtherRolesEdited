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
                // TORE v1.3.1
                var news = new ModNews
                {
                    Number = 100013,
                    Title = $"TheOtherRolesEdited  v1.3.1",
                    SubTitle = "超多更新！<s>(我会增加新职业的!)</s>",
                    ShortTitle = $"★TORE",
                    Text = "<size=100%>欢迎来到 TORE v1.3.1.适配Among us v2025.9.9s/v17.0.0</size>\n"
                        + "\n<b>声明</b>\n· 本模组不隶属于 Among Us 或 Innersloth LLC 其中包含的内容未得到 Innersloth LLC 的认可或以其他方式赞助 此处包含的部分材料是 Innersloth LLC的财产 ©Innersloth"
                        + "\n<b>对应官方版本</b>\n · TOR v.4.8.0\r"
                        + "\n<b>更新内容</b>\n · 再度适配Starlight(包含UI)\n · 优化升级违禁词检测\n · 提升下载帽子的速度(by fangkuai)\n · 更改大厅名称颜色\n · 更改游戏开始时的加载UI\n · 更改替换部分图片\n · 新增搜索游戏时地图的检测(CopyFrom YuET)\n · 新增进入游戏快捷键\n · 新增公告界面\n · 新增公告\n · 新增隐藏AspectSize的动画\n · 新增关闭开启Aspect的按钮\n · 新增更新公告UI\n · 新增TORE贡献者UI\n · 新增Loading界面的多语言\n · 修复安卓端UI错位\n · 修复PC端和安卓端不兼容的问题\n · 修复勒索者没有技能的问题\n · 删除安卓端部分按钮\n · 删除Aige按钮\n · 删除原更新公告UI\n · 删除原TORE贡献者UI\n · 删除TORE头衔\n · 删除TORE部分自定义颜色"
                        + "\n<b>BUG反馈</b>\n · 如有更多问题请邮箱联系！【liu9928161@gmail.com/1500689499@qq.com】感谢您的支持！",
                    Date = "2025-11-16T00:00:00Z"
                };
                AllModNews.Add(news);
            }
            {
                // TORE v1.3.0
                var news = new ModNews
                {
                    Number = 100012,
                    Title = $"TheOtherRolesEdited  v1.3.0",
                    SubTitle = "适配Starlight！！！",
                    ShortTitle = $"★TORE",
                    Text = "<size=100%>欢迎来到 TORE v1.3.0.适配Among us v2025.9.9s/v17.0.0</size>\n"
                        + "\n<b>声明</b>\n· 本模组不隶属于 Among Us 或 Innersloth LLC 其中包含的内容未得到 Innersloth LLC 的认可或以其他方式赞助 此处包含的部分材料是 Innersloth LLC的财产 ©Innersloth"
                        + "\n<b>对应官方版本</b>\n · TOR v.4.8.0\r"
                        + "\n<b>更新内容</b>\n · 适配Starlight\n · 新增Loading界面Logo放大缩小\n · 新增Loading界面背景\n · 新增主页大厅AmongUs Logo和TORE Logo来回切换\n · 新增游戏大厅倒计时(倒计时结束后会自动踢出房间内的所有人)\n · 新增切换设置页面按钮\n · 新增轮抽选角隐藏随机角色的设置\n · 新增Starlight按钮(Android版)\n · 删除右下角按钮\n · 删除版本号检测\n · 为安卓端适配大厅UI\n · 为安卓端添加自定义帽子\n · 为安卓端删除Beplnex更新检测"
                        + "\n<b>目前已知的问题</b>\n · <s>当android端用户进入pc端用户创建的游戏时会检测到版本不同(反之可以)</s>[已解决]\n · 安卓端快捷按钮无法跳转指定页面\n<b>以上问题均会解决如有更多问题请邮箱联系！【liu9928161@gmail.com/1500689499@qq.com】感谢您的支持！</b>",
                    Date = "2025-10-6T00:00:00Z"
                };
                AllModNews.Add(news);
            }
            {
                // TORE v1.2.9
                var news = new ModNews
                {
                    Number = 100011,
                    Title = $"TheOtherRolesEdited  v1.2.9",
                    SubTitle = "派蒙启动！！",
                    ShortTitle = $"★TORE",
                    Text = "<size=100%>欢迎来到 TORE v1.2.9.适配Among us v2025.9.9s/v17.0.0</size>\n"
                        + "\n<b>声明</b>\n·本模组不隶属于 Among Us 或 Innersloth LLC 其中包含的内容未得到 Innersloth LLC 的认可或以其他方式赞助 此处包含的部分材料是 Innersloth LLC的财产 ©Innersloth"
                        + "\n<b>对应官方版本</b>\n · TOR v.4.8.0\r"
                        + "\n<b>更新内容</b>\n · 适配到v17.0.0版本\n · 修复勒索者技能无法使用的问题\n · 新增模组使用次数计数器(fangkuai服务器)\n · 修正设置UI\n · 修复BUG若干\n · 我真的好喜欢这次派蒙的皮肤<s>主要是因为免费</s>",
                    Date = "2025-9-14T00:00:00Z"
                };
                AllModNews.Add(news);
            }
            {
                // TORE v1.2.8
                var news = new ModNews
                {
                    Number = 100010,
                    Title = $"TheOtherRolesEdited  v1.2.8",
                    SubTitle = "开学啦！！",
                    ShortTitle = $"★TORE",
                    Text = "<size=100%>欢迎来到 TORE v1.2.8.适配Among us v2025.4.15s/v16.1.0</size>\n"
                        + "\n<b>声明</b>\n·本模组不隶属于 Among Us 或 Innersloth LLC 其中包含的内容未得到 Innersloth LLC 的认可或以其他方式赞助 此处包含的部分材料是 Innersloth LLC的财产 ©Innersloth"
                        + "\n<b>对应官方版本</b>\n · TOR v.4.8.0\r"
                        + "\n<b>更新内容</b>\n · 新增轮抽选角职业底图\n · 新增轮抽选角随机回合(by:方块)\n · 新增Loading界面\n · 新增游戏设备检测\n · 新增手动更新按钮\n · 修复BUG若干\n · 删除更新背景提示\n · <s>我还更新了版本号</s>",
                    Date = "2025-8-31T00:00:00Z"
                };
                AllModNews.Add(news);
            }
            {
                // TORE v1.2.7
                var news = new ModNews
                {
                    Number = 100009,
                    Title = $"TheOtherRolesEdited  v1.2.7",
                    SubTitle = "时间回溯！！",
                    ShortTitle = $"★TORE",
                    Text = "<size=100%>欢迎来到 TORE v1.2.7.适配Among us v2025.4.15s/v16.1.0</size>\n"
                        + "\n<b>声明</b>\n·本模组不隶属于 Among Us 或 Innersloth LLC 其中包含的内容未得到 Innersloth LLC 的认可或以其他方式赞助 此处包含的部分材料是 Innersloth LLC的财产 ©Innersloth"
                        + "\n<b>对应官方版本</b>\n · TOR v.4.8.0\r"
                        + "\n<b>更新内容</b>\n · 新增切换服务器上下页面按钮\n · 新增DownloadCount\n · 新增聊天框【复制】【粘贴】【剪切】快捷键\n · 新增聊天框查看历史记录（使用键盘上下键）\n · 新增语言:【英文】切换方式为[设置→Date→语言选择→选择English]\n · 删除了一些没用的UI\n · 删除/xw指令\n · 删除违禁词检测更改为政治敏感词检测\n · 修改在线游戏的UI\n · 修改MOTD的字体"
                        + "\n<b>新增技能</b>\n · 时间之主新增主动回溯技能(可以复活在此期间被击杀的船员)",
                    Date = "2025-8-24T00:00:00Z"
                };
                AllModNews.Add(news);
            }

            {
                // TORE v1.2.6
                var news = new ModNews
                {
                    Number = 100008,
                    Title = $"TheOtherRolesEdited  v1.2.6",
                    SubTitle = "新职业来啦!",
                    ShortTitle = $"★TORE",
                    Text = "<size=100%>欢迎来到 TORE v1.2.6.适配Among us v2025.4.15s/v16.1.0</size>\n"
                        + "\n<b>声明</b>\n·本模组不隶属于 Among Us 或 Innersloth LLC 其中包含的内容未得到 Innersloth LLC 的认可或以其他方式赞助 此处包含的部分材料是 Innersloth LLC的财产 ©Innersloth"
                        + "\n<b>对应官方版本</b>\n · TOR v.4.8.0\r"
                        + "\n<b>更新内容</b>\n · 新增按钮[模组官网]\n · 修改按钮颜色\n · 修改MOD图标的坐标\n · 修改VersionShower的坐标\n · 增加边框移动动画\n · 增加主页边框\n · 增加关闭边框按钮\n · 重写制作人员内容\n · 为了保证UI的适配所以强制游戏画面大小为1980x1080\n · 移除在线游戏里的搜索游戏按钮\n · 修改BarSprite的不透明度\n · 修改模组职业设置UI(by:fangkuai)",
                    Date = "2025-8-19T00:00:00Z"
                };
                AllModNews.Add(news);
            }
            {
                // TORE v1.2.5.2
                var news = new ModNews
                {
                    Number = 100007,
                    Title = $"TheOtherRolesEdited  v1.2.5.2",
                    SubTitle = "每日更新:)",
                    ShortTitle = $"★TORE",
                    Text = "<size=100%>欢迎来到 TORE v1.2.5.2.适配Among us v2025.3.31s</size>\n"
                        + "\n<b>声明</b>\n·本模组不隶属于 Among Us 或 Innersloth LLC 其中包含的内容未得到 Innersloth LLC 的认可或以其他方式赞助 此处包含的部分材料是 Innersloth LLC的财产 ©Innersloth"
                        + "\n<b>对应官方版本</b>\n · TOR v.4.8.0\r"
                        + "\n<b>新增</b>\n · <s>我更新了版本号</s>\n · 修复轮抽选角(真的)\n · 更进到 TOR v4.8.0的代码",
                    Date = "2025-6-15T00:00:00Z"
                };
                AllModNews.Add(news);
            }
            {
                // TORE v1.2.5
                var news = new ModNews
                {
                    Number = 100006,
                    Title = $"TheOtherRolesEdited  v1.2.5",
                    SubTitle = "最勤奋的一集(端午节&儿童节快乐!)",
                    ShortTitle = $"★TORE",
                    Text = "<size=100%>欢迎来到 TORE v1.2.5.适配Among us v2025.3.31s</size>\n"
                        + "\n<b>声明</b>\n·本模组不隶属于 Among Us 或 Innersloth LLC 其中包含的内容未得到 Innersloth LLC 的认可或以其他方式赞助 此处包含的部分材料是 Innersloth LLC的财产 ©Innersloth"
                        + "\n<b>对应官方版本</b>\n · TOR v.4.8.0\r"
                        + "\n<b>新增</b>\n ·切换地图皮肤样式(仅限骷髅舰)\n ·轮抽选角增加随机职业按钮\n ·MOTD大厅提示语(方块服务器)\n ·测试模式\n · <s>我还更新了版本号</s>",
                    Date = "2025-6-1T00:00:00Z"
                };
                AllModNews.Add(news);
            }
            {
                // TORE v1.2.4
                var news = new ModNews
                {
                    Number = 100005,
                    Title = $"TheOtherRolesEdited  v1.2.4",
                    SubTitle = "劳动节快乐哈！",
                    ShortTitle = $"★TORE",
                    Text = "<size=100%>欢迎来到 TORE v1.2.4.适配Among us v2025.3.31s</size>\n"
                        + "\n<b>声明</b>\n·本模组不隶属于 Among Us 或 Innersloth LLC 其中包含的内容未得到 Innersloth LLC 的认可或以其他方式赞助 此处包含的部分材料是 Innersloth LLC的财产 ©Innersloth"
                        + "\n<b>对应官方版本</b>\n · TOR v.4.8.0\r"
                        + "\n<b>UI更新</b>\n · 等候大厅UI全新更新重新排版!\n ·创建游戏界面UI更新(by方块)"
                        + "\n<b>轮抽选角</b>\n · 增加聊天功能\n ·增加隐藏船员"
                        + "\n<b>huh</b>\n · 我还更新了版本号",
                    Date = "2025-5-5T00:00:00Z"
                };
                AllModNews.Add(news);
            }
            {
                // TORE v1.2.3
                var news = new ModNews
                {
                    Number = 100004,
                    Title = $"TheOtherRolesEdited  v1.2.3",
                    SubTitle = "我又来更新啦! 快来van:>",
                    ShortTitle = $"★TORE",
                    Text = "<size=100%>欢迎来到 TORE v1.2.3.适配Among us v2025.3.31s</size>\n"
                        + "\n<b>声明</b>\n·本模组不隶属于 Among Us 或 Innersloth LLC 其中包含的内容未得到 Innersloth LLC 的认可或以其他方式赞助 此处包含的部分材料是 Innersloth LLC的财产 ©Innersloth"
                        + "\n<b>对应官方版本</b>\n · TOR v.4.8.0\r"
                        + "\n<b>UI更新</b>\n · 等候大厅UI全新更新重新排版!\n· 主页菜单UI更新:增加‘方块的小站’ & ‘Github’按钮"
                        + "\n<b>修改</b>\n · 中文汉化问题修改"
                        + "\n<b>huh</b>\n · Have a great time！",
                    Date = "2025-4-12T00:00:00Z"
                };
                AllModNews.Add(news);
            }
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
                        + "\n<b>修改</b>\n · 修复了变形狩猎中玩家无法转化为道具的错误"
                        + "\n<b>新增</b>\n · 轮抽选角(by:TOR)\n ·更改的Ping延迟文字在会议中的位置"
                        + "\n<b>温馨提示</b>\n · 在轮抽选角模式中如果想听音乐应调节AU原版的音量大小:>"
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
