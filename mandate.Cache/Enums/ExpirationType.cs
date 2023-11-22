namespace mandate.Cache.Enums;

/// <summary>
/// 時效性類型
/// </summary>
public enum ExpirationType
{
    /// <summary>
    /// 指定時常內未使用時回收快取
    /// </summary>
    SlidingExpiration,

    /// <summary>
    /// 指定時間後回收快取
    /// </summary>
    AbsoluteExpiration,

    /// <summary>
    /// 相對現在時間的指定時長後回收快取
    /// </summary>
    AbsoluteExpirationRelativeToNow
}