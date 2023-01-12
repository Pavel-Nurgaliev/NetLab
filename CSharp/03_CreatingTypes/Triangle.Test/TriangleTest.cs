using NUnit.Framework;
using System;

namespace Triangle.Test
{
    public class TriangleTest
    {
        private const string ExpectedString735 = "Треугольник со сторонами: A=7, B=3, C=5";

        [TestCase(7, 3, 5, ExpectedResult = 7, TestName = "CreateTriangle_CheckSideA_Success")]
        public int CreateTriangle_CheckSideA_Success(int a, int b, int c) => Triangle.CreateInstance(a, b, c).A;


        [TestCase(7, 3, 5, ExpectedResult = 3, TestName = "CreateTriangle_CheckSideB_Success")]
        public int CreateTriangle_CheckSideB_Success(int a, int b, int c) => Triangle.CreateInstance(a, b, c).B;


        [TestCase(7, 3, 5, ExpectedResult = 5, TestName = "CreateTriangle_CheckSideC_Success")]
        public int CreateTriangle_CheckSideC_Success(int a, int b, int c) => Triangle.CreateInstance(a, b, c).C;

        [TestCase(0, 1, 2)]
        [TestCase(1, 0, 2)]
        [TestCase(1, 2, 0)]
        public void CreateTriangle_CheckSide_Exeption(int a, int b, int c)
        {
            Assert.Throws<Exception>(() => Triangle.CreateInstance(a, b, c));
        }

        [TestCase(7, 3, 5, ExpectedResult = 15)]
        public int Calculate_Perimeter_Success(int a, int b, int c) => Triangle.CreateInstance(a, b, c).Perimeter;

        [TestCase(7, 3, 5, ExpectedResult = 6.49519052838329)]
        public double Calculate_Square_Success(int a, int b, int c) => Triangle.CreateInstance(a, b, c).Square;

        [TestCase(7, 3, 5, ExpectedResult = ExpectedString735)]
        public string OutputTriangle_ToString_OutString(int a, int b, int c) => Triangle.CreateInstance(a, b, c).ToString();
    }

}