namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sale_Updated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sales", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Sales", "OutletId", "dbo.Outlets");
            DropIndex("dbo.Sales", new[] { "Employee_Id" });
            RenameColumn(table: "dbo.Sales", name: "Employee_Id", newName: "EmployeeId");
            AlterColumn("dbo.Sales", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sales", "EmployeeId");
            AddForeignKey("dbo.Sales", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sales", "OutletId", "dbo.Outlets", "Id");
            DropColumn("dbo.Sales", "EmployeedId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "EmployeedId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Sales", "OutletId", "dbo.Outlets");
            DropForeignKey("dbo.Sales", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Sales", new[] { "EmployeeId" });
            AlterColumn("dbo.Sales", "EmployeeId", c => c.Int());
            RenameColumn(table: "dbo.Sales", name: "EmployeeId", newName: "Employee_Id");
            CreateIndex("dbo.Sales", "Employee_Id");
            AddForeignKey("dbo.Sales", "OutletId", "dbo.Outlets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sales", "Employee_Id", "dbo.Employees", "Id");
        }
    }
}
