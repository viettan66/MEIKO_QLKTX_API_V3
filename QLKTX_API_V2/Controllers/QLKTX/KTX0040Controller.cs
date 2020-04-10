using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.QLKTX
{
    [RoutePrefix("api/KTX0040")]
    public class KTX0040Controller : ApiController
    {
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]KTX0040[] values)
        {
            using (DB db = new DB())
            {
                results<KTX0040> list = new results<KTX0040>();
                foreach (var value in values)
                {
                    result<KTX0040> rel = new result<KTX0040>();
                    KTX0040 t = value;
                    try
                    {
                        var kkk = db.KTX0040.Add(t);
                        db.SaveChanges();
                        rel.set("OK", t, "Thành công");
                    }
                    catch (Exception rr)
                    {

                        rel.set("ERR", t, "Thất bại: " + rr.Message);
                    }
                    list.add(rel);
                }
                return list.ToHttpResponseMessage();
            }
        }

        [Route("Getall")]
        [HttpGet]
        public HttpResponseMessage Getall()
        {
            using (DB db = new DB())
            {
                var temp = db.KTX0040.Select(p => new
                { p.ghichu,
                    p.image, p.KTX0040_ID, p.noidung, p.thutu, p.tieude, p.trangthai
                });
                return REST.GetHttpResponseMessFromObject(temp.ToList());
            }
        }
        [Route("delete")]
        [HttpPut]
        public HttpResponseMessage update([FromBody]KTX0040[] values)
        {
            using (DB db = new DB())
            {
                results<KTX0040> list = new results<KTX0040>();
                values.ToList().ForEach(value =>
                {
                    result<KTX0040> rel = new result<KTX0040>();
                    var check = db.KTX0040.SingleOrDefault(p => p.KTX0040_ID == value.KTX0040_ID);
                    if (check != null)
                    {
                        db.KTX0040.Remove(check);
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
        [HttpPost]
        public HttpResponseMessage update([FromBody]KTX0040 values)
        {
            using (DB db = new DB())
            {
                result<KTX0040> rel = new result<KTX0040>();
                var check = db.KTX0040.SingleOrDefault(p => p.KTX0040_ID == values.KTX0040_ID);
                if (check != null)
                {
                    check.ghichu = values.ghichu;
                    check.image = values.image;
                    check.noidung = values.noidung;
                    check.thutu = values.thutu;
                    check.tieude = values.tieude;
                    check.trangthai = values.trangthai;
                    try {
                        db.SaveChanges();
                        rel.set("OK", check, "Thành Công");
                    } catch (Exception tf)
                    { 
                        rel.set("ERR", values, "Thất bại: "+tf.Message);
                    }
                }else 
                        rel.set("NaN", values, "Không thất dữ liệu");
                return rel.ToHttpResponseMessage();
            }
        }
    }
}
