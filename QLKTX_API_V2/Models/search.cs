using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

        public class searchkey
        {
            public string key { get; set; }
        }

        public class valuesearch
        {
            public object KTX0020 { get; set; }
            public object KTX0023 { get; set; }
            public object KTX0031 { get; set; }
            //public KTX0031[] KTX0031 { get; set; }
            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
            public  HttpResponseMessage ToHttpResponseMessage()
            {
                return REST.GetHttpResponseMessFromObject(this);
            }
        }
    

