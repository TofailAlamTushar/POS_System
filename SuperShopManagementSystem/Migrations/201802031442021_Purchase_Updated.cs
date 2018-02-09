namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchase_Updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "PartyId", c => c.Int(nullable: false));
            AddColumn("dbo.Purchases", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "DueAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Purchases", "PartyId");
            AddForeignKey("dbo.Purchases", "PartyId", "dbo.Parties", "Id", cascadeDelete: true);
            DropColumn("dbo.Purchases", "Supplier");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchases", "Supplier", c => c.String(nullable: false));
            DropForeignKey("dbo.Purchases", "PartyId", "dbo.Parties");
            DropIndex("dbo.Purchases", new[] { "PartyId" });
            DropColumn("dbo.Purchases", "DueAmount");
            DropColumn("dbo.Purchases", "Total");
            DropColumn("dbo.Purchases", "PartyId");
        }
    }
}
