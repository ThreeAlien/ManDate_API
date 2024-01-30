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

    public bool? IsColShortHeadLine { get; set; }

    public bool? IsColLongHeadLine { get; set; }

    public bool? IsColHeadLine_1 { get; set; }

    public bool? IsColHeadLine_2 { get; set; }

    public bool? IsColDirections { get; set; }

    public bool? IsColDirections_1 { get; set; }

    public bool? IsColDirections_2 { get; set; }

    public bool? IsColAdName { get; set; }

    public bool? IsColAdPath_1 { get; set; }

    public bool? IsColAdPath_2 { get; set; }

    public bool? IsColSrchKeyWord { get; set; }

    public bool? IsColSwitchTarget { get; set; }

    public bool? IsColDateTime { get; set; }

    public bool? IsColWeek { get; set; }

    public bool? IsColSeason { get; set; }

    public bool? IsColMonth { get; set; }

    public bool? IsColIncome { get; set; }

    public bool? IsColTransTime { get; set; }

    public bool? IsColTransCostOnce { get; set; }

    public bool? IsColTrans { get; set; }

    public bool? IsColTransRate { get; set; }

    public bool? IsColClick { get; set; }

    public bool? IsColImpression { get; set; }

    public bool? IsColCTR { get; set; }

    public bool? IsColCPC { get; set; }

    public bool? IsColCost { get; set; }

    public string ContentId { get; set; } = null!;

    public string ColumnId { get; set; } = null!;

    public bool? IsColAge { get; set; }

    public bool? IsColSex { get; set; }

    public bool? IsColRegion { get; set; }

    public string? ContentSort { get; set; } = null!;
}