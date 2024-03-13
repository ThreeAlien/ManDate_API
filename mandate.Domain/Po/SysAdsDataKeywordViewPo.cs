using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

[Table("SysAdsDataKeywordView")]
public class SysAdsDataKeywordViewPo
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
    /// 搜尋關鍵字
    /// </summary>
    public string? ColSrchKeyWord { get; set; }

    /// <summary>
    /// 搜尋字詞
    /// </summary>
    public string? ColSearchWord { get; set; }
    /// <summary>
    /// 比對類型
    /// </summary>
    public string? ColMatchType { get; set; }

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
    public DateTime? ColDate { get; set; }
}
