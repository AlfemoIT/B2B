namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeADZHLColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cawnts", "ADZHL", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cawnts", "ADZHL", c => c.String());
        }
    }
}
