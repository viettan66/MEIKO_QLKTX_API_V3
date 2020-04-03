using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.TUYENDUNG
{
    [RoutePrefix("api/RM0003")]
    public class RM0003Controller : ApiController
    {
        [Route("Getall")]
        [HttpGet]
        public HttpResponseMessage Getall()
        {
            using (DB db = new DB())
            {
                var data = db.RM0003.Select(p => new
                {
                    p.ghiChu,
                    p.maBacDaoTao,
                    p.RM0003_ID,
                    p.tenBacDaoTao,
                    p.thuTu,
                    p.tinhTrang
                });
                return REST.GetHttpResponseMessFromObject(data.ToList());
            }
        }
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]RM0003 value)
        {
            using (DB db = new DB())
            {
                result<RM0003> rel = new result<RM0003>();
                db.RM0003.Add(value);
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
