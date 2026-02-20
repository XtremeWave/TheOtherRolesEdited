using System;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using UnityEngine.SceneManagement;
using AmongUs.Data;
using Assets.InnerNet;
using BepInEx.Unity.IL2CPP;
using System.Linq;
using static UnityEngine.UI.Button;
using System.Collections.Generic;
using TMPro;

namespace TheOtherRolesEdited.Modules;

[HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
public class MainMenuPatch
{
    private static bool horseButtonState = TORMapOptions.enableHorseMode;
    //private static Sprite horseModeOffSprite = null;
    //private static Sprite horseModeOnSprite = null;
    //private static AnnouncementPopUp popUp;
    public static GameObject modScreen = null;
    internal static TMP_FontAsset fontAssetVersionShower;
    internal static TMP_FontAsset fontAsset;
    private static void ForceSetButtonText(GameObject button, string text)
    {
        var translator = button.GetComponentInChildren<TextTranslatorTMP>();
        if (translator != null)
            UnityEngine.Object.Destroy(translator);

        var tmp = button.GetComponentInChildren<TMPro.TMP_Text>();
        if (tmp != null)
        {
            tmp.text = text;
            tmp.ForceMeshUpdate();
        }
    }

    private static void Prefix(MainMenuManager __instance)
    {
        SoundEffectsManager.Load();
        var template = GameObject.Find("CreditsButton");
        var websiteButton = UnityEngine.Object.Instantiate(template, template.transform.parent);
        var githubButton = UnityEngine.Object.Instantiate(template, template.transform.parent);
      
        //position
        websiteButton.GetComponent<AspectPosition>().anchorPoint = new Vector2(0.586f, 0.36f);
        githubButton.GetComponent<AspectPosition>().anchorPoint = new Vector2(0.412f, 0.36f);
        
        //scale
        var scalerList = __instance.mainMenuUI.GetComponent<SlicedAspectScaler>();
        scalerList.objectsToScale.Add(websiteButton.GetComponent<AspectScaledAsset>());
        scalerList.objectsToScale.Add(githubButton.GetComponent<AspectScaledAsset>());

        //FK button
        websiteButton.name = "WebsiteButton";
        ForceSetButtonText(websiteButton, ModTranslation.getString("ModWebsite"));
        PassiveButton PassiveWebsiteButton = websiteButton.GetComponent<PassiveButton>();
        PassiveWebsiteButton.activeTextColor = new Color32(0, 191, 255, byte.MaxValue);
        PassiveWebsiteButton.OnClick = new Button.ButtonClickedEvent();
        PassiveWebsiteButton.OnClick.AddListener((System.Action)(() => Application.OpenURL("https://tore.amongusclub.cn/")));
        PassiveWebsiteButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0.333f, 0.255f, 1f);
        PassiveWebsiteButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0.333f, 0.255f, 2f, 0.8f);
        Color originalColorPassiveWebsiteButton = PassiveWebsiteButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        PassiveWebsiteButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorPassiveWebsiteButton * 0.6f;

        //Github button
        githubButton.name = "GithubButton";
        ForceSetButtonText(githubButton, "Github");
        PassiveButton passiveGithubButton = githubButton.GetComponent<PassiveButton>();
        passiveGithubButton.activeTextColor = new Color32(0, 191, 255, byte.MaxValue);
        passiveGithubButton.OnClick = new Button.ButtonClickedEvent();
        passiveGithubButton.OnClick.AddListener((System.Action)(() => Application.OpenURL("https://github.com/XtremeWave/TheOtherRolesEdited")));
        passiveGithubButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0.333f, 0.255f, 1f);
        passiveGithubButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0.333f, 0.255f, 2f, 0.8f);
        Color originalColorpassiveGithubButton = passiveGithubButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        passiveGithubButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorpassiveGithubButton * 0.6f;

        // TOR credits button
        if (template == null) return;
        var creditsButton = Object.Instantiate(template, template.transform.parent);
        scalerList.objectsToScale.Add(creditsButton.GetComponent<AspectScaledAsset>());
        creditsButton.GetComponent<AspectPosition>().anchorPoint = new Vector2(0.412f, 0.43f);
        creditsButton.name = "creditsButton";
        ForceSetButtonText(creditsButton, ModTranslation.getString("TOREcredits"));
        PassiveButton passiveCreditsButton = creditsButton.GetComponent<PassiveButton>();
        passiveCreditsButton.OnClick = new Button.ButtonClickedEvent();
        passiveCreditsButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0.333f, 0.255f, 1f);
        passiveCreditsButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0.333f, 0.255f, 2f, 0.8f);
        Color originalColorpassiveCreditsButton = passiveCreditsButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
        passiveCreditsButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorpassiveCreditsButton * 0.6f;
        passiveCreditsButton.activeTextColor = Color.white;
        passiveCreditsButton.inactiveTextColor = Color.white;


        passiveCreditsButton.OnClick.AddListener((System.Action)delegate
        {
            MainMenuManagerPatch.HideRightPanel();
            void ShowPopup(string text)
            {
                var popup = GameObject.Instantiate(DiscordManager.Instance.discordPopup, Camera.main!.transform);

                var background = popup.transform.Find("Background").GetComponent<SpriteRenderer>();
                var size = background.size;
                size.x *= 2.5f;
                background.size = size;
                background.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.MainPhoto.Background.png", 150f);
                background.transform.localScale = new Vector3(1.2f, 3.16f, 1f);
                popup.TextAreaTMP.fontSizeMin = 2;
                popup.TextAreaTMP.rectTransform.localPosition = new Vector3(-3.2f, 0.06f);
                popup.TextAreaTMP.font = fontAssetVersionShower;
                popup.Show(text);

                var exitBtn = popup.transform.Find("ExitGame");
                if (exitBtn != null)
                {
                    var btnSpriteRenderer = exitBtn.GetComponent<SpriteRenderer>();
                    if (btnSpriteRenderer != null)
                    {
                        Sprite customBgSprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.MainPhoto.Close.png", 100f);
                        if (customBgSprite != null)
                        {
                            btnSpriteRenderer.sprite = customBgSprite;
                        }
                    }
                    exitBtn.transform.localScale = new Vector3(0.45f, 1.6f, 1f);
                    var pos = exitBtn.localPosition;
                    pos.x = 4.2364f;
                    pos.y = 2.4724f;
                    exitBtn.localPosition = pos;

                    var buttonText = exitBtn.transform.GetComponentInChildren<TMPro.TMP_Text>();
                    __instance.StartCoroutine(Effects.Lerp(0.5f, new System.Action<float>((p) =>
                    {
                        buttonText.SetText($"");
                        buttonText.font = fontAsset;
                    })));
                }
            }

            string creditsString = @$"<size=60%>
<align=""left"">★<b>Github 贡献者:</b>
Alex2911    amsyarasyiq    MaximeGillot
Psynomit    probablyadnf    JustASysAdmin
★<b>Discord 管理员:</b>
Ryuk    K    XiezibanWrite
感谢所有 discord 上的支持者!
感谢 miniduikboot & GD 制作模组服务器
★<b>其他的贡献和资源:</b>
OxygenFilter -  在 v2.3.0 至 v2.6.1 版本中，我们使用 OxygenFilter 进行自动反混淆处理
Reactor - 在 v2.0.0 之前的所有版本以及 v4.2.0 之后的版本均使用该框架
BepInEx - 用于挂钩游戏函数
Essentials - DorCoMaNdO 的自定义游戏选项:
v1.6 之前：我们使用 Essentials 的默认版本 v1.6 至 v1.8：我们对默认的 Essentials 做了轻微修改
Four Han sinicization group - 部分图标由他们制作
Jackal and Sidekick - 豺狼与跟班角色的创意源自 Dhalucard
Among-Us-Love-Couple-Mod -  恋人角色的创意源自 Woodi-dev
Jester - 小丑角色的创意源自 Maartii
ExtraRolesAmongUs - 工程师与医生角色的创意源自 NotHunter101，同时借鉴了部分代码
Among-Us-Sheriff-Mod - 警长角色的创意源自 Woodi-dev
TooManyRolesMods - 侦探与时间大师角色的创意源自 Hardel-DW，同时借鉴了部分代码
TownOfUs - 换票师、交换师、纵火犯以及市长角色的创意源自 Slushiegoose
Ottomated - 化形者、告密者与隐蔽者角色的创意源自 Ottomated
Crowded-Mod - 我们对 10 人以上玩家大厅的实现方式，灵感源自 Crowded 模组团队的方案
Goose-Goose-Duck - 秃鹫角色的创意源自 Slushiegoose
TheEpicRoles - 首刀保护（选用部分代码）以及菜单选项的创意（选用部分代码）源自 LaicosVK、DasMonschta、Nova
轮抽选角 - 音乐源自 Youtube【Unreal Superhero 3 by Kenët & Rez】
<b>编辑时间: 2025.11.15</b> </size></align>";

            string credits = $@"<size=150%>TORE贡献者</size>";

            ShowPopup(credits + creditsString);
        });
    }
    private static void CheckAndUnpatch()
    {
        // 获取所有已加载的插件
        var loadedPlugins = IL2CPPChainloader.Instance.Plugins.Values;
        // 检查是否有目标插件
        var targetPlugin = loadedPlugins.FirstOrDefault(plugin => plugin.Metadata.Name == "MalumMenu");

        if (targetPlugin != null)
        {
            TheOtherRolesEditedPlugin.Logger.LogMessage("已检测到您使用了MM外挂.\n TORE将不再运行\n删除MalumMenu.dll即可恢复");
            Harmony.UnpatchAll();//当进入MainMenu时检测加载如果有MM 就自动关闭
        }
    }

    public static void addSceneChangeCallbacks()
    {
        SceneManager.add_sceneLoaded((Action<Scene, LoadSceneMode>)((scene, _) =>
        {
            if (!scene.name.Equals("MatchMaking", StringComparison.Ordinal)) return;
            TORMapOptions.gameMode = CustomGamemodes.Classic;
            // Add buttons For Guesser Mode, Hide N Seek in this scene.
            // find "HostLocalGameButton"
            var template = GameObject.FindObjectOfType<HostLocalGameButton>();
            var gameButton = template.transform.FindChild("CreateGameButton");
            var gameButtonPassiveButton = gameButton.GetComponentInChildren<PassiveButton>();

            var guesserButton = GameObject.Instantiate<Transform>(gameButton, gameButton.parent);
            guesserButton.transform.localPosition = new Vector3(2.115f, -0.257f);
            var guesserButtonText = guesserButton.GetComponentInChildren<TMPro.TextMeshPro>();
            var guesserButtonPassiveButton = guesserButton.GetComponentInChildren<PassiveButton>();

            guesserButtonPassiveButton.OnClick = new Button.ButtonClickedEvent();
            guesserButtonPassiveButton.OnClick.AddListener((System.Action)(() =>
            {
                TORMapOptions.gameMode = CustomGamemodes.Guesser;
                template.OnClick();
            }));

            var HideNSeekButton = GameObject.Instantiate<Transform>(gameButton, gameButton.parent);
            HideNSeekButton.transform.localPosition = new Vector3(3.815f, -0.257f);
            var HideNSeekButtonText = HideNSeekButton.GetComponentInChildren<TMPro.TextMeshPro>();
            var HideNSeekButtonPassiveButton = HideNSeekButton.GetComponentInChildren<PassiveButton>();

            HideNSeekButtonPassiveButton.OnClick = new Button.ButtonClickedEvent();
            HideNSeekButtonPassiveButton.OnClick.AddListener((System.Action)(() =>
            {
                TORMapOptions.gameMode = CustomGamemodes.HideNSeek;
                template.OnClick();
            }));

            var PropHuntButton = GameObject.Instantiate<Transform>(gameButton, gameButton.parent);
            PropHuntButton.transform.localPosition += new Vector3(0f, -0.5f);
            var PropHuntButtonText = PropHuntButton.GetComponentInChildren<TMPro.TextMeshPro>();
            var PropHuntButtonPassiveButton = PropHuntButton.GetComponentInChildren<PassiveButton>();

            PropHuntButtonPassiveButton.OnClick = new Button.ButtonClickedEvent();
            PropHuntButtonPassiveButton.OnClick.AddListener((System.Action)(() =>
            {
                TORMapOptions.gameMode = CustomGamemodes.PropHunt;
                template.OnClick();
            }));

            template.StartCoroutine(Effects.Lerp(0.1f, new System.Action<float>((p) =>
            {
                guesserButtonText.SetText($"{ModTranslation.getString("Guesser")}");
                HideNSeekButtonText.SetText($"{ModTranslation.getString("HideNSeek")}");
                PropHuntButtonText.SetText($"{ModTranslation.getString("PropHunt")}");
            })));
        }));
    }

    internal static void ForceSetButtonText(GameObject modeButton, object v)
    {
        throw new NotImplementedException();
    }
}