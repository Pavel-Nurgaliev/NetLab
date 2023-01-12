using System.Linq;

namespace CheckPassword
{
    public class PasswordValidator
    {
        public static bool IsValid(string password)
        {
            IValidPasswordChecker[] checker = new IValidPasswordChecker[] {
                new PasswordLengthChecker(),
                new StringOfDigitalPasswordChecker(),
                new PasswordNonRepeatedNumbersChecker(),
                new PasswordConsecutiveNumbersChecker()};

            return checker.All(check => check.IsValid(password));
        }
    }
}
