using Product;

namespace Factory
{
    public class SchoolProductFactory : IFactory
    {
        private readonly ISofa sofa = new SchoolSofa();
        private readonly ITable table = new SchoolTable();

        public string FactoryName => nameof(SchoolProductFactory);
        public ISofa Sofa => sofa;
        public ITable Table => table;
    }
}
