using System.ComponentModel.DataAnnotations;

namespace PetShop.MVC.Models {
    public class CustomerCreateViewModel {
        [Required]
        [StringLength(99, MinimumLength = 2, ErrorMessage = "Must be at least 2 characters long.")]
        public string Name { get; set; }
        [Required]
        [StringLength(99, MinimumLength = 2, ErrorMessage = "Must be at least 2 characters long.")]
        public string Surname { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{10,10})$", ErrorMessage = "Phone number must be exactly 10 numbers")]
        public string Phone { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{9,9})$", ErrorMessage = "TIN number must be exaclty 9 numbers")]
        public string TIN { get; set; }
    }


    public class CustomerDetailsViewModel {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string TIN { get; set; }
    }

    public class CustomerEditViewModel {
        public int ID { get; set; }
        [Required]
        [StringLength(99, MinimumLength = 2, ErrorMessage = "Must be at least 2 characters long.")]
        public string Name { get; set; }
        [Required]
        [StringLength(99, MinimumLength = 2, ErrorMessage = "Must be at least 2 characters long.")]
        public string Surname { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{10,10})$", ErrorMessage = "Phone number must be exactly 10 numbers")]
        public string Phone { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{9,9})$", ErrorMessage = "TIN number must be exaclty 9 numbers")]
        public string TIN { get; set; }
    }

    public class CustomerDeleteViewModel {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string TIN { get; set; }
    }




}
