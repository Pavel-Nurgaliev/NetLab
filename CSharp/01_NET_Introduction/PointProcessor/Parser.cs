using System.Globalization;

namespace PointProcessor
{
    public static class Parser
    {
        private const char nextNumber = ',';
        private const char decimalSeparator = '.';
        private const int countNumbersOfLine = 2;

        private const int positionOfCoordinateX = 0;
        private const int positionOfCoordinateY = 1;

        public static bool TryParsePoint(string line, out Point point)
        {
            point = null;

            if (line == null)
            {
                return false;
            }

            var elements = line.Split(nextNumber);

            var pointOfLine = new decimal[countNumbersOfLine];


            if (elements.Length == countNumbersOfLine && TryParseCoordinate(elements[positionOfCoordinateX], out pointOfLine[positionOfCoordinateX])
                && TryParseCoordinate(elements[positionOfCoordinateY], out pointOfLine[positionOfCoordinateY]))
            {
                point = new Point(pointOfLine[positionOfCoordinateX], pointOfLine[positionOfCoordinateY]);

                return true;
            }

            return false;
        }

        private static bool TryParseCoordinate(string line, out decimal coordinate)
        {
            return decimal.TryParse(line, NumberStyles.Number, new NumberFormatInfo { NumberDecimalSeparator = decimalSeparator.ToString() },
                out coordinate);
        }
    }
}
