using MediatR;
using System.ComponentModel.DataAnnotations;

namespace mandate.Domain.Models;

/// <summary>
/// 取得報表資料 Request
/// </summary>
public class UpdateReportRequest : IRequest<UpdateReportResponse>
{

    /// <summary>
    /// 報表ID
    /// </summary>
    public string ReportID { get; set; } = null!;

    /// <summary>
    /// 報表名稱
    /// </summary>
    public string ReportName { get; set; } = null!;

    /// <summary>
    /// 報表目標
    /// </summary>
    public string? ReportGoalAds { get; set; }

    /// <summary>
    /// 報表媒體
    /// </summary>
    public string ReportMedia { get; set; } = null!;

    /// <summary>
    /// 報表內容ID(Join)
    /// </summary>
    public string? ContentID { get; set; }

    /// <summary>
    /// 子帳戶UD
    /// </summary>
    public string SubID { get; set; } = null!;

    /// <summary>
    /// 編輯者
    /// </summary>
    public string? Editer { get; set; }

    /// <summary>
    /// 編輯日期
    /// </summary>
    public DateTime EditDate { get; set; }

    /// <summary>
    /// 建立者
    /// </summary>
    public string? Creater { get; set; }
    /// <summary>
    /// 建立日期
    /// </summary>
    public DateTime? CreateDate { get; set; }
    /// <summary>
    /// 報表是否使用
    /// </summary>
    public bool? ReportStatus { get; set; }

    public UpdateReportColumnRequest ColumnData { get; set; }
}