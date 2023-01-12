using Product;

namespace Factory
{
    public class OfficeProductFactory : IFactory
    {
        private readonly ISofa sofa = new OfficeSofa();
        private readonly ITable table = new OfficeTable();

        public string FactoryName => nameof(OfficeProductFactory);
        public ISofa Sofa => sofa;
        public ITable Table => table;
    }
}
