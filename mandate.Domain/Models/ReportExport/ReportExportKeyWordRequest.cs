using MediatR;

namespace mandate.Domain.Models.ReportExport;

/// <summary>
/// 報表匯出 - 關鍵字 Request
/// </summary>
public class ReportExportKeyWordRequest : IRequest<ReportExportKeyWordResponse>
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