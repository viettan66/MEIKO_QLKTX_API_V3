namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb6 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.A0028E", new[] { "A0028_A0028_ID" });
            DropColumn("dbo.A0028E", "A0028_ID");
            RenameColumn(table: "dbo.A0028E", name: "A0028_A0028_ID", newName: "A0028_ID");
            AlterColumn("dbo.A0028E", "A0028_ID", c => c.String(maxLength: 128));
            CreateIndex("dbo.A0028E", "A0028_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.A0028E", new[] { "A0028_ID" });
            AlterColumn("dbo.A0028E", "A0028_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.A0028E", name: "A0028_ID", newName: "A0028_A0028_ID");
            AddColumn("dbo.A0028E", "A0028_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.A0028E", "A0028_A0028_ID");
        }
    }
}
