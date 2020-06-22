namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KTX0021", "batdau", c => c.String());
            AlterColumn("dbo.KTX0021", "ketthuc", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KTX0021", "ketthuc", c => c.DateTime());
            AlterColumn("dbo.KTX0021", "batdau", c => c.DateTime());
        }
    }
}
