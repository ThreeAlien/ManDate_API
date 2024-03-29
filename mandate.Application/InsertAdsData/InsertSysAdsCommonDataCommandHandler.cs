﻿using Google.Ads.GoogleAds.V15.Services;
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
                            await InsertAgeData(googleAdsRow);
                            break;
                        case "gender":
                            await InsertGenderData(googleAdsRow);
                            break;
                        case "keyWord":
                            await InsertKeyWordData(googleAdsRow);
                            break;
                        case "location":
                            await InsertLocationData(googleAdsRow);
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
    private async Task InsertAgeData(GoogleAdsRow googleAdsRow)
    {
        long CustomerID = googleAdsRow.Customer.Id;
        string AdGroupCriterionAgeRange =
            googleAdsRow.AdGroupCriterion.AgeRange != null &&
            !string.IsNullOrEmpty(googleAdsRow.AdGroupCriterion.AgeRange.Type.ToString())
            ? googleAdsRow.AdGroupCriterion.AgeRange.Type.ToString()
            : " ";
        string ColClicks = googleAdsRow.Metrics.Clicks.ToString();
        string ColImpressions = googleAdsRow.Metrics.Impressions.ToString();
        string ColCTR = googleAdsRow.Metrics.Ctr.ToString();
        string ColCPC = googleAdsRow.Metrics.AverageCpc.ToString();
        string ColCost = googleAdsRow.Metrics.CostMicros.ToString();
        DateTime ColDate = Convert.ToDateTime(googleAdsRow.Segments.Date.ToString());

        SysAdsDataAgeViewPo sysAdsDataAgeViewPo = new()
        {
            CustomerID = googleAdsRow.Customer.Id.ToString(),
            CampaignID = googleAdsRow.Campaign.Id.ToString(),
            ColAge = AdGroupCriterionAgeRange,
            ColCampaignName = googleAdsRow.Campaign.Name,
            ColAdGroupName = googleAdsRow.AdGroup.Name,
            ColClicks = ColClicks,
            ColImpressions = ColImpressions,
            ColCTR = ColCTR,
            ColCPC = ColCPC,
            ColCost = ColCost,
            ColDate = googleAdsRow.Segments.Date.ToString(),
    };
        _context.SysAdsDataAgeView.Add(sysAdsDataAgeViewPo);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// 寫入性別資料
    /// </summary>
    /// <param name="googleAdsRow"></param>
    private async Task InsertGenderData(GoogleAdsRow googleAdsRow)
    {
        long CustomerID = googleAdsRow.Customer.Id;
        string AdGroupCriterionGender =
                            googleAdsRow.AdGroupCriterion.Gender != null &&
                            !string.IsNullOrEmpty(googleAdsRow.AdGroupCriterion.Gender.Type.ToString())
                            ? googleAdsRow.AdGroupCriterion.Gender.Type.ToString()
                            : " ";
        string ColClicks = googleAdsRow.Metrics.Clicks.ToString();
        string ColImpressions = googleAdsRow.Metrics.Impressions.ToString();
        string ColCTR = googleAdsRow.Metrics.Ctr.ToString();
        string ColCPC = googleAdsRow.Metrics.AverageCpc.ToString();
        string ColCost = googleAdsRow.Metrics.CostMicros.ToString();
        DateTime ColDate = Convert.ToDateTime(googleAdsRow.Segments.Date.ToString());

        SysAdsDataGenderViewPo sysAdsDataGenderViewPo = new()
        {
            CustomerID = googleAdsRow.Customer.Id.ToString(),
            CampaignID = googleAdsRow.Campaign.Id.ToString(),
            ColGender = AdGroupCriterionGender,
            ColCampaignName = googleAdsRow.Campaign.Name,
            ColAdGroupName = googleAdsRow.AdGroup.Name,
            ColClicks = ColClicks,
            ColImpressions = ColImpressions,
            ColCTR = ColCTR,
            ColCPC = ColCPC,
            ColCost = ColCost,
            ColDate = googleAdsRow.Segments.Date.ToString(),
        };
        _context.SysAdsDataGenderView.Add(sysAdsDataGenderViewPo);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// 寫入關鍵字資料
    /// </summary>
    /// <param name="googleAdsRow"></param>
    private async Task InsertKeyWordData(GoogleAdsRow googleAdsRow)
    {
        string AdGroupCriterionKeyWord =
                           googleAdsRow?.Segments?.Keyword?.Info.Text.ToString() ?? " ";
        string MatchType = googleAdsRow?.Segments?.Keyword?.Info.MatchType.ToString() ?? " ";
        string SearchWord = googleAdsRow?.SearchTermView?.SearchTerm?.ToString() ?? " ";
        string ColClicks = googleAdsRow.Metrics.Clicks.ToString();
        string ColImpressions = googleAdsRow.Metrics.Impressions.ToString();
        string ColCTR = googleAdsRow.Metrics.Ctr.ToString();
        string ColCPC = googleAdsRow.Metrics.AverageCpc.ToString();
        string ColCost = googleAdsRow.Metrics.CostMicros.ToString();
        DateTime ColDate = Convert.ToDateTime(googleAdsRow.Segments.Date.ToString());

        SysAdsDataKeywordViewPo sysAdsDataKeywordViewPo = new()
        {
            CustomerID = googleAdsRow.Customer.Id.ToString(),
            CampaignID = googleAdsRow.Campaign.Id.ToString(),
            ColSrchKeyWord = AdGroupCriterionKeyWord,
            ColSearchWord = SearchWord,
            ColMatchType = MatchType,
            ColCampaignName = googleAdsRow.Campaign.Name,
            ColAdGroupName = googleAdsRow.AdGroup.Name,
            ColClicks = ColClicks,
            ColImpressions = ColImpressions,
            ColCTR = ColCTR,
            ColCPC = ColCPC,
            ColCost = ColCost,
            ColDate = googleAdsRow.Segments.Date.ToString(),
        };
        _context.SysAdsDataKeywordView.Add(sysAdsDataKeywordViewPo);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// 寫入地點資料
    /// </summary>
    /// <param name="googleAdsRow"></param>
    private async Task InsertLocationData(GoogleAdsRow googleAdsRow)
    {
        string Constant = googleAdsRow?.CampaignCriterion?.Location?.GeoTargetConstant?.ToString() ?? " ";
        string AdGroupName = googleAdsRow?.AdGroup?.Name.ToString() ?? " ";
        string ColClicks = googleAdsRow.Metrics.Clicks.ToString();
        string ColImpressions = googleAdsRow.Metrics.Impressions.ToString();
        string ColCTR = googleAdsRow.Metrics.Ctr.ToString();
        string ColCPC = googleAdsRow.Metrics.AverageCpc.ToString();
        string ColCost = googleAdsRow.Metrics.CostMicros.ToString();
        SysAdsDataLocationViewPo sysAdsDataLocationViewPo = new()
        {
            CustomerID = googleAdsRow.Customer.Id.ToString(),
            CampaignID = googleAdsRow.Campaign.Id.ToString(),
            ColConstant = Constant,
            ColCampaignName = googleAdsRow.Campaign.Name,
            ColAdGroupName = AdGroupName,
            ColClicks = ColClicks,
            ColImpressions = ColImpressions,
            ColCTR = ColCTR,
            ColCPC = ColCPC,
            ColCost = ColCost,
            ColDate = googleAdsRow.Segments.Date.ToString(),
        };
        _context.SysAdsDataLocationView.Add(sysAdsDataLocationViewPo);
        await _context.SaveChangesAsync();
    }
}
