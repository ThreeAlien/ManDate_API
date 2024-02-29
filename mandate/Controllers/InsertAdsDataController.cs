using mandate.Controllers;
using mandate.Domain.Models.AdsData;
using Microsoft.AspNetCore.Mvc;

namespace mandate.api.Controllers;

public class InsertAdsDataController : BaseApiController
{
    /// <summary>
    /// InsertSysAdsDataCampaignAction
    /// </summary>
    [HttpPost]
    public Task<InsertSysAdsDataCampaignActionResponse> InsertSysAdsDataCampaignAction() => Mediator!.Send(new InsertSysAdsDataCampaignActionRequest());

    /// <summary>
    /// InsertSysAdsDataAdGroupCriterion
    /// </summary>
    [HttpPost]
    public Task<InsertSysAdsDataAdGroupCriterionResponse> InsertSysAdsDataAdGroupCriterion() => Mediator!.Send(new InsertSysAdsDataAdGroupCriterionRequest());

    /// <summary>
    /// InsertSysAdsDataCampaignCon
    /// </summary>
    [HttpPost]
    public Task<InsertSysAdsDataCampaignConResponse> InsertSysAdsDataCampaignCon() => Mediator!.Send(new InsertSysAdsDataCampaignConRequest());

    /// <summary>
    /// InsertSysAdsDataCampaignLocation
    /// </summary>
    [HttpPost]
    public Task<InsertSysAdsDataCampaignLocationResponse> InsertSysAdsDataCampaignLocation() => Mediator!.Send(new InsertSysAdsDataCampaignLocationRequest());

    /// <summary>
    /// InsertSysAdsDataCampaign
    /// </summary>
    [HttpPost]
    public Task<InsertSysAdsDataCampaignResponse> InsertSysAdsDataCampaign() => Mediator!.Send(new InsertSysAdsDataCampaignRequest());

    /// <summary>
    /// InsertSysAdsDataCampaign
    /// </summary>
    [HttpPost]
    public Task<InsertSysAdsDataCampaignOtherResponse> InsertSysAdsDataCampaignOther() => Mediator!.Send(new InsertSysAdsDataCampaignOtherRequest());

    /// <summary>
    /// InsertSysAdsDataAdGroupAd
    /// </summary>
    [HttpPost]
    public Task<InsertSysAdsDataAdGroupAdResponse> InsertSysAdsDataAdGroupAd() => Mediator!.Send(new InsertSysAdsDataAdGroupAdRequest());
}
