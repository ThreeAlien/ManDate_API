using mandate.Domain.Models.Customer;
using Microsoft.AspNetCore.Mvc;

namespace mandate.Controllers;

public class CustomerInfoController : BaseApiController
{
    /// <summary>
    /// 取得顧客資料
    /// </summary>
    [HttpPost]
    public Task<GetCustomerResponse> GetCustomer(GetCustomerRequest request) => Mediator!.Send(request);
}