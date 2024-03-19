using MediatR;

namespace mandate.Domain.Models.Auth;

/// <summary>
/// 取得權限 Request
/// </summary>
public class GetAccessRoleRequest : IRequest<GetAccessRoleResponse>
{
    /// <summary>
    /// Mcc帳戶
    /// </summary>
    public string CustId { get; set; } = null!;
}