using PetShop.EF.Context;
using PetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.EF.Repositories
{
    public class PetFoodRepo : IEntityRepo<PetFood>
    {
        public async Task Create(PetFood entity)
        {
            using var context = new PetShopContext();
            context.PetFoods.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            using var context = new PetShopContext();
            var foundFood = context.PetFoods.SingleOrDefault(food => food.ID == id);
            if (foundFood is null)
                return;

            context.PetFoods.Remove(foundFood);
            await context.SaveChangesAsync();
        }

        public List<PetFood> GetAll()
        {
            using var context = new PetShopContext();
            return context.PetFoods.ToList();
        }

        public PetFood? GetById(int id)
        {
            using var context = new PetShopContext();
            return context.PetFoods.Where(food => food.ID == id).SingleOrDefault();
        }

        public async Task Update(int id, PetFood entity)
        {
            using var context = new PetShopContext();
            var foundFood = context.PetFoods.SingleOrDefault(food => food.ID == id);
            if (foundFood is null)
                return;

            foundFood.AnimalType = entity.AnimalType;
            foundFood.Price=entity.Price;
            foundFood.Cost=entity.Cost;
            await context.SaveChangesAsync();
        }
    }
}
