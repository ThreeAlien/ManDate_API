using mandate.Controllers;
using mandate.Domain.Models;
using mandate.Domain.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace mandate.api.Controllers;

public class AuthController : BaseApiController
{
    /// <summary>
    /// 驗證功能(取得RefreshToken)
    /// </summary>
    [HttpPost]
    public Task<AuthenlizationResponse> Authenlization() => Mediator!.Send(new AuthenlizationRequest());

    /// <summary>
    /// 驗證功能(取得RefreshToken)
    /// </summary>
    [HttpPost]
    public Task<LoginResponse> Login(LoginRequest request) => Mediator!.Send(request);
}
