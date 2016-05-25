using System.Security.Cryptography;

namespace HashingAlgorithms
{
    public static class Hash
    {
        public static byte[] Sha1(byte[] passaASer)
        {
            using (var sha1 = SHA1.Create())
            {
                return sha1.ComputeHash(passaASer);
            }
        }

        public static byte[] Sha256(byte[] passaASer)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(passaASer);
            }
        }

        public static byte[] Sha512(byte[] passaASer)
        {
            using (var sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(passaASer);
            }
        }

        public static byte[] Sha384(byte[] passaASer)
        {
            using (var sha384 = SHA384.Create())
            {
                return sha384.ComputeHash(passaASer);
            }
        }

        public static byte[] Md5(byte[] passaASer)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(passaASer);
            }
        }
    }
}