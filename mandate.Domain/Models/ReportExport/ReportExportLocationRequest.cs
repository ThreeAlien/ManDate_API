using MediatR;

namespace mandate.Domain.Models.ReportExport;

/// <summary>
/// 報表匯出 - 地點 Request
/// </summary>
public class ReportExportLocationRequest : IRequest<ReportExportLocationResponse>
{
    /// <summary>
    /// CampaignID
    /// </summary>
    public string? CampaignID { get; set; }

    /// <summary>
    /// 起始日期
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// 結束日期
    /// </summary>
    public DateTime? EndDate { get; set; }
}