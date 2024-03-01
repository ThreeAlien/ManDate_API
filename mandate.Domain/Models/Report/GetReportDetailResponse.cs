using mandate.Business.Models;
using mandate.Domain.Po;

namespace mandate.Domain.Models.Report;

/// <summary>
/// 取得報表詳細資訊 Response
/// </summary>
public class GetReportDetailResponse : BaseResponse<List<SysReportColumnPo>>
{
}