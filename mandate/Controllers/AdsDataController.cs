using mandate.Controllers;
using mandate.Domain.Models.AdsData;
using Microsoft.AspNetCore.Mvc;

namespace mandate.api.Controllers;

public class AdsDataController : BaseApiController
{
    /// <summary>
    /// 取得Ads資料
    /// </summary>
    [HttpPost]
    public Task<GetSysAdsDataResponse> GetSysAdsData(GetSysAdsDataRequest request) => Mediator!.Send(request);

    /// <summary>
    /// 取得Ads帳戶(權限管理用)
    /// </summary>
    [HttpPost]
    public Task<GetAdsAccountResponse> GetAdsAccount(GetAdsAccountRequest request) => Mediator!.Send(request);
}
