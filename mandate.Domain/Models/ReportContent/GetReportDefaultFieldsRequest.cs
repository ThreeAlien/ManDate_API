using MediatR;

namespace mandate.Domain.Models.ReportContent;

/// <summary>
/// 取得報表預設欄位 Request
/// </summary>
public class GetReportDefaultFieldsRequest : IRequest<GetReportDefaultFieldsResponse>
{
}