namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb030406 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RM0005",
                c => new
                    {
                        RM0005_ID = c.Int(nullable: false, identity: true),
                        maNgoaiNgu = c.String(),
                        tenNgoaiNgu = c.String(),
                        thuTu = c.Int(),
                        tinhTrang = c.Boolean(),
                        ghiChu = c.String(),
                    })
                .PrimaryKey(t => t.RM0005_ID);
            
            CreateTable(
                "dbo.RM0006",
                c => new
                    {
                        RM0006_ID = c.Int(nullable: false, identity: true),
                        maTieuChiDG = c.String(),
                        tenTieuChiDG = c.String(),
                        thuTu = c.Int(),
                        tinhTrang = c.Boolean(),
                        ghiChu = c.String(),
                    })
                .PrimaryKey(t => t.RM0006_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RM0006");
            DropTable("dbo.RM0005");
        }
    }
}
