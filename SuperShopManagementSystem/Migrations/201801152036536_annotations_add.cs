namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class annotations_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpenseItems", "Image", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExpenseItems", "Image");
        }
    }
}
