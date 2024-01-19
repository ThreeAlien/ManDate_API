using Google.Ads.GoogleAds.V15.Services;
using mandate.Business.Service;
using mandate.Domain.Models.AdsData;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;

namespace mandate.Application.InsertAdsData;

public class InsertSysAdsDataCampaignActionCommandHandler : IRequestHandler<InsertSysAdsDataCampaignActionRequest, InsertSysAdsDataCampaignActionResponse>
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
    public InsertSysAdsDataCampaignActionCommandHandler(IGoogleAdsService googleAdsService, ManDateDBContext context)
    {
        _googleAdsService = googleAdsService;
        _context = context;
    }

    public async Task<InsertSysAdsDataCampaignActionResponse> Handle(InsertSysAdsDataCampaignActionRequest request, CancellationToken cancellationToken)
    {
        InsertSysAdsDataCampaignActionResponse response = new();
        string? refreshToken = await _googleAdsService.GenerateRefreshToken();
        // 1.取得子帳戶
        List<Business.Service.SysClientPo> subAccountList = _googleAdsService.FetchAdsSubAccountApi(refreshToken);

        foreach (Business.Service.SysClientPo subAccount in subAccountList)
        {
            // 2. SysAdsDataCampaignAction
            Google.Protobuf.Collections.RepeatedField<GoogleAdsRow> adsCampaignActionResult = await _googleAdsService.FetchAdsCampaignAction(refreshToken, subAccount.ClientId);
            foreach (GoogleAdsRow googleAdsRow in adsCampaignActionResult)
            {
                try
                {
                    long CustomerID = googleAdsRow.Customer.Id;
                    string ColConAction = googleAdsRow.ConversionAction.Name;
                    // 寫入DB SysAdsDataCampaignAction
                    SysAdsDataCampaignActionPo sysAdsDataCampaignActionPo = new()
                    {
                        CustomerID = CustomerID.ToString(),
                        CampaignID = googleAdsRow.Campaign.Id.ToString(),
                        ColConAction = ColConAction,
                    };
                    _context.SysAdsDataCampaignAction.Add(sysAdsDataCampaignActionPo);
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
