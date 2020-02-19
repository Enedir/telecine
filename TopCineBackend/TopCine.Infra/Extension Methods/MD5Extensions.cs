using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TopCine.Infra.Extension_Methods
{
    public static class MD5Extensions
    {
        public static string GetMd5Hash(this MD5 md5Hash, string source)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(source));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

    }
}
