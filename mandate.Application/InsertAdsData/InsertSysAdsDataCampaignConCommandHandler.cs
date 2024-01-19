using Google.Ads.GoogleAds.V15.Services;
using mandate.Business.Service;
using mandate.Domain.Models.AdsData;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;

namespace mandate.Application.InsertAdsData;

public class InsertSysAdsDataCampaignConCommandHandler : IRequestHandler<InsertSysAdsDataCampaignConRequest, InsertSysAdsDataCampaignConResponse>
{
    /// <summary>
    /// Google Ads服務
    /// </summary>
    private readonly IGoogleAdsService _googleAdsService;

    /// <summary>
    /// Db Context
    /// </summary>
    private readonly ManDateDBContext _context;

    /// <summary>
    /// 建構子
    /// </summary>
    public InsertSysAdsDataCampaignConCommandHandler(IGoogleAdsService googleAdsService, ManDateDBContext context)
    {
        _googleAdsService = googleAdsService;
        _context = context;
    }

    public async Task<InsertSysAdsDataCampaignConResponse> Handle(InsertSysAdsDataCampaignConRequest request, CancellationToken cancellationToken)
    {
        InsertSysAdsDataCampaignConResponse response = new();
        string? refreshToken = await _googleAdsService.GenerateRefreshToken();
        // 1.取得子帳戶
        List<Business.Service.SysClientPo> subAccountList = _googleAdsService.FetchAdsSubAccountApi(refreshToken);

        foreach (Business.Service.SysClientPo subAccount in subAccountList)
        {
            // 4. SysAdsDataCampaignCon
            Google.Protobuf.Collections.RepeatedField<GoogleAdsRow> adsDataCampaignConResult = await _googleAdsService.FetchAdsDataCampaignCon(refreshToken, subAccount.ClientId);
            foreach (GoogleAdsRow googleAdsRow in adsDataCampaignConResult)
            {
                // 寫入DB SysAdsDataCampaign
                try
                {
                    // 寫入DB SysAdsDataCampaignCon
                    SysAdsDataCampaignConPo sysAdsDataCriterionConPo = new()
                    {
                        CustomerID = googleAdsRow.Customer.Id.ToString(),
                        CampaignID = googleAdsRow.Campaign.Id.ToString(),
                        ColConGoal = googleAdsRow.CustomConversionGoal.ResourceName
                    };
                    _context.SysAdsDataCampaignCon.Add(sysAdsDataCriterionConPo);
                    await _context.SaveChangesAsync();

                    response = new()
                    {
                        Code = "200",
                        Data = null,
                        Msg = "Success"
                    };
                }
                catch (Exception ex)
                {
                    response = new()
                    {
                        Code = "404",
                        Data = null,
                        Msg = ex.ToString()
                    };
                }
            }
        }
        return response;
    }
}
