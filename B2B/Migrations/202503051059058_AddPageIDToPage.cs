namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPageIDToPage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PageAssignments", "Page_ID", "dbo.Pages");
            DropIndex("dbo.PageAssignments", new[] { "Page_ID" });
            RenameColumn(table: "dbo.PageAssignments", name: "Page_ID", newName: "PageID");
            AlterColumn("dbo.PageAssignments", "PageID", c => c.Int(nullable: false));
            CreateIndex("dbo.PageAssignments", "PageID");
            AddForeignKey("dbo.PageAssignments", "PageID", "dbo.Pages", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PageAssignments", "PageID", "dbo.Pages");
            DropIndex("dbo.PageAssignments", new[] { "PageID" });
            AlterColumn("dbo.PageAssignments", "PageID", c => c.Int());
            RenameColumn(table: "dbo.PageAssignments", name: "PageID", newName: "Page_ID");
            CreateIndex("dbo.PageAssignments", "Page_ID");
            AddForeignKey("dbo.PageAssignments", "Page_ID", "dbo.Pages", "ID");
        }
    }
}
