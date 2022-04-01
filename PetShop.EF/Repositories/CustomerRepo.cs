using PetShop.EF.Context;
using PetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.EF.Repositories
{
    public class CustomerRepo : IEntityRepo<Customer>
    {
        public async Task Create(Customer entity)
        {
            using var context = new PetShopContext();
            context.Customers.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            using var context = new PetShopContext();
            var foundCustomer = context.Customers.SingleOrDefault(customer => customer.ID == id);
            if (foundCustomer is null)
                return;

            context.Customers.Remove(foundCustomer);
            await context.SaveChangesAsync();
        }

        public List<Customer> GetAll()
        {
            using var context = new PetShopContext();
            return context.Customers.ToList();
        }

        public Customer? GetById(int id)
        {
            using var context = new PetShopContext();
            return context.Customers.Where(customer => customer.ID == id).SingleOrDefault();
        }

        public async Task Update(int id, Customer entity)
        {
            using var context = new PetShopContext();
            var foundCustomer = context.Customers.SingleOrDefault(customer => customer.ID == id);
            if (foundCustomer is null)
                return;

            foundCustomer.Name = entity.Name;
            foundCustomer.Surname = entity.Surname;
            foundCustomer.Phone = entity.Phone;
            foundCustomer.TIN = entity.TIN;
            await context.SaveChangesAsync();
        }
    }
}
