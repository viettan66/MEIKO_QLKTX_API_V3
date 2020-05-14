namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.A0028E",
                c => new
                    {
                        A0028E_ID = c.Int(nullable: false, identity: true),
                        MKV9999_ID = c.Int(nullable: false),
                        A0028_ID = c.Int(nullable: false),
                        A0028_A0028_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.A0028E_ID)
                .ForeignKey("dbo.A0028", t => t.A0028_A0028_ID)
                .Index(t => t.A0028_A0028_ID);
            
            AddColumn("dbo.A0028", "thoigian", c => c.DateTime());
            AddColumn("dbo.A0028", "RM0008_ID", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.A0028E", "A0028_A0028_ID", "dbo.A0028");
            DropIndex("dbo.A0028E", new[] { "A0028_A0028_ID" });
            DropColumn("dbo.A0028", "RM0008_ID");
            DropColumn("dbo.A0028", "thoigian");
            DropTable("dbo.A0028E");
        }
    }
}
