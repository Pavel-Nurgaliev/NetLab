using System.Linq;

namespace CheckPassword
{
    public class PasswordLengthChecker : IValidPasswordChecker
    {
        private const int ValidLength = 4;
        public bool IsValid(string password)
        {
            return password.Length == ValidLength;
        }
    }
}
