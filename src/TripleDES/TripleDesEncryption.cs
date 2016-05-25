using System.IO;
using System.Security.Cryptography;

namespace TripleDES
{
    public class TripleDesEncryption
    {
        public byte[] Criptografar(byte[] dadosParaCripgrafar, byte[] chave, byte[] iv)
        {
            using (var des = new TripleDESCryptoServiceProvider())
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

                    cryptoStream.Write(dadosParaCripgrafar,0,dadosParaCripgrafar.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }

        public byte[] Descripografar(byte[] dadosParaDescriptografar, byte[] chave,byte[] iv)
        {
            using (var des = new TripleDESCryptoServiceProvider())
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