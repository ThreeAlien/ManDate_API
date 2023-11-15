using MediatR;

namespace mandate.Domain.Models;

/// <summary>
/// 驗證 Request
/// </summary>
public class AuthenlizationRequest : IRequest<AuthenlizationResponse>
{
}