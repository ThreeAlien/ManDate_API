using mandate.Business.Service;
using mandate.Domain.Models;
using mandate.Utility.Extension;
using MediatR;
using Microsoft.AspNetCore.Http;

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
    /// Session存取服務
    /// </summary>
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// 建構子
    /// </summary>
    public AuthenlizationCommandHandler(IHttpContextAccessor httpContextAccessor, IGoogleAdsService googleAdsService)
    {
        _httpContextAccessor = httpContextAccessor;
        _googleAdsService = googleAdsService;
    }

    public async Task<AuthenlizationResponse> Handle(AuthenlizationRequest request, CancellationToken cancellationToken)
    {
        string? refreshToken = await _googleAdsService.GenerateRefreshToken();
        // 設定session範例
        //_httpContextAccessor.HttpContext.Session.Set("refreshToken", refreshToken);
        // 取得Session範例
        //string? sessionRefreshToken = _httpContextAccessor.HttpContext.Session.Get<string>("refreshToken");
        // 執行GoogleAds Api範例
        _googleAdsService.FetchAdsSubAccountApi(refreshToken);

        //_googleAdsService.FetchAdsAccountApi(refreshToken);

        //_googleAdsService.FetchAdsReportApi(refreshToken);

        return new() { RefreshToken = refreshToken };
    }
}