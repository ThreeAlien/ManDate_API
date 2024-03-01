using Google.Ads.GoogleAds.V15.Services;
using mandate.Business.Service;
using mandate.Domain.Models.AdsData;
using mandate.Domain.Po;
using mandate.Infrastructure;
using mandate.Utility.Extension;
using MediatR;

namespace mandate.Application.InsertAdsData;

public class InsertSysAdsDataCampaignOtherCommandHandler : IRequestHandler<InsertSysAdsDataCampaignOtherRequest, InsertSysAdsDataCampaignOtherResponse>
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
    public InsertSysAdsDataCampaignOtherCommandHandler(IGoogleAdsService googleAdsService, ManDateDBContext context)
    {
        _googleAdsService = googleAdsService;
        _context = context;
    }

    public async Task<InsertSysAdsDataCampaignOtherResponse> Handle(InsertSysAdsDataCampaignOtherRequest request, CancellationToken cancellationToken)
    {
        InsertSysAdsDataCampaignOtherResponse response = new();
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
                string ColConValue = googleAdsRow.Metrics.ConversionsValue.ToString();
                string ColConByDate = googleAdsRow.Metrics.ConversionsByConversionDate.ToString();
                string ColConPerCost = StringExtension.ToRounding(googleAdsRow.Metrics.CostPerConversion).ToString();

                string ColCon = googleAdsRow.Metrics.Conversions.ToString();
                string ColConRate = StringExtension.ToRoundPercentage(googleAdsRow.Metrics.ConversionsFromInteractionsRate);

                //寫入DB SysAdsDataCampaign

                try
                {
                    SysAdsDataCampaignConversionPo sysAdsDataCampaignOtherPo = new()
                    {
                        CustomerID = customerId.ToString(),
                        CampaignID = googleAdsRow.Campaign.Id.ToString(),
                        ColCampaignName = campaignName,
                        ColConValue = ColConValue,
                        ColConByDate = ColConByDate,
                        ColConPerCost = ColConPerCost,
                        ColCon = ColCon,
                        ColConRate = ColConRate,

                    };
                    _context.SysAdsDataCampaignConversion.Add(sysAdsDataCampaignOtherPo);
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
