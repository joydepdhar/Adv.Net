using DataAccessLayer.Interfaces;
using DataAccessLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    public class PostRepo : Repo, IRepo<Post, int, Post>
    {
        public Post Create(Post obj)
        {
            db.Posts.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Posts.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Post> Read()
        {
            return db.Posts.ToList();
        }

        public Post Read(int id)
        {
            return db.Posts.Find(id);
        }

        public Post Update(Post obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
