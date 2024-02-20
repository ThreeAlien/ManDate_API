using mandate.Controllers;
using mandate.Domain.Models.Sso;
using Microsoft.AspNetCore.Mvc;

namespace mandate.api.Controllers;

public class SsoController : BaseApiController
{
    /// <summary>
    /// Sso
    /// </summary>
    [HttpPost]
    public Task<SingleSignOnResponse> SingleSignOn(SingleSignOnRequest request) => Mediator!.Send(request);

    /// <summary>
    /// CallBack
    /// </summary>
    [HttpPost]
    public Task<AuthorizeCallBackResponse> AuthorizeCallBack(AuthorizeCallBackRequest request) => Mediator!.Send(request);
}
