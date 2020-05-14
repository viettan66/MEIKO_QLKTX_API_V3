using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.TUYENDUNG
{
    public static class ungvienget
    {
        public struct filterungvien
        {
            public Nullable<int> id { get; set; }
            public string[] cmtnd { get; set; }
            public string[] sdt { get; set; }
            public string[] email { get; set; }
            public Nullable<bool> type { get; set; }
            public Nullable<bool> emty { get; set; }
            public string A0028_ID { get; set; }
        }
        public static object Getallungvien(filterungvien filter)
        {
            using (DB db = new DB())
            {
                var data = db.RM0010.Select(p => new
                {
                    p.RM0010_ID,
                    p.maID,
                    p.HODEM,
                    p.TEN,
                    p.sophieu,
                    p.A0028_ID,
                    p.NGAYSINH,
                    p.NOISINH,
                    p.CMTND_SO,
                    p.CMTND_NGAYCAP,
                    p.CMTND_NOICAP,
                    p.GIOITINH,
                    p.HONNHAN,
                    p.TELEPHONE,
                    p.MOBILE,
                    p.CHIEUCAO,
                    p.CANNANG,
                    p.EMAIL,
                    p.THUONGTRU,
                    p.TAMTRU,
                    p.RM0001_ID,
                    p.RM0001_ID2,
                    p.NGAYCOTHELAM,
                    p.THUNHAPMONGMUON,
                    p.COTHELAMTHEM,
                    p.COTHEDICONGTAC,
                    p.COTHETHAYDOIDIADIEM,
                    p.DATUNGTHITUYENMEIKO,
                    p.NEUDATUNGTHITUYENMEIKO,
                    p.ID_NGUONTHONGTIN,
                    p.DUDINHTUONGLAI,
                    p.SOTHICH,
                    p.KHONGTHICH,
                    p.CACPHAMCHATKYNANG,
                    p.HOTENNGUOITHAN,
                    p.DIACHINGUOITHAN,
                    p.MOBILENGUOITHAN,
                    p.ANHCHANDUNG,
                    p.RM0011_ID1,
                    p.RM0011_ID2,
                    p.trangthai,
                    count = db.RM0010.Where(f=>f.CMTND_SO==p.CMTND_SO).Count(),
                    p.DUDINHHOCTIEPCHUYENNGANH,
                    p.DUDINHHOCTIEP,
                    p.bophanid,
                    p.ghichu,
                    RM0001 = db.RM0001.Where(o => o.RM0001_ID == p.RM0001_ID).Select(da => new
                    {
                        da.ghiChu,
                        da.maCongViec,
                        da.moTa,
                        da.RM0001_ID,
                        da.RM0004_ID,
                        da.tenCongViec,
                        da.thuTu,
                        da.tinhTrang
                    }).FirstOrDefault(),
                    RM0001_2 = db.RM0001.Where(o => o.RM0001_ID == p.RM0001_ID2).Select(da => new
                    {
                        da.ghiChu,
                        da.maCongViec,
                        da.moTa,
                        da.RM0001_ID,
                        da.RM0004_ID,
                        da.tenCongViec,
                        da.thuTu,
                        da.tinhTrang
                    }).FirstOrDefault(),
                    RM0080 = db.RM0080.Where(o => o.RM0010_ID == p.RM0010_ID).Select(da => new
                    {
                        da.HOTEN,
                        da.LAMGIODAU,
                        da.QUANHE,
                        da.RM0010_ID,
                        da.RM0080_ID
                    }).ToList(),
                    RM0081_A = db.RM0081_A.Where(o => o.RM0010_ID == p.RM0010_ID).Select(da => new
                    {
                        da.BATDAU,
                        da.CHUYENNGANH,
                        da.HEDAOTAO,
                        da.RM0010_ID,
                        da.KETTHUC,
                        da.QUOCGIA,
                        da.RM0081_ID,
                        da.TENTRUONG,
                        da.TYPE,
                        da.XEPLOAI,
                    }).OrderBy(fk=>fk.KETTHUC) .ToList(),
                    RM0081_B = db.RM0081_B.Where(o => o.RM0010_ID == p.RM0010_ID).Select(da => new
                    {
                        da.CHUNGCHI,
                        da.DOC,
                        da.NGAYCAP,
                        da.NGHE,
                        da.NGOAINGU,
                        da.NOI,
                        da.RM0010_ID,
                        da.RM0081_ID,
                        da.VIET,
                        da.XEPLOAI,
                    }).ToList(),
                    RM0081_C = db.RM0081_C.Where(o => o.RM0010_ID == p.RM0010_ID).Select(da => new
                    {
                        da.RM0010_ID,
                        da.RM0081_ID,
                        da.TENPHANMEM,
                        da.TRINHDO,
                    }).ToList(),
                    RM0081_D = db.RM0081_D.Where(o => o.RM0010_ID == p.RM0010_ID).Select(da => new
                    {
                        da.NAM,
                        da.RM0002_ID,
                        da.RM0010_ID,
                        da.RM0081_ID,
                        da.TENGIAITHUONG,
                        da.TOCHUCTRAO,
                    }).ToList(),
                    RM0081_E = db.RM0081_E.Where(o => o.RM0010_ID == p.RM0010_ID).Select(da => new
                    {
                        da.BATDAU,
                        da.KETTHUC,
                        da.LYDONGHIVIEC,
                        da.MOTA,
                        da.MUCLUONG,
                        da.QUOCGIA,
                        da.RM0010_ID,
                        da.RM0081_ID,
                        da.TENCONGTY,
                        da.TINH,
                        da.VITRI,
                    }).ToList(),
                    RM0081_F = db.RM0081_F.Where(o => o.RM0010_ID == p.RM0010_ID).Select(da => new
                    {
                        da.DONVI,
                        da.HOTEN,
                        da.MOBILE,
                        da.RM0010_ID,
                        da.RM0081_ID,
                        da.VITRI,
                    }),
                });
                if (filter.id != null)
                {
                    data = data.Where(p => p.RM0010_ID == filter.id);
                    return data.FirstOrDefault();
                }
                if (filter.emty != null)
                {
                    if (filter.emty == true)
                        data = data.Where(p => p.A0028_ID == null);
                    if (filter.emty == false)
                        data = data.Where(p => p.A0028_ID != null);
                }
                if (filter.type != null)
                {
                    if(filter.type==true)
                        data = data.Where(p => p.trangthai == filter.type ||  p.trangthai == null );
                    if(filter.type==false)
                        data = data.Where(p => p.trangthai == false);
                    
                }
                if (filter.cmtnd != null)
                {
                    data = data.Where(p => filter.cmtnd.Contains( p.CMTND_SO ));
                  
                }
                if (filter.sdt != null)
                {
                    data = data.Where(p => filter.sdt.Contains( p.MOBILE ));
                  
                }
                if (filter.email != null)
                {
                    data = data.Where(p => filter.email.Contains( p.EMAIL ));
                  
                }
                if (filter.A0028_ID != null)
                {
                    data = data.Where(p =>  p.A0028_ID==filter.A0028_ID);
                  
                }
                    return data.ToList();
            }
        }
        public static bool updateungvien(RM0010 value)
        {
            using (DB db = new DB())
            {
                result<object> rel = new result<object>();
                var check = db.RM0010.SingleOrDefault(p => p.RM0010_ID == value.RM0010_ID);
                if (check != null)
                {
                    check.maID = value.maID;
                    check.HODEM = value.HODEM;
                    check.TEN = value.TEN;
                    check.NGAYSINH = value.NGAYSINH;
                    check.NOISINH = value.NOISINH;
                    check.CMTND_SO = value.CMTND_SO;
                    check.CMTND_NGAYCAP = value.CMTND_NGAYCAP;
                    check.CMTND_NOICAP = value.CMTND_NOICAP;
                    check.GIOITINH = value.GIOITINH;
                    check.HONNHAN = value.HONNHAN;
                    check.TELEPHONE = value.TELEPHONE;
                    check.MOBILE = value.MOBILE;
                    check.CHIEUCAO = value.CHIEUCAO;
                    check.CANNANG = value.CANNANG;
                    check.EMAIL = value.EMAIL;
                    check.THUONGTRU = value.THUONGTRU;
                    check.TAMTRU = value.TAMTRU;
                    check.RM0001_ID = value.RM0001_ID;
                    check.RM0001_ID2 = value.RM0001_ID2;
                    check.NGAYCOTHELAM = value.NGAYCOTHELAM;
                    check.THUNHAPMONGMUON = value.THUNHAPMONGMUON;
                    check.COTHELAMTHEM = value.COTHELAMTHEM;
                    check.COTHEDICONGTAC = value.COTHEDICONGTAC;
                    check.COTHETHAYDOIDIADIEM = value.COTHETHAYDOIDIADIEM;
                    check.DATUNGTHITUYENMEIKO = value.DATUNGTHITUYENMEIKO;
                    check.NEUDATUNGTHITUYENMEIKO = value.NEUDATUNGTHITUYENMEIKO;
                    check.ID_NGUONTHONGTIN = value.ID_NGUONTHONGTIN;
                    check.DUDINHTUONGLAI = value.DUDINHTUONGLAI;
                    check.SOTHICH = value.SOTHICH;
                    check.KHONGTHICH = value.KHONGTHICH;
                    check.CACPHAMCHATKYNANG = value.CACPHAMCHATKYNANG;
                    check.HOTENNGUOITHAN = value.HOTENNGUOITHAN;
                    check.DIACHINGUOITHAN = value.DIACHINGUOITHAN;
                    check.MOBILENGUOITHAN = value.MOBILENGUOITHAN;
                    check.ANHCHANDUNG = value.ANHCHANDUNG;
                    check.RM0011_ID1 = value.RM0011_ID1;
                    check.RM0011_ID2 = value.RM0011_ID2;
                    check.trangthai = value.trangthai;
                    check.DUDINHHOCTIEPCHUYENNGANH = value.DUDINHHOCTIEPCHUYENNGANH;
                    check.DUDINHHOCTIEP = value.DUDINHHOCTIEP;
                    check.bophanid = value.bophanid;
                    check.A0028_ID = value.A0028_ID;
                    check.ghichu = value.ghichu;
                    if (value.sophieu != null)
                    {
                        check.A0028_ID = db.A0028.Where(p => p.sophieu == value.sophieu).Select(p => p.A0028_ID).FirstOrDefault();
                        check.bophanid = db.A0028.Where(p => p.sophieu == value.sophieu).Select(p => p.T098C).FirstOrDefault();
                        //check.RM0001_ID =int.Parse( db.A0028.Where(p => p.sophieu == value.sophieu).Select(p => p.T005C).FirstOrDefault());
                    }
                    if (value.A0028_ID != null)
                    {
                        check.RM0001_ID =int.Parse( db.A0028.Where(p => p.A0028_ID == value.A0028_ID).Select(p => p.T005C).FirstOrDefault());
                    }
                    try
                    {
                        db.SaveChanges();

                        db.RM0081_A.RemoveRange(check.RM0081_A);
                        db.RM0081_B.RemoveRange(check.RM0081_B);
                        db.RM0081_C.RemoveRange(check.RM0081_C);
                        db.RM0081_D.RemoveRange(check.RM0081_D);
                        db.RM0081_E.RemoveRange(check.RM0081_E);
                        db.RM0081_F.RemoveRange(check.RM0081_F);
                        db.RM0080.RemoveRange(check.RM0080);
                        db.SaveChanges();
                        check.RM0080 = value.RM0080;
                        check.RM0081_A = value.RM0081_A;
                        check.RM0081_B = value.RM0081_B;
                        check.RM0081_C = value.RM0081_C;
                        check.RM0081_D = value.RM0081_D;
                        check.RM0081_E = value.RM0081_E;
                        check.RM0081_F = value.RM0081_F;
                        db.SaveChanges();
                        return true;
                        rel.set("OK", ungvienget.Getallungvien(new ungvienget.filterungvien() { id = value.RM0010_ID }), "Thành công");
                    }
                    catch (Exception l)
                    {

                        return false;
                        rel.set("ERR", null, "Thất bại:" + l.Message);
                    }
                }
                else
                {
                    return false;
                    rel.set("NaN", null, "Không tìm thấy dữ liệu.");
                }
                return false;
               // return rel.ToHttpResponseMessage();

            }

        }
    }
}