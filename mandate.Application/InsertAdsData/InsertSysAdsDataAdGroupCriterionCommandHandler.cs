using Google.Ads.GoogleAds.V15.Services;
using mandate.Business.Service;
using mandate.Domain.Models.AdsData;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;

namespace mandate.Application.InsertAdsData;

public class InsertSysAdsDataAdGroupCriterionCommandHandler : IRequestHandler<InsertSysAdsDataAdGroupCriterionRequest, InsertSysAdsDataAdGroupCriterionResponse>
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
    public InsertSysAdsDataAdGroupCriterionCommandHandler(IGoogleAdsService googleAdsService, ManDateDBContext context)
    {
        _googleAdsService = googleAdsService;
        _context = context;
    }

    public async Task<InsertSysAdsDataAdGroupCriterionResponse> Handle(InsertSysAdsDataAdGroupCriterionRequest request, CancellationToken cancellationToken)
    {
        InsertSysAdsDataAdGroupCriterionResponse response = new();
        string? refreshToken = await _googleAdsService.GenerateRefreshToken();
        // 1.取得子帳戶
        List<Business.Service.SysClientPo> subAccountList = _googleAdsService.FetchAdsSubAccountApi(refreshToken);

        foreach (Business.Service.SysClientPo subAccount in subAccountList)
        {
            // 3. SysAdsDataAdGroupCriterion
            Google.Protobuf.Collections.RepeatedField<GoogleAdsRow> adGroupCriterionResult = await _googleAdsService.FetchAdsAdGroupCriterion(refreshToken, subAccount.ClientId);
            foreach (GoogleAdsRow googleAdsRow in adGroupCriterionResult)
            {
                try
                {
                    //string AdGroupCriterion = string.IsNullOrEmpty(googleAdsRow.AdGroupCriterion.Keyword.ToString()) ? " " : googleAdsRow.AdGroupCriterion.Keyword.Text.ToString(); 
                    string AdGroupCriterion =
                                        googleAdsRow.AdGroupCriterion.Keyword != null &&
                                        !string.IsNullOrEmpty(googleAdsRow.AdGroupCriterion.Keyword.Text)
                                        ? googleAdsRow.AdGroupCriterion.Keyword.Text
                                        : " ";

                    string AdGroupCriterionAgeRange =
                                        googleAdsRow.AdGroupCriterion.AgeRange != null &&
                                        !string.IsNullOrEmpty(googleAdsRow.AdGroupCriterion.AgeRange.Type.ToString())
                                        ? googleAdsRow.AdGroupCriterion.AgeRange.Type.ToString()
                                        : " ";

                    string AdGroupCriterionGender =
                                        googleAdsRow.AdGroupCriterion.Gender != null &&
                                        !string.IsNullOrEmpty(googleAdsRow.AdGroupCriterion.Gender.Type.ToString())
                                        ? googleAdsRow.AdGroupCriterion.Gender.Type.ToString()
                                        : " ";

                    // 寫入DB SysAdsDataAdGroupCriterion
                    SysAdsDataAdGroupCriterionPo sysAdsDataAdGroupCriterionPo = new()
                    {
                        CustomerID = googleAdsRow.Customer.Id.ToString(),
                        CampaignID = googleAdsRow.Campaign.Id.ToString(),
                        ColSrchKeyWord = AdGroupCriterion,
                        ColAge = AdGroupCriterionAgeRange,
                        ColGender = AdGroupCriterionGender,
                    };
                    _context.SysAdsDataAdGroupCriterion.Add(sysAdsDataAdGroupCriterionPo);
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
