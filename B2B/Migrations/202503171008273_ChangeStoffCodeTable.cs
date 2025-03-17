namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStoffCodeTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.StoffCodes", "MANDT");
            DropColumn("dbo.StoffCodes", "KUMAS_TANIM_EN");
            DropColumn("dbo.StoffCodes", "KUMAS_STATU_IC");
            DropColumn("dbo.StoffCodes", "KUMAS_STATU_IH");
            DropColumn("dbo.StoffCodes", "DATUV");
            DropColumn("dbo.StoffCodes", "DATUB");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StoffCodes", "DATUB", c => c.String());
            AddColumn("dbo.StoffCodes", "DATUV", c => c.String());
            AddColumn("dbo.StoffCodes", "KUMAS_STATU_IH", c => c.String());
            AddColumn("dbo.StoffCodes", "KUMAS_STATU_IC", c => c.String());
            AddColumn("dbo.StoffCodes", "KUMAS_TANIM_EN", c => c.String());
            AddColumn("dbo.StoffCodes", "MANDT", c => c.String());
        }
    }
}
