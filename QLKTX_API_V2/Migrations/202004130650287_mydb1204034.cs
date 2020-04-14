namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb1204034 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MKV7001", "date", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MKV7001", "date");
        }
    }
}
