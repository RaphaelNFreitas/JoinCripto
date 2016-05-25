using System;
using System.Security.Cryptography;

namespace PasswordStorage
{
    public static class Hash
    {
        public static byte[] SenhaHashComSalt(byte[] passaASer, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Combine(passaASer, salt));
            }
        }

        private static byte[] Combine(byte[] passaASer, byte[] salt)
        {
            var ret = new byte[passaASer.Length+salt.Length];
            Buffer.BlockCopy(passaASer,0,ret,0,passaASer.Length);
            Buffer.BlockCopy(salt,0,ret,passaASer.Length,salt.Length);

            return ret;
        }

        public static byte[] GerarSalt()
        {
            const int TAMANHO_SALT = 32;

            using (var gerarNumeroAleatorio = new RNGCryptoServiceProvider())
            {
                var numeroAleatorio = new byte[TAMANHO_SALT];
                gerarNumeroAleatorio.GetBytes(numeroAleatorio);

                return numeroAleatorio;
            }
        }
    }
}