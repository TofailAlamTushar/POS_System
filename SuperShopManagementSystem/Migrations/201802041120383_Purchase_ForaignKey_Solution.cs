namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchase_ForaignKey_Solution : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Purchases", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Purchases", "OutletId", "dbo.Outlets");
            DropIndex("dbo.Purchases", new[] { "Employee_Id" });
            RenameColumn(table: "dbo.Purchases", name: "Employee_Id", newName: "EmployeeId");
            AlterColumn("dbo.Purchases", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Purchases", "EmployeeId");
            AddForeignKey("dbo.Purchases", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Purchases", "OutletId", "dbo.Outlets", "Id");
            DropColumn("dbo.Purchases", "EmployeedId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchases", "EmployeedId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Purchases", "OutletId", "dbo.Outlets");
            DropForeignKey("dbo.Purchases", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Purchases", new[] { "EmployeeId" });
            AlterColumn("dbo.Purchases", "EmployeeId", c => c.Int());
            RenameColumn(table: "dbo.Purchases", name: "EmployeeId", newName: "Employee_Id");
            CreateIndex("dbo.Purchases", "Employee_Id");
            AddForeignKey("dbo.Purchases", "OutletId", "dbo.Outlets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Purchases", "Employee_Id", "dbo.Employees", "Id");
        }
    }
}
