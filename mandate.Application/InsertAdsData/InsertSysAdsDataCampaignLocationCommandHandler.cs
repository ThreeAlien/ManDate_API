using Google.Ads.GoogleAds.V15.Services;
using mandate.Business.Service;
using mandate.Domain.Models.AdsData;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;

namespace mandate.Application.InsertAdsData;

public class InsertSysAdsDataCampaignLocationCommandHandler : IRequestHandler<InsertSysAdsDataCampaignLocationRequest, InsertSysAdsDataCampaignLocationResponse>
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
    public InsertSysAdsDataCampaignLocationCommandHandler(IGoogleAdsService googleAdsService, ManDateDBContext context)
    {
        _googleAdsService = googleAdsService;
        _context = context;
    }

    public async Task<InsertSysAdsDataCampaignLocationResponse> Handle(InsertSysAdsDataCampaignLocationRequest request, CancellationToken cancellationToken)
    {
        InsertSysAdsDataCampaignLocationResponse response = new();
        string? refreshToken = await _googleAdsService.GenerateRefreshToken();
        // 1.取得子帳戶
        List<Business.Service.SysClientPo> subAccountList = _googleAdsService.FetchAdsAdvertiseAccount(refreshToken);

        foreach (Business.Service.SysClientPo subAccount in subAccountList)
        {
            // 4. SysAdsDataCampaignLocation
            Google.Protobuf.Collections.RepeatedField<GoogleAdsRow> adsDataCampaignLocationResult = await _googleAdsService.FetchAdsDataCampaignLocation(refreshToken, subAccount.ClientId);
            foreach (GoogleAdsRow googleAdsRow in adsDataCampaignLocationResult)
            {
                // 寫入DB SysAdsDataCampaignLocation
                try
                {

                    string Constant =
                        googleAdsRow?.CampaignCriterion?.Location?.GeoTargetConstant?.ToString() ?? " ";

                    // 寫入DB SysAdsDataCampaignLocation
                    SysAdsDataCampaignLocationPo SysAdsDataCampaignLocationPo = new()
                    {
                        CustomerID = googleAdsRow.Customer.Id.ToString(),
                        CampaignID = googleAdsRow.Campaign.Id.ToString(),
                        ColConstant = Constant
                    };
                    _context.SysAdsDataCampaignLocation.Add(SysAdsDataCampaignLocationPo);
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
