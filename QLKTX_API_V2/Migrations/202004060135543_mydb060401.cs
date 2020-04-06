namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb060401 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RM0013", "RM0006_RM0015_ID", "dbo.RM0015");
            DropForeignKey("dbo.RM0013", "RM0015_RM0015_ID", "dbo.RM0015");
            DropIndex("dbo.RM0013", new[] { "RM0006_RM0015_ID" });
            DropIndex("dbo.RM0013", new[] { "RM0015_RM0015_ID" });
            DropColumn("dbo.RM0013", "RM0006_ID");
            DropColumn("dbo.RM0013", "RM0015_ID");
            RenameColumn(table: "dbo.RM0013", name: "RM0006_RM0015_ID", newName: "RM0006_ID");
            RenameColumn(table: "dbo.RM0013", name: "RM0015_RM0015_ID", newName: "RM0015_ID");
            AlterColumn("dbo.RM0013", "RM0006_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.RM0013", "RM0015_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.RM0013", "RM0015_ID");
            CreateIndex("dbo.RM0013", "RM0006_ID");
            AddForeignKey("dbo.RM0013", "RM0006_ID", "dbo.RM0006", "RM0006_ID", cascadeDelete: true);
            AddForeignKey("dbo.RM0013", "RM0015_ID", "dbo.RM0015", "RM0015_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RM0013", "RM0015_ID", "dbo.RM0015");
            DropForeignKey("dbo.RM0013", "RM0006_ID", "dbo.RM0006");
            DropIndex("dbo.RM0013", new[] { "RM0006_ID" });
            DropIndex("dbo.RM0013", new[] { "RM0015_ID" });
            AlterColumn("dbo.RM0013", "RM0015_ID", c => c.Int());
            AlterColumn("dbo.RM0013", "RM0006_ID", c => c.Int());
            RenameColumn(table: "dbo.RM0013", name: "RM0015_ID", newName: "RM0015_RM0015_ID");
            RenameColumn(table: "dbo.RM0013", name: "RM0006_ID", newName: "RM0006_RM0015_ID");
            AddColumn("dbo.RM0013", "RM0015_ID", c => c.Int(nullable: false));
            AddColumn("dbo.RM0013", "RM0006_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.RM0013", "RM0015_RM0015_ID");
            CreateIndex("dbo.RM0013", "RM0006_RM0015_ID");
            AddForeignKey("dbo.RM0013", "RM0015_RM0015_ID", "dbo.RM0015", "RM0015_ID");
            AddForeignKey("dbo.RM0013", "RM0006_RM0015_ID", "dbo.RM0015", "RM0015_ID");
        }
    }
}
