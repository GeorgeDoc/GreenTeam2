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
    public class PetsController : Controller
    {
        private readonly PetShopContext _context;
        private readonly IEntityRepo<Pet> _petRepo;

        public PetsController(IEntityRepo<Pet> petRepo)
        {
            _petRepo = petRepo;
        }
        //public PetsController(PetShopContext context)
        //{
        //    _context = context;
        //}

        // GET: Pets
        public async Task<IActionResult> Index()
        {
            return View(await _petRepo.GetAllAsync());
        }

        // GET: Pets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _petRepo.GetByIdAsync(id.Value);
            if (pet == null)
            {
                return NotFound();
            }

            var viewPet = new PetDetailsViewModel()
            {
                ID = pet.ID,
                Breed = pet.Breed,
                AnimalType = pet.AnimalType,
                PetStatus = pet.PetStatus,
                Price = pet.Price,
                Cost = pet.Cost,
            };

            return View(viewPet);
        }

        // GET: Pets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Breed,PetStatus,AnimalType,Price,Cost")] PetCreateViewModel pet)
        {
            if (ModelState.IsValid)
            {
                var dbPet = new Pet()
                {
                    Breed = pet.Breed,
                    AnimalType = pet.AnimalType,
                    PetStatus = pet.PetStatus,
                    Price = pet.Price,
                    Cost = pet.Cost,
                };
                await _petRepo.AddAsync(dbPet);
                return RedirectToAction(nameof(Index));
            }
            return View(pet);
        }

        // GET: Pets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _petRepo.GetByIdAsync(id.Value);
            if (pet == null)
            {
                return NotFound();
            }
            var viewPet = new PetEditViewModel()
            {
                Breed = pet.Breed,
                AnimalType = pet.AnimalType,
                PetStatus = pet.PetStatus,
                Price = pet.Price,
                Cost = pet.Cost,
            };
            return View(viewPet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Breed,PetStatus,AnimalType,Price,Cost,ID")] PetEditViewModel pet)
        {
            if (id != pet.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                var dbPet= await _petRepo.GetByIdAsync(pet.ID);
                if (dbPet is null)
                    return BadRequest($"Can not find pet with id '{id}'");
                dbPet.Breed = pet.Breed;
                dbPet.AnimalType = pet.AnimalType;
                dbPet.PetStatus = pet.PetStatus;
                dbPet.Price = pet.Price;
                dbPet.Cost = pet.Cost;
                await _petRepo.UpdateAsync(id, dbPet);                
                return RedirectToAction(nameof(Index));
            }
            return View(pet);
        }

        // GET: Pets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbPet = await _petRepo.GetByIdAsync(id.Value);
            if (dbPet == null)
            {
                return NotFound();
            }
            var viewPet = new PetDeleteViewModel()
            {
                ID = dbPet.ID,
                Breed = dbPet.Breed,
                AnimalType = dbPet.AnimalType,
                PetStatus = dbPet.PetStatus,
                Price = dbPet.Price,
                Cost = dbPet.Cost,
            };
            return View(viewPet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _petRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PetExists(int id)
        {
            return _context.Pets.Any(e => e.ID == id);
        }
    }
}
