using System.Security.Cryptography;

namespace Hydrido
{
    public class RsaWithRsaParameterKey
    {
        private RSAParameters _chavePublica;
        private RSAParameters _chavePrivada;

        public void AtribuirNovaChave()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                _chavePublica = rsa.ExportParameters(false);
                _chavePrivada = rsa.ExportParameters(true);
            }
        }

        public byte[] CriptografarDados(byte[] dadosParaCriptografar)
        {
            byte[] cipherbytes;

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(_chavePublica);

                cipherbytes = rsa.Encrypt(dadosParaCriptografar, true);
            }
            return cipherbytes;
        }

        public byte[] DescriptografarDados(byte[] dadosParaCriptografar)
        {
            byte[] plain;

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(_chavePrivada);
                plain = rsa.Decrypt(dadosParaCriptografar, true);
            }
            return plain;
        }

    }
}