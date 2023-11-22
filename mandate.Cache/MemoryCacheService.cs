using mandate.Cache.DiExtension;
using mandate.Cache.Enums;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace mandate.Cache;

/// <summary>
/// 本機MemoryCacheService
/// </summary>
public class MemoryCacheService : ICacheService
{
    /// <summary>
    /// 快取設定參數
    /// </summary>
    private CacheOption _cacheOption;

    /// <summary>
    /// 儲存目標
    /// </summary>
    private readonly IMemoryCache _memoryCache;

    /// <summary>
    /// 建構子
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="memoryCache"></param>
    public MemoryCacheService(IConfiguration configuration, IMemoryCache memoryCache)
    {
        _cacheOption = configuration.GetSection(CacheOption.SectionName).Get<CacheOption>();
        _memoryCache = memoryCache;
    }

    /// <summary>
    /// 讀取資料
    /// </summary>
    /// <typeparam name="T">鍵值型別</typeparam>
    /// <param name="key">鍵</param>
    /// <returns></returns>
    public Task<T> GetValue<T>(string key)
    {
        bool result = _memoryCache.TryGetValue(key, out T cacheValue);
        return Task.FromResult(cacheValue);
    }

    /// <summary>
    /// 設定資料
    /// </summary>
    /// <typeparam name="T">鍵值類別</typeparam>
    /// <param name="key">鍵</param>
    /// <param name="value">值</param>
    /// <param name="expirationTime">有效時間</param>
    /// <param name="expirationType">時效性類型</param>
    /// <returns></returns>
    public Task SetValue<T>(string key, T value, TimeSpan? expirationTime = null, ExpirationType expirationType = ExpirationType.SlidingExpiration)
    {
        expirationTime ??= new TimeSpan(0, _cacheOption.Duration, 0);
        MemoryCacheEntryOptions options = expirationType switch
        {
            ExpirationType.SlidingExpiration => new() { SlidingExpiration = expirationTime },
            ExpirationType.AbsoluteExpiration => new() { AbsoluteExpiration = new DateTime(expirationTime.Value.Ticks) },
            ExpirationType.AbsoluteExpirationRelativeToNow => new() { AbsoluteExpirationRelativeToNow = expirationTime },
            _ => new() { SlidingExpiration = expirationTime }
        };
        _memoryCache.Set<T>(key, value, options);
        return Task.CompletedTask;
    }

    /// <summary>
    /// 清除資料
    /// </summary>
    /// <param name="key">鍵</param>
    /// <returns></returns>
    public Task ClearValue(string key)
    {
        _memoryCache.Remove(key);
        return Task.CompletedTask;
    }
}