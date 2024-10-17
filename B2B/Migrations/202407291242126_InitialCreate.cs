namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SapCode = c.String(),
                        Name = c.String(),
                        TaxNo = c.String(),
                        Phone1 = c.String(),
                        Phone2 = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CompanyAssignments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        SubRoleID = c.Int(nullable: false),
                        NameSurname = c.String(),
                        Password = c.String(),
                        Phone1 = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SubRoles", t => t.SubRoleID, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID)
                .Index(t => t.SubRoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SubRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SubRoleRoles",
                c => new
                    {
                        SubRole_ID = c.Int(nullable: false),
                        Role_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubRole_ID, t.Role_ID })
                .ForeignKey("dbo.SubRoles", t => t.SubRole_ID, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_ID, cascadeDelete: true)
                .Index(t => t.SubRole_ID)
                .Index(t => t.Role_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Users", "SubRoleID", "dbo.SubRoles");
            DropForeignKey("dbo.SubRoleRoles", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.SubRoleRoles", "SubRole_ID", "dbo.SubRoles");
            DropForeignKey("dbo.CompanyAssignments", "UserID", "dbo.Users");
            DropForeignKey("dbo.CompanyAssignments", "CompanyID", "dbo.Companies");
            DropIndex("dbo.SubRoleRoles", new[] { "Role_ID" });
            DropIndex("dbo.SubRoleRoles", new[] { "SubRole_ID" });
            DropIndex("dbo.Users", new[] { "SubRoleID" });
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.CompanyAssignments", new[] { "CompanyID" });
            DropIndex("dbo.CompanyAssignments", new[] { "UserID" });
            DropTable("dbo.SubRoleRoles");
            DropTable("dbo.SubRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.CompanyAssignments");
            DropTable("dbo.Companies");
        }
    }
}
