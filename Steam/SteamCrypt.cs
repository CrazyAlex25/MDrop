using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MDrop.Steam
{
    public static class SteamCrypt
    {
        public static string GetPassword(string mod,string exp,string pwd)
        {
            RSAParameters key = new RSAParameters()
            {
                Modulus = StringToByteArray(mod),
                Exponent = StringToByteArray(exp)
            };

            using (var rsa_engine = RSA.Create())
            {
                rsa_engine.ImportParameters(key);
                var bytes = Encoding.ASCII.GetBytes(pwd);
                var encryptedBytes = rsa_engine.Encrypt(bytes, RSAEncryptionPadding.Pkcs1);
                return Convert.ToBase64String(encryptedBytes);
            }
        }
        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }

   
}
