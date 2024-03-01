using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

[Table("SysAdsDataAdGroupAd")]
public class SysAdsDataAdGroupAdPo
{
    /// <summary>
    /// 客戶ID
    /// </summary>
    public string? CustomerID { get; set; }

    /// <summary>
    /// 廣告活動ID
    /// </summary>
    [Key]
    public string? CampaignID { get; set; }

    /// <summary>
    /// 廣告群組名稱
    /// </summary>
    public string? ColAdGroupName { get; set; }

    /// <summary>
    /// URL
    /// </summary>
    public string? ColAdFinalURL { get; set; }

    /// <summary>
    /// 標題
    /// </summary>
    public string? ColHeadline { get; set; }

    /// <summary>
    /// 標題1
    /// </summary>
    public string? ColHeadline_1 { get; set; }

    /// <summary>
    /// 標題2
    /// </summary>
    public string? ColHeadline_2 { get; set; }


    /// <summary>
    /// 描述
    /// </summary>
    public string? ColDirections { get; set; }

    /// <summary>
    /// 描述1
    /// </summary>
    public string? ColDirections_1 { get; set; }

    /// <summary>
    /// 描述2
    /// </summary>
    public string? ColDirections_2 { get; set; }

    /// <summary>
    /// 廣告
    /// </summary>
    public string? ColAdName { get; set; }

    /// <summary>
    /// 數據日期
    /// </summary>
    [Key]
    public DateTime? ColDate { get; set; }
}
