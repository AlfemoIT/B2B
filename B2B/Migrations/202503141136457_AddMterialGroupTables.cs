namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMterialGroupTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaterialPriceGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MANDT = c.String(),
                        SPRAS = c.String(),
                        KONDM = c.String(),
                        BEZEI20 = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MATNR = c.String(),
                        MATKL = c.String(),
                        MAKTX = c.String(),
                        ZCL_MAKTX = c.String(),
                        BRGEW = c.String(),
                        NETGW = c.String(),
                        GEWEI = c.String(),
                        VOLUM = c.String(),
                        VOLEH = c.String(),
                        LAENG = c.String(),
                        BREIT = c.String(),
                        HOEHE = c.String(),
                        MEABM = c.String(),
                        Tvm1tID = c.Int(nullable: false),
                        Tvm2tID = c.Int(nullable: false),
                        Tvm3tID = c.Int(nullable: false),
                        Tvm4tID = c.Int(nullable: false),
                        Tvm5tID = c.Int(nullable: false),
                        MaterialPriceGroupID = c.Int(nullable: false),
                        LVORM = c.String(),
                        VMSTA = c.String(),
                        VSTAT = c.String(),
                        BIRINCI_BOLGE = c.String(),
                        IKINCI_BOLGE = c.String(),
                        UCUNCU_BOLGE = c.String(),
                        AYAK_RENGI = c.String(),
                        BELKIRLENTI_1 = c.String(),
                        BELKIRLENTI_2 = c.String(),
                        KIRLENT45_1 = c.String(),
                        KIRLENT45_2 = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MaterialPriceGroups", t => t.MaterialPriceGroupID, cascadeDelete: true)
                .ForeignKey("dbo.Tvm1t", t => t.Tvm1tID, cascadeDelete: true)
                .ForeignKey("dbo.Tvm2t", t => t.Tvm2tID, cascadeDelete: true)
                .ForeignKey("dbo.Tvm3t", t => t.Tvm3tID, cascadeDelete: true)
                .ForeignKey("dbo.Tvm4t", t => t.Tvm4tID, cascadeDelete: true)
                .ForeignKey("dbo.Tvm5t", t => t.Tvm5tID, cascadeDelete: true)
                .Index(t => t.Tvm1tID)
                .Index(t => t.Tvm2tID)
                .Index(t => t.Tvm3tID)
                .Index(t => t.Tvm4tID)
                .Index(t => t.Tvm5tID)
                .Index(t => t.MaterialPriceGroupID);
            
            CreateTable(
                "dbo.Tvm1t",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MANDT = c.String(),
                        SPRAS = c.String(),
                        MVGR1 = c.String(),
                        BEZEI = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tvm2t",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MANDT = c.String(),
                        SPRAS = c.String(),
                        MVGR2 = c.String(),
                        BEZEI = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tvm3t",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MANDT = c.String(),
                        SPRAS = c.String(),
                        MVGR3 = c.String(),
                        BEZEI = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tvm4t",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MANDT = c.String(),
                        SPRAS = c.String(),
                        MVGR4 = c.String(),
                        BEZEI = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tvm5t",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MANDT = c.String(),
                        SPRAS = c.String(),
                        MVGR5 = c.String(),
                        BEZEI = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Materials", "Tvm5tID", "dbo.Tvm5t");
            DropForeignKey("dbo.Materials", "Tvm4tID", "dbo.Tvm4t");
            DropForeignKey("dbo.Materials", "Tvm3tID", "dbo.Tvm3t");
            DropForeignKey("dbo.Materials", "Tvm2tID", "dbo.Tvm2t");
            DropForeignKey("dbo.Materials", "Tvm1tID", "dbo.Tvm1t");
            DropForeignKey("dbo.Materials", "MaterialPriceGroupID", "dbo.MaterialPriceGroups");
            DropIndex("dbo.Materials", new[] { "MaterialPriceGroupID" });
            DropIndex("dbo.Materials", new[] { "Tvm5tID" });
            DropIndex("dbo.Materials", new[] { "Tvm4tID" });
            DropIndex("dbo.Materials", new[] { "Tvm3tID" });
            DropIndex("dbo.Materials", new[] { "Tvm2tID" });
            DropIndex("dbo.Materials", new[] { "Tvm1tID" });
            DropTable("dbo.Tvm5t");
            DropTable("dbo.Tvm4t");
            DropTable("dbo.Tvm3t");
            DropTable("dbo.Tvm2t");
            DropTable("dbo.Tvm1t");
            DropTable("dbo.Materials");
            DropTable("dbo.MaterialPriceGroups");
        }
    }
}
