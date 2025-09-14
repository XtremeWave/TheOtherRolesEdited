using System.Collections.Generic;
using System.Linq;

namespace TheOtherRolesEdited.Modules;

public class DevUser
{
    public string Code { get; set; }
    public string Color { get; set; }
    public string Tag { get; set; }
    public bool IsUp { get; set; }
    public bool IsDev { get; set; }
    public bool DeBug { get; set; }
    public string UpName { get; set; }
    public DevUser(string code = "", string color = "null", string tag = "null")
    {
        Code = code;
        Color = color;
        Tag = tag;

    }
    public bool HasTag() => Tag != "null";
    public string GetTag() => Color == "null" ? $"<size=1.7>{Tag}</size>\r\n" : $"<color={Color}><size=1.7>{(Tag)}</size></color>\r\n";
}

public static class DevManager
{
    public static DevUser DefaultDevUser = new();
    public static List<DevUser> DevUserList = new();
    public static void Init()
    {
        DevUserList.Add(new(code: "gridunable#5279", color: "#00BFFF", tag: $"{ModTranslation.getString("Dev")}"));//毒液
        DevUserList.Add(new(code: "dazedkiosk#9538", color: "#00FFFF", tag: $"{ModTranslation.getString("Dev")}||{ModTranslation.getString("ServerHost")}"));//方块
        DevUserList.Add(new(code: "aideproof#8388", color: "#00FFFF", tag: $"{ModTranslation.getString("Con")}||毒液npy"));//Elinmei
        DevUserList.Add(new(code: "adoswish#5144", color: "#FF44FF", tag: $"{ModTranslation.getString("Tester")}"));//汪泽宇
        DevUserList.Add(new(code: "heappotted#1406", color: "#ffff67", tag: $"{ModTranslation.getString("Art")}"));//汪泽宇
        DevUserList.Add(new(code: "squishyhod#5187", color: "#FF44FF", tag: $"哈哈哥[测逝圆]"));//哈哈哥
        //  空白的例子   DevUserList.Add(new(code: "xxxxxx#0000", color: "#000000", tag: ""));
    }
    public static bool IsDevUser(this string code) => DevUserList.Any(x => x.Code == code);
    public static DevUser GetDevUser(this string code) => code.IsDevUser() ? DevUserList.Find(x => x.Code == code) : DefaultDevUser;
}