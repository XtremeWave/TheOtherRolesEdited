using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using HarmonyLib;
using AmongUs.Data.Legacy;
using TheOtherRolesEdited.Utilities;

namespace TheOtherRolesEdited.Modules {
    public class CustomColors {
        protected static Dictionary<int, string> ColorStrings = new Dictionary<int, string>();
        public static List<int> lighterColors = new List<int>(){ 3, 4, 5, 7, 10, 11, 13, 14, 17 };
        public static uint pickableColors = (uint)Palette.ColorNames.Length;
        private static readonly List<int> ORDER = new List<int>() { 7, 37, 14, 5, 33, 41, 25,
                                                                    4, 30, 0, 35, 3, 27, 17,
                                                                    13, 23, 8, 32, 38, 1, 21,
                                                                    40, 31, 10, 34, 22, 28, 36,
                                                                    2, 11, 26, 29, 20, 19, 18,
                                                                    12, 9, 24, 16, 15, 6, 39,
                                                                    };
        public static void Load() {
            List<StringNames> longlist = Enumerable.ToList<StringNames>(Palette.ColorNames);
            List<Color32> colorlist = Enumerable.ToList<Color32>(Palette.PlayerColors);
            List<Color32> shadowlist = Enumerable.ToList<Color32>(Palette.ShadowColors);

            List<CustomColor> colors = new List<CustomColor>();

            /* Custom Colors, starting with id (for ORDER) 18 */
            colors.Add(new CustomColor
            {
                longname = "浅粉蓝(MOD)", //18
                color = new Color32(255, 245, 238, byte.MaxValue),
                shadow = new Color32(240, 255, 255, byte.MaxValue),
                isLighterColor = true
            });
            colors.Add(new CustomColor
            {
                longname = "天蓝色(MOD)", // 19
                color = new Color32(0, 191, 255, byte.MaxValue),
                shadow = new Color32(0, 0, 205, byte.MaxValue),
                isLighterColor = false
            });
            // 20
            colors.Add(new CustomColor
            {
                longname = "荧光色(MOD)",
                color = new Color32(124, 252, 0, byte.MaxValue),
                shadow = new Color32(0, 255, 0, byte.MaxValue),
                isLighterColor = true
            });
            colors.Add(new CustomColor
            {
                longname = "深橙色(MOD)",
                color = new Color32(238, 180, 34, byte.MaxValue),
                shadow = new Color32(205, 155, 29, byte.MaxValue),
                isLighterColor = false
            });
            colors.Add(new CustomColor
            {
                longname = "浅米色(MOD)",
                color = new Color32(255, 235, 205, byte.MaxValue),
                shadow = new Color32(255, 228, 196, byte.MaxValue),
                isLighterColor = true
            });
            colors.Add(new CustomColor
            {
                longname = "薰衣草色(MOD)",
                color = new Color32(173, 126, 201, byte.MaxValue),
                shadow = new Color32(131, 58, 203, byte.MaxValue),
                isLighterColor = true
            });
            colors.Add(new CustomColor
            {
                longname = "焦糖色(MOD)",
                color = new Color32(160, 101, 56, byte.MaxValue),
                shadow = new Color32(115, 15, 78, byte.MaxValue),
                isLighterColor = false
            });
            // 25
            colors.Add(new CustomColor
            {
                longname = "桃粉色(MOD)",
                color = new Color32(255, 164, 119, byte.MaxValue),
                shadow = new Color32(238, 128, 100, byte.MaxValue),
                isLighterColor = true
            });
            colors.Add(new CustomColor
            {
                longname = "芥末绿(MOD)",
                color = new Color32(112, 143, 46, byte.MaxValue),
                shadow = new Color32(72, 92, 29, byte.MaxValue),
                isLighterColor = false
            });
            colors.Add(new CustomColor
            {
                longname = "热粉色(MOD)",
                color = new Color32(255, 51, 102, byte.MaxValue),
                shadow = new Color32(232, 0, 58, byte.MaxValue),
                isLighterColor = true
            });
            colors.Add(new CustomColor
            {
                longname = "生机绿(MOD)",
                color = new Color32(0, 255, 127, byte.MaxValue),
                shadow = new Color32(0, 205, 102, byte.MaxValue),
                isLighterColor = false
            });
            colors.Add(new CustomColor
            {
                longname = "柠檬色(MOD)",
                color = new Color32(0xDB, 0xFD, 0x2F, byte.MaxValue),
                shadow = new Color32(0x74, 0xE5, 0x10, byte.MaxValue),
                isLighterColor = true
            });
            // 30
            colors.Add(new CustomColor
            {
                longname = "青色(MOD)",
                color = new Color32(0, 245, 255, byte.MaxValue),
                shadow = new Color32(0, 197, 205, byte.MaxValue),
                isLighterColor = true
            });
            colors.Add(new CustomColor
            {
                longname = "海水色(MOD)",
                color = new Color32(135, 206, 250, byte.MaxValue),
                shadow = new Color32(70, 130, 180, byte.MaxValue),
                isLighterColor = true
            });

            colors.Add(new CustomColor
            {
                longname = "蓝紫色(MOD)",
                color = new Color32(61, 44, 142, byte.MaxValue),
                shadow = new Color32(25, 14, 90, byte.MaxValue),
                isLighterColor = false
            });

            colors.Add(new CustomColor
            {
                longname = "朝霞色(MOD)",
                color = new Color32(0xFF, 0xCA, 0x19, byte.MaxValue),
                shadow = new Color32(0xDB, 0x44, 0x42, byte.MaxValue),
                isLighterColor = true
            });
            colors.Add(new CustomColor
            {
                longname = "冰激凌色(MOD)",
                color = new Color32(0xA8, 0xDF, 0xFF, byte.MaxValue),
                shadow = new Color32(0x59, 0x9F, 0xC8, byte.MaxValue),
                isLighterColor = true
            });
            // 35
            colors.Add(new CustomColor
            {
                longname = "紫红色(MOD)", //35 Color Credit: LaikosVK
                color = new Color32(164, 17, 129, byte.MaxValue),
                shadow = new Color32(104, 3, 79, byte.MaxValue),
                isLighterColor = false
            });
            colors.Add(new CustomColor
            {
                longname = "皇家绿色(MOD)", //36
                color = new Color32(9, 82, 33, byte.MaxValue),
                shadow = new Color32(0, 46, 8, byte.MaxValue),
                isLighterColor = false
            });
            colors.Add(new CustomColor
            {
                longname = "珊瑚色(MOD)",
                color = new Color32(255, 106, 106, byte.MaxValue),
                shadow = new Color32(205, 85, 85, byte.MaxValue),
                isLighterColor = false
            });
            colors.Add(new CustomColor
            {
                longname = "深蓝色(MOD)", //38
                color = new Color32(0, 0, 128, byte.MaxValue),
                shadow = new Color32(0, 13, 56, byte.MaxValue),
                isLighterColor = false
            });
            colors.Add(new CustomColor
            {
                longname = "清新绿(MOD)", //39
                color = new Color32(0, 255, 127, byte.MaxValue),
                shadow = new Color32(100, 149, 237, byte.MaxValue),
                isLighterColor = false
            });
            colors.Add(new CustomColor
            {
                longname = "纯白色(MOD)", //40
                color = new Color32(255, 255, 255, byte.MaxValue),
                shadow = new Color32(255, 255, 255, byte.MaxValue),
                isLighterColor = false
            });
            colors.Add(new CustomColor
            {
                longname = "天蓝色(MOD)", //40
                color = new Color32(0, 191, 255, byte.MaxValue),
                shadow = new Color32(30, 144, 255, byte.MaxValue),
                isLighterColor = false
            });
            colors.Add(new CustomColor
            {
                longname = "纯黑色(MOD)", // 41
                color = new Color32(0, 0, 0, byte.MaxValue),
                shadow = new Color32(0, 0, 0, byte.MaxValue),
                isLighterColor = false
            });
            pickableColors += (uint)colors.Count; // Colors to show in Tab
            /** Hidden Colors **/     
                    
            /** Add Colors **/
            int id = 50000;
            foreach (CustomColor cc in colors) {
                longlist.Add((StringNames)id);
                CustomColors.ColorStrings[id++] = cc.longname;
                colorlist.Add(cc.color);
                shadowlist.Add(cc.shadow);
                if (cc.isLighterColor)
                    lighterColors.Add(colorlist.Count - 1);
            }
            

            Palette.ColorNames = longlist.ToArray();
            Palette.PlayerColors = colorlist.ToArray();
            Palette.ShadowColors = shadowlist.ToArray();
        }

