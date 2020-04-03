using MEIKO_QLKTX_API_V1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLKTX_API_V2.Controllers.QLKTX
{
    [RoutePrefix("api/KTX0011")]
    public class KTX0011Controller : ApiController
    {
        [Route("add/{id}")]
        [HttpPost]
        public HttpResponseMessage add(int id, [FromBody]KTX0010[] values)
        {
            using (DB db = new DB())
            {
                results<KTX0011> list = new results<KTX0011>();
                foreach (var value in values)
                {
                    result<KTX0011> rel = new result<KTX0011>();
                    var check = db.KTX0011.SingleOrDefault(p => p.KTX0010_ID == value.KTX0010_ID && p.KTX0001_ID == id);
                    if (check != null)
                    {
                        check.ghichu = value.ghichu;
                        check.soluong = value.soluongmacdinh;
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", check, "Thành công: ");
                        }
                        catch (Exception d)
                        {
                            rel.set("ERR", check, "Thất bại: " + d.Message);
                        }
                    }
                    else
                    {
                        var kkkk = new KTX0011() { ghichu = value.ghichu, KTX0001_ID = id, KTX0010_ID = value.KTX0010_ID, soluong = value.soluongmacdinh };
                        db.KTX0011.Add(kkkk);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", kkkk, "Thành công: ");
                        }
                        catch (Exception d)
                        {
                            rel.set("ERR", kkkk, "Thất bại: " + d.Message);
                        }
                    }
                    list.add(rel);
                }
                return  (list.ToHttpResponseMessage());
            }
        }
        [Route("edit")]
        [HttpPut]
        public HttpResponseMessage edit([FromBody]KTX0011[] values)
        {
            using (DB db = new DB())
            {
                results<KTX0011> list = new results<KTX0011>();
                foreach (var value in values)
                {
                    result<KTX0011> rel = new result<KTX0011>();
                    var check = db.KTX0011.SingleOrDefault(p => p.KTX0011_ID == value.KTX0011_ID);
                    if (check != null)
                    {
                        check.ghichu = value.ghichu;
                        check.soluong = value.soluong; try
                        {
                            db.SaveChanges();
                            rel.set("OK", check, "Thành công: ");
                        }
                        catch (Exception d)
                        {
                            rel.set("ERR", check, "Thất bại: " + d.Message);
                        }
                    }
                    else
                    {
                        rel.set("NaN", check, "Thất bại: Không tìm thấy bản ghi.");
                    }
                    list.add(rel);
                }
                return (list.ToHttpResponseMessage());
            }
        }
        [Route("delete")]
        [HttpPut]
        public HttpResponseMessage delete([FromBody]KTX0011 values)
        {
            using (DB db = new DB())
            {
                result<KTX0011> rel = new result<KTX0011>();
                var check = db.KTX0011.SingleOrDefault(p => p.KTX0011_ID == values.KTX0011_ID);
                if (check != null)
                {
                    db.KTX0011.Remove(check);
                    try
                    {
                        db.SaveChanges();
                        rel.set("OK", check, "Thành công.");
                    }
                    catch (Exception t)
                    {
                        rel.set("ERR", check, "Thất bại: " + t.Message);
                    }
                }
                else
                    rel.set("NaN", check, "Thất bại: Không tìm thấy bản ghi.");
                return ( rel.ToHttpResponseMessage());
            }
        }
    }
}
