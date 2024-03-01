using MediatR;

namespace mandate.Domain.Models.Report;

/// <summary>
/// 取得報表詳細資訊 Request
/// </summary>
public class GetReportDetailRequest : IRequest<GetReportDetailResponse>
{
    /// <summary>
    /// 報表內容ID
    /// </summary>
    public string ColumnID { get; set; } = null!;
}
