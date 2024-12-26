namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSalesOfficeIDToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "SalesOfficeID", c => c.Int());
            CreateIndex("dbo.Users", "SalesOfficeID");
            AddForeignKey("dbo.Users", "SalesOfficeID", "dbo.SalesOffices", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "SalesOfficeID", "dbo.SalesOffices");
            DropIndex("dbo.Users", new[] { "SalesOfficeID" });
            DropColumn("dbo.Users", "SalesOfficeID");
        }
    }
}
