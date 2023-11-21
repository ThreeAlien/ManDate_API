using mandate.Business.Service;
using mandate.Domain.Models;
using MediatR;

namespace mandate.Application.Auth;

/// <summary>
/// 驗證 CommandHandler
/// </summary>
public class AuthenlizationCommandHandler : IRequestHandler<AuthenlizationRequest, AuthenlizationResponse>
{
    private readonly IGoogleAdsService _googleAdsService;

    /// <summary>
    /// 建構子
    /// </summary>
    public AuthenlizationCommandHandler(IGoogleAdsService googleAdsService)
    {
        _googleAdsService = googleAdsService;
    }

    public async Task<AuthenlizationResponse> Handle(AuthenlizationRequest request, CancellationToken cancellationToken)
    {
        string? refreshToken = await _googleAdsService.GenerateRefreshToken();

        _googleAdsService.FetchAdsSubAccountApi(refreshToken);

        //_googleAdsService.FetchAdsAccountApi(refreshToken);

        //_googleAdsService.FetchAdsReportApi(refreshToken);

        return new() { RefreshToken = refreshToken };
    }
}