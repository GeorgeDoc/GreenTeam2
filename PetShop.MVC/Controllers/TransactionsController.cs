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
    public class TransactionsController : Controller
    {
        private readonly PetShopContext _context;
        private readonly IEntityRepo<Transaction> _transactionRepo;
        private readonly IEntityRepo<Pet> _petRepo;
        private readonly IEntityRepo<PetFood> _petFoodRepo;
        private readonly IEntityRepo<Customer> _customerRepo;
        private readonly IEntityRepo<Employee> _employeeRepo;


        public TransactionsController(IEntityRepo<Transaction> transactionRepo,
            IEntityRepo<Pet> petRepo, IEntityRepo<PetFood> petFoodRepo, 
            IEntityRepo<Customer> customerRepo, IEntityRepo<Employee> employeeRepo)
        {
            _transactionRepo = transactionRepo;
            _petRepo=petRepo;
            _petFoodRepo = petFoodRepo;
            _customerRepo=customerRepo;
            _employeeRepo = employeeRepo;
        }






        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Sell([Bind("CustomerID,EmployeeID,Pet,PetFoodID,PetFoodQty")] TransactionSellViewModel sellModel) {


        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout([Bind("CustomerID,EmployeeID,PetID,PetFoodID,PetFoodQty")] TransactionSellViewModel sellModel) {


            var vm = new TransactionSellViewModel();
            if (sellModel.PetFoodID > 0 ) {
                var petfood = await _petFoodRepo.GetByIdAsync(sellModel.PetFoodID);
                sellModel.PetFoodPrice = petfood.Price;
            }
            
            if (sellModel.PetID > 0) {
                var pet = await _petRepo.GetByIdAsync(sellModel.PetID);
                sellModel.PetPrice = pet.Price;
            }
            sellModel.TotalPrice = sellModel.PetPrice + (sellModel.PetFoodPrice * (sellModel.PetFoodQty-1));

            return View(sellModel);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sell([Bind("CustomerID,EmployeeID,PetID, PetFoodID,PetFoodPrice,TotalPrice, PetPrice,PetFoodQty")] TransactionSellViewModel sellModel) {


            if (sellModel.CustomerID > 0 && sellModel.PetID > 0 && sellModel.PetFoodID > 0 && sellModel.EmployeeID >0) {
                var dbtrans = new Transaction()
                { 

                    CustomerID = sellModel.CustomerID,
                    EmployeeID = sellModel.EmployeeID,
                    PetID = sellModel.PetID,
                    PetPrice = sellModel.PetPrice,
                    PetFoodID = sellModel.PetFoodID,
                    PetFoodQty = sellModel.PetFoodQty,
                    PetFoodPrice = sellModel.PetFoodPrice,
                    TotalPrice = sellModel.TotalPrice
                };

                //var customer = await _customerRepo.GetByIdAsync(sellModel.CustomerID);
                //dbtrans.Customer = new Customer();
                //dbtrans.Customer.Name = customer.Name;
                //dbtrans.Customer.Surname = customer.Surname;
                //dbtrans.Customer.Phone = customer.Phone;
                //dbtrans.Customer.TIN = customer.TIN;

                //var employee = await _employeeRepo.GetByIdAsync(sellModel.EmployeeID);
                //dbtrans.Employee = employee as Employee;

                //var pet = await _petRepo.GetByIdAsync(sellModel.PetID);
                //dbtrans.Pet = pet as Pet;

                //var petFood = await _petFoodRepo.GetByIdAsync(sellModel.PetFoodID);
                //dbtrans.PetFood = petFood as PetFood;

                await _transactionRepo.AddAsync(dbtrans);
                return RedirectToAction("Index");

            }

            return View();
        }


        public async Task<IActionResult> Sell(int? id) {

            if (id == null) {
                return NotFound();
            }
            //var customer = await _customerRepo.GetByIdAsync(id.Value);
            //if (customer == null)
            //    return NotFound();

            // Find Customers

            var sellViewModel = new TransactionSellViewModel();

            var customers=await _customerRepo.GetAllAsync();
            var selectedCustomers = new List<Customer>();
            foreach (var item in customers)
            {
                selectedCustomers.Add(item as Customer);
            }
            sellViewModel.CustomersList = new SelectList(selectedCustomers, "ID", "Name");


            //Find Pet
            var pet = await _petRepo.GetByIdAsync(id.Value);
            sellViewModel.Pet = pet;
            if (pet == null) {
                return NotFound();
            }

            //Find selected Pet petFood
            var petFoods = await _petFoodRepo.GetAllAsync();
            var selectedPetFoods = new List<PetFood>();
            foreach (var item in petFoods) {
                if(item.AnimalType == pet.AnimalType)
                    selectedPetFoods.Add(item);
            }
            sellViewModel.PetFoodList = new SelectList(selectedPetFoods,"ID","Price");

            //Find Employees
            var employees = await _employeeRepo.GetAllAsync();
            var selectedEmployees = new List<Employee>();
            foreach (var item in employees) {
                selectedEmployees.Add(item as Employee);
            }
            sellViewModel.EmployeesList = new SelectList(selectedEmployees, "ID", "Name");

            return View(sellViewModel);
        }
            // GET: Transactions
            public async Task<IActionResult> Index()
        {
            var dbtrans = await _transactionRepo.GetAllAsync();

            var model = new TransactionIndexViewModel();

            foreach (var item in dbtrans) {

                model.Transactions.Add(item);
            }
            foreach (var item in model.Transactions) {
                var customer = await _customerRepo.GetByIdAsync(item.CustomerID);
                item.Customer.Name = customer.Name;
                item.Customer.Surname = customer.Surname;
                item.Customer.TIN = customer.TIN;
                item.Customer.Phone = customer.Phone;

                var emp = await _employeeRepo.GetByIdAsync(item.EmployeeID);
                item.Employee.Name = emp.Name;
                item.Employee.Surname = emp.Surname;
                item.Employee.EmployeeType = emp.EmployeeType;
                item.Employee.SallaryPerMonth = emp.SallaryPerMonth;


            }

            //var petShopContext = _context.Transactions.Include(t => t.Customer).Include(t => t.Employee).Include(t => t.Pet).Include(t => t.PetFood);
            return View(model);
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _transactionRepo.GetByIdAsync(id.Value);
            if (transaction == null)
            {
                return NotFound();
            }

            var viewTransaction = new TransactionDetailsViewModel()
            {
                ID = transaction.ID,
                Date = transaction.Date,
                CustomerID = transaction.CustomerID,
                EmployeeID = transaction.EmployeeID,
                PetID = transaction.PetID,
                PetPrice = transaction.PetPrice,
                PetFoodID = transaction.PetFoodID,
                PetFoodQty = transaction.PetFoodQty,
                PetFoodPrice = transaction.PetFoodPrice,
                TotalPrice = transaction.TotalPrice,
            };

            return View(viewTransaction);
        }

        // GET: Transactions/Create
        public async Task<IActionResult> Create()
        {
            var petList = await _petRepo.GetAllAsync();
            var canBeSoldList = new List<Pet>();
            var transactions = await _transactionRepo.GetAllAsync();
            foreach (var item in petList) {
                if (item.PetStatus != PetStatus.Unhealthy)
                    canBeSoldList.Add(item);
                foreach (var trans in transactions) {
                    if (item.ID == trans.PetID)
                            canBeSoldList.Remove(item);
                }
            }
            return View(canBeSoldList);
        }


        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _transactionRepo.GetByIdAsync(id.Value);
            if (transaction == null)
            {
                return NotFound();
            }
            var viewTransaction = new TransactionEditViewModel()
            {
                Date = transaction.Date,
                CustomerID = transaction.CustomerID,
                EmployeeID = transaction.EmployeeID,
                PetID = transaction.PetID,
                PetPrice = transaction.PetPrice,
                PetFoodID = transaction.PetFoodID,
                PetFoodQty = transaction.PetFoodQty,
                PetFoodPrice = transaction.PetFoodPrice,
                TotalPrice = transaction.TotalPrice,
            };
            return View(viewTransaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Date,CustomerID,EmployeeID,PetID,PetPrice,PetFoodID,PetFoodQty,PetFoodPrice,TotalPrice,ID")] TransactionEditViewModel transaction)
        {
            if (id != transaction.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var dbTransaction = await _transactionRepo.GetByIdAsync(transaction.ID);
                if (dbTransaction is null)
                    return BadRequest($"Can not find transaction with id '{id}'");
                dbTransaction.Date = transaction.Date;
                dbTransaction.CustomerID = transaction.CustomerID;
                dbTransaction.EmployeeID = transaction.EmployeeID;
                dbTransaction.PetID = transaction.PetID;
                dbTransaction.PetPrice = transaction.PetPrice;
                dbTransaction.PetFoodID = transaction.PetFoodID;
                dbTransaction.PetFoodQty = transaction.PetFoodQty;
                dbTransaction.PetFoodPrice = transaction.PetFoodPrice;
                dbTransaction.TotalPrice = transaction.TotalPrice;
            }
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbTransaction = await _transactionRepo.GetByIdAsync(id.Value);
            if (dbTransaction == null)
            {
                return NotFound();
            }

            var viewTransaction = new TransactionDeleteViewModel()
            {
                ID = dbTransaction.ID,
                CustomerID = dbTransaction.CustomerID,
                EmployeeID = dbTransaction.EmployeeID,
                PetID = dbTransaction.PetID,
                PetPrice = dbTransaction.PetPrice,
                PetFoodID = dbTransaction.PetFoodID,
                PetFoodQty = dbTransaction.PetFoodQty,
                TotalPrice = dbTransaction.TotalPrice,
            };
            return View(dbTransaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _transactionRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.ID == id);
        }
    }
}
