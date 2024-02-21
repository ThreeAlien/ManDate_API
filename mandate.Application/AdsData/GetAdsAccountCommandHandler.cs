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
        if (string.IsNullOrEmpty(request.RefreshToken))
        {
            return new GetAdsAccountResponse()
            {
                Code = "400",
                Data = null,
                Msg = "RequestToken為必填！"
            };
        }
        string[]? adsAccountArray = _googleAdsService.FetchAdsAccountApi(request.RefreshToken);

        List<string> listDatas = new List<string>(adsAccountArray);


        return new GetAdsAccountResponse()
        {
            Code = "200",
            Data = listDatas,
            Msg = "success"
        };
    }
}
