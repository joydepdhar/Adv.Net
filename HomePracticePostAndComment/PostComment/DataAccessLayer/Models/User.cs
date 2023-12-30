using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    public class User
    {
        [Key]
        public string Uname { get; set; }
        [Required]
        [StringLength(10)]
        public string Password { get; set; }
        [Required]
        [StringLength (10)]
        public string Name  { get; set; }
        [Required]
        public string Type { get; set; }           
    }
}
