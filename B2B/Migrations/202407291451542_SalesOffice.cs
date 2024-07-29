namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesOffice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesOffices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Companies", "SalesOfficeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Companies", "SalesOfficeID");
            AddForeignKey("dbo.Companies", "SalesOfficeID", "dbo.SalesOffices", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "SalesOfficeID", "dbo.SalesOffices");
            DropIndex("dbo.Companies", new[] { "SalesOfficeID" });
            DropColumn("dbo.Companies", "SalesOfficeID");
            DropTable("dbo.SalesOffices");
        }
    }
}
