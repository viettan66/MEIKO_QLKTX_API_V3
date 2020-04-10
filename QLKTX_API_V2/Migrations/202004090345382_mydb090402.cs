namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb090402 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MKV8001", "trangthai", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MKV8001", "trangthai");
        }
    }
}
