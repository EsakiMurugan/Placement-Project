using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Placement.Models
{
    public class Student
    {
        [Key]
        [Display(Name = "Student ID")]
        public int StudentId { get; set; }
        [Required]
        [Display(Name = "Student Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Numbers and special characters are not allowed")]
        public string StudentName { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [Required]
        [Display(Name = "Native Place")]
        public string Native_place { get; set; }
        [Required]
        [Display(Name = "Reg.No")]
        public string Reg_no { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public long Mobile_No { get; set; }
        [Required]
        [Display(Name = "Email-ID")]
        [DataType(DataType.EmailAddress)]
        public string StudentEmail { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        [Display(Name = "SSLC Percentage")]
        public float SSLC { get; set; }
        [Display(Name = "HSC Percentage")]
        public float XII { get; set; }
        [Display(Name = "Diploma Percentage")]
        public float Diploma { get; set; }
        [Required]
        [Display(Name = "History Of Arrears")]
        public int HOA { get; set; }
        [Required]
        [Display(Name = "Standing Arrears")]
        public int SA { get; set; }
        [Required]
        public float CGPA { get; set; }
        [Required]
        [Display(Name = "Area Of Interest")]
        public string AOI { get; set; }
        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", 
            ErrorMessage = "At least one uppercase, one lowercase, one digit, one special character and minimum eight in length")]
        [Display(Name = "Password")]
        public string PassWord { get; set; }
        [Compare("PassWord",ErrorMessage = "Password Not Matching")]
        [NotMapped]
        [Display(Name = "Confirm Password")]
        public string CPassWord { get; set; }
    }
}
