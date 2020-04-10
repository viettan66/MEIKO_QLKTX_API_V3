namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb090401 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MKV8001",
                c => new
                    {
                        MKV8001_ID = c.Int(nullable: false, identity: true),
                        taikhoan = c.String(),
                        sdt = c.String(),
                        cmnd = c.String(),
                    })
                .PrimaryKey(t => t.MKV8001_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MKV8001");
        }
    }
}
