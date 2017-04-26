namespace Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.ProductCarts",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Cart_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Cart_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.Cart_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Cart_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCarts", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.ProductCarts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Carts", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.ProductCarts", new[] { "Cart_Id" });
            DropIndex("dbo.ProductCarts", new[] { "Product_Id" });
            DropIndex("dbo.Carts", new[] { "Customer_Id" });
            DropTable("dbo.ProductCarts");
            DropTable("dbo.Carts");
        }
    }
}
