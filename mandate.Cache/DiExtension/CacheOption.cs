namespace mandate.Cache.DiExtension;

/// <summary>
/// 快取設定參數
/// </summary>
public class CacheOption
{
    /// <summary>
    /// SectionName
    /// </summary>
    public const string SectionName = "Cache";

    /// <summary>
    /// 儲存的持續時間(分鐘)
    /// </summary>
    public int Duration { get; set; }

    /// <summary>
    /// Redis連線字串
    /// </summary>
    /// <remarks>若不使用請設定null或空字串</remarks>
    public string? RedisConnectionString { get; set; }

    /// <summary>
    /// 應用程式名稱
    /// </summary>
    public string? ApplicationName { get; set; }

    /// <summary>
    /// 空間名稱
    /// </summary>
    public string? InstanceName { get; set; }
}