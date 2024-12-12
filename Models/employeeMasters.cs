using System.ComponentModel.DataAnnotations;

namespace SubpagesMVCArchitecture.Models
{
    public class employeeMasters
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name Is required")]
        [StringLength(50,ErrorMessage = "Name Must Not Exceed 50 Charecters")]
        [RegularExpression(@"^[A-Za-z\s]+$",ErrorMessage ="Please Enter valid Name only charecters from a-z are allowed")]
        public string? Name { get; set; }

        [Required]

        [StringLength(50, ErrorMessage = "Name Must Not Exceed 50 Charecters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Please Enter valid Name only charecters from a-z are allowed")]
        public string? Designatiom { get; set; }

        [Required]

        [StringLength(50, ErrorMessage = "Name Must Not Exceed 50 Charecters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Please Enter valid Name only charecters from a-z are allowed")]
        public string? Department { get; set; }

        [Required]

        [StringLength(10, ErrorMessage = "Name Must Not Exceed 50 Charecters")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please Enter valid Mobile Number ! No alphabets or SpecialCharecter allowed")]
        public string? PhoneNumber { get; set; }
        

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",ErrorMessage ="Please Enter valid Email Address")]
        //[EmailAddress(ErrorMessage ="Please enter valid Email Address")]
        public string? Email { get; set; }

    }
}
