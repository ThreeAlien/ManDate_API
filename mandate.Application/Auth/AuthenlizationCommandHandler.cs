using mandate.Business.Service;
using mandate.Domain.Models;
using mandate.Utility.Oauth;
using MediatR;
using static System.Net.Mime.MediaTypeNames;

namespace mandate.Application.Auth;

/// <summary>
/// 驗證 CommandHandler
/// </summary>
public class AuthenlizationCommandHandler : IRequestHandler<AuthenlizationRequest, AuthenlizationResponse>
{
    /// <summary>
    /// 建構子
    /// </summary>
    public AuthenlizationCommandHandler()
    {
    }

    public async Task<AuthenlizationResponse> Handle(AuthenlizationRequest request, CancellationToken cancellationToken)
    {
        string? refreshToken = GenerateUserCredentials.GenerateRefreshToken();

        GoogleAdsService.FetchAdsApi(refreshToken);

        return new() { RefreshToken = refreshToken };
    }
}