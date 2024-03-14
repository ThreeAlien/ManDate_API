using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mandate.Domain.Po;

/// <summary>
/// 權限資訊
/// </summary>
[Table("SysUser")]
public class SysUserPo
{
    /// <summary>
    /// 編號
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserNo { get; set; }

    /// <summary>
    /// 使用者帳戶
    /// </summary>
    public string? UserAccount { get; set; }

    /// <summary>
    /// 使用者密碼
    /// </summary>
    public string? UserPassword { get; set; }

    /// <summary>
    /// 使用者id
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// 使用者部門
    /// </summary>
    public string? UserDepartment { get; set; }

    /// <summary>
    /// 與用者中文名
    /// </summary>
    public string? UserCname { get; set; }

    /// <summary>
    /// 使用英文名
    /// </summary>
    public string? UserEname { get; set; }

    /// <summary>
    /// 使用者層級
    /// </summary>
    public string? UserLv { get; set; }

    /// <summary>
    /// 編輯者
    /// </summary>
    public string? Editer { get; set; }

    /// <summary>
    /// 編輯日期
    /// </summary>
    public DateTime? EditDate { get; set; }

    /// <summary>
    /// 創建者
    /// </summary>
    public string? Creater { get; set; }

    /// <summary>
    /// 創建日期
    /// </summary>
    public DateTime? CreateDate { get; set; }

    /// <summary>
    /// 狀態
    /// </summary>
    public bool? UserStatus { get; set; }
}