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

namespace TheOtherRolesEdited.Modules {
    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    public class MainMenuPatch {
        private static bool horseButtonState = TORMapOptions.enableHorseMode;
        //private static Sprite horseModeOffSprite = null;
        //private static Sprite horseModeOnSprite = null;
        private static AnnouncementPopUp popUp;
        
        private static void Prefix(MainMenuManager __instance) {
            SoundEffectsManager.Load();
            var template = GameObject.Find("ExitGameButton");
            var buttonQQ = UnityEngine.Object.Instantiate(template, template.transform.parent);
            var buttonBG = UnityEngine.Object.Instantiate(template, template.transform.parent);
            var buttonFK = UnityEngine.Object.Instantiate(template, template.transform.parent);
            var buttonGH = UnityEngine.Object.Instantiate(template, template.transform.parent);
            buttonQQ.GetComponent<AspectPosition>().anchorPoint = new Vector2(0.586f, 0.43f);
            buttonBG.GetComponent<AspectPosition>().anchorPoint = new Vector2(1.389f, 0.30f);
            buttonFK.GetComponent<AspectPosition>().anchorPoint = new Vector2(0.586f, 0.36f);
            buttonGH.GetComponent<AspectPosition>().anchorPoint = new Vector2(0.412f, 0.36f);
           
            //FK button
            var textFK = buttonFK.transform.GetComponentInChildren<TMPro.TMP_Text>();
            __instance.StartCoroutine(Effects.Lerp(0.5f, new System.Action<float>((p) => {
                textFK.SetText("方块の小站");
            })));
            PassiveButton passiveButtonFK = buttonFK.GetComponent<PassiveButton>();
            passiveButtonFK.activeTextColor = new Color32(0, 191, 255, byte.MaxValue);
            passiveButtonFK.OnClick = new Button.ButtonClickedEvent();
            passiveButtonFK.OnClick.AddListener((System.Action)(() => Application.OpenURL("https://fungle.icu")));
            passiveButtonFK.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0.191f, 255f);
            passiveButtonFK.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 255f);
            Color originalColorpassiveButtonFK = passiveButtonFK.inactiveSprites.GetComponent<SpriteRenderer>().color;
            passiveButtonFK.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorpassiveButtonFK * 0.6f;
           
