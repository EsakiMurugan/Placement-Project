using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Placement.Models
{
    public class Application
    {
        [Key]
        public int ApplicationID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ApplicationDate { get; set; }
        [Required]
        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student StudentsId { get; set; }
        [Required]
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company CompanysId { get; set; }
    }
}
