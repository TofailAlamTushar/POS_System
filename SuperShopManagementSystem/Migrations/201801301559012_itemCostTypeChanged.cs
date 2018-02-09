namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemCostTypeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "CostPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Items", "SalePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "SalePrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Items", "CostPrice", c => c.Int(nullable: false));
        }
    }
}
