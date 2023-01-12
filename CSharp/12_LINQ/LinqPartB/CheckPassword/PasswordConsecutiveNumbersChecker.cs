using System;
using System.Linq;

namespace CheckPassword
{
    public class PasswordConsecutiveNumbersChecker : IValidPasswordChecker
    {
        private const int IndexNextNumber = 1;

        private const int IndexOutOfRange = 1;

        private const int PositiveConsecutiveRatio = 1;
        private const int NegativeConsecutiveRatio = -1;

        private const int MaxCountConsecutiveNumbers = 2;

        public bool IsValid(string password)
        {
            int[] numbers = password.Select(number => Convert.ToInt32(number)).ToArray();

            return !(IsConsecutiveNumbers(numbers, PositiveConsecutiveRatio) ||
                IsConsecutiveNumbers(numbers, NegativeConsecutiveRatio));

        }

        private bool IsConsecutiveNumbers(int[] numbers, int ratio)
        {
            int amount = 0;

            for (var i = 0; i < numbers.Length - IndexOutOfRange; i++)
            {
                if (numbers[i] == numbers[i + IndexNextNumber] + ratio)
                {
                    amount++;
                }
            }

            return amount > MaxCountConsecutiveNumbers;
        }
    }
}
