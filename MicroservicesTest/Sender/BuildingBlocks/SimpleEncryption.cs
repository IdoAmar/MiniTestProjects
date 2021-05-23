using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sender
{
    public static class SimpleEncryption
    {
        public static string Encrypt(string encryptedString)
        {
            string decryptedString = "";

            foreach (char c in encryptedString)
            {
                if (c != ' ')
                {
                    decryptedString = decryptedString.Insert(decryptedString.Length, ((char)(c ^ 'X')).ToString());
                }
                else
                {
                    decryptedString = decryptedString.Insert(decryptedString.Length, " ");
                }
            }
            return decryptedString;
        }
    }
}
