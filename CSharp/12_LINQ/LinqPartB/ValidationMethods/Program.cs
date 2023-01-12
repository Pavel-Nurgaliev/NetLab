using CheckPassword;
using ConsoleInput;
using FindWord;
using System;

namespace ValidationMethods
{
    internal class Program
    {
        private const string InvitationInputMessage =
            "Choose option of app. Enter \'1\' - Find frequent word in string. Or \'2\' - Check password on validity.";
        private const string NegativeInputMessage = "Data entry error. Repeat enter please";

        private const int MinRangeOfInputData = 0;
        private const int MaxRangeOfInputData = 3;

        private const string InputStringMessage = "Enter string.";
        private const string InputPasswordMessage = "Enter password. Password must be digital.";

        private const string ResultFindFrequentWord = "Frequent word of string \'{0}\'";

        private const string ValidResultValidationPassword = "Password is valid";
        private const string InvalidResultatValidationPassword = "Password is not valid";

        private const string ContinueMessage = "If you want go back press \'Enter\' key. Or press any key";
        private const string StopMessage = "If you want stop app operation  press \'Enter\' key. Or press any key";
        static void Main(string[] args)
        {
            ProcessData();
        }

        private static void ProcessData()
        {
            do
            {
                var option = InvitationInputHelper.InputInteger(InvitationInputMessage, NegativeInputMessage,
                    MinRangeOfInputData, MaxRangeOfInputData);

                do
                {
                    ProcessOptionAndStart(option);

                    Console.WriteLine(ContinueMessage);
                }
                while (Console.ReadLine() != string.Empty);

                Console.WriteLine(StopMessage);
            }
            while (Console.ReadLine() != string.Empty);
        }

        private static void ProcessOptionAndStart(int option)
        {
            if (option == 1)
            {
                Console.WriteLine(InputStringMessage);

                var inputMessage = Console.ReadLine();

                var frequentWord = StringProcessor.GetFrequentWordInString(inputMessage);
                Console.WriteLine(string.Format(ResultFindFrequentWord, frequentWord));
            }
            else
            {
                Console.WriteLine(InputPasswordMessage);

                var password = Console.ReadLine();

                PrintResultMessageAboutValidPassword(password);
            }
        }

        private static void PrintResultMessageAboutValidPassword(string password)
        {
            if (PasswordValidator.IsValid(password))
            {
                Console.WriteLine(ValidResultValidationPassword);
            }
            else
            {
                Console.WriteLine(InvalidResultatValidationPassword);
            }
        }
    }
}
