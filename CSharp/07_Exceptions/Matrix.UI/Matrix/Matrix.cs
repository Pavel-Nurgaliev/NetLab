using System;
using System.Text;
using System.Linq;
using System.Collections;

namespace Matrix
{
    public class Matrix : IEquatable<Matrix>
    {
        private const string NegativeMessageRowsLength = "Amount of rows was not be equal or less zero";
        private const string NegativeMessageColumnsLength = "Amount of columns was not be equal or less zero";

        public Matrix(int[,] elements)
        {
            if (elements == null) throw new ArgumentNullException(nameof(elements));

            Elements = elements;
        }

        public Matrix(int rowsLength, int columnsLength)
        {
            if (rowsLength <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rowsLength), rowsLength, NegativeMessageRowsLength);
            }
            if (columnsLength <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(columnsLength), columnsLength, NegativeMessageColumnsLength);
            }

            Elements = new int[rowsLength, columnsLength];
        }

        public int this[int indexRow, int indexColumn]
        {
            get
            {
                return Elements[indexRow, indexColumn];
            }
            private set
            {
                Elements[indexRow, indexColumn] = value;
            }
        }

        public int[,] Elements { get; private set; }

        public int LengthRows => Elements.RowsCount();
        public int LengthColumns => Elements.ColumnsCount();

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            for (var row = 0; row < LengthRows; row++)
            {
                for (var column = 0; column < LengthColumns; column++)
                {
                    if (column == 0) builder.AppendLine();

                    builder.Append(string.Format("{0,5}", Elements[row, column]));
                }
            }

            return builder.ToString();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Matrix)) return false;

            return Equals(obj as Matrix);
        }

        public override int GetHashCode() => HashCode.Combine(Elements);

        public bool Equals(Matrix matrix)
        {
            if (ReferenceEquals(null, matrix)) return false;
            if (ReferenceEquals(this, matrix)) return true;

            return CheckOnEquals(matrix.Elements);
        }

        private bool CheckOnEquals(int[,] elements)
        {
            if (elements.RowsCount() != LengthRows ||
                elements.ColumnsCount() != LengthColumns) return false;

            var elementsCollection = elements.OfType<IEnumerable>();

            return elementsCollection.SequenceEqual(Elements.OfType<IEnumerable>());
        }

        public static bool operator ==(Matrix firstMatrix, Matrix secondMatrix)
        {
            return Equals(firstMatrix, secondMatrix);
        }

        public static bool operator !=(Matrix firstMatrix, Matrix secondMatrix)
        {
            return !Equals(firstMatrix, secondMatrix);
        }

        public static Matrix operator +(Matrix firstMatrix, Matrix secondMatrix)
        {
            CheckOnNullMatrices(firstMatrix, secondMatrix);
            CheckEqualsMatricesLength(firstMatrix, secondMatrix);

            var elements = new int[firstMatrix.LengthRows, firstMatrix.LengthColumns];

            for (var row = 0; row < firstMatrix.LengthRows; row++)
            {
                for (var column = 0; column < firstMatrix.LengthColumns; column++)
                {
                    elements[row, column] = firstMatrix.Elements[row, column] + secondMatrix.Elements[row, column];
                }
            }

            return new Matrix(elements);
        }

        private static void CheckOnNullMatrices(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix is null)
            {
                throw new ArgumentNullException(nameof(firstMatrix));
            }
            else if (secondMatrix is null)
            {
                throw new ArgumentNullException(nameof(secondMatrix));
            }
        }

        private static void CheckEqualsMatricesLength(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.LengthColumns != secondMatrix.LengthColumns ||
                firstMatrix.LengthRows != secondMatrix.LengthRows)
            {
                throw new InvalidMatrixOperationException(firstMatrix.LengthRows, firstMatrix.LengthColumns,
                    secondMatrix.LengthRows, secondMatrix.LengthColumns);
            }
        }

        public static Matrix operator -(Matrix firstMatrix, Matrix secondMatrix)
        {
            CheckOnNullMatrices(firstMatrix, secondMatrix);
            CheckEqualsMatricesLength(firstMatrix, secondMatrix);

            return firstMatrix + (-secondMatrix);
        }

        public static Matrix operator -(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            for (var row = 0; row < matrix.LengthRows; row++)
            {
                for (var column = 0; column < matrix.LengthColumns; column++)
                {
                    matrix[row, column] = -matrix[row, column];
                }
            }

            return matrix;
        }



        public static Matrix operator *(Matrix firstMatrix, Matrix secondMatrix)
        {
            CheckOnNullMatrices(firstMatrix, secondMatrix);
            CheckMatricesSizesForMultiplication(firstMatrix, secondMatrix);

            var elements = new int[firstMatrix.LengthRows, secondMatrix.LengthColumns];

            for (var row = 0; row < firstMatrix.LengthRows; row++)
            {
                for (var column = 0; column < secondMatrix.LengthColumns; column++)
                {
                    elements[row, column] = SummaryMultiplication(firstMatrix, secondMatrix, column, row);
                }
            }

            return new Matrix(elements);
        }

        private static void CheckMatricesSizesForMultiplication(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.LengthColumns != secondMatrix.LengthRows)
            {
                throw new InvalidMatrixOperationException(firstMatrix.LengthRows, firstMatrix.LengthColumns,
                    secondMatrix.LengthRows, secondMatrix.LengthColumns);
            }
        }

        private static int SummaryMultiplication(Matrix firstMatrix, Matrix secondMatrix, int column, int row)
        {
            var result = 0;

            for (var i = 0; i < firstMatrix.LengthColumns; i++)
            {
                var a = firstMatrix.Elements[row, i];
                var b = secondMatrix.Elements[i, column];
                result += a * b;
            }

            return result;
        }
    }
}
