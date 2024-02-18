using mandate.Business.Service;
using mandate.Domain.Models.AdsData;
using MediatR;

namespace mandate.Application.AdsData;

/// <summary>
/// 取得Ads帳戶(權限管理用) ComandHandler
/// </summary>
public class GetAdsAccountCommandHandler : IRequestHandler<GetAdsAccountRequest, GetAdsAccountResponse>
{
    /// <summary>
    /// Google Ads服務
    /// </summary>
    private readonly IGoogleAdsService _googleAdsService;

    /// <summary>
    /// 建構子
    /// </summary>
    public GetAdsAccountCommandHandler(IGoogleAdsService googleAdsService)
    {
        _googleAdsService = googleAdsService;
    }

    public async Task<GetAdsAccountResponse> Handle(GetAdsAccountRequest request, CancellationToken cancellationToken)
    {

        string? refreshToken = await _googleAdsService.GenerateRefreshToken();
        string[]? adsAccountArray = _googleAdsService.FetchAdsAccountApi(refreshToken);

        List<string> listDatas = new List<string>(adsAccountArray);


        return new GetAdsAccountResponse()
        {
            Code = "200",
            Data = listDatas,
            Msg = "success"
        };
    }
}
