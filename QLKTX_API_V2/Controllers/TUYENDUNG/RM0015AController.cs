using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.TUYENDUNG
{
    [RoutePrefix("api/RM0015A")]
    public class RM0015AController : ApiController
    {
        [Route("update")]
        [HttpPost]
        public HttpResponseMessage Getall([FromBody]RM0015A[] values)
        {
            using (DB db = new DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val =>
                {
                    result<object> rel = new result<object>();
                    var check = db.RM0015A.SingleOrDefault(p => p.RM0015A_ID == val.RM0015A_ID);
                    if (check != null)
                    {
                        check.ghiChu = val.ghiChu;
                        check.trangThai = val.trangThai;
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", GetRM0015A.Get(new GetRM0015A.filter() { id = check.RM0015A_ID }), "Thành công.");
                        }
                        catch (Exception fd)
                        {
                            rel.set("ERR", null, "Thất bại: " + fd.Message);
                        }
                    }
                    else
                        rel.set("NaN", null, "Không thấy dữ liệu.");
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }

        }
    }
    public static class GetRM0015A
    {
        public struct filter
        {
            public Nullable<int> id { get; set; }
        }
        public static object Get(filter filter)
        {
            using(DB db=new DB())
            {
                var data = db.RM0015A.AsEnumerable().Select(p=> new{
                    p.ghiChu,p.MKV9999_ID,p.RM0015A_ID,p.RM0015_ID,p.trangThai,RM0015=db.RM0015.Where(o=>o.RM0015_ID==p.RM0015_ID).Select(o=>new {
                        o.ghiChu,o.ketQua,o.RM0008_ID,o.RM0010_ID,o.RM0015_ID,o.thoiGianPhongVan,o.trangThai,o.vongPhongVan
                    }).FirstOrDefault()
                });
                if (filter.id != null)
                {
                    return data.SingleOrDefault(p => p.RM0015A_ID == filter.id);
                }
                return data.ToList();
            }
        }
    }
}
