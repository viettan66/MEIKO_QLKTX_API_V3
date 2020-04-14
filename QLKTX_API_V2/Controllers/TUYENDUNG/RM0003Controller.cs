using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.TUYENDUNG
{
    [RoutePrefix("api/RM0003")]
    public class RM0003Controller : ApiController
    {
        [Route("Getall")]
        [HttpGet]
        public HttpResponseMessage Getall()
        {
            using (DB db = new DB())
            {
                var data = db.RM0003.Select(p => new
                {
                    p.ghiChu,
                    p.maBacDaoTao,
                    p.RM0003_ID,
                    p.tenBacDaoTao,
                    p.thuTu,
                    p.tinhTrang
                });
                return REST.GetHttpResponseMessFromObject(data.ToList());
            }
        }
        [Route("Getid/{id}")]
        [HttpGet]
        public HttpResponseMessage Getid(int id)
        {
            using (DB db = new DB())
            {
                var data = db.RM0003.Where(p => p.RM0003_ID == id).Select(p => new
                {
                    p.ghiChu,
                    p.maBacDaoTao,
                    p.RM0003_ID,
                    p.tenBacDaoTao,
                    p.thuTu,
                    p.tinhTrang
                }).FirstOrDefault();
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage update([FromBody]RM0003 value)
        {
            using (DB db = new DB())
            {
                result<RM0003> rel = new result<RM0003>();
                var check = db.RM0003.SingleOrDefault(p => p.RM0003_ID == value.RM0003_ID);
                if (check != null)
                {
                    check.ghiChu = value.ghiChu;
                    check.maBacDaoTao = value.maBacDaoTao;
                    check.tenBacDaoTao = value.tenBacDaoTao;
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
        public HttpResponseMessage delete([FromBody]RM0003[] values)
        {
            using (DB db = new DB())
            {
                results<RM0003> list = new results<RM0003>();
                values.ToList().ForEach(value =>
                {
                    result<RM0003> rel = new result<RM0003>();
                    var check = db.RM0003.SingleOrDefault(p => p.RM0003_ID == value.RM0003_ID);
                    if (check != null)
                    {
                        db.RM0003.Remove(check);
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
        public HttpResponseMessage add([FromBody]RM0003 value)
        {
            using (DB db = new DB())
            {
                result<RM0003> rel = new result<RM0003>();
                db.RM0003.Add(value);
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
