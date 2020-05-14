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
    [RoutePrefix("api/KTX0052")]
    public class KTX0052Controller : ApiController
    {
        [Route("Getall")]
        [HttpGet]
        public HttpResponseMessage Getall()
        {
            using (DB db = new DB())
            {
                var data = db.KTX0052.ToList();
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]KTX0052 value)
        {
            using (DB db = new DB())
            {
                result<KTX0052> rel = new result<KTX0052>();
                var check = db.KTX0052.Where(p => p.User_ID == value.User_ID || p.manhansu == value.manhansu).FirstOrDefault();
                if (check == null)
                {
                    try { db.KTX0052.Add(value);
                        db.SaveChanges();
                        rel.set("OK", value);
                    }
                    catch
                    {
                        rel.set("ERR", null);
                    }
                }
                else
                {
                        rel.set("ESIXT", null);

                }
                return rel.ToHttpResponseMessage();
            }
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage update([FromBody]KTX0052 value)
        {
            using (DB db = new DB())
            {
                result<KTX0052> rel = new result<KTX0052>();
                var check = db.KTX0052.SingleOrDefault(p => p.KTX0052_ID == value.KTX0052_ID);
                if (check != null)
                {
                    check.capbac = value.capbac;
                    check.chucvu = value.chucvu ;
                    check.cmtnd_ngayhethan = value.cmtnd_ngayhethan ;
                    check.cmtnd_noicap = value.cmtnd_noicap ;
                    check.cmtnd_so = value.cmtnd_so ;
                    check.dienthoai_didong = value.dienthoai_didong ;
                    check.gioitinh = value.gioitinh ;
                    check.hodem = value.hodem ;
                    check.manhansu = value.manhansu ;
                    check.ngaysinh = value.ngaysinh ;
                    check.phong_id = value.phong_id ;
                    check.ten = value.ten ;
                    check.thetu_id = value.thetu_id;
                    check.User_ID = value.User_ID ;
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
        public HttpResponseMessage delete([FromBody]KTX0052[] values)
        {
            using (DB db = new DB())
            {
                results<KTX0052> list = new results<KTX0052>();
                values.ToList().ForEach(value =>
                {
                    result<KTX0052> rel = new result<KTX0052>();
                    var check = db.KTX0052.SingleOrDefault(p => p.KTX0052_ID == value.KTX0052_ID);
                    if (check != null)
                    {
                        db.KTX0052.Remove(check);
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
    }
}
