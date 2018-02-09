namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sale_SalsDetail_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        OutletId = c.Int(nullable: false),
                        EmployeedId = c.Int(nullable: false),
                        SaleDate = c.DateTime(nullable: false),
                        CusContractNo = c.String(nullable: false),
                        CusName = c.String(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Vat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DueAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Outlets", t => t.OutletId, cascadeDelete: true)
                .Index(t => t.OutletId)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.SalesDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quntity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockQuantity = c.Int(nullable: false),
                        SaleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.SaleId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.SaleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesDetails", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.SalesDetails", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Sales", "OutletId", "dbo.Outlets");
            DropForeignKey("dbo.Sales", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.SalesDetails", new[] { "SaleId" });
            DropIndex("dbo.SalesDetails", new[] { "ItemId" });
            DropIndex("dbo.Sales", new[] { "Employee_Id" });
            DropIndex("dbo.Sales", new[] { "OutletId" });
            DropTable("dbo.SalesDetails");
            DropTable("dbo.Sales");
        }
    }
}
