﻿namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RM0010", "RM0001_ID", "dbo.RM0001");
            DropIndex("dbo.RM0010", new[] { "RM0001_ID" });
            AlterColumn("dbo.RM0010", "RM0001_ID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RM0010", "RM0001_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.RM0010", "RM0001_ID");
            AddForeignKey("dbo.RM0010", "RM0001_ID", "dbo.RM0001", "RM0001_ID", cascadeDelete: true);
        }
    }
}
