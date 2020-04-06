namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb060409 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RM0007",
                c => new
                    {
                        RM0007_ID = c.Int(nullable: false, identity: true),
                        MKV9999_ID = c.Int(nullable: false),
                        RM0006_ID = c.Int(nullable: false),
                        trangThai = c.Boolean(),
                    })
                .PrimaryKey(t => t.RM0007_ID)
                .ForeignKey("dbo.MKV9999", t => t.MKV9999_ID, cascadeDelete: true)
                .ForeignKey("dbo.RM0006", t => t.RM0006_ID, cascadeDelete: true)
                .Index(t => t.MKV9999_ID)
                .Index(t => t.RM0006_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RM0007", "RM0006_ID", "dbo.RM0006");
            DropForeignKey("dbo.RM0007", "MKV9999_ID", "dbo.MKV9999");
            DropIndex("dbo.RM0007", new[] { "RM0006_ID" });
            DropIndex("dbo.RM0007", new[] { "MKV9999_ID" });
            DropTable("dbo.RM0007");
        }
    }
}
