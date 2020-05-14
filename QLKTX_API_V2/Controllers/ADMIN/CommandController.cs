using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.ADMIN
{
    [RoutePrefix("api/Command")]
    public class CommandController : ApiController
    {
        public struct y
        {
            public string cmd { get; set; }
        }
        [Route("Run")]
        [HttpPost]
        public HttpResponseMessage Run([FromBody]y values)
        {
            using (DB db = new DB())
            {
                result<object> rel = new result<object>();
                try
                {
                var kl=db.Database.SqlQuery<IQueryable>(values.cmd).ToList();
                    rel.set("OK", kl, "thành công");

                }catch(Exception fd)
                {
                    rel.set("ERR", null, "Thất bại: "+fd.Message);

                }
                return rel.ToHttpResponseMessage();
            }
        }
    }
}
