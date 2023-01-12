using NUnit.Framework;
using System.Collections.Generic;

namespace Vector.Tests
{
    public class VectorData
    {
        public static IEnumerable<TestCaseData> AddDataCase
        {
            get
            {
                yield return new TestCaseData(new Vector(1, 1, 1), new Vector(1, 1, 1)).Returns(new Vector(2, 2, 2));
                yield return new TestCaseData(new Vector(1, 1, 1), new Vector(3, 3, 3)).Returns(new Vector(4, 4, 4));
                yield return new TestCaseData(new Vector(2, 2, 2), new Vector(1, 1, 1)).Returns(new Vector(3, 3, 3));
            }
        }
        public static IEnumerable<TestCaseData> SubDataCase
        {
            get
            {
                yield return new TestCaseData(new Vector(1, 1, 1), new Vector(1, 1, 1)).Returns(new Vector(0, 0, 0));
                yield return new TestCaseData(new Vector(1, 1, 1), new Vector(3, 3, 3)).Returns(new Vector(-2, -2, -2));
                yield return new TestCaseData(new Vector(2, 2, 2), new Vector(1, 1, 1)).Returns(new Vector(1, 1, 1));
            }
        }
        public static IEnumerable<TestCaseData> MultiDataCase
        {
            get
            {
                yield return new TestCaseData(new Vector(1, 1, 1), new Vector(1, 1, 1)).Returns(3);
                yield return new TestCaseData(new Vector(1, 1, 1), new Vector(3, 3, 3)).Returns(9);
                yield return new TestCaseData(new Vector(2, 2, 2), new Vector(1, 1, 1)).Returns(6);
            }
        }
        public static IEnumerable<TestCaseData> EqualDataCase
        {
            get
            {
                yield return new TestCaseData(new Vector(1, 1, 1), new Vector(1, 1, 1)).Returns(true);
                yield return new TestCaseData(new Vector(1, 1, 1), new Vector(3, 3, 3)).Returns(false);
                yield return new TestCaseData(new Vector(2, 2, 2), new Vector(1, 1, 1)).Returns(false);
            }
        }
    }
}
