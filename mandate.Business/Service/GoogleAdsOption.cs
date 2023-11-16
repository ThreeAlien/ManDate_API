namespace mandate.Business.Service;

/// <summary>
/// GoogleAds 設定檔
/// </summary>
public class GoogleAdsOption
{
    /// <summary>
    /// SectionName
    /// </summary>
    public const string SectionName = "GoogleAds";

    /// <summary>
    /// DeveloperToken
    /// </summary>
    public string DeveloperToken { get; set; } = null!;

    /// <summary>
    /// ClientId
    /// </summary>
    public string ClientId { get; set; } = null!;

    /// <summary>
    /// ClientSecret
    /// </summary>
    public string ClientSecret { get; set; } = null!;

    /// <summary>
    /// Scope
    /// </summary>
    public string? Scope { get; set; }

    /// <summary>
    /// LoginCustomerId
    /// </summary>
    public string? LoginCustomerId { get; set; }
}
