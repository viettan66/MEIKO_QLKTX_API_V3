using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.TUYENDUNG
{
    [RoutePrefix("api/RM0007")]
    public class RM0007Controller : ApiController
    {

        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]RM0007 value)
        {
            using (DB db = new DB())
            {
                result<object> rel = new result<object>();
                var check = db.RM0007.SingleOrDefault(p => p.RM0007_ID == value.RM0007_ID);
                if (check == null)
                {
                    db.RM0007.Add(value);
                    try
                    {
                        db.SaveChanges();
                        rel.set("OK", RM0007Get(new filter() { RM0007_ID = value.RM0007_ID }));
                    }
                    catch (Exception fd)
                    {
                        rel.set("ERR", null, "Thất bại: " + fd.Message);
                    }
                }
                else
                {
                    db.RM0007.Remove(check);
                    try
                    {
                        db.SaveChanges();
                        rel.set("OK", null);
                    }
                    catch (Exception fd)
                    {
                        rel.set("ERR", null, "Thất bại: " + fd.Message);
                    }

                }
                return rel.ToHttpResponseMessage();
            }
        }
        [Route("add2")]
        [HttpPost]
        public HttpResponseMessage add2([FromBody]RM0007 value)
        {
            using (DB db = new DB())
            {
                result<object> rel = new result<object>();
                var check = db.RM0007.SingleOrDefault(p => p.MKV9999_ID == value.MKV9999_ID&&p.RM0006_ID==value.RM0006_ID);
                if (check == null)
                {
                    db.RM0007.Add(value);
                    try
                    {
                        db.SaveChanges();
                        rel.set("OK", RM0007Get(new filter() { RM0007_ID = value.RM0007_ID }));
                    }
                    catch (Exception fd)
                    {
                        rel.set("ERR", null, "Thất bại: " + fd.Message);
                    }
                }
                return rel.ToHttpResponseMessage();
            }
        }
        [Route("Getall")]
        [HttpGet]
        public HttpResponseMessage Getall()
        {
            using (DB db = new DB())
            {
                //var data = db.RM0007.AsEnumerable().Select(p => new
                //{
                //    p.MKV9999_ID,p.RM0006_ID,p.RM0007_ID,p.trangThai,
                //    MKV9999=AccountGett.GetAccount(new AccountGett.filter() { id=p.MKV9999_ID}),
                //    RM0006=db.RM0006.Where(o=>o.RM0006_ID==p.RM0006_ID).Select(o=>new { o.ghiChu, o.maTieuChiDG,o.RM0006_ID,o.tenTieuChiDG,o.thuTu,o.tinhTrang})
                //});
                var data = db.MKV9999.AsEnumerable().Select(p => new
                {
                    p.MKV9999_ID,
                    p.manhansu,
                    p.matkhau,
                    p.id,
                    p.hodem,
                    p.ten,
                    p.type,
                    p.ngaysinh,
                    p.gioitinh,
                    p.noisinh,
                    p.quequan,
                    p.diachithuongtru,
                    p.diachitamtru,
                    p.cmtnd_so,
                    p.cmtnd_ngayhethan,
                    p.cmtnd_noicap,
                    p.hochieu_so,
                    p.hochieu_ngaycap,
                    p.hochieu_ngayhethan,
                    p.ngayvaocongty,
                    p.phong_id,
                    p.ban_id,
                    p.congdoan_id,
                    p.chucvu_id,
                    p.nganhang_stk,
                    p.nganhang_id,
                    p.sosobaohiem,
                    p.honnhantinhtrang,
                    p.datnuoc_id,
                    p.phuongxa,
                    p.suckhoetinhtrang,
                    p.dienthoai_nharieng,
                    p.dienthoai_didong,
                    p.email,
                    p.tinhtrangnhansu,
                    p.thutu,
                    p.chucvu,
                    p.capbac,
                    thetu_id = db.MKV9998.Where(o => p.phong_id == o.phong_id).Select(o => o.bophan_ten).FirstOrDefault(),
                    RM0006 = db.RM0006.Where(w => w.tinhTrang == true).Select(w => new
                    {
                        w.ghiChu,
                        w.maTieuChiDG,
                        w.RM0006_ID,
                        w.tenTieuChiDG,
                        w.thuTu,
                        w.tinhTrang,
                        RM0007 = db.RM0007.Where(q => q.MKV9999_ID == p.MKV9999_ID && q.RM0006_ID == w.RM0006_ID).Select(q => new
                        {
                            q.MKV9999_ID,
                            q.RM0006_ID,
                            q.RM0007_ID,
                            q.trangThai,

                        }).FirstOrDefault(),
                    }),

                }).ToList();
                return REST.GetHttpResponseMessFromObject(data);
            }

        }

        [Route("GetallMKV999ID")]
        [HttpPost]
        public HttpResponseMessage GetallMKV999ID([FromBody]filter filter)
        {
            return REST.GetHttpResponseMessFromObject(RM0007Get(filter));
        }
        public struct filter
        {
            public Nullable<int> MKV9999_ID { get; set; }
            public Nullable<int> RM0007_ID { get; set; }
        }
        public object RM0007Get(filter filter)
        {
            using (DB db = new DB())
            {
                var data = db.RM0007.Select(q => new
                {
                    q.MKV9999_ID,
                    q.RM0006_ID,
                    q.RM0007_ID,
                    q.trangThai,

                });
                if (filter.RM0007_ID != null)
                    return data.Where(q => q.RM0007_ID == filter.RM0007_ID).FirstOrDefault();
                if(filter.MKV9999_ID!=null)
                    return data.Where(q => q.MKV9999_ID == filter.MKV9999_ID).ToList();
                return data.ToList();

            }
        }
    }
}

