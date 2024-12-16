namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexToCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PageCategories", "Index", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PageCategories", "Index");
        }
    }
}
