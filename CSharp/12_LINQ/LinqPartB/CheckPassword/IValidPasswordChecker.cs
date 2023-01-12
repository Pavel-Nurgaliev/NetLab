namespace CheckPassword
{
    internal interface IValidPasswordChecker
    {
        public bool IsValid(string password);
    }
}
