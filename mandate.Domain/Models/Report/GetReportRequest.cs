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
   
}