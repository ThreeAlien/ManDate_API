using MediatR;
using System.ComponentModel.DataAnnotations;

namespace mandate.Domain.Models;

/// <summary>
/// 取得報表資料 Request
/// </summary>
public class DeleteReportRequest : IRequest<DeleteReportResponse>
{

    /// <summary>
    /// 報表ID
    /// </summary>
    public string ReportID { get; set; } = null!;
    /// <summary>
    /// 報表是否使用
    /// </summary>
    public bool? ReportStatus { get; set; }
}