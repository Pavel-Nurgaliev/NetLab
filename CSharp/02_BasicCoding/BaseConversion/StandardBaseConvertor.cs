using System;
using System.Text;


namespace BaseConversion
{
    public static class StandardBaseConvertor
    {
        public static string ToBinStandard(int number) => Convert.ToString(number, (int)BaseSystems.Bin);
        public static string ToOctStandard(int number) => Convert.ToString(number, (int)BaseSystems.Oct);
        public static string ToHexStandard(int number) => Convert.ToString(number, (int)BaseSystems.Hex).ToUpper();
        public static string ToBase32Standard(int number) => null;
        public static string ToBase64Standard(int number) => Convert.ToBase64String(Encoding.UTF8.GetBytes($"{number}"));

    }
}
