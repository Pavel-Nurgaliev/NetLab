
using System.Collections.Generic;

namespace BaseConversion
{
    public static class BaseSystemConverter
    {
        private const string BinAlphabet = "01";
        private const string OctAlphabet = "01234567";
        private const string HexAlphabet = "0123456789ABCDEF";
        private const string Base32Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUV";
        private const string Base64Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
        public static string ToBin(int number) => ToBase(number, BinAlphabet);

        public static string ToOct(int number) => ToBase(number, OctAlphabet);

        public static string ToHex(int number) => ToBase(number, HexAlphabet);

        public static string ToBase32(int number) => ToBase(number, Base32Alphabet);

        public static string ToBase64(int number) => ToBase(number, Base64Alphabet);

        private static string ToBase(int number, string baseAlphabet)
        {
            List<int> binNumbers = new List<int>();

            string result = string.Empty;

            while (number > 0)
            {
                binNumbers.Add(number % baseAlphabet.Length);

                number = number / baseAlphabet.Length;
            }

            for (var i = binNumbers.Count - 1; i >= 0; i--)
            {
                result += baseAlphabet[binNumbers[i]];
            }

            return result;
        }

    }
}
