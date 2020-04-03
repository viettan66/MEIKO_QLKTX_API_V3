namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb030408 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RM0009",
                c => new
                    {
                        RM0009_ID = c.Int(nullable: false, identity: true),
                        maNguonThongTin = c.String(),
                        tenNguongThongTin = c.String(),
                        ghiChu = c.String(),
                    })
                .PrimaryKey(t => t.RM0009_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RM0009");
        }
    }
}
