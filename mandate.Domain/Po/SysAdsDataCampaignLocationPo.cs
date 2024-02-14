using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

[Table("SysAdsDataCampaignLocation")]
public class SysAdsDataCampaignLocationPo
{
    /// <summary>
    /// 客戶ID
    /// </summary>
    [Key]
    public string? CustomerID { get; set; }

    /// <summary>
    /// 廣告活動ID
    /// </summary>
    [Key]
    public string? CampaignID { get; set; }

    /// <summary>
    /// 地區
    /// </summary>
    public string? ColConstant { get; set; }

}