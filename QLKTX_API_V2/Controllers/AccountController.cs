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
                thetu_id=db.MKV9998.Where(o => p.phong_id == o.phong_id).Select(o => o.bophan_ten).FirstOrDefault(),
                KTX0001 = db.KTX0001.Where(l => l.KTX0001_ID == db.KTX0020.Where(j => j.MKV9999_ID == p.MKV9999_ID && j.trangthai2 != true).Select(j => j.MKV9999_ID).FirstOrDefault()).Select(o => new
                {
                    o.capbac,o.ghichu,o.idcha,o.khu,o.KTX0001_ID,o.makhoa,o.slot,o.ten,o.thutu,o.trangthai,o.type
                })
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
            var ch = db.MKV9999.Where(p => p.manhansu == value.manhansu).FirstOrDefault();
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
                rel.set("exist", ch, "Tài khoản này đã tồn tại, bạn hãy sử dụng chức năng Quên mật khẩu!");
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
        public struct getcmd { 
            public string cmd { get; set; }
        }
        [Route("GetSQL")]
        [HttpPost]
        public HttpResponseMessage GetSQL([FromBody] getcmd cmd)
        {
            using (DB db = new DB())
            {
                var data = db.Database.SqlQuery<MKV9999>(cmd.cmd);
                return REST.GetHttpResponseMessFromObject(data);
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
        [Route("Updateinfo")]
        [HttpPut]
        public HttpResponseMessage Updateinfo([FromBody]MKV9999 value)
        {
            using (DB db = new DB())
            {
                result<object> rel = new result<object>();
                var check = db.MKV9999.SingleOrDefault(p=>p.MKV9999_ID==value.MKV9999_ID);
                if (check != null)
                {
                    check.manhansu = value.manhansu;
                    check.id = value.id;
                    check.hodem = value.hodem;
                    check.ten = value.ten;
                    check.type = 1;
                    check.ngaysinh = value.ngaysinh;
                    check.gioitinh = value.gioitinh;
                    check.noisinh = value.noisinh;
                    check.quequan = value.quequan;
                    check.diachithuongtru = value.diachithuongtru;
                    check.diachitamtru = value.diachitamtru;
                    check.cmtnd_so = value.cmtnd_so;
                    check.cmtnd_ngayhethan = value.cmtnd_ngayhethan;
                    check.cmtnd_noicap = value.cmtnd_noicap;
                    check.hochieu_so = value.hochieu_so;
                    check.hochieu_ngaycap = value.hochieu_ngaycap;
                    check.hochieu_ngayhethan = value.hochieu_ngayhethan;
                    check.ngayvaocongty = value.ngayvaocongty;
                    check.phong_id = value.phong_id;
                    check.ban_id = value.ban_id;
                    check.congdoan_id = value.congdoan_id;
                    check.chucvu_id = value.chucvu_id;
                    check.nganhang_stk = value.nganhang_stk;
                    check.nganhang_id = value.nganhang_id;
                    check.sosobaohiem = value.sosobaohiem;
                    check.honnhantinhtrang = value.honnhantinhtrang;
                    check.datnuoc_id = value.datnuoc_id;
                    check.phuongxa = value.phuongxa;
                    check.suckhoetinhtrang = value.suckhoetinhtrang;
                    check.dienthoai_nharieng = value.dienthoai_nharieng;
                    check.dienthoai_didong = value.dienthoai_didong;
                    check.email = value.email;
                    check.tinhtrangnhansu = value.tinhtrangnhansu;
                    check.thutu = value.thutu;
                    check.chucvu = value.chucvu;
                    check.capbac = value.capbac;
                    check.thetu_id = value.thetu_id;
                    try
                    {
                        db.SaveChanges();
                        rel.set("OK",AccountGett.GetAccount(new AccountGett.filter() { id=value.MKV9999_ID}),"Thành công");
                    }catch(Exception fd)
                    {
                        rel.set("ERR", null, "Thất bại: " + fd.Message);
                    }
                }else rel.set("NaN", null, "Thất bại: Không có dữ liệu");
                return rel.ToHttpResponseMessage();
            }
        }
    }
}
