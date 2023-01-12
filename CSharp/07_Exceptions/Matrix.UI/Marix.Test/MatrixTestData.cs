using System.Collections.Generic;
using NUnit.Framework;

namespace Matrix.Test
{
    internal class MatrixTestData
    {
        public static IEnumerable<TestCaseData> GetString
        {
            get
            {
                yield return new TestCaseData(new Matrix(
                    new int[,] {
                        { 1, 2, 3 },
                        { 1, 2, 3 } })).Returns(
@"
    1    2    3
    1    2    3");

                yield return new TestCaseData(new Matrix(
                    new int[,] {
                        { 2, 4, 6 },
                        { 1, 2, 3 } })).Returns(@"
    2    4    6
    1    2    3");

                yield return new TestCaseData(new Matrix(
                    new int[,] {
                        { 1, 2, 3 },
                        { 3, 4, 5 },
                        { 3, 3, 3} })).Returns(@"
    1    2    3
    3    4    5
    3    3    3");
            }
        }


        public static IEnumerable<TestCaseData> SumMatrices
        {
            get
            {
                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2, 3 }, { 2, 3, 4 } }),
                    new Matrix(new int[,] { { 1, 2, 4 }, { 3, 5, 6 } })).
                    Returns(new Matrix(new int[,] { { 2, 4, 7 }, { 5, 8, 10 } }));

                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2 }, { 2, 3 }, { 3, 4 } }),
                    new Matrix(new int[,] { { 1, 2 }, { 3, 4 }, { 3, 5 } })).
                    Returns(new Matrix(new int[,] { { 2, 4 }, { 5, 7 }, { 6, 9 } }));

                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2, 3, 3 }, { 2, 3, 4, 3 } }),
                    new Matrix(new int[,] { { 1, 2, 4, 3 }, { 3, 5, 6, 3 } })).
                    Returns(new Matrix(new int[,] { { 2, 4, 7, 6 }, { 5, 8, 10, 6 } }));
            }
        }

        public static IEnumerable<TestCaseData> SubMatrices
        {
            get
            {
                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2, 3 }, { 2, 3, 4 } }),
                    new Matrix(new int[,] { { 1, 2, 4 }, { 3, 5, 6 } })).
                    Returns(new Matrix(new int[,] { { 0, 0, -1 }, { -1, -2, -2 } }));

                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2 }, { 2, 3 }, { 3, 4 } }),
                    new Matrix(new int[,] { { 1, 2 }, { 3, 4 }, { 3, 5 } })).
                    Returns(new Matrix(new int[,] { { 0, 0 }, { -1, -1 }, { 0, -1 } }));

                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2, 3, 3 }, { 2, 3, 4, 3 } }),
                    new Matrix(new int[,] { { 1, 2, 4, 3 }, { 3, 5, 6, 3 } })).
                    Returns(new Matrix(new int[,] { { 0, 0, -1, 0 }, { -1, -2, -2, 0 } }));
            }
        }

        public static IEnumerable<TestCaseData> MultiMatrices
        {
            get
            {
                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2, 3 }, { 2, 3, 4 } }),
                    new Matrix(new int[,] { { 1, 2 }, { 3, 5 }, { 3, 5 } })).
                    Returns(new Matrix(new int[,] { { 16, 27 }, { 23, 39 } }));

                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2 }, { 2, 3 }, { 3, 4 } }),
                    new Matrix(new int[,] { { 1, 2, 3 }, { 3, 4, 6 } })).
                    Returns(new Matrix(new int[,] { { 7, 10, 15 }, { 11, 16, 24 }, { 15, 22, 33 } }));

                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2, 3, 3 }, { 2, 3, 4, 3 } }),
                    new Matrix(new int[,] { { 1, 2 }, { 3, 5 }, { 3, 5 }, { 3, 3 } })).
                    Returns(new Matrix(new int[,] { { 25, 36 }, { 32, 48 } }));
            }
        }

        public static IEnumerable<TestCaseData> ExpectionSumMatrix
        {
            get
            {
                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2, 3 }, { 2, 3, 4 } }),
                    new Matrix(new int[,] { { 1, 2 }, { 3, 5 }, { 3, 5 } }));

                yield return new TestCaseData(new Matrix(new int[,] { { 1 }, { 2 } }),
                    new Matrix(new int[,] { { 1, 2 }, { 3, 5 }, { 3, 5 } }));

                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2, 3, 4 }, { 2, 3, 4, 4 } }),
                    new Matrix(new int[,] { { 1, 2, 3 }, { 3, 5, 3 }, { 3, 5, 3 } }));
            }
        }

        public static IEnumerable<TestCaseData> ExpectionSubMatrix
        {
            get
            {
                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2 }, { 2, 3 } }),
                    new Matrix(new int[,] { { 1, 2, 3 }, { 3, 5, 3 }, { 3, 5, 3 } }));

                yield return new TestCaseData(new Matrix(new int[,] { { 1 }, { 2 } }),
                    new Matrix(new int[,] { { 1, 2 }, { 3, 5 }, { 3, 5 } }));

                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2, 3, 4 }, { 2, 3, 4, 4 } }),
                    new Matrix(new int[,] { { 1, 2, 3 }, { 3, 5, 3 }, { 3, 5, 3 } }));
            }
        }

        public static IEnumerable<TestCaseData> ExpectionMultiMatrix
        {
            get
            {
                yield return new TestCaseData(new Matrix(new int[,] { { 1 }, { 2 } }),
                    new Matrix(new int[,] { { 1, 2, 3 }, { 3, 5, 3 }, { 3, 5, 3 } }));

                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2, 3, 4 }, { 2, 3, 4, 4 } }),
                    new Matrix(new int[,] { { 1, 2, 3 }, { 3, 5, 3 }, { 3, 5, 3 } }));
            }
        }

        public static IEnumerable<TestCaseData> NullExpectionSumMatrix
        {
            get
            {
                yield return new TestCaseData(null,
                    new Matrix(new int[,] { { 1, 2, 3 }, { 3, 5, 3 }, { 3, 5, 3 } }));

                yield return new TestCaseData(null,
                    new Matrix(new int[,] { { 1, 2, 3 }, { 3, 5, 3 }, { 3, 5, 3 } }));

                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2, 3, 4 }, { 2, 3, 4, 4 } }),
                    null);
            }
        }

        public static IEnumerable<TestCaseData> NullExpectionSubMatrix
        {
            get
            {
                yield return new TestCaseData(null,
                    new Matrix(new int[,] { { 1, 2, 3 }, { 3, 5, 3 }, { 3, 5, 3 } }));

                yield return new TestCaseData(null,
                    new Matrix(new int[,] { { 1, 2, 3 }, { 3, 5, 3 }, { 3, 5, 3 } }));

                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2, 3, 4 }, { 2, 3, 4, 4 } }),
                    null);
            }
        }
        public static IEnumerable<TestCaseData> NullExpectionMultiMatrix
        {
            get
            {
                yield return new TestCaseData(null,
                    new Matrix(new int[,] { { 1, 2, 3 }, { 3, 5, 3 }, { 3, 5, 3 } }));

                yield return new TestCaseData(null,
                    new Matrix(new int[,] { { 1, 2, 3 }, { 3, 5, 3 }, { 3, 5, 3 } }));

                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2, 3, 4 }, { 2, 3, 4, 4 } }),
                    null);
            }
        }

        public static IEnumerable<TestCaseData> EqualsMatrix
        {
            get
            {
                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2, 3 }, { 3, 5, 3 }, { 3, 5, 3 } }),
                    new Matrix(new int[,] { { 1, 2, 3 }, { 3, 5, 3 }, { 3, 5, 3 } })).Returns(true);

                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2, 3, 4 }, { 2, 3, 4, 4 } }),
                    new Matrix(new int[,] { { 1, 3 }, { 3, 3 }, { 3, 5 } })).Returns(false);

                yield return new TestCaseData(new Matrix(new int[,] { { 1, 3 }, { 3, 3 }, { 3, 5 } }),
                    null).Returns(false);
            }
        }

        public static IEnumerable<TestCaseData> MatrixIndexator
        {
            get
            {
                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2, 3 }, { 3, 5, 3 }, { 3, 5, 3 } }), 0, 0).Returns(1);

                yield return new TestCaseData(
                    new Matrix(new int[,] { { 1, 3 }, { 3, 3 }, { 3, 5 } }), 2, 0).Returns(3);

                yield return new TestCaseData(new Matrix(new int[,] { { 1, 3 }, { 3, 3 }, { 3, 5 } }),
                    2, 1).Returns(5);
            }
        }

        public static IEnumerable<TestCaseData> MatrixIndexatorException
        {
            get
            {
                yield return new TestCaseData(new Matrix(new int[,] { { 1, 2, 3 }, { 3, 5, 3 }, { 3, 5, 3 } }), 10, 0);

                yield return new TestCaseData(
                    new Matrix(new int[,] { { 1, 3 }, { 3, 3 }, { 3, 5 } }), 20, 0);

                yield return new TestCaseData(new Matrix(new int[,] { { 1, 3 }, { 3, 3 }, { 3, 5 } }),
                    50, 22);
            }
        }
    }
}