using PetShop.EF.Repositories;
using PetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.EF.MockRepositories
{
    public class MockPetFoodRepo : IEntityRepo<PetFood>
    {
        private List<PetFood> _petFoods = new List<PetFood>
        {
            new PetFood(){ID=1,AnimalType=AnimalType.Mammal,Price=15,Cost=10},
            new PetFood(){ID=2,AnimalType=AnimalType.Reptile,Price=20,Cost=10},
            new PetFood(){ID=3,AnimalType =AnimalType.Bird,Price=5,Cost=1},
            new PetFood(){ID=4,AnimalType =AnimalType.Fish,Price=5,Cost=1}
        };
        public Task Create(PetFood entity)
        {

            _petFoods.Add(entity);
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {

            var foundFood = _petFoods.SingleOrDefault(food => food.ID == id);
            if (foundFood is null)
                return Task.CompletedTask;

            _petFoods.Remove(foundFood);
            return Task.CompletedTask;
        }

        public List<PetFood> GetAll()
        {
            return _petFoods;
        }

        public PetFood? GetById(int id)
        {
            return _petFoods.SingleOrDefault(pet => pet.ID == id);
        }

        public Task Update(int id, PetFood entity)
        {
            var foundFood = _petFoods.SingleOrDefault(pet => pet.ID == id);
            if (foundFood is null)
                return Task.CompletedTask;

            foundFood.AnimalType = entity.AnimalType;
            foundFood.Price = entity.Price;
            foundFood.Cost = entity.Cost;
            return Task.CompletedTask;
        }
    }
}
