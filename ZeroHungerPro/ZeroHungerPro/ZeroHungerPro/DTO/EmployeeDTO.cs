using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZeroHungerPro.Models;

namespace ZeroHungerPro.DTO
{
    public class EmployeeDTO
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email can not be blank....")]
        public string Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "At least 8 character.....")]
        public string Password { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "Must be exactly 11 characters")]
        public string Phone { get; set; }
        [Required]
        [Age(18, ErrorMessage = "You must be 18 years old......")]
        public System.DateTime DOB { get; set; }
        [Required(ErrorMessage = "Address can not be blank....")]
        public string Address { get; set; }
    }
}