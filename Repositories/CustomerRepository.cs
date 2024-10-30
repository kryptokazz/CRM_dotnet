// Repositories/CustomerRepository.cs
using System.Collections.Generic;
using CRMApp.Models;

namespace CRMApp.Repositories
{
    public class CustomerRepository
    {
        private readonly List<Customer> _customers = new List<Customer>();
        private int _currentId = 1;

        public IEnumerable<Customer> GetAll() => _customers;

        public Customer GetById(int id) => _customers.Find(c => c.Id == id);

        public void Add(Customer customer)
        {
            customer.Id = _currentId++;
            _customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            var index = _customers.FindIndex(c => c.Id == customer.Id);
            if (index != -1)
                _customers[index] = customer;
        }

        public void Delete(int id)
        {
            var customer = GetById(id);
            if (customer != null)
                _customers.Remove(customer);
        }
    }
}

