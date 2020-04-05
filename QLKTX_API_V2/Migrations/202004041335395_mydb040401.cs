namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb040401 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RM0013",
                c => new
                    {
                        RM0013_ID = c.Int(nullable: false, identity: true),
                        RM0015_ID = c.Int(nullable: false),
                        MKV9999_ID = c.Int(nullable: false),
                        RM0006_ID = c.Int(nullable: false),
                        nhanXet = c.String(),
                        ghiChu = c.String(),
                        ketQua = c.Boolean(),
                        trangThai = c.Boolean(),
                        RM0006_RM0015_ID = c.Int(),
                        RM0015_RM0015_ID = c.Int(),
                    })
                .PrimaryKey(t => t.RM0013_ID)
                .ForeignKey("dbo.RM0015", t => t.RM0006_RM0015_ID)
                .ForeignKey("dbo.RM0015", t => t.RM0015_RM0015_ID)
                .Index(t => t.RM0006_RM0015_ID)
                .Index(t => t.RM0015_RM0015_ID);
            
            CreateTable(
                "dbo.RM0015",
                c => new
                    {
                        RM0015_ID = c.Int(nullable: false, identity: true),
                        RM0010_ID = c.Int(nullable: false),
                        thoiGianPhongVan = c.DateTime(),
                        ghiChu = c.String(),
                        trangThai = c.Boolean(),
                        ketQua = c.Boolean(),
                        vongPhongVan = c.Int(),
                    })
                .PrimaryKey(t => t.RM0015_ID);
            
            CreateTable(
                "dbo.RM0015A",
                c => new
                    {
                        RM0015A_ID = c.Int(nullable: false, identity: true),
                        RM0015_ID = c.Int(nullable: false),
                        MKV9999_ID = c.Int(nullable: false),
                        ghiChu = c.String(),
                        trangThai = c.Boolean(),
                    })
                .PrimaryKey(t => t.RM0015A_ID)
                .ForeignKey("dbo.RM0015", t => t.RM0015_ID, cascadeDelete: true)
                .Index(t => t.RM0015_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RM0013", "RM0015_RM0015_ID", "dbo.RM0015");
            DropForeignKey("dbo.RM0013", "RM0006_RM0015_ID", "dbo.RM0015");
            DropForeignKey("dbo.RM0015A", "RM0015_ID", "dbo.RM0015");
            DropIndex("dbo.RM0015A", new[] { "RM0015_ID" });
            DropIndex("dbo.RM0013", new[] { "RM0015_RM0015_ID" });
            DropIndex("dbo.RM0013", new[] { "RM0006_RM0015_ID" });
            DropTable("dbo.RM0015A");
            DropTable("dbo.RM0015");
            DropTable("dbo.RM0013");
        }
    }
}
