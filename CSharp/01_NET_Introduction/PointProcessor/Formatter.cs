using System;
using System.Globalization;

namespace PointProcessor
{
    public class Formatter
    {
        public static string Format(Point point)
        {
            if (point == null) return null;


            (decimal integer, decimal fractional) x = GetNumberParts(point.X);
            (decimal integer, decimal fractional) y = GetNumberParts(point.Y);

            var cultureInfo = new CultureInfo("ru-Ru")
            {
                NumberFormat = new NumberFormatInfo { NumberDecimalSeparator = "," }
            };

            return String.Format(cultureInfo, $"X: {x.integer,4:###0}{x.fractional,-5:.0###}" +
                $" Y: {y.integer,4:###0}{y.fractional,-5:.0###}");
        }

        private static (decimal integer, decimal fractional) GetNumberParts(decimal x)
        {
            var integer = Math.Truncate(x);

            var fractional = x - integer;

            return (integer, fractional);
        }
    }
}
