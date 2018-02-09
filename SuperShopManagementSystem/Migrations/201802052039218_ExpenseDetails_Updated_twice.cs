namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpenseDetails_Updated_twice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ExpenseDetails", "Description", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ExpenseDetails", "Description", c => c.String());
        }
    }
}
