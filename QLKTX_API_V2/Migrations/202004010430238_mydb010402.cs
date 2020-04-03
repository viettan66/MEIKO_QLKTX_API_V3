namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb010402 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KTX0031", "type", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KTX0031", "type");
        }
    }
}
