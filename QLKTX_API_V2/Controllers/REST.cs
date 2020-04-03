using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http.Headers;

    public static class REST
    {
        public const string NaN = "Không tìm thấy dữ liệu";
        public const string OK = "Thành công.";
        public static string ERR = "Thất bại: ";
        public enum code { NaN, OK, ERR }
        public static HttpResponseMessage GetHttpResponseMessFromObject(object obj)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(obj));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }
        public static HttpResponseMessage HttpResponseMessage(object obj)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore }));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }
        public static HttpResponseMessage HttpResponseMessage(string obj,bool check=false)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent((obj));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }
        public static string ToString(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
        }
    }
