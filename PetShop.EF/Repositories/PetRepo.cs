using PetShop.EF.Context;
using PetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.EF.Repositories
{
    public class PetRepo : IEntityRepo<Pet>
    {
        public Task AddAsync(Pet entity) {
            throw new NotImplementedException();
        }

        public async Task Create(Pet entity)
        {
            using var context = new PetShopContext();
            context.Pets.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            using var context = new PetShopContext();
            var foundPet = context.Pets.SingleOrDefault(pet => pet.ID == id);
            if (foundPet is null)
                return;

            context.Pets.Remove(foundPet);
            await context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        public List<Pet> GetAll()
        {
            using var context = new PetShopContext();
            return context.Pets.ToList();
        }

        public Task<IEnumerable<Pet>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public Pet? GetById(int id)
        {
            using var context = new PetShopContext();
            return context.Pets.Where(pet => pet.ID == id).SingleOrDefault();
        }

        public Task<Pet?> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public async Task Update(int id,Pet entity)
        {
            using var context = new PetShopContext();
            var foundPet = context.Pets.SingleOrDefault(pet => pet.ID == id);
            if (foundPet is null)
                return;

            foundPet.Breed = entity.Breed;
            foundPet.AnimalType= entity.AnimalType;
            foundPet.PetStatus = entity.PetStatus;
            foundPet.Price = entity.Price;
            foundPet.Cost = entity.Cost;
            await context.SaveChangesAsync();
        }

        public Task UpdateAsync(int id, Pet entity) {
            throw new NotImplementedException();
        }
    }
}
