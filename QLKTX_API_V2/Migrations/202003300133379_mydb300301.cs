namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb300301 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KTX0020", "capbac", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KTX0020", "capbac");
        }
    }
}
