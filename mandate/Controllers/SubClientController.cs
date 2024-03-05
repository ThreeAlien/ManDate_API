using mandate.Controllers;
using mandate.Domain.Models.SubClient;
using Microsoft.AspNetCore.Mvc;

namespace mandate.api.Controllers;

public class SubClientController : BaseApiController
{
    /// <summary>
    /// 取得子帳戶基本資料
    /// </summary>
    [HttpPost]
    public Task<GetSubClientResponse> GetSubClient(GetSubClientRequest request) => Mediator!.Send(request);

    /// <summary>
    /// 取得子帳戶基本資料
    /// </summary>
    [HttpPost]
    public Task<AddSubClientResponse> AddSubClient(AddSubClientRequest request) => Mediator!.Send(request);
}