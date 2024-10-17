namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnRegistration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RegistrationNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "RegistrationNo");
        }
    }
}
