using mandate.Cache.Enums;

namespace mandate.Cache;

/// <summary>
/// 快取相關服務 介面
/// </summary>
public interface ICacheService
{
    /// <summary>
    /// 讀取資料
    /// </summary>
    /// <typeparam name="T">鍵值型別</typeparam>
    /// <param name="key">鍵</param>
    /// <returns></returns>
    public Task<T> GetValue<T>(string key);

    /// <summary>
    /// 設定資料
    /// </summary>
    /// <typeparam name="T">鍵值類別</typeparam>
    /// <param name="key">鍵</param>
    /// <param name="value">值</param>
    /// <param name="expirationTime">有效時間</param>
    /// <param name="expirationType">時效性類型</param>
    /// <returns></returns>
    public Task SetValue<T>(string key, T value, TimeSpan? expirationTime = null, ExpirationType expirationType = ExpirationType.SlidingExpiration);

    /// <summary>
    /// 清除資料
    /// </summary>
    /// <param name="key">鍵</param>
    /// <returns></returns>
    public Task ClearValue(string key);
}