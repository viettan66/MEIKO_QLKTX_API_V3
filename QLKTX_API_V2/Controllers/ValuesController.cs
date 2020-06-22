using MEIKO_QLKTX_API_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;

namespace QLKTX_API_V2.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public struct kkkk
        {
            public string url { get; set; }
            public string manhansu { get; set; }
            public DateTime date { get; set; }
        }
        public HttpResponseMessage Post([FromBody]kkkk value)
        {
            using (var db = new DB())
            {
                var id = db.MKV9999.Where(df => df.manhansu == value.manhansu).Select(f => f.id).FirstOrDefault();
                if (id != null)
                {
                    WebClient webC = new WebClient();
                    webC.Encoding = Encoding.UTF8;
                    string f= webC.DownloadString(value.url + id + "/" + value.date.Month + "/" + value.date.Year + "/1");
                    return REST.GetHttpResponseMessFromObject(JsonConvert.DeserializeObject(f));

                }
                else
                {
                    return REST.GetHttpResponseMessFromObject(null);
                }
            }
                
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
