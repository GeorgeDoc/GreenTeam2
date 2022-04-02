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

namespace PetShop.MVC.Controllers
{
    public class CustomersController : Controller
    {
        private readonly PetShopContext _context;
        private readonly IEntityRepo<Customer> _customerRepo;


        public CustomersController(IEntityRepo<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await _customerRepo.GetAllAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepo.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }
            var viewCustomer = new CustomerDetailsViewModel()
            {
                ID=customer.ID,
                Name = customer.Name,
                Surname = customer.Surname,
                TIN=customer.TIN,
                Phone=customer.Phone
            };
            return View(viewCustomer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {


            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Surname,Phone,TIN")] CustomerCreateViewModel customer)
        {
            if (ModelState.IsValid)
            {
                var dbCustomer = new Customer()
                {
                    Name = customer.Name,
                    Surname = customer.Surname,
                    TIN = customer.TIN,
                    Phone = customer.Phone
                };
                await _customerRepo.AddAsync(dbCustomer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepo.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            var viewCustomer = new CustomerEditViewModel()
            {
                Name=customer.Name,
                Surname=customer.Surname,
                TIN= customer.TIN,
                Phone= customer.Phone
            };

            return View(viewCustomer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Surname,Phone,TIN,ID")] CustomerEditViewModel customer)
        {
            if (id != customer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var dbCustomer = await _customerRepo.GetByIdAsync(customer.ID);
                if (dbCustomer is null)
                    return BadRequest($"Can't find a customer with id '{id}'");

                dbCustomer.Name = customer.Name;
                dbCustomer.Surname = customer.Surname;
                dbCustomer.TIN = customer.TIN;
                dbCustomer.Phone = customer.Phone;
                await _customerRepo.UpdateAsync(id, dbCustomer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbCustomer = await _customerRepo.GetByIdAsync(id.Value);
            if (dbCustomer == null)
            {
                return NotFound();
            }

            var viewCustomer = new CustomerDeleteViewModel()
            {
                ID=dbCustomer.ID,
                Name = dbCustomer.Name,
                Surname = dbCustomer.Surname,
                TIN = dbCustomer.TIN,
                Phone = dbCustomer.Phone

            };
            return View(viewCustomer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _customerRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.ID == id);
        }
    }
}
