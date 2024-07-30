namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTableCompany : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Companies", newName: "Customers");
            DropForeignKey("dbo.CompanyAssignments", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.CompanyAssignments", "UserID", "dbo.Users");
            DropIndex("dbo.CompanyAssignments", new[] { "UserID" });
            DropIndex("dbo.CompanyAssignments", new[] { "CompanyID" });
            CreateTable(
                "dbo.CustomerAssignments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.CustomerGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Customers", "CustomerGroupID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "CustomerGroupID");
            AddForeignKey("dbo.Customers", "CustomerGroupID", "dbo.CustomerGroups", "ID", cascadeDelete: true);
            DropTable("dbo.CompanyAssignments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CompanyAssignments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.CustomerAssignments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Customers", "CustomerGroupID", "dbo.CustomerGroups");
            DropForeignKey("dbo.CustomerAssignments", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Customers", new[] { "CustomerGroupID" });
            DropIndex("dbo.CustomerAssignments", new[] { "CustomerID" });
            DropIndex("dbo.CustomerAssignments", new[] { "UserID" });
            DropColumn("dbo.Customers", "CustomerGroupID");
            DropTable("dbo.CustomerGroups");
            DropTable("dbo.CustomerAssignments");
            CreateIndex("dbo.CompanyAssignments", "CompanyID");
            CreateIndex("dbo.CompanyAssignments", "UserID");
            AddForeignKey("dbo.CompanyAssignments", "UserID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CompanyAssignments", "CompanyID", "dbo.Companies", "ID", cascadeDelete: true);
            RenameTable(name: "dbo.Customers", newName: "Companies");
        }
    }
}
