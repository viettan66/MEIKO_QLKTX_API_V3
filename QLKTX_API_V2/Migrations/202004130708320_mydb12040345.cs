namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb12040345 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MKV7001", "type", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MKV7001", "type");
        }
    }
}
