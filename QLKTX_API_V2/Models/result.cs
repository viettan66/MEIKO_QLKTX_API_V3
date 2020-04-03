
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;


public class result<T>
    {
        public string code { get; set; }
        public string mess { get; set; }
        public T data { get; set; }
        public void set(string code,T data,string mess="" )
        {
            this.code = code;
            this.mess = mess;
            this.data = data;
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
        }

    public HttpResponseMessage ToHttpResponseMessage()
    {
        return REST.GetHttpResponseMessFromObject(this);
    }
}
    public class results<T>
    {
        List<result<T>> list = new List<result<T>>();
        public void add(result< T> ressult)
        {
            list.Add(ressult);
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(list, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
        }
        public  HttpResponseMessage ToHttpResponseMessage()
        {
            return REST.GetHttpResponseMessFromObject(list);
        }
    }

