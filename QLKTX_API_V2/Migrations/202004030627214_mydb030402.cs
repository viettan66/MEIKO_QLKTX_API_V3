namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb030402 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RM0001",
                c => new
                    {
                        RM0001_ID = c.Int(nullable: false, identity: true),
                        RM0004_ID = c.Int(),
                        maCongViec = c.String(),
                        tenCongViec = c.String(),
                        moTa = c.String(),
                        thuTu = c.Int(),
                        tinhTrang = c.Boolean(),
                        ghiChu = c.String(),
                    })
                .PrimaryKey(t => t.RM0001_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RM0001");
        }
    }
}
