using mandate.Domain.Models.ReportContent;
using Microsoft.AspNetCore.Mvc;

namespace mandate.Controllers;

public class ReportContentInfoController : BaseApiController
{
    /// <summary>
    /// 取得顧客資料
    /// </summary>
    [HttpPost]
    public Task<GetReportContentResponse> GetReportContent(GetReportContentRequest request) => Mediator!.Send(request);

}