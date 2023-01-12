using Factory;
using Client;
using System.Collections.Generic;
using System;

namespace AbstractFactory.UI
{
    internal class Program
    {
        private const string FirstCustomerName = "Alex";
        private const string SecondCustomerName = "Ivan";
        public static void Main(string[] args)
        {
            OutputCustomers(InitListCustomers());
        }

        private static List<Customer> InitListCustomers()
        {
            IFactory[] factories = { new SchoolProductFactory(), new OfficeProductFactory() };

            List<Customer> customers = new List<Customer>();

            customers.Add(new Customer(factories[0], FirstCustomerName));

            customers.Add(new Customer(factories[1], SecondCustomerName));

            return customers;
        }

        private static void OutputCustomers(List<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("------------------------------");

                Console.WriteLine(customer.CustomerName);

                Console.WriteLine(customer.Factory.FactoryName);

                Console.WriteLine(customer.Factory.Table.TableName);
                Console.WriteLine(customer.Factory.Sofa.SofaName);
            }
        }
    }
}
