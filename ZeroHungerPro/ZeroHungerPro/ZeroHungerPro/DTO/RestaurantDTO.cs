using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHungerPro.DTO
{
    public class RestaurantDTO
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Must be greater than 5 and less than 50")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email can not be blank....")]
        public string Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "At least 8 character.....")]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "Must be exactly 11 characters")]
        [RegularExpression(@"^\+01\d{9}$", ErrorMessage = "Phone number should start with +88")]
        public string Phone { get; set; }

    }
}