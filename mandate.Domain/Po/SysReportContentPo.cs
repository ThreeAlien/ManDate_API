using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

/// <summary>
/// 待註解
/// </summary>
[Table("SysReportContent")]
public class SysReportContentPo
{
    /// <summary>
    /// 報表內容流水編號
    /// </summary>
    [Key]
    public int ContentNo { get; set; }

    /// <summary>
    /// 報表內容ID
    /// </summary>
    public string ContentID { get; set; } = null!;

    /// <summary>
    /// 報表內容名稱
    /// </summary>
    public string ContentName { get; set; } = null!;

    /// <summary>
    /// 報表內容排序
    /// </summary>
    public string? ContentSort { get; set; }

}