using System;
using System.Text;
using static System.Console;
using static MessageAuthentication.Hash;

namespace MessageAuthentication
{
    class Program
    {
        static void Main()
        {
            const string MENSAGEM_ORIGINAL = "Mensagem original para hash";
            const string MENSAGEM_ORIGINAL2 = "Esta e outra mensagem de hash";

            WriteLine("Demonstração HMAC em .NET");
            WriteLine("--------------------------------------------------------------------");
            WriteLine($"Mensagem original 1: {MENSAGEM_ORIGINAL}");
            WriteLine($"Mensagem original 2: {MENSAGEM_ORIGINAL2}");
            WriteLine();

            var chave = GerarChave();

            WriteLine("---------------------- Chave ---------------------------------------");
            WriteLine($"Chave gerada: {Convert.ToBase64String(chave)}");
            WriteLine();

            var sha1Mensagem = CalcularHmacSha1(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL), chave);
            var sha1Mensagem2 = CalcularHmacSha1(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL2), chave);

            WriteLine("-------------------------- SHA-1 -----------------------------------");
            WriteLine($"Mensagem 1: {Convert.ToBase64String(sha1Mensagem)}");
            WriteLine($"Mensagem 2: {Convert.ToBase64String(sha1Mensagem2)}");
            WriteLine();

            var sha256Mensagem = CalcularHmacSha1(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL), chave);
            var sha256Mensagem2 = CalcularHmacSha1(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL2), chave);

            WriteLine("-------------------------- SHA-256 ----------------------------------");
            WriteLine($"Mensagem 1: {Convert.ToBase64String(sha256Mensagem)}");
            WriteLine($"Mensagem 2: {Convert.ToBase64String(sha256Mensagem2)}");
            WriteLine();

            var sha512Mensagem = CalcularHmacSha1(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL), chave);
            var sha512Mensagem2 = CalcularHmacSha1(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL2), chave);

            WriteLine("-------------------------- SHA-512 ---------------------------------");
            WriteLine($"Mensagem 1: {Convert.ToBase64String(sha512Mensagem)}");
            WriteLine($"Mensagem 2: {Convert.ToBase64String(sha512Mensagem2)}");

            var sha384Mensagem = CalcularHmacSha1(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL), chave);
            var sha384Mensagem2 = CalcularHmacSha1(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL2), chave);
           
            WriteLine("-------------------------- SHA-384 ---------------------------------");
            WriteLine($"Mensagem 1: {Convert.ToBase64String(sha384Mensagem)}");
            WriteLine($"Mensagem 2: {Convert.ToBase64String(sha384Mensagem2)}");
            WriteLine();

            var md5Mensagem = CalcularHmacSha1(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL), chave);
            var md5Mensagem2 = CalcularHmacSha1(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL2), chave);

            WriteLine("-------------------------- MD5 -------------------------------------");
            WriteLine($"Mensagem 1: {Convert.ToBase64String(md5Mensagem)}");
            WriteLine($"Mensagem 2: {Convert.ToBase64String(md5Mensagem2)}");
            WriteLine();

            ReadKey();
        }
    }
}
