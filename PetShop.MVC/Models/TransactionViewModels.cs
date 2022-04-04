using Microsoft.AspNetCore.Mvc.Rendering;
using PetShop.Model;
using System.ComponentModel.DataAnnotations;

namespace PetShop.MVC.Models
{
    public class TransactionCreateViewModel
    {
 
        [Required]
        public DateTime Date { get; set; }
        [Required]
        //public Customer customer { get; set; }
        public int CustomerID { get; set; }
        [Required]
        //public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
        [Required]
        //public Pet Pet { get; set; }
        public int? PetID { get; set; }
        [Required]
        public decimal? PetPrice { get; set; }
        [Required]
        //public PetFood PetFood { get; set; }
        public int PetFoodID { get; set; }
        [Required]
        public int PetFoodQty { get; set; }
        [Required]
        public decimal PetFoodPrice { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
    }

    public class TransactionDetailsViewModel
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int? PetID { get; set; }
        public decimal? PetPrice { get; set; }
        public int PetFoodID { get; set; }
        public int PetFoodQty { get; set; }
        public decimal PetFoodPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class TransactionEditViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        //public Customer customer { get; set; }
        public int CustomerID { get; set; }
        [Required]
        //public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
        [Required]
        //public Pet Pet { get; set; }
        public int? PetID { get; set; }
        [Required]
        public decimal? PetPrice { get; set; }
        [Required]
        //public PetFood PetFood { get; set; }
        public int PetFoodID { get; set; }
        [Required]
        public int PetFoodQty { get; set; }
        [Required]
        public decimal PetFoodPrice { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
    }

    public class TransactionDeleteViewModel
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int? PetID { get; set; }
        public decimal? PetPrice { get; set; }
        public int PetFoodID { get; set; }
        public int PetFoodQty { get; set; }
        public decimal PetFoodPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }



    public class TransactionSellViewModel {
        public Pet Pet { get; set; }
        //public List<PetFood> PetFoods { get; set; }
       
        public decimal TotalPrice { get; set; }
        public int PetFoodQty { get; set; }
        public decimal PetFoodPrice { get; set; }


        public decimal PetPrice { get; set; }
        public int PetID { get; set; }
        public int PetFoodID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }

        public SelectList EmployeesList { get; set; }
        public SelectList CustomersList { get; set; }
        public SelectList PetFoodList { get; set; }

    }
}
