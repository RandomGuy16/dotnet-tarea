using System.Security.Cryptography;
using System.Text;

namespace MiBotica.SolPedido.Utiles.Helpers;

public class EncriptacionHelper
{
    public static byte[] EncriptarByte(string rawText)
    {
        // Aes.Create() reemplaza RijndaelManaged (eliminado en .NET 8+).
        // Mismo algoritmo AES-CBC con PKCS7, misma clave/IV derivados de PBKDF2-SHA1,
        // por lo que los valores almacenados en la BD siguen siendo compatibles.
        using var aes = Aes.Create();
        byte[] rawTextData = Encoding.UTF8.GetBytes(rawText);
        Rfc2898DeriveBytes secretKey = GetSecretKey();

        aes.Key = secretKey.GetBytes(32);
        aes.IV  = secretKey.GetBytes(16);

        using var encryptor    = aes.CreateEncryptor();
        using var memoryStream = new MemoryStream();
        using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

        cryptoStream.Write(rawTextData, 0, rawTextData.Length);
        cryptoStream.FlushFinalBlock();
        return memoryStream.ToArray();
    }
    
    private static Rfc2898DeriveBytes GetSecretKey()
    {
        const string encryptionKey = "T@ll3rN3t2018";
        byte[] salt = Encoding.UTF8.GetBytes(encryptionKey);
        var secretKey = new Rfc2898DeriveBytes(encryptionKey, salt);
        return secretKey;
    }
}