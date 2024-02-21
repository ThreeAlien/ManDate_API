using mandate.Business.Service;
using mandate.Domain.Models.Sso;
using MediatR;

namespace mandate.Application.Sso;

public class AuthorizeCallBackCommandHandler : IRequestHandler<AuthorizeCallBackRequest, AuthorizeCallBackResponse>
{
    /// <summary>
    /// Google Ads服務
    /// </summary>
    private readonly IGoogleAdsService _googleAdsService;

    /// <summary>
    /// 建構子
    /// </summary>
    public AuthorizeCallBackCommandHandler(IGoogleAdsService googleAdsService)
    {
        _googleAdsService = googleAdsService;
    }

    public async Task<AuthorizeCallBackResponse> Handle(AuthorizeCallBackRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Code))
        {
            return new AuthorizeCallBackResponse()
            {
                Code = "400",
                Data = null,
                Msg = "SsoCode 為必填！"
            };
        }

        string? refreshToken = string.Empty;

        try
        {
            refreshToken = await _googleAdsService.AuthorizeCallBack(request.Code);
        }
        catch (Exception ex)
        {
            return new AuthorizeCallBackResponse()
            {
                Code = "400",
                Data = null,
                Msg = ex.Message.ToString()
            };
        }

        return new AuthorizeCallBackResponse()
        {
            Code = "200",
            Data = refreshToken,
            Msg = "success"
        };
    }
}
