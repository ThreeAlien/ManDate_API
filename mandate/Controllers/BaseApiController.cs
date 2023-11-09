using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace mandate.Controllers;

/// <summary>
/// Api Controller 基底
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public abstract class BaseApiController : Controller
{
    private IMediator _mediator = null!;

    /// <summary>
    /// IMediator
    /// </summary>
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}