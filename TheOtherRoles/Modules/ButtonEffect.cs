using System.Collections.Generic;
using UnityEngine;

namespace TheOtherRolesEdited.Modules
{
    public static class ButtonEffect
    {
        public class KeyCodeInfo
        {
            public static string GetKeyDisplayName(KeyCode keyCode)
            {
                if (keyCode == KeyCode.Return)
                    return "Return";
                if (AllKeyInfo.TryGetValue(keyCode, out var val)) return val.TranslationKey;
                return null;
            }

            static public Dictionary<KeyCode, KeyCodeInfo> AllKeyInfo = new();
            public KeyCode keyCode { get; private set; }
            public DividedSpriteLoader textureHolder { get; private set; }
            public int num { get; private set; }
            public string TranslationKey { get; private set; }
            public KeyCodeInfo(KeyCode keyCode, string translationKey, DividedSpriteLoader spriteLoader, int num)
            {
                this.keyCode = keyCode;
                this.TranslationKey = translationKey;
                this.textureHolder = spriteLoader;
                this.num = num;

                AllKeyInfo.Add(keyCode, this);
            }

            public Sprite Sprite => textureHolder.GetSprite(num);

            static KeyCodeInfo()
            {
                DividedSpriteLoader spriteLoader;
                spriteLoader = DividedSpriteLoader.FromResource("TheOtherRolesEdited.Resources.Key.KeyBindCharacters0.png", 100f, 18, 19, true);
                new KeyCodeInfo(KeyCode.Tab, "Tab", spriteLoader, 0);
                new KeyCodeInfo(KeyCode.Space, "Space", spriteLoader, 1);
                new KeyCodeInfo(KeyCode.Comma, "<", spriteLoader, 2);
                new KeyCodeInfo(KeyCode.Period, ">", spriteLoader, 3);
                spriteLoader = DividedSpriteLoader.FromResource("TheOtherRolesEdited.Resources.Key.KeyBindCharacters1.png", 100f, 18, 19, true);
                for (KeyCode key = KeyCode.A; key <= KeyCode.Z; key++)
                    new KeyCodeInfo(key, ((char)('A' + key - KeyCode.A)).ToString(), spriteLoader, key - KeyCode.A);
                spriteLoader = DividedSpriteLoader.FromResource("TheOtherRolesEdited.Resources.Key.KeyBindCharacters2.png", 100f, 18, 19, true);
                for (int i = 0; i < 15; i++)
                    new KeyCodeInfo(KeyCode.F1 + i, "F" + (i + 1), spriteLoader, i);
                spriteLoader = DividedSpriteLoader.FromResource("TheOtherRolesEdited.Resources.Key.KeyBindCharacters3.png", 100f, 18, 19, true);
                new KeyCodeInfo(KeyCode.RightShift, "RShift", spriteLoader, 0);
                new KeyCodeInfo(KeyCode.LeftShift, "LShift", spriteLoader, 1);
                new KeyCodeInfo(KeyCode.RightControl, "RControl", spriteLoader, 2);
                new KeyCodeInfo(KeyCode.LeftControl, "LControl", spriteLoader, 3);
                new KeyCodeInfo(KeyCode.RightAlt, "RAlt", spriteLoader, 4);
                new KeyCodeInfo(KeyCode.LeftAlt, "LAlt", spriteLoader, 5);
                spriteLoader = DividedSpriteLoader.FromResource("TheOtherRolesEdited.Resources.Key.KeyBindCharacters4.png", 100f, 18, 19, true);
                for (int i = 0; i < 6; i++)
                    new KeyCodeInfo(KeyCode.Mouse1 + i, "Mouse " + (i == 0 ? "Right" : i == 1 ? "Middle" : (i + 1).ToString()), spriteLoader, i);
                spriteLoader = DividedSpriteLoader.FromResource("TheOtherRolesEdited.Resources.Key.KeyBindCharacters5.png", 100f, 18, 19, true);
                for (int i = 0; i < 10; i++)
                    new KeyCodeInfo(KeyCode.Alpha0 + i, "0" + (i + 1), spriteLoader, i);
            }
        }

        static Image keyBindBackgroundSprite = SpriteLoader.FromResource("TheOtherRolesEdited.Resources.Key.KeyBindBackground.png", 100f);
        static Image mouseDisableActionSprite = SpriteLoader.FromResource("TheOtherRolesEdited.Resources.Key.MouseActionDisableIcon.png", 100f);

        static public GameObject AddKeyGuide(GameObject button, KeyCode key, UnityEngine.Vector2 pos, bool removeExistingGuide, string action = null)
        {
            if (removeExistingGuide) button.gameObject.ForEachChild((Il2CppSystem.Action<GameObject>)(obj => { if (obj.name == "HotKeyGuide") GameObject.Destroy(obj); }));

            Sprite numSprite = null;
            if (KeyCodeInfo.AllKeyInfo.ContainsKey(key)) numSprite = KeyCodeInfo.AllKeyInfo[key].Sprite;
            if (numSprite == null) return null;

            GameObject obj = new();
            obj.name = "HotKeyGuide";
            obj.transform.SetParent(button.transform);
            obj.layer = button.layer;
            SpriteRenderer renderer = obj.AddComponent<SpriteRenderer>();
            renderer.transform.localPosition = (UnityEngine.Vector3)pos + new UnityEngine.Vector3(0f, 0f, -10f);
            renderer.sprite = keyBindBackgroundSprite.GetSprite();

            GameObject numObj = new();
            numObj.name = "HotKeyText";
            numObj.transform.SetParent(obj.transform);
            numObj.layer = button.layer;
            renderer = numObj.AddComponent<SpriteRenderer>();
            renderer.transform.localPosition = new(0, 0, -1f);
            renderer.sprite = numSprite;

            return obj;
        }

