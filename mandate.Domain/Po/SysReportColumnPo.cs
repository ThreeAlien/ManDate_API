using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

/// <summary>
/// 報表欄位是否執行
/// </summary>
[Table("SysReportColumn")]
public class SysReportColumnPo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReportNo { get; set; }

    public bool? IsColAccount { get; set; }

    public bool? IsColCutomerID { get; set; }

    public bool? IsColCampaignName { get; set; }

    public bool? IsColAdGroupName { get; set; }

    public bool? IsColAdFinalURL { get; set; }

    public bool? IsColHeadline { get; set; }

    public bool? IsColHeadLine_1 { get; set; }

    public bool? IsColHeadLine_2 { get; set; }

    public bool? IsColDirections { get; set; }

    public bool? IsColDirections_1 { get; set; }

    public bool? IsColDirections_2 { get; set; }

    public bool? IsColAdName { get; set; }


    public bool? IsColSrchKeyWord { get; set; }

    public bool? IsColConGoal { get; set; }

    public bool? IsColConValue { get; set; }

    public bool? IsColConByDate { get; set; }

    public bool? IsColConPerCost { get; set; }

    public bool? IsColCon { get; set; }

    public bool? IsColConRate { get; set; }

    public bool? IsColClicks { get; set; }

    public bool? IsColImpressions { get; set; }

    public bool? IsColCTR { get; set; }

    public bool? IsColCPC { get; set; }

    public bool? IsColCost { get; set; }

    public string ContentId { get; set; } = null!;

    public string ColumnId { get; set; } = null!;

    public bool? IsColAge { get; set; }

    public bool? IsColGender { get; set; }

    public bool? IsColConstant { get; set; }

    public bool? IsColConAction { get; set; }

    public bool? IsColCPA { get; set; }

    public bool? IsColStartDate { get; set; }

    public bool? IsColEndDate { get; set; }

    public string? ContentSort { get; set; } = null!;

    /// <summary>
    /// 是否為預設欄位
    /// </summary>
    public bool? IsDefault { get; set; }
}