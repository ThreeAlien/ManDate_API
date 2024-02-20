using MediatR;

namespace mandate.Domain.Models.Sso;

public class AuthorizeCallBackRequest : IRequest<AuthorizeCallBackResponse>
{
    public string Code { get; set; } = null!;
}