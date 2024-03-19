using MediatR;

namespace mandate.Domain.Models.ReportExport;

/// <summary>
/// 報表匯出 - 年齡 Request
/// </summary>
public class ReportExportAgeRequest : IRequest<ReportExportAgeResponse>
{
    /// <summary>
    /// CampaignID
    /// </summary>
    public string? CampaignID { get; set; }

    /// <summary>
    /// 起始日期
    /// </summary>
    public string? StartDate { get; set; }

    /// <summary>
    /// 結束日期
    /// </summary>
    public string? EndDate { get; set; }
}