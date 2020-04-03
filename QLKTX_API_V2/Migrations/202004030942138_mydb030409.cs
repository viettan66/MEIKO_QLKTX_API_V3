namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb030409 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RM0010",
                c => new
                    {
                        RM0010_ID = c.Int(nullable: false, identity: true),
                        maID = c.String(),
                        HODEM = c.String(),
                        TEN = c.String(),
                        NGAYSINH = c.DateTime(),
                        NOISINH = c.String(),
                        CMTND_SO = c.String(),
                        CMTND_NGAYCAP = c.DateTime(),
                        CMTND_NOICAP = c.String(),
                        GIOITINH = c.Boolean(),
                        HONNHAN = c.Boolean(),
                        TELEPHONE = c.String(),
                        MOBILE = c.String(),
                        CHIEUCAO = c.Double(),
                        CANNANG = c.Double(),
                        EMAIL = c.String(),
                        THUONGTRU = c.String(),
                        TAMTRU = c.String(),
                        RM0001_ID1 = c.String(),
                        RM0001_ID2 = c.String(),
                        NGAYCOTHELAM = c.DateTime(),
                        THUNHAPMONGMUON = c.Double(),
                        COTHELAMTHEM = c.Boolean(),
                        COTHEDICONGTAC = c.Boolean(),
                        COTHETHAYDOIDIADIEM = c.Boolean(),
                        DATUNGTHITUYENMEIKO = c.Boolean(),
                        NEUDATUNGTHITUYENMEIKO = c.String(),
                        ID_NGUONTHONGTIN = c.Int(),
                        DUDINHTUONGLAI = c.String(),
                        SOTHICH = c.String(),
                        KHONGTHICH = c.String(),
                        CACPHAMCHATKYNANG = c.String(),
                        HOTENNGUOITHAN = c.String(),
                        DIACHINGUOITHAN = c.String(),
                        MOBILENGUOITHAN = c.String(),
                        ANHCHANDUNG = c.Binary(),
                        RM0011_ID1 = c.String(),
                        RM0011_ID2 = c.String(),
                        trangthai = c.Boolean(),
                        DUDINHHOCTIEPCHUYENNGANH = c.String(),
                        DUDINHHOCTIEP = c.Boolean(),
                        bophanid = c.String(),
                        RM0001_RM0001_ID = c.Int(),
                    })
                .PrimaryKey(t => t.RM0010_ID)
                .ForeignKey("dbo.RM0001", t => t.RM0001_RM0001_ID)
                .Index(t => t.RM0001_RM0001_ID);
            
            CreateTable(
                "dbo.RM0080",
                c => new
                    {
                        RM0080_ID = c.Int(nullable: false, identity: true),
                        RM0010_ID = c.Int(nullable: false),
                        QUANHE = c.String(),
                        HOTEN = c.String(),
                        LAMGIODAU = c.String(),
                    })
                .PrimaryKey(t => t.RM0080_ID)
                .ForeignKey("dbo.RM0010", t => t.RM0010_ID, cascadeDelete: true)
                .Index(t => t.RM0010_ID);
            
            CreateTable(
                "dbo.RM0081_A",
                c => new
                    {
                        RM0081_ID = c.Int(nullable: false, identity: true),
                        BATDAU = c.DateTime(),
                        KETTHUC = c.DateTime(),
                        CHUYENNGANH = c.String(),
                        TENTRUONG = c.String(),
                        QUOCGIA = c.String(),
                        HEDAOTAO = c.String(),
                        XEPLOAI = c.String(),
                        TYPE = c.Int(),
                        RM0010_ID = c.String(),
                        RM0010_RM0010_ID = c.Int(),
                    })
                .PrimaryKey(t => t.RM0081_ID)
                .ForeignKey("dbo.RM0010", t => t.RM0010_RM0010_ID)
                .Index(t => t.RM0010_RM0010_ID);
            
            CreateTable(
                "dbo.RM0081_B",
                c => new
                    {
                        RM0081_ID = c.Int(nullable: false, identity: true),
                        RM0010_ID = c.String(),
                        NGOAINGU = c.String(),
                        CHUNGCHI = c.String(),
                        XEPLOAI = c.String(),
                        NGAYCAP = c.DateTime(),
                        NGHE = c.String(),
                        NOI = c.String(),
                        DOC = c.String(),
                        VIET = c.String(),
                        RM0010_RM0010_ID = c.Int(),
                    })
                .PrimaryKey(t => t.RM0081_ID)
                .ForeignKey("dbo.RM0010", t => t.RM0010_RM0010_ID)
                .Index(t => t.RM0010_RM0010_ID);
            
            CreateTable(
                "dbo.RM0081_C",
                c => new
                    {
                        RM0081_ID = c.Int(nullable: false, identity: true),
                        RM0010_ID = c.String(),
                        TENPHANMEM = c.String(),
                        TRINHDO = c.Int(),
                        RM0010_RM0010_ID = c.Int(),
                    })
                .PrimaryKey(t => t.RM0081_ID)
                .ForeignKey("dbo.RM0010", t => t.RM0010_RM0010_ID)
                .Index(t => t.RM0010_RM0010_ID);
            
            CreateTable(
                "dbo.RM0081_D",
                c => new
                    {
                        RM0081_ID = c.Int(nullable: false, identity: true),
                        RM0010_ID = c.String(),
                        TENGIAITHUONG = c.String(),
                        RM0002_ID = c.String(),
                        TOCHUCTRAO = c.String(),
                        NAM = c.DateTime(),
                        RM0010_RM0010_ID = c.Int(),
                    })
                .PrimaryKey(t => t.RM0081_ID)
                .ForeignKey("dbo.RM0010", t => t.RM0010_RM0010_ID)
                .Index(t => t.RM0010_RM0010_ID);
            
            CreateTable(
                "dbo.RM0081_E",
                c => new
                    {
                        RM0081_ID = c.Int(nullable: false, identity: true),
                        RM0010_ID = c.String(),
                        BATDAU = c.DateTime(),
                        KETTHUC = c.DateTime(),
                        QUOCGIA = c.String(),
                        TINH = c.String(),
                        VITRI = c.String(),
                        MUCLUONG = c.Double(nullable: false),
                        MOTA = c.String(),
                        LYDONGHIVIEC = c.String(),
                        TENCONGTY = c.String(),
                        RM0010_RM0010_ID = c.Int(),
                    })
                .PrimaryKey(t => t.RM0081_ID)
                .ForeignKey("dbo.RM0010", t => t.RM0010_RM0010_ID)
                .Index(t => t.RM0010_RM0010_ID);
            
            CreateTable(
                "dbo.RM0081_F",
                c => new
                    {
                        RM0081_ID = c.Int(nullable: false, identity: true),
                        RM0010_ID = c.String(),
                        HOTEN = c.String(),
                        VITRI = c.String(),
                        DONVI = c.String(),
                        MOBILE = c.String(),
                        RM0010_RM0010_ID = c.Int(),
                    })
                .PrimaryKey(t => t.RM0081_ID)
                .ForeignKey("dbo.RM0010", t => t.RM0010_RM0010_ID)
                .Index(t => t.RM0010_RM0010_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RM0081_F", "RM0010_RM0010_ID", "dbo.RM0010");
            DropForeignKey("dbo.RM0081_E", "RM0010_RM0010_ID", "dbo.RM0010");
            DropForeignKey("dbo.RM0081_D", "RM0010_RM0010_ID", "dbo.RM0010");
            DropForeignKey("dbo.RM0081_C", "RM0010_RM0010_ID", "dbo.RM0010");
            DropForeignKey("dbo.RM0081_B", "RM0010_RM0010_ID", "dbo.RM0010");
            DropForeignKey("dbo.RM0081_A", "RM0010_RM0010_ID", "dbo.RM0010");
            DropForeignKey("dbo.RM0080", "RM0010_ID", "dbo.RM0010");
            DropForeignKey("dbo.RM0010", "RM0001_RM0001_ID", "dbo.RM0001");
            DropIndex("dbo.RM0081_F", new[] { "RM0010_RM0010_ID" });
            DropIndex("dbo.RM0081_E", new[] { "RM0010_RM0010_ID" });
            DropIndex("dbo.RM0081_D", new[] { "RM0010_RM0010_ID" });
            DropIndex("dbo.RM0081_C", new[] { "RM0010_RM0010_ID" });
            DropIndex("dbo.RM0081_B", new[] { "RM0010_RM0010_ID" });
            DropIndex("dbo.RM0081_A", new[] { "RM0010_RM0010_ID" });
            DropIndex("dbo.RM0080", new[] { "RM0010_ID" });
            DropIndex("dbo.RM0010", new[] { "RM0001_RM0001_ID" });
            DropTable("dbo.RM0081_F");
            DropTable("dbo.RM0081_E");
            DropTable("dbo.RM0081_D");
            DropTable("dbo.RM0081_C");
            DropTable("dbo.RM0081_B");
            DropTable("dbo.RM0081_A");
            DropTable("dbo.RM0080");
            DropTable("dbo.RM0010");
        }
    }
}
