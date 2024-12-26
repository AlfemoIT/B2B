namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIconToPage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "Icon", c => c.String());
            AddColumn("dbo.Pages", "Index", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "Index");
            DropColumn("dbo.Pages", "Icon");
        }
    }
}
