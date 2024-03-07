using Google.Ads.GoogleAds.V15.Services;
using mandate.Business.Service;
using mandate.Domain.Models.AdsData;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace mandate.Application.InsertAdsData;

/// <summary>
/// Insert age、gender、keyWord、location 資料 CommandHandler
/// </summary>
public class InsertSysAdsCommonDataCommandHandler : IRequestHandler<InsertSysAdsCommonDataRequest, InsertSysAdsCommonDataResponse>
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
    public InsertSysAdsCommonDataCommandHandler(IGoogleAdsService googleAdsService, ManDateDBContext context)
    {
        _googleAdsService = googleAdsService;
        _context = context;
    }

    public async Task<InsertSysAdsCommonDataResponse> Handle(InsertSysAdsCommonDataRequest request, CancellationToken cancellationToken)
    {
        InsertSysAdsCommonDataResponse response = new();
        string[] requestLimit = { "age", "gender", "keyWord", "location" };
        if (string.IsNullOrEmpty(request.QueryType) || !requestLimit.Contains(request.QueryType))
        {
            return response = new()
            {
                Code = "404",
                Data = null,
                Msg = "QueryType請輸入age、gender、keyWord、location其中一個！"
            };
        }
        string? refreshToken = await _googleAdsService.GenerateRefreshToken();
        // 1.取得子帳戶
        List<Business.Service.SysClientPo> subAccountList = _googleAdsService.FetchAdsAdvertiseAccount(refreshToken);

        foreach (Business.Service.SysClientPo subAccount in subAccountList)
        {
            // GetAdsCommonData
            Google.Protobuf.Collections.RepeatedField<GoogleAdsRow> adsDataAdGroupAdResult = await _googleAdsService.FetchAdsCommonData(refreshToken, subAccount.ClientId, request.QueryType);
            foreach (GoogleAdsRow googleAdsRow in adsDataAdGroupAdResult)
            {
                try
                {
                    switch (request.QueryType)
                    {
                        case "age":
                            InsertAgeData(googleAdsRow);
                            break;
                        case "gender":
                            InsertGenderData(googleAdsRow);
                            break;
                        case "keyWord":
                            InsertKeyWordData(googleAdsRow);
                            break;
                        case "location":
                            InsertLocationData(googleAdsRow);
                            break;
                    }

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

    /// <summary>
    /// 寫入年齡資料
    /// </summary>
    /// <param name="googleAdsRow"></param>
    private async void InsertAgeData(GoogleAdsRow googleAdsRow)
    {
        SysAdsDataAgeViewPo sysAdsDataAgeViewPo = new()
        {
            CustomerID = googleAdsRow.Customer.Id.ToString(),
            CampaignID = googleAdsRow.Campaign.Id.ToString(),
            ColAge = googleAdsRow.AdGroupCriterion.AgeRange.Type.ToString(),
            ColCampaignName = googleAdsRow.Campaign.Name,
            ColAdGroupName = googleAdsRow.AdGroup.Name,
            ColClicks = googleAdsRow.Metrics.Clicks.ToString(),
            ColImpressions = googleAdsRow.Metrics.Impressions.ToString(),
            ColCTR = googleAdsRow.Metrics.Ctr.ToString(),
            ColCPC = googleAdsRow.Metrics.AverageCpc.ToString(),
            ColCost = googleAdsRow.Metrics.CostMicros.ToString(),
            ColDate = googleAdsRow.Segments.Date.ToString(),
        };
        _context.SysAdsDataAgeView.Add(sysAdsDataAgeViewPo);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// 寫入性別資料
    /// </summary>
    /// <param name="googleAdsRow"></param>
    private async void InsertGenderData(GoogleAdsRow googleAdsRow)
    {
        SysAdsDataGenderViewPo sysAdsDataGenderViewPo = new()
        {
            CustomerID = googleAdsRow.Customer.Id.ToString(),
            CampaignID = googleAdsRow.Campaign.Id.ToString(),
            ColGender = googleAdsRow.AdGroupCriterion.Gender.Type.ToString(),
            ColCampaignName = googleAdsRow.Campaign.Name,
            ColAdGroupName = googleAdsRow.AdGroup.Name,
            ColClicks = googleAdsRow.Metrics.Clicks.ToString(),
            ColImpressions = googleAdsRow.Metrics.Impressions.ToString(),
            ColCTR = googleAdsRow.Metrics.Ctr.ToString(),
            ColCPC = googleAdsRow.Metrics.AverageCpc.ToString(),
            ColCost = googleAdsRow.Metrics.CostMicros.ToString(),
            ColDate = googleAdsRow.Segments.Date.ToString(),
        };
        _context.SysAdsDataGenderView.Add(sysAdsDataGenderViewPo);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// 寫入關鍵字資料
    /// </summary>
    /// <param name="googleAdsRow"></param>
    private void InsertKeyWordData(GoogleAdsRow googleAdsRow)
    {
        SysAdsDataKeywordViewPo sysAdsDataKeywordViewPo = new()
        {
            CustomerID = googleAdsRow.Customer.Id.ToString(),
            CampaignID = googleAdsRow.Campaign.Id.ToString(),
            ColSrchKeyWord = googleAdsRow.AdGroupCriterion.Keyword.Text.ToString(),
            ColCampaignName = googleAdsRow.Campaign.Name,
            ColAdGroupName = googleAdsRow.AdGroup.Name,
            ColClicks = googleAdsRow.Metrics.Clicks.ToString(),
            ColImpressions = googleAdsRow.Metrics.Impressions.ToString(),
            ColCTR = googleAdsRow.Metrics.Ctr.ToString(),
            ColCPC = googleAdsRow.Metrics.AverageCpc.ToString(),
            ColCost = googleAdsRow.Metrics.CostMicros.ToString(),
            ColDate = googleAdsRow.Segments.Date.ToString(),
        };
        _context.SysAdsDataKeywordView.Add(sysAdsDataKeywordViewPo);
    }

    /// <summary>
    /// 寫入地點資料
    /// </summary>
    /// <param name="googleAdsRow"></param>
    private async void InsertLocationData(GoogleAdsRow googleAdsRow)
    {
        SysAdsDataLocationViewPo sysAdsDataLocationViewPo = new()
        {
            CustomerID = googleAdsRow.Customer.Id.ToString(),
            CampaignID = googleAdsRow.Campaign.Id.ToString(),
            ColConstant = googleAdsRow.CampaignCriterion.Location.GeoTargetConstant.ToString(),
            ColCampaignName = googleAdsRow.Campaign.Name,
            ColAdGroupName = googleAdsRow.AdGroup.Name,
            ColClicks = googleAdsRow.Metrics.Clicks.ToString(),
            ColImpressions = googleAdsRow.Metrics.Impressions.ToString(),
            ColCTR = googleAdsRow.Metrics.Ctr.ToString(),
            ColCPC = googleAdsRow.Metrics.AverageCpc.ToString(),
            ColCost = googleAdsRow.Metrics.CostMicros.ToString(),
            ColDate = googleAdsRow.Segments.Date.ToString(),
        };
        _context.SysAdsDataLocationView.Add(sysAdsDataLocationViewPo);
        await _context.SaveChangesAsync();
    }
}
