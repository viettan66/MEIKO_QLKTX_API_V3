namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RM0010", "RM0001_ID2", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RM0010", "RM0001_ID2", c => c.Int(nullable: false));
        }
    }
}
