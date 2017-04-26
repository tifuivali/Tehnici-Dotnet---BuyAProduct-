namespace Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageUrlFieldToProductDto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageUrl", c => c.String(maxLength: 2046));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ImageUrl");
        }
    }
}
