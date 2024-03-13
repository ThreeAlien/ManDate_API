using MediatR;

namespace mandate.Domain.Models;

/// <summary>
/// 取得顧客資料 Request
/// </summary>
public class GetReportRequest : IRequest<GetReportResponse>
{
    /// <summary>
    /// 報表名稱
    /// </summary>
    public string? ReportName { get; set; }

    /// <summary>
    /// 報表目標
    /// </summary>
    public string? ReportGoalAds { get; set; }

    /// <summary>
    /// 報表媒體
    /// </summary>
    public string? ReportMedia { get; set; }

    /// <summary>
    /// 起始日期
    /// </summary>
    public string? StartDate { get; set; }

    /// <summary>
    /// 結束日期
    /// </summary>
    public string? EndDate { get; set; }
}