using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

[Table("SysAdsDataCampaignCon")]
public class SysAdsDataCampaignConPo
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
    /// 廣告目標
    /// </summary>
    public string? ColConGoal { get; set; }
}