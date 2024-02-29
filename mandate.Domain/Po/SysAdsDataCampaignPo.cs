using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

[Table("SysAdsDataCampaign")]
public class SysAdsDataCampaignPo
{
    /// <summary>
    /// 子客戶編號
    /// </summary>
    
    public string? CustomerID { get; set; }

    /// <summary>
    /// 廣告活動編號
    /// </summary>
    [Key]
    public string? CampaignID { get; set; }

    /// <summary>
    /// 廣告活動名稱
    /// </summary>
    public string? ColCampaignName { get; set; }


    /// 點擊
    /// </summary>
    public string? ColClicks { get; set; }

    /// <summary>
    /// 曝光數
    /// </summary>
    public string? ColImpressions { get; set; }

    /// <summary>
    /// 點閱率
    /// </summary>
    public string? ColCTR { get; set; }

    /// <summary>
    ///  點擊成本
    /// </summary>
    public string? ColCPC { get; set; }

    /// <summary>
    ///  費用(未)
    /// </summary>
    public string? ColCost { get; set; }

    /// <summary>
    /// 轉換成本(CPA)
    /// </summary>
    public string? ColCPA { get; set; }

    /// <summary>
    ///  廣告開始時間
    /// </summary>
    public DateTime? ColStartDate { get; set; }

    /// <summary>
    /// 廣告結束時間
    /// </summary>
    public DateTime? ColEndDate { get; set; }

    /// <summary>
    /// 數據日期
    /// </summary>
    [Key]
    public DateTime? ColDate { get; set; }
}