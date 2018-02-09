namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpenseDetails_Updated_3rd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExpenseDetails", "Expense_Id", "dbo.Expenses");
            DropIndex("dbo.ExpenseDetails", new[] { "Expense_Id" });
            RenameColumn(table: "dbo.ExpenseDetails", name: "Expense_Id", newName: "ExpenseId");
            AlterColumn("dbo.ExpenseDetails", "ExpenseId", c => c.Int(nullable: false));
            CreateIndex("dbo.ExpenseDetails", "ExpenseId");
            AddForeignKey("dbo.ExpenseDetails", "ExpenseId", "dbo.Expenses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseDetails", "ExpenseId", "dbo.Expenses");
            DropIndex("dbo.ExpenseDetails", new[] { "ExpenseId" });
            AlterColumn("dbo.ExpenseDetails", "ExpenseId", c => c.Int());
            RenameColumn(table: "dbo.ExpenseDetails", name: "ExpenseId", newName: "Expense_Id");
            CreateIndex("dbo.ExpenseDetails", "Expense_Id");
            AddForeignKey("dbo.ExpenseDetails", "Expense_Id", "dbo.Expenses", "Id");
        }
    }
}
