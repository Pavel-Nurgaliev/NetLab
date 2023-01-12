using System;

namespace Matrix
{
    internal static class ArrayExtensions
    {
        private const int RowsIndex = 0;
        private const int ColumnsIndex = 1;

        public static int RowsCount(this int[,] elements) => elements.GetLength(RowsIndex);
        public static int ColumnsCount(this int[,] elements) => elements.GetLength(ColumnsIndex);
    }
}
