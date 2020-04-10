using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.TUYENDUNG
{
    [RoutePrefix("api/RM0008")]
    public class RM0008Controller : ApiController
    {
        [Route("Getall")]
        [HttpGet]
        public HttpResponseMessage Getall()
        {
            using (DB db = new DB())
            {
                var data = db.RM0008.Select(p => new
                {
                    p.ghiChu,
                    p.maDiaDiem,
                    p.RM0008_ID,
                    p.DiaDiem,
                });
                return REST.GetHttpResponseMessFromObject(data.ToList());
            }
        }
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage update([FromBody]RM0008 value)
        {
            using (DB db = new DB())
            {
                result<RM0008> rel = new result<RM0008>();
                var check = db.RM0008.SingleOrDefault(p => p.RM0008_ID == value.RM0008_ID);
                if (check != null)
                {
                    check.ghiChu = value.ghiChu;
                    check.maDiaDiem = value.maDiaDiem;
                    check.DiaDiem = value.DiaDiem;
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
        public HttpResponseMessage update([FromBody]RM0008[] values)
        {
            using (DB db = new DB())
            {
                results<RM0008> list = new results<RM0008>();
                values.ToList().ForEach(value =>
                {
                    result<RM0008> rel = new result<RM0008>();
                    var check = db.RM0008.SingleOrDefault(p => p.RM0008_ID == value.RM0008_ID);
                    if (check != null)
                    {
                        db.RM0008.Remove(check);
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
        public HttpResponseMessage add([FromBody]RM0008 value)
        {
            using (DB db = new DB())
            {
                result<RM0008> rel = new result<RM0008>();
                db.RM0008.Add(value);
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
