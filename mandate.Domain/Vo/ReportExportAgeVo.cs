namespace mandate.Domain.Vo;

/// <summary>
/// 報表匯出 - 年齡 Vo
/// </summary>
public class ReportExportAgeVo
{
    /// <summary>
    /// 年齡
    /// </summary>
    public string? Age { get; set; }

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