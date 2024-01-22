using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

[Table("SysAdsDataCampaignAction")]
public class SysAdsDataCampaignActionPo
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
    public string? ActionID { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColConAction { get; set; }
}