            //Github button
            var textGH = buttonGH.transform.GetComponentInChildren<TMPro.TMP_Text>();
            __instance.StartCoroutine(Effects.Lerp(0.5f, new System.Action<float>((p) => {
                textGH.SetText("Github");
            })));
            PassiveButton passiveButtonGH = buttonGH.GetComponent<PassiveButton>();
            passiveButtonGH.activeTextColor = new Color32(0, 191, 255, byte.MaxValue);
            passiveButtonGH.OnClick = new Button.ButtonClickedEvent();
            passiveButtonGH.OnClick.AddListener((System.Action)(() => Application.OpenURL("https://github.com/XtremeWave/TheOtherRolesEdited")));
            passiveButtonGH.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0.191f, 255f);
            passiveButtonGH.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 255f);
            Color originalColorpassiveButtonGH = passiveButtonGH.inactiveSprites.GetComponent<SpriteRenderer>().color;
            passiveButtonGH.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorpassiveButtonGH * 0.6f;
            
            //QQ button
            var textQQ = buttonQQ.transform.GetComponentInChildren<TMPro.TMP_Text>();
            __instance.StartCoroutine(Effects.Lerp(0.5f, new System.Action<float>((p) => {
                textQQ.SetText("QQ频道");
            })));
            PassiveButton passiveButtonQQ = buttonQQ.GetComponent<PassiveButton>();
            passiveButtonQQ.activeTextColor = new Color32(0, 191, 255, byte.MaxValue);
            passiveButtonQQ.OnClick = new Button.ButtonClickedEvent();
            passiveButtonQQ.OnClick.AddListener((System.Action)(() => Application.OpenURL("https://qm.qq.com/q/xyaS08h3Lq")));
            passiveButtonQQ.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0.191f, 255f);
            passiveButtonQQ.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 255f);
            Color originalColorpassiveButtonQQ = passiveButtonQQ.inactiveSprites.GetComponent<SpriteRenderer>().color;
            passiveButtonQQ.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorpassiveButtonQQ * 0.6f;
            buttonQQ.GetComponent<AspectPosition>().anchorPoint = new Vector2(0.586f, 0.43f);
            
            //Bg Button
            var textBG = buttonBG.transform.GetComponentInChildren<TMPro.TMP_Text>();
            __instance.StartCoroutine(Effects.Lerp(0.5f, new System.Action<float>((p) => {
                textBG.SetText($"<b>Background © AiGe</B>");
            })));
            textBG.outlineColor = Color.black;
            textBG.outlineWidth = 0.18f;
            PassiveButton passiveButtonBG = buttonBG.GetComponent<PassiveButton>();
            passiveButtonBG.activeTextColor = new Color32(0, 191, 255, byte.MaxValue);
            passiveButtonBG.OnClick = new Button.ButtonClickedEvent();
            passiveButtonBG.OnClick.AddListener((System.Action)(() => Application.OpenURL("http://qm.qq.com/cgi-bin/qm/qr?_wv=1027&k=1YPTXe2Sh93pAUXv1mwv4unI6J_G1FYK&authKey=%2BPzdgfi%2FpbaxyPTVU1Lx8xU69Zo1X4%2FCih0lTozAbZ0%2FsCiO%2FGe8sQ97p6jxEFlV&noverify=0&group_code=647668527")));
            passiveButtonBG.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
            passiveButtonBG.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
            Color originalColorpassiveButtonBG = passiveButtonQQ.inactiveSprites.GetComponent<SpriteRenderer>().color;
            passiveButtonBG.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorpassiveButtonQQ * 0f;
            passiveButtonBG.activeSprites.GetComponent<SpriteRenderer>().color = originalColorpassiveButtonQQ * 0f;
            passiveButtonBG.OnMouseOut.AddListener((Action)(() => textBG.color = Color.white));
            passiveButtonBG.OnMouseOver.AddListener((Action)(() => textBG.color = Color.red));

            // TOR credits button
            if (template == null) return;
            var creditsButton = Object.Instantiate(template, template.transform.parent);
            creditsButton.GetComponent<AspectPosition>().anchorPoint = new Vector2(0.412f, 0.43f);

            var textCreditsButton = creditsButton.transform.GetComponentInChildren<TMPro.TMP_Text>();
            __instance.StartCoroutine(Effects.Lerp(0.5f, new System.Action<float>((p) => {
                textCreditsButton.SetText ("TORE公告");
            })));
            PassiveButton passiveCreditsButton = creditsButton.GetComponent<PassiveButton>();

            passiveCreditsButton.OnClick = new Button.ButtonClickedEvent();
            passiveCreditsButton.inactiveSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0.191f, 255f);
            passiveCreditsButton.activeSprites.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 255f);
            Color originalColorpassiveCreditsButton = passiveCreditsButton.inactiveSprites.GetComponent<SpriteRenderer>().color;
            passiveCreditsButton.inactiveSprites.GetComponent<SpriteRenderer>().color = originalColorpassiveCreditsButton * 0.6f;
            passiveCreditsButton.activeTextColor = Color.white;
            passiveCreditsButton.inactiveTextColor = Color.white;



            passiveCreditsButton.OnClick.AddListener((System.Action)delegate {
                // do stuff
                if (popUp != null) Object.Destroy(popUp);
                var popUpTemplate = Object.FindObjectOfType<AnnouncementPopUp>(true);
                if (popUpTemplate == null) {
                    TheOtherRolesEditedPlugin.Logger.LogError("couldnt show credits, popUp is null");
                    return;
                }
                popUp = Object.Instantiate(popUpTemplate);

                popUp.gameObject.SetActive(true);
                string creditsString = @$"<align=""center""><b>Github Contributors:</b>
Alex2911    amsyarasyiq    MaximeGillot
Psynomit    probablyadnf    JustASysAdmin
[https://discord.gg/w7msq53dq7]Discord[] Moderators:
Ryuk    K    XiezibanWrite
Thanks to all our discord helpers!
Thanks to miniduikboot & GD for hosting modded servers
";
                creditsString += $@"<size=60%> Other Credits & Resources:
OxygenFilter - For the versions v2.3.0 to v2.6.1, we were using the OxygenFilter for automatic deobfuscation
Reactor - The framework used for all versions before v2.0.0, and again since 4.2.0
BepInEx - Used to hook game functions
Essentials - Custom game options by DorCoMaNdO:
Before v1.6: We used the default Essentials release
v1.6-v1.8: We slightly changed the default Essentials.
Four Han sinicization group - Some of the pictures are made by them
Jackal and Sidekick - Original idea for the Jackal and Sidekick came from Dhalucard
Among-Us-Love-Couple-Mod - Idea for the Lovers modifier comes from Woodi-dev
Jester - Idea for the Jester role came from Maartii
ExtraRolesAmongUs - Idea for the Engineer and Medic role came from NotHunter101. Also some code snippets from their implementation were used.
Among-Us-Sheriff-Mod - Idea for the Sheriff role came from Woodi-dev
TooManyRolesMods - Idea for the Detective and Time Master roles comes from Hardel-DW. Also some code snippets from their implementation were used.
TownOfUs - Idea for the Swapper, Shifter, Arsonist and a similar Mayor role came from Slushiegoose
Ottomated - Idea for the Morphling, Snitch and Camouflager role came from Ottomated
Crowded-Mod - Our implementation for 10+ player lobbies was inspired by the one from the Crowded Mod Team
Goose-Goose-Duck - Idea for the Vulture role came from Slushiegoose
TheEpicRoles - Idea for the first kill shield (partly) and the tabbed option menu (fully + some code), by LaicosVK DasMonschta Nova</size>";
                creditsString += "</align>";


                Assets.InnerNet.Announcement creditsAnnouncement = new() {
                    Id = "torCredits",
                    Language = 0,
                    Number = 500,
                    Title = "\nThe Other Roles Edited\n贡献 & 资源",
                    ShortTitle = "TORE公告",
                    SubTitle = "",
                    PinState = false,
                    Date = "01.07.2022",
                    Text = creditsString,
                };
                __instance.StartCoroutine(Effects.Lerp(0.1f, new Action<float>((p) => {
                    if (p == 1) {
                        var backup = DataManager.Player.Announcements.allAnnouncements;
                        DataManager.Player.Announcements.allAnnouncements = new();
                        popUp.Init(false);
                        DataManager.Player.Announcements.SetAnnouncements(new Announcement[] { creditsAnnouncement });
                        popUp.CreateAnnouncementList();
                        popUp.UpdateAnnouncementText(creditsAnnouncement.Number);
                        popUp.visibleAnnouncements._items[0].PassiveButton.OnClick.RemoveAllListeners();
                        DataManager.Player.Announcements.allAnnouncements = backup;
                    }
                })));
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

        public static void addSceneChangeCallbacks() {
            SceneManager.add_sceneLoaded((Action<Scene, LoadSceneMode>)((scene, _) => {
                if (!scene.name.Equals("MatchMaking", StringComparison.Ordinal)) return;
                TORMapOptions.gameMode = CustomGamemodes.Classic;
                // Add buttons For Guesser Mode, Hide N Seek in this scene.
                // find "HostLocalGameButton"
                var template = GameObject.FindObjectOfType<HostLocalGameButton>();
                var gameButton = template.transform.FindChild("CreateGameButton");
                var gameButtonPassiveButton = gameButton.GetComponentInChildren<PassiveButton>();

                var guesserButton = GameObject.Instantiate<Transform>(gameButton, gameButton.parent);
                guesserButton.transform.localPosition += new Vector3(0f, -0.5f);
                var guesserButtonText = guesserButton.GetComponentInChildren<TMPro.TextMeshPro>();
                var guesserButtonPassiveButton = guesserButton.GetComponentInChildren<PassiveButton>();
                
                guesserButtonPassiveButton.OnClick = new Button.ButtonClickedEvent();
                guesserButtonPassiveButton.OnClick.AddListener((System.Action)(() => {
                    TORMapOptions.gameMode = CustomGamemodes.Guesser;
                    template.OnClick();
                }));

                var HideNSeekButton = GameObject.Instantiate<Transform>(gameButton, gameButton.parent);
                HideNSeekButton.transform.localPosition += new Vector3(1.7f, -0.5f);
                var HideNSeekButtonText = HideNSeekButton.GetComponentInChildren<TMPro.TextMeshPro>();
                var HideNSeekButtonPassiveButton = HideNSeekButton.GetComponentInChildren<PassiveButton>();
                
                HideNSeekButtonPassiveButton.OnClick = new Button.ButtonClickedEvent();
                HideNSeekButtonPassiveButton.OnClick.AddListener((System.Action)(() => {
                    TORMapOptions.gameMode = CustomGamemodes.HideNSeek;
                    template.OnClick();
                }));

                var PropHuntButton = GameObject.Instantiate<Transform>(gameButton, gameButton.parent);
                PropHuntButton.transform.localPosition += new Vector3(3.4f, -0.5f);
                var PropHuntButtonText = PropHuntButton.GetComponentInChildren<TMPro.TextMeshPro>();
                var PropHuntButtonPassiveButton = PropHuntButton.GetComponentInChildren<PassiveButton>();

                PropHuntButtonPassiveButton.OnClick = new Button.ButtonClickedEvent();
                PropHuntButtonPassiveButton.OnClick.AddListener((System.Action)(() => {
                    TORMapOptions.gameMode = CustomGamemodes.PropHunt;
                    template.OnClick();
                }));

                template.StartCoroutine(Effects.Lerp(0.1f, new System.Action<float>((p) => {
                    guesserButtonText.SetText("赌怪模式");
                    HideNSeekButtonText.SetText("捉迷藏模式");
                    PropHuntButtonText.SetText("变形躲猫猫模式");
                })));
            }));
        }
    }
}
