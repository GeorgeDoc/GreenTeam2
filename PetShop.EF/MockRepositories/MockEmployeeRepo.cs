using PetShop.EF.Repositories;
using PetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.EF.MockRepositories
{
    public class MockEmployeeRepo : IEntityRepo<Employee>
    {
        private List<Employee> _employees = new List<Employee>
        {
            new Employee(){ID = 1, Name ="Takis",Surname="Manageridis",EmployeeType=EmployeeType.Manager, SallaryPerMonth=2000},
            new Employee(){ID = 2, Name ="Akis",Surname="Staffikis",EmployeeType=EmployeeType.Staff, SallaryPerMonth=450.60m},

        };
        public Task Create(Employee entity)
        {

            _employees.Add(entity);
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {

            var foundEmployee = _employees.SingleOrDefault(employee => employee.ID == id);
            if (foundEmployee is null)
                return Task.CompletedTask;

            _employees.Remove(foundEmployee);
            return Task.CompletedTask;
        }

        public List<Employee> GetAll()
        {
            return _employees;
        }

        public Employee? GetById(int id)
        {
            return _employees.SingleOrDefault(employee => employee.ID == id);
        }

        public Task Update(int id, Employee entity)
        {
            var foundEmployee = _employees.SingleOrDefault(employee => employee.ID == id);
            if (foundEmployee is null)
                return Task.CompletedTask;

            foundEmployee.Name = entity.Name;
            foundEmployee.Surname = entity.Surname;
            foundEmployee.EmployeeType = entity.EmployeeType;
            foundEmployee.SallaryPerMonth = entity.SallaryPerMonth;
            return Task.CompletedTask;
        }
    }
}
