using System;

namespace Matrix.UI
{
    internal class Program
    {
        private const string MessageOperationSum = "Matrix after summation";
        private const string MessageOperationSub = "Matrix after subtraction";
        private const string MessageOperationMulti = "Matrix after multiplication";
        static void Main(string[] args)
        {
            Matrix firstMatrix;
            Matrix secondMatrix;

            try
            {
                firstMatrix = new Matrix(InputDataHelper.InitializeMatrixWithoutRange());

                Console.WriteLine(firstMatrix);

                secondMatrix = new Matrix(InputDataHelper.InitializeMatrixWithRange());

                Console.WriteLine(secondMatrix);

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);

                return;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);

                return;
            }

            AddictMatrices(firstMatrix, secondMatrix);

            SubstractMatrices(firstMatrix, secondMatrix);

            MultiplicateMatrices(firstMatrix, secondMatrix);
        }

        private static void AddictMatrices(Matrix firstMatrix, Matrix secondMatrix)
        {
            try
            {
                Console.WriteLine(MessageOperationSum);
                Console.WriteLine(firstMatrix + secondMatrix);
            }
            catch (InvalidMatrixOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SubstractMatrices(Matrix firstMatrix, Matrix secondMatrix)
        {
            try
            {
                Console.WriteLine(MessageOperationSub);
                Console.WriteLine(firstMatrix - secondMatrix);
            }
            catch (InvalidMatrixOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void MultiplicateMatrices(Matrix firstMatrix, Matrix secondMatrix)
        {
            try
            {
                Console.WriteLine(MessageOperationMulti);
                Console.WriteLine(firstMatrix * secondMatrix);
            }
            catch (InvalidMatrixOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
