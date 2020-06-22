namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RM0010", "Headhunt", c => c.String());
            AddColumn("dbo.RM0010", "Position", c => c.String());
            AddColumn("dbo.RM0010", "Date", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RM0010", "Date");
            DropColumn("dbo.RM0010", "Position");
            DropColumn("dbo.RM0010", "Headhunt");
        }
    }
}
