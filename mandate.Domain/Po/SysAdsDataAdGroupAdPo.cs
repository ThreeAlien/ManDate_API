using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

[Table("SysAdsDataAdGroupAd")]
public class SysAdsDataAdGroupAdPo
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
    public string? ColAdGroupName { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColAdFinalURL { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColHeadline { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColHeadline_1 { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColHeadline_2 { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColHeadline_3 { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColDirections { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColDirections_1 { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColDirections_2 { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColAdName { get; set; }
}
