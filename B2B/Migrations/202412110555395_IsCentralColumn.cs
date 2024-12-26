namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsCentralColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsCentral", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsCentral");
        }
    }
}
