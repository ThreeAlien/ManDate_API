using MediatR;

namespace mandate.Domain.Models.ReportExport;

/// <summary>
/// 報表匯出 - 每周或每日 Request
/// </summary>
public class ReportExportWithWeekOrDayRequest : IRequest<ReportExportWithWeekOrDayResponse>
{
    /// <summary>
    /// CampaignID
    /// </summary>
    public string? CampaignID { get; set; }

    /// <summary>
    /// 狀態(使用者選"每周"或"每日")
    /// </summary>
    public string Status { get; set; } = null!;

    /// <summary>
    /// 起始日期
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// 結束日期
    /// </summary>
    public DateTime? EndDate { get; set; }
}
