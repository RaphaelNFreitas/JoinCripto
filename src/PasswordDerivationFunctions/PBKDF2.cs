using System.Security.Cryptography;

namespace PasswordDerivationFunctions
{
    public static class Pbkdf2
    {
        public static byte[] GerarSalt()
        {
            using (var gerarNumeroAleatorio = new RNGCryptoServiceProvider())
            {
                var numeroAleatorio = new byte[32];
                gerarNumeroAleatorio.GetBytes(numeroAleatorio);
                return numeroAleatorio;
            }
        }

        public static byte[] SenhaHash(byte[] passaASer, byte[] salt, int numeroDeRodadas)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(passaASer,salt,numeroDeRodadas))
            {
                return rfc2898.GetBytes(32);
            }
        }
    }
}