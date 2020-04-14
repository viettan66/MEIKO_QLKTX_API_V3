using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.TUYENDUNG
{
    [RoutePrefix("api/RM0002")]
    public class RM0002Controller : ApiController
    {
        [Route("Getall")]
        [HttpGet]
        public HttpResponseMessage Getall()
        {
            using (DB db = new DB())
            {
                var data = db.RM0002.Select(p => new
                {
                    p.ghiChu,
                    p.maLinhVuc,
                    p.RM0002_ID,
                    p.tenLinhVuc,
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
                var data = db.RM0002.Where(p => p.RM0002_ID == id).Select(p => new
                {
                    p.ghiChu,
                    p.maLinhVuc,
                    p.RM0002_ID,
                    p.tenLinhVuc,
                    p.thuTu,
                    p.tinhTrang
                }).FirstOrDefault();
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage update([FromBody]RM0002 value)
        {
            using (DB db = new DB())
            {
                result<RM0002> rel = new result<RM0002>();
                var check = db.RM0002.SingleOrDefault(p => p.RM0002_ID == value.RM0002_ID);
                if (check != null)
                {
                    check.ghiChu = value.ghiChu;
                    check.maLinhVuc = value.maLinhVuc;
                    check.tenLinhVuc = value.tenLinhVuc;
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
        public HttpResponseMessage update([FromBody]RM0002[] values)
        {
            using (DB db = new DB())
            {
                results<RM0002> list = new results<RM0002>();
                values.ToList().ForEach(value =>
                {
                    result<RM0002> rel = new result<RM0002>();
                    var check = db.RM0002.SingleOrDefault(p => p.RM0002_ID == value.RM0002_ID);
                    if (check != null)
                    {
                        db.RM0002.Remove(check);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", value, "Thành công");
                        }
                        catch (Exception l)
                        {
                            rel.set("ERR", value, "Thất bại:" + l.Message);
                        }

                    }else 
                            rel.set("NaN", null, "Thành công");
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]RM0002 value)
        {
            using (DB db = new DB())
            {
                result<RM0002> rel = new result<RM0002>();
                db.RM0002.Add(value);
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