        protected internal struct CustomColor {
            public string longname;
            public Color32 color;
            public Color32 shadow;
            public bool isLighterColor;
        }

        [HarmonyPatch]
        public static class CustomColorPatches {
            [HarmonyPatch(typeof(TranslationController), nameof(TranslationController.GetString), new[] {
                typeof(StringNames),
                typeof(Il2CppReferenceArray<Il2CppSystem.Object>)
            })]
            private class ColorStringPatch {
                [HarmonyPriority(Priority.Last)]
                public static bool Prefix(ref string __result, [HarmonyArgument(0)] StringNames name) {
                    if ((int)name >= 50000) {
                        string text = CustomColors.ColorStrings[(int)name];
                        if (text != null) {
                            __result = text;
                            return false;
                        }
                    }
                    return true;
                }
            }

			[HarmonyPatch(typeof(ChatNotification), nameof(ChatNotification.SetUp))]
			private class ChatNotificationColorsPatch
			{
				public static bool Prefix(ChatNotification __instance, PlayerControl sender, string text)
				{
					if (ShipStatus.Instance && !TORMapOptions.ShowChatNotifications)
					{
						return false;
					}
					__instance.timeOnScreen = 5f;
					__instance.gameObject.SetActive(true);
					__instance.SetCosmetics(sender.Data);
					string str;
					Color color;
					try
					{
						str = ColorUtility.ToHtmlStringRGB(Palette.TextColors[__instance.player.ColorId]);
						color = Palette.TextOutlineColors[__instance.player.ColorId];
					}
					catch
					{
						Color32 c = Palette.PlayerColors[__instance.player.ColorId];
						str = ColorUtility.ToHtmlStringRGB(c);

						color = c.r + c.g + c.b > 180 ? Palette.Black : Palette.White;
						TheOtherRolesEditedPlugin.Logger.LogMessage($"{c.r}, {c.g}, {c.b}");
					}
					__instance.playerColorText.text = __instance.player.ColorBlindName;
					__instance.playerNameText.text = "<color=#" + str + ">" + (string.IsNullOrEmpty(sender.Data.PlayerName) ? "..." : sender.Data.PlayerName);
					__instance.playerNameText.outlineColor = color;
					__instance.chatText.text = text;
					return false;
				}
			}

