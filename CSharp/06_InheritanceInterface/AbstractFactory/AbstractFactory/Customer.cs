using Factory;
using Product;

namespace Client
{
    public class Customer
    {
        public Customer(IFactory factory, string customerName)
        {
            Factory = factory;

            CustomerName = customerName;
        }

        public string CustomerName { get; private set; }

        public IFactory Factory { get; private set; }

        public ITable table => Factory.Table;
        public ISofa sofa => Factory.Sofa;
    }
}
