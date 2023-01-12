using System;
using System.Collections.Generic;
using ConsoleInput;

namespace Matrix.UI
{
    public static class InputDataHelper
    {
        private const string MessageInputColumn = "Enter amount column elements of matrix";
        private const string MessageInputRow = "Enter amount row elements of matrix";

        private const string MessageInputMatrixElements = "Enter matrix elements of row number {0}";

        private const string NegativeMessageRage = "Amount elements of matrix was not be less than zero. Repeat enter.";

        private const string NegativeMessageElement = "Element've invalid format";
        public static int[,] InitializeMatrixWithRange()
        {
            var elements = InitArrayElements(CreateEmptyArrayElements());

            return elements;
        }

        private static int[,] InitArrayElements(int[,] elements)
        {
            for (var i = 0; i < elements.GetLength(0); i++)
            {
                Console.WriteLine(MessageInputMatrixElements, i);

                for (var j = 0; j < elements.GetLength(1); j++)
                {
                    elements[i, j] = InvitationInputHelper.InputInteger(string.Empty, NegativeMessageElement);
                }
            }

            return elements;
        }

        private static int[,] CreateEmptyArrayElements()
        {
            var row = InvitationInputHelper.InputInteger(MessageInputRow, NegativeMessageRage, 0);

            var column = InvitationInputHelper.InputInteger(MessageInputColumn, NegativeMessageRage, 0);

            int[,] elements = new int[row, column];

            return elements;
        }

        public static int[,] InitializeMatrixWithoutRange()
        {
            var elementsList = CreateListElements(out var row, out var countRow);

            var elements = InitListToArray(elementsList, row, countRow);

            return elements;
        }

        private static int[,] InitListToArray(List<List<int>> elements, List<int> row, int countRow)
        {
            int MaxCountElementsInRow = SortCountsInRow(elements, countRow);

            int[,] resultMatrix = new int[row.Count, MaxCountElementsInRow];

            for (var rowIndex = 0; rowIndex < resultMatrix.GetLength(0); rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < resultMatrix.GetLength(1); columnIndex++)
                {
                    try
                    {
                        resultMatrix[rowIndex, columnIndex] = elements[rowIndex][columnIndex];
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        resultMatrix[rowIndex, columnIndex] = 0;
                    }
                }
            }

            return resultMatrix;
        }

        private static List<List<int>> CreateListElements(out List<int> row, out int countRow)
        {
            row = new List<int>();

            var elements = new List<List<int>>();

            int element = 0;

            countRow = 0;

            string inputMessageElement = string.Empty;

            Console.WriteLine(MessageInputMatrixElements, countRow);

            while (int.TryParse(Console.ReadLine(), out element))//column
            {
                row.Add(++countRow);

                List<int> column = new List<int>();

                do
                {
                    column.Add(element);
                }
                while (int.TryParse(inputMessageElement = Console.ReadLine(), out element));//row

                if (inputMessageElement != string.Empty)
                {
                    throw new ArgumentOutOfRangeException(inputMessageElement);
                }

                elements.Add(column);

                Console.WriteLine(MessageInputMatrixElements, countRow);
            }

            return elements;
        }

        private static int SortCountsInRow(List<List<int>> elements, int countRow)
        {
            int[] countList = new int[countRow];

            int i = 0;
            foreach (var element in elements)
            {
                countList[i] = element.Count;

                i++;
            }

            Array.Sort(countList);

            return countList[countList.Length - 1];
        }
    }
}
