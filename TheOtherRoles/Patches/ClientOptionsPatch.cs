using HarmonyLib;
using UnityEngine;
using System;
using System.Collections.Generic;
using TheOtherRolesEdited.Utilities;
using TMPro;
using UnityEngine.Events;
using static UnityEngine.UI.Button;
using Object = UnityEngine.Object;
using Rewired.Utils.Platforms.Windows;

namespace TheOtherRolesEdited.Patches
{
    [HarmonyPatch]
    public static class ClientOptionsPatch
    {
        private static readonly SelectionBehaviour[] AllOptions = {
            new("幽灵可以查看任务&其他", () => TORMapOptions.ghostsSeeInformation = TheOtherRolesEditedPlugin.GhostsSeeInformation.Value = !TheOtherRolesEditedPlugin.GhostsSeeInformation.Value, TheOtherRolesEditedPlugin.GhostsSeeInformation.Value,0),
            new("幽灵可以看到地图上的管道", () => TORMapOptions.ghostsSeeVotes = TheOtherRolesEditedPlugin.GhostsSeeVotes.Value = !TheOtherRolesEditedPlugin.GhostsSeeVotes.Value, TheOtherRolesEditedPlugin.GhostsSeeVotes.Value,0),
            new("幽灵可以看到职业", () => TORMapOptions.ghostsSeeRoles = TheOtherRolesEditedPlugin.GhostsSeeRoles.Value = !TheOtherRolesEditedPlugin.GhostsSeeRoles.Value, TheOtherRolesEditedPlugin.GhostsSeeRoles.Value,0),
            new("幽灵可以看到附加职业", () => TORMapOptions.ghostsSeeModifier = TheOtherRolesEditedPlugin.GhostsSeeModifier.Value = !TheOtherRolesEditedPlugin.GhostsSeeModifier.Value, TheOtherRolesEditedPlugin.GhostsSeeModifier.Value,0),
            new("显示角色摘要", () => TORMapOptions.showRoleSummary = TheOtherRolesEditedPlugin.ShowRoleSummary.Value = !TheOtherRolesEditedPlugin.ShowRoleSummary.Value, TheOtherRolesEditedPlugin.ShowRoleSummary.Value,0),
            new("显示颜色类型亮/暗", () => TORMapOptions.showLighterDarker = TheOtherRolesEditedPlugin.ShowLighterDarker.Value = !TheOtherRolesEditedPlugin.ShowLighterDarker.Value, TheOtherRolesEditedPlugin.ShowLighterDarker.Value,0),
            new("在地图上显示通风口", () => TORMapOptions.ShowVentsOnMap = TheOtherRolesEditedPlugin.ShowVentsOnMap.Value = !TheOtherRolesEditedPlugin.ShowVentsOnMap.Value, TheOtherRolesEditedPlugin.ShowVentsOnMap.Value,0),
            new("显示聊天通知", () => TORMapOptions.ShowChatNotifications = TheOtherRolesEditedPlugin.ShowChatNotifications.Value = !TheOtherRolesEditedPlugin.ShowChatNotifications.Value, TheOtherRolesEditedPlugin.ShowChatNotifications.Value,0),
            new("启用模组光标", () => TORMapOptions.toggleCursor = TheOtherRolesEditedPlugin.ToggleCursor.Value = !TheOtherRolesEditedPlugin.ToggleCursor.Value, TheOtherRolesEditedPlugin.ToggleCursor.Value,1),
              new("启用模组音效", () =>  {
                TORMapOptions.enableSoundEffects = TheOtherRolesEditedPlugin.EnableSoundEffects.Value = !TheOtherRolesEditedPlugin.EnableSoundEffects.Value;
                if (!TORMapOptions.enableSoundEffects) SoundEffectsManager.stopAll();
                 return TORMapOptions.enableSoundEffects;
                }, TheOtherRolesEditedPlugin.EnableSoundEffects.Value,0),
        };

        private static GameObject popUp;
        private static TextMeshPro titleText;

        private static ToggleButtonBehaviour buttonPrefab;
        private static Vector3? _origin;
  

        [HarmonyPostfix]


