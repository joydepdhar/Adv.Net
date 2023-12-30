using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class UserDTO
    {
        public string Uname { get; set; }
        [Required]
        [StringLength(10)]
        public string Password { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
