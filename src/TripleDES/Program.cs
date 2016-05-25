using System;
using System.Text;
using RamdomNumbers;
using static System.Console;

namespace TripleDES
{
    class Program
    {
        static void Main()
        {
            var tripleDes = new TripleDesEncryption();
            var chave = NumerosAleatorios.GerarNumerosAletorios(24);
            var iv = NumerosAleatorios.GerarNumerosAletorios(8);

            const string ORIGINAL = "Texto para criptografar";

            var criptografado = tripleDes.Criptografar(Encoding.UTF8.GetBytes(ORIGINAL), chave, iv);
            var descriptografado = tripleDes.Descripografar(criptografado, chave, iv);

            var mensagemDescriptografada = Encoding.UTF8.GetString(descriptografado);

            WriteLine("Demonstração da criptografia triple DES em .NET");
            WriteLine("-----------------------------------------------------------------------");
            WriteLine();
            WriteLine($"Texto original: {ORIGINAL}");
            WriteLine($"Texto criptografado: {Convert.ToBase64String(criptografado)}");
            WriteLine($"Texto descriptografado: {mensagemDescriptografada}");

            ReadKey();
        }
    }
}
