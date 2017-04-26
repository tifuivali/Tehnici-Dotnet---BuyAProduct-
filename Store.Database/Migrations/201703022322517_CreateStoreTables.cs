namespace Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStoreTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Category_Id", c => c.Int());
            AlterColumn("dbo.Products", "Name", c => c.String(maxLength: 255));
            CreateIndex("dbo.Products", "Category_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.ProductCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_Id", "dbo.ProductCategories");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            AlterColumn("dbo.Products", "Name", c => c.String());
            DropColumn("dbo.Products", "Category_Id");
            DropTable("dbo.ProductCategories");
        }
    }
}
