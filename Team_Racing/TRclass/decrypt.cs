using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace Team_Racing
{
    public class decrypt
    {

        private const string SecurityKey = "ComplexKeyHere_12121";

        public static string decryptText(string text)
        {
            byte[] encryptArray = Convert.FromBase64String(text);
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();

            byte [] keyArray = MD5.ComputeHash(System.Text.UTF8Encoding.UTF8.GetBytes(SecurityKey));
            MD5.Clear();

            var decrypService = new TripleDESCryptoServiceProvider();
            decrypService.Key = keyArray;
            decrypService.Mode = CipherMode.ECB;
            decrypService.Padding = PaddingMode.PKCS7;

            var decrypTransform = decrypService.CreateDecryptor();

            byte[] result = decrypTransform.TransformFinalBlock(encryptArray, 0, encryptArray.Length);
            decrypService.Clear();

            return System.Text.UTF8Encoding.UTF8.GetString(result);
        }

    }
}