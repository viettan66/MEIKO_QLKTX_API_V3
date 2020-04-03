
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

[RoutePrefix("api/Search")]
public class SearchController : ApiController
    {
        [Route("Search")]
        [HttpPost]
        public HttpResponseMessage Get([FromBody]searchkey value)
        {
            using (DB db = new DB())
            {
                var result = timkiem.tim (value);
                return (result.ToHttpResponseMessage());
            }
        }

        //[Route("filterprint")]
        //[HttpPost]
        //public ActionResult<string> Get([FromBody]search value)
        //{
        //    using (DB db = new DB())
        //    {
        //    }
        //}
    }
