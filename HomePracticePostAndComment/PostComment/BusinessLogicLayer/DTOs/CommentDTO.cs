using DataAccessLayer.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        [Required]
        public string CommentText { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CommentedBy { get; set; }
        public int PostID { get; set; }
        
    }
}
