namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb030404 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RM0003",
                c => new
                    {
                        RM0003_ID = c.Int(nullable: false, identity: true),
                        maBacDaoTao = c.String(),
                        tenBacDaoTao = c.String(),
                        thuTu = c.Int(),
                        tinhTrang = c.Boolean(),
                        ghiChu = c.String(),
                    })
                .PrimaryKey(t => t.RM0003_ID);
            
            CreateTable(
                "dbo.RM0004",
                c => new
                    {
                        RM0004_ID = c.Int(nullable: false, identity: true),
                        RM0002_ID = c.Int(nullable: false),
                        maChuyenNganh = c.String(),
                        tenChuyenNganh = c.String(),
                        thuTu = c.Int(),
                        tinhTrang = c.Boolean(),
                        ghiChu = c.String(),
                    })
                .PrimaryKey(t => t.RM0004_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RM0004");
            DropTable("dbo.RM0003");
        }
    }
}
