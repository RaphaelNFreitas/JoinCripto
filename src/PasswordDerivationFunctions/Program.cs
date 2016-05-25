using System;
using System.Diagnostics;
using System.Text;
using static System.Console;
using static PasswordDerivationFunctions.Pbkdf2;

namespace PasswordDerivationFunctions
{
    class Program
    {
        static void Main()
        {
            const string SENHA_HASH = "SenhaMuitoComplexa";

            WriteLine("Demonstração de senha baseado em defivação de função em .NET");
            WriteLine("----------------------------------------------------------------------------");
            WriteLine();
            WriteLine("PBKDF2 hashes");
            WriteLine();
            SenhaHash(SENHA_HASH, 100);
            SenhaHash(SENHA_HASH, 1000);
            SenhaHash(SENHA_HASH, 10000);
            SenhaHash(SENHA_HASH, 50000);
            SenhaHash(SENHA_HASH, 100000);
            SenhaHash(SENHA_HASH, 200000);
            SenhaHash(SENHA_HASH, 500000);

            ReadKey();
        }

        private static void SenhaHash(string senhaASer, int numeroDeRodadas)
        {
            var sw = new Stopwatch();
            sw.Start();

            var hashDaSenha = Pbkdf2.SenhaHash(Encoding.UTF8.GetBytes(senhaASer),
                                                    GerarSalt(),
                                                    numeroDeRodadas);

            sw.Stop();

            WriteLine();
            WriteLine($"Senha de hash: {senhaASer}");
            WriteLine($"Hash da senha: {Convert.ToBase64String(hashDaSenha)}");
            WriteLine($"Iterações <{numeroDeRodadas}> tempo gasto {sw.ElapsedMilliseconds}ms");
        }
    }
}
