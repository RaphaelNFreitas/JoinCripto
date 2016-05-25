using System.IO;
using System.Security.Cryptography;

namespace Hydrido
{
    public class AesEncryption
    {
        public byte[] Criptografar(byte[] dadosParaCriptografar, byte[] chave, byte[] iv)
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = chave;
                aes.IV = iv;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream,
                                                        aes.CreateEncryptor(),
                                                        CryptoStreamMode.Write);

                    cryptoStream.Write(dadosParaCriptografar, 0, dadosParaCriptografar.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }

        public byte[] Descriptografar(byte[] dadosParaDescriptografar, byte[] chave, byte[] iv)
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = chave;
                aes.IV = iv;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream,
                                                        aes.CreateDecryptor(),
                                                        CryptoStreamMode.Write);

                    cryptoStream.Write(dadosParaDescriptografar, 0, dadosParaDescriptografar.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }
    }
}