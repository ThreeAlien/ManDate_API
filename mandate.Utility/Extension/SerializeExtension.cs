using mandate.Utility.Extension.JsonConverter;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace mandate.Utility.Extension;

/// <summary>
/// 序列化/反序列化 擴充功能
/// </summary>
public static class SerializeExtension
{
    /// <summary>
    /// 預設Json設定
    /// </summary>
    private readonly static JsonSerializerOptions _serializeOption = new JsonSerializerOptions()
    {
        Converters = { new BoolConverter() },
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip
    };

    public static string ToJson(this object value, JsonSerializerOptions? option = null)
    {
        option ??= _serializeOption;
        return JsonSerializer.Serialize(value, option);
    }

    public static T ToObject<T>(this string value, JsonSerializerOptions? option = null)
    {
        option ??= _serializeOption;
        return JsonSerializer.Deserialize<T>(value, option);
    }
}
