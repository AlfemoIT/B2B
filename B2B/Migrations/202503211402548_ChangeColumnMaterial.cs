namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnMaterial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materials", "ZclMaktx", c => c.String());
            AddColumn("dbo.Materials", "BirinciBolge", c => c.String());
            AddColumn("dbo.Materials", "İkinciBolge", c => c.String());
            AddColumn("dbo.Materials", "UcuncuBolge", c => c.String());
            AddColumn("dbo.Materials", "AyakRengi", c => c.String());
            DropColumn("dbo.Materials", "ZCL_MAKTX");
            DropColumn("dbo.Materials", "BIRINCI_BOLGE");
            DropColumn("dbo.Materials", "IKINCI_BOLGE");
            DropColumn("dbo.Materials", "UCUNCU_BOLGE");
            DropColumn("dbo.Materials", "AYAK_RENGI");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Materials", "AYAK_RENGI", c => c.String());
            AddColumn("dbo.Materials", "UCUNCU_BOLGE", c => c.String());
            AddColumn("dbo.Materials", "IKINCI_BOLGE", c => c.String());
            AddColumn("dbo.Materials", "BIRINCI_BOLGE", c => c.String());
            AddColumn("dbo.Materials", "ZCL_MAKTX", c => c.String());
            DropColumn("dbo.Materials", "AyakRengi");
            DropColumn("dbo.Materials", "UcuncuBolge");
            DropColumn("dbo.Materials", "İkinciBolge");
            DropColumn("dbo.Materials", "BirinciBolge");
            DropColumn("dbo.Materials", "ZclMaktx");
        }
    }
}
