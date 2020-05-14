namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RM0015", "kqChung", c => c.String());
            AddColumn("dbo.RM0015", "ngoaingu", c => c.String());
            AddColumn("dbo.RM0015", "IQ", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RM0015", "IQ");
            DropColumn("dbo.RM0015", "ngoaingu");
            DropColumn("dbo.RM0015", "kqChung");
        }
    }
}
