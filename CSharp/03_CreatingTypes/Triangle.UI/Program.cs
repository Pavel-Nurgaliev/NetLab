using System;
using ConsoleInput;

namespace Triangle.UI
{
    public class Program
    {
        private const string InvitationInput = "Введите данные";

        private const string PositiveMessageInputSideA = "Сторона треугольника A = ";
        private const string PositiveMessageInputSideB = "Сторона треугольника B = ";
        private const string PositiveMessageInputSideC = "Сторона треугольника C = ";

        private const string NegativeMessageInputSides = "Ошибка ввода данных. Повторите ввод";

        private const int MinValueSideOfTriangle = 1;

        private const string PerimeterMessage = "Периметр равен {0}";
        private const string SquareMessage = "Площадь равна {0}";

        public static void Main(string[] args)
        {
            var sides = InputTriangleSides();

            Triangle triangle = Triangle.CreateInstance(sides.Item1, sides.Item2, sides.Item3);


            PrintResultOfCalculate(triangle);
        }

        private static (int, int, int) InputTriangleSides()
        {
            Console.WriteLine(InvitationInput);

            int a = InvitationInputHelper.InputInteger(PositiveMessageInputSideA, NegativeMessageInputSides, MinValueSideOfTriangle);
            int b = InvitationInputHelper.InputInteger(PositiveMessageInputSideB, NegativeMessageInputSides, MinValueSideOfTriangle);
            int c = InvitationInputHelper.InputInteger(PositiveMessageInputSideC, NegativeMessageInputSides, MinValueSideOfTriangle);

            return (a, b, c);
        }

        private static void PrintResultOfCalculate(Triangle triangle)
        {
            Console.WriteLine(PerimeterMessage, triangle.Perimeter);
            Console.WriteLine(SquareMessage, triangle.Square);
        }
    }
}
