using Google.Ads.GoogleAds.V15.Services;
using mandate.Business.Service;
using mandate.Domain.Models.AdsData;
using mandate.Domain.Po;
using mandate.Infrastructure;
using mandate.Utility.Extension;
using MediatR;

namespace mandate.Application.InsertAdsData;

public class InsertSysAdsDataCampaignCommandHandler : IRequestHandler<InsertSysAdsDataCampaignRequest, InsertSysAdsDataCampaignResponse>
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
    public InsertSysAdsDataCampaignCommandHandler(IGoogleAdsService googleAdsService, ManDateDBContext context)
    {
        _googleAdsService = googleAdsService;
        _context = context;
    }

    public async Task<InsertSysAdsDataCampaignResponse> Handle(InsertSysAdsDataCampaignRequest request, CancellationToken cancellationToken)
    {
        InsertSysAdsDataCampaignResponse response = new();
        string? refreshToken = await _googleAdsService.GenerateRefreshToken();
        // 1.取得子帳戶
        List<Business.Service.SysClientPo> subAccountList = _googleAdsService.FetchAdsAdvertiseAccount(refreshToken);

        foreach (Business.Service.SysClientPo subAccount in subAccountList)
        {
            // 6. AdsDataCampaign
            Google.Protobuf.Collections.RepeatedField<GoogleAdsRow> adsDataCampaignResult = await _googleAdsService.FetchAdsDataCampaignOther(refreshToken, subAccount.ClientId);
            foreach (GoogleAdsRow googleAdsRow in adsDataCampaignResult)
            {
                long customerId = googleAdsRow.Customer.Id;
                string campaignName = googleAdsRow.Campaign.Name;
                //string colConValue = googleAdsRow.Metrics.ConversionsValue.ToString();
                //string ColConByDate = googleAdsRow.Metrics.ConversionsByConversionDate.ToString();
                //string colConPerCost = StringExtension.ToRounding(googleAdsRow.Metrics.CostPerConversion).ToString();

                //string ColCon = googleAdsRow.Metrics.Conversions.ToString();
                //string ColConRate = StringExtension.ToRoundPercentage(googleAdsRow.Metrics.ConversionsFromInteractionsRate);
                string ColClicks = googleAdsRow.Metrics.Clicks.ToString();
                string ColImpressions = googleAdsRow.Metrics.Impressions.ToString();
                string ColCTR = googleAdsRow.Metrics.Ctr.ToString();
                string ColCPC = googleAdsRow.Metrics.AverageCpc.ToString();
                string ColCost = googleAdsRow.Metrics.CostMicros.ToString();
                string ColCPA = googleAdsRow.Metrics.AverageTargetCpaMicros.ToString();
                string ColStartDate = googleAdsRow.Campaign.StartDate;
                string ColEndDate = googleAdsRow.Campaign.EndDate.ToString();
                string ColDate = googleAdsRow.Segments.Date.ToString();
                //寫入DB SysAdsDataCampaign

                try
                {
                    SysAdsDataCampaignPo sysAdsDataCampaignPo = new()
                    {
                        CustomerID = customerId.ToString(),
                        CampaignID = googleAdsRow.Campaign.Id.ToString(),
                        ColCampaignName = campaignName,
                        ColClicks = ColClicks,
                        ColImpressions = ColImpressions,
                        ColCTR = ColCTR,
                        ColCPC = ColCPC,
                        ColCost = ColCost,
                        ColCPA = ColCPA,
                        ColStartDate = ColStartDate,
                        ColEndDate = ColEndDate,
                        ColDate = ColDate,
                    };
                    _context.SysAdsDataCampaign.Add(sysAdsDataCampaignPo);
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
