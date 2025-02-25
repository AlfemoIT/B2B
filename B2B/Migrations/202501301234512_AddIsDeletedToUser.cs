namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDeletedToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "IsDeleted", c => c.Boolean(nullable: false));
        }
        public override void Down()
        {
            DropColumn("dbo.Users", "IsDeleted");
            DropColumn("dbo.Users", "Email");
        }
    }
}
