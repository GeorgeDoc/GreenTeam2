using PetShop.Model;
using System.ComponentModel.DataAnnotations;

namespace PetShop.MVC.Models {
    public class EmployeeCreateViewModel {
        
        [Required]
        [StringLength(99, MinimumLength = 2, ErrorMessage = "Must be at least 2 characters long.")]
        public string Name { get; set; }
        [Required]
        [StringLength(99, MinimumLength = 2, ErrorMessage = "Must be at least 2 characters long.")]
        public string Surname { get; set; }
        [Required]
        public EmployeeType EmployeeType { get; set; }
        [Required]
        [Range(0.00, 10000.00, ErrorMessage = "Must be between 0.0 and 10000.00")] // int?
        public decimal SallaryPerMonth { get; set; }


        public class EmployeeEditViewModel {
            public int ID { get; set; }
            [Required]
            [StringLength(99, MinimumLength = 2, ErrorMessage = "Must be at least 2 characters long.")]
            public string Name { get; set; }
            [Required]
            [StringLength(99, MinimumLength = 2, ErrorMessage = "Must be at least 2 characters long.")]
            public string Surname { get; set; }
            [Required]
            public EmployeeType EmployeeType { get; set; }
            [Required]
            [Range(0.00, 10000.00, ErrorMessage = "Must be between 0.0 and 10000.00")] // int?
            public decimal SallaryPerMonth { get; set; }
        }

        public class EmployeeDeleteViewModel {
            public int ID { get; set; }
            public string Name { get; set; } 
            public string Surname { get; set; }            
            public EmployeeType EmployeeType { get; set; }
            public decimal SallaryPerMonth { get; set; }
        }

        public class EmployeeDetailsViewModel {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public EmployeeType EmployeeType { get; set; }
            public decimal SallaryPerMonth { get; set; }
        }
    }
}
