using MediatR;

namespace mandate.Domain.Models.AdsData;

/// <summary>
/// 取得Ads帳戶(權限管理用) Request
/// </summary>
public class GetAdsAccountRequest : IRequest<GetAdsAccountResponse>
{
    /// <summary>
    /// Token
    /// </summary>
    public string RefreshToken { get; set; } = null!;
}