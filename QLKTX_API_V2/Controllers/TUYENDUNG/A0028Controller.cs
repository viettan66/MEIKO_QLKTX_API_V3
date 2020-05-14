using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.TUYENDUNG
{
    [RoutePrefix("api/A0028")]
    public class A0028Controller : ApiController
    {
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]A0028[] values)
        {
            using (DB db = new DB())
            {
                results<A0028> list = new results<A0028>();
                values.ToList().ForEach(value =>
                {
                    result<A0028> rel = new result<A0028>();
                    var check = db.A0028.SingleOrDefault(p => p.A0028_ID == value.A0028_ID);
                    if (check == null)
                    {
                        var c = db.A0028.Select(p => p.sophieu).Max();
                        value.sophieu = (c == null ? 0 : c) + 1;
                        db.A0028.Add(value);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", value);
                        }
                        catch (Exception d)
                        {
                            rel.set("ERR", value, "Thất bại: " + d.Message);

                        }
                    }
                    else
                    {
                        rel.set("EXIST", value, "Lỗi: Đã tồn tại");

                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
        public struct filter
        {
            public string A0028_ID { get; set; }
            public string phongid { get; set; }
        }
        [Route("Getall")]
        [HttpPost]
        public HttpResponseMessage Getall([FromBody]filter filter)
        {
            using (DB db = new DB())
            {
                var data = db.A0028.AsEnumerable().Select(p => new
                {
                    p.sophieu,
                    p.thoigian,
                    p.RM0008_ID,
                    diadiem = db.RM0008.SingleOrDefault(op => op.RM0008_ID == p.RM0008_ID),
                    p.A0028_ID,
                    p.A0002_ID,
                    p.hoVaTen,
                    p.A0016_ID,
                    p.A0022_ID,
                    p.A0032_ID,
                    p.maForm,
                    p.trangThai,
                    p.ngayTao,
                    p.noiDungCongViec,
                    p.daXoa,
                    p.T001C,
                    p.T002C,
                    p.T003C,
                    p.T004C,
                    p.T005C,
                    p.T006C,
                    p.T007C,
                    p.T008C,
                    p.T009C,
                    p.T010C,
                    p.T011C,
                    p.T012C,
                    p.T013C,
                    p.T014C,
                    p.T015C,
                    p.T016C,
                    p.T017C,
                    p.T018C,
                    p.T019C,
                    p.T020C,
                    p.T021C,
                    p.T022C,
                    p.T023C,
                    p.T024C,
                    p.T025C,
                    p.T026C,
                    p.T027C,
                    p.T028C,
                    p.T029C,
                    p.T030C,
                    p.T097C,
                    p.T098C,
                    p.T099C,
                    p.T100C,
                    p.tinhtrang,
                    ok = db.RM0015.Where(f => db.RM0010.Where(g => g.A0028_ID == p.A0028_ID).Select(g => g.RM0010_ID).Contains(f.RM0010_ID) && f.ketQua == true).Count(),
                    wait = db.RM0010.Where(g => g.A0028_ID == p.A0028_ID).Count() - db.RM0015.Where(f => db.RM0010.Where(g => g.A0028_ID == p.A0028_ID).Select(g => g.RM0010_ID).Contains(f.RM0010_ID) && f.ketQua == false).Count(),
                    A0028D = db.A0028D.Where(f => f.A0028_ID == p.A0028_ID).FirstOrDefault(),
                    RM0001 = db.RM0001.Where(f => f.RM0001_ID + "" == p.T005C).Select(f => new { f.ghiChu, f.maCongViec, f.moTa, f.RM0001_ID, f.RM0004_ID, f.tenCongViec, f.thuTu, f.tinhTrang }).FirstOrDefault(),
                    RM0002 = db.RM0002.Where(f => f.RM0002_ID + "" == p.A0028D.C014C).Select(f => new { f.ghiChu, f.maLinhVuc, f.RM0002_ID, f.tenLinhVuc, f.thuTu, f.tinhTrang }).FirstOrDefault(),
                    RM0003 = db.RM0003.Where(f => f.RM0003_ID + "" == p.A0028D.C009C).Select(f => new { f.ghiChu, f.maBacDaoTao, f.RM0003_ID, f.tenBacDaoTao, f.thuTu, f.tinhTrang }).FirstOrDefault(),
                    RM0004 = db.RM0004.Where(f => f.RM0004_ID + "" == p.A0028D.C010C).Select(f => new { f.ghiChu, f.maChuyenNganh, f.RM0002_ID, f.RM0004_ID, f.tenChuyenNganh, f.thuTu, f.tinhTrang }).FirstOrDefault(),
                    RM0010 = db.RM0010.Where(f => f.A0028_ID == p.A0028_ID).Select(f => new
                    {
                        f.RM0010_ID,
                        f.maID,
                        f.HODEM,
                        f.TEN,
                        f.A0028_ID,
                        f.NGAYSINH,
                        f.NOISINH,
                        f.CMTND_SO,
                        f.CMTND_NGAYCAP,
                        f.CMTND_NOICAP,
                        f.GIOITINH,
                        f.HONNHAN,
                        f.TELEPHONE,
                        f.MOBILE,
                        f.CHIEUCAO,
                        f.CANNANG,
                        f.EMAIL,
                        f.THUONGTRU,
                        f.TAMTRU,
                        f.RM0001_ID,
                        f.RM0001_ID2,
                        f.NGAYCOTHELAM,
                        f.THUNHAPMONGMUON,
                        f.COTHELAMTHEM,
                        f.COTHEDICONGTAC,
                        f.COTHETHAYDOIDIADIEM,
                        f.DATUNGTHITUYENMEIKO,
                        f.NEUDATUNGTHITUYENMEIKO,
                        f.ID_NGUONTHONGTIN,
                        f.DUDINHTUONGLAI,
                        f.SOTHICH,
                        f.KHONGTHICH,
                        f.CACPHAMCHATKYNANG,
                        f.HOTENNGUOITHAN,
                        f.DIACHINGUOITHAN,
                        f.MOBILENGUOITHAN,
                        f.ANHCHANDUNG,
                        f.RM0011_ID1,
                        f.RM0011_ID2,
                        f.trangthai,
                        count = db.RM0010.Where(y => y.CMTND_SO == f.CMTND_SO).Count(),
                        f.DUDINHHOCTIEPCHUYENNGANH,
                        f.DUDINHHOCTIEP,
                        f.bophanid,
                        f.ghichu,
                        check = false,
                        isactive = db.RM0015.Where(lk => lk.RM0010_ID == f.RM0010_ID).FirstOrDefault() != null ? true : false,
                        RM0001 = db.RM0001.Where(o => o.RM0001_ID == f.RM0001_ID).Select(da => new
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
                        RM0001_2 = db.RM0001.Where(o => o.RM0001_ID == f.RM0001_ID2).Select(da => new
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
                        RM0080 = db.RM0080.Where(o => o.RM0010_ID == f.RM0010_ID).Select(da => new
                        {
                            da.HOTEN,
                            da.LAMGIODAU,
                            da.QUANHE,
                            da.RM0010_ID,
                            da.RM0080_ID
                        }).ToList(),
                        RM0081_A = db.RM0081_A.Where(o => o.RM0010_ID == f.RM0010_ID).Select(da => new
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
                        }).OrderBy(fk => fk.KETTHUC).ToList(),
                        RM0081_B = db.RM0081_B.Where(o => o.RM0010_ID == f.RM0010_ID).Select(da => new
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
                        RM0081_C = db.RM0081_C.Where(o => o.RM0010_ID == f.RM0010_ID).Select(da => new
                        {
                            da.RM0010_ID,
                            da.RM0081_ID,
                            da.TENPHANMEM,
                            da.TRINHDO,
                        }).ToList(),
                        RM0081_D = db.RM0081_D.Where(o => o.RM0010_ID == f.RM0010_ID).Select(da => new
                        {
                            da.NAM,
                            da.RM0002_ID,
                            da.RM0010_ID,
                            da.RM0081_ID,
                            da.TENGIAITHUONG,
                            da.TOCHUCTRAO,
                        }).ToList(),
                        RM0081_E = db.RM0081_E.Where(o => o.RM0010_ID == f.RM0010_ID).Select(da => new
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
                        RM0081_F = db.RM0081_F.Where(o => o.RM0010_ID == f.RM0010_ID).Select(da => new
                        {
                            da.DONVI,
                            da.HOTEN,
                            da.MOBILE,
                            da.RM0010_ID,
                            da.RM0081_ID,
                            da.VITRI,
                        }),
                    }),
                }) ;
                if (filter.A0028_ID != null)
                {
                    return REST.GetHttpResponseMessFromObject(data.SingleOrDefault(p => p.A0028_ID == filter.A0028_ID));
                }
                if (filter.phongid != null)
                {
                    data = data.Where(p => p.T098C == filter.phongid);
                }
                return REST.GetHttpResponseMessFromObject(data.OrderBy(p => p.sophieu));
            }
        }
        [Route("hoanthanhdanhgia")]
        [HttpPost]
        public HttpResponseMessage hoanthanhdanhgia([FromBody]A0028[] values)
        {
            using (DB db = new DB())
            {
                values.ToList().ForEach(value =>
                {
                    var check = db.A0028.SingleOrDefault(p => p.A0028_ID == value.A0028_ID);
                    if (check != null)
                    {
                        check.trangThai = value.trangThai;
                    }
                });
                try
                {
                    db.SaveChanges();
                    return REST.GetHttpResponseMessFromObject(1);
                }
                catch
                {

                    return REST.GetHttpResponseMessFromObject(-1);
                }
            }
        }

        [Route("updatethoidiandiadiem")]
        [HttpPost]
        public HttpResponseMessage updatethoidiandiadiem([FromBody]A0028 value)
        {
            using (DB db = new DB())
            {
                result<Exception> rel = new result<Exception>();
                var check = db.A0028.SingleOrDefault(p => p.A0028_ID == value.A0028_ID);
                if (check != null)
                {
                    check.thoigian = value.thoigian;
                    check.RM0008_ID = value.RM0008_ID;
                }
                try
                {
                    db.SaveChanges();
                    rel.set("OK",null, "");
                }
                catch (Exception j)
                {
                    rel.set("ERR", j, "");
                }
                return rel.ToHttpResponseMessage();
            }
        }
        [Route("updatenguoiphongvan")]
        [HttpPost]
        public HttpResponseMessage updatenguoiphongvan([FromBody]A0028E[] value)
        {
            using (DB db = new DB())
            {
                results<Exception> list = new results<Exception>();
                value.ToList().ForEach(val =>
                {
                result<Exception> rel = new result<Exception>();
                    var check = db.A0028E.Where(p => p.A0028_ID == val.A0028_ID&&p.MKV9999_ID==val.MKV9999_ID);
                    if (check == null)
                    {
                        db.A0028E.Add(new A0028E() { A0028E_ID=val.A0028E_ID,MKV9999_ID=val.MKV9999_ID});
                    }
                    try
                    {
                        db.SaveChanges();
                        rel.set("OK", null);
                    }
                    catch (Exception j)
                    {
                        rel.set("OK", j);
                    }
                    list.add(rel);
                });
                
                return list.ToHttpResponseMessage();
            }
        }
        [Route("getnguoiphongvan/{id}")]
        [HttpGet]
        public HttpResponseMessage getnguoiphongvan(string id)
        {
            using (DB db = new DB())
            {
                var data = db.A0028E.AsEnumerable().Where(p => p.A0028_ID == id).Select(p => new
                {
                    p.A0028E_ID,
                    p.A0028_ID,p.MKV9999_ID,
                    MKV9999=AccountGett.GetAccount(new AccountGett.filter() { id=p.MKV9999_ID})
                });
                
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
    }
}

