namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class image_not_required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ExpenseCatagories", "Image", c => c.Binary());
            AlterColumn("dbo.ExpenseItems", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ExpenseItems", "Image", c => c.Binary(nullable: false));
            AlterColumn("dbo.ExpenseCatagories", "Image", c => c.Binary(nullable: false));
        }
    }
}
