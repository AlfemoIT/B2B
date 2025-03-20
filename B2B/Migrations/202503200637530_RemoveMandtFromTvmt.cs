namespace B2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMandtFromTvmt : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tvm1t", "MANDT");
            DropColumn("dbo.Tvm1t", "SPRAS");
            DropColumn("dbo.Tvm2t", "MANDT");
            DropColumn("dbo.Tvm2t", "SPRAS");
            DropColumn("dbo.Tvm3t", "MANDT");
            DropColumn("dbo.Tvm3t", "SPRAS");
            DropColumn("dbo.Tvm4t", "MANDT");
            DropColumn("dbo.Tvm4t", "SPRAS");
            DropColumn("dbo.Tvm5t", "MANDT");
            DropColumn("dbo.Tvm5t", "SPRAS");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tvm5t", "SPRAS", c => c.String());
            AddColumn("dbo.Tvm5t", "MANDT", c => c.String());
            AddColumn("dbo.Tvm4t", "SPRAS", c => c.String());
            AddColumn("dbo.Tvm4t", "MANDT", c => c.String());
            AddColumn("dbo.Tvm3t", "SPRAS", c => c.String());
            AddColumn("dbo.Tvm3t", "MANDT", c => c.String());
            AddColumn("dbo.Tvm2t", "SPRAS", c => c.String());
            AddColumn("dbo.Tvm2t", "MANDT", c => c.String());
            AddColumn("dbo.Tvm1t", "SPRAS", c => c.String());
            AddColumn("dbo.Tvm1t", "MANDT", c => c.String());
        }
    }
}
