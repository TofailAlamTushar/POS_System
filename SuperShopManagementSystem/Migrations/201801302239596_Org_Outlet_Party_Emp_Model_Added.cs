namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Org_Outlet_Party_Emp_Model_Added : DbMigration
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
                "dbo.Outlets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationId = c.Int(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Outlets", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Employees", "OutletId", "dbo.Outlets");
            DropForeignKey("dbo.Employees", "ReferenceId", "dbo.Employees");
            DropIndex("dbo.Outlets", new[] { "OrganizationId" });
            DropIndex("dbo.Employees", new[] { "ReferenceId" });
            DropIndex("dbo.Employees", new[] { "OutletId" });
            DropTable("dbo.Parties");
            DropTable("dbo.Organizations");
            DropTable("dbo.Outlets");
            DropTable("dbo.Employees");
        }
    }
}
