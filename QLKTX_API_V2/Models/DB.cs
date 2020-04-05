
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MEIKO_QLKTX_API_V1.Models
{
        /// <summary>
        /// Đây là lớp Database. Nếu có lỗi kết nối hãy kiểm tra ConnectionString phía dưới.v
        /// </summary>
    public class DB : DbContext
    {
        public DB() : base("DefaultConnection1")
        {

        }
        //protected override void OnConfiguring()
        //{
        //    optionsBuilder.UseSqlServer(@"data source=IT527\SQLEXPRESS;initial catalog=MKVC_DB;user id=sa;password=12345678;MultipleActiveResultSets=True;App=EntityFramework&quot;");
        
        //    ///optionsBuilder.UseSqlServer(@"data source=DESKTOP-DLI1F52\SQLEXPRESS;initial catalog=MKVC_DB;user id=sa;password=viettan66;MultipleActiveResultSets=True;App=EntityFramework&quot;");
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}

        public DbSet<KTX0001> KTX0001 { get; set; }
        public DbSet<KTX0002> KTX0002 { get; set; }
        public DbSet<KTX0003> KTX0003 { get; set; }
        public DbSet<KTX0010> KTX0010 { get; set; }
        public DbSet<KTX0011> KTX0011 { get; set; }
        public DbSet<KTX0031> KTX0031 { get; set; }
        public DbSet<MKV9999> MKV9999 { get; set; }
        public DbSet<MKV9998> MKV9998 { get; set; }
        public DbSet<MKV9980> MKV9980 { get; set; }
        public DbSet<MKV9981> MKV9981 { get; set; }
        public DbSet<MKV9982> MKV9982 { get; set; }
        public DbSet<MKV9983> MKV9983 { get; set; }
        public DbSet<MKV9984> MKV9984 { get; set; }
        public DbSet<KTX0020> KTX0020 { get; set; }
        public DbSet<KTX0021> KTX0021 { get; set; }
        public DbSet<KTX0022> KTX0022 { get; set; }
        public DbSet<KTX0023> KTX0023 { get; set; }
        public DbSet<MKV8000> KTX8000 { get; set; }
        public DbSet<KTX0040> KTX0040 { get; set; }


        public DbSet<RM0001> RM0001 { get; set; }
        public DbSet<RM0002> RM0002 { get; set; }
        public DbSet<RM0003> RM0003 { get; set; }
        public DbSet<RM0004> RM0004 { get; set; }
        public DbSet<RM0005> RM0005 { get; set; }
        public DbSet<RM0006> RM0006 { get; set; }
        public DbSet<RM0008> RM0008 { get; set; }
        public DbSet<RM0009> RM0009 { get; set; }
        public DbSet<RM0010> RM0010 { get; set; }
        public DbSet<RM0080> RM0080 { get; set; }
        public DbSet<RM0081_A> RM0081_A { get; set; }
        public DbSet<RM0081_B> RM0081_B { get; set; }
        public DbSet<RM0081_C> RM0081_C { get; set; }
        public DbSet<RM0081_D> RM0081_D { get; set; }
        public DbSet<RM0081_E> RM0081_E { get; set; }
        public DbSet<RM0081_F> RM0081_F { get; set; }
        public DbSet<RM0015> RM0015 { get; set; }
        public DbSet<RM0015A> RM0015A { get; set; }
        public DbSet<RM0013> RM0013 { get; set; }
    }
    /// <summary>
    /// Đây là lớp khởi tạo Database và Insert dữ liệu
    /// </summary>
    public static class MyDbContextSeeder
    {

        /// <summary>
        /// Đây là Hàm khởi tạo Database và Insert dữ liệu
        /// </summary>
        public static void Seed(DB context)
        {
            context.MKV9998.Add(new MKV9998() { phong_id = "009a3783-493c-432b-bc77-7b46140fceff", bophan_ten = "EM" });
            context.MKV9998.Add(new MKV9998() { phong_id = "0401c55c-1f0a-4a77-8c19-e5bfab99ad66", bophan_ten = "SL2" });
            context.MKV9998.Add(new MKV9998() { phong_id = "08ecdced-660a-4a3e-ac58-f438cd0c6b7b", bophan_ten = "F-MA" });
            context.MKV9998.Add(new MKV9998() { phong_id = "1339e01f-1d85-42ea-af2c-e684aa461464", bophan_ten = "F-DS" });
            context.MKV9998.Add(new MKV9998() { phong_id = "14b1d51a-f794-47e4-9e2c-3225b83282f1", bophan_ten = "MA1A" });
            context.MKV9998.Add(new MKV9998() { phong_id = "15e3fee4-1f3f-49eb-91b5-8426648ab7b7", bophan_ten = "Quản lý rủi ro" });
            context.MKV9998.Add(new MKV9998() { phong_id = "20c07882-229c-498e-8800-5970d2f65d4e", bophan_ten = "MA4" });
            context.MKV9998.Add(new MKV9998() { phong_id = "2593604f-dd98-4fa4-b508-d07bd5e9643b", bophan_ten = "SL1" });
            context.MKV9998.Add(new MKV9998() { phong_id = "28fb1bea-5695-4845-a146-d0fb3ccb8237", bophan_ten = "E-QA" });
            context.MKV9998.Add(new MKV9998() { phong_id = "37592e22-e3df-40d1-8118-f3b3f1dc325a", bophan_ten = "F-PE" });
            context.MKV9998.Add(new MKV9998() { phong_id = "3b8c2b09-9123-433d-a74d-84c734c9dcb5", bophan_ten = "PC" });
            context.MKV9998.Add(new MKV9998() { phong_id = "3fab275a-76e8-4480-8802-343bc3108b80", bophan_ten = "LG" });
            context.MKV9998.Add(new MKV9998() { phong_id = "48658e83-0abb-4ff9-8ba4-28c05165bff4", bophan_ten = "MA5A" });
            context.MKV9998.Add(new MKV9998() { phong_id = "4a5dbc54-e5dd-4f18-b606-42b1b208fc4f", bophan_ten = "PE1" });
            context.MKV9998.Add(new MKV9998() { phong_id = "5b5e75ef-27e0-4f9e-af2a-7f4200e495aa", bophan_ten = "CS1" });
            context.MKV9998.Add(new MKV9998() { phong_id = "5c3e90ca-671a-422d-b6c1-ed19073a5f3d", bophan_ten = "FE" });
            context.MKV9998.Add(new MKV9998() { phong_id = "631209aa-4d54-439b-ba06-9ac09204e65b", bophan_ten = "PE2" });
            context.MKV9998.Add(new MKV9998() { phong_id = "68750978-03a4-4851-98c1-80f977e00cf8", bophan_ten = "PD2" });
            context.MKV9998.Add(new MKV9998() { phong_id = "7335dd33-84b3-42c4-b554-b0ab2a5ea3db", bophan_ten = "HR" });
            context.MKV9998.Add(new MKV9998() { phong_id = "7b3a637d-9832-4c0f-8ed8-e4339c89e7a1", bophan_ten = "MC" });
            context.MKV9998.Add(new MKV9998() { phong_id = "87020722-3966-4eec-bf9b-3f53257610ce", bophan_ten = "SL3" });
            context.MKV9998.Add(new MKV9998() { phong_id = "8803aeea-882d-423c-aa3a-ac598799309b", bophan_ten = "MA2" });
            context.MKV9998.Add(new MKV9998() { phong_id = "88ade990-3308-426c-b9e1-a9b7f78bc7e9", bophan_ten = "F-MR" });
            context.MKV9998.Add(new MKV9998() { phong_id = "8acee89a-c12d-4228-a1ef-82fc8d76ff8f", bophan_ten = "E-PC" });
            context.MKV9998.Add(new MKV9998() { phong_id = "8b5f7efb-bb07-4e5d-8922-6eff5748d0da", bophan_ten = "SL" });
            context.MKV9998.Add(new MKV9998() { phong_id = "8bb13ff3-9f83-49cd-a049-661c7cd6670d", bophan_ten = "E-MA" });
            context.MKV9998.Add(new MKV9998() { phong_id = "8c03466d-9ca5-4a15-ae63-44f0b49ef1d2", bophan_ten = "MA5B" });
            context.MKV9998.Add(new MKV9998() { phong_id = "934e81e5-b274-4dc5-a86d-9a5523d9eb7b", bophan_ten = "QC2" });
            context.MKV9998.Add(new MKV9998() { phong_id = "93f16930-1e38-4b5b-8c04-e8c855fd6a08", bophan_ten = "GA" });
            context.MKV9998.Add(new MKV9998() { phong_id = "978dcfa6-3647-4b16-ba65-fe9fa226270b", bophan_ten = "E-PU" });
            context.MKV9998.Add(new MKV9998() { phong_id = "98556f84-6d3e-42fa-a084-6b9d22839181", bophan_ten = "IT" });
            context.MKV9998.Add(new MKV9998() { phong_id = "9cce0dd2-8a72-47be-bc02-6db716a1dd6c", bophan_ten = "MA6" });
            context.MKV9998.Add(new MKV9998() { phong_id = "a41b4ebe-3655-44ee-bc9f-c6ecbdee2c24", bophan_ten = "CT" });
            context.MKV9998.Add(new MKV9998() { phong_id = "b050f6d6-314a-416a-95d1-6e3b99cb1650", bophan_ten = "PD3" });
            context.MKV9998.Add(new MKV9998() { phong_id = "b60fec96-708e-45b8-91ac-a7d2d5bbac01", bophan_ten = "MA3B" });
            context.MKV9998.Add(new MKV9998() { phong_id = "b628e491-b561-41ff-bc86-5ee1007ffa4a", bophan_ten = "MA3A" });
            context.MKV9998.Add(new MKV9998() { phong_id = "b64b3d0b-2e5b-47e6-bbae-d0b0944935ec", bophan_ten = "SI2" });
            context.MKV9998.Add(new MKV9998() { phong_id = "bec5d987-d505-4571-9f0c-3b27b08272ff", bophan_ten = "F-QA" });
            context.MKV9998.Add(new MKV9998() { phong_id = "bf6859ea-28e8-4a97-9b63-2d6d5e314792", bophan_ten = "Quản lý chung" });
            context.MKV9998.Add(new MKV9998() { phong_id = "c88fe487-deb8-416b-a857-7a1556ccae44", bophan_ten = "PE5" });
            context.MKV9998.Add(new MKV9998() { phong_id = "c9354b4a-7ee1-4c01-a8a7-dceaf78789e9", bophan_ten = "PE2" });
            context.MKV9998.Add(new MKV9998() { phong_id = "c9a487e8-5fde-480d-ba77-5e81374fe076", bophan_ten = "MA1B" });
            context.MKV9998.Add(new MKV9998() { phong_id = "cf332d01-13bc-4940-a4a6-325372f5917a", bophan_ten = "QC1" });
            context.MKV9998.Add(new MKV9998() { phong_id = "cf5e9694-efba-4ef3-962d-f836fcefb568", bophan_ten = "PE3" });
            context.MKV9998.Add(new MKV9998() { phong_id = "cfa0e153-aa76-4db0-be26-b31b9edb8099", bophan_ten = "CS3" });
            context.MKV9998.Add(new MKV9998() { phong_id = "d18af034-c7a6-46e1-a786-b3a7f151453b", bophan_ten = "SS" });
            context.MKV9998.Add(new MKV9998() { phong_id = "d3ca07c2-1088-4175-afaa-e316fba92d95", bophan_ten = "E-EN" });
            context.MKV9998.Add(new MKV9998() { phong_id = "d5949a43-9283-4dbd-b1b3-ab18815208b2", bophan_ten = "FN" });
            context.MKV9998.Add(new MKV9998() { phong_id = "dca93815-9c6b-4695-addf-7c7e69efcd38", bophan_ten = "F-PD" });
            context.MKV9998.Add(new MKV9998() { phong_id = "e4a09c9a-0967-434b-bc9b-55262b194f78", bophan_ten = "QA" });
            context.MKV9998.Add(new MKV9998() { phong_id = "e5679ed3-83d2-4870-b392-f7c47fa5777d", bophan_ten = "CS2" });
            context.MKV9998.Add(new MKV9998() { phong_id = "ec273f58-7a4d-4688-b440-3ab989024ede", bophan_ten = "SI3" });
            context.MKV9998.Add(new MKV9998() { phong_id = "ef1cc1ac-fbd7-4570-b1d6-bd47760ca868", bophan_ten = "SI1" });
            context.MKV9998.Add(new MKV9998() { phong_id = "f02c68ae-0669-4368-b3c4-bc7b9600a00c", bophan_ten = "PD1" });
            context.MKV9998.Add(new MKV9998() { phong_id = "f155784f-0a68-41d1-b6c3-a1488d804620", bophan_ten = "CAM" });
            context.MKV9998.Add(new MKV9998() { phong_id = "f40fbecf-d98e-48f5-bae1-d30f34de5bbd", bophan_ten = "PU" });
            context.SaveChanges();
            context.MKV9999.Add(new MKV9999(){manhansu = "admin",hodem="Administrator",ten="(IT)",matkhau = "1",phong_id= "98556f84-6d3e-42fa-a084-6b9d22839181" });
            context.SaveChanges();
            context.MKV9983.Add(new MKV9983() {  TENNHOM = "Admin" });
            context.MKV9983.Add(new MKV9983() {  TENNHOM = "Người dùng mặc định" });
            context.SaveChanges();
            context.MKV9980.Add(new MKV9980() { TENQUYEN = "DASHBOARD" });
            context.MKV9980.Add(new MKV9980() {  TENQUYEN = "KÝ TÚC XÁ" });
            context.SaveChanges();
            context.MKV9981.Add(new MKV9981() { MKV9980_ID = 1, TENHANHDONG = "DASHBOARD",LINKMENU="DASHBOARD",CAPMENU=0,IMAGE= @"/assets/image/icon/dashboard.png" });
            context.MKV9981.Add(new MKV9981() { MKV9980_ID = 2, TENHANHDONG = "KÝ TÚC XÁ",LINKMENU="QLKTX",CAPMENU=0,IMAGE= @"/assets/image/icon/KTX1.jpg" });
            context.MKV9981.Add(new MKV9981() { MKV9980_ID = 2, TENHANHDONG = "ĐƠN CỦA TÔI",LINKMENU= "QLKTX/QLDK", CAPMENU=1,IDCHA=2 });
            context.MKV9981.Add(new MKV9981() { MKV9980_ID = 2, TENHANHDONG = "QUẢN LÝ THIẾT BỊ",LINKMENU= "QLKTX/QLTB", CAPMENU=1,IDCHA=2 });
            context.MKV9981.Add(new MKV9981() { MKV9980_ID = 2, TENHANHDONG = "QUẢN LÝ PHÒNG",LINKMENU= "QLKTX/QLP", CAPMENU=1,IDCHA=2 });
            context.MKV9981.Add(new MKV9981() { MKV9980_ID = 2, TENHANHDONG = "SẮP PHÒNG",LINKMENU= "QLKTX/QLSP", CAPMENU=1,IDCHA=2 });
            context.MKV9981.Add(new MKV9981() { MKV9980_ID = 2, TENHANHDONG = "QUẢN LÝ ĐƠN",LINKMENU= "QLKTX/QLD", CAPMENU=1,IDCHA=2 });
            context.MKV9981.Add(new MKV9981() { MKV9980_ID = 2, TENHANHDONG = "TRA CỨU",LINKMENU= "QLKTX/QLTCTK", CAPMENU=1,IDCHA=2 });
            context.SaveChanges();
            context.MKV9984.Add(new MKV9984() { MKV9999_ID = 1, MKV9983_ID = 1 }); ;
            context.SaveChanges();
            context.MKV9982.Add(new MKV9982() { MKV9981_ID = 1, MKV9983_ID = 1 }); ;
            context.MKV9982.Add(new MKV9982() { MKV9981_ID = 2, MKV9983_ID = 1 }); ;
            context.MKV9982.Add(new MKV9982() { MKV9981_ID = 3, MKV9983_ID = 1 }); ;
            context.MKV9982.Add(new MKV9982() { MKV9981_ID = 4, MKV9983_ID = 1 }); ;
            context.MKV9982.Add(new MKV9982() { MKV9981_ID = 5, MKV9983_ID = 1 }); ;
            context.MKV9982.Add(new MKV9982() { MKV9981_ID = 6, MKV9983_ID = 1 }); ;
            context.MKV9982.Add(new MKV9982() { MKV9981_ID = 2, MKV9983_ID = 2 }); ;
            context.MKV9982.Add(new MKV9982() { MKV9981_ID = 3, MKV9983_ID = 2 }); ;
            context.SaveChanges();
        }
    }
    /// <summary>
    /// Đây là bảng "PHÒNG"
    /// </summary>
    [Table("KTX0001")]//Dãy nhà
    public class KTX0001
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KTX0001_ID { get; set; }
        public Nullable<int> idcha { get; set; }
        public string khu { get; set; }
        public string ten { get; set; }
        public string makhoa { get; set; }
        public string ghichu { get; set; }
        public Nullable<bool> trangthai { get; set; }
        public Nullable<int> thutu { get; set; }
        public Nullable<int> slot { get; set; }
        public Nullable<int> type { get; set; }
        public Nullable<int> capbac { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<KTX0002> KTX0002 { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<KTX0003> KTX0003 { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<KTX0011> KTX0011 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Giường"
    /// </summary>
    [Table("KTX0002")]
    public class KTX0002
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KTX0002_ID { get; set; }
        public int KTX0001_ID { get; set; }
        public string ten { get; set; }
        public string ghichu { get; set; }
        public Nullable<bool> trangthai { get; set; }
        public Nullable<int> thutu { get; set; }
        public int type { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual KTX0001 KTX0001 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Chìa khóa"
    /// </summary>
    [Table("KTX0003")]
    public class KTX0003
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KTX0003_ID { get; set; }
        public int KTX0001_ID { get; set; }
        public string SoTu { get; set; }
        public string MaKhoa { get; set; }
        public string ghichu { get; set; }
        public Nullable<bool> trangthai { get; set; }
        public Nullable<int> type { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual KTX0001 KTX0001 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Đồ dùng"
    /// </summary>
    [Table("KTX0010")]
    public class KTX0010
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KTX0010_ID { get; set; }
        public string WH0007_ID { get; set; }
        public string maSanPham { get; set; }
        public string ten { get; set; }
        public double giatien { get; set; }
        [MaxLength(50)]
        public string donvi { get; set; }
        public string ghichu { get; set; }
        public Nullable<bool> trangthai { get; set; }
        public Nullable<int> thutu { get; set; }
        public Nullable<int> loai { get; set; }
        public Nullable<int> soluongmacdinh { get; set; }
        public Nullable<int> soluongfull { get; set; }
        public Nullable<int> soLuongTonKho { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<KTX0011> KTX0011 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Đồ dùng người ở"
    /// </summary>
    /// 
    public class KTX0011
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KTX0011_ID { get; set; }
        public int KTX0001_ID { get; set; }
        public int KTX0010_ID { get; set; }
        public Nullable<int> soluong { get; set; }
        public string ghichu { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual KTX0001 KTX0001 { get; set; }//130
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual KTX0010 KTX0010 { get; set; }//130
    }
    [Table("KTX0031")]
    public class KTX0031
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KTX0031_ID { get; set; }
        public int KTX0010_ID { get; set; }
        public int MKV9999_ID { get; set; }
        public int KTX0023_ID { get; set; }
        public Nullable<DateTime> ngaycap { get; set; }
        public Nullable<int> soluongcap { get; set; }
        public Nullable<DateTime> ngaytra { get; set; }
        public Nullable<int> soluongtra { get; set; }
        public Nullable<bool> trangthai { get; set; }
        public Nullable<int> type { get; set; }
        public string ghichu { get; set; }
        public Nullable<int> thutu { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual KTX0010 KTX0010 { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual MKV9999 MKV9999 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Đơn xin"
    /// </summary>
    [Table("KTX0020")]
    public class KTX0020
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KTX0020_ID { get; set; }
        public int MKV9999_ID { get; set; }
        public Nullable<bool> okitucxa { get; set; }
        public Nullable<DateTime> ngayokitucxa { get; set; }
        public Nullable<bool> quaylaikytucxa { get; set; }
        public Nullable<DateTime> ngayquaylaikytucxa { get; set; }
        public Nullable<DateTime> thoigiantralantruoc { get; set; }
        public string lydodangkyoktx { get; set; }
        [MaxLength(50)]
        public string nguyenvongophongso { get; set; }
        public string lydonguyenvong { get; set; }
        [MaxLength(20)]
        public string somayle { get; set; }
        [MaxLength(20)]
        public string didong  { get; set; }
        [MaxLength(20)]
        public string nharieng { get; set; }
        public Nullable<bool> chunhiemnoilamviec { get; set; }
        public Nullable<bool> truongphongnoilamviec { get; set; }
        public Nullable<bool> bqlktx { get; set; }
        public Nullable<bool> truongphongGA { get; set; }
        public Nullable<int> KTX0001_ID { get; set; }
        public Nullable<int> KTX0002_ID { get; set; }
        public Nullable<int> KTX0003_ID { get; set; }
        public Nullable<int> printcount { get; set; }
        public Nullable<int> capbac { get; set; }
        public string khoaphong { get; set; }
        public string sotu { get; set; }
        public string sokhoatu { get; set; }
        public Nullable<DateTime> ngaycohieuluc { get; set; }
        public Nullable<bool> bengiao { get; set; }
        public Nullable<bool> bennhan { get; set; }


        public string hotenkhaisinh { get; set; }
        public Nullable<bool> gioitinh { get; set; }
        public string hotenkhac { get; set; }
        public Nullable<DateTime> ngaysinh { get; set; }
        public string noisinh { get; set; }
        public string quequan { get; set; }
        public string dantoc { get; set; }
        public string tongiao { get; set; }
        public string cmtnd_so { get; set; }
        public Nullable<DateTime> cmtnd_ngaycap { get; set; }
        public string cmtnd_noicap { get; set; }
        public string noithuongtru { get; set; }
        public string choohiennay { get; set; }
        public string trinhdohocvan { get; set; }
        public string trinhdchuyenmon { get; set; }
        public string biettiengdantocitnguoi { get; set; }
        public string bietngoaingu { get; set; }
        public string nghenghiepchucvunoilam { get; set; }
        public string lamgiodautu14tuoi { get; set; }
        public Nullable<DateTime> ngaytaodon { get; set; }
        public Nullable<DateTime> ngayduyetdon  { get; set; }
        public string noidung  { get; set; }
        public string lydo  { get; set; }
        public string hotenbengiao { get; set; }
        public string ghichu  { get; set; }
        public string ghichu2  { get; set; }
        public string tienantoidanhhinhphat  { get; set; }
        public Nullable<bool> trangthai  { get; set; }
        public Nullable<bool> trangthai2  { get; set; }

        //[JsonIgnore]
        //[IgnoreDataMember]
        public virtual ICollection<KTX0021> KTX0021 { get; set; }
        //[JsonIgnore]
        //[IgnoreDataMember]
        public virtual ICollection<KTX0022> KTX0022 { get; set; }
        
        public virtual MKV9999 MKV9999 { get; set; }
    }



    /// <summary>
    /// Đây là bảng "phụ kê khai nhân khẩu"
    /// </summary>
    [Table("KTX0021 ")]
    public class KTX0021
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KTX0021_ID { get; set; }
        public int KTX0020_ID { get; set; }
        public Nullable<DateTime> batdau { get; set; }
        public Nullable<DateTime> ketthuc { get; set; }
        public string choo { get; set; }
        public string nghenghiepnoilam { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual KTX0020 KTX0020 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "phụ kê khai nhân khẩu 2"
    /// </summary>
    [Table("KTX0022 ")]
    public class KTX0022
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KTX0022_ID { get; set; }
        public int KTX0020_ID { get; set; }
        [MaxLength(255)]
        public string HoTen { get; set; }
        [MaxLength(5)]
        public string NamSinh { get; set; }
        [MaxLength(255)]
        public string QuanHe { get; set; }
        public string NgheNghiep { get; set; }
        public string ChoOHienNay { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual KTX0020 KTX0020 { get; set; }
    }

    /// <summary>
    /// Đây là bảng "đơn xin ra ngoài"
    /// </summary>
    [Table("KTX0023 ")]
    public class KTX0023
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KTX0023_ID { get; set; }
        public int MKV9999_ID { get; set; }
        public Nullable< bool> trakytucxa{ get; set; }
        public Nullable< DateTime> ngaytrakytucxa{ get; set; }
        public string lydotra { get; set; }
        public string somayle { get; set; }
        public string didong { get; set; }
        public string chunhiemnoilam { get; set; }
        public string truongphongnoilam { get; set; }
        public string banqlktx { get; set; }
        public string chunhiemGA { get; set; }
        public Nullable<int> KTX0001_ID { get; set; }
        public Nullable<int> printcount { get; set; }
        public Nullable<int> KTX0002_ID { get; set; }
        public Nullable<int> KTX0003_ID { get; set; }
        public string khoaphong { get; set; }
        public string sotu { get; set; }
        public string sokhoatu { get; set; }
        public Nullable<DateTime> ngaycohieuluc { get; set; }
        public Nullable<float> tonggiatriboithuong { get; set; }
        public string bqlhoten{ get; set; }
        public Nullable<bool> bqlkynhan { get; set; }
        public string nldhoten{ get; set; }
        public Nullable<bool> nldkynhan { get; set; }
        public Nullable<bool> trangthai { get; set; }
        public Nullable<DateTime> ngaytaodon { get; set; }
        public string nhanxet { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual MKV9999 MKV9999 { get; set; }

    }

    /// <summary>
    /// Đây là bảng "Thông tin KTX"
    /// </summary>
    [Table("KTX0040 ")]
    public class KTX0040
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KTX0040_ID { get; set; }
        [MaxLength(250)]
        public string tieude{ get; set; }
        public string image{ get; set; }
        public string noidung{ get; set; }
        public string ghichu{ get; set; }
        public Nullable<bool> trangthai{ get; set; }
        public Nullable<int> thutu{ get; set; }
    }
        /// <summary>
        /// Đây là bảng "Tài khoản"
        /// </summary>
        [Table("MKV9999")]//Tài khoản DDDDDD
    public class MKV9999
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MKV9999_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string manhansu { get; set; }
        [Required]
        [MaxLength(50)]
        public string matkhau { get; set; }
        public string id { get; set; }
        [Required]
        [MaxLength(50)]
        public string hodem { get; set; }
        [Required]
        [MaxLength(50)]
        public string ten { get; set; }
        public Nullable<DateTime> ngaysinh { get; set; }
        public Nullable<bool> gioitinh { get; set; }
        public string noisinh { get; set; }
        public string quequan { get; set; }
        public string diachithuongtru { get; set; }
        public string diachitamtru { get; set; }
        [MaxLength(50)]
        public string cmtnd_so { get; set; }
        public Nullable<DateTime> cmtnd_ngayhethan { get; set; }
        public string cmtnd_noicap { get; set; }
        [MaxLength(50)]
        public string hochieu_so { get; set; }
        public Nullable<DateTime> hochieu_ngaycap { get; set; }
        public Nullable<DateTime> hochieu_ngayhethan { get; set; }
        public Nullable<DateTime> ngayvaocongty { get; set; }
        [MaxLength(100)]
        public string phong_id { get; set; }
        [MaxLength(50)]
        public string ban_id { get; set; }
        [MaxLength(50)]
        public string congdoan_id { get; set; }
        [MaxLength(50)]
        public string chucvu_id { get; set; }
        [MaxLength(50)]
        public string nganhang_stk { get; set; }
        [MaxLength(50)]
        public string nganhang_id { get; set; }
        [MaxLength(50)]
        public string sosobaohiem { get; set; }
        public Nullable<bool> honnhantinhtrang { get; set; }
        [MaxLength(50)]
        public string datnuoc_id { get; set; }
        [MaxLength(150)]
        public string phuongxa { get; set; }
        public string suckhoetinhtrang { get; set; }
        [MaxLength(50)]
        public string dienthoai_nharieng { get; set; }
        [MaxLength(50)]
        public string dienthoai_didong { get; set; }
        [MaxLength(150)]
        public string email { get; set; }
        public Nullable<bool> tinhtrangnhansu { get; set; }
        public Nullable<int> thutu { get; set; }
        [MaxLength(50)]
        public string chucvu { get; set; }
        [MaxLength(50)]
        public string capbac { get; set; }
        [MaxLength(50)]
        public string thetu_id { get; set; }
        public Nullable<int> type { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual MKV9998 MKV9998 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Bộ phận"
    /// </summary>
    [Table("MKV9998")]//Bộ phận
    public class MKV9998
    {
        [Key]
        [MaxLength(100)]
        public string phong_id { get; set; }
        [MaxLength(50)]
        public string bophan_ma { get; set; }
        [MaxLength(50)]
        public string bophan_ten { get; set; }
        [MaxLength(50)]
        public string bophan_dienthoai { get; set; }
        [MaxLength(150)]
        public string bophan_diachi { get; set; }
        public Nullable<bool> tinhtrang { get; set; }
        public Nullable<int> thutu { get; set; }
        [MaxLength(100)]
        public string idcha { get; set; }
        [MaxLength(100)]
        public string muc { get; set; }
        public Nullable<int> asoft { get; set; }
        public string congty_id { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<MKV9999> MKV9999 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Phân quyền"
    /// </summary>
    [Table("MKV9980")]//quyền
    public class MKV9980
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MKV9980_ID { get; set; }
        public string TENQUYEN { get; set; }
        public string GHICHU { get; set; }
        public Nullable<bool> TINHTRANG { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<MKV9981> MKV9981 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Hành động", một quyền có nhiều hành động.
    /// </summary>
    [Table("MKV9981")]//HÀNH ĐỘNG
    public class MKV9981
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MKV9981_ID { get; set; }
        public int MKV9980_ID { get; set; }
        public string TENHANHDONG { get; set; }
        public string GHICHU { get; set; }
        public Nullable<bool> TINHTRANG { get; set; }
        public Nullable<int> THUTU { get; set; }

        public string TENMENU { get; set; }
        public string LINKMENU { get; set; }
        public int CAPMENU { get; set; }
        public int IDCHA { get; set; }
        public string IMAGE { get; set; }
        public virtual MKV9980 MKV9980 { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<MKV9982> MKV9982 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Phaan quyeefn", .
    /// </summary>
    [Table("MKV9982")]
    public class MKV9982
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MKV9982_ID { get; set; }
        public int MKV9981_ID { get; set; }
        public int MKV9983_ID { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual MKV9981 MKV9981 { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual MKV9983 MKV9983 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Nhóm", .
    /// </summary>
    [Table("MKV9983")]
    public class MKV9983
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MKV9983_ID { get; set; }
        public string TENNHOM { get; set; }
        public Nullable<bool> TINHTRANG { get; set; }
    }
    /// <summary>
    /// Đây là bảng "phân nhóm Nhóm", .
    /// </summary>
    [Table("MKV9984")]
    public class MKV9984
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MKV9984_ID { get; set; }
        public int MKV9999_ID { get; set; }
        public int MKV9983_ID { get; set; }
        public string TENNHOM { get; set; }
        public Nullable<bool> TINHTRANG { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual MKV9983 MKV9983 { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual MKV9999 MKV9999 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "cài đặt", .
    /// </summary>
    [Table("MKV8000")]
    public class MKV8000
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MKV8000_ID { get; set; }
        public string ST01 { get; set; }
        public string ST02 { get; set; }
        public string ST03 { get; set; }
        public string ST04 { get; set; }
        public string ST05 { get; set; }
        public string ST06 { get; set; }
        public string ST07 { get; set; }
        public string ST08 { get; set; }
        public string ST09 { get; set; }
        public string ST10 { get; set; }
        public string ST11 { get; set; }
        public string ST12 { get; set; }
        public string ST13 { get; set; }
        public string ST14 { get; set; }
        public string ST15 { get; set; }
        public string ST16 { get; set; }
        public string ST17 { get; set; }
        public string ST18 { get; set; }
    }



}
