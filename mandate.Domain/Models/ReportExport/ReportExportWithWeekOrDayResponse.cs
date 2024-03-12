using mandate.Business.Models;
using mandate.Domain.Vo;

namespace mandate.Domain.Models.ReportExport;

/// <summary>
/// 報表匯出 - 每周或每日 Response
/// </summary>
public class ReportExportWithWeekOrDayResponse : BaseResponse<List<ReportExportWithWeekOrDayVo>>
{
}
