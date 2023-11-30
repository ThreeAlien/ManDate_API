using MediatR;

namespace mandate.Domain.Models.Customer;

/// <summary>
/// 取得顧客資料 Request
/// </summary>
public class GetCustomerRequest : IRequest<GetCustomerResponse>
{
    /// <summary>
    /// 顧客ID
    /// </summary>
    public string? CustomerID { get; set; }
}