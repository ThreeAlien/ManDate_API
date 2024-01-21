using Google.Ads.GoogleAds.V15.Services;
using mandate.Business.Service;
using mandate.Domain.Models.AdsData;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;

namespace mandate.Application.InsertAdsData;

public class InsertSysAdsDataAdGroupAdCommandHandler : IRequestHandler<InsertSysAdsDataAdGroupAdRequest, InsertSysAdsDataAdGroupAdResponse>
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
    public InsertSysAdsDataAdGroupAdCommandHandler(IGoogleAdsService googleAdsService, ManDateDBContext context)
    {
        _googleAdsService = googleAdsService;
        _context = context;
    }

    public async Task<InsertSysAdsDataAdGroupAdResponse> Handle(InsertSysAdsDataAdGroupAdRequest request, CancellationToken cancellationToken)
    {
        InsertSysAdsDataAdGroupAdResponse response = new();
        string? refreshToken = await _googleAdsService.GenerateRefreshToken();
        // 1.取得子帳戶
        List<Business.Service.SysClientPo> subAccountList = _googleAdsService.FetchAdsSubAccountApi(refreshToken);

        foreach (Business.Service.SysClientPo subAccount in subAccountList)
        {
            // 6. AdsDataAdGroupAd
            Google.Protobuf.Collections.RepeatedField<GoogleAdsRow> adsDataAdGroupAdResult = await _googleAdsService.FetchAdsDataAdGroupAd(refreshToken, subAccount.ClientId);
            foreach (GoogleAdsRow googleAdsRow in adsDataAdGroupAdResult)
            {
                //long customerId = googleAdsRow.Customer.Id;
                //string ColAdGroupName = googleAdsRow.AdGroup.Name;
                //string ColAdFinalURL = googleAdsRow.AdGroupAd.Ad.FinalUrls.ToString();

                //string ColHeadLine_1 = googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.HeadlinePart1;
                //string ColHeadLine_2 = googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.HeadlinePart2;
                //string ColHeadLine = string.Join("|", new[] { ColHeadLine_1, ColHeadLine_2 }.Where(s => !string.IsNullOrWhiteSpace(s)));
                //string ColHeadLine_3 = googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.HeadlinePart3;
                //string ColDirections_1 = googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.Description;
                //string ColDirections_2 = googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.Description2;
                //string ColDirections = string.Join("|", new[] { ColDirections_1, ColDirections_2 }.Where(s => !string.IsNullOrWhiteSpace(s)));
                //string ColAdName = string.Join("|", new[] { ColHeadLine_1, ColHeadLine_2, ColHeadLine_3, ColAdFinalURL, ColDirections_1, ColDirections_2 }.Where(s => !string.IsNullOrWhiteSpace(s)));

                long customerId = googleAdsRow.Customer.Id;
                string ColAdGroupName = googleAdsRow.AdGroup.Name;
                string ColAdFinalURL = string.IsNullOrEmpty(googleAdsRow.AdGroupAd.Ad.FinalUrls.ToString()) ? " " : googleAdsRow.AdGroupAd.Ad.FinalUrls.ToString();

                string ColHeadLine_1 = string.IsNullOrEmpty(googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.HeadlinePart1) ? " " : googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.HeadlinePart1;
                string ColHeadLine_2 = string.IsNullOrEmpty(googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.HeadlinePart2) ? " " : googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.HeadlinePart2;
                string ColHeadLine = string.Join("|", new[] { ColHeadLine_1, ColHeadLine_2 }.Where(s => !string.IsNullOrWhiteSpace(s)));
                string ColHeadLine_3 = string.IsNullOrEmpty(googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.HeadlinePart3) ? " " : googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.HeadlinePart3;
                string ColDirections_1 = string.IsNullOrEmpty(googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.Description) ? " " : googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.Description;
                string ColDirections_2 = string.IsNullOrEmpty(googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.Description2) ? " " : googleAdsRow.AdGroupAd.Ad.ExpandedTextAd.Description2;
                string ColDirections = string.Join("|", new[] { ColDirections_1, ColDirections_2 }.Where(s => !string.IsNullOrWhiteSpace(s)));
                string ColAdName = string.Join("|", new[] { ColHeadLine_1, ColHeadLine_2, ColHeadLine_3, ColAdFinalURL, ColDirections_1, ColDirections_2 }.Where(s => !string.IsNullOrWhiteSpace(s)));

                // 寫入DB SysAdsDataAdGroupAd

                try
                {
                    SysAdsDataAdGroupAdPo sysAdsDataAdGroupAdPo = new()
                    {
                        CustomerID = customerId.ToString(),
                        CampaignID = googleAdsRow.Campaign.Id.ToString(),
                        ColAdGroupName = ColAdGroupName,
                        ColAdFinalURL = ColAdFinalURL,
                        ColHeadline = ColHeadLine,
                        ColHeadline_1 = ColHeadLine_1,
                        ColHeadline_2 = ColHeadLine_2,
                        ColHeadline_3 = ColHeadLine_3,
                        ColDirections = ColDirections,
                        ColDirections_1 = ColDirections_1,
                        ColDirections_2 = ColDirections_2,
                        ColAdName = ColAdName,
                    };
                    _context.SysAdsDataAdGroupAd.Add(sysAdsDataAdGroupAdPo);
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
