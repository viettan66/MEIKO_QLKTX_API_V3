using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.TUYENDUNG
{
    [RoutePrefix("api/RM0006")]
    public class RM0006Controller : ApiController
    {
        [Route("Getall")]
        [HttpGet]
        public HttpResponseMessage Getall()
        {
            using (DB db = new DB())
            {
                var data = db.RM0006.Select(p => new
                {
                    p.ghiChu,
                    p.maTieuChiDG,
                    p.RM0006_ID,
                    p.tenTieuChiDG,
                    p.thuTu,
                    p.tinhTrang
                });
                return REST.GetHttpResponseMessFromObject(data.ToList());
            }
        }
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage update([FromBody]RM0006 value)
        {
            using (DB db = new DB())
            {
                result<RM0006> rel = new result<RM0006>();
                var check = db.RM0006.SingleOrDefault(p => p.RM0006_ID == value.RM0006_ID);
                if (check != null)
                {
                    check.ghiChu = value.ghiChu;
                    check.maTieuChiDG = value.maTieuChiDG;
                    check.tenTieuChiDG = value.tenTieuChiDG;
                    check.thuTu = value.thuTu;
                    check.tinhTrang = value.tinhTrang;
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
        public HttpResponseMessage update([FromBody]RM0006[] values)
        {
            using (DB db = new DB())
            {
                results<RM0006> list = new results<RM0006>();
                values.ToList().ForEach(value =>
                {
                    result<RM0006> rel = new result<RM0006>();
                    var check = db.RM0006.SingleOrDefault(p => p.RM0006_ID == value.RM0006_ID);
                    if (check != null)
                    {
                        db.RM0006.Remove(check);
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
        public HttpResponseMessage add([FromBody]RM0006 value)
        {
            using (DB db = new DB())
            {
                result<RM0006> rel = new result<RM0006>();
                db.RM0006.Add(value);
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
