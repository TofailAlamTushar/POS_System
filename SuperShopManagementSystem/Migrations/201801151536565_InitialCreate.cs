namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseCatagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Description = c.String(),
                        Image = c.Binary(),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCatagories", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.ExpenseItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Description = c.String(),
                        Image = c.Binary(),
                        ExpenseCatagoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCatagories", t => t.ExpenseCatagoryId, cascadeDelete: true)
                .Index(t => t.ExpenseCatagoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseItems", "ExpenseCatagoryId", "dbo.ExpenseCatagories");
            DropForeignKey("dbo.ExpenseCatagories", "ParentId", "dbo.ExpenseCatagories");
            DropIndex("dbo.ExpenseItems", new[] { "ExpenseCatagoryId" });
            DropIndex("dbo.ExpenseCatagories", new[] { "ParentId" });
            DropTable("dbo.ExpenseItems");
            DropTable("dbo.ExpenseCatagories");
        }
    }
}
