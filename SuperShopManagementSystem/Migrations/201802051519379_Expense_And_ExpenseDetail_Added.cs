namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Expense_And_ExpenseDetail_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        OutletId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        ExpenseDate = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Due = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Outlets", t => t.OutletId, cascadeDelete: true)
                .Index(t => t.OutletId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.ExpenseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Expense_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Expenses", t => t.Expense_Id)
                .Index(t => t.ItemId)
                .Index(t => t.Expense_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseDetails", "Expense_Id", "dbo.Expenses");
            DropForeignKey("dbo.Expenses", "OutletId", "dbo.Outlets");
            DropForeignKey("dbo.ExpenseDetails", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Expenses", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.ExpenseDetails", new[] { "Expense_Id" });
            DropIndex("dbo.ExpenseDetails", new[] { "ItemId" });
            DropIndex("dbo.Expenses", new[] { "EmployeeId" });
            DropIndex("dbo.Expenses", new[] { "OutletId" });
            DropTable("dbo.ExpenseDetails");
            DropTable("dbo.Expenses");
        }
    }
}
