namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb030403 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RM0002",
                c => new
                    {
                        RM0002_ID = c.Int(nullable: false, identity: true),
                        maLinhVuc = c.String(),
                        tenLinhVuc = c.String(),
                        thuTu = c.Int(),
                        tinhTrang = c.Boolean(),
                        ghiChu = c.String(),
                    })
                .PrimaryKey(t => t.RM0002_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RM0002");
        }
    }
}
