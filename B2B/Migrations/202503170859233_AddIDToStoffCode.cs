namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIDToStoffCode : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoffCodes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MANDT = c.String(),
                        KUMAS_KOD = c.String(),
                        HAMMADDE_KOD = c.String(),
                        KUMAS_TANIM = c.String(),
                        KUMAS_TANIM_EN = c.String(),
                        KUMAS_STATU_IC = c.String(),
                        KUMAS_STATU_IH = c.String(),
                        DATUV = c.String(),
                        DATUB = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StoffCodes");
        }
    }
}
