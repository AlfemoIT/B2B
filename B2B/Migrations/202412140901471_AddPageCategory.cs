namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPageCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Pages", "CategoryID", c => c.Int(nullable: false));
            AddColumn("dbo.Pages", "PageCategory_ID", c => c.Int());
            CreateIndex("dbo.Pages", "PageCategory_ID");
            AddForeignKey("dbo.Pages", "PageCategory_ID", "dbo.PageCategories", "ID");
            DropColumn("dbo.Pages", "Icon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pages", "Icon", c => c.String());
            DropForeignKey("dbo.Pages", "PageCategory_ID", "dbo.PageCategories");
            DropIndex("dbo.Pages", new[] { "PageCategory_ID" });
            DropColumn("dbo.Pages", "PageCategory_ID");
            DropColumn("dbo.Pages", "CategoryID");
            DropTable("dbo.PageCategories");
        }
    }
}
