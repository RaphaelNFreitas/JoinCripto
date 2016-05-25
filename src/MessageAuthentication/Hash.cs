using System.Security.Cryptography;

namespace MessageAuthentication
{
    public static class Hash
    {
        private const int TAMANHO_CHAVE = 32;

        public static byte[] GerarChave()
        {
            using (var gerarNumeroAleatorio = new RNGCryptoServiceProvider())
            {
                var numeroAleatorio = new byte[TAMANHO_CHAVE];
                gerarNumeroAleatorio.GetBytes(numeroAleatorio);
                return numeroAleatorio;
            }
        }

        public static byte[] CalcularHmacSha1(byte[] passaASer, byte[] chave)
        {
            using (var hmac = new HMACSHA1(chave))
            {
                return hmac.ComputeHash(passaASer);
            }
        }

        public static byte[] CalcularHmacSha256(byte[] passaASer, byte[] chave)
        {
            using (var hmac =  new HMACSHA256(chave))
            {
                return hmac.ComputeHash(passaASer);
            }
        }

        public static byte[] CalcularHmacSha512(byte[] passaASer, byte[] chave)
        {
            using (var hmac = new HMACSHA512(chave))
            {
                return hmac.ComputeHash(passaASer);
            }
        }

        public static byte[] CalcularHmacSha384(byte[] passaASer, byte[] chave)
        {
            using (var hmac = new HMACSHA384(chave))
            {
                return hmac.ComputeHash(passaASer);
            }
        }

        public static byte[] CalcularHmacMd5(byte[] passaASer, byte[] chave)
        {
            using (var hmac = new HMACMD5(chave))
            {
                return hmac.ComputeHash(passaASer);
            }
        }
    }
}