namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb060402 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RM0015", "RM0008_ID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RM0015", "RM0008_ID");
        }
    }
}
