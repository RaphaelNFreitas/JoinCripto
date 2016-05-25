using System;
using System.Text;
using static System.Console;

namespace PasswordStorage
{
    class Program
    {
        static void Main()
        {
            const string PASSWORD = "V3ryC0mpl3xP455w0rd";
            var salt = Hash.GerarSalt();

            WriteLine("Demonstração de senhas com salt em .NET");
            WriteLine("-------------------------------------------------------------");
            WriteLine();
            WriteLine($"Senha original: {PASSWORD}");
            WriteLine($"Salt: {Convert.ToBase64String(salt)}");
            WriteLine();

            var senhaHash = Hash.SenhaHashComSalt(Encoding.UTF8.GetBytes(PASSWORD), salt);

            WriteLine($"Senha hash: {Convert.ToBase64String(senhaHash)}");

           

            ReadKey();
        }
    }
}
