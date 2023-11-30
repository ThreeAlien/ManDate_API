using MediatR;

namespace mandate.Domain.Models;

/// <summary>
/// 取得顧客資料 Request
/// </summary>
public class GetReportRequest : IRequest<GetReportResponse>
{
    /// <summary>
    /// 報表流水編號
    /// </summary>
    public string? ReportID { get; set; }
    /// <summary>
    /// 報表流水編號
    /// </summary>
    public string? ReportName { get; set; }
    /// <summary>
    /// 報表流水編號
    /// </summary>
    public string? ReportGoalAds { get; set; }
    /// <summary>
    /// 報表流水編號
    /// </summary>
    public string? ReportMedia { get; set; }
    /// <summary>
    /// 報表流水編號
    /// </summary>
    public string? ContentID { get; set; }
    /// <summary>
    /// 報表流水編號
    /// </summary>
    public string? SubID { get; set; }
    /// <summary>
    /// 報表流水編號
    /// </summary>
    public string? Editer { get; set; }
    /// <summary>
    /// 報表流水編號
    /// </summary>
    public DateTime? EditDate { get; set; }
    /// <summary>
    /// 報表流水編號
    /// </summary>
    public string? Creater { get; set; }
    /// <summary>
    /// 報表流水編號
    /// </summary>
    public DateTime? CreateDate { get; set; }
    /// <summary>
    /// 報表流水編號
    /// </summary>
    public string? ReportStatus { get; set; }
}