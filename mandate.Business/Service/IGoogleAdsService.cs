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
    /// 取得Ads Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public void FetchAdsApi(string refreshToken);
}
