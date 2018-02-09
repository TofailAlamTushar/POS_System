namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchase_PurchaseDetail_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        OutletId = c.Int(nullable: false),
                        EmployeedId = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        Supplier = c.String(nullable: false),
                        Remarks = c.String(),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Outlets", t => t.OutletId, cascadeDelete: true)
                .Index(t => t.OutletId)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quntity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.PurchaseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseDetails", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Purchases", "OutletId", "dbo.Outlets");
            DropForeignKey("dbo.Purchases", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseId" });
            DropIndex("dbo.PurchaseDetails", new[] { "ItemId" });
            DropIndex("dbo.Purchases", new[] { "Employee_Id" });
            DropIndex("dbo.Purchases", new[] { "OutletId" });
            DropTable("dbo.PurchaseDetails");
            DropTable("dbo.Purchases");
        }
    }
}
