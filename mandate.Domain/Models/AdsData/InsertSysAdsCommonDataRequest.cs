using MediatR;

namespace mandate.Domain.Models.AdsData;

/// <summary>
/// Insert age、gender、keyWord、location 資料 Request
/// </summary>
public class InsertSysAdsCommonDataRequest : IRequest<InsertSysAdsCommonDataResponse>
{
    /// <summary>
    /// 查詢類別
    /// 請輸入age、gender、keyWord、location其中一個
    /// </summary>
    public string QueryType { get; set; } = null!;
}
