using MediatR;

namespace mandate.Domain.Models.ReportExport;

/// <summary>
/// 報表匯出 - 關鍵字 Request
/// </summary>
public class ReportExportKeyWordRequest : IRequest<ReportExportKeyWordResponse>
{
    /// <summary>
    /// 關鍵字
    /// </summary>
    public string? KeyWord { get; set; }
}