			[HarmonyPatch(typeof(PlayerTab), nameof(PlayerTab.OnEnable))]
            private static class PlayerTabEnablePatch {
                public static void Postfix(PlayerTab __instance) { // Replace instead
                    Il2CppArrayBase<ColorChip> chips = __instance.ColorChips.ToArray();

                    int cols = 7; // TODO: Design an algorithm to dynamically position chips to optimally fill space
                    for (int i = 0; i < ORDER.Count; i++) {
                        int pos = ORDER[i];
                        if (pos < 0 || pos > chips.Length)
                            continue;
                        ColorChip chip = chips[pos];
                        int row = i / cols, col = i % cols; // Dynamically do the positioning
                        chip.transform.localPosition = new Vector3(-0.975f + (col * 0.5f), 1.475f - (row * 0.5f), chip.transform.localPosition.z);
                        chip.transform.localScale *= 0.76f;
                    }
                    for (int j = ORDER.Count; j < chips.Length; j++) { // If number isn't in order, hide it
                        ColorChip chip = chips[j];
                        chip.transform.localScale *= 0f; 
                        chip.enabled = false;
                        chip.Button.enabled = false;
                        chip.Button.OnClick.RemoveAllListeners();
                    }
                }
            }
            [HarmonyPatch(typeof(LegacySaveManager), nameof(LegacySaveManager.LoadPlayerPrefs))]
            private static class LoadPlayerPrefsPatch { // Fix Potential issues with broken colors
                private static bool needsPatch = false;
                public static void Prefix([HarmonyArgument(0)] bool overrideLoad) {
                    if (!LegacySaveManager.loaded || overrideLoad)
                        needsPatch = true;
                }
                public static void Postfix() {
                    if (!needsPatch) return;
                    LegacySaveManager.colorConfig %= CustomColors.pickableColors;
                    needsPatch = false;
                }
            }
            [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.CheckColor))]
            private static class PlayerControlCheckColorPatch {
                private static bool isTaken(PlayerControl player, uint color) {
                    foreach (NetworkedPlayerInfo p in GameData.Instance.AllPlayers.GetFastEnumerator())
                        if (!p.Disconnected && p.PlayerId != player.PlayerId && p.DefaultOutfit.ColorId == color)
                            return true;
                    return false;
                }
                public static bool Prefix(PlayerControl __instance, [HarmonyArgument(0)] byte bodyColor) { // Fix incorrect color assignment
                    uint color = (uint)bodyColor;
                   if (isTaken(__instance, color) || color >= Palette.PlayerColors.Length) {
                        int num = 0;
                        while (num++ < 50 && (color >= CustomColors.pickableColors || isTaken(__instance, color))) {
                            color = (color + 1) % CustomColors.pickableColors;
                        }
                    }
                    __instance.RpcSetColor((byte)color);
                    return false;
                }
            }
        }
    }
}