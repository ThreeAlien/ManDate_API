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

    /// <summary>
    /// 新增顧客資料 (FeomGoogle)
    /// </summary>
    [HttpPost]
    public Task<AddCustomerResponse> AddCustomer(AddCustomerRequest request) => Mediator!.Send(request);
}