namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameAddedInOutlet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Outlets", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Outlets", "Name");
        }
    }
}
