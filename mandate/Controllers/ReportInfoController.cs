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
    /// 新增顧客資料
    /// </summary>
    [HttpPost]
    public Task<CreateReportResponse> CreateReport(CreateReportRequest request) => Mediator!.Send(request);


    /// <summary>
    /// 更新顧客資料
    /// </summary>
    [HttpPost]
    public Task<UpdateReportResponse> UpdateReport(UpdateReportRequest request) => Mediator!.Send(request);

    /// <summary>
    /// 刪除顧客資料
    /// </summary>
    [HttpPost]
    public Task<DeleteReportResponse> DeleteReport(DeleteReportRequest request) => Mediator!.Send(request);

}