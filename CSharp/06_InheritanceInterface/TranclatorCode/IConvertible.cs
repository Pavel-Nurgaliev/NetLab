namespace Translator
{
    public interface IConvertible
    {
        public string ConvertToCSharp(string data);

        public string ConvertToVB(string data);
    }
}
