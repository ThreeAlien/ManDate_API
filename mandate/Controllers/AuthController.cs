using mandate.Controllers;
using mandate.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace mandate.api.Controllers;

public class AuthController : BaseApiController
{
    /// <summary>
    /// 驗證功能(取得RefreshToken)weiderTest
    /// </summary>
    [HttpPost]
    public Task<AuthenlizationResponse> Authenlization() => Mediator!.Send(new AuthenlizationRequest());

}
