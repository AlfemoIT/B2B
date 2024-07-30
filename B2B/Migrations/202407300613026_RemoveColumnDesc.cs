namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveColumnDesc : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Roles", "Description");
            DropColumn("dbo.UserGroups", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserGroups", "Description", c => c.String());
            AddColumn("dbo.Roles", "Description", c => c.String());
        }
    }
}
