﻿namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb260302 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KTX0001", "khu", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KTX0001", "khu");
        }
    }
}
