using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.ADMIN
{
    public static class GetMKV9998
    {
        public struct filter {
            public string id { get; set; }
        }

        public static object Get(filter filter)
        {
            using(DB db=new DB())
            {
                var data = db.MKV9998.AsEnumerable().Select(p => new
                {
                    p.asoft,p.bophan_diachi,p.bophan_dienthoai,p.bophan_ma,p.bophan_ten,p.congty_id,p.idcha,p.muc,p.phong_id,p.thutu,p.tinhtrang
                });
                if (filter.id != null)
                    return data.Where(p => p.phong_id == filter.id).FirstOrDefault();
                return data.ToList();
            }
        }
    }
}