using System;
using System.Diagnostics;

namespace GreatestCommonDivisor
{
    public static class GreatestCommonDivisor
    {
        private const string MessageErrorDataInput = "Ошибка ввода данных";

        private const int MinNumbersAmount = 2;

        public static int CalculateGreatestCommonDivisorByEuclid(out TimeSpan timeOfCalculateByBinaryAlgoritgm, params int[] numbers)
        {
            return MeausureElapsedTime(numbers, CalculateByEuclid, out timeOfCalculateByBinaryAlgoritgm);
        }

        public static int CalculateGreatestCommonDivisorByBinaryAlgorithm(out TimeSpan timeOfCalculateByBinaryAlgoritgm, params int[] numbers)
        {
            return MeausureElapsedTime(numbers, CalculateByBinaryAlgorithm, out timeOfCalculateByBinaryAlgoritgm);
        }

        private static int MeausureElapsedTime(int[] numbers, Func<int, int, int> greatestCommonDivisorMethod, out TimeSpan elapsed)
        {

            var processTimeOfCalculateByBinaryAlgoritgm = Stopwatch.StartNew();

            var greatestCommonDivisor = ProcessData(greatestCommonDivisorMethod, numbers);

            processTimeOfCalculateByBinaryAlgoritgm.Stop();

            elapsed = processTimeOfCalculateByBinaryAlgoritgm.Elapsed;

            return greatestCommonDivisor;
        }

        private static int ProcessData(Func<int, int, int> choisedAlgorithm, params int[] numbers)
        {
            if (!CheckOnValidValue(numbers)) throw new ArgumentException(MessageErrorDataInput);

            int greatestCommonDevisor = numbers[0];

            for (var i = 1; i < numbers.Length; i++)
            {
                greatestCommonDevisor = choisedAlgorithm(greatestCommonDevisor, numbers[i]);
            }

            return greatestCommonDevisor;
        }

        private static int CalculateByEuclid(int firstNumber, int secondNumber)
        {
            int greatestCommonDivisor;

            while (firstNumber != secondNumber)
            {
                if (firstNumber > secondNumber)
                    firstNumber -= secondNumber;
                else
                    secondNumber += -firstNumber;
            }
            greatestCommonDivisor = firstNumber;

            return greatestCommonDivisor;
        }



        private static int CalculateByBinaryAlgorithm(int firstNumber, int secodNumber)
        {
            //1
            if (firstNumber == 0)
                return secodNumber;
            if (secodNumber == 0)
                return firstNumber;
            //2
            if (firstNumber == 1 || secodNumber == 1)
                return 1;

            //3 - все четные
            if (firstNumber % 2 == 0)
            {
                if (secodNumber % 2 == 0)
                {
                    return 2 * CalculateByBinaryAlgorithm(firstNumber / 2, secodNumber / 2);
                }//4 -  первое четное, второе нечетное
                else return CalculateByBinaryAlgorithm(firstNumber / 2, secodNumber);
            }
            else
            { //5 - первое нечетное, второе четное
                if (secodNumber % 2 == 0)
                {
                    return CalculateByBinaryAlgorithm(firstNumber, secodNumber / 2);
                }
                else
                {//6- оба нечетных, если первое больше второго
                    if (firstNumber > secodNumber) return CalculateByBinaryAlgorithm((firstNumber - secodNumber) / 2, secodNumber);

                    //7- оба нечетные, если второе больше первого
                    else return CalculateByBinaryAlgorithm(firstNumber, (secodNumber - firstNumber) / 2);
                }
            }
        }
        private static bool CheckOnValidValue(int[] numbers)
        {
            if (numbers.Length < MinNumbersAmount)
            {
                return false;
            }
            foreach (var number in numbers)
            {
                if (number < 0) return false;
            }

            return true;
        }
    }

}
