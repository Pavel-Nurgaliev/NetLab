using System;
using ConsoleInput;

namespace RootCalculation.UI
{
    internal class Program
    {

        private const double MinNumber = 0.00;
        private const int MinDegree = 0;
        private const double MaxAccuracy = 0.11;

        private const string StartInputOfNumber = "Number under root. Number must be positive. Number= ";
        private const string StartInputOfDegree = "Number of degree. Number must be positive and integer. Degree= ";
        private const string StartInputOfAccuracy = "Accuracy of calculate.Accuracy must be positive and low maximum accuracy. Accuracy= ";

        private const string MaxAccuracyValue = "Maximum value of accuracy is ";

        private const string NegativeMessageOfNumber = "The number under root is negative. Please, repeat to enter";
        private const string NegativeMessageOfDegree = "The number of degree is negative. Please, repeat to enter";
        private const string NegativeMessageOfAccuracy = "The accuracy was more to maximum value. Please, repeat to enter";

        private const string ResultPositiveOfEquals = "Results are equal with accuracy.";
        private const string ResultNegativeOfEquals = "Results are not equal with accuracy.";


        static void Main(string[] args)
        {
            var number = InvitationInputHelper.InputDouble(StartInputOfNumber, NegativeMessageOfNumber, MinNumber);
            var degree = InvitationInputHelper.InputInteger(StartInputOfDegree, NegativeMessageOfDegree, MinDegree);

            Console.WriteLine(MaxAccuracyValue + MaxAccuracy.ToString());
            var accuracy = InvitationInputHelper.InputDouble(StartInputOfAccuracy, NegativeMessageOfAccuracy, maxLimit: MaxAccuracy);

            var result = CalculateRoots(number, degree, accuracy);

            Print(result.resultByNewton, result.resultByStandard, CheckOnEquals(result, accuracy));
        }


        private static (double resultByNewton, double resultByStandard) CalculateRoots(double number, int degree, double accuracy)
        {
            var resultByNewton = RootCalculator.CalculateByNewton(number, degree, accuracy);
            var resultByStandard = RootCalculator.CalculateByStandard(number, degree);

            return (resultByNewton, resultByStandard);
        }

        private static bool CheckOnEquals((double resultByNewton, double resultByStandard) result, double accuracy)
        {
            return (Math.Abs(result.resultByNewton - result.resultByStandard) <= accuracy);
        }

        private static void Print(double resultOfNewton, double resultOfStandard, bool isEquals)
        {
            Console.WriteLine(resultOfNewton);
            Console.WriteLine(resultOfStandard);

            Console.WriteLine(isEquals ? ResultPositiveOfEquals : ResultNegativeOfEquals);
        }
    }
}
