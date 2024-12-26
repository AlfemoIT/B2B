namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStorageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StorageAssignments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        StorageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.StorageID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.StorageID);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsCentral = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StorageAssignments", "StorageID", "dbo.Storages");
            DropForeignKey("dbo.StorageAssignments", "CustomerID", "dbo.Customers");
            DropIndex("dbo.StorageAssignments", new[] { "StorageID" });
            DropIndex("dbo.StorageAssignments", new[] { "CustomerID" });
            DropTable("dbo.Storages");
            DropTable("dbo.StorageAssignments");
        }
    }
}
