using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.TUYENDUNG
{
    [RoutePrefix("api/RM0013")]
    public class RM0013Controller : ApiController
    {
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]RM0013[] values)
        {
            using (DB db = new DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(value =>
                {
                    result<object> rel = new result<object>();
                    var check = db.RM0013.SingleOrDefault(p => p.RM0013_ID == value.RM0013_ID);
                    if (check == null)
                    {
                        db.RM0013.Add(value);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", GettRM0013(new filter() { id = value.RM0013_ID }), "Thành công");
                        }
                        catch (Exception fd)
                        {
                            rel.set("ERR", null, "Thất bại: " + fd.Message);
                        }
                    }
                    else
                    {
                        check.ghiChu = value.ghiChu;
                        check.ketQua = value.ketQua;
                        check.MKV9999_ID = value.MKV9999_ID;
                        check.nhanXet = value.nhanXet;
                        check.trangThai = value.trangThai;
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", GettRM0013(new filter() { id = check.RM0013_ID }), "Thành công");
                        }
                        catch (Exception fd)
                        {
                            rel.set("ERR", null, "Thất bại: " + fd.Message);
                        }
                    }
                    updateKetqua(value.RM0015_ID);
                    list.add(rel);
                });

                return list.ToHttpResponseMessage();
            }
        }
        public struct filter
        {
            public Nullable<int> id { get; set; }
            public Nullable<int> type { get; set; }
        }
        public object GettRM0013(filter filter)
        {
            using (DB db = new DB())
            {
                var data = db.RM0013.AsEnumerable().Select(p => new
                {
                    p.ghiChu,
                    p.ketQua,
                    p.MKV9999_ID,
                    p.nhanXet,
                    p.RM0006_ID,
                    p.RM0013_ID,
                    p.RM0015_ID,
                    p.trangThai
                }).ToList();
                if (filter.id != null)
                {
                    return data.Where(p => p.RM0013_ID == filter.id).FirstOrDefault();
                }
                return data;
            }
        }
        public void updateKetqua(int idrm0015)
        {
            using (DB db = new DB())
            {
                var check = db.RM0015.SingleOrDefault(p => p.RM0015_ID == idrm0015);
                if (check != null)
                {
                    var rm0006 = db.RM0006.Where(p => p.tinhTrang == true).Select(p=>p.RM0006_ID);
                    var rm0013 = db.RM0013.Where(p => p.RM0015_ID == idrm0015&&rm0006.Contains(p.RM0006_ID));
                    if (rm0006.Count() == rm0013.Count())
                    {
                        bool iff = true;
                        rm0013.ToList().ForEach(val =>
                        {
                            if (val.ketQua == false) iff = false;
                        });
                        if (iff)
                        {
                            check.ketQua = true;
                            try { db.SaveChanges(); ; } catch { }
                        }
                        else
                        {

                            check.ketQua = false;
                            try { db.SaveChanges(); ; } catch { }
                        }
                    }
                   
                }
            }
        }
    }
}