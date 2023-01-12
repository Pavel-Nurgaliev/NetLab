using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Polynomial.Tests
{
    public class PolynomialData
    {
        public static IEnumerable<TestCaseData> AddDataCase
        {
            get
            {
                yield return new TestCaseData(new Polynomial(1, 0, 0), new Polynomial(1, 1, 1, 1)).Returns(new Polynomial(2, 1, 1, 1));
                yield return new TestCaseData(new Polynomial(0, 1, 1), new Polynomial(1, 1, 1)).Returns(new Polynomial(1, 2, 2));
                yield return new TestCaseData(new Polynomial(1, 1, 1), new Polynomial(3, 3, 3)).Returns(new Polynomial(4, 4, 4));
                yield return new TestCaseData(new Polynomial(2, 2, 2), new Polynomial(1, 1, 1)).Returns(new Polynomial(3, 3, 3));
                yield return new TestCaseData(new Polynomial(1, 2, 3), new Polynomial(3, 3)).Returns(new Polynomial(4, 5, 3));
                yield return new TestCaseData(new Polynomial(1), new Polynomial(3, 3)).Returns(new Polynomial(4, 3));
            }
        }

        public static IEnumerable<TestCaseData> SubDataCase
        {
            get
            {
                yield return new TestCaseData(new Polynomial(1, 0, 0), new Polynomial(1, 1, 1, 1)).Returns(new Polynomial(0, -1, -1, -1));
                yield return new TestCaseData(new Polynomial(0, 1, 1), new Polynomial(1, 1, 1)).Returns(new Polynomial(-1, 0, 0));
                yield return new TestCaseData(new Polynomial(1, 1, 1), new Polynomial(3, 3, 3)).Returns(new Polynomial(-2, -2, -2));
                yield return new TestCaseData(new Polynomial(2, 2, 2), new Polynomial(1, 1, 1)).Returns(new Polynomial(1, 1, 1));
                yield return new TestCaseData(new Polynomial(1, 2, 3), new Polynomial(3, 3)).Returns(new Polynomial(-2, -1, 3));
                yield return new TestCaseData(new Polynomial(1), new Polynomial(3, 3)).Returns(new Polynomial(-2, -3));
            }
        }

        public static IEnumerable<TestCaseData> MultiOnPolynomialDataCase
        {
            get
            {
                yield return new TestCaseData(new Polynomial(1, 0, 0), new Polynomial(1)).Returns(new Polynomial(1));
                yield return new TestCaseData(new Polynomial(1, 1), new Polynomial(1, 1)).Returns(new Polynomial(1, 2, 1));
                yield return new TestCaseData(new Polynomial(5), new Polynomial(3, 3, 3)).Returns(new Polynomial(15, 15, 15));
                yield return new TestCaseData(new Polynomial(2, 0), new Polynomial(3, 3, 3)).Returns(new Polynomial(6, 6, 6));
                yield return new TestCaseData(new Polynomial(1, 2, 3), new Polynomial(3, 3)).Returns(new Polynomial(3, 9, 15, 9));
                yield return new TestCaseData(new Polynomial(1), new Polynomial(3, 3)).Returns(new Polynomial(3, 3));
            }
        }

        public static IEnumerable<TestCaseData> MultiOnNumberDataCase
        {
            get
            {
                yield return new TestCaseData(new Polynomial(1, 0, 0), 1).Returns(new Polynomial(1, 0, 0));
                yield return new TestCaseData(new Polynomial(1, 1, 1), 1).Returns(new Polynomial(1, 1, 1));
                yield return new TestCaseData(new Polynomial(1, 1, 1), 2).Returns(new Polynomial(2, 2, 2));
                yield return new TestCaseData(new Polynomial(2, 2, 2), 0).Returns(new Polynomial(0, 0, 0));
                yield return new TestCaseData(new Polynomial(1, 2), 2).Returns(new Polynomial(2, 4));
                yield return new TestCaseData(new Polynomial(1), 10).Returns(new Polynomial(10));
            }
        }

        public static IEnumerable<TestCaseData> PolynolialsEqualsDateCase
        {
            get
            {
                yield return new TestCaseData(new Polynomial(1, 0, 0), new Polynomial(1, 0, 0)).Returns(true);
                yield return new TestCaseData(new Polynomial(1, 0, 0), new Polynomial(1, 0, 1)).Returns(false);
            }
        }


    }
}
