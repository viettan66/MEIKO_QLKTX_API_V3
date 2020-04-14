namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb120403 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MKV7001", "MKV9999_ID2", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MKV7001", "MKV9999_ID2");
        }
    }
}
