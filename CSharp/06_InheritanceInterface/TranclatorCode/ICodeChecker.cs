namespace Translator
{
    public interface ICodeChecker
    {
        public bool CheckCodeSyntax(string data, string usingLanguage);
    }
}
