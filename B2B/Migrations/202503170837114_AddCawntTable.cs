namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCawntTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cawnts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ATINN = c.String(),
                        ATZHL = c.Int(nullable: false),
                        SPRAS = c.String(),
                        ADZHL = c.String(),
                        ATWTB = c.String(),
                        DATUV = c.String(),
                        TECHV = c.String(),
                        AENNR = c.String(),
                        LKENZ = c.String(),
                        DATUB = c.String(),
                    })
                .PrimaryKey(t => t.ID);
        }
        
        public override void Down()
        {
            DropTable("dbo.Cawnts");
        }
    }
}
