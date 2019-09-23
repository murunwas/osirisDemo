using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace OSIRIS.Common.Helpers
{
    public class PasswordGenerator
    {
        private static string GenerateHash(string value, string salt)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                                password: value,
                                salt: Encoding.UTF8.GetBytes(salt),
                                prf: KeyDerivationPrf.HMACSHA512,
                                iterationCount: 10000,
                                numBytesRequested: 256 / 8);

            return Convert.ToBase64String(valueBytes);
        }

        private static string GenerateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }

        private static bool Validate(string value, string salt, string hash) => GenerateHash(value, salt) == hash;


        public static bool Validate(string pass, string hash)
        {
            var split = hash.Split(".");

            if (split.Length < 2)
            {
                return false;
            }
            else
            {
                return Validate(pass, split[1], split[0]);
            }


        }

        public static string GenerateHashedPassword(string password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(password);
            }


            var salt = GenerateSalt();
            var hash = GenerateHash(password.Trim(), salt);
            return $"{hash}.{salt}";
        }
    }
}
