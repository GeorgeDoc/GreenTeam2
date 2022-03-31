using PetShop.EF.Context;
using PetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.EF.Repositories
{
    public class EmployeeRepo : IEntityRepo<Employee>
    {
        public async Task Create(Employee entity)
        {
            using var context = new PetShopContext();
            context.Employees.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            using var context = new PetShopContext();
            var foundEmployee = context.Employees.SingleOrDefault(employee => employee.ID == id);
            if (foundEmployee is null)
                return;

            context.Employees.Remove(foundEmployee);
            await context.SaveChangesAsync();
        }

        public List<Employee> GetAll()
        {
            using var context = new PetShopContext();
            return context.Employees.ToList();
        }

        public Employee? GetById(int id)
        {
            using var context = new PetShopContext();
            return context.Employees.Where(employee => employee.ID == id).SingleOrDefault();
        }

        public async Task Update(int id, Employee entity)
        {
            using var context = new PetShopContext();
            var foundEmployee = context.Employees.SingleOrDefault(employee => employee.ID == id);
            if (foundEmployee is null)
                return;

            foundEmployee.Name = entity.Name;
            foundEmployee.Surname = entity.Surname;
            foundEmployee.EmployeeType = entity.EmployeeType;
            foundEmployee.SallaryPerMonth = entity.SallaryPerMonth;
            await context.SaveChangesAsync();
        }
    }
}
