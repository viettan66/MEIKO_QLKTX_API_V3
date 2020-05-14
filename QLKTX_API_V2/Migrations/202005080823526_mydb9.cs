namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KTX0049", "thanhtoan", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KTX0049", "thanhtoan");
        }
    }
}
