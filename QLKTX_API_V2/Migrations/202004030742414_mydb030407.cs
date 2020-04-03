namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb030407 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RM0008",
                c => new
                    {
                        RM0008_ID = c.Int(nullable: false, identity: true),
                        maDiaDiem = c.String(),
                        DiaDiem = c.String(),
                        ghiChu = c.String(),
                    })
                .PrimaryKey(t => t.RM0008_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RM0008");
        }
    }
}
