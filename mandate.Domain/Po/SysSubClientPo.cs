using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

/// <summary>
/// 子客戶資料表
/// </summary>
[Table("SysSubClient")]
public class SysSubClientPo
{
    /// <summary>
    /// 客戶流水號
    /// </summary>
    [Key]
    public int SubNo { get; set; }

    /// <summary>
    /// 子帳戶ID
    /// </summary>
    public string? SubId { get; set; }

    /// <summary>
    /// 子帳戶名稱
    /// </summary>
    public string? SubName { get; set; }

    /// <summary>
    /// 客戶ID
    /// </summary>
    public string? ClientId { get; set; }

    /// <summary>
    /// 客戶名稱
    /// </summary>
    public string ClientName { get; set; } = null!;
}
