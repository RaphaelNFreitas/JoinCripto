using System.IO;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace RSA
{
    public class RsaWithXmlKkey
    {
        public void AtribuirNovaChave(string caminhoDaChavePublica, string caminhoDaChavePrivada)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                if (File.Exists(caminhoDaChavePrivada))
                    File.Delete(caminhoDaChavePrivada);

                if (File.Exists(caminhoDaChavePublica))
                    File.Delete(caminhoDaChavePublica);

                var pastaDaChavePublica = Path.GetDirectoryName(caminhoDaChavePublica);
                var pastaDaChavePrivada = Path.GetDirectoryName(caminhoDaChavePrivada);

                if (!Directory.Exists(pastaDaChavePublica))
                    Directory.CreateDirectory(pastaDaChavePublica);

                if (!Directory.Exists(pastaDaChavePrivada))
                    Directory.CreateDirectory(pastaDaChavePrivada);

                var chavePublica = rsa.ToXmlString(false);
                var chavePrivada = rsa.ToXmlString(true);

                File.WriteAllText(caminhoDaChavePublica,chavePublica);
                File.WriteAllText(caminhoDaChavePrivada,chavePrivada);
            }
        }

        public byte[] CriptografarDados(string caminhoDaChavePublica, byte[] dadosParaCriptografar)
        {
            byte[] cipherBytes;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXmlString(File.ReadAllText(caminhoDaChavePublica));

                cipherBytes = rsa.Encrypt(dadosParaCriptografar, false);
            }
            return cipherBytes;
        }

        public byte[] DescriptografarDados(string caminhoDaChavePrivada, byte[] dadosParaDescriptografar)
        {
            byte[] plain;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXmlString(File.ReadAllText(caminhoDaChavePrivada));
                plain = rsa.Decrypt(dadosParaDescriptografar, false);
            }
            return plain;
        }
    }
}