namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCategoryToPage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pages", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pages", "Category", c => c.String());
        }
    }
}
