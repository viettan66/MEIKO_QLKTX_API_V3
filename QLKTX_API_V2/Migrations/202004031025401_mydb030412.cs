namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb030412 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RM0081_A", "RM0010_RM0010_ID", "dbo.RM0010");
            DropForeignKey("dbo.RM0081_B", "RM0010_RM0010_ID", "dbo.RM0010");
            DropForeignKey("dbo.RM0081_C", "RM0010_RM0010_ID", "dbo.RM0010");
            DropForeignKey("dbo.RM0081_D", "RM0010_RM0010_ID", "dbo.RM0010");
            DropForeignKey("dbo.RM0081_E", "RM0010_RM0010_ID", "dbo.RM0010");
            DropForeignKey("dbo.RM0081_F", "RM0010_RM0010_ID", "dbo.RM0010");
            DropIndex("dbo.RM0081_A", new[] { "RM0010_RM0010_ID" });
            DropIndex("dbo.RM0081_B", new[] { "RM0010_RM0010_ID" });
            DropIndex("dbo.RM0081_C", new[] { "RM0010_RM0010_ID" });
            DropIndex("dbo.RM0081_D", new[] { "RM0010_RM0010_ID" });
            DropIndex("dbo.RM0081_E", new[] { "RM0010_RM0010_ID" });
            DropIndex("dbo.RM0081_F", new[] { "RM0010_RM0010_ID" });
            DropColumn("dbo.RM0081_A", "RM0010_ID");
            DropColumn("dbo.RM0081_B", "RM0010_ID");
            DropColumn("dbo.RM0081_C", "RM0010_ID");
            DropColumn("dbo.RM0081_D", "RM0010_ID");
            DropColumn("dbo.RM0081_E", "RM0010_ID");
            DropColumn("dbo.RM0081_F", "RM0010_ID");
            RenameColumn(table: "dbo.RM0081_A", name: "RM0010_RM0010_ID", newName: "RM0010_ID");
            RenameColumn(table: "dbo.RM0081_B", name: "RM0010_RM0010_ID", newName: "RM0010_ID");
            RenameColumn(table: "dbo.RM0081_C", name: "RM0010_RM0010_ID", newName: "RM0010_ID");
            RenameColumn(table: "dbo.RM0081_D", name: "RM0010_RM0010_ID", newName: "RM0010_ID");
            RenameColumn(table: "dbo.RM0081_E", name: "RM0010_RM0010_ID", newName: "RM0010_ID");
            RenameColumn(table: "dbo.RM0081_F", name: "RM0010_RM0010_ID", newName: "RM0010_ID");
            AlterColumn("dbo.RM0081_A", "RM0010_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.RM0081_A", "RM0010_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.RM0081_B", "RM0010_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.RM0081_B", "RM0010_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.RM0081_C", "RM0010_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.RM0081_C", "RM0010_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.RM0081_D", "RM0010_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.RM0081_D", "RM0010_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.RM0081_E", "RM0010_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.RM0081_E", "RM0010_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.RM0081_F", "RM0010_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.RM0081_F", "RM0010_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.RM0081_A", "RM0010_ID");
            CreateIndex("dbo.RM0081_B", "RM0010_ID");
            CreateIndex("dbo.RM0081_C", "RM0010_ID");
            CreateIndex("dbo.RM0081_D", "RM0010_ID");
            CreateIndex("dbo.RM0081_E", "RM0010_ID");
            CreateIndex("dbo.RM0081_F", "RM0010_ID");
            AddForeignKey("dbo.RM0081_A", "RM0010_ID", "dbo.RM0010", "RM0010_ID", cascadeDelete: true);
            AddForeignKey("dbo.RM0081_B", "RM0010_ID", "dbo.RM0010", "RM0010_ID", cascadeDelete: true);
            AddForeignKey("dbo.RM0081_C", "RM0010_ID", "dbo.RM0010", "RM0010_ID", cascadeDelete: true);
            AddForeignKey("dbo.RM0081_D", "RM0010_ID", "dbo.RM0010", "RM0010_ID", cascadeDelete: true);
            AddForeignKey("dbo.RM0081_E", "RM0010_ID", "dbo.RM0010", "RM0010_ID", cascadeDelete: true);
            AddForeignKey("dbo.RM0081_F", "RM0010_ID", "dbo.RM0010", "RM0010_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RM0081_F", "RM0010_ID", "dbo.RM0010");
            DropForeignKey("dbo.RM0081_E", "RM0010_ID", "dbo.RM0010");
            DropForeignKey("dbo.RM0081_D", "RM0010_ID", "dbo.RM0010");
            DropForeignKey("dbo.RM0081_C", "RM0010_ID", "dbo.RM0010");
            DropForeignKey("dbo.RM0081_B", "RM0010_ID", "dbo.RM0010");
            DropForeignKey("dbo.RM0081_A", "RM0010_ID", "dbo.RM0010");
            DropIndex("dbo.RM0081_F", new[] { "RM0010_ID" });
            DropIndex("dbo.RM0081_E", new[] { "RM0010_ID" });
            DropIndex("dbo.RM0081_D", new[] { "RM0010_ID" });
            DropIndex("dbo.RM0081_C", new[] { "RM0010_ID" });
            DropIndex("dbo.RM0081_B", new[] { "RM0010_ID" });
            DropIndex("dbo.RM0081_A", new[] { "RM0010_ID" });
            AlterColumn("dbo.RM0081_F", "RM0010_ID", c => c.Int());
            AlterColumn("dbo.RM0081_F", "RM0010_ID", c => c.String());
            AlterColumn("dbo.RM0081_E", "RM0010_ID", c => c.Int());
            AlterColumn("dbo.RM0081_E", "RM0010_ID", c => c.String());
            AlterColumn("dbo.RM0081_D", "RM0010_ID", c => c.Int());
            AlterColumn("dbo.RM0081_D", "RM0010_ID", c => c.String());
            AlterColumn("dbo.RM0081_C", "RM0010_ID", c => c.Int());
            AlterColumn("dbo.RM0081_C", "RM0010_ID", c => c.String());
            AlterColumn("dbo.RM0081_B", "RM0010_ID", c => c.Int());
            AlterColumn("dbo.RM0081_B", "RM0010_ID", c => c.String());
            AlterColumn("dbo.RM0081_A", "RM0010_ID", c => c.Int());
            AlterColumn("dbo.RM0081_A", "RM0010_ID", c => c.String());
            RenameColumn(table: "dbo.RM0081_F", name: "RM0010_ID", newName: "RM0010_RM0010_ID");
            RenameColumn(table: "dbo.RM0081_E", name: "RM0010_ID", newName: "RM0010_RM0010_ID");
            RenameColumn(table: "dbo.RM0081_D", name: "RM0010_ID", newName: "RM0010_RM0010_ID");
            RenameColumn(table: "dbo.RM0081_C", name: "RM0010_ID", newName: "RM0010_RM0010_ID");
            RenameColumn(table: "dbo.RM0081_B", name: "RM0010_ID", newName: "RM0010_RM0010_ID");
            RenameColumn(table: "dbo.RM0081_A", name: "RM0010_ID", newName: "RM0010_RM0010_ID");
            AddColumn("dbo.RM0081_F", "RM0010_ID", c => c.String());
            AddColumn("dbo.RM0081_E", "RM0010_ID", c => c.String());
            AddColumn("dbo.RM0081_D", "RM0010_ID", c => c.String());
            AddColumn("dbo.RM0081_C", "RM0010_ID", c => c.String());
            AddColumn("dbo.RM0081_B", "RM0010_ID", c => c.String());
            AddColumn("dbo.RM0081_A", "RM0010_ID", c => c.String());
            CreateIndex("dbo.RM0081_F", "RM0010_RM0010_ID");
            CreateIndex("dbo.RM0081_E", "RM0010_RM0010_ID");
            CreateIndex("dbo.RM0081_D", "RM0010_RM0010_ID");
            CreateIndex("dbo.RM0081_C", "RM0010_RM0010_ID");
            CreateIndex("dbo.RM0081_B", "RM0010_RM0010_ID");
            CreateIndex("dbo.RM0081_A", "RM0010_RM0010_ID");
            AddForeignKey("dbo.RM0081_F", "RM0010_RM0010_ID", "dbo.RM0010", "RM0010_ID");
            AddForeignKey("dbo.RM0081_E", "RM0010_RM0010_ID", "dbo.RM0010", "RM0010_ID");
            AddForeignKey("dbo.RM0081_D", "RM0010_RM0010_ID", "dbo.RM0010", "RM0010_ID");
            AddForeignKey("dbo.RM0081_C", "RM0010_RM0010_ID", "dbo.RM0010", "RM0010_ID");
            AddForeignKey("dbo.RM0081_B", "RM0010_RM0010_ID", "dbo.RM0010", "RM0010_ID");
            AddForeignKey("dbo.RM0081_A", "RM0010_RM0010_ID", "dbo.RM0010", "RM0010_ID");
        }
    }
}
