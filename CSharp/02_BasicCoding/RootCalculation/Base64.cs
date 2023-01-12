using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSystem
{
    internal class Base64
    {
        public string Result { get; private set; }
        public Base64(int number)
        {
            Result = ToBase32(number);
        }

        private static string ToBase32(int number)
        {
            List<int> binNumbers = new List<int>();

            string result = string.Empty;

            while (number > 0)
            {
                binNumbers.Add(number % 64);

                number = number / 64;
            }



            for (var i = binNumbers.Count - 1; i >= 0; i--)
            {
                if (binNumbers[i] < 26)
                    result += Convert.ToChar(binNumbers[i] + 65);
                else if (binNumbers[i] < 52)
                    result += Convert.ToChar(binNumbers[i] + 71);
                else if (binNumbers[i] < 62)
                    result += Convert.ToChar(binNumbers[i] - 4);
                else result += Convert.ToChar(binNumbers[i] - 19);
            }

            return result;
        }
    }
}
