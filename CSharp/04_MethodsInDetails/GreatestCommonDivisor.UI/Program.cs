using System;
using System.Collections.Generic;
using ConsoleInput;

namespace GreatestCommonDivisor.UI
{
    public class Program
    {
        private const string MessageStartInput = "Введите данные";
        private const string MessageInstructionInput = "Число должно быть неотрицательным";

        private const string MessageCountOfNumbers = "Введите количество чисел, для вычисления НОД";
        private const string NegativeMessageInputCountsOfNumbers = "Неправильно задано количество чисел для вычисления НОД. Повторите ввод.";

        private const int MinValueCountOfNumbers = 2;

        private const string MessageInputMoreNumbers = "Введите следующее число";
        private const string NegativeMessageInputNumbers = "Ошибка входных чисел для вычисления НОД";

        private const int MinValueInputData = 0;

        private const string MessageOfResults = "Результаты:";

        private const string ResultCalculateByEuclideanAlhoritm = "НОД, вычесленный Евклидовым алгоритомом = ";
        private const string ResultCalculateByBinaryAlhoritm = "НОД, вычесленный бинарным алгоритмом = ";

        private const string MessageOfTimeForCalculateByEuclid = "Время, затраченное на нахождение НОД евклидовым алгоритмом = {0} мкс";
        private const string MessageOfTimeForCalculateByBinaryAlgorithm = "Время, затраченное на нахождение НОД бинарным алгоритмом = {0} мкс";

        private const int RatioOfConvertMilliToMicro = 1000;
        public static void Main(string[] args)
        {
            int[] numbers = InputData();

            var greatestCommonDivisor = GreatestCommonDivisor.CalculateGreatestCommonDivisorByEuclid(out var timeOfCalculateByEuclid, numbers);

            PrintGreatestCommonDivisor(greatestCommonDivisor, ResultCalculateByEuclideanAlhoritm);

            greatestCommonDivisor = GreatestCommonDivisor.CalculateGreatestCommonDivisorByBinaryAlgorithm(out var timeOfCalculateByBinaryAlgorithm, numbers);

            PrintGreatestCommonDivisor(greatestCommonDivisor, ResultCalculateByBinaryAlhoritm);

            PrintProcessTime(timeOfCalculateByEuclid, timeOfCalculateByBinaryAlgorithm);
        }
        private static void PrintGreatestCommonDivisor(int greatestCommonDivisor, string methodName)
        {
            Console.WriteLine(MessageOfResults);

            Console.Write(methodName);

            Console.WriteLine(greatestCommonDivisor);
        }
        public static int[] InputData()
        {
            List<int> numbers = new List<int>();

            var countNumbers = InvitationInputHelper.InputInteger(MessageCountOfNumbers, NegativeMessageInputCountsOfNumbers, MinValueInputData);

            while (!CheckOnMoreOfCountNumbers(countNumbers))
            {
                Console.WriteLine(NegativeMessageInputCountsOfNumbers);

                return InputData();
            }

            Console.WriteLine(MessageStartInput);
            Console.WriteLine(MessageInstructionInput);

            for (var i = 0; i < countNumbers; i++)
            {
                numbers.Add(InvitationInputHelper.InputInteger(MessageInputMoreNumbers, NegativeMessageInputNumbers, MinValueInputData));
            }

            return numbers.ToArray();
        }

        private static bool CheckOnMoreOfCountNumbers(int countNumbers) => (countNumbers >= MinValueCountOfNumbers) ? true : false;

        private static void PrintProcessTime(TimeSpan timeOfCalculateByEuclid, TimeSpan timeOfCalculateByBinaryAlgorithm)
        {
            Console.WriteLine(MessageOfTimeForCalculateByEuclid, timeOfCalculateByEuclid.TotalMilliseconds * RatioOfConvertMilliToMicro);

            Console.WriteLine(MessageOfTimeForCalculateByBinaryAlgorithm, timeOfCalculateByBinaryAlgorithm.TotalMilliseconds * RatioOfConvertMilliToMicro);
        }
    }
}