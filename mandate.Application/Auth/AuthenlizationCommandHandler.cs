using mandate.Business.Service;
using mandate.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace mandate.Application.Auth;

/// <summary>
/// 驗證 CommandHandler
/// </summary>
public class AuthenlizationCommandHandler : IRequestHandler<AuthenlizationRequest, AuthenlizationResponse>
{
    private readonly IGoogleAdsService _googleAdsService;

    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// 建構子
    /// </summary>
    public AuthenlizationCommandHandler(IHttpContextAccessor httpContextAccessor,IGoogleAdsService googleAdsService)
    {
        _httpContextAccessor = httpContextAccessor;
        _googleAdsService = googleAdsService;
    }

    public async Task<AuthenlizationResponse> Handle(AuthenlizationRequest request, CancellationToken cancellationToken)
    {
        string? refreshToken = await _googleAdsService.GenerateRefreshToken();
        _httpContextAccessor.HttpContext.Session.Set("token", Encoding.UTF8.GetBytes(refreshToken));

        _httpContextAccessor.HttpContext.Session.TryGetValue("token", out var token);
        string? a = Encoding.UTF8.GetString(token);
        _googleAdsService.FetchAdsSubAccountApi(refreshToken);

        //_googleAdsService.FetchAdsAccountApi(refreshToken);

        //_googleAdsService.FetchAdsReportApi(refreshToken);

        return new() { RefreshToken = refreshToken };
    }
}