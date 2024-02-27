using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

[Table("SysAdsData")]
public class SysAdsDataPo
{
    /// <summary>
    /// 流水編號
    /// </summary>
    public int SubClientNo { get; set; }

    /// <summary>
    /// 子帳戶名稱
    /// </summary>
    public string? SubClientName { get; set; }

    /// <summary>
    /// 子帳戶ID
    /// </summary>
    public string? SubClientID { get; set; }

    /// <summary>
    /// 廣告活動名稱
    /// </summary>
    public string? ColCampaignName { get; set; }

    /// <summary>
    /// 廣告群組名稱
    /// </summary>
    public string? ColAdGroupName { get; set; }

    /// <summary>
    /// 廣告網址
    /// </summary>
    public string? ColAdFinalURL { get; set; }

    /// <summary>
    /// 廣告標題
    /// </summary>
    public string? ColHeadline { get; set; }


    /// <summary>
    /// 廣告標題_1
    /// </summary>
    public string? ColHeadLine_1 { get; set; }

    /// <summary>
    /// 廣告標題_2
    /// </summary>
    public string? ColHeadLine_2 { get; set; }

    /// <summary>
    /// 廣告名稱
    /// </summary>
    public string? ColAdName { get; set; }



    /// <summary>
    /// 關鍵字
    /// </summary>
    public string? ColSrchKeyWord { get; set; }

    /// <summary>
    /// 廣告目標
    /// </summary>
    public string? ColConGoal { get; set; }

    /// <summary>
    /// 廣告時間
    /// </summary>
    //public string? ColDateTime { get; set; }

    ///// <summary>
    ///// 週
    ///// </summary>
    //public string? ColWeek { get; set; }

    ///// <summary>
    ///// 季
    ///// </summary>
    //public string? ColSeason { get; set; }

    ///// <summary>
    ///// 月
    ///// </summary>
    //public string? ColMonth { get; set; }

    /// <summary>
    /// 轉換價值
    /// </summary>
    public string? ColConValue { get; set; }

    /// <summary>
    /// 轉換(依轉換時間)
    /// </summary>
    public string? ColConByDate { get; set; }

    /// <summary>
    /// 單次轉換費用
    /// </summary>
    public string? ColConPerCost { get; set; }

    /// <summary>
    /// 轉換
    /// </summary>
    public string? ColCon { get; set; }

    /// <summary>
    /// 轉換率
    /// </summary>
    public string? ColConRate { get; set; }

    /// <summary>
    /// 點擊率
    /// </summary>
    public string? ColClicks { get; set; }

    /// <summary>
    /// 曝光數
    /// </summary>
    public string? ColImpressions { get; set; }

    /// <summary>
    /// CTR
    /// </summary>
    public string? ColCTR { get; set; }

    /// <summary>
    /// CPC
    /// </summary>
    public string? ColCPC { get; set; }

    /// <summary>
    /// 費用
    /// </summary>
    public string? ColCost { get; set; }

    /// <summary>
    /// 年齡
    /// </summary>
    public string? ColAge { get; set; }

    /// <summary>
    /// 性別
    /// </summary>
    public string? ColGender { get; set; }

    /// <summary>
    /// 地區
    /// </summary>
    public string? ColConstant { get; set; }

    /// <summary>
    /// 轉換動作
    /// </summary>
    public string? ColConAction { get; set; }

    /// <summary>
    /// CPA
    /// </summary>
    public string? ColCPA { get; set; }

    /// <summary>
    ///  廣告開始時間
    /// </summary>
    public string? ColStartDate { get; set; }

    /// <summary>
    /// 廣告結束時間
    /// </summary>
    public string? ColEndDate { get; set; }
}