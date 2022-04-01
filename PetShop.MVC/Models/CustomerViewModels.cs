using System.ComponentModel.DataAnnotations;

namespace PetShop.MVC.Models {
    public class CustomerCreateViewModel {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{10,10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Phone { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{9,9})$", ErrorMessage = "Invalid TIN Number.")]
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
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{10,10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Phone { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{9,9})$", ErrorMessage = "Invalid TIN Number.")]
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
