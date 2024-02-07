using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

[Table("SysAdsData")]
public class SysAdsDataPo
{
    /// <summary>
    /// 待註解
    /// </summary>
    public int SubClientNo { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? SubClientName { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? SubClientID { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColCampaignID { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColAdGroupID { get; set; }

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
    public string? ColShortHeadLine { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColLongHeadLine { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColHeadLine_1 { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColHeadLine_2 { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColAdName { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColAdPath_1 { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColAdPath_2 { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColSrchKeyWord { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColSwitchTarget { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColDateTime { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColWeek { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColSeason { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColMonth { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColIncome { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColTransTime { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColTransCostOnce { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColTrans { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColTransRate { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColClick { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ColImpression { get; set; }

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
}