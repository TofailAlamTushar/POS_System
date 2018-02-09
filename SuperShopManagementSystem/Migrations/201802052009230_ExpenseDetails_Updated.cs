namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpenseDetails_Updated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExpenseDetails", "ItemId", "dbo.Items");
            DropIndex("dbo.ExpenseDetails", new[] { "ItemId" });
            AddColumn("dbo.ExpenseDetails", "ExpenseItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.ExpenseDetails", "ExpenseItemId");
            AddForeignKey("dbo.ExpenseDetails", "ExpenseItemId", "dbo.ExpenseItems", "Id", cascadeDelete: true);
            DropColumn("dbo.ExpenseDetails", "ItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExpenseDetails", "ItemId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ExpenseDetails", "ExpenseItemId", "dbo.ExpenseItems");
            DropIndex("dbo.ExpenseDetails", new[] { "ExpenseItemId" });
            DropColumn("dbo.ExpenseDetails", "ExpenseItemId");
            CreateIndex("dbo.ExpenseDetails", "ItemId");
            AddForeignKey("dbo.ExpenseDetails", "ItemId", "dbo.Items", "Id", cascadeDelete: true);
        }
    }
}
