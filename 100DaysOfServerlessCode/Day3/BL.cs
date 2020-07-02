using System;
using System.Collections.Generic;
using System.Text;

namespace _100DaysOfServerlessCode.Day3
{
    class BL
    {
        public static string Encryption(string message,string key)
        {
            int cipherKey;
            bool isValidKey = int.TryParse(key, out cipherKey);
            string encryptedMessage = "";
            char alphabet;
            if (isValidKey)
            {
                foreach(char ch in message)
                {
                    alphabet = (char)(Convert.ToUInt16(ch) + cipherKey);
                    encryptedMessage = encryptedMessage + alphabet;
                }
                return encryptedMessage;
            }
            else
            {
                return "Please enter a valid key. Any Integer is considered to be an valid key.";
            }
        }
        public static string Decryption(string message, string key)
        {
            int cipherKey;
            bool isValidKey = int.TryParse(key, out cipherKey);
            string decryptedMessage = "";
            char alphabet;
            if (isValidKey)
            {
                foreach (char ch in message)
                {
                    alphabet = (char)(Convert.ToUInt16(ch) - cipherKey);
                    decryptedMessage = decryptedMessage + alphabet;
                }
                return decryptedMessage;
            }
            else
            {
                return "Please enter a valid key. Any Integer is considered to be an valid key.";
            }
        }
    }
}
