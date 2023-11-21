namespace mandate.Business.Service;

/// <summary>
/// Google ADS服務 介面
/// </summary>
public interface IGoogleAdsService
{
    /// <summary>
    /// 產生RefreshToken
    /// </summary>
    /// <returns></returns>
    public Task<string?> GenerateRefreshToken();

    /// <summary>
    /// 取得Ads報表 Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public void FetchAdsReportApi(string refreshToken);

    /// <summary>
    /// 取得Ads帳戶 Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public void FetchAdsAccountApi(string refreshToken);

    public void FetchAdsSubAccountApi(string? refreshToken);
}
