namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb3103023 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KTX0040",
                c => new
                    {
                        KTX0040_ID = c.Int(nullable: false, identity: true),
                        tieude = c.String(maxLength: 250),
                        image = c.String(),
                        noidung = c.String(),
                        ghichu = c.String(),
                        trangthai = c.Boolean(),
                        thutu = c.Int(),
                    })
                .PrimaryKey(t => t.KTX0040_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KTX0040");
        }
    }
}
