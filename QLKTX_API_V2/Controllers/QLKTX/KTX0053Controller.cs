using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;
using QLKTX_API_V2.Controllers.ADMIN;
using static QLKTX_API_V2.Controllers.ADMIN.FingerPrintData;

namespace QLKTX_API_V2.Controllers.QLKTX
{
    [RoutePrefix("api/KTX0053")]
    public class KTX0053Controller : ApiController
    {
        [Route("Getall")]
        [HttpGet]
        public HttpResponseMessage Getall()
        {
            using (DB db = new DB())
            {
                var data = db.KTX0053;
                return REST.GetHttpResponseMessFromObject(data.ToList());
            }
        }
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage update([FromBody]KTX0053 value)
        {
            using (DB db = new DB())
            {
                result<KTX0053> rel = new result<KTX0053>();
                var check = db.KTX0053.SingleOrDefault(p => p.KTX0053_ID == value.KTX0053_ID);
                if (check != null)
                {
                    check.buasang = value.buasang;
                    check.buatoi = value.buatoi;
                    check.buatrua = value.buatrua;
                    check.ngay = value.ngay;
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
        [Route("delete")]
        [HttpPut]
        public HttpResponseMessage update([FromBody]KTX0053[] values)
        {
            using (DB db = new DB())
            {
                results<KTX0053> list = new results<KTX0053>();
                values.ToList().ForEach(value =>
                {
                    result<KTX0053> rel = new result<KTX0053>();
                    var check = db.KTX0053.SingleOrDefault(p => p.KTX0053_ID == value.KTX0053_ID);
                    if (check != null)
                    {
                        db.KTX0053.Remove(check);
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
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]KTX0053 value)
        {
            using (DB db = new DB())
            {
                result<KTX0053> rel = new result<KTX0053>();
                db.KTX0053.Add(value);
                try
                {
                    db.SaveChanges();
                    rel.set("OK", value, "Thành công");
                }
                catch (Exception l)
                {
                    rel.set("ERR", value, "Thất bại:" + l.Message);
                }
                return rel.ToHttpResponseMessage();
            }
        }
    }
}
