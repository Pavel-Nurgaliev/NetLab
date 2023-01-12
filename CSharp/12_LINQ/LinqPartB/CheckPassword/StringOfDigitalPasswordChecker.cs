using System.Linq;

namespace CheckPassword
{
    public class StringOfDigitalPasswordChecker : IValidPasswordChecker
    {
        public bool IsValid(string password)
        {
            return password.All(symbol => char.IsDigit(symbol));
        }
    }
}
