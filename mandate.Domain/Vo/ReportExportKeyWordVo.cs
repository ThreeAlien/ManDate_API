namespace mandate.Domain.Vo;

/// <summary>
/// 報表匯出 - 關鍵字 Vo
/// </summary>
public class ReportExportKeyWordVo
{
    /// <summary>
    /// 廣告活動
    /// </summary>
    public string? CampaignName { get; set; }

    /// <summary>
    /// 廣告群組
    /// </summary>
    public string? AdGroupName { get; set; }

    /// <summary>
    /// 關鍵字
    /// </summary>
    public string? ColSrchKeyWord { get; set; }

    /// <summary>
    /// 曝光數
    /// </summary>
    public int Impressions { get; set; }

    /// <summary>
    /// 點擊數
    /// </summary>
    public int Click { get; set; }

    /// <summary>
    /// 點閱率
    /// </summary>
    public string? CTR { get; set; }

    /// <summary>
    /// CPC
    /// </summary>
    public double CPC { get; set; }

    /// <summary>
    /// 費用
    /// </summary>
    public double Cost { get; set; }
}
