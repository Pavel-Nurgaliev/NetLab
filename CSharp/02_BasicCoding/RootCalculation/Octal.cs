using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSystem
{

    public class Octal
    {

        public string Result { get; private set; }

        public Octal(int number)
        {
            Result = ToOctInteger(number);
        }

        private static string ToOctInteger(int number)
        {
            List<int> binNumbers = new List<int>();

            string result = string.Empty;

            while (number > 0)
            {
                binNumbers.Add(number % 8);

                number = number / 8;
            }



            for (var i = binNumbers.Count - 1; i >= 0; i--)
            {
                result += binNumbers[i].ToString();
            }

            return result;
        }
    }
}
