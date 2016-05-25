using System;
using System.Security.Cryptography;
using System.Text;
using static System.Console;

namespace DigitalSignature
{
    class Program
    {
        static void Main()
        {
            var documento = Encoding.UTF8.GetBytes("Documento para assinar");
            byte[] hashDoDocumento;

            using (var sha256 = SHA256.Create())
            {
                hashDoDocumento = sha256.ComputeHash(documento);
            }

            var assinaturaDigital = new DigitalSignature();
            assinaturaDigital.AtribuirNovaChave();

            var assinatura = assinaturaDigital.AssinarDados(hashDoDocumento);
            var verificado = assinaturaDigital.VerificarAssinatura(hashDoDocumento, assinatura);

            WriteLine("Demonstração de assinatura digital em .NET");
            WriteLine("-----------------------------------------------------------------------");
            WriteLine();
            WriteLine();
            WriteLine($"Texto original: {Encoding.Default.GetString(documento)}");
            WriteLine();
            WriteLine($"Assinatura digital: {Convert.ToBase64String(assinatura)}");
            WriteLine();

            WriteLine(verificado
                ? "A assinatura digital foi correctamente verificado."
                : "A assinatura digital não foi correctamente verificada.");

            ReadKey();

        }
    }
}
