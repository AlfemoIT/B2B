namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFKCatInPage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pages", "PageCategory_ID", "dbo.PageCategories");
            DropIndex("dbo.Pages", new[] { "PageCategory_ID" });
            RenameColumn(table: "dbo.Pages", name: "PageCategory_ID", newName: "PageCategoryID");
            AlterColumn("dbo.Pages", "PageCategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Pages", "PageCategoryID");
            AddForeignKey("dbo.Pages", "PageCategoryID", "dbo.PageCategories", "ID", cascadeDelete: true);
            DropColumn("dbo.Pages", "CategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pages", "CategoryID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Pages", "PageCategoryID", "dbo.PageCategories");
            DropIndex("dbo.Pages", new[] { "PageCategoryID" });
            AlterColumn("dbo.Pages", "PageCategoryID", c => c.Int());
            RenameColumn(table: "dbo.Pages", name: "PageCategoryID", newName: "PageCategory_ID");
            CreateIndex("dbo.Pages", "PageCategory_ID");
            AddForeignKey("dbo.Pages", "PageCategory_ID", "dbo.PageCategories", "ID");
        }
    }
}
