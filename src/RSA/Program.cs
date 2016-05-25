using System;
using System.Text;
using static System.Console;

namespace RSA
{
    class Program
    {
        static void Main()
        {
            var rsa= new RsaWithXmlKkey();
            var rsaCsp = new RsaWithCspKey();
            var rsaParams = new RsaWithRsaParameterKey();

            const string ORIGINAL = "Texto para criptografar";
            const string CAMINHO_DA_CHAVE_PUBLICA = "c:\\temp\\chavepublica.xml";
            const string CAMINHO_DA_CHAVE_PRIVADA = "c:\\temp\\chaveprivada.xml";

            rsa.AtribuirNovaChave(CAMINHO_DA_CHAVE_PUBLICA, CAMINHO_DA_CHAVE_PRIVADA);
            var criptografado = rsa.CriptografarDados(CAMINHO_DA_CHAVE_PUBLICA, Encoding.UTF8.GetBytes(ORIGINAL));
            var descriptografado = rsa.DescriptografarDados(CAMINHO_DA_CHAVE_PRIVADA, criptografado);

            rsaCsp.AtribuirNovaChave();
            var cspCriptografado = rsaCsp.CriptografarDados(Encoding.UTF8.GetBytes(ORIGINAL));
            var cspDescriptografado = rsaCsp.DescriptografarDados(cspCriptografado);
            rsaCsp.RemoveChaveEmCsp();

            rsaParams.AtribuirNovaChave();
            var rsaParamsCriptografado = rsaParams.CriptografarDados(Encoding.UTF8.GetBytes(ORIGINAL));
            var rsaParamsDescriptografado = rsaParams.DescriptografarDados(rsaParamsCriptografado);

            WriteLine("Demonstração da criptografia RSA em .NET");
            WriteLine("----------------------------------------------------------------------------");
            WriteLine();
            WriteLine("Chave em memoria");
            WriteLine();
            WriteLine($"Texto original: {ORIGINAL}");
            WriteLine();
            WriteLine($"Texto criptografado: {Convert.ToBase64String(rsaParamsCriptografado)}");
            WriteLine();
            WriteLine($"Texto descriptografado: {Convert.ToBase64String(rsaParamsDescriptografado)}");
            WriteLine();
            WriteLine();
            WriteLine("Chave baseada em xml");
            WriteLine();
            WriteLine($"Texto original: {ORIGINAL}");
            WriteLine();
            WriteLine($"Texto criptografado: {Convert.ToBase64String(criptografado)}");
            WriteLine();
            WriteLine($"Texto descriptografado: {Convert.ToBase64String(descriptografado)}");
            WriteLine();
            WriteLine();
            WriteLine("Chave baseado em CSP");
            WriteLine();
            WriteLine($"Texto original: {ORIGINAL}");
            WriteLine();
            WriteLine($"Texto criptografado: {Convert.ToBase64String(cspCriptografado)}");
            WriteLine();
            WriteLine($"Texto descriptografado: {Convert.ToBase64String(cspDescriptografado)}");
            WriteLine();
            WriteLine();


            ReadKey();
        }
    }
}
