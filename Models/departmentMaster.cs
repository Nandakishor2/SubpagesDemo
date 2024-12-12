using System.ComponentModel.DataAnnotations;

namespace SubpagesMVCArchitecture.Models
{
    public class departmentMaster
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Department Name Cannot Be empty")]
        [StringLength(50,ErrorMessage ="String Length Must not exclude 50 Charecters")]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string? name { get; set; }

    }
}
