using Product;

namespace Factory
{
    public interface IFactory
    {
        public string FactoryName { get; }
        public ITable Table { get; }
        public ISofa Sofa { get; }

    }
}
