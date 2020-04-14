namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb110401 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MKV8002",
                c => new
                    {
                        MKV8002_ID = c.Int(nullable: false, identity: true),
                        ten = c.String(maxLength: 250),
                        ip = c.String(),
                        port = c.String(),
                        commkey = c.String(),
                        ghiChu = c.String(),
                        trangthai = c.Boolean(),
                        thutu = c.Int(),
                        type = c.Int(),
                    })
                .PrimaryKey(t => t.MKV8002_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MKV8002");
        }
    }
}
