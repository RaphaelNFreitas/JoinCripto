using System.Security.Cryptography;

namespace DigitalSignature
{
    public class DigitalSignature
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

        public byte[] AssinarDados(byte[] hashDeDadosParaAssinar)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(_chavePrivada);
                var rsaFormato = new RSAPKCS1SignatureFormatter(rsa);
                rsaFormato.SetHashAlgorithm("SHA256");

                return rsaFormato.CreateSignature(hashDeDadosParaAssinar);
            }
        }

        public bool VerificarAssinatura(byte[] hashDeDadosParaAssinar, byte[] assinatura)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.ImportParameters(_chavePublica);

                var rsaDesformato = new RSAPKCS1SignatureDeformatter(rsa);
                rsaDesformato.SetHashAlgorithm("SHA256");

                return rsaDesformato.VerifySignature(hashDeDadosParaAssinar, assinatura);
            }
        }
    }
}