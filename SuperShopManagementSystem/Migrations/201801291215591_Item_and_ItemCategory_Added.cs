namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Item_and_ItemCategory_Added : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CostPrice = c.Int(nullable: false),
                        SalePrice = c.Int(nullable: false),
                        Code = c.String(nullable: false),
                        Description = c.String(maxLength: 1000),
                        ItemCategoryId = c.Int(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCategories", t => t.ItemCategoryId, cascadeDelete: true)
                .Index(t => t.ItemCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "ItemCategoryId", "dbo.ItemCategories");
            DropForeignKey("dbo.ItemCategories", "ParentId", "dbo.ItemCategories");
            DropIndex("dbo.Items", new[] { "ItemCategoryId" });
            DropIndex("dbo.ItemCategories", new[] { "ParentId" });
            DropTable("dbo.Items");
            DropTable("dbo.ItemCategories");
        }
    }
}
