using System;

namespace Triangle
{
    public class Triangle
    {
        private const string InvalidTriangleErrorMessage = "Треугольник не существует, ошибка ввода данных.";

        private const string OutputTriangleMessage = "Треугольник со сторонами";

        private Triangle(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }

        public int A { get; private set; }
        public int B { get; private set; }
        public int C { get; private set; }

        public int Perimeter => A + B + C;
        private double HalfPerimeter => (double)Perimeter / 2;

        public double Square => Math.Sqrt(HalfPerimeter * (HalfPerimeter - A) * (HalfPerimeter - B) * (HalfPerimeter - C));

        public static Triangle CreateInstance(int a, int b, int c)
        {
            return (CheckValueSizeIsMoreThanZero(a, b, c) && CheckExisting(a, b, c)) ?
                new Triangle(a, b, c) : throw new Exception(InvalidTriangleErrorMessage);
        }

        private static bool CheckValueSizeIsMoreThanZero(int a, int b, int c) => a > 0 && b > 0 && c > 0;
        private static bool CheckExisting(int a, int b, int c) => a + b > c && c + b > a && c + a > b;


        public override string ToString()
        {
            return $"{OutputTriangleMessage}: A={A}, B={B}, C={C}";
        }
    }
}

