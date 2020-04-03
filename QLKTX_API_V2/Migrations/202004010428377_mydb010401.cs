namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb010401 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MKV9999", "type", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MKV9999", "type");
        }
    }
}
