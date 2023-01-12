using NUnit.Framework;
using System;

namespace Matrix.Test
{
    public class MatrixTests
    {
        [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.GetString))]
        public string TestMatrixGetString_ToString_Success(Matrix matrix) => matrix.ToString();

        [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.SumMatrices))]
        public Matrix TestSumMatrices_Summation_Success(Matrix firstMatrix, Matrix secondMatrix) =>
            firstMatrix + secondMatrix;

        [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.SubMatrices))]
        public Matrix TestSubMatrices_Substraction_Success(Matrix firstMatrix, Matrix secondMatrix) =>
            firstMatrix - secondMatrix;

        [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.MultiMatrices))]
        public Matrix TestMultiMatrices_Multiplication_Success(Matrix firstMatrix, Matrix secondMatrix) =>
            firstMatrix * secondMatrix;

        [Test]
        public void TestCreateNullMatrix_NullElements_Exception() =>
            Assert.Throws<ArgumentNullException>(() => new Matrix(null));

        [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.ExpectionSumMatrix))]
        public void TestSumMatrices_Summation_Exception(Matrix firstMatrix, Matrix secondMatrix)
        {
            Assert.That(() => firstMatrix + secondMatrix, Throws.TypeOf<InvalidMatrixOperationException>());
        }

        [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.ExpectionSubMatrix))]
        public void TestSubMatrices_Substraction_Exception(Matrix firstMatrix, Matrix secondMatrix)
        => Assert.That(() => firstMatrix - secondMatrix, Throws.TypeOf<InvalidMatrixOperationException>());


        [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.ExpectionMultiMatrix))]
        public void TestMultiMatrices_Multiplication_Exception(Matrix firstMatrix, Matrix secondMatrix)
        => Assert.That(() => firstMatrix * secondMatrix, Throws.TypeOf<InvalidMatrixOperationException>());




        [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.NullExpectionSumMatrix))]
        public void TestSumMatrices_Summation_NullException(Matrix firstMatrix, Matrix secondMatrix)
        {
            Assert.That(() => firstMatrix + secondMatrix, Throws.TypeOf<ArgumentNullException>());
        }

        [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.NullExpectionSubMatrix))]
        public void TestSubMatrices_Substraction_NullException(Matrix firstMatrix, Matrix secondMatrix)
        => Assert.That(() => firstMatrix - secondMatrix, Throws.TypeOf<ArgumentNullException>());


        [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.NullExpectionMultiMatrix))]
        public void TestMultiMatrices_Multiplication_NullException(Matrix firstMatrix, Matrix secondMatrix)
        => Assert.That(() => firstMatrix * secondMatrix, Throws.TypeOf<ArgumentNullException>());

        [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.EqualsMatrix))]
        public bool TestEqualsMatrix_Equals_Success(Matrix firstMatrix, Matrix secondMatrix) =>
            firstMatrix.Equals(secondMatrix);

        [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.MatrixIndexator))]
        public int TestMatrixIndexator_Index_Success(Matrix matrix, int indexRow, int indexColumn) =>
            matrix[indexRow, indexColumn];

        [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.MatrixIndexatorException))]
        public void TestMatrixIndexator_Index_Exception(Matrix matrix, int indexRow, int indexColumn) =>
           Assert.That(() => matrix[indexRow, indexColumn], Throws.TypeOf<IndexOutOfRangeException>());
    }
}