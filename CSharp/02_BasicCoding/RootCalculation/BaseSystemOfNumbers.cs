using System;
using System.Collections.Generic;

namespace BaseSystem
{
    public class BaseSystemOfNumbers
    {
        public static string ToBin(int number)
        {
            Binary initBinary = new Binary(number);

            return initBinary.Result;
        }

        public static string ToOct(int number)
        {
            Octal initOctal = new Octal(number);

            return initOctal.Result;
        }

        public static string ToHex(int number)
        {
            Hexadecimal initHex = new Hexadecimal(number);

            return initHex.Result;
        }

        public static string ToBase32(int number)
        {
            Base32 initBase32 = new Base32(number);

            return initBase32.Result;
        }

        public static string ToBase64(int number)
        {
            Base64 initBase64 = new Base64(number);

            return initBase64.Result;
        }

        public static string ToBase(int number, int bit)
        {
            switch (bit)
            {
                case 2:
                    return ToBin(number);
                case 8:
                    return ToOct(number);
                case 16:
                    return ToHex(number);
                case 32:
                    return ToBase32(number);
                case 64:
                    return ToBase64(number);
            }
            return "Incorrect data";
        }
    }
}
