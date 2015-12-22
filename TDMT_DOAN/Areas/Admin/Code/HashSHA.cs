using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TDMT_DOAN.Areas.Admin.Code
{
    public class HashSHA
    {
        public static string encryptSHA(string data)   // Encode password
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = sha.ComputeHash(encoder.GetBytes(data));
            return System.Text.Encoding.UTF8.GetString(hashedBytes);
        }

        private byte[] BytesFromString(string str)
        {
            return Encoding.ASCII.GetBytes(str);  // Convert string to byte
        }

        private int GetResponseCode(string ResponseString)
        {
            return int.Parse(ResponseString.Substring(0, 3));
        }
    }
}