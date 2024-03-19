using MediatR;

namespace mandate.Domain.Models.ReportExport;

/// <summary>
/// 報表匯出 - 性別 Request
/// </summary>
public class ReportExportGenderRequest : IRequest<ReportExportGenderResponse>
{
    /// <summary>
    /// SubId
    /// </summary>
    public string? SubId { get; set; }

    /// <summary>
    /// 起始日期
    /// </summary>
    public string? StartDate { get; set; }

    /// <summary>
    /// 結束日期
    /// </summary>
    public string? EndDate { get; set; }
}
