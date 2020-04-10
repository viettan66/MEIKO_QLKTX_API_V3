using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.TUYENDUNG
{
    [RoutePrefix("api/RM0015")]
    public class RM0015Controller : ApiController
    {
        [Route("Getall")]
        [HttpPost]
        public HttpResponseMessage Getall([FromBody]filter filter)
        {
            object fd = getallRM0015(filter);
            return REST.GetHttpResponseMessFromObject(fd);

        }
        [Route("Getall2/{id}")]
        [HttpGet]
        public HttpResponseMessage Getall2(int id)
        {
            object fd = getallRM0015(new filter() { id=id });
            return REST.GetHttpResponseMessFromObject(fd);

        }
        [Route("Getalldanhgia")]
        [HttpPost]
        public HttpResponseMessage Getalldanhgia([FromBody]filter filter)
        {
            object fd = getallRM0015(filter);
                return REST.GetHttpResponseMessFromObject(fd);
            
        }
        public struct addlichhen
        {
            public DateTime thoigian { get; set; }
            public int diadiem  { get; set; }
            public RM0010[] RM0010 { get; set; }
            public MKV9999[] MKV9999 { get; set; }
        }
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]addlichhen values)
        {
            using (DB db = new DB())
            {
                results<object> list = new results<object>();
                values.RM0010.ToList().ForEach(value =>
                {
                    result<object> rel = new result<object>();
                    var check = db.RM0010.SingleOrDefault(p => p.RM0010_ID == value.RM0010_ID);
                    if (check != null)
                    {
                        RM0015 rm0015 = new RM0015()
                        {
                            RM0010_ID = value.RM0010_ID,
                            thoiGianPhongVan = values.thoigian,
                            trangThai = false,
                            RM0008_ID = values.diadiem,
                            vongPhongVan = db.RM0015.Where(p => p.RM0010_ID == value.RM0010_ID).Count() + 1,
                            ghiChu = "Thời gian tạo lịch hẹn" + DateTime.Now,
                        };
                        db.RM0015.Add(rm0015);
                        try
                        {
                            db.SaveChanges();
                            values.MKV9999.ToList().ForEach(mkv9999 =>
                            {
                                RM0015A temp = new RM0015A()
                                {
                                    MKV9999_ID=mkv9999.MKV9999_ID,
                                    RM0015_ID=rm0015.RM0015_ID,
                                };
                                db.RM0015A.Add(temp) ;
                            });
                            check.trangthai = false;
                            db.SaveChanges();
                            rel.set("OK", getallRM0015(new filter() { id = rm0015.RM0015_ID }),"Thành công.");
                        }catch(Exception tr)
                        {
                            rel.set("ERR", null, "Thất bại: " + tr.Message) ;
                        }
                    }
                    else
                    {
                        rel.set("NaN", null, "Không tìm thấy dữ liệu.");
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }


        [Route("update")]
        [HttpPut]
        public HttpResponseMessage update([FromBody]RM0015 values)
        {
            using (DB db = new DB())
            {
                result<object> rel = new result<object>();
                var check = db.RM0015.SingleOrDefault(p => p.RM0015_ID == values.RM0015_ID);
                if (check != null)
                {
                    check.ghiChu = values.ghiChu;
                    check.ketQua = values.ketQua;
                    check.RM0008_ID = values.RM0008_ID;
                    check.RM0010_ID = values.RM0010_ID;
                    check.thoiGianPhongVan = values.thoiGianPhongVan;
                    check.trangThai = values.trangThai;
                    check.vongPhongVan = values.vongPhongVan;
                    try
                    {
                        db.SaveChanges();
                        db.RM0015A.RemoveRange(check.RM0015A);
                        db.SaveChanges();
                        check.RM0015A = values.RM0015A;
                        db.SaveChanges();
                        rel.set("OK", getallRM0015(new filter() { id = check.RM0015_ID }), "Thành công.");
                    }
                    catch (Exception fd)
                    {
                        rel.set("ERR", null, "Thất bại: " + fd.Message);
                    }
                }
                else
                    rel.set("NaN", null, "Không thấy dữ liệu.");
                return rel.ToHttpResponseMessage();
            }
        }
        [Route("update2")]
        [HttpPost]
        public HttpResponseMessage hoanthanhdanhgia([FromBody]RM0015[] data)
        {
            using (DB db = new DB())
            {
                results<object> list = new results<object>();
                data.ToList().ForEach(values =>
                {
                    result<object> rel = new result<object>();
                    var check = db.RM0015.SingleOrDefault(p => p.RM0015_ID == values.RM0015_ID);
                    if (check != null)
                    {
                        check.ghiChu = values.ghiChu;
                        check.ketQua = values.ketQua;
                        check.RM0008_ID = values.RM0008_ID;
                        check.RM0010_ID = values.RM0010_ID;
                        check.thoiGianPhongVan = values.thoiGianPhongVan;
                        check.trangThai = values.trangThai;
                        check.vongPhongVan = values.vongPhongVan;
                        try
                        {
                            db.SaveChanges();
                            db.RM0015A.RemoveRange(check.RM0015A);
                            db.SaveChanges();
                            check.RM0015A = values.RM0015A;
                            db.SaveChanges();
                            rel.set("OK", getallRM0015(new filter() { id = check.RM0015_ID }), "Thành công.");
                        }
                        catch (Exception fd)
                        {
                            rel.set("ERR", null, "Thất bại: " + fd.Message);
                        }
                    }
                    else
                        rel.set("NaN", null, "Không thấy dữ liệu.");
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
        [Route("delete/{id}")]
        [HttpGet]
        public HttpResponseMessage delete(int id)
        {
            using (DB db = new DB())
            {
                result<object> rel = new result<object>();
                var check = db.RM0015.SingleOrDefault(p => p.RM0015_ID == id);
                if (check != null)
                {
                    db.RM0015.Remove(check);
                    try
                    {
                        db.SaveChanges();
                        var kl = db.RM0010.SingleOrDefault(p => p.RM0010_ID == check.RM0010_ID);
                        if (kl != null)
                        {
                            kl.trangthai = true;
                            db.SaveChanges();
                        }
                        
                        rel.set("OK", null, "Thành công.");
                    }
                    catch (Exception fd)
                    {
                        rel.set("ERR", null, "Thất bại: " + fd.Message);
                    }
                }
                else
                    rel.set("NaN", null, "Không thấy dữ liệu.");
                return rel.ToHttpResponseMessage(); ;
            }
        }
        public struct filter
        {
            public Nullable<int> id { get; set; }
            public Nullable<int> MKV9999_ID { get; set; }
            public string phong_id { get; set; }
            public Nullable<bool> type { get; set; }
            public Nullable<bool> trangthai { get; set; }
        }
    public object getallRM0015(filter filter)
        {
            using(DB db=new DB())
            {
                var data = db.RM0015.AsEnumerable().Select(p => new
                {
                    p.ghiChu,
                    p.ketQua,
                    p.RM0010_ID,
                    p.RM0015_ID,
                    p.RM0008_ID,
                        p.thoiGianPhongVan,
                    ngayPV= p.thoiGianPhongVan!=null?DateTime.Parse(p.thoiGianPhongVan.ToString()).ToString("yyyy-MM-dd"):"",
                    thoiGianPV=p.thoiGianPhongVan!=null?DateTime.Parse(p.thoiGianPhongVan.ToString()).ToString("hh:mm"):"",
                    p.trangThai,
                    p.vongPhongVan,
                    RM0008 = db.RM0008.Where(m => m.RM0008_ID == p.RM0008_ID).Select(m => new { m.DiaDiem, m.ghiChu, m.maDiaDiem, m.RM0008_ID }).FirstOrDefault(),
                    RM0006 = db.RM0006.Where(qq => qq.tinhTrang == true).Select(qq => new
                    {
                        qq.ghiChu,qq.maTieuChiDG,qq.RM0006_ID,qq.tenTieuChiDG,qq.thuTu,qq.tinhTrang,
                        RM0013 = db.RM0013.Where(ww => ww.RM0006_ID == qq.RM0006_ID && ww.RM0015_ID == p.RM0015_ID).Select(ww => new
                        {
                            ww.ghiChu,ww.ketQua,ww.MKV9999_ID,ww.nhanXet,ww.RM0006_ID,ww.RM0013_ID,ww.RM0015_ID,ww.trangThai,
                            MKV9999 = db.MKV9999.Where(ee => ee.MKV9999_ID == ww.MKV9999_ID).Select(ee => new
                            {
                                ee.MKV9999_ID,
                                ee.manhansu,
                                ee.matkhau,
                                ee.id,
                                ee.hodem,
                                ee.ten,
                                ee.type,
                                ee.ngaysinh,
                                ee.gioitinh,
                                ee.noisinh,
                                ee.quequan,
                                ee.diachithuongtru,
                                ee.diachitamtru,
                                ee.cmtnd_so,
                                ee.cmtnd_ngayhethan,
                                ee.cmtnd_noicap,
                                ee.hochieu_so,
                                ee.hochieu_ngaycap,
                                ee.hochieu_ngayhethan,
                                ee.ngayvaocongty,
                                ee.phong_id,
                                ee.ban_id,
                                ee.congdoan_id,
                                ee.chucvu_id,
                                ee.nganhang_stk,
                                ee.nganhang_id,
                                ee.sosobaohiem,
                                ee.honnhantinhtrang,
                                ee.datnuoc_id,
                                ee.phuongxa,
                                ee.suckhoetinhtrang,
                                ee.dienthoai_nharieng,
                                ee.dienthoai_didong,
                                ee.email,
                                ee.tinhtrangnhansu,
                                ee.thutu,
                                ee.chucvu,
                                ee.capbac,
                                thetu_id = db.MKV9998.Where(o => ee.phong_id == o.phong_id).Select(o => o.bophan_ten).FirstOrDefault(),
                            }).FirstOrDefault()
                        }).FirstOrDefault()
                    }).ToList(),
                    RM0015A = db.RM0015A.Where(f => f.RM0015_ID == p.RM0015_ID).Select(f => new
                    {
                        f.ghiChu,
                        f.MKV9999_ID,
                        f.RM0015A_ID,
                        f.RM0015_ID,
                        f.trangThai,
                        MKV9999 = db.MKV9999.Where(g => g.MKV9999_ID == f.MKV9999_ID).Select(g => new
                        {
                            g.MKV9999_ID,
                            g.manhansu,
                            g.matkhau,
                            g.id,
                            g.hodem,
                            g.ten,
                            g.type,
                            g.ngaysinh,
                            g.gioitinh,
                            g.noisinh,
                            g.quequan,
                            g.diachithuongtru,
                            g.diachitamtru,
                            g.cmtnd_so,
                            g.cmtnd_ngayhethan,
                            g.cmtnd_noicap,
                            g.hochieu_so,
                            g.hochieu_ngaycap,
                            g.hochieu_ngayhethan,
                            g.ngayvaocongty,
                            g.phong_id,
                            g.ban_id,
                            g.congdoan_id,
                            g.chucvu_id,
                            g.nganhang_stk,
                            g.nganhang_id,
                            g.sosobaohiem,
                            g.honnhantinhtrang,
                            g.datnuoc_id,
                            g.phuongxa,
                            g.suckhoetinhtrang,
                            g.dienthoai_nharieng,
                            g.dienthoai_didong,
                            g.email,
                            g.tinhtrangnhansu,
                            g.thutu,
                            g.chucvu,
                            g.capbac,
                            thetu_id = db.MKV9998.Where(o => o.phong_id == g.phong_id).Select(o => o.bophan_ten).FirstOrDefault(),
                        }).FirstOrDefault(),
                    }).ToList(),
                    RM0010 = ungvienget.Getallungvien(new ungvienget.filterungvien() { id = p.RM0010_ID }),
                });
                if (filter.id != null)
                {
                    return data.Where(p => p.RM0015_ID == filter.id).FirstOrDefault();
                }
                if (filter.MKV9999_ID != null)
                {
                    data= data.Where(p =>db.RM0015A.Where(j=>j.MKV9999_ID==filter.MKV9999_ID).Select(j=>j.RM0015_ID).Distinct().Contains(p.RM0015_ID )).ToList();
                }
                if (filter.phong_id != null)
                {
                    data= data.Where(p =>db.RM0015A.Where(
                        j=>db.MKV9999.Where(u=>u.phong_id==filter.phong_id).Select(u=>u.MKV9999_ID).Contains( j.MKV9999_ID)
                        ).Select(j=>j.RM0015_ID).Distinct().Contains(p.RM0015_ID )).ToList();
                }
                if (filter.type != null)
                {
                    if (filter.type == true)
                        data = data.Where(p => DateTime.Parse(p.ngayPV).Date <= DateTime.Now.Date).ToList();
                    else data = data.Where(p => DateTime.Parse(p.ngayPV).Date >= DateTime.Now.Date).ToList();
                }
                if (filter.trangthai != null)
                {
                    if (filter.trangthai == true)
                        data = data.Where(p =>p.trangThai==true).ToList();
                    else
                        data = data.Where(p => p.trangThai == false).ToList();
                }
                return data.ToList();
            }
            
        }
    }
}
