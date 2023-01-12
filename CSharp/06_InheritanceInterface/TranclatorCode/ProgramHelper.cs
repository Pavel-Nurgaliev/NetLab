using System;

namespace Translator
{
    public class ProgramHelper : ProgramConverter, ICodeChecker
    {
        public bool CheckCodeSyntax(string data, string usingLanguage)
        {
            return data.Contains(usingLanguage);
        }
    }
}
