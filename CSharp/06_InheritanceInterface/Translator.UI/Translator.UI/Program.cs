using System;
using Translator;

namespace Translator.UI
{
    internal class Program
    {
        private const string InitCode = "It's CSharp code";
        private const string UsingLanguageCSharp = "CSharp";
        public static void Main(string[] args)
        {
            var code = InitCode;

            PrintResultConverting(code);
        }

        private static void PrintResultConverting(string code)
        {
            IConvertible[] convertibleObjects = {
                new ProgramConverter(), new ProgramHelper()};

            foreach (var convertibleObject in convertibleObjects)
            {

                if (convertibleObject is ICodeChecker codeChecker)
                {
                    if (codeChecker.CheckCodeSyntax(code, UsingLanguageCSharp))
                    {
                        var codeVB = convertibleObject.ConvertToVB(code);

                        Console.WriteLine(codeVB);
                    }
                    else
                    {
                        var codeCSharp = convertibleObject.ConvertToCSharp(code);

                        Console.WriteLine(codeCSharp);
                    }
                }
                else
                {
                    var codeVB = convertibleObject.ConvertToVB(code);

                    Console.WriteLine(codeVB);

                    var codeCSharp = convertibleObject.ConvertToCSharp(code);

                    Console.WriteLine(codeCSharp);
                }
            }
        }
    }
}
