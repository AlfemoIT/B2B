namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsManagementToPage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "IsManagement", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "IsManagement");
        }
    }
}
