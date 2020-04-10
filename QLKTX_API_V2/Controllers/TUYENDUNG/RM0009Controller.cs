using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.TUYENDUNG
{
    [RoutePrefix("api/RM0009")]
    public class RM0009Controller : ApiController
    {
        [Route("Getall")]
        [HttpGet]
        public HttpResponseMessage Getall()
        {
            using (DB db = new DB())
            {
                var data = db.RM0009.Select(p => new
                {
                    p.ghiChu,
                    p.maNguonThongTin,
                    p.RM0009_ID,
                    p.tenNguongThongTin,
                });
                return REST.GetHttpResponseMessFromObject(data.ToList());
            }
        }
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage update([FromBody]RM0009 value)
        {
            using (DB db = new DB())
            {
                result<RM0009> rel = new result<RM0009>();
                var check = db.RM0009.SingleOrDefault(p => p.RM0009_ID == value.RM0009_ID);
                if (check != null)
                {
                    check.ghiChu = value.ghiChu;
                    check.maNguonThongTin = value.maNguonThongTin;
                    check.tenNguongThongTin = value.tenNguongThongTin;
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
        public HttpResponseMessage update([FromBody]RM0009[] values)
        {
            using (DB db = new DB())
            {
                results<RM0009> list = new results<RM0009>();
                values.ToList().ForEach(value =>
                {
                    result<RM0009> rel = new result<RM0009>();
                    var check = db.RM0009.SingleOrDefault(p => p.RM0009_ID == value.RM0009_ID);
                    if (check != null)
                    {
                        db.RM0009.Remove(check);
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
        public HttpResponseMessage add([FromBody]RM0009 value)
        {
            using (DB db = new DB())
            {
                result<RM0009> rel = new result<RM0009>();
                db.RM0009.Add(value);
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
