using System.Security.Cryptography;
using System.Text;

namespace mandate.Utility.Crypto;

public class AESHelper
{
    /// <summary>
    /// 加密
    /// </summary>
    /// <param name="key"></param>
    /// <param name="iv"></param>
    /// <param name="cipherText"></param>
    /// <returns></returns>
    public static string Encrypt(string key, string iv, string cipherText)
    {
        using (MemoryStream sourceStream = new MemoryStream(Encoding.UTF8.GetBytes(cipherText)))
        {
            Aes aes = Aes.Create();
            SHA256 sha256 = SHA256.Create();
            SHA384 sha384 = SHA384.Create();

            byte[] aesKey = sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
            byte[] aesIV = sha384.ComputeHash(Encoding.UTF8.GetBytes(iv));

            aes.Key = aesKey;
            aes.IV = new byte[aesIV.Length - 32];
            aes.Mode = CipherMode.CBC;

            ICryptoTransform encryptor = aes.CreateEncryptor();

            byte[]? result = null;
            using (MemoryStream encryptedStream = new MemoryStream())
            using (CryptoStream cstream = new CryptoStream(sourceStream, encryptor, CryptoStreamMode.Read))
            {
                int length = 0;
                byte[] buffer = new byte[1024 * 256];

                while ((length = cstream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    encryptedStream.Write(buffer, 0, length);
                }

                aes.Clear();
                sha256.Clear();
                sha384.Clear();

                result = encryptedStream.ToArray();
            }
            return Convert.ToBase64String(result);
        }
    }

    /// <summary>
    /// 解密
    /// </summary>
    /// <param name="key"></param>
    /// <param name="iv"></param>
    /// <param name="cipherText"></param>
    /// <returns></returns>
    public static string Decrypt(string key, string iv, string cipherText)
    {
        // 避免二次編碼故在此轉換字元
        cipherText = cipherText.Replace(" ", "+");

        using (MemoryStream sourceStream = new MemoryStream(Convert.FromBase64String(cipherText)))
        {
            byte[]? result = null;
            Aes aes = Aes.Create();
            SHA256 sha256 = SHA256.Create();
            SHA384 sha384 = SHA384.Create();

            byte[] aesKey = sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
            byte[] aesIV = sha384.ComputeHash(Encoding.UTF8.GetBytes(iv));

            aes.Key = aesKey;
            aes.IV = new byte[aesIV.Length - 32];
            aes.Mode = CipherMode.CBC;

            ICryptoTransform decryptor = aes.CreateDecryptor();

            using (MemoryStream descryptedStream = new MemoryStream())
            using (CryptoStream cstream = new CryptoStream(sourceStream, decryptor, CryptoStreamMode.Read))
            {
                int length = 0;
                byte[] buffer = new byte[1024 * 256];

                while ((length = cstream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    descryptedStream.Write(buffer, 0, length);
                }

                aes.Clear();
                sha256.Clear();
                sha384.Clear();

                result = descryptedStream.ToArray();
                cstream.Clear();
                descryptedStream.Dispose();
                sourceStream.Dispose();
            }
            return Encoding.UTF8.GetString(result);
        }
    }
}