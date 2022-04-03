using PetShop.Model;

namespace PetShop.MVC.Models
{
    public class PetFoodListViewModel
    {
        public AnimalType AnimalType { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }
    public class PetFoodCreateViewModel
    {
        public AnimalType AnimalType { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }

    public class PetFoodUpdateModel
    {
        public int ID { get; set; }
        public AnimalType AnimalType { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }

    public class PetFoodDeleteModel
    {
        public int ID { get; set; }
        public AnimalType AnimalType { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }
}
