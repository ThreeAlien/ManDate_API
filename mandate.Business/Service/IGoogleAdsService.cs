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

    /// <summary>
    /// 取得Ads子帳戶 Api
    /// </summary>
    public List<SysClientPo> FetchAdsSubAccountApi(string? refreshToken);
}

#region 汎古的客戶資料
public class SysClientPo
{
    /// <summary>
    /// 待註解
    /// </summary>
    public long ClientNo { get; set; }

    /// <summary>
    /// 客戶ID
    /// </summary>
    public string? ClientId { get; set; }

    /// <summary>
    /// 客戶名稱
    /// </summary>
    public string? ClientName { get; set; }
}
#endregion
