﻿
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
    /// Đây là bảng "Công việc", .
    /// </summary>
    [Table("RM0001")]
    public class RM0001
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0001_ID { get; set; }
        public Nullable<int> RM0004_ID { get; set; }
        public string maCongViec { get; set; }
        public string tenCongViec { get; set; }
        public string moTa { get; set; }
        public Nullable<int> thuTu { get; set; }
        public Nullable<bool> tinhTrang { get; set; }
        public string ghiChu { get; set; }
        //    public RM0010 :RM0010[]    ;
        //public RM0012 :RM0012[]    ;
    }


    /// <summary>
    /// Đây là bảng "lĩnh vực", .
    /// </summary>
    [Table("RM0002")]
    public class RM0002
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0002_ID { get; set; }
        public string maLinhVuc { get; set; }
        public string tenLinhVuc { get; set; }
        public Nullable<int> thuTu { get; set; }
        public Nullable<bool> tinhTrang { get; set; }
        public string ghiChu { get; set; }
        //public RM0012 :RM0012[]    ;

    }
    /// <summary>
    /// Đây là bảng "bậc đào tạo", .
    /// </summary>
    [Table("RM0003")]
    public class RM0003
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0003_ID { get; set; }
        public string maBacDaoTao { get; set; }
        public string tenBacDaoTao { get; set; }
        public Nullable<int> thuTu { get; set; }
        public Nullable<bool> tinhTrang { get; set; }
        public string ghiChu { get; set; }
        //public RM0012 :RM0012[]    ;

    }
    /// <summary>
    /// Đây là bảng "bậc đào tạo", .
    /// </summary>
    [Table("RM0004")]
    public class RM0004
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0004_ID { get; set; }
        public int RM0002_ID { get; set; }
        public string maChuyenNganh { get; set; }
        public string tenChuyenNganh { get; set; }
        public Nullable<int> thuTu { get; set; }
        public Nullable<bool> tinhTrang { get; set; }
        public string ghiChu { get; set; }
        //public RM0012 :RM0012[]    ;

    }
    /// <summary>
    /// Đây là bảng "ngoại ngữ", .
    /// </summary>
    [Table("RM0005")]
    public class RM0005
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0005_ID { get; set; }
        public string maNgoaiNgu { get; set; }
        public string tenNgoaiNgu { get; set; }
        public Nullable<int> thuTu { get; set; }
        public Nullable<bool> tinhTrang { get; set; }
        public string ghiChu { get; set; }
        // public  RM1205 :RM1205[]    ;

    }

    /// <summary>
    /// Đây là bảng "ngoại ngữ", .
    /// </summary>
    [Table("RM0006")]
    public class RM0006
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0006_ID { get; set; }
        public string maTieuChiDG { get; set; }
        public string tenTieuChiDG { get; set; }
        public Nullable<int> thuTu { get; set; }
        public Nullable<bool> tinhTrang { get; set; }
        public string ghiChu { get; set; }
         public virtual ICollection<RM0013> RM0013 {  get; set; }

    }
    /// <summary>
    /// Đây là bảng "ngoại ngữ", .
    /// </summary>
    [Table("RM0008")]
    public class RM0008
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0008_ID { get; set; }
        public string maDiaDiem { get; set; }
        public string DiaDiem { get; set; }
        public string ghiChu { get; set; }
        // public  RM0013 :RM0013[]    ;

    }
    /// <summary>
    /// Đây là bảng "NGUỒN THÔNG TIN", .
    /// </summary>
    [Table("RM0009")]
    public class RM0009
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0009_ID { get; set; }
        public string maNguonThongTin { get; set; }
        public string tenNguongThongTin { get; set; }
        public string ghiChu { get; set; }
        // public  RM0013 :RM0013[]    ;

    }
    /// <summary>
    /// Đây là bảng "NGUỒN THÔNG TIN", .
    /// </summary>
    [Table("RM0010")]
    public class RM0010
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0010_ID { get; set; }
        public string maID { get; set; }
        public string HODEM { get; set; }
        public string TEN { get; set; }
        public Nullable<System.DateTime> NGAYSINH { get; set; }
        public string NOISINH { get; set; }
        public string CMTND_SO { get; set; }
        public Nullable<System.DateTime> CMTND_NGAYCAP { get; set; }
        public string CMTND_NOICAP { get; set; }
        public Nullable<bool> GIOITINH { get; set; }
        public Nullable<bool> HONNHAN { get; set; }
        public string TELEPHONE { get; set; }
        public string MOBILE { get; set; }
        public Nullable<double> CHIEUCAO { get; set; }
        public Nullable<double> CANNANG { get; set; }
        public string EMAIL { get; set; }
        public string THUONGTRU { get; set; }
        public string TAMTRU { get; set; }
        public int RM0001_ID { get; set; }
        public int RM0001_ID2 { get; set; }
        public Nullable<System.DateTime> NGAYCOTHELAM { get; set; }
        public Nullable<double> THUNHAPMONGMUON { get; set; }
        public Nullable<bool> COTHELAMTHEM { get; set; }
        public Nullable<bool> COTHEDICONGTAC { get; set; }
        public Nullable<bool> COTHETHAYDOIDIADIEM { get; set; }
        public Nullable<bool> DATUNGTHITUYENMEIKO { get; set; }
        public string NEUDATUNGTHITUYENMEIKO { get; set; }
        public Nullable<int> ID_NGUONTHONGTIN { get; set; }
        public string DUDINHTUONGLAI { get; set; }
        public string SOTHICH { get; set; }
        public string KHONGTHICH { get; set; }
        public string CACPHAMCHATKYNANG { get; set; }
        public string HOTENNGUOITHAN { get; set; }
        public string DIACHINGUOITHAN { get; set; }
        public string MOBILENGUOITHAN { get; set; }
        public byte[] ANHCHANDUNG { get; set; }
        public string RM0011_ID1 { get; set; }
        public string RM0011_ID2 { get; set; }
        public Nullable<bool> trangthai { get; set; }
        public string DUDINHHOCTIEPCHUYENNGANH { get; set; }
        public Nullable<bool> DUDINHHOCTIEP { get; set; }
        public string bophanid { get; set; }

        public virtual RM0001 RM0001 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RM0080> RM0080 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RM0081_A> RM0081_A { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RM0081_B> RM0081_B { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RM0081_C> RM0081_C { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RM0081_D> RM0081_D { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RM0081_E> RM0081_E { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RM0081_F> RM0081_F { get; set; }
    }
    /// <summary>
    /// Đây là bảng "NGUỒN THÔNG TIN", .
    /// </summary>
    [Table("RM0080")]
    public class RM0080
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0080_ID { get; set; }
        public int RM0010_ID { get; set; }
        public string QUANHE { get; set; }
        public string HOTEN { get; set; }
        public string LAMGIODAU { get; set; }

        public virtual RM0010 RM0010 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "NGUỒN THÔNG TIN", .
    /// </summary>
    [Table("RM0081_A")]
    public class RM0081_A
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0081_ID { get; set; }
        public Nullable<System.DateTime> BATDAU { get; set; }
        public Nullable<System.DateTime> KETTHUC { get; set; }
        public string CHUYENNGANH { get; set; }
        public string TENTRUONG { get; set; }
        public string QUOCGIA { get; set; }
        public string HEDAOTAO { get; set; }
        public string XEPLOAI { get; set; }
        public Nullable<int> TYPE { get; set; }
        public int RM0010_ID { get; set; }

        public virtual RM0010 RM0010 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "NGUỒN THÔNG TIN", .
    /// </summary>
    [Table("RM0081_B")]
    public class RM0081_B
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0081_ID { get; set; }
        public int RM0010_ID { get; set; }
        public string NGOAINGU { get; set; }
        public string CHUNGCHI { get; set; }
        public string XEPLOAI { get; set; }
        public Nullable<System.DateTime> NGAYCAP { get; set; }
        public string NGHE { get; set; }
        public string NOI { get; set; }
        public string DOC { get; set; }
        public string VIET { get; set; }

        public virtual RM0010 RM0010 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "NGUỒN THÔNG TIN", .
    /// </summary>
    [Table("RM0081_C")]
    public class RM0081_C
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0081_ID { get; set; }
        public int RM0010_ID { get; set; }
        public string TENPHANMEM { get; set; }
        public Nullable<int> TRINHDO { get; set; }

        public virtual RM0010 RM0010 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "NGUỒN THÔNG TIN", .
    /// </summary>
    [Table("RM0081_D")]
    public class RM0081_D
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0081_ID { get; set; }
        public int RM0010_ID { get; set; }
        public string TENGIAITHUONG { get; set; }
        public string RM0002_ID { get; set; }
        public string TOCHUCTRAO { get; set; }
        public Nullable<System.DateTime> NAM { get; set; }

        public virtual RM0010 RM0010 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "NGUỒN THÔNG TIN", .
    /// </summary>
    [Table("RM0081_E")]
    public class RM0081_E
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0081_ID { get; set; }
        public int RM0010_ID { get; set; }
        public Nullable<System.DateTime> BATDAU { get; set; }
        public Nullable<System.DateTime> KETTHUC { get; set; }
        public string QUOCGIA { get; set; }
        public string TINH { get; set; }
        public string VITRI { get; set; }
        public double MUCLUONG { get; set; }
        public string MOTA { get; set; }
        public string LYDONGHIVIEC { get; set; }
        public string TENCONGTY { get; set; }

        public virtual RM0010 RM0010 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "NGUỒN THÔNG TIN", .
    /// </summary>
    [Table("RM0081_F")]
    public class RM0081_F
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0081_ID { get; set; }
        public int RM0010_ID { get; set; }
        public string HOTEN { get; set; }
        public string VITRI { get; set; }
        public string DONVI { get; set; }
        public string MOBILE { get; set; }

        public virtual RM0010 RM0010 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "lịch hẹn", .
    /// </summary>
    [Table("RM0015")]
    public class RM0015
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0015_ID { get; set; }
        public int RM0010_ID { get; set; }
        public int RM0008_ID { get; set; }
        public Nullable<DateTime> thoiGianPhongVan { get; set; }
        public string ghiChu { get; set; }
        public Nullable<bool> trangThai { get; set; }
        public Nullable<bool> ketQua { get; set; }
        public Nullable<int> vongPhongVan { get; set; }
        public virtual ICollection<RM0015A> RM0015A { get; set; }
        public virtual RM0010 RM0010 { get; set; }

    }
    /// <summary>
    /// Đây là bảng "chi tiet lich hen", .
    /// </summary>
    [Table("RM0015A")]
    public class RM0015A
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0015A_ID { get; set; }
        public int RM0015_ID { get; set; }
        public int MKV9999_ID { get; set; }
        public string ghiChu { get; set; }
        public Nullable<bool> trangThai { get; set; }
        public virtual RM0015 RM0015 { get; set; }


    }
    /// <summary>
    /// Đây là bảng "đánh giá", .
    /// </summary>
    [Table("RM0013")]
    public class RM0013
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0013_ID { get; set; }
        public int RM0015_ID { get; set; }
        public int MKV9999_ID { get; set; }
        public int RM0006_ID { get; set; }
        public string nhanXet { get; set; }
        public string ghiChu { get; set; }
        public Nullable<bool> ketQua { get; set; }
        public Nullable<bool> trangThai { get; set; }
        public virtual RM0015 RM0015 { get; set; }
        public virtual RM0006 RM0006 { get; set; }


    }
    /// <summary>
    /// Đây là bảng "Quyền đánh giá", .
    /// </summary>
    [Table("RM0007")]
    public class RM0007
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RM0007_ID { get; set; }
        public int MKV9999_ID { get; set; }
        public int RM0006_ID { get; set; }
        public Nullable<bool> trangThai { get; set; }
        public virtual MKV9999 MKV9999 { get; set; }
        public virtual RM0006 RM0006 { get; set; }


    }
}

