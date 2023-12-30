namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intiDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentText = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CommentedBy = c.String(maxLength: 128),
                        PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CommentedBy)
                .Index(t => t.CommentedBy)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        PostedBy = c.String(maxLength: 128),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.PostedBy)
                .Index(t => t.PostedBy);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Uname = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 10),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Uname);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "CommentedBy", "dbo.Users");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Posts", "PostedBy", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "PostedBy" });
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropIndex("dbo.Comments", new[] { "CommentedBy" });
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
