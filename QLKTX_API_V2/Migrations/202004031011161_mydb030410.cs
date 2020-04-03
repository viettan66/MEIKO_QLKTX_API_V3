namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb030410 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RM0010", "RM0001_RM0001_ID", "dbo.RM0001");
            DropIndex("dbo.RM0010", new[] { "RM0001_RM0001_ID" });
            RenameColumn(table: "dbo.RM0010", name: "RM0001_RM0001_ID", newName: "RM0001_ID");
            AlterColumn("dbo.RM0010", "RM0001_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.RM0010", "RM0001_ID");
            AddForeignKey("dbo.RM0010", "RM0001_ID", "dbo.RM0001", "RM0001_ID", cascadeDelete: true);
            DropColumn("dbo.RM0010", "RM0001_ID1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RM0010", "RM0001_ID1", c => c.String());
            DropForeignKey("dbo.RM0010", "RM0001_ID", "dbo.RM0001");
            DropIndex("dbo.RM0010", new[] { "RM0001_ID" });
            AlterColumn("dbo.RM0010", "RM0001_ID", c => c.Int());
            RenameColumn(table: "dbo.RM0010", name: "RM0001_ID", newName: "RM0001_RM0001_ID");
            CreateIndex("dbo.RM0010", "RM0001_RM0001_ID");
            AddForeignKey("dbo.RM0010", "RM0001_RM0001_ID", "dbo.RM0001", "RM0001_ID");
        }
    }
}
