using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

/// <summary>
/// 待註解
/// </summary>
[Table("SysClient")]
public class SysClientPo
{
    /// <summary>
    /// 待註解
    /// </summary>
    [Key]
    public int ClientNo { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string ClientId { get; set; } = null!;

    /// <summary>
    /// 待註解
    /// </summary>
    public string ClientName { get; set; } = null!;

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ClientTaxID { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ClientPhone { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ClientAddress { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? ClientContact { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? Editer { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public DateTime? EditDate { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? Creater { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public DateTime? CreateDate { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public bool? ClientStatus { get; set; }
}