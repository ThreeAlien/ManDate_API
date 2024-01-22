using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

[Table("SysAdsDataAdGroupCriterion")]
public class SysAdsDataAdGroupCriterionPo
{
    /// <summary>
    /// 待註解
    /// </summary>
    [Key]
    public string? CustomerID { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    [Key]
    public string? CampaignID { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColSrchKeyWord { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColAge { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColGender { get; set; }
}
