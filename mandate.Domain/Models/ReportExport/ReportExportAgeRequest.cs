using MediatR;

namespace mandate.Domain.Models.ReportExport;

/// <summary>
/// 報表匯出 - 年齡 Request
/// </summary>
public class ReportExportAgeRequest : IRequest<ReportExportAgeResponse>
{
}