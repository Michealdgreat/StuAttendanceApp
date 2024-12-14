using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceApp.Services
{
    public static class Sha256Hasher
    {
        /// <summary>
        /// Password encoding and verification
        /// </summary>
        /// <summary>
        /// Generate hash-value of user's raw password.
        /// </summary>
        /// <param name="inputValue">User password</param>
        /// <returns></returns>
        public static string Hash(string inputValue)
        {
            using var sha256 = SHA256.Create();
            var originalBytes = Encoding.Default.GetBytes(inputValue);
            var encodedBytes = sha256.ComputeHash(originalBytes);
            return Convert.ToBase64String(encodedBytes);
        }


        /// <param name="hashText">Database Hash</param>
        /// <param name="rawText">Hash-Value of pass provided by the user</param>
        /// <returns></returns>
        public static bool IsCompare(string hashText, string rawText)
        {
            var hash = Hash(rawText);
            return hashText == hash;
        }

    }
}
