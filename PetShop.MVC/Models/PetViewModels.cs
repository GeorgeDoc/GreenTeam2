using PetShop.Model;
using System.ComponentModel.DataAnnotations;

namespace PetShop.MVC.Models
{
    public class PetCreateViewModel
    {
        [Required]
        [StringLength(99, MinimumLength = 2, ErrorMessage = "Must be at least 2 characters long.")]
        public string Breed { get; set; }
        [Required]
        public AnimalType AnimalType { get; set; }
        [Required]
        public PetStatus PetStatus { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Cost { get; set; }
    }

    public class PetDetailsViewModel
    {
        public int ID { get; set; }
        public string Breed { get; set; }
        public AnimalType AnimalType { get; set; }
        public PetStatus PetStatus { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }

    }

    public class PetEditViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [StringLength(99, MinimumLength = 2, ErrorMessage = "Must be at least 2 characters long.")]
        public string Breed { get; set; }
        [Required]
        public AnimalType AnimalType { get; set; }
        [Required]
        public PetStatus PetStatus { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Cost { get; set; }
    }

    public class PetDeleteViewModel
    {
        public int ID { get; set; }
        public string Breed { get; set; }
        public AnimalType AnimalType { get; set; }
        public PetStatus PetStatus { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }
}
