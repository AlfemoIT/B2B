namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageAssignments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Page_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pages", t => t.Page_ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.Page_ID);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PageAssignments", "UserID", "dbo.Users");
            DropForeignKey("dbo.PageAssignments", "Page_ID", "dbo.Pages");
            DropIndex("dbo.PageAssignments", new[] { "Page_ID" });
            DropIndex("dbo.PageAssignments", new[] { "UserID" });
            DropTable("dbo.Pages");
            DropTable("dbo.PageAssignments");
        }
    }
}
