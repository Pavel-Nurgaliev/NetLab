using NUnit.Framework;
using System;

namespace GreatestCommonDivisor.Test
{
    public class GreatestCommonDivisorTests
    {
        [TestCase(11, 11, ExpectedResult = 11, TestName = "TestCalculateByEuclid_TwoEqualNumber_Success")]
        [TestCase(11, 121, ExpectedResult = 11, TestName = "TestCalculateByEuclid_FirstNumberLessSecond_Success")]
        [TestCase(121, 11, ExpectedResult = 11, TestName = "TestCalculateByEuclid_SecondNumberLessSecond_Success")]
        [TestCase(2, 4, ExpectedResult = 2, TestName = "TestCalculateByEuclid_EvenValues_Success")]
        [TestCase(3, 9, ExpectedResult = 3, TestName = "TestCalculateByEuclid_NotEvenValues_Success")]
        [TestCase(3, 5, 7, 11, 13, ExpectedResult = 1, TestName = "TestCalculateByEuclid_FiveSimpleNumbers_Success")]
        [TestCase(10, 20, 5, ExpectedResult = 5, TestName = "TestCalculateByEuclid_ThreeNumbers_Success")]
        [TestCase(10, 20, 30, 5, ExpectedResult = 5, TestName = "TestCalculateByEuclid_FourNumbers_Success")]
        [TestCase(15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, ExpectedResult = 1, TestName = "TestCalculateByEuclid_FifteenNumbers_Success")]
        public int CalculateByEuclid_CalculateGreatestCommonDivisor_Success(params int[] numbers)
            => GreatestCommonDivisor.CalculateGreatestCommonDivisorByEuclid(out var stopwatch, numbers);

        [TestCase(11, 11, ExpectedResult = 11, TestName = "TestCalculateByBinaryAlgorithm_TwoEqualNumber_Success")]
        [TestCase(11, 121, ExpectedResult = 11, TestName = "TestCalculateByBinaryAlgorithm_FirstNumberLessSecond_Success")]
        [TestCase(121, 11, ExpectedResult = 11, TestName = "TestCalculateByBinaryAlgorithm_SecondNumberLessSecond_Success")]
        [TestCase(2, 4, ExpectedResult = 2, TestName = "TestCalculateByBinaryAlgorithm_EvenValues_Success")]
        [TestCase(3, 9, ExpectedResult = 3, TestName = "TestCalculateByBinaryAlgorithm_NotEvenValues_Success")]
        [TestCase(3, 5, 7, 11, 13, ExpectedResult = 1, TestName = "TestCalculateByBinaryAlgorithm_FiveSimpleNumbers_Success")]
        [TestCase(10, 20, 5, ExpectedResult = 5, TestName = "TestCalculateByBinaryAlgorithm_ThreeNumbers_Success")]
        [TestCase(10, 20, 30, 5, ExpectedResult = 5, TestName = "TestCalculateByBinaryAlgorithm_FourNumbers_Success")]
        [TestCase(15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, ExpectedResult = 1, TestName = "TestCalculateByBinaryAlgorithm_FifteenNumbers_Success")]
        public int CalculateByBinaryAlgorithm_CalculateGreatestCommonDivisor_Success(params int[] numbers)
            => GreatestCommonDivisor.CalculateGreatestCommonDivisorByBinaryAlgorithm(out var stopwatch, numbers);

        [TestCase(1)]
        [TestCase(-1, 10)]
        public void TestRange_InvalidValuesInEuclidAlgorithm_Exception(params int[] numbers)
            => Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.CalculateGreatestCommonDivisorByEuclid(out var stopwatch, numbers));

        [TestCase(1)]
        [TestCase(-1, 10)]
        public void TestRange_InvalidValuesInBinaryAlgorithm_Exception(params int[] numbers)
           => Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.CalculateGreatestCommonDivisorByBinaryAlgorithm(out var stopwatch, numbers));
    }
}