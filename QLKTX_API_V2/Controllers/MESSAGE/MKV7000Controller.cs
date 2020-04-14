using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers
{
    [RoutePrefix("api/MKV7000")]
    public class MKV7000Controller : ApiController
    {
        [Route("Getall")]
        [HttpPost]
        public HttpResponseMessage Getall()
        {
            //object fd = getallRM0015(filter);
            //return REST.GetHttpResponseMessFromObject(fd);
            return null;
        }
    }
}
