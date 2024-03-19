namespace mandate.Business.Models;

/// <summary>
/// 取得權限 Result
/// </summary>
public class GetAccessRoleResult
{
    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// 權限
    /// </summary>
    public string AccessRole { get; set; } = null!;
}