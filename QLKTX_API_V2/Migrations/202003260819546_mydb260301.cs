namespace QLKTX_API_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb260301 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KTX0001",
                c => new
                    {
                        KTX0001_ID = c.Int(nullable: false, identity: true),
                        idcha = c.Int(),
                        ten = c.String(),
                        makhoa = c.String(),
                        ghichu = c.String(),
                        trangthai = c.Boolean(),
                        thutu = c.Int(),
                        slot = c.Int(),
                        type = c.Int(),
                    })
                .PrimaryKey(t => t.KTX0001_ID);
            
            CreateTable(
                "dbo.KTX0002",
                c => new
                    {
                        KTX0002_ID = c.Int(nullable: false, identity: true),
                        KTX0001_ID = c.Int(nullable: false),
                        ten = c.String(),
                        ghichu = c.String(),
                        trangthai = c.Boolean(),
                        thutu = c.Int(),
                        type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KTX0002_ID)
                .ForeignKey("dbo.KTX0001", t => t.KTX0001_ID, cascadeDelete: true)
                .Index(t => t.KTX0001_ID);
            
            CreateTable(
                "dbo.KTX0003",
                c => new
                    {
                        KTX0003_ID = c.Int(nullable: false, identity: true),
                        KTX0001_ID = c.Int(nullable: false),
                        SoTu = c.String(),
                        MaKhoa = c.String(),
                        ghichu = c.String(),
                        trangthai = c.Boolean(),
                        type = c.Int(),
                    })
                .PrimaryKey(t => t.KTX0003_ID)
                .ForeignKey("dbo.KTX0001", t => t.KTX0001_ID, cascadeDelete: true)
                .Index(t => t.KTX0001_ID);
            
            CreateTable(
                "dbo.KTX0011",
                c => new
                    {
                        KTX0011_ID = c.Int(nullable: false, identity: true),
                        KTX0001_ID = c.Int(nullable: false),
                        KTX0010_ID = c.Int(nullable: false),
                        soluong = c.Int(),
                        ghichu = c.String(),
                    })
                .PrimaryKey(t => t.KTX0011_ID)
                .ForeignKey("dbo.KTX0001", t => t.KTX0001_ID, cascadeDelete: true)
                .ForeignKey("dbo.KTX0010", t => t.KTX0010_ID, cascadeDelete: true)
                .Index(t => t.KTX0001_ID)
                .Index(t => t.KTX0010_ID);
            
            CreateTable(
                "dbo.KTX0010",
                c => new
                    {
                        KTX0010_ID = c.Int(nullable: false, identity: true),
                        WH0007_ID = c.String(),
                        maSanPham = c.String(),
                        ten = c.String(),
                        giatien = c.Double(nullable: false),
                        donvi = c.String(maxLength: 50),
                        ghichu = c.String(),
                        trangthai = c.Boolean(),
                        thutu = c.Int(),
                        loai = c.Int(),
                        soluongmacdinh = c.Int(),
                        soLuongTonKho = c.Int(),
                    })
                .PrimaryKey(t => t.KTX0010_ID);
            
            CreateTable(
                "dbo.KTX0020",
                c => new
                    {
                        KTX0020_ID = c.Int(nullable: false, identity: true),
                        MKV9999_ID = c.Int(nullable: false),
                        okitucxa = c.Boolean(),
                        ngayokitucxa = c.DateTime(),
                        quaylaikytucxa = c.Boolean(),
                        ngayquaylaikytucxa = c.DateTime(),
                        thoigiantralantruoc = c.DateTime(),
                        lydodangkyoktx = c.String(),
                        nguyenvongophongso = c.String(maxLength: 50),
                        lydonguyenvong = c.String(),
                        somayle = c.String(maxLength: 20),
                        didong = c.String(maxLength: 20),
                        nharieng = c.String(maxLength: 20),
                        chunhiemnoilamviec = c.Boolean(),
                        truongphongnoilamviec = c.Boolean(),
                        bqlktx = c.Boolean(),
                        truongphongGA = c.Boolean(),
                        KTX0001_ID = c.Int(),
                        KTX0002_ID = c.Int(),
                        KTX0003_ID = c.Int(),
                        printcount = c.Int(),
                        khoaphong = c.String(),
                        sotu = c.String(),
                        sokhoatu = c.String(),
                        ngaycohieuluc = c.DateTime(),
                        bengiao = c.Boolean(),
                        bennhan = c.Boolean(),
                        hotenkhaisinh = c.String(),
                        gioitinh = c.Boolean(),
                        hotenkhac = c.String(),
                        ngaysinh = c.DateTime(),
                        noisinh = c.String(),
                        quequan = c.String(),
                        dantoc = c.String(),
                        tongiao = c.String(),
                        cmtnd_so = c.String(),
                        cmtnd_ngaycap = c.DateTime(),
                        cmtnd_noicap = c.String(),
                        noithuongtru = c.String(),
                        choohiennay = c.String(),
                        trinhdohocvan = c.String(),
                        trinhdchuyenmon = c.String(),
                        biettiengdantocitnguoi = c.String(),
                        bietngoaingu = c.String(),
                        nghenghiepchucvunoilam = c.String(),
                        lamgiodautu14tuoi = c.String(),
                        ngaytaodon = c.DateTime(),
                        ngayduyetdon = c.DateTime(),
                        noidung = c.String(),
                        lydo = c.String(),
                        hotenbengiao = c.String(),
                        ghichu = c.String(),
                        ghichu2 = c.String(),
                        tienantoidanhhinhphat = c.String(),
                        trangthai = c.Boolean(),
                        trangthai2 = c.Boolean(),
                    })
                .PrimaryKey(t => t.KTX0020_ID)
                .ForeignKey("dbo.MKV9999", t => t.MKV9999_ID, cascadeDelete: true)
                .Index(t => t.MKV9999_ID);
            
            CreateTable(
                "dbo.KTX0021",
                c => new
                    {
                        KTX0021_ID = c.Int(nullable: false, identity: true),
                        KTX0020_ID = c.Int(nullable: false),
                        batdau = c.DateTime(),
                        ketthuc = c.DateTime(),
                        choo = c.String(),
                        nghenghiepnoilam = c.String(),
                    })
                .PrimaryKey(t => t.KTX0021_ID)
                .ForeignKey("dbo.KTX0020", t => t.KTX0020_ID, cascadeDelete: true)
                .Index(t => t.KTX0020_ID);
            
            CreateTable(
                "dbo.KTX0022",
                c => new
                    {
                        KTX0022_ID = c.Int(nullable: false, identity: true),
                        KTX0020_ID = c.Int(nullable: false),
                        HoTen = c.String(maxLength: 255),
                        NamSinh = c.String(maxLength: 5),
                        QuanHe = c.String(maxLength: 255),
                        NgheNghiep = c.String(),
                        ChoOHienNay = c.String(),
                    })
                .PrimaryKey(t => t.KTX0022_ID)
                .ForeignKey("dbo.KTX0020", t => t.KTX0020_ID, cascadeDelete: true)
                .Index(t => t.KTX0020_ID);
            
            CreateTable(
                "dbo.MKV9999",
                c => new
                    {
                        MKV9999_ID = c.Int(nullable: false, identity: true),
                        manhansu = c.String(nullable: false, maxLength: 50),
                        matkhau = c.String(nullable: false, maxLength: 50),
                        id = c.String(),
                        hodem = c.String(nullable: false, maxLength: 50),
                        ten = c.String(nullable: false, maxLength: 50),
                        ngaysinh = c.DateTime(),
                        gioitinh = c.Boolean(),
                        noisinh = c.String(),
                        quequan = c.String(),
                        diachithuongtru = c.String(),
                        diachitamtru = c.String(),
                        cmtnd_so = c.String(maxLength: 50),
                        cmtnd_ngayhethan = c.DateTime(),
                        cmtnd_noicap = c.String(),
                        hochieu_so = c.String(maxLength: 50),
                        hochieu_ngaycap = c.DateTime(),
                        hochieu_ngayhethan = c.DateTime(),
                        ngayvaocongty = c.DateTime(),
                        phong_id = c.String(maxLength: 100),
                        ban_id = c.String(maxLength: 50),
                        congdoan_id = c.String(maxLength: 50),
                        chucvu_id = c.String(maxLength: 50),
                        nganhang_stk = c.String(maxLength: 50),
                        nganhang_id = c.String(maxLength: 50),
                        sosobaohiem = c.String(maxLength: 50),
                        honnhantinhtrang = c.Boolean(),
                        datnuoc_id = c.String(maxLength: 50),
                        phuongxa = c.String(maxLength: 150),
                        suckhoetinhtrang = c.String(),
                        dienthoai_nharieng = c.String(maxLength: 50),
                        dienthoai_didong = c.String(maxLength: 50),
                        email = c.String(maxLength: 150),
                        tinhtrangnhansu = c.Boolean(),
                        thutu = c.Int(),
                        chucvu = c.String(maxLength: 50),
                        capbac = c.String(maxLength: 50),
                        thetu_id = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MKV9999_ID)
                .ForeignKey("dbo.MKV9998", t => t.phong_id)
                .Index(t => t.phong_id);
            
            CreateTable(
                "dbo.MKV9998",
                c => new
                    {
                        phong_id = c.String(nullable: false, maxLength: 100),
                        bophan_ma = c.String(maxLength: 50),
                        bophan_ten = c.String(maxLength: 50),
                        bophan_dienthoai = c.String(maxLength: 50),
                        bophan_diachi = c.String(maxLength: 150),
                        tinhtrang = c.Boolean(),
                        thutu = c.Int(),
                        idcha = c.String(maxLength: 100),
                        muc = c.String(maxLength: 100),
                        asoft = c.Int(),
                        congty_id = c.String(),
                    })
                .PrimaryKey(t => t.phong_id);
            
            CreateTable(
                "dbo.KTX0023",
                c => new
                    {
                        KTX0023_ID = c.Int(nullable: false, identity: true),
                        MKV9999_ID = c.Int(nullable: false),
                        trakytucxa = c.Boolean(),
                        ngaytrakytucxa = c.DateTime(),
                        lydotra = c.String(),
                        somayle = c.String(),
                        didong = c.String(),
                        chunhiemnoilam = c.String(),
                        truongphongnoilam = c.String(),
                        banqlktx = c.String(),
                        chunhiemGA = c.String(),
                        KTX0001_ID = c.Int(),
                        printcount = c.Int(),
                        KTX0002_ID = c.Int(),
                        KTX0003_ID = c.Int(),
                        khoaphong = c.String(),
                        sotu = c.String(),
                        sokhoatu = c.String(),
                        ngaycohieuluc = c.DateTime(),
                        tonggiatriboithuong = c.Single(),
                        bqlhoten = c.String(),
                        bqlkynhan = c.Boolean(),
                        nldhoten = c.String(),
                        nldkynhan = c.Boolean(),
                        trangthai = c.Boolean(),
                        ngaytaodon = c.DateTime(),
                        nhanxet = c.String(),
                    })
                .PrimaryKey(t => t.KTX0023_ID)
                .ForeignKey("dbo.MKV9999", t => t.MKV9999_ID, cascadeDelete: true)
                .Index(t => t.MKV9999_ID);
            
            CreateTable(
                "dbo.KTX0031",
                c => new
                    {
                        KTX0031_ID = c.Int(nullable: false, identity: true),
                        KTX0010_ID = c.Int(nullable: false),
                        MKV9999_ID = c.Int(nullable: false),
                        KTX0023_ID = c.Int(nullable: false),
                        ngaycap = c.DateTime(),
                        soluongcap = c.Int(),
                        ngaytra = c.DateTime(),
                        soluongtra = c.Int(),
                        trangthai = c.Boolean(),
                        ghichu = c.String(),
                        thutu = c.Int(),
                    })
                .PrimaryKey(t => t.KTX0031_ID)
                .ForeignKey("dbo.KTX0010", t => t.KTX0010_ID, cascadeDelete: true)
                .ForeignKey("dbo.MKV9999", t => t.MKV9999_ID, cascadeDelete: true)
                .Index(t => t.KTX0010_ID)
                .Index(t => t.MKV9999_ID);
            
            CreateTable(
                "dbo.MKV8000",
                c => new
                    {
                        MKV8000_ID = c.Int(nullable: false, identity: true),
                        ST01 = c.String(),
                        ST02 = c.String(),
                        ST03 = c.String(),
                        ST04 = c.String(),
                        ST05 = c.String(),
                        ST06 = c.String(),
                        ST07 = c.String(),
                        ST08 = c.String(),
                        ST09 = c.String(),
                        ST10 = c.String(),
                        ST11 = c.String(),
                        ST12 = c.String(),
                        ST13 = c.String(),
                        ST14 = c.String(),
                        ST15 = c.String(),
                        ST16 = c.String(),
                        ST17 = c.String(),
                        ST18 = c.String(),
                    })
                .PrimaryKey(t => t.MKV8000_ID);
            
            CreateTable(
                "dbo.MKV9980",
                c => new
                    {
                        MKV9980_ID = c.Int(nullable: false, identity: true),
                        TENQUYEN = c.String(),
                        GHICHU = c.String(),
                        TINHTRANG = c.Boolean(),
                    })
                .PrimaryKey(t => t.MKV9980_ID);
            
            CreateTable(
                "dbo.MKV9981",
                c => new
                    {
                        MKV9981_ID = c.Int(nullable: false, identity: true),
                        MKV9980_ID = c.Int(nullable: false),
                        TENHANHDONG = c.String(),
                        GHICHU = c.String(),
                        TINHTRANG = c.Boolean(),
                        THUTU = c.Int(),
                        TENMENU = c.String(),
                        LINKMENU = c.String(),
                        CAPMENU = c.Int(nullable: false),
                        IDCHA = c.Int(nullable: false),
                        IMAGE = c.String(),
                    })
                .PrimaryKey(t => t.MKV9981_ID)
                .ForeignKey("dbo.MKV9980", t => t.MKV9980_ID, cascadeDelete: true)
                .Index(t => t.MKV9980_ID);
            
            CreateTable(
                "dbo.MKV9982",
                c => new
                    {
                        MKV9982_ID = c.Int(nullable: false, identity: true),
                        MKV9981_ID = c.Int(nullable: false),
                        MKV9983_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MKV9982_ID)
                .ForeignKey("dbo.MKV9981", t => t.MKV9981_ID, cascadeDelete: true)
                .ForeignKey("dbo.MKV9983", t => t.MKV9983_ID, cascadeDelete: true)
                .Index(t => t.MKV9981_ID)
                .Index(t => t.MKV9983_ID);
            
            CreateTable(
                "dbo.MKV9983",
                c => new
                    {
                        MKV9983_ID = c.Int(nullable: false, identity: true),
                        TENNHOM = c.String(),
                        TINHTRANG = c.Boolean(),
                    })
                .PrimaryKey(t => t.MKV9983_ID);
            
            CreateTable(
                "dbo.MKV9984",
                c => new
                    {
                        MKV9984_ID = c.Int(nullable: false, identity: true),
                        MKV9999_ID = c.Int(nullable: false),
                        MKV9983_ID = c.Int(nullable: false),
                        TENNHOM = c.String(),
                        TINHTRANG = c.Boolean(),
                    })
                .PrimaryKey(t => t.MKV9984_ID)
                .ForeignKey("dbo.MKV9983", t => t.MKV9983_ID, cascadeDelete: true)
                .ForeignKey("dbo.MKV9999", t => t.MKV9999_ID, cascadeDelete: true)
                .Index(t => t.MKV9999_ID)
                .Index(t => t.MKV9983_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MKV9984", "MKV9999_ID", "dbo.MKV9999");
            DropForeignKey("dbo.MKV9984", "MKV9983_ID", "dbo.MKV9983");
            DropForeignKey("dbo.MKV9982", "MKV9983_ID", "dbo.MKV9983");
            DropForeignKey("dbo.MKV9982", "MKV9981_ID", "dbo.MKV9981");
            DropForeignKey("dbo.MKV9981", "MKV9980_ID", "dbo.MKV9980");
            DropForeignKey("dbo.KTX0031", "MKV9999_ID", "dbo.MKV9999");
            DropForeignKey("dbo.KTX0031", "KTX0010_ID", "dbo.KTX0010");
            DropForeignKey("dbo.KTX0023", "MKV9999_ID", "dbo.MKV9999");
            DropForeignKey("dbo.KTX0020", "MKV9999_ID", "dbo.MKV9999");
            DropForeignKey("dbo.MKV9999", "phong_id", "dbo.MKV9998");
            DropForeignKey("dbo.KTX0022", "KTX0020_ID", "dbo.KTX0020");
            DropForeignKey("dbo.KTX0021", "KTX0020_ID", "dbo.KTX0020");
            DropForeignKey("dbo.KTX0011", "KTX0010_ID", "dbo.KTX0010");
            DropForeignKey("dbo.KTX0011", "KTX0001_ID", "dbo.KTX0001");
            DropForeignKey("dbo.KTX0003", "KTX0001_ID", "dbo.KTX0001");
            DropForeignKey("dbo.KTX0002", "KTX0001_ID", "dbo.KTX0001");
            DropIndex("dbo.MKV9984", new[] { "MKV9983_ID" });
            DropIndex("dbo.MKV9984", new[] { "MKV9999_ID" });
            DropIndex("dbo.MKV9982", new[] { "MKV9983_ID" });
            DropIndex("dbo.MKV9982", new[] { "MKV9981_ID" });
            DropIndex("dbo.MKV9981", new[] { "MKV9980_ID" });
            DropIndex("dbo.KTX0031", new[] { "MKV9999_ID" });
            DropIndex("dbo.KTX0031", new[] { "KTX0010_ID" });
            DropIndex("dbo.KTX0023", new[] { "MKV9999_ID" });
            DropIndex("dbo.MKV9999", new[] { "phong_id" });
            DropIndex("dbo.KTX0022", new[] { "KTX0020_ID" });
            DropIndex("dbo.KTX0021", new[] { "KTX0020_ID" });
            DropIndex("dbo.KTX0020", new[] { "MKV9999_ID" });
            DropIndex("dbo.KTX0011", new[] { "KTX0010_ID" });
            DropIndex("dbo.KTX0011", new[] { "KTX0001_ID" });
            DropIndex("dbo.KTX0003", new[] { "KTX0001_ID" });
            DropIndex("dbo.KTX0002", new[] { "KTX0001_ID" });
            DropTable("dbo.MKV9984");
            DropTable("dbo.MKV9983");
            DropTable("dbo.MKV9982");
            DropTable("dbo.MKV9981");
            DropTable("dbo.MKV9980");
            DropTable("dbo.MKV8000");
            DropTable("dbo.KTX0031");
            DropTable("dbo.KTX0023");
            DropTable("dbo.MKV9998");
            DropTable("dbo.MKV9999");
            DropTable("dbo.KTX0022");
            DropTable("dbo.KTX0021");
            DropTable("dbo.KTX0020");
            DropTable("dbo.KTX0010");
            DropTable("dbo.KTX0011");
            DropTable("dbo.KTX0003");
            DropTable("dbo.KTX0002");
            DropTable("dbo.KTX0001");
        }
    }
}
