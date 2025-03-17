namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCawntTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cawnts", "SPRAS");
            DropColumn("dbo.Cawnts", "ADZHL");
            DropColumn("dbo.Cawnts", "DATUV");
            DropColumn("dbo.Cawnts", "TECHV");
            DropColumn("dbo.Cawnts", "AENNR");
            DropColumn("dbo.Cawnts", "LKENZ");
            DropColumn("dbo.Cawnts", "DATUB");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cawnts", "DATUB", c => c.String());
            AddColumn("dbo.Cawnts", "LKENZ", c => c.String());
            AddColumn("dbo.Cawnts", "AENNR", c => c.String());
            AddColumn("dbo.Cawnts", "TECHV", c => c.String());
            AddColumn("dbo.Cawnts", "DATUV", c => c.String());
            AddColumn("dbo.Cawnts", "ADZHL", c => c.Int(nullable: false));
            AddColumn("dbo.Cawnts", "SPRAS", c => c.String());
        }
    }
}
