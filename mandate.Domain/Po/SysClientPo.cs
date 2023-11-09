using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

/// <summary>
/// 待註解
/// </summary>
[Table("sys_client")]
public class SysClientPo
{
    /// <summary>
    /// 待註解
    /// </summary>
    [Key]
    public int client_no { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string client_id { get; set; } = null!;

    /// <summary>
    /// 待註解
    /// </summary>
    public string client_name { get; set; } = null!;

    /// <summary>
    /// 待註解
    /// </summary>
    public string? client_taxID { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? client_phone { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? client_address { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? client_contact { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? edit_cname { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public DateTime? edit_date { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? creat_cname { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public DateTime? creat_date { get; set; }

    /// <summary>
    /// 待註解
    /// </summary>
    public string? client_status { get; set; }


}