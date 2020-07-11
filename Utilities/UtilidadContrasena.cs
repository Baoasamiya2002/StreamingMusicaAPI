using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;
using CryptSharp.Utility;

namespace ApiRest.Utilities
{
    public class UtilidadContrasena
    {
        private static int saltLengthLimit = 32;
        public byte[] GetSalt()
        {
            return GetSalt(saltLengthLimit);
        }
        private static byte[] GetSalt(int maximumSaltLength)
        {
            var salt = new byte[maximumSaltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return salt;
        }

        public string Hash(string contrasena, string salt)
        {
            var keyBytes = Encoding.UTF8.GetBytes(contrasena);
            var saltBytes = Encoding.UTF8.GetBytes(salt);
            var cost = 262144;
            var blockSize = 8;
            var parallel = 1;
            var maxThreads = (int?)null;
            var derivedKeyLength = 128;
            var bytes = SCrypt.ComputeDerivedKey(keyBytes, saltBytes, cost, blockSize, parallel, maxThreads, derivedKeyLength);
            return Convert.ToBase64String(bytes);
        }
    }
}