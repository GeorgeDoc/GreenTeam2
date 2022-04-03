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


        public TransactionsController(IEntityRepo<Transaction> transactionRepo, IEntityRepo<Pet> petRepo, IEntityRepo<PetFood> petFoodRepo)
        {
            _transactionRepo = transactionRepo;
            _petRepo=petRepo;
            _petFoodRepo = petFoodRepo;
        }


        public async Task<IActionResult> Sell(int? id) {

            if (id == null) {
                return NotFound();
            }

            var pet = await _petRepo.GetByIdAsync(id.Value);
            if (pet == null) {
                return NotFound();
            }


            var petFoods = await _petFoodRepo.GetAllAsync();
            var selectedPetFoods = new List<PetFood>();
            

            foreach (var item in petFoods) {
                if(item.AnimalType == pet.AnimalType)
                    selectedPetFoods.Add(item);
            }

            var vm = new TransactionSellViewModel();
            vm.PetFoodList = new SelectList(selectedPetFoods,"ID","Price");

            return View(vm);
        }
            // GET: Transactions
            public async Task<IActionResult> Index()
        {
            //var petShopContext = _context.Transactions.Include(t => t.Customer).Include(t => t.Employee).Include(t => t.Pet).Include(t => t.PetFood);
            return View(await _transactionRepo.GetAllAsync());
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
            foreach (var item in petList) {
                if (item.PetStatus != PetStatus.Unhealthy)
                    canBeSoldList.Add(item);
            }
            return View(canBeSoldList);
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,CustomerID,EmployeeID,PetID,PetPrice,PetFoodID,PetFoodQty,PetFoodPrice,TotalPrice")] TransactionCreateViewModel transaction)
        {
            if (ModelState.IsValid)
            {
                var dbTransaction = new Transaction()
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
                await _transactionRepo.AddAsync(dbTransaction);
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
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
