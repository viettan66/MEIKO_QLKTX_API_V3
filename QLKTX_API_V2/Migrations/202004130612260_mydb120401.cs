namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb120401 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MKV7000",
                c => new
                    {
                        MKV7000_ID = c.Int(nullable: false, identity: true),
                        ten = c.String(maxLength: 250),
                        type = c.Int(),
                        trangthai = c.Boolean(),
                    })
                .PrimaryKey(t => t.MKV7000_ID);
            
            CreateTable(
                "dbo.MKV7001",
                c => new
                    {
                        MKV7001_ID = c.Int(nullable: false, identity: true),
                        MKV7000_ID = c.Int(nullable: false),
                        MKV9999_ID = c.Int(nullable: false),
                        tieuDe = c.String(maxLength: 250),
                        noiDung = c.String(),
                        ghiChu = c.String(),
                        trangthai = c.Boolean(),
                    })
                .PrimaryKey(t => t.MKV7001_ID)
                .ForeignKey("dbo.MKV7000", t => t.MKV7000_ID, cascadeDelete: true)
                .ForeignKey("dbo.MKV9999", t => t.MKV9999_ID, cascadeDelete: true)
                .Index(t => t.MKV7000_ID)
                .Index(t => t.MKV9999_ID);
            
            CreateTable(
                "dbo.MKV7002",
                c => new
                    {
                        MKV7002_ID = c.Int(nullable: false, identity: true),
                        MKV7000_ID = c.Int(nullable: false),
                        MKV9999_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MKV7002_ID)
                .ForeignKey("dbo.MKV7000", t => t.MKV7000_ID, cascadeDelete: true)
                .ForeignKey("dbo.MKV9999", t => t.MKV9999_ID, cascadeDelete: true)
                .Index(t => t.MKV7000_ID)
                .Index(t => t.MKV9999_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MKV7002", "MKV9999_ID", "dbo.MKV9999");
            DropForeignKey("dbo.MKV7002", "MKV7000_ID", "dbo.MKV7000");
            DropForeignKey("dbo.MKV7001", "MKV9999_ID", "dbo.MKV9999");
            DropForeignKey("dbo.MKV7001", "MKV7000_ID", "dbo.MKV7000");
            DropIndex("dbo.MKV7002", new[] { "MKV9999_ID" });
            DropIndex("dbo.MKV7002", new[] { "MKV7000_ID" });
            DropIndex("dbo.MKV7001", new[] { "MKV9999_ID" });
            DropIndex("dbo.MKV7001", new[] { "MKV7000_ID" });
            DropTable("dbo.MKV7002");
            DropTable("dbo.MKV7001");
            DropTable("dbo.MKV7000");
        }
    }
}
