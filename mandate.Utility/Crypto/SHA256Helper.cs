using System.Security.Cryptography;
using System.Text;

namespace mandate.Utility.Crypto;

public static class SHA256Helper
{
    /// <summary>
    /// 轉換成SHA256格式(Unicode)
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string ToSHA256String(this string source)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            return Convert.ToHexString(sha256.ComputeHash(Encoding.Unicode.GetBytes(source))).ToLower();
        }
    }

    /// <summary>
    /// 轉換成SHA256格式(ANSI)
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string ToAnsiSHA256String(this string source)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            return Convert.ToHexString(sha256.ComputeHash(Encoding.Default.GetBytes(source))).ToLower();
        }
    }
}
