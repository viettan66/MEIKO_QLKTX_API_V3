namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KTX0049",
                c => new
                    {
                        User_ID = c.String(nullable: false, maxLength: 128),
                        startdate = c.DateTime(),
                        enddate = c.DateTime(),
                        trangthai = c.Boolean(),
                        ghichu = c.String(),
                    })
                .PrimaryKey(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KTX0049");
        }
    }
}
