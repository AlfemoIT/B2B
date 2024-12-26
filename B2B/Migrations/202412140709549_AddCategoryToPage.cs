namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryToPage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "Category");
        }
    }
}
