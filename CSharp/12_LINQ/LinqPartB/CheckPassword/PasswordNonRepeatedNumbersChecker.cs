using System.Linq;

namespace CheckPassword
{
    public class PasswordNonRepeatedNumbersChecker : IValidPasswordChecker
    {
        public const int MaxCountRepeatedNumbers = 2;

        public bool IsValid(string password)
        {
            var result = !password.Any(symbol => password.Count(symbComp => symbol.Equals(symbComp)) > MaxCountRepeatedNumbers);

            return result;
        }
    }
}
