using MediatR;

namespace mandate.Domain.Models.ReportExport;

/// <summary>
/// 報表匯出 - 地點 Request
/// </summary>
public class ReportExportLocationRequest : IRequest<ReportExportLocationResponse>
{
}