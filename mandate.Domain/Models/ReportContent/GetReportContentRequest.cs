using MediatR;

namespace mandate.Domain.Models.ReportContent;

/// <summary>
/// 取得顧客資料 Request
/// </summary>
public class GetReportContentRequest : IRequest<GetReportContentResponse>
{
    /// <summary>
    /// 報表內容流水編號
    /// </summary>
    public string? ContentID { get; set; }
}