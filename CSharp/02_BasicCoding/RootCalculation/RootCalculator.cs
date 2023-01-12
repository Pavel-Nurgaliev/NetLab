using System;

namespace RootCalculation
{
    public class RootCalculator
    {
        public static double CalculateByNewton(double number, int degree, double accuracy)
        {
            var previousResult = number;

            double result = number / degree;

            while (Math.Abs(previousResult - result) > accuracy)
            {
                previousResult = result;

                result = ((degree - 1) * previousResult + number / Math.Pow(previousResult, degree - 1)) / degree;
            }

            return result;
        }

        public static double CalculateByStandard(double result, int degree)
        {
            return Math.Pow(result, (double)1 / degree);
        }
    }
}
