using MEIKO_QLKTX_API_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLKTX_API_V2.Controllers.ADMIN
{
    [RoutePrefix("api/MKV9998")]
    public class MKV9998Controller : ApiController
    {
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]MKV9998 values)
        {
            using (DB db = new DB())
            {
                result<MKV9998> rel = new result<MKV9998>();
                {
                    var check = db.MKV9998.SingleOrDefault(p => p.phong_id == values.phong_id);
                    if (check == null)
                    {
                        db.MKV9998.Add(values);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", values, "OK");
                        }
                        catch
                        {
                            rel.set("ERR", values, "NG");
                        }

                    }
                    rel.set("ERR", values, "Đã có");

                }
                return rel.ToHttpResponseMessage();
            }
        }
        [Route("Getall")]
        [HttpPost]
        public HttpResponseMessage Getall(GetMKV9998.filter filter)
        {
            return REST.GetHttpResponseMessFromObject(GetMKV9998.Get(filter));
        }
    }
}
