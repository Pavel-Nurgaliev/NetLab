using System;

namespace Translator
{
    public class ProgramConverter : IConvertible
    {
        private const string MessageOfConvertToCsharp = "Code was converted to CSharp code";
        private const string MessageOfConvertToVB = "Code was converted to VB code";

        protected const string UsingLanguageVB = "VB";
        protected const string UsingLanguageCSharp = "CSharp";
        public string ConvertToCSharp(string data)
        {
            return MessageOfConvertToCsharp + Environment.NewLine + data.Replace(UsingLanguageVB, UsingLanguageCSharp);
        }

        public string ConvertToVB(string data)
        {
            return MessageOfConvertToVB + Environment.NewLine + data.Replace(UsingLanguageCSharp, UsingLanguageVB);
        }
    }
}
