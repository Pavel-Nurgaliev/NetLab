using System;
using ConsoleInput;

namespace BaseConversion.UI
{
    public class Program
    {
        private const string StartInputNumber = "Number must be integer and not negative. Number=";

        private const string NegativeInputNumber = "Number not correct. Repeat enter";

        private const string PositiveMessageOfEquals = "Results are equal.";

        private const string NegativeMessageOfEquals = "Results are not equal.";

        private const string MessageOfConvert = "Own method: {0}, Standard method: {1}";

        public static void Main(string[] args)
        {
            var number = InvitationInputHelper.InputInteger(StartInputNumber, NegativeInputNumber);

            ConvertNumberAndPrint(number);
        }

        private static void ConvertNumberAndPrint(int number)
        {
            Print(BaseSystemConverter.ToBin(number), StandardBaseConvertor.ToBinStandard(number), "binary");
            Print(BaseSystemConverter.ToOct(number), StandardBaseConvertor.ToOctStandard(number), "octal");
            Print(BaseSystemConverter.ToHex(number), StandardBaseConvertor.ToHexStandard(number), "hexadecimal");
            Print(BaseSystemConverter.ToBase32(number), StandardBaseConvertor.ToBase32Standard(number), "32");
            Print(BaseSystemConverter.ToBase64(number), StandardBaseConvertor.ToBase64Standard(number), "64");
        }

        private static void Print(string resultStringConvertByOwnMethod, string resultStringConvertByStandardMethod, string stringOfNameBase)
        {
            Console.WriteLine("The base is {0}", stringOfNameBase);
            Console.WriteLine(MessageOfConvert, resultStringConvertByOwnMethod, resultStringConvertByStandardMethod);
            Console.WriteLine(resultStringConvertByOwnMethod.Equals(resultStringConvertByStandardMethod)
                ? PositiveMessageOfEquals : NegativeMessageOfEquals);
        }

    }
}
