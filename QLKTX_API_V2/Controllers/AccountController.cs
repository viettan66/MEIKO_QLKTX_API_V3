using MEIKO_QLKTX_API_V1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLKTX_API_V2.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        public struct acc
        {
            public string ID { get; set; }
            public string pass { get; set; }
        }
        [Route("Check")]
        [HttpPost]
        public HttpResponseMessage Check([FromBody]acc value)
        {
            DB db = new DB();
            var acc = (from temp in db.MKV9999 where temp.manhansu == value.ID || temp.cmtnd_so == value.ID select temp).Select(p => new
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
                p.thetu_id,
            }).FirstOrDefault();

            return REST.GetHttpResponseMessFromObject(acc);
        }
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]MKV9999 value)
        {
            result<MKV9999> rel = new result<MKV9999>();
            DB db = new DB();
            var kj = value;
            var ch = db.MKV9999.SingleOrDefault(p => p.manhansu == value.manhansu);
            if (ch == null)
            {
                db.MKV9999.Add(kj);
                try
                {
                    db.SaveChanges();
                    rel.set("OK", kj, "Thành công");

                    db.MKV9984.Add(new MKV9984() { MKV9999_ID = kj.MKV9999_ID, MKV9983_ID = 2 }); ;
                    db.SaveChanges();
                }
                catch (Exception ee)
                {
                    rel.set("ERR", value, ee.Message);
                }
            }
            else
            {
                rel.set("ERR", kj, "Tài khoản này đã tồn tại, bạn hãy sử dụng chức năng Quên mật khẩu!");
            }
            return (rel.ToHttpResponseMessage());
        }

        [Route("Get")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            using (DB db = new DB())
            {
                var acc = (from p in db.MKV9999 select new
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
                    thetu_id=db.MKV9998.Where(o=>p.phong_id==o.phong_id).Select(o=>o.bophan_ten).FirstOrDefault(),
                }).ToList();

                return REST.GetHttpResponseMessFromObject(acc);
            }
        }
        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Update([FromBody]MKV9999 value)
        {
            using (DB db = new DB())
            {
                result<MKV9999> rel = new result<MKV9999>();
                var check = db.MKV9999.SingleOrDefault(p=>p.MKV9999_ID==value.MKV9999_ID);
                if (check != null)
                {
                    check.matkhau = value.matkhau;
                    try
                    {
                        db.SaveChanges();
                        rel.set("OK",value,"Thành công");
                    }catch(Exception fd)
                    {
                        rel.set("ERR", value, "Thất bại: " + fd.Message);
                    }
                }else rel.set("NaN", value, "Thất bại: Không có dữ liệu");
                return rel.ToHttpResponseMessage();
            }
        }
    }
}
