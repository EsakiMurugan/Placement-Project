using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Placement.Models
{
    public class Admin
    {
        [Key]
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }   
        public string Department { get; set; }
        public string Grade { get; set; }
        [Required]
        public string PassWord { get; set; }
        [Compare("PassWord", ErrorMessage = "PassWord Not Match")]
        [NotMapped]
        [Display(Name = "Confirm PassWord")]
        public string CPassWord { get; set; }
    }


}

