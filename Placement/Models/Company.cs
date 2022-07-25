using System.ComponentModel.DataAnnotations;

namespace Placement.Models
{
    public class Company
    {
        [Key]
        [Display(Name = "Company ID")]
        public int CompanyId { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required]
        public string Domain { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Package { get; set; } 
        public string File { get; set; }    



    }
}
