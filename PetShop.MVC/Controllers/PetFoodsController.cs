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
    public class PetFoodsController : Controller
    {
        private readonly PetShopContext _context;
        private readonly IEntityRepo<PetFood> _petFoodRepo;

        public PetFoodsController(IEntityRepo<PetFood> petFoodRepo)
        {
            _petFoodRepo = petFoodRepo;
        }

        // GET: PetFoods
        public async Task<IActionResult> Index()
        {
            return View(await _petFoodRepo.GetAllAsync());
        }

        // GET: PetFoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petFood = await _petFoodRepo.GetByIdAsync(id.Value);
            if (petFood == null)
            {
                return NotFound();
            }

            return View(petFood);
        }

        // GET: PetFoods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PetFoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimalType,Price,Cost")] PetFoodCreateViewModel petFoodViewModel)
        {
            if (ModelState.IsValid)
            {
                var newPetFood = new PetFood 
                { 
                    AnimalType = petFoodViewModel.AnimalType,
                    Price = petFoodViewModel.Price,
                    Cost = petFoodViewModel.Cost                    
                };

                await _petFoodRepo.AddAsync(newPetFood);

                
                return RedirectToAction(nameof(Index));
            }
            return View(petFoodViewModel);
        }

        // GET: PetFoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var petFood = await _petFoodRepo.GetByIdAsync(id.Value);
            if (petFood == null)
            {
                return NotFound();
            }
            var petFoodViewModel = new PetFoodUpdateModel();
            petFoodViewModel.AnimalType = petFood.AnimalType;
            petFoodViewModel.Price = petFood.Price;
            petFoodViewModel.Cost = petFood.Cost;

            return View(petFoodViewModel);
        }

        // POST: PetFoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnimalType,Price,Cost,ID")] PetFoodUpdateModel petFood)
        {
            if (id != petFood.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {                
                var currentPetFood = await _petFoodRepo.GetByIdAsync(id);
                if (currentPetFood is null)
                    return BadRequest($"Could not find PetFood with id '{id}'");                    
                currentPetFood.AnimalType = petFood.AnimalType;
                currentPetFood.Price = petFood.Price;
                currentPetFood.Cost = petFood.Cost;
                await _petFoodRepo.UpdateAsync(id, currentPetFood);                                                   
                return RedirectToAction(nameof(Index));
            }
            return View(petFood);
        }

        // GET: PetFoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var petFood = await _petFoodRepo.GetByIdAsync(id.Value);
                
            if (petFood == null)
            {
                return NotFound();
            }
            var viewModel = new PetFoodDeleteModel();

            viewModel.AnimalType = petFood.AnimalType;
            viewModel.Price = petFood.Price;
            viewModel.Cost = petFood.Cost;

            return View(viewModel);
        }

        // POST: PetFoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _petFoodRepo.DeleteAsync(id);

            
            return RedirectToAction(nameof(Index));
        }

        
    }
}
