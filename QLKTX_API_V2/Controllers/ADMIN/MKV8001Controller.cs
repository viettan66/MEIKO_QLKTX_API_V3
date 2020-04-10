using MEIKO_QLKTX_API_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLKTX_API_V2.Controllers.ADMIN
{
    [RoutePrefix("api/MKV8001")]
    public class MKV8001Controller : ApiController
    {
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]MKV8001 value)
        {
            using (DB db = new DB())
            {
                result<MKV8001> rel = new result<MKV8001>();
                db.MKV8001.Add(value);
                try
                {
                    db.SaveChanges();
                    rel.set("OK", value, "Thành công");
                }
                catch (Exception rr)
                {

                    rel.set("ERR", value, "Thất bại: " + rr.Message);
                }
                return rel.ToHttpResponseMessage();
            }
        }
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage update([FromBody]MKV8001 value)
        {
            using (DB db = new DB())
            {
                result<MKV8001> rel = new result<MKV8001>();
                var check = db.MKV9999.Where(p => p.manhansu == value.taikhoan||p.cmtnd_so==value.cmnd).FirstOrDefault();
                if (check != null)
                {
                    check.matkhau = "123456";
                    try
                    {
                        db.SaveChanges();
                        var k = db.MKV8001.SingleOrDefault(p=>p.MKV8001_ID==value.MKV8001_ID);
                        if (k != null) k.trangthai = true;
                        db.SaveChanges();
                        rel.set("OK", value, "Thành công");
                    }
                    catch (Exception rr)
                    {

                        rel.set("ERR", value, "Thất bại: " + rr.Message);
                    }

                }
                return rel.ToHttpResponseMessage();
            }
        }
        [Route("Get/{type}")]
        [HttpGet]
        public HttpResponseMessage Get(Nullable< bool > type)
        {
            using (DB db = new DB())
            {
                var data= db.MKV8001.Select(p => new
                {
                    p.cmnd,p.MKV8001_ID,p.sdt,p.taikhoan,p.trangthai
                });
                if (type != null) data = data.Where(p => p.trangthai == type);
                return REST.GetHttpResponseMessFromObject(data.ToList());
            }
        }
    }
}
