using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSystem
{
    public class Binary
    {
        public string Result { get; private set; }
        public Binary(int number)
        {
            Result = ToBinInteger(number);
        }

        private static string ToBinInteger(int number)
        {
            List<int> binNumbers = new List<int>();

            string result = string.Empty;

            while (number > 0)
            {
                binNumbers.Add(number % 2);

                number = number / 2;
            }



            for (var i = binNumbers.Count - 1; i >= 0; i--)
            {
                result += binNumbers[i].ToString();
            }

            return result;
        }
    }
}
