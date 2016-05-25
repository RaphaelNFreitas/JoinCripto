using System;
using System.Text;
using RamdomNumbers;
using static System.Console;

namespace DataEncryotionStandard
{
    class Program
    {
        static void Main()
        {
            var des = new DesEncryption();
            var chave = NumerosAleatorios.GerarNumerosAletorios(8);
            var iv = NumerosAleatorios.GerarNumerosAletorios(8);

            const string ORIGINAL = "Texto para criptografar";

            var criptogradado = des.Criptografar(Encoding.UTF8.GetBytes(ORIGINAL), chave, iv);
            var descriptografado = des.Descriptografar(criptogradado, chave, iv);

            var mensagemDescriptografada = Encoding.UTF8.GetString(descriptografado);

            WriteLine("Demostraçao de criptografia DES em .NET");
            WriteLine("-----------------------------------------------------------------");
            WriteLine();
            WriteLine($"Texto original: {ORIGINAL}");
            WriteLine($"Texto criptografado: {Convert.ToBase64String(criptogradado)}");
            WriteLine($"Texto descriptografado: {mensagemDescriptografada}");

            ReadKey();
        }
    }
}
