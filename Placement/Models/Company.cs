﻿using System.ComponentModel.DataAnnotations;

namespace Placement.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Domain { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Package { get; set; }
        public string file { get; set; }    


    }

}
