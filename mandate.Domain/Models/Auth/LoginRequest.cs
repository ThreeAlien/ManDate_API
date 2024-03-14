using MediatR;

namespace mandate.Domain.Models.Auth;

public class LoginRequest : IRequest<LoginResponse>
{
    /// <summary>
    /// 帳號
    /// </summary>
    public string Account { get; set; } = null!;

    /// <summary>
    /// 密碼
    /// </summary>
    public string Password { get; set; } = null!;
}