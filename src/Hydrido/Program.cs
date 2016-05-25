using System.Text;
using RamdomNumbers;
using static System.Console;

namespace Hydrido
{
    class Program
    {
        static void Main()
        {
            const string ORIGINAL = "Muito secreto, as informações importantes que não pode cair nas mãos erradas.";

            var rsaParams = new RsaWithRsaParameterKey();
            rsaParams.AtribuirNovaChave();

            var blocoCriptografado = CriptografarDados(ORIGINAL, rsaParams);
            var descriptografado = DescriptografarDados(blocoCriptografado, rsaParams);

            WriteLine("Demostração de criptografica hidrida em .NET");
            WriteLine("--------------------------------------------------------------------");
            WriteLine();
            WriteLine($"Mensagem original: {ORIGINAL}");
            WriteLine();
            WriteLine($"Mensagem depois da descriptografia: {descriptografado}");
            WriteLine();

            ReadKey();
        }

        private static string DescriptografarDados(PacoteCriptografado blocoCriptografado, RsaWithRsaParameterKey rsaParams)
        {
            var aes = new AesEncryption();

            var sessaoDaChaveDescriptografada =
                rsaParams.DescriptografarDados(blocoCriptografado.ChaveDaSessaoCriptografada);
            var dadosDescriptografado = aes.Descriptografar(blocoCriptografado.DadosCriptografados,
                sessaoDaChaveDescriptografada,blocoCriptografado.Iv);

            return Encoding.UTF8.GetString(dadosDescriptografado);
        }

        private static PacoteCriptografado CriptografarDados(string original, RsaWithRsaParameterKey rsaParams)
        {
            var aes = new AesEncryption();
            var sessaoDaChave = NumerosAleatorios.GerarNumerosAletorios(32);
            var encryptedPacket = new PacoteCriptografado
            {
                Iv = NumerosAleatorios.GerarNumerosAletorios(16)
            };

            encryptedPacket.DadosCriptografados = aes.Criptografar(Encoding.UTF8.GetBytes(original), sessaoDaChave,
                encryptedPacket.Iv);
            encryptedPacket.ChaveDaSessaoCriptografada = rsaParams.CriptografarDados(sessaoDaChave);

            return encryptedPacket;
        }
    }
}
