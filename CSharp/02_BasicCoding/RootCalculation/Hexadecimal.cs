using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSystem
{
    public class Hexadecimal
    {
        public string Result { get; private set; }
        public Hexadecimal(int number)
        {
            Result = ToHex(number);
        }

        private static string ToHex(int number)
        {
            List<int> binNumbers = new List<int>();

            string result = string.Empty;

            while (number > 0)
            {
                binNumbers.Add(number % 16);

                number = number / 16;
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
