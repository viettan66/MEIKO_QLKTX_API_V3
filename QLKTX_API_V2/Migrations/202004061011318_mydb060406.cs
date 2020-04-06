namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb060406 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.RM0015", "RM0010_ID");
            AddForeignKey("dbo.RM0015", "RM0010_ID", "dbo.RM0010", "RM0010_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RM0015", "RM0010_ID", "dbo.RM0010");
            DropIndex("dbo.RM0015", new[] { "RM0010_ID" });
        }
    }
}
