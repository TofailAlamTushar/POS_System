namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(),
                        OutletId = c.Int(nullable: false),
                        JoiningDate = c.DateTime(nullable: false),
                        Image = c.Binary(),
                        ContactNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ReferenceId = c.Int(),
                        EmerContactNo = c.String(nullable: false),
                        NationalId = c.String(),
                        FathersName = c.String(),
                        MothersName = c.String(),
                        PresentAddress = c.String(),
                        PermanentAddress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.ReferenceId)
                .ForeignKey("dbo.Outlets", t => t.OutletId, cascadeDelete: true)
                .Index(t => t.OutletId)
                .Index(t => t.ReferenceId);
            
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
                        ExpenseId = c.Int(nullable: false),
                        ExpenseItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(maxLength: 1000),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Expenses", t => t.ExpenseId, cascadeDelete: true)
                .ForeignKey("dbo.ExpenseItems", t => t.ExpenseItemId, cascadeDelete: true)
                .Index(t => t.ExpenseId)
                .Index(t => t.ExpenseItemId);
            
            CreateTable(
                "dbo.ExpenseItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Description = c.String(maxLength: 1000),
                        Image = c.Binary(),
                        ExpenseCatagoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCatagories", t => t.ExpenseCatagoryId, cascadeDelete: true)
                .Index(t => t.ExpenseCatagoryId);
            
            CreateTable(
                "dbo.ExpenseCatagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Description = c.String(maxLength: 1000),
                        Image = c.Binary(),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCatagories", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Outlets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        ContactNo = c.String(),
                        Address = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        ContactNo = c.String(),
                        Image = c.Binary(),
                        Address = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        OutletId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        PartyId = c.Int(nullable: false),
                        Remarks = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DueAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Outlets", t => t.OutletId)
                .ForeignKey("dbo.Parties", t => t.PartyId, cascadeDelete: true)
                .Index(t => t.OutletId)
                .Index(t => t.EmployeeId)
                .Index(t => t.PartyId);
            
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(),
                        ContactNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Image = c.Binary(),
                        Address = c.String(maxLength: 1000),
                        PartyType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Code = c.String(nullable: false),
                        Description = c.String(maxLength: 1000),
                        ItemCategoryId = c.Int(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCategories", t => t.ItemCategoryId, cascadeDelete: true)
                .Index(t => t.ItemCategoryId);
            
            CreateTable(
                "dbo.ItemCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Description = c.String(maxLength: 1000),
                        Image = c.Binary(),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCategories", t => t.ParentId)
                .Index(t => t.ParentId);
            
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
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        OutletId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        SaleDate = c.DateTime(nullable: false),
                        CusContractNo = c.String(nullable: false),
                        CusName = c.String(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Vat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DueAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Outlets", t => t.OutletId)
                .Index(t => t.OutletId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.IncomeVms",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        SalesTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchasesTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.SalesDetails", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.Sales", "OutletId", "dbo.Outlets");
            DropForeignKey("dbo.Sales", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.SalesDetails", "ItemId", "dbo.Items");
            DropForeignKey("dbo.PurchaseDetails", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "ItemCategoryId", "dbo.ItemCategories");
            DropForeignKey("dbo.ItemCategories", "ParentId", "dbo.ItemCategories");
            DropForeignKey("dbo.Purchases", "PartyId", "dbo.Parties");
            DropForeignKey("dbo.Purchases", "OutletId", "dbo.Outlets");
            DropForeignKey("dbo.Purchases", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Outlets", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Expenses", "OutletId", "dbo.Outlets");
            DropForeignKey("dbo.Employees", "OutletId", "dbo.Outlets");
            DropForeignKey("dbo.ExpenseDetails", "ExpenseItemId", "dbo.ExpenseItems");
            DropForeignKey("dbo.ExpenseItems", "ExpenseCatagoryId", "dbo.ExpenseCatagories");
            DropForeignKey("dbo.ExpenseCatagories", "ParentId", "dbo.ExpenseCatagories");
            DropForeignKey("dbo.ExpenseDetails", "ExpenseId", "dbo.Expenses");
            DropForeignKey("dbo.Expenses", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "ReferenceId", "dbo.Employees");
            DropIndex("dbo.Sales", new[] { "EmployeeId" });
            DropIndex("dbo.Sales", new[] { "OutletId" });
            DropIndex("dbo.SalesDetails", new[] { "SaleId" });
            DropIndex("dbo.SalesDetails", new[] { "ItemId" });
            DropIndex("dbo.ItemCategories", new[] { "ParentId" });
            DropIndex("dbo.Items", new[] { "ItemCategoryId" });
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseId" });
            DropIndex("dbo.PurchaseDetails", new[] { "ItemId" });
            DropIndex("dbo.Purchases", new[] { "PartyId" });
            DropIndex("dbo.Purchases", new[] { "EmployeeId" });
            DropIndex("dbo.Purchases", new[] { "OutletId" });
            DropIndex("dbo.Outlets", new[] { "OrganizationId" });
            DropIndex("dbo.ExpenseCatagories", new[] { "ParentId" });
            DropIndex("dbo.ExpenseItems", new[] { "ExpenseCatagoryId" });
            DropIndex("dbo.ExpenseDetails", new[] { "ExpenseItemId" });
            DropIndex("dbo.ExpenseDetails", new[] { "ExpenseId" });
            DropIndex("dbo.Expenses", new[] { "EmployeeId" });
            DropIndex("dbo.Expenses", new[] { "OutletId" });
            DropIndex("dbo.Employees", new[] { "ReferenceId" });
            DropIndex("dbo.Employees", new[] { "OutletId" });
            DropTable("dbo.IncomeVms");
            DropTable("dbo.Sales");
            DropTable("dbo.SalesDetails");
            DropTable("dbo.ItemCategories");
            DropTable("dbo.Items");
            DropTable("dbo.PurchaseDetails");
            DropTable("dbo.Parties");
            DropTable("dbo.Purchases");
            DropTable("dbo.Organizations");
            DropTable("dbo.Outlets");
            DropTable("dbo.ExpenseCatagories");
            DropTable("dbo.ExpenseItems");
            DropTable("dbo.ExpenseDetails");
            DropTable("dbo.Expenses");
            DropTable("dbo.Employees");
        }
    }
}
