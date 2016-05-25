using System.Security.Cryptography;
using System.Text;
using RamdomNumbers;
using static System.Console;

namespace HybridWithIntegrity
{
    class Program
    {
        static void Main()
        {
            const string ORIGINAL = "Muito secreto, as informações importantes que não pode cair nas mãos erradas.";

            var rsaParams = new RsaWithRsaParameterKey();
            rsaParams.AtribuirNovaChave();

            WriteLine("Demonstração de criptografia hibrida com integridade em .NET");
            WriteLine("-------------------------------------------------------------------------");
            WriteLine();

            try
            {
                var blocoCriptografado = CriptografarDados(ORIGINAL, rsaParams);
                var descriptografado = DescriptografarDados(blocoCriptografado, rsaParams);

                WriteLine($"Mensagem original: {ORIGINAL}");
                WriteLine();
                WriteLine($"Mensagem depois de descriptografada: {descriptografado}");
            }
            catch (CryptographicException exception)
            {
                WriteLine($"Error: {exception.Message}");
            }

            ReadKey();
        }

        private static string DescriptografarDados(PacoteCriptografado blocoCriptografado, RsaWithRsaParameterKey rsaParams)
        {
            var aes = new AesEncryption();

            var sessaoDaChaveDescriptografada =
                rsaParams.DescriptografarDados(blocoCriptografado.ChaveDaSessaoCriptografada);

            using (var hmac = new HMACSHA256(sessaoDaChaveDescriptografada))
            {
                var hmacParaVerificar = hmac.ComputeHash(blocoCriptografado.DadosCriptografados);

                if (!Compare(blocoCriptografado.Hmac, hmacParaVerificar))
                    throw new CryptographicException("HMAC para a descodificação não corresponde pacote criptografado.");
            }

            var dadosDescriptografados = aes.Descriptografar(blocoCriptografado.DadosCriptografados,
                sessaoDaChaveDescriptografada, blocoCriptografado.Iv);

            return Encoding.UTF8.GetString(dadosDescriptografados);
        }

        private static bool Compare(byte[] hmac, byte[] hmacParaVerificar)
        {
            var resultado = hmac.Length == hmacParaVerificar.Length;

            for (var i = 0; i < hmac.Length && i < hmacParaVerificar.Length; ++i)
            {
                resultado &= hmac[i] == hmacParaVerificar[i];
            }
            return resultado;
        }

        private static PacoteCriptografado CriptografarDados(string original, RsaWithRsaParameterKey rsaParams)
        {
            var aes = new AesEncryption();

            var sessaoDaChave = NumerosAleatorios.GerarNumerosAletorios(32);
            var pacoteCriptografado = new PacoteCriptografado
            {
                Iv = NumerosAleatorios.GerarNumerosAletorios(16)
            };

            pacoteCriptografado.DadosCriptografados = aes.Criptografar(Encoding.UTF8.GetBytes(original), sessaoDaChave,
                pacoteCriptografado.Iv);

            pacoteCriptografado.ChaveDaSessaoCriptografada = rsaParams.CriptografarDados(sessaoDaChave);

            using (var hmac = new HMACSHA256(sessaoDaChave))
            {
                pacoteCriptografado.Hmac = hmac.ComputeHash(pacoteCriptografado.DadosCriptografados);
            }

            return pacoteCriptografado;
        }
    }
}
