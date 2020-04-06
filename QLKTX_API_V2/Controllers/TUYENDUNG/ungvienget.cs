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
            public Nullable<bool> type { get; set; }
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
                    p.DUDINHHOCTIEPCHUYENNGANH,
                    p.DUDINHHOCTIEP,
                    p.bophanid,
                    RM0001 = db.RM0001.Where(o => o.RM0001_ID == p.RM0001_ID).Select(da => new {
                        da.ghiChu,
                        da.maCongViec,
                        da.moTa,
                        da.RM0001_ID,
                        da.RM0004_ID,
                        da.tenCongViec,
                        da.thuTu,
                        da.tinhTrang
                    }).FirstOrDefault(),
                    RM0001_2 = db.RM0001.Where(o => o.RM0001_ID == p.RM0001_ID2).Select(da => new {
                        da.ghiChu,
                        da.maCongViec,
                        da.moTa,
                        da.RM0001_ID,
                        da.RM0004_ID,
                        da.tenCongViec,
                        da.thuTu,
                        da.tinhTrang
                    }).FirstOrDefault(),
                    RM0080 = db.RM0080.Where(o => o.RM0010_ID == p.RM0010_ID).Select(da => new {
                        da.HOTEN,
                        da.LAMGIODAU,
                        da.QUANHE,
                        da.RM0010_ID,
                        da.RM0080_ID
                    }).ToList(),
                    RM0081_A = db.RM0081_A.Where(o => o.RM0010_ID == p.RM0010_ID).Select(da => new {
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
                    }).ToList(),
                    RM0081_B = db.RM0081_B.Where(o => o.RM0010_ID == p.RM0010_ID).Select(da => new {
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
                    RM0081_C = db.RM0081_C.Where(o => o.RM0010_ID == p.RM0010_ID).Select(da => new {
                        da.RM0010_ID,
                        da.RM0081_ID,
                        da.TENPHANMEM,
                        da.TRINHDO,
                    }).ToList(),
                    RM0081_D = db.RM0081_D.Where(o => o.RM0010_ID == p.RM0010_ID).Select(da => new {
                        da.NAM,
                        da.RM0002_ID,
                        da.RM0010_ID,
                        da.RM0081_ID,
                        da.TENGIAITHUONG,
                        da.TOCHUCTRAO,
                    }).ToList(),
                    RM0081_E = db.RM0081_E.Where(o => o.RM0010_ID == p.RM0010_ID).Select(da => new {
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
                    RM0081_F = db.RM0081_F.Where(o => o.RM0010_ID == p.RM0010_ID).Select(da => new {
                        da.DONVI,
                        da.HOTEN,
                        da.MOBILE,
                        da.RM0010_ID,
                        da.RM0081_ID,
                        da.VITRI,
                    }).ToList(),
                });
                if (filter.id != null)
                {
                    data = data.Where(p => p.RM0010_ID == filter.id);
                    return data.FirstOrDefault();
                }
                if (filter.type != null)
                {
                    data = data.Where(p => p.trangthai ==filter.type);
                    return data.ToList();
                }
                else
                    return data.ToList();
            }
        }
    }
}