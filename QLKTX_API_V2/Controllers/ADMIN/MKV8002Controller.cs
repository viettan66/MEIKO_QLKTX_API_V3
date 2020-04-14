using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.QLKTX
{
    [RoutePrefix("api/MKV8002")]
    public class MKV8002Controller : ApiController
    {
        public struct filter
        {
            public Nullable<int> type { get; set; }
            public Nullable<bool> trangthai { get; set; }
        }
        [Route("Getall")]
        [HttpPost]
        public HttpResponseMessage Getall([FromBody]filter filter)
        {
            using (DB db = new DB())
            {
                var data = from k in db.MKV8002 select k;
                if (filter.type != null) data = data.Where(p => p.type == filter.type);
                if (filter.trangthai != null) data = data.Where(p => p.trangthai == filter.trangthai);
                return REST.GetHttpResponseMessFromObject(data.ToList());
            }
        }
        [Route("delete")]
        [HttpPut]
        public HttpResponseMessage delete([FromBody]MKV8002[] values)
        {
            using (DB db = new DB())
            {
                results<MKV8002> list = new results<MKV8002>();
                values.ToList().ForEach(value =>
                {
                    result<MKV8002> rel = new result<MKV8002>();
                    var check = db.MKV8002.SingleOrDefault(p => p.MKV8002_ID == value.MKV8002_ID);
                    if (check != null)
                    {
                        db.MKV8002.Remove(check);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", value, "Thành công");
                        }
                        catch (Exception l)
                        {
                            rel.set("ERR", value, "Thất bại:" + l.Message);
                        }

                    }
                    else
                        rel.set("NaN", null, "Thành công");
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage update([FromBody]MKV8002 value)
        {
            using (DB db = new DB())
            {
                result<MKV8002> rel = new result<MKV8002>();
                var check = db.MKV8002.SingleOrDefault(p => p.MKV8002_ID == value.MKV8002_ID);
                if (check != null)
                {
                    check.ghiChu = value.ghiChu;
                    check.ten = value.ten;
                    check.ip = value.ip;
                    check.port = value.port;
                    check.commkey = value.commkey;
                    check.trangthai = value.trangthai;
                    check.thutu = value.thutu;
                    try
                    {
                        db.SaveChanges();
                        rel.set("OK", value, "Thành công");
                    }
                    catch (Exception l)
                    {
                        rel.set("ERR", value, "Thất bại:" + l.Message);
                    }

                }
                return rel.ToHttpResponseMessage();
            }
        }
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]MKV8002 values)
        {
            using (DB db = new DB())
            {
                result<MKV8002> list = new result<MKV8002>();
                db.MKV8002.Add(values);
                try
                {
                    db.SaveChanges();
                    list.set("OK", values, "");
                }catch(Exception ef)
                {
                    list.set("ERR", values, ef.Message);

                }
                return list.ToHttpResponseMessage();
            }
        }
    }
}
