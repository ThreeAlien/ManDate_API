using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

[Table("SysAdsDataCampaignLocation")]
public class SysAdsDataCampaignLocationPo
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
    public string? ColConstant { get; set; }

}