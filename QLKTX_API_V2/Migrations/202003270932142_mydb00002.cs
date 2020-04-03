namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb00002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KTX0001", "capbac", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KTX0001", "capbac");
        }
    }
}
