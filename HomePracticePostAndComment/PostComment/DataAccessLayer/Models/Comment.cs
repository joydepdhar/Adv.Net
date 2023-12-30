using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string CommentText { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("User")]
        public string CommentedBy {  get; set; }
        [ForeignKey("Post")]
        public int PostID { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
        

    }
}
