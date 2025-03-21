namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaterialPriceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaterialPrices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MATNR = c.String(),
                        RowType = c.String(),
                        ListType = c.String(),
                        Price1 = c.String(),
                        Price2 = c.String(),
                        Price3 = c.String(),
                        Price4 = c.String(),
                        Price5 = c.String(),
                        Currency = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Materials", "MaterialPriceID", c => c.Int());
            CreateIndex("dbo.Materials", "MaterialPriceID");
            AddForeignKey("dbo.Materials", "MaterialPriceID", "dbo.MaterialPrices", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Materials", "MaterialPriceID", "dbo.MaterialPrices");
            DropIndex("dbo.Materials", new[] { "MaterialPriceID" });
            DropColumn("dbo.Materials", "MaterialPriceID");
            DropTable("dbo.MaterialPrices");
        }
    }
}
