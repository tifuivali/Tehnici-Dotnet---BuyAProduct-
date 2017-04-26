namespace Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameProductMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductDtoes", newName: "Products");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Products", newName: "ProductDtoes");
        }
    }
}
