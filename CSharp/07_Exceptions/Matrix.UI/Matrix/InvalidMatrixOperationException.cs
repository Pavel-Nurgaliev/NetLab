using System;
using System.Runtime.Serialization;

namespace Matrix
{
    [Serializable]
    public class InvalidMatrixOperationException : Exception
    {
        private const string MessageIncorrectLength = "Lengths of matrices not equal. (Sizes of matrices: first matrix = {0}x{1}, second matrix = {2}x{3})";

        public InvalidMatrixOperationException(int firstMatrixGetLenthRow, int firstMatrixGetLengthColumn,
            int secondMatrixGetLenthRow, int secondMatrixGetLengthColumn)
        {
            FirstMatrixGetLengthColumn = firstMatrixGetLengthColumn;
            SecondMatrixGetLengthColumn = secondMatrixGetLengthColumn;

            FirstMatrixGetLengthRow = firstMatrixGetLenthRow;
            SecondMatrixGetLengthRow = secondMatrixGetLenthRow;
        }

        public InvalidMatrixOperationException(int firstMatrixGetLenthRow, int firstMatrixGetLengthColumn,
            int secondMatrixGetLenthRow, int secondMatrixGetLengthColumn, string message) : base(message)
        {
            FirstMatrixGetLengthColumn = firstMatrixGetLengthColumn;
            SecondMatrixGetLengthColumn = secondMatrixGetLengthColumn;

            FirstMatrixGetLengthRow = firstMatrixGetLenthRow;
            SecondMatrixGetLengthRow = secondMatrixGetLenthRow;
        }

        public InvalidMatrixOperationException(int firstMatrixGetLenthRow, int firstMatrixGetLengthColumn,
            int secondMatrixGetLenthRow, int secondMatrixGetLengthColumn, string message, Exception exception)
            : base(message, exception)
        {
            FirstMatrixGetLengthColumn = firstMatrixGetLengthColumn;
            SecondMatrixGetLengthColumn = secondMatrixGetLengthColumn;

            FirstMatrixGetLengthRow = firstMatrixGetLenthRow;
            SecondMatrixGetLengthRow = secondMatrixGetLenthRow;
        }

        public InvalidMatrixOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            FirstMatrixGetLengthColumn = (int)info.GetValue(nameof(FirstMatrixGetLengthColumn), typeof(int));
            FirstMatrixGetLengthRow = (int)info.GetValue(nameof(FirstMatrixGetLengthRow), typeof(int));

            SecondMatrixGetLengthColumn = (int)info.GetValue(nameof(SecondMatrixGetLengthColumn), typeof(int));
            SecondMatrixGetLengthRow = (int)info.GetValue(nameof(SecondMatrixGetLengthRow), typeof(int));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(FirstMatrixGetLengthColumn), FirstMatrixGetLengthColumn);
            info.AddValue(nameof(FirstMatrixGetLengthRow), FirstMatrixGetLengthRow);

            info.AddValue(nameof(SecondMatrixGetLengthColumn), SecondMatrixGetLengthColumn);
            info.AddValue(nameof(SecondMatrixGetLengthRow), SecondMatrixGetLengthRow);

            base.GetObjectData(info, context);
        }

        public int FirstMatrixGetLengthColumn { get; private set; }
        public int FirstMatrixGetLengthRow { get; private set; }
        public int SecondMatrixGetLengthColumn { get; private set; }
        public int SecondMatrixGetLengthRow { get; private set; }


        public override string Message => String.Format(MessageIncorrectLength,
            FirstMatrixGetLengthRow, FirstMatrixGetLengthColumn,
            SecondMatrixGetLengthRow, SecondMatrixGetLengthColumn);
    }
}
