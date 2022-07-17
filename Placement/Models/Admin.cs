using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Placement.Models
{
    public class Admin
    {
        [Key]
        public int FacultyId { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Numbers and special characters are not allowed")]
        public string FacultyName { get; set; }   
        public string Department { get; set; }
        public string Grade { get; set; }
        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "At least one uppercase, one lowercase, one digit, one special character and minimum eight in length")]
        public string PassWord { get; set; }
        [Compare("PassWord", ErrorMessage = "PassWord Not Match")]
        [NotMapped]
        [Display(Name = "Confirm PassWord")]
        public string CPassWord { get; set; }
    }


}

