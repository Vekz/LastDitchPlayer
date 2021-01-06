using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LastDitchPlayer.Classes
{
    internal static class UtilClass
    {
        internal static string RandomAlphaNumericString(int lenght)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, lenght)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        
        }
    }
}
