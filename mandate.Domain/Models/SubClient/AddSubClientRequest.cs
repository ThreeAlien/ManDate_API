using MediatR;

namespace mandate.Domain.Models.SubClient;

/// <summary>
/// 取得子帳戶基本資料 Request
/// </summary>
public class AddSubClientRequest : IRequest<AddSubClientResponse>
{
}