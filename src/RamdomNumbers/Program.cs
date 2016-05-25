using System;
using static System.Console;

namespace RamdomNumbers
{
    class Program
    {
        static void Main()
        {

            WriteLine("Demostraçao de numeros aleatorio em .NET");
            WriteLine("-----------------------------------------------------------------------------");

            for (var i = 0; i < 10; i++)
            {
                WriteLine($"Numero aleatorio {i}: {Convert.ToBase64String(NumerosAleatorios.GerarNumerosAletorios(32))} ");
            }

            ReadKey();
        }
    }
}
