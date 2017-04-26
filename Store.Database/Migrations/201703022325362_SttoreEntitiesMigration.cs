namespace Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SttoreEntitiesMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 255),
                        LastName = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Address = c.String(maxLength: 255),
                        Phone = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.ProductReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 255),
                        Message = c.String(),
                        Likes = c.Int(nullable: false),
                        Dislikes = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            AddColumn("dbo.Products", "Order_Id", c => c.Int());
            CreateIndex("dbo.Products", "Order_Id");
            AddForeignKey("dbo.Products", "Order_Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductReviews", "Author_Id", "dbo.Customers");
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.ProductReviews", new[] { "Author_Id" });
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropColumn("dbo.Products", "Order_Id");
            DropTable("dbo.ProductReviews");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
