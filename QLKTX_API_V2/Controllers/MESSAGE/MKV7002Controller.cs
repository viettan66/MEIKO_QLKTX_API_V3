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
    [RoutePrefix("api/MKV7002")]
    public class MKV7002Controller : ApiController
    {
        [Route("Getall")]
        [HttpPost]
        public HttpResponseMessage Getall([FromBody]MessageManager.filter filter)
        {
            object fd = MessageManager.GetAll(filter);
            return REST.GetHttpResponseMessFromObject(fd);
            //return null;
        }
    }
}
