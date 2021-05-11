using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace PapsCourse.Server.Models.Services
{
    public static class CriptoService
    {
        public static byte[] GetRandomBytes(int size = 32)
        {
            var salt = new byte[size];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }
            return salt;
        }

        public static byte[] Pbkdf2(string password, byte[] salt, int numBytes = 32)
        {
            return KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: numBytes
                );
        }
    }
}
