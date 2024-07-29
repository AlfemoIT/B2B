namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserGroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Users", "UserGroupID", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "UserGroupID");
            AddForeignKey("dbo.Users", "UserGroupID", "dbo.UserGroups", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserGroupID", "dbo.UserGroups");
            DropIndex("dbo.Users", new[] { "UserGroupID" });
            DropColumn("dbo.Users", "UserGroupID");
            DropTable("dbo.UserGroups");
        }
    }
}
