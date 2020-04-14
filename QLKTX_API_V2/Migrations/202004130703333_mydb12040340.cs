namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb12040340 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MKV7001", "MKV7000_ID", "dbo.MKV7000");
            DropForeignKey("dbo.MKV7001", "MKV9999_ID", "dbo.MKV9999");
            DropIndex("dbo.MKV7001", new[] { "MKV7000_ID" });
            DropIndex("dbo.MKV7001", new[] { "MKV9999_ID" });
            AlterColumn("dbo.MKV7001", "MKV7000_ID", c => c.Int());
            AlterColumn("dbo.MKV7001", "MKV9999_ID", c => c.Int());
            AlterColumn("dbo.MKV7001", "MKV9999_ID2", c => c.Int());
            CreateIndex("dbo.MKV7001", "MKV7000_ID");
            CreateIndex("dbo.MKV7001", "MKV9999_ID");
            AddForeignKey("dbo.MKV7001", "MKV7000_ID", "dbo.MKV7000", "MKV7000_ID");
            AddForeignKey("dbo.MKV7001", "MKV9999_ID", "dbo.MKV9999", "MKV9999_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MKV7001", "MKV9999_ID", "dbo.MKV9999");
            DropForeignKey("dbo.MKV7001", "MKV7000_ID", "dbo.MKV7000");
            DropIndex("dbo.MKV7001", new[] { "MKV9999_ID" });
            DropIndex("dbo.MKV7001", new[] { "MKV7000_ID" });
            AlterColumn("dbo.MKV7001", "MKV9999_ID2", c => c.Int(nullable: false));
            AlterColumn("dbo.MKV7001", "MKV9999_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.MKV7001", "MKV7000_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.MKV7001", "MKV9999_ID");
            CreateIndex("dbo.MKV7001", "MKV7000_ID");
            AddForeignKey("dbo.MKV7001", "MKV9999_ID", "dbo.MKV9999", "MKV9999_ID", cascadeDelete: true);
            AddForeignKey("dbo.MKV7001", "MKV7000_ID", "dbo.MKV7000", "MKV7000_ID", cascadeDelete: true);
        }
    }
}
