namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSubRole : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubRoleRoles", "SubRole_ID", "dbo.SubRoles");
            DropForeignKey("dbo.SubRoleRoles", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.Users", "SubRoleID", "dbo.SubRoles");
            DropIndex("dbo.Users", new[] { "SubRoleID" });
            DropIndex("dbo.SubRoleRoles", new[] { "SubRole_ID" });
            DropIndex("dbo.SubRoleRoles", new[] { "Role_ID" });
            DropColumn("dbo.Users", "SubRoleID");
            DropTable("dbo.SubRoles");
            DropTable("dbo.SubRoleRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubRoleRoles",
                c => new
                    {
                        SubRole_ID = c.Int(nullable: false),
                        Role_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubRole_ID, t.Role_ID });
            
            CreateTable(
                "dbo.SubRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Users", "SubRoleID", c => c.Int(nullable: false));
            CreateIndex("dbo.SubRoleRoles", "Role_ID");
            CreateIndex("dbo.SubRoleRoles", "SubRole_ID");
            CreateIndex("dbo.Users", "SubRoleID");
            AddForeignKey("dbo.Users", "SubRoleID", "dbo.SubRoles", "ID", cascadeDelete: true);
            AddForeignKey("dbo.SubRoleRoles", "Role_ID", "dbo.Roles", "ID", cascadeDelete: true);
            AddForeignKey("dbo.SubRoleRoles", "SubRole_ID", "dbo.SubRoles", "ID", cascadeDelete: true);
        }
    }
}
