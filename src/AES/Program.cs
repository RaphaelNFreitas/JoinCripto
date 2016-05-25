using System;
using System.Text;
using RamdomNumbers;
using static System.Console;

namespace AES
{
    class Program
    {
        static void Main()
        {
            var aes = new AesEncryption();
            var chave = NumerosAleatorios.GerarNumerosAletorios(32);
            var iv = NumerosAleatorios.GerarNumerosAletorios(16);
            const string ORIGINAL = "Texto para criptografar";

            var criptografado = aes.Criptografar(Encoding.UTF8.GetBytes(ORIGINAL), chave, iv);
            var descripotgrafado = aes.Descriptografar(criptografado, chave, iv);

            var mensagemDescriptografada = Encoding.UTF8.GetString(descripotgrafado);

            WriteLine("Demonstração da criptografia AES em .NET");
            WriteLine("-----------------------------------------------------------");
            WriteLine();
            WriteLine($"Texto original: {ORIGINAL}");
            WriteLine($"Texto criptografado: {Convert.ToBase64String(criptografado)}");
            WriteLine($"Texto descriptografado: {mensagemDescriptografada}");

            ReadKey();
        }
    }
}