        [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
        public static void MainMenuManager_StartPostfix(MainMenuManager __instance)
        {
            // Prefab for the title
            var go = new GameObject("TitleTextTOR");
            var tmp = go.AddComponent<TextMeshPro>();
            tmp.fontSize = 4;
            tmp.alignment = TextAlignmentOptions.Center;
            tmp.transform.localPosition += Vector3.left * 0.2f;
            titleText = Object.Instantiate(tmp);
            titleText.gameObject.SetActive(false);
            Object.DontDestroyOnLoad(titleText);
        }


        [HarmonyPostfix]
        [HarmonyPatch(typeof(OptionsMenuBehaviour), nameof(OptionsMenuBehaviour.Start))]
        public static void OptionsMenuBehaviour_StartPostfix(OptionsMenuBehaviour __instance)
        {
            if (!__instance.CensorChatButton) return;

            if (!popUp)
            {
                CreateCustom(__instance);
            }
            if (!buttonPrefab)
            {
                buttonPrefab = Object.Instantiate(__instance.CensorChatButton);
                Object.DontDestroyOnLoad(buttonPrefab);
                buttonPrefab.name = "CensorChatPrefab";
                buttonPrefab.gameObject.SetActive(false);
            }
            SetUpOptions();
            InitializeMoreButton(__instance);
        }

        private static void CreateCustom(OptionsMenuBehaviour prefab)
        {
            popUp = Object.Instantiate(prefab.gameObject);
            Object.DontDestroyOnLoad(popUp);
            var transform = popUp.transform;
            var pos = transform.localPosition;
            pos.z = -810f;
            transform.localPosition = pos;

            Object.Destroy(popUp.GetComponent<OptionsMenuBehaviour>());
            foreach (var gObj in popUp.gameObject.GetAllChilds())
            {
                if (gObj.name != "Background" && gObj.name != "CloseButton")
                    Object.Destroy(gObj);
            }

            popUp.SetActive(false);
        }

        private static void InitializeMoreButton(OptionsMenuBehaviour __instance)
        {
            var moreOptions = Object.Instantiate(buttonPrefab, __instance.CensorChatButton.transform.parent);
            var transform = __instance.CensorChatButton.transform;
            __instance.CensorChatButton.Text.transform.localScale = new Vector3(1 / 0.66f, 1, 1);
            _origin ??= transform.localPosition;

            transform.localPosition = _origin.Value + Vector3.left * 0.45f;
            transform.localScale = new Vector3(0.66f, 1, 1);
            __instance.EnableFriendInvitesButton.transform.localScale = new Vector3(0.66f, 1, 1);
            __instance.EnableFriendInvitesButton.transform.localPosition += Vector3.right * 0.5f;
            __instance.EnableFriendInvitesButton.Text.transform.localScale = new Vector3(1.2f, 1, 1);

            moreOptions.transform.localPosition = _origin.Value + Vector3.right * 4f / 3f;
            moreOptions.transform.localScale = new Vector3(0.66f, 1, 1);

            moreOptions.gameObject.SetActive(true);
            moreOptions.Text.text = "模组设置...";
            moreOptions.Text.transform.localScale = new Vector3(1 / 0.66f, 1, 1);
            var moreOptionsButton = moreOptions.GetComponent<PassiveButton>();
            moreOptionsButton.OnClick = new ButtonClickedEvent();
            moreOptionsButton.OnClick.AddListener((Action)(() =>
            {
                bool closeUnderlying = false;
                if (!popUp) return;

                if (__instance.transform.parent && __instance.transform.parent == FastDestroyableSingleton<HudManager>.Instance.transform)
                {
                    popUp.transform.SetParent(FastDestroyableSingleton<HudManager>.Instance.transform);
                    popUp.transform.localPosition = new Vector3(0, 0, -800f);
                    closeUnderlying = true;
                }
                else
                {
                    popUp.transform.SetParent(null);
                    Object.DontDestroyOnLoad(popUp);
                }

                CheckSetTitle();
                RefreshOpen();
                if (closeUnderlying)
                    __instance.Close();
            }));
        }

        private static void RefreshOpen()
        {
            popUp.gameObject.SetActive(false);
            popUp.gameObject.SetActive(true);
            SetUpOptions();
        }

        private static void CheckSetTitle()
        {
            if (!popUp || popUp.GetComponentInChildren<TextMeshPro>() || !titleText) return;

            var title = Object.Instantiate(titleText, popUp.transform);
            title.GetComponent<RectTransform>().localPosition = Vector3.up * 2.3f;
            title.gameObject.SetActive(true);
            title.text = "更多设置...";
            title.name = "TitleText";
        }

        private static void SetUpOptions()
        {
            if (popUp.transform.GetComponentInChildren<ToggleButtonBehaviour>()) return;

            for (var i = 0; i < AllOptions.Length; i++)
            {
                var info = AllOptions[i];

                var button = Object.Instantiate(buttonPrefab, popUp.transform);
                var pos = new Vector3(i % 2 == 0 ? -1.17f : 1.17f, 1.3f - i / 2 * 0.8f, -.5f);

                var transform = button.transform;
                transform.localPosition = pos;

                button.onState = info.DefaultValue;
                button.Background.color = button.onState ? Color.green : Palette.ImpostorRed;

                button.Text.text = info.Title;
                button.Text.fontSizeMin = button.Text.fontSizeMax = 1.8f;
                button.Text.font = Object.Instantiate(titleText.font);
                button.Text.GetComponent<RectTransform>().sizeDelta = new Vector2(2, 2);

                button.name = info.Title.Replace(" ", "") + "Toggle";
                button.gameObject.SetActive(true);

                var passiveButton = button.GetComponent<PassiveButton>();
                var colliderButton = button.GetComponent<BoxCollider2D>();

                colliderButton.size = new Vector2(2.2f, .7f);

                passiveButton.OnClick = new ButtonClickedEvent();
                passiveButton.OnMouseOut = new UnityEvent();
                passiveButton.OnMouseOver = new UnityEvent();

                passiveButton.OnClick.AddListener((Action)(() =>
                {
                    if (info.Number == 1)
                    {
                        Helpers.enableCursor(false);
                    }
                    button.onState = info.OnClick();
                    button.Background.color = button.onState ? Color.green : Palette.ImpostorRed;
                }));

                passiveButton.OnMouseOver.AddListener((Action)(() => button.Background.color = button.onState ? new Color32(34, 139, 34, byte.MaxValue) : new Color32(139, 34, 34, byte.MaxValue)));
                passiveButton.OnMouseOut.AddListener((Action)(() => button.Background.color = button.onState ? Color.green : Palette.ImpostorRed));

                foreach (var spr in button.gameObject.GetComponentsInChildren<SpriteRenderer>())
                    spr.size = new Vector2(2.2f, .7f);
            }
        }

        private static IEnumerable<GameObject> GetAllChilds(this GameObject Go)
        {
            for (var i = 0; i < Go.transform.childCount; i++)
            {
                yield return Go.transform.GetChild(i).gameObject;
            }
        }

        public class SelectionBehaviour
        {
            public string Title;
            public Func<bool> OnClick;
            public bool DefaultValue;
            public float Number;

            public SelectionBehaviour(string title, Func<bool> onClick, bool defaultValue,float number)
            {
                Title = title;
                OnClick = onClick;
                DefaultValue = defaultValue;
                Number = number;
            }
        }
    }
}
