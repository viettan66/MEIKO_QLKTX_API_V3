using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.TUYENDUNG
{
    [RoutePrefix("api/RM0004")]
    public class RM0004Controller : ApiController
    {
        [Route("Getall")]
        [HttpGet]
        public HttpResponseMessage Getall()
        {
            using (DB db = new DB())
            {
                var data = db.RM0004.Select(p => new
                {
                    p.ghiChu,
                    p.maChuyenNganh,
                    p.RM0004_ID,
                    p.RM0002_ID,
                    p.tenChuyenNganh,
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
                var data = db.RM0004.Where(p => p.RM0004_ID == id).Select(p => new
                {
                    p.ghiChu,
                    p.maChuyenNganh,
                    p.RM0004_ID,
                    p.RM0002_ID,
                    p.tenChuyenNganh,
                    p.thuTu,
                    p.tinhTrang
                }).FirstOrDefault();
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage update([FromBody]RM0004 value)
        {
            using (DB db = new DB())
            {
                result<RM0004> rel = new result<RM0004>();
                var check = db.RM0004.SingleOrDefault(p => p.RM0004_ID == value.RM0004_ID);
                if (check != null)
                {
                    check.ghiChu = value.ghiChu;
                    check.maChuyenNganh = value.maChuyenNganh;
                    check.tenChuyenNganh = value.tenChuyenNganh;
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
        [Route("delete")]
        [HttpPut]
        public HttpResponseMessage update([FromBody]RM0004[] values)
        {
            using (DB db = new DB())
            {
                results<RM0004> list = new results<RM0004>();
                values.ToList().ForEach(value =>
                {
                    result<RM0004> rel = new result<RM0004>();
                    var check = db.RM0004.SingleOrDefault(p => p.RM0004_ID == value.RM0004_ID);
                    if (check != null)
                    {
                        db.RM0004.Remove(check);
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
                    else
                        rel.set("NaN", null, "Thành công");
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]RM0004 value)
        {
            using (DB db = new DB())
            {
                result<RM0004> rel = new result<RM0004>();
                db.RM0004.Add(value);
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
    }
}
