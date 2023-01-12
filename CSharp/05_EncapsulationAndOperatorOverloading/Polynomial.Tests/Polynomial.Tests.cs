using NUnit.Framework;

namespace Polynomial.Tests
{
    public class PolynomialTests
    {
        private const string ExpectedPolynomialOutputStringWithNegativeMembers = "4x^3+3x^2-2x-1";
        private const string ExpectedPolynomialOutputStringWithOnlyPositiveMembers = "4x^3+3x^2+2x+1";
        private const string ExpectedPolynomialOutputStringWithOnlyZeroElement = "0";

        [TestCase(-1, -2, 3, 4, ExpectedResult = ExpectedPolynomialOutputStringWithNegativeMembers)]
        [TestCase(1, 2, 3, 4, ExpectedResult = ExpectedPolynomialOutputStringWithOnlyPositiveMembers)]
        [TestCase(0, 0, 0, 0, ExpectedResult = ExpectedPolynomialOutputStringWithOnlyZeroElement)]
        public string TestOutputPolynomial_ToString_Success(params double[] ratios) => new Polynomial(ratios).ToString();

        [TestCase(1, 0, 0)]
        public void TestRatiosOfPolynomial_DifferentValues_Success(params double[] ratios)
        {
            double[] expected = ratios;

            var polynomial = new Polynomial(ratios);

            Assert.AreEqual(expected, polynomial.Ratios);
        }

        [TestCase(null)]
        public void TestRatiosOfPolynomial_NullValues_Success(params double[] ratios)
        {
            double[] expected = new double[1] { 0 };

            var polynomial = new Polynomial(ratios);

            Assert.AreEqual(expected, polynomial.Ratios);
        }



        [TestCaseSource(typeof(PolynomialData), nameof(PolynomialData.AddDataCase))]
        public Polynomial TestAddPolynomial_Adding_Success(Polynomial firstPolynomial, Polynomial secondPolynomial) => firstPolynomial + secondPolynomial;

        [TestCaseSource(typeof(PolynomialData), nameof(PolynomialData.SubDataCase))]
        public Polynomial TestSubPolynomial_Substracting_Success(Polynomial firstPolynomial, Polynomial secondPolynomial) => firstPolynomial - secondPolynomial;

        [TestCaseSource(typeof(PolynomialData), nameof(PolynomialData.MultiOnNumberDataCase))]
        public Polynomial TestMultiOnNumberPolynomial_Multiplying_Success(Polynomial firstPolynomial, int number) => firstPolynomial * number;

        [TestCaseSource(typeof(PolynomialData), nameof(PolynomialData.MultiOnPolynomialDataCase))]
        public Polynomial TestMultiOnPolynomial_Multiplying_Success(Polynomial firstPolynomial, Polynomial secondPolynomial) => firstPolynomial * secondPolynomial;

        [TestCaseSource(typeof(PolynomialData), nameof(PolynomialData.PolynolialsEqualsDateCase))]
        public bool TestPolynomialsEquals_Multiplying_Success(Polynomial firstPolynomial, Polynomial secondPolynomial) =>
            firstPolynomial.Equals(secondPolynomial);

        [Test]
        public void TestAddPolynomial_Adding_Exception()
        {
            Polynomial firstPolynomial = null;
            Polynomial secondPolynomial = new Polynomial(1, 2, 3);

            Assert.That(() => firstPolynomial + secondPolynomial, Throws.ArgumentNullException);
        }

        [Test]
        public void TestSubPolynomial_Substracting_Exception()
        {
            Polynomial firstPolynomial = null;
            Polynomial secondPolynomial = new Polynomial(1, 2, 3);

            Assert.That(() => firstPolynomial - secondPolynomial, Throws.ArgumentNullException);
        }

        [Test]
        public void TestMultiOnNumberPolynomial_Multiplying_Exception()
        {
            Polynomial firstPolynomial = null;
            int number = 3;

            Assert.That(() => firstPolynomial * number, Throws.ArgumentNullException);
        }

        [Test]
        public void TestMultiOnPolynomial_Multiplying_Exception()
        {
            Polynomial firstPolynomial = null;
            Polynomial secondPolynomial = new Polynomial(1, 2, 3);

            Assert.That(() => firstPolynomial * secondPolynomial, Throws.ArgumentNullException);
        }
    }
}