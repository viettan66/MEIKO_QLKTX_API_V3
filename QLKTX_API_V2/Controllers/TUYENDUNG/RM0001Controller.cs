using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.TUYENDUNG
{
    [RoutePrefix("api/RM0001")]
    public class RM0001Controller : ApiController
    {
        [Route("Getall")]
        [HttpGet]
        public HttpResponseMessage Getall()
        {
            using (DB db = new DB())
            {
                var data = db.RM0001.Select(p => new
                {
                    p.ghiChu,
                    p.maCongViec,
                    p.moTa,
                    p.RM0001_ID,
                    p.RM0004_ID,
                    p.tenCongViec,
                    p.thuTu,
                    p.tinhTrang
                });
                return REST.GetHttpResponseMessFromObject(data.ToList());
            }
        }
        [Route("Getid/{id}")]
        [HttpGet]
        public HttpResponseMessage Getid(int id)
        {
            using (DB db = new DB())
            {
                var data = db.RM0001.Where(p=>p.RM0001_ID==id).Select(p => new
                {
                    p.ghiChu,
                    p.maCongViec,
                    p.moTa,
                    p.RM0001_ID,
                    p.RM0004_ID,
                    p.tenCongViec,
                    p.thuTu,
                    p.tinhTrang
                }).FirstOrDefault();
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]RM0001 value)
        {
            using (DB db = new DB())
            {
                result<RM0001> rel = new result<RM0001>();
                db.RM0001.Add(value);
                try
                {
                    db.SaveChanges();
                    rel.set("OK", value, "Thành công");
                }
                catch (Exception l)
                {
                    rel.set("ERR", value, "Thất bại:" + l.Message);
                }
                return rel.ToHttpResponseMessage();
            }
        }
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage update([FromBody]RM0001 value)
        {
            using (DB db = new DB())
            {
                result<RM0001> rel = new result<RM0001>();
                var check = db.RM0001.SingleOrDefault(p=>p.RM0001_ID==value.RM0001_ID);
                if (check != null)
                {
                    check.ghiChu = value.ghiChu;
                    check.maCongViec = value.maCongViec;
                    check.moTa = value.moTa;
                    check.RM0004_ID = value.RM0004_ID;
                    check.tenCongViec = value.tenCongViec;
                    check.thuTu = value.thuTu;
                    check.tinhTrang = value.tinhTrang;
                    try
                    {
                        db.SaveChanges();
                        rel.set("OK", value, "Thành công");
                    }
                    catch (Exception l)
                    {
                        rel.set("ERR", value, "Thất bại:" + l.Message);
                    }

                }
                return rel.ToHttpResponseMessage();
            }
        }
    }
}