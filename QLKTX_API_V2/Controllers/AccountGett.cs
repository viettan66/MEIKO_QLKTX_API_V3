using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers
{
    public static class AccountGett
    { 
        public struct filter { 
            public Nullable<int> id { get; set; }
            public string manhansu { get; set; }
        }
        public static object GetAccount(filter filter)
        {

            using (DB db = new DB())
            {
                var acc = (from p in db.MKV9999
                           select new
                           {
                               p.MKV9999_ID,
                               p.manhansu,
                               p.matkhau,
                               p.id,
                               p.hodem,
                               p.ten,
                               p.type,
                               p.ngaysinh,
                               p.gioitinh,
                               p.noisinh,
                               p.quequan,
                               p.diachithuongtru,
                               p.diachitamtru,
                               p.cmtnd_so,
                               p.cmtnd_ngayhethan,
                               p.cmtnd_noicap,
                               p.hochieu_so,
                               p.hochieu_ngaycap,
                               p.hochieu_ngayhethan,
                               p.ngayvaocongty,
                               p.phong_id,
                               p.ban_id,
                               p.congdoan_id,
                               p.chucvu_id,
                               p.nganhang_stk,
                               p.nganhang_id,
                               p.sosobaohiem,
                               p.honnhantinhtrang,
                               p.datnuoc_id,
                               p.phuongxa,
                               p.suckhoetinhtrang,
                               p.dienthoai_nharieng,
                               p.dienthoai_didong,
                               p.email,
                               p.tinhtrangnhansu,
                               p.thutu,
                               p.chucvu,
                               p.capbac,
                               thetu_id = db.MKV9998.Where(o => p.phong_id == o.phong_id).Select(o => o.bophan_ten).FirstOrDefault(),
                           }).ToList();
                if (filter.id != null)
                {
                    return acc.Where(p => p.MKV9999_ID == filter.id).FirstOrDefault();
                }
                if (filter.manhansu != null)
                {
                    return acc.Where(p => p.manhansu == filter.manhansu).FirstOrDefault();
                }
                return acc;
            }
        }
    }
}