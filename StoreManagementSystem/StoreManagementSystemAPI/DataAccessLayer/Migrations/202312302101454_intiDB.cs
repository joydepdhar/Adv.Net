namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intiDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCustomers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        productID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Granttotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.productID, cascadeDelete: true)
                .Index(t => t.productID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 100),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        ReckNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 20),
                        NID = c.String(nullable: false, maxLength: 10),
                        Address = c.String(nullable: false, maxLength: 100),
                        Role = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCustomers", "productID", "dbo.Products");
            DropForeignKey("dbo.ProductCustomers", "CustomerID", "dbo.Customers");
            DropIndex("dbo.ProductCustomers", new[] { "CustomerID" });
            DropIndex("dbo.ProductCustomers", new[] { "productID" });
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.ProductCustomers");
            DropTable("dbo.Customers");
        }
    }
}
