namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKirlentColumnToMaterial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materials", "KIRLENT45_3", c => c.String());
            AddColumn("dbo.Materials", "KIRLENT50_1", c => c.String());
            AddColumn("dbo.Materials", "KIRLENT50_2", c => c.String());
            AddColumn("dbo.Materials", "KIRLENT50_3", c => c.String());
            AddColumn("dbo.Materials", "KIRLENT52_1", c => c.String());
            AddColumn("dbo.Materials", "KIRLENT52_2", c => c.String());
            AddColumn("dbo.Materials", "KIRLENT52_3", c => c.String());
            AddColumn("dbo.Materials", "ROUNDKIRLENT_1", c => c.String());
            AddColumn("dbo.Materials", "ROUNDKIRLENT_2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Materials", "ROUNDKIRLENT_2");
            DropColumn("dbo.Materials", "ROUNDKIRLENT_1");
            DropColumn("dbo.Materials", "KIRLENT52_3");
            DropColumn("dbo.Materials", "KIRLENT52_2");
            DropColumn("dbo.Materials", "KIRLENT52_1");
            DropColumn("dbo.Materials", "KIRLENT50_3");
            DropColumn("dbo.Materials", "KIRLENT50_2");
            DropColumn("dbo.Materials", "KIRLENT50_1");
            DropColumn("dbo.Materials", "KIRLENT45_3");
        }
    }
}