        static public GameObject SetKeyGuide(GameObject button, KeyCode key, bool removeExistingGuide = true, string action = null)
        {
            return AddKeyGuide(button, key, new(0.48f, 0.48f), removeExistingGuide, action: action);
        }
        public class XOnlyDividedSpriteLoader : Image, IDividedSpriteLoader
        {
            float pixelsPerUnit;
            Sprite[] sprites;
            ITextureLoader texture;
            int? division, size;
            public Vector2 Pivot = new(0.5f, 0.5f);

            public XOnlyDividedSpriteLoader(ITextureLoader textureLoader, float pixelsPerUnit, int x, bool isSize = false)
            {
                this.pixelsPerUnit = pixelsPerUnit;
                if (isSize)
                {
                    this.size = x;
                    this.division = null;
                }
                else
                {
                    this.division = x;
                    this.size = null;
                }
                sprites = null!;
                texture = textureLoader;
            }

            public Sprite GetSprite(int index)
            {
                if (!size.HasValue || !division.HasValue || sprites == null)
                {
                    var texture2D = texture.GetTexture();
                    if (size == null)
                        size = texture2D.width / division;
                    else if (division == null)
                        division = texture2D.width / size!;
                    sprites = new Sprite[division!.Value];
                }

                if (!sprites[index])
                {
                    var texture2D = texture.GetTexture();
                    sprites[index] = texture2D.ToSprite(new Rect(index * size!.Value, 0, size!.Value, texture2D.height), Pivot, pixelsPerUnit);
                }
                return sprites[index];
            }

            public Sprite GetSprite() => GetSprite(0);

            public int Length
            {
                get
                {
                    if (!division.HasValue) GetSprite(0);
                    return division!.Value;
                }
            }

            public Image WrapLoader(int index) => new WrapSpriteLoader(() => GetSprite(index));

            static public XOnlyDividedSpriteLoader FromResource(string address, float pixelsPerUnit, int x, bool isSize = false)
                 => new(new ResourceTextureLoader(address), pixelsPerUnit, x, isSize);
            static public XOnlyDividedSpriteLoader FromDisk(string address, float pixelsPerUnit, int x, bool isSize = false)
                 => new(new DiskTextureLoader(address), pixelsPerUnit, x, isSize);
        }

        public interface IDividedSpriteLoader
        {
            Sprite GetSprite(int index);
            Image AsLoader(int index) => new WrapSpriteLoader(() => GetSprite(index));
            int Length { get; }
        }
        private static IDividedSpriteLoader textureUsesIconsSprite = XOnlyDividedSpriteLoader.FromResource("TheOtherRolesEdited.Resources.Key.UsesIcon.png", 120f, 10);

        static public GameObject ShowUsesIcon(this ActionButton button)
        {
            Transform template = HudManager.Instance.AbilityButton.transform.GetChild(2);
            var usesObject = UnityEngine.Object.Instantiate(template.gameObject);
            usesObject.transform.SetParent(button.gameObject.transform);
            usesObject.transform.localScale = template.localScale;
            usesObject.transform.localPosition = template.localPosition * 1.2f;
            return usesObject;
        }

        static public GameObject ShowUsesIcon(this ActionButton button, int iconVariation, out TMPro.TextMeshPro text)
        {
            GameObject result = ShowUsesIcon(button);
            var renderer = result.GetComponent<SpriteRenderer>();
            renderer.sprite = textureUsesIconsSprite.GetSprite(iconVariation);
            text = result.transform.GetChild(0).GetComponent<TMPro.TextMeshPro>();
            text.transform.localScale *= 0.85f;
            text.transform.SetLocalY(text.transform.localPosition.y - 0.01f);
            return result;
        }

        static public void ShowVanillaKeyGuide(this HudManager manager)
        {
            if (manager == null) return;

            //ボタンのガイドを表示
            var keyboardMap = Rewired.ReInput.mapping.GetKeyboardMapInstanceSavedOrDefault(0, 0, 0);
            Il2CppReferenceArray<Rewired.ActionElementMap> actionArray;
            Rewired.ActionElementMap actionMap;

            //マップ
            actionArray = keyboardMap.GetButtonMapsWithAction(4);
            if (actionArray.Count > 0)
            {
                actionMap = actionArray[0];
                SetKeyGuide(manager.SabotageButton.gameObject, actionMap.keyCode);
            }

            //使用
            actionArray = keyboardMap.GetButtonMapsWithAction(6);
            if (actionArray.Count > 0)
            {
                actionMap = actionArray[0];
                SetKeyGuide(manager.UseButton.gameObject, actionMap.keyCode);
                SetKeyGuide(manager.PetButton.gameObject, actionMap.keyCode);
            }

            //レポート
            actionArray = keyboardMap.GetButtonMapsWithAction(7);
            if (actionArray.Count > 0)
            {
                actionMap = actionArray[0];
                SetKeyGuide(manager.ReportButton.gameObject, actionMap.keyCode);
            }

            //キル
            actionArray = keyboardMap.GetButtonMapsWithAction(8);
            if (actionArray.Count > 0)
            {
                actionMap = actionArray[0];
                SetKeyGuide(manager.KillButton.gameObject, actionMap.keyCode);
            }

            //ベント
            actionArray = keyboardMap.GetButtonMapsWithAction(50);
            if (actionArray.Count > 0)
            {
                actionMap = actionArray[0];
                SetKeyGuide(manager.ImpostorVentButton.gameObject, actionMap.keyCode);
            }
        }
    }
}
