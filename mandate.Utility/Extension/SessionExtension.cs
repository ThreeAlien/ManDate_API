using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace mandate.Utility.Extension;

/// <summary>
/// Session 擴充功能
/// </summary>
public static class SessionExtension
{
    /// <summary>
    /// 存Session
    /// </summary>
    /// <param name="session"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void Set(this ISession session, string key, string value)
    {
        session.Set(key, JsonSerializer.SerializeToUtf8Bytes(value));
    }

    /// <summary>
    /// 取Session
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="session"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static T Get<T>(this ISession session, string key)
    {
        session.TryGetValue(key, out byte[]? sessionValue);
        return key == null ? default(T) :
            JsonSerializer.Deserialize<T>(sessionValue);
    }
}