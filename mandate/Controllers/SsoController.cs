using mandate.Controllers;
using mandate.Domain.Models.Sso;
using Microsoft.AspNetCore.Mvc;

namespace mandate.api.Controllers;

public class SsoController : BaseApiController
{
    /// <summary>
    /// CallBack
    /// </summary>
    [HttpPost]
    public Task<AuthorizeCallBackResponse> AuthorizeCallBack(AuthorizeCallBackRequest request) => Mediator!.Send(request);
}
