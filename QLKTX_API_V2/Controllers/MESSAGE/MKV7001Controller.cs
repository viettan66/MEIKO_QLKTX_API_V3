using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;
using QLKTX_API_V2.Controllers.MESSAGE;

namespace QLKTX_API_V2.Controllers
{
    [RoutePrefix("api/MKV7001")]
    public class MKV7001Controller : ApiController
    {
        [Route("Getall")]
        [HttpPost]
        public HttpResponseMessage Getall([FromBody]MessageManager.filter filter)
        {
            object fd = MessageManager.GetAll(filter);
            return REST.GetHttpResponseMessFromObject(fd);
            //return null;
        }
        [Route("CreateMess")]
        [HttpPost]
        public HttpResponseMessage CreateMess([FromBody]MKV7001 filter)
        {
            object fd = MessageManager.CreateMessage(filter);
            return REST.GetHttpResponseMessFromObject(fd);
            //return null;
        }
        [Route("markread")]
        [HttpPost]
        public HttpResponseMessage markread([FromBody]MessageManager.filter filter)
        {
            using (DB db = new DB())
            {
                var checks = db.MKV7001.Where(p => p.MKV9999_ID == filter.MKV9999_ID2 && p.MKV9999_ID2 == filter.MKV9999_ID);
                if (checks != null)
                {
                    checks.ToList().ForEach(val =>
                    {
                        val.trangthai = true;
                    });
                    db.SaveChanges();
                }
                return REST.GetHttpResponseMessFromObject(new{code="OK" });
            }
        }
    }
}
