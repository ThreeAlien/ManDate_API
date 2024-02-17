using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

[Table("SysAdsDataCampaign")]
public class SysAdsDataCampaignPo
{
    /// <summary>
    /// 子帳戶ID
    /// </summary>
    [Key]
    public string? CustomerID { get; set; }

    /// <summary>
    /// 廣告活動ID
    /// </summary>
    [Key]
    public string? CampaignID { get; set; }

    /// <summary>
    /// 廣告活動名稱
    /// </summary>
    public string? ColCampaignName { get; set; }

    /// <summary>
    /// 收益
    /// </summary>
    public string? ColConValue { get; set; }

    /// <summary>
    /// 轉換 (依轉換時間)
    /// </summary>
    public string? ColConByDate { get; set; }

    /// <summary>
    /// 單次轉換費用
    /// </summary>
    public string? ColConPerCost { get; set; }

    /// <summary>
    /// 轉換
    /// </summary>
    public string? ColCon { get; set; }

    /// <summary>
    /// 轉換率
    /// </summary>
    public string? ColConRate { get; set; }

    /// <summary>
    /// 點擊
    /// </summary>
    public string? ConClicks { get; set; }

    /// <summary>
    /// 曝光數
    /// </summary>
    public string? ColImpressions { get; set; }

    /// <summary>
    /// 點閱率(CTR)
    /// </summary>
    public string? ColCTR { get; set; }

    /// <summary>
    ///  點擊成本(CPC)
    /// </summary>
    public string? ColCPC { get; set; }

    /// <summary>
    /// 費用(未)
    /// </summary>
    public string? ColCost { get; set; }

    /// <summary>
    /// 轉換成本
    /// </summary>
    public string? ColCPA { get; set; }

    /// <summary>
    /// 廣告活動開始時間
    /// </summary>
    public string? ColStartDate { get; set; }

    /// <summary>
    /// 廣告活動結束時間
    /// </summary>
    public string? ColEndDate { get; set; }
}