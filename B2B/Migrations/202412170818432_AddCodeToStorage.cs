namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCodeToStorage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Storages", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Storages", "Code");
        }
    }
}
