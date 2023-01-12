using System;

namespace ConsoleInput
{
    public class InvitationInputHelper
    {
        private static bool InRange(double number, double? minLimit, double? maxLimit)
        {
            return ((minLimit == null || number > minLimit) && (maxLimit == null || number < maxLimit));
        }

        public static int InputInteger(string startInputMessage, string negativeMessage, int? minLimit = null, int? maxLimit = null)
        {
            int integerValue;

            Console.WriteLine(startInputMessage);

            while (!int.TryParse(Console.ReadLine(), out integerValue) || !InRange(integerValue, minLimit, maxLimit))
            {
                Console.WriteLine(negativeMessage);
            }

            return integerValue;
        }
    }
}
