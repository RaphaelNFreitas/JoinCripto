using System;
using System.Text;
using static System.Console;
using static HashingAlgorithms.Hash;

namespace HashingAlgorithms
{
    class Program
    {
        static void Main()
        {
            const string MENSAGEM_ORIGINAL = "Mensagem original para hash";
            const string MENSAGEM_ORIGINAL2 = "Esta e outra mensagem de hash";

            WriteLine("Demonstraçao de hash seguro em .NET");
            WriteLine("---------------------------------------------------------------");
            WriteLine();
            WriteLine($"Mensagem original 1: {MENSAGEM_ORIGINAL}");
            WriteLine($"Mensagem original 2: {MENSAGEM_ORIGINAL2}");
            WriteLine();

            var mensagemHashedMd5 = Md5(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL));
            var mensagemHashedMd52 = Md5(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL2));

            WriteLine();
            WriteLine("--------------------- MD5 Hashes ------------------------------");
            WriteLine();
            WriteLine($"Message 1 hash = {Convert.ToBase64String(mensagemHashedMd5)}");
            WriteLine($"Message 2 hash = {Convert.ToBase64String(mensagemHashedMd52)}");

            var mensagemHashedSha1 = Sha1(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL));
            var mensagemHashedSha12 = Sha1(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL2));

            WriteLine();
            WriteLine("--------------------- SHA-1 Hashes ----------------------------");
            WriteLine();
            WriteLine($"Message 1 hash = {Convert.ToBase64String(mensagemHashedSha1)}");
            WriteLine($"Message 2 hash = {Convert.ToBase64String(mensagemHashedSha12)}");

            var mensagemHashedSha256 = Sha256(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL));
            var mensagemHashedSha2562 = Sha256(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL2));

            WriteLine();
            WriteLine("--------------------- SHA-256 Hashes ---------------------------");
            WriteLine();
            WriteLine($"Message 1 hash = {Convert.ToBase64String(mensagemHashedSha256)}");
            WriteLine($"Message 2 hash = {Convert.ToBase64String(mensagemHashedSha2562)}");

            var mensagemHashedSha512 = Sha512(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL));
            var mensagemHashedSha5122 = Sha512(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL2));

            WriteLine();
            WriteLine("--------------------- SHA-512 Hashes ---------------------------");
            WriteLine();
            WriteLine($"Message 1 hash = {Convert.ToBase64String(mensagemHashedSha512)}");
            WriteLine($"Message 2 hash = {Convert.ToBase64String(mensagemHashedSha5122)}");

            var mensagemHashedSha384 = Sha384(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL));
            var mensagemHashedSha3842 = Sha384(Encoding.UTF8.GetBytes(MENSAGEM_ORIGINAL2));

            WriteLine();
            WriteLine("--------------------- SHA-384 Hashes ---------------------------");
            WriteLine();
            WriteLine($"Message 1 hash = {Convert.ToBase64String(mensagemHashedSha384)}");
            WriteLine($"Message 2 hash = {Convert.ToBase64String(mensagemHashedSha3842)}");

            ReadKey();
        }
    }
}
