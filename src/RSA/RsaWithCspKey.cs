using System.Security.Cryptography;

namespace RSA
{
    public class RsaWithCspKey
    {
        private const string NOME_DO_CONTAINER = "MeuContainer";

        public void AtribuirNovaChave()
        {
            const int PROVEDOR_COMPLETO_RSA = 1;

            var cspParameters = new CspParameters(PROVEDOR_COMPLETO_RSA)
            {
                KeyContainerName = NOME_DO_CONTAINER,
                Flags = CspProviderFlags.UseMachineKeyStore,
                ProviderName = "Microsoft Strong Cryptographic Provider"
            };

            var rsa = new RSACryptoServiceProvider(cspParameters)
            {
                PersistKeyInCsp = true
            };
        }

        public void RemoveChaveEmCsp()
        {
            var cspParameters = new CspParameters()
            {
                KeyContainerName = NOME_DO_CONTAINER
            };
            var rsa = new RSACryptoServiceProvider(cspParameters)
            {
                PersistKeyInCsp = false,
            };

            rsa.Clear();
        }

        public byte[] CriptografarDados(byte[] dadosParaCriptografar)
        {
            byte[] cipherBytes;

            var cspParameters = new CspParameters()
            {
                KeyContainerName = NOME_DO_CONTAINER
            };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParameters))
            {
                cipherBytes = rsa.Encrypt(dadosParaCriptografar, false);
            }
            return cipherBytes;
        }

        public byte[] DescriptografarDados(byte[] dadosParaDescriptografar)
        {
            byte[] plain;

            var cspParameters = new CspParameters()
            {
                KeyContainerName = NOME_DO_CONTAINER
            };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParameters))
            {
                plain = rsa.Decrypt(dadosParaDescriptografar, false);
            }

            return plain;
        }
    }
}