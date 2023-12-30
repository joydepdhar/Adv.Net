using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    internal class PostContext:DbContext
    {
        public DbSet<User> Users { get; set;}

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set;} 
    }
}
