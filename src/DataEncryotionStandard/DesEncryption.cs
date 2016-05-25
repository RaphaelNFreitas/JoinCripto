using System.IO;
using System.Security.Cryptography;

namespace DataEncryotionStandard
{
    public class DesEncryption
    {
        public byte[] Criptografar(byte[] dadosParaCriptografar, byte[] chave, byte[] iv)
        {
            using (var des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;

                des.Key = chave;
                des.IV = iv;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream,
                                                        des.CreateEncryptor(),
                                                        CryptoStreamMode.Write);

                    cryptoStream.Write(dadosParaCriptografar,0,dadosParaCriptografar.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }

        public byte[] Descriptografar(byte[] dadosParaDescriptografar, byte[] chave, byte[] iv)
        {
            using (var des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;

                des.Key = chave;
                des.IV = iv;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream,
                                                        des.CreateDecryptor(),
                                                        CryptoStreamMode.Write);

                    cryptoStream.Write(dadosParaDescriptografar,0,dadosParaDescriptografar.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }
    }
}