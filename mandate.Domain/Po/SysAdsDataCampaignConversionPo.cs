using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

[Table("SysAdsDataCampaignConversion")]
public class SysAdsDataCampaignConversionPo
{
    /// <summary>
    /// 子客戶編號
    /// </summary>
    [Key]
    public string? CustomerID { get; set; }

    /// <summary>
    /// 廣告活動編號
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

}