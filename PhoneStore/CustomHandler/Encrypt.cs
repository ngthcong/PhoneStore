using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.CustomHandler
{
    public class Encrypt
    {
        public static string EncryptPassword(string clearText, string salt)
        {
            try
            {
                byte[] hashBytes = ComputeHash(clearText);

                byte[] saltHash = ComputeHash(salt);

                byte[] hashWithSalt = new byte[hashBytes.Length + saltHash.Length];
                for (int i = 0; i < hashBytes.Length; i++)
                    hashWithSalt[i] = hashBytes[i];
                for (int i = 0; i < saltHash.Length; i++)
                    hashWithSalt[hashBytes.Length + i] = saltHash[i];

                string hashValue = Convert.ToBase64String(hashWithSalt);

                return hashValue;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //random salt generation
        //public static byte[] GetRandomSalt()
        //{
        //    int minSaltSize = 16;
        //    int maxSaltSize = 32;

        //    Random random = new Random();
        //    int saltSize = random.Next(minSaltSize, maxSaltSize);
        //    byte[] saltBytes = new byte[saltSize];
        //    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        //    rng.GetNonZeroBytes(saltBytes);
        //    return saltBytes;
        //}

        public static string GetRandomSalt()
        {
            Random random = new Random();
            int size = random.Next(16, 32);
            StringBuilder builder = new StringBuilder();

            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
        // hashing
        public static byte[] ComputeHash(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            HashAlgorithm hash = new SHA256Managed();
            return hash.ComputeHash(plainTextBytes);
        }
    }
}

