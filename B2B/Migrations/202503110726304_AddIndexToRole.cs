namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexToRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Index", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "Index");
        }
    }
}
