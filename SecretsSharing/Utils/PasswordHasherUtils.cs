﻿using System.Security.Cryptography;
using System.Text;
using System;

namespace SecretsSharing.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class PasswordHasherUtils
    {

        public static string CreateHash(string password, string salt, string pepper, int iteration)
        {
            for (int i = 0; i < iteration; i++)
            {
                using var sha256 = SHA256.Create();
                var passwordSaltPepper = password + salt + pepper;
                var byteValue = Encoding.UTF8.GetBytes(passwordSaltPepper);
                var byteHash = sha256.ComputeHash(byteValue);
                password = Convert.ToBase64String(byteHash);
            }
            return password;
        }

        public static string GenerateSalt()
        {
            using var rng = RandomNumberGenerator.Create();
            var byteSalt = new byte[16];
            rng.GetBytes(byteSalt);
            var salt = Convert.ToBase64String(byteSalt);
            return salt;
        }
    }
}
