using Google.Ads.GoogleAds.V15.Services;
using mandate.Business.Service;
using mandate.Domain.Models;
using mandate.Domain.Po;
using mandate.Infrastructure;
using mandate.Utility.Extension;
using MediatR;

namespace mandate.Application.Auth;

/// <summary>
/// 驗證 CommandHandler
/// </summary>
public class AuthenlizationCommandHandler : IRequestHandler<AuthenlizationRequest, AuthenlizationResponse>
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
    public AuthenlizationCommandHandler(IGoogleAdsService googleAdsService, ManDateDBContext context)
    {
        _googleAdsService = googleAdsService;
        _context = context;
    }

    public async Task<AuthenlizationResponse> Handle(AuthenlizationRequest request, CancellationToken cancellationToken)
    {
        string? refreshToken = await _googleAdsService.GenerateRefreshToken();
        // 1.取得子帳戶
        List<Business.Service.SysClientPo> subAccountList = _googleAdsService.FetchAdsAdvertiseAccount(refreshToken);

        foreach (Business.Service.SysClientPo subAccount in subAccountList)
        {
            // 測試從Ads抓性別資料 For Andy
            Google.Protobuf.Collections.RepeatedField<GoogleAdsRow> adsCommonDataResult = await _googleAdsService.FetchAdsGenderData(refreshToken, subAccount.ClientId);

            // 2. SysAdsDataCampaignAction
            Google.Protobuf.Collections.RepeatedField<GoogleAdsRow> adsCampaignActionResult = await _googleAdsService.FetchAdsCampaignAction(refreshToken, subAccount.ClientId);
            foreach (GoogleAdsRow googleAdsRow in adsCampaignActionResult)
            {
                long CustomerID = googleAdsRow.Customer.Id;
                string ColConAction = googleAdsRow.ConversionAction.Name;
                long ActionID = googleAdsRow.ConversionAction.Id;
                // 寫入DB SysAdsDataCampaignAction
                SysAdsDataCampaignActionPo sysAdsDataCampaignActionPo = new()
                {
                    CustomerID = CustomerID.ToString(),
                    ActionID = ActionID.ToString(),
                    //CampaignID = googleAdsRow.Campaign.Id.ToString(),
                    ColConAction = ColConAction,
                };
                _context.SysAdsDataCampaignAction.Add(sysAdsDataCampaignActionPo);
                await _context.SaveChangesAsync();
            }

            // 3. SysAdsDataAdGroupCriterion
            Google.Protobuf.Collections.RepeatedField<GoogleAdsRow> adGroupCriterionResult = await _googleAdsService.FetchAdsAdGroupCriterion(refreshToken, subAccount.ClientId);
            foreach (GoogleAdsRow googleAdsRow in adGroupCriterionResult)
            {
                string AdGroupCriterion = googleAdsRow.AdGroupCriterion.Keyword.Text;
                // 寫入DB SysAdsDataAdGroupCriterion
                SysAdsDataAdGroupCriterionPo sysAdsDataAdGroupCriterionPo = new()
                {
                    CustomerID = googleAdsRow.Customer.Id.ToString(),
                    CampaignID = googleAdsRow.Campaign.Id.ToString(),
                    ColSrchKeyWord = AdGroupCriterion,
                    ColAge = googleAdsRow.AdGroupCriterion.AgeRange.Type.ToString(),
                    ColGender = googleAdsRow.AdGroupCriterion.Gender.Type.ToString(),
                };
                _context.SysAdsDataAdGroupCriterion.Add(sysAdsDataAdGroupCriterionPo);
                await _context.SaveChangesAsync();
            }

            // 4.SysAdsDataCampaignCon
            Google.Protobuf.Collections.RepeatedField<GoogleAdsRow> adsDataCampaignConResult = await _googleAdsService.FetchAdsDataCampaignCon(refreshToken, subAccount.ClientId);
            foreach (GoogleAdsRow googleAdsRow in adsDataCampaignConResult)
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
            }

            // 5. AdsDataCampaign
            Google.Protobuf.Collections.RepeatedField<GoogleAdsRow> adsDataCampaignResult = await _googleAdsService.FetchAdsDataCampaignOther(refreshToken, subAccount.ClientId);
            foreach (GoogleAdsRow googleAdsRow in adsDataCampaignResult)
            {
                long customerId = googleAdsRow.Customer.Id;
                string campaignName = googleAdsRow.Campaign.Name;
                string ConClicks = googleAdsRow.Metrics.Clicks.ToString();
                string ColImpressions = googleAdsRow.Metrics.Impressions.ToString();
                string ColCTR = googleAdsRow.Metrics.Ctr.ToString();
                string ColCPC = googleAdsRow.Metrics.AverageCpc.ToString();
                string ColCost = googleAdsRow.Metrics.CostMicros.ToString();
                string ColCPA = googleAdsRow.Metrics.AverageTargetCpaMicros.ToString();
                DateTime ColStartDate = Convert.ToDateTime(googleAdsRow.Campaign.StartDate.ToString());
                DateTime ColEndDate = Convert.ToDateTime(googleAdsRow.Campaign.EndDate.ToString());
                DateTime ColDate = Convert.ToDateTime(googleAdsRow.Segments.Date.ToString());

                // 寫入DB SysAdsDataCampaign
                SysAdsDataCampaignPo sysAdsDataCampaignPo = new()
                {
                    CustomerID = customerId.ToString(),
                    CampaignID = googleAdsRow.Campaign.Id.ToString(),
                    ColCampaignName = campaignName,
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
            }

            // 6. AdsDataAdGroupAd
            Google.Protobuf.Collections.RepeatedField<GoogleAdsRow> adsDataAdGroupAdResult = await _googleAdsService.FetchAdsDataAdGroupAd(refreshToken, subAccount.ClientId);
            foreach (GoogleAdsRow googleAdsRow in adsDataAdGroupAdResult)
            {
                long customerId = googleAdsRow.Customer.Id;
                string ColAdGroupName = googleAdsRow.AdGroup.Name;
                string ColAdFinalURL = googleAdsRow.AdGroupAd.Ad.FinalUrls.ToString();

                string ColHeadLine_1 = googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.HeadlinePart1;
                string ColHeadLine_2 = googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.HeadlinePart2;
                string ColHeadLine = string.Join("|", new[] { ColHeadLine_1, ColHeadLine_2 }.Where(s => !string.IsNullOrWhiteSpace(s)));
                string ColHeadLine_3 = googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.HeadlinePart3;
                string ColDirections_1 = googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.Description;
                string ColDirections_2 = googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.Description2;
                string ColDirections = string.Join("|", new[] { ColDirections_1, ColDirections_2 }.Where(s => !string.IsNullOrWhiteSpace(s)));
                string ColAdName = string.Join("|", new[] { ColHeadLine_1, ColHeadLine_2, ColHeadLine_3, ColAdFinalURL, ColDirections_1, ColDirections_2 }.Where(s => !string.IsNullOrWhiteSpace(s)));
                // 寫入DB SysAdsDataAdGroupAd
                SysAdsDataAdGroupAdPo sysAdsDataAdGroupAdPo = new()
                {
                    CustomerID = customerId.ToString(),
                    CampaignID = googleAdsRow.Campaign.Id.ToString(),
                    ColAdGroupName = ColAdGroupName,
                    ColAdFinalURL = ColAdFinalURL,
                    ColHeadline = ColHeadLine,
                    ColHeadline_1 = ColHeadLine_1,
                    ColHeadline_2 = ColHeadLine_2,
                 //   ColHeadline_3 = ColHeadLine_3,
                    ColDirections = ColDirections,
                    ColDirections_1 = ColDirections_1,
                    ColDirections_2 = ColDirections_2,
                    ColAdName = ColAdName,
                };
                _context.SysAdsDataAdGroupAd.Add(sysAdsDataAdGroupAdPo);
                await _context.SaveChangesAsync();
            }
        }



        return new() { RefreshToken = refreshToken };
    }
}