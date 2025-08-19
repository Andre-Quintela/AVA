using AVA.Application.Interfaces.Security;
using Isopoh.Cryptography.Argon2;
using System;
using System.Security.Cryptography;
using System.Text;

namespace AVA.Application.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be null or empty", nameof(password));
            }

            var config = new Argon2Config
            {
                Type = Argon2Type.DataDependentAddressing,
                Version = Argon2Version.Nineteen,
                TimeCost = 4,
                MemoryCost = 65536, // 64 MB  
                Lanes = 4,
                Threads = 4,
                Password = Encoding.UTF8.GetBytes(password),
                Salt = GenerateSalt(16),
                HashLength = 32
            };

            using var argon2 = new Argon2(config);
            var hashBytes = argon2.Hash();

            return config.EncodeString(hashBytes.Buffer);
        }

        public bool VerifyPassword(string hashedPassword, string password)
        {
            return Argon2.Verify(hashedPassword, password); 
        }

        private byte[] GenerateSalt(int length)
        {
            byte[] salt = new byte[length];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);
            return salt;
        }
    }
}
