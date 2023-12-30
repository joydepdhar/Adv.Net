using DataAccessLayer.Interfaces;
using DataAccessLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccessFactory
    {
        public static IRepo <Post, int , Post> PostData()
        {
            return new PostRepo(); 
        }
        public static IRepo<Comment, int, bool>CommentData()
        {
            return new CommentRepo();
        }
        public static IRepo <User,string, User> UserData()
        {
            return new UserRepo();
        }

    }
}
