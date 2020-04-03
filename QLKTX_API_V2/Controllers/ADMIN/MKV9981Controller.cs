using MEIKO_QLKTX_API_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLKTX_API_V2.Controllers.ADMIN
{
    [RoutePrefix("api/MKV9981")]
    public class MKV9981Controller : ApiController
    {
        [Route("Edit")]
        [HttpPut]
        public HttpResponseMessage Edit([FromBody]MKV9981[] value)
        {
            using (DB db = new DB())
            {
                results<MKV9981> list = new results<MKV9981>();
                foreach (var val in value)
                {
                    result<MKV9981> rel = new result<MKV9981>();
                    var data = db.MKV9981.SingleOrDefault(p => p.MKV9981_ID == val.MKV9981_ID);
                    if (data != null)
                    {
                        data.TENHANHDONG = val.TENHANHDONG;
                        data.LINKMENU = val.LINKMENU;
                        data.IMAGE = val.IMAGE;
                        data.THUTU = val.THUTU;
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", data, "Thành công");
                        }
                        catch (Exception rr)
                        {

                            rel.set("ERR", data, "Thất bại: " + rr.Message);
                        }
                    }
                    else
                    {
                        rel.set("ERR", val, "Thất bại: Không tìm thấy dữ liệu.");
                    }
                    list.add(rel);
                }
                return  list.ToHttpResponseMessage();
            }
        }
    }
}
