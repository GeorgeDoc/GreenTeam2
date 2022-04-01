using PetShop.EF.Repositories;
using PetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.EF.MockRepositories
{
    public class MockPetRepo : IEntityRepo<Pet>
    {
        private List<Pet> _pets = new List<Pet>
        {
            new Pet(){ID = 1, Breed="German Shepherd",AnimalType=AnimalType.Mammal,PetStatus=PetStatus.OK,Price=300,Cost=100},
            new Pet(){ID = 2, Breed="Canery",AnimalType=AnimalType.Bird,PetStatus=PetStatus.Recovering,Price=50,Cost=10},
            //------------------------------------------------------------------------------TO BUY PET IS OK :P----------------------
            new Pet(){ID = 3, Breed="Royal Cobra",AnimalType=AnimalType.Reptile,PetStatus=PetStatus.Unhealthy,Price=3000,Cost=500},
            //-----------------------------------------------------REALLY UNHEALTHY FORGETS OFTEN BUT EXPENSIVE (MOVIE STAR)------
            new Pet(){ID = 4, Breed="Dory",AnimalType=AnimalType.Fish,PetStatus=PetStatus.Unhealthy,Price=5000,Cost=500},
        };

        public Task AddAsync(Pet entity) {
            throw new NotImplementedException();
        }

        public Task Create(Pet entity)
        {

            _pets.Add(entity);
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {

            var foundPet = _pets.SingleOrDefault(pet => pet.ID == id);
            if (foundPet is null)
                return Task.CompletedTask;

            _pets.Remove(foundPet);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        public List<Pet> GetAll()
        {
            return _pets;
        }

        public Task<IEnumerable<Pet>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public Pet? GetById(int id)
        {
            return _pets.SingleOrDefault(pet => pet.ID == id);
        }

        public Task<Pet?> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public Task Update(int id, Pet entity)
        {
            var foundPet = _pets.SingleOrDefault(pet => pet.ID == id);
            if (foundPet is null)
                return Task.CompletedTask;

            foundPet.Breed = entity.Breed;
            foundPet.AnimalType = entity.AnimalType;
            foundPet.PetStatus = entity.PetStatus;
            foundPet.Price = entity.Price;
            foundPet.Cost = entity.Cost;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(int id, Pet entity) {
            throw new NotImplementedException();
        }
    }
}
