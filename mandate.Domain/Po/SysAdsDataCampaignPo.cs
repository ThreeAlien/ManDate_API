using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

[Table("SysAdsDataCampaign")]
public class SysAdsDataCampaignPo
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
    public string? ColCampaignName { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColConValue { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColConByDate { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColConPerCost { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColCon { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColConRate { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ConClicks { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColImpressions { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColCTR { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColCPC { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColCost { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColCPA { get; set; }
}