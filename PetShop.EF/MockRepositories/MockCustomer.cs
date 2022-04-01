using PetShop.EF.Context;
using PetShop.EF.Repositories;
using PetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.EF.MockRepositories
{
    public class MockCustomerRepo : IEntityRepo<Customer>
    {
        private List<Customer> _customers = new List<Customer>
        {
            new Customer(){ ID=1, Name="Giannis",Surname="Polychroniadis", Phone = 1234567890, TIN="1234567890"},
            new Customer(){ ID=2, Name="Giorge",Surname="Aivaliotis", Phone=0987654321, TIN="0987654321"},
            new Customer(){ ID=3, Name="Theodoros",Surname="Petsagkas",Phone=1230987654, TIN="1230987654"},
            new Customer(){ID=4, Name="Dimitris",Surname="Tserkezidis",Phone=0981234567, TIN="0981234567"}
        };
        public  Task Create(Customer entity)
        {
                
            _customers.Add(entity);
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
                
            var foundCustomer = _customers.SingleOrDefault(customer => customer.ID == id);
            if (foundCustomer is null)
                return Task.CompletedTask;

            _customers.Remove(foundCustomer);
            return Task.CompletedTask;
        }

        public List<Customer> GetAll()
        {
            return _customers;
        }

        public Customer? GetById(int id)
        {
            return _customers.SingleOrDefault(customer => customer.ID == id);
        }

        public Task Update(int id, Customer entity)
        {
            var foundCustomer = _customers.SingleOrDefault(customer => customer.ID == id);
            if (foundCustomer is null)
                return Task.CompletedTask;

            foundCustomer.Name = entity.Name;
            foundCustomer.Surname = entity.Surname;
            foundCustomer.Phone = entity.Phone;
            foundCustomer.TIN = entity.TIN;
            return Task.CompletedTask;
        }
    }
}


