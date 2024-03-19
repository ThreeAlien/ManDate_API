﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

[Table("SysAdsDataLocationView")]
public class SysAdsDataLocationViewPo
{
    /// <summary>
    /// 
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int SerialID { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? CustomerID { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Key]
    public string CampaignID { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    public string? ColConstant { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? ColCampaignName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? ColAdGroupName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? ColClicks { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? ColImpressions { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? ColCTR { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? ColCPC { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? ColCost { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public string? ColDate { get; set; }
}
