using mandate.Controllers;
using mandate.Domain.Models.ReportExport;
using Microsoft.AspNetCore.Mvc;

namespace mandate.api.Controllers;

/// <summary>
/// 報表匯出 Controller
/// </summary>
public class ReportExportController : BaseApiController
{
    /// <summary>
    /// 報表匯出 - 性別
    /// </summary>
    [HttpPost]
    public Task<ReportExportGenderResponse> ReportExportGender(ReportExportGenderRequest request) => Mediator!.Send(request);

    /// <summary>
    /// 報表匯出 - 年齡
    /// </summary>
    [HttpPost]
    public Task<ReportExportAgeResponse> ReportExportAge(ReportExportAgeRequest request) => Mediator!.Send(request);

    /// <summary>
    /// 報表匯出 - 關鍵字
    /// </summary>
    [HttpPost]
    public Task<ReportExportKeyWordResponse> ReportExportKeyWord(ReportExportKeyWordRequest request) => Mediator!.Send(request);

    /// <summary>
    /// 報表匯出 - 地點
    /// </summary>
    [HttpPost]
    public Task<ReportExportLocationResponse> ReportExportLocation(ReportExportLocationRequest request) => Mediator!.Send(request);

    /// <summary>
    /// 報表匯出 - 每周或每日
    /// </summary>
    [HttpPost]
    public Task<ReportExportWithWeekOrDayResponse> ReportExportWithWeekOrDay(ReportExportWithWeekOrDayRequest request) => Mediator!.Send(request);
}
