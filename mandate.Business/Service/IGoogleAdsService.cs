using Google.Ads.GoogleAds.V15.Services;
using mandate.Business.Models;

namespace mandate.Business.Service;

/// <summary>
/// Google ADS服務 介面
/// </summary>
public interface IGoogleAdsService
{
    public Task<string?> AuthorizeCallBack(string code);

    /// <summary>
    /// 產生RefreshToken
    /// </summary>
    /// <returns></returns>
    public Task<string?> GenerateRefreshToken();

    /// <summary>
    /// 取得AdsDataCampaign報表 Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public Task<Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>> FetchAdsDataCampaign(string refreshToken, string custId);

    /// <summary>
    /// 取得AdsDataCampaign報表 Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public Task<Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>> FetchAdsDataCampaignOther(string refreshToken, string custId);

    /// <summary>
    /// 取得AdsDataAdGroupAd報表 Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public Task<Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>> FetchAdsDataAdGroupAd(string refreshToken, string custId);

    /// <summary>
    /// 取得CampaignAction報表 Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public Task<Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>> FetchAdsCampaignAction(string refreshToken, string custId);

    /// <summary>
    /// 取得AdGroupCriterion報表 Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public Task<Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>> FetchAdsAdGroupCriterion(string refreshToken, string custId);

    /// <summary>
    /// 取得AdsDataCampaignCon報表 Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public Task<Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>> FetchAdsDataCampaignCon(string refreshToken, string custId);

    /// <summary>
    /// 取得AdsDataCampaignLocation報表 Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public Task<Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>> FetchAdsDataCampaignLocation(string refreshToken, string custId);


    /// <summary>
    /// 取得Ads帳戶 Api
    /// </summary>
    /// <param name="refreshToken"></param>
    public string[]? FetchAdsAccountApi(string refreshToken);

    /// <summary>
    /// 取得權限
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <param name="custId"></param>
    /// <returns></returns>
    public List<GetAccessRoleResult> AccessRole(string refreshToken, string custId);

    /// <summary>
    /// 取得廣告帳戶 Api
    /// </summary>
    public List<SysClientPo> FetchAdsAdvertiseAccount(string? refreshToken);

    /// <summary>
    /// 取得Ads子帳戶 Api
    /// </summary>
    public List<SysClientPo> FetchAdsSubAccountApi(string? refreshToken);

    /// <summary>
    /// 取得性別
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <param name="custId"></param>
    /// <returns>請依不同查詢條件更換Query</returns>
    public Task<Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>> FetchAdsCommonData(string refreshToken, string custId, string queryType);

    /// <summary>
    /// 取得年齡
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <param name="custId"></param>
    /// <returns>請依不同查詢條件更換Query</returns>
    public Task<Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>> FetchAdsAgeData(string refreshToken, string custId);

    /// <summary>
    /// 取得搜尋關鍵字
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <param name="custId"></param>
    /// <returns>請依不同查詢條件更換Query</returns>
    public Task<Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>> FetchAdsKeyWordData(string refreshToken, string custId);

    /// <summary>
    /// 取得地區
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <param name="custId"></param>
    /// <returns>請依不同查詢條件更換Query</returns>
    public Task<Google.Protobuf.Collections.RepeatedField<GoogleAdsRow>> FetchAdsLocationData(string refreshToken, string custId);
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
