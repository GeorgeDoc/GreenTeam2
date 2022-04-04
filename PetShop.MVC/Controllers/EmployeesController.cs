#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.EF.Context;
using PetShop.EF.Repositories;
using PetShop.Model;
using PetShop.MVC.Models;
using static PetShop.MVC.Models.EmployeeCreateViewModel;

namespace PetShop.MVC.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly IEntityRepo<Employee> _employeeRepo;
        public EmployeesController(IEntityRepo<Employee> employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _employeeRepo.GetAllAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepo.GetByIdAsync(id.Value); //.Value επιστρέφει την non-null τιμή
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Surname,EmployeeType,SallaryPerMonth")] EmployeeCreateViewModel employee)
        {   //normally we don't want a new id here, it's created anyway by the configure
            if (ModelState.IsValid) // if model is valid, do what you gotta, then return to Index page
            {
                var newEmployee = new Employee()
                {
                    Name = employee.Name,
                    Surname = employee.Surname,
                    EmployeeType = employee.EmployeeType,
                    SallaryPerMonth = employee.SallaryPerMonth
                };
                _employeeRepo.AddAsync(newEmployee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee); // if not valid, return to Create page to correct your mistakes
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepo.GetByIdAsync(id.Value);
    
            if (employee == null)
            {
                return NotFound();
            }

            var emp = new EmployeeEditViewModel()
            {
                ID = employee.ID,
                Name = employee.Name,
                Surname = employee.Surname,
                EmployeeType = employee.EmployeeType,
                SallaryPerMonth = employee.SallaryPerMonth,

            };
            return View(emp);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Name,Surname,EmployeeType,SallaryPerMonth")] EmployeeEditViewModel employee)
        {
            if (id == 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var dbEmployee = await _employeeRepo.GetByIdAsync(id.Value);
                if (dbEmployee is null)
                    return BadRequest($"Can't find an empployee with id '{id}'");
                dbEmployee.Name = employee.Name;
                dbEmployee.Surname = employee.Surname;
                dbEmployee.SallaryPerMonth = employee.SallaryPerMonth;
                dbEmployee.EmployeeType = employee.EmployeeType;

                await _employeeRepo.UpdateAsync(id.Value, dbEmployee);
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepo.GetByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _employeeRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool EmployeeExists(int id)
        //{
        //    return _context.Employees.Any(e => e.ID == id);
        //}
    }
}
