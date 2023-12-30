using DataAccessLayer.Interfaces;
using DataAccessLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    internal class CommentRepo : Repo, IRepo<Comment, int, bool>
    {
        public bool Create(Comment obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> Read()
        {
            throw new NotImplementedException();
        }

        public Comment Read(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Comment obj)
        {
            throw new NotImplementedException();
        }
    }
}
