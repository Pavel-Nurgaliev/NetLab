using NUnit.Framework;

namespace Vector.Tests
{
    [TestFixture]
    public class VectorTests
    {
        private const string ExpectedOutputStringOfCreateVector = "Vector = (1, 1, 1)";

        [TestCase(1, 1, 1, ExpectedResult = ExpectedOutputStringOfCreateVector)]
        public string TestOutputStringOfCreateVector_ToString_Success(int endX, int endY, int endZ) =>
            new Vector(endX, endY, endZ).ToString();

        [TestCaseSource(typeof(VectorData), nameof(VectorData.AddDataCase))]
        public Vector TestAddVector_Adding_Success(Vector firstVector, Vector secondVector) => firstVector + secondVector;

        [TestCaseSource(typeof(VectorData), nameof(VectorData.SubDataCase))]
        public Vector TestSubVector_Substracting_Success(Vector firstVector, Vector secondVector) => firstVector - secondVector;

        [TestCaseSource(typeof(VectorData), nameof(VectorData.MultiDataCase))]
        public int TestMultiVector_Multiplying_Success(Vector firstVector, Vector secondVector) => firstVector * secondVector;

        [TestCaseSource(typeof(VectorData), nameof(VectorData.EqualDataCase))]
        public bool TestEqualVector_Comparison_Success(Vector firstVector, Vector secondVector) => firstVector == secondVector;


        [Test]
        public void TestAddVector_Adding_Exception()
        {
            Vector firstVector = null;
            Vector secondVector = new Vector(1, 2, 3);

            Assert.That(() => firstVector + secondVector, Throws.ArgumentNullException);
        }

        [Test]
        public void TestSubVector_Substracting_Exception()
        {
            Vector firstVector = null;
            Vector secondVector = new Vector(1, 2, 3);

            Assert.That(() => firstVector - secondVector, Throws.ArgumentNullException);
        }

        [Test]
        public void TestMultiVector_Multiplying_Exception()
        {
            Vector firstVector = null;
            Vector secondVector = new Vector(1, 2, 3);

            Assert.That(() => firstVector * secondVector, Throws.ArgumentNullException);
        }

        [Test]
        public void TestCompNullVector_Comparison_Success()
        {
            Vector firstVector = null;
            Vector secondVector = new Vector(1, 2, 3);

            Assert.AreEqual(false, firstVector == secondVector);
        }
    }
}
