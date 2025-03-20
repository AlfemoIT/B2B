namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMandtToMaterialPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaterialPriceGroups", "VTEXT", c => c.String());
            DropColumn("dbo.MaterialPriceGroups", "MANDT");
            DropColumn("dbo.MaterialPriceGroups", "SPRAS");
            DropColumn("dbo.MaterialPriceGroups", "BEZEI20");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MaterialPriceGroups", "BEZEI20", c => c.String());
            AddColumn("dbo.MaterialPriceGroups", "SPRAS", c => c.String());
            AddColumn("dbo.MaterialPriceGroups", "MANDT", c => c.String());
            DropColumn("dbo.MaterialPriceGroups", "VTEXT");
        }
    }
}
