namespace RamdomNumbers
{
    public static class NumerosAleatorios
    {
        public static byte[] GerarNumerosAletorios(int tamanho)
        {
            using (var rngCryptoServiceProvider = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                var numeroAleatorio = new byte[tamanho];
                rngCryptoServiceProvider.GetBytes(numeroAleatorio);

                return numeroAleatorio;
            }
        }
    }
}
