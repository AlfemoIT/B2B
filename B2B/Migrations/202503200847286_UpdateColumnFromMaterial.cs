namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumnFromMaterial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Materials", "MaterialPriceGroupID", "dbo.MaterialPriceGroups");
            DropForeignKey("dbo.Materials", "Tvm1tID", "dbo.Tvm1t");
            DropForeignKey("dbo.Materials", "Tvm2tID", "dbo.Tvm2t");
            DropForeignKey("dbo.Materials", "Tvm3tID", "dbo.Tvm3t");
            DropForeignKey("dbo.Materials", "Tvm4tID", "dbo.Tvm4t");
            DropForeignKey("dbo.Materials", "Tvm5tID", "dbo.Tvm5t");
            DropIndex("dbo.Materials", new[] { "Tvm1tID" });
            DropIndex("dbo.Materials", new[] { "Tvm2tID" });
            DropIndex("dbo.Materials", new[] { "Tvm3tID" });
            DropIndex("dbo.Materials", new[] { "Tvm4tID" });
            DropIndex("dbo.Materials", new[] { "Tvm5tID" });
            DropIndex("dbo.Materials", new[] { "MaterialPriceGroupID" });
            AlterColumn("dbo.Materials", "Tvm1tID", c => c.Int());
            AlterColumn("dbo.Materials", "Tvm2tID", c => c.Int());
            AlterColumn("dbo.Materials", "Tvm3tID", c => c.Int());
            AlterColumn("dbo.Materials", "Tvm4tID", c => c.Int());
            AlterColumn("dbo.Materials", "Tvm5tID", c => c.Int());
            AlterColumn("dbo.Materials", "MaterialPriceGroupID", c => c.Int());
            CreateIndex("dbo.Materials", "Tvm1tID");
            CreateIndex("dbo.Materials", "Tvm2tID");
            CreateIndex("dbo.Materials", "Tvm3tID");
            CreateIndex("dbo.Materials", "Tvm4tID");
            CreateIndex("dbo.Materials", "Tvm5tID");
            CreateIndex("dbo.Materials", "MaterialPriceGroupID");
            AddForeignKey("dbo.Materials", "MaterialPriceGroupID", "dbo.MaterialPriceGroups", "ID");
            AddForeignKey("dbo.Materials", "Tvm1tID", "dbo.Tvm1t", "ID");
            AddForeignKey("dbo.Materials", "Tvm2tID", "dbo.Tvm2t", "ID");
            AddForeignKey("dbo.Materials", "Tvm3tID", "dbo.Tvm3t", "ID");
            AddForeignKey("dbo.Materials", "Tvm4tID", "dbo.Tvm4t", "ID");
            AddForeignKey("dbo.Materials", "Tvm5tID", "dbo.Tvm5t", "ID");
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
            AlterColumn("dbo.Materials", "MaterialPriceGroupID", c => c.Int(nullable: false));
            AlterColumn("dbo.Materials", "Tvm5tID", c => c.Int(nullable: false));
            AlterColumn("dbo.Materials", "Tvm4tID", c => c.Int(nullable: false));
            AlterColumn("dbo.Materials", "Tvm3tID", c => c.Int(nullable: false));
            AlterColumn("dbo.Materials", "Tvm2tID", c => c.Int(nullable: false));
            AlterColumn("dbo.Materials", "Tvm1tID", c => c.Int(nullable: false));
            CreateIndex("dbo.Materials", "MaterialPriceGroupID");
            CreateIndex("dbo.Materials", "Tvm5tID");
            CreateIndex("dbo.Materials", "Tvm4tID");
            CreateIndex("dbo.Materials", "Tvm3tID");
            CreateIndex("dbo.Materials", "Tvm2tID");
            CreateIndex("dbo.Materials", "Tvm1tID");
            AddForeignKey("dbo.Materials", "Tvm5tID", "dbo.Tvm5t", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Materials", "Tvm4tID", "dbo.Tvm4t", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Materials", "Tvm3tID", "dbo.Tvm3t", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Materials", "Tvm2tID", "dbo.Tvm2t", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Materials", "Tvm1tID", "dbo.Tvm1t", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Materials", "MaterialPriceGroupID", "dbo.MaterialPriceGroups", "ID", cascadeDelete: true);
        }
    }
}
