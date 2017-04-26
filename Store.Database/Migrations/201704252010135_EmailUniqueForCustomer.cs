namespace Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailUniqueForCustomer : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Customers", "Email", unique: true, name: "EmailIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", "EmailIndex");
        }
    }
}
