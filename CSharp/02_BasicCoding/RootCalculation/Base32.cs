using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSystem
{
    internal class Base32
    {
        public string Result { get; private set; }
        public Base32(int number)
        {
            Result = ToBase32(number);
        }

        private static string ToBase32(int number)
        {
            List<int> binNumbers = new List<int>();

            string result = string.Empty;

            while (number > 0)
            {
                binNumbers.Add(number % 32);

                number = number / 32;
            }



            for (var i = binNumbers.Count - 1; i >= 0; i--)
            {
                if (binNumbers[i] < 10)
                    result += binNumbers[i].ToString();
                else
                    result += Convert.ToChar(binNumbers[i] + 55);
            }

            return result;
        }
    }


}
