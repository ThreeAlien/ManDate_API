using MediatR;

namespace mandate.Domain.Models.AdsData;

public class GetSysAdsDataRequest : IRequest<GetSysAdsDataResponse>
{
    /// <summary>
    /// 子帳戶號碼
    /// </summary>
    public int SubClientNo { get; set; }

    /// <summary>
    /// 選擇查詢的欄位
    /// </summary>
    public string[] SelectFields { get; set; } = null!;
}