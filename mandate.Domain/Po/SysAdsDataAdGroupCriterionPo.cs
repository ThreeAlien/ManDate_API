using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

[Table("SysAdsDataAdGroupCriterion")]
public class SysAdsDataAdGroupCriterionPo
{
    /// <summary>
    /// 客戶UD
    /// </summary>
    [Key]
    public string? CustomerID { get; set; }

    /// <summary>
    /// 廣告ID
    /// </summary>
    [Key]
    public string? CampaignID { get; set; }

    /// <summary>
    /// 關鍵字
    /// </summary>
    public string? ColSrchKeyWord { get; set; }

    /// <summary>
    /// 年齡
    /// </summary>
    public string? ColAge { get; set; }

    /// <summary>
    /// 性別
    /// </summary>
    public string? ColGender { get; set; }

}
