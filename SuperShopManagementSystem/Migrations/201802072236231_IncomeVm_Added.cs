namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncomeVm_Added : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.IncomeVms");
        }
    }
}
