namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.Repos.PostContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccessLayer.Repos.PostContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            for (int i = 1; i <= 10; i++)
            {
                context.Users.AddOrUpdate(new Repos.User
                {
                    Name = Guid.NewGuid().ToString().Substring(0, 10),
                    Uname = "User-" + i,
                    Password= Guid.NewGuid().ToString().Substring(0, 10),
                    Type="General"
                }) ;
            }
            Random random = new Random();
            for(int i = 1;i <= 20; i++)
            {
                context.Posts.AddOrUpdate(new Repos.Post { 
                Id=i,
                Title=Guid.NewGuid().ToString().Substring(0,5),
                Description=Guid.NewGuid().ToString(),
                Date=DateTime.Now,
                PostedBy= "User-"+ random.Next(1,9),

                });
            }
            for(int i =1; i <= 30;i++)
            {
                context.Comments.AddOrUpdate(new Repos.Comment
                {
                    Id = i,
                    CommentText = Guid.NewGuid().ToString().Substring(0, 5),
                    CreatedDate = DateTime.Now,
                    CommentedBy = "User-" + random.Next(1, 9),
                    PostID= random.Next(1, 21),
                });
            }
        }
    }
}

