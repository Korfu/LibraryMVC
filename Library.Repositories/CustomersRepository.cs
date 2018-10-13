using Library.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        public Customer Get(int id)
        {
            using (var context = new LibraryContext())
            {
                //dodanie Include() zwraca nam cały obiekt a nie tylko klucz główny, potrzebujemy tego, aby dobrać się do nazwy genre, bo ona była "głębiej w modelu"
                return context.Customer.SingleOrDefault(x => x.Id == id);
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            using (var context = new LibraryContext())
            {
                //dodanie Include() zwraca nam cały obiekt a nie tylko klucz główny, potrzebujemy tego, aby dobrać się do nazwy genre, bo ona była "głębiej w modelu"
                return context.Customer.ToList();
            }
        }

        public int Add(Customer customer)
        {
            using (var context = new LibraryContext())
            {
                context.Customer.Add(customer);
                context.SaveChanges();
                return customer.Id;
            }
        }

        public void Edit(Customer customer)
        {
            using (var context = new LibraryContext())
            {
                var originalCustomer = context.Customer.Find(customer.Id);
                context.Entry(originalCustomer).CurrentValues.SetValues(customer);
                context.SaveChanges();
            }
        }

        public void Delete(Customer customer)
        {
            using (var context = new LibraryContext())
            {
                var originalCustomer = context.Customer.Find(customer.Id);
                context.Customer.Remove(originalCustomer);
                context.SaveChanges();
            }
        }

    }

    public interface ICustomersRepository
    {
        Customer Get(int id);
        IEnumerable<Customer> GetAll();
        int Add(Customer customer);
        void Edit(Customer customer);
        void Delete(Customer customer);
    }
}
