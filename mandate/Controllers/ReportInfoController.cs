using mandate.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace mandate.Controllers;

public class ReportInfoController : BaseApiController
{
    /// <summary>
    /// 取得顧客資料
    /// </summary>
    [HttpPost]
    public Task<GetReportResponse> GetReport(GetReportRequest request) => Mediator!.Send(request);

    /// <summary>
    /// 取得顧客資料
    /// </summary>
    [HttpPost]
    public Task<CreateReportResponse> CreateReport(CreateReportRequest request) => Mediator!.Send(request);


}