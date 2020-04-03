using MEIKO_QLKTX_API_V1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLKTX_API_V2.Controllers.QLKTX
{
    [RoutePrefix("api/KTX0023")]
    public class KTX0023Controller : ApiController
    {
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]KTX0023 values)
        {
            using (DB db = new DB())
            {
                result<KTX0023> rel = new result<KTX0023>();

                KTX0023 newKTX0023 = new KTX0023();
                newKTX0023.MKV9999_ID = values.MKV9999_ID;
                newKTX0023.trakytucxa = values.trakytucxa;
                newKTX0023.ngaytrakytucxa = values.ngaytrakytucxa;
                newKTX0023.lydotra = values.lydotra;
                newKTX0023.somayle = values.somayle;
                newKTX0023.didong = values.didong;
                newKTX0023.chunhiemnoilam = values.chunhiemnoilam;
                newKTX0023.truongphongnoilam = values.truongphongnoilam;
                newKTX0023.banqlktx = values.banqlktx;
                newKTX0023.chunhiemGA = values.chunhiemGA;
                newKTX0023.KTX0001_ID = values.KTX0001_ID;
                newKTX0023.KTX0002_ID = values.KTX0002_ID;
                newKTX0023.KTX0003_ID = values.KTX0003_ID;
                newKTX0023.khoaphong = values.khoaphong;
                newKTX0023.sotu = values.sotu;
                newKTX0023.sokhoatu = values.sokhoatu;
                newKTX0023.ngaycohieuluc = values.ngaycohieuluc;
                newKTX0023.tonggiatriboithuong = values.tonggiatriboithuong;
                newKTX0023.bqlhoten = values.bqlhoten;
                newKTX0023.bqlkynhan = values.bqlkynhan;
                newKTX0023.nldhoten = values.nldhoten;
                newKTX0023.nldkynhan = values.nldkynhan;
                newKTX0023.trangthai = values.trangthai;
                newKTX0023.ngaytaodon = DateTime.Now;
                db.KTX0023.Add(newKTX0023);
                try
                {
                    db.SaveChanges();
                    newKTX0023.MKV9999 = values.MKV9999;
                    rel.set("OK", newKTX0023, REST.OK);
                }
                catch (Exception t)
                {
                    rel.set("ERR", values, REST.ERR + t.Message);
                }
                return  (rel.ToHttpResponseMessage());
            }
        }

        public struct GetKTX0023
        {
            public Nullable<int> KTX0023_ID { get; set; }
            public Nullable<int> MKV9999_ID { get; set; }
            public Nullable<bool> trangthai { get; set; }
            public Nullable<DateTime> startdate { get; set; }
            public Nullable<DateTime> enddate { get; set; }
        }
        [Route("Getall")]
        [HttpPost]
        public HttpResponseMessage Getall([FromBody]GetKTX0023 filter)
        {
            using (var db = new DB())
            {
                var table = db.KTX0023.AsEnumerable().Select(check => new
                {
                    check.banqlktx,
                    check.bqlhoten,
                    check.bqlkynhan,
                    check.chunhiemGA,
                    check.chunhiemnoilam,
                    check.didong,
                    check.khoaphong,
                    check.KTX0001_ID,
                    check.KTX0002_ID,
                    check.KTX0003_ID,
                    check.KTX0023_ID,
                    check.lydotra,
                    check.MKV9999_ID,
                    check.ngaycohieuluc,
                    check.ngaytrakytucxa,
                    check.nldhoten,
                    check.nldkynhan,
                    check.sokhoatu,
                    check.somayle,
                    check.sotu,
                    check.nhanxet,
                    check.tonggiatriboithuong,
                    check.trakytucxa,
                    check.truongphongnoilam,
                    check.trangthai,
                    check.ngaytaodon,
                    KTX0001 =(from p in db.KTX0001 where  p.KTX0001_ID == check.KTX0001_ID select new { p.ghichu, p.idcha, p.khu, p.KTX0001_ID, p.makhoa, p.slot, p.ten, p.thutu, p.trangthai, p.type }).FirstOrDefault(),
                    KTX0002 = db.KTX0002.Where(p => p.KTX0002_ID == check.KTX0002_ID).Select(p=>new { p.ghichu, p.KTX0001_ID, p.KTX0002_ID, p.ten, p.thutu, p.trangthai, p.type }).FirstOrDefault(),
                    KTX0003 = db.KTX0003.Where(p => p.KTX0003_ID == check.KTX0003_ID).Select(p => new { p.ghichu, p.KTX0001_ID, p.KTX0003_ID, p.MaKhoa, p.SoTu, p.trangthai, p.type }).FirstOrDefault(),
                    MKV9999 = (from f in db.MKV9999
                               where check.MKV9999_ID == f.MKV9999_ID
                               select new
                               {
                                   f.MKV9999_ID,
                                   f.manhansu,
                                   f.matkhau,
                                   f.id,
                                   f.hodem,
                                   f.ten,
                                   f.ngaysinh,
                                   f.gioitinh,
                                   f.noisinh,
                                   f.quequan,
                                   f.diachithuongtru,
                                   f.diachitamtru,
                                   f.cmtnd_so,
                                   f.cmtnd_ngayhethan,
                                   f.cmtnd_noicap,
                                   f.hochieu_so,
                                   f.hochieu_ngaycap,
                                   f.hochieu_ngayhethan,
                                   f.ngayvaocongty,
                                   f.phong_id,
                                   f.ban_id,
                                   f.congdoan_id,
                                   f.chucvu_id,
                                   f.nganhang_stk,
                                   f.nganhang_id,
                                   f.sosobaohiem,
                                   f.honnhantinhtrang,
                                   f.datnuoc_id,
                                   f.phuongxa,
                                   f.suckhoetinhtrang,
                                   f.dienthoai_nharieng,
                                   f.dienthoai_didong,
                                   f.email,
                                   f.tinhtrangnhansu,
                                   f.thutu,
                                   f.chucvu,
                                   f.capbac,
                                   bophan = (from klj in db.MKV9998 where klj.phong_id == f.phong_id select klj).FirstOrDefault(),
                                   ban = (from klj in db.MKV9998 where klj.phong_id == f.ban_id select klj).FirstOrDefault(),
                                   thetu_id = (from t in db.MKV9998 where t.phong_id == f.phong_id select t.bophan_ten).FirstOrDefault(),
                               }).FirstOrDefault(),
                    KTX0031 = (from temp in db.KTX0031
                               where temp.MKV9999_ID == check.MKV9999_ID && temp.trangthai == true || temp.KTX0023_ID == check.KTX0023_ID
                               select new
                               {
                                   temp.ghichu,
                                   temp.KTX0010_ID,
                                   temp.KTX0031_ID,
                                   temp.MKV9999_ID,
                                   temp.ngaycap,
                                   temp.ngaytra,
                                   temp.soluongcap,
                                   temp.soluongtra,
                                   temp.thutu,
                                   temp.trangthai,
                                   KTX0010 = (from l in db.KTX0010
                                              where l.KTX0010_ID == temp.KTX0010_ID
                                              select new
                                              {
                                                  l.ghichu,
                                                  l.giatien,
                                                  l.donvi,
                                                  l.KTX0010_ID,
                                                  l.loai,
                                                  l.maSanPham,
                                                  l.soluongmacdinh,
                                                  l.soLuongTonKho,
                                                  l.ten,
                                                  l.thutu,
                                                  l.trangthai,
                                                  l.WH0007_ID,
                                              }).FirstOrDefault()
                               })
                });
                if (filter.trangthai != null)
                {
                    table = table.Where(p => p.trangthai == filter.trangthai);
                }
                if (filter.KTX0023_ID != null)
                {
                    table = table.Where(p => p.KTX0023_ID == filter.KTX0023_ID);
                }
                if (filter.MKV9999_ID != null)
                {
                    table = table.Where(p => p.MKV9999_ID == filter.MKV9999_ID);
                }
                if (filter.startdate != null)
                {
                    table = table.Where(p => p.ngaytaodon.Value.Date >= filter.startdate.Value.Date);
                }
                if (filter.enddate != null)
                {
                    table = table.Where(p => p.ngaytaodon.Value.Date <= filter.enddate.Value.Date);
                }
                return  REST.GetHttpResponseMessFromObject(table.ToList());
            }





        }
        [Route("delete")]
        [HttpPut]
        public HttpResponseMessage delete([FromBody]KTX0023[] values)
        {
            using (DB db = new DB())
            {
                results<KTX0023> list = new results<KTX0023>();
                foreach (var k in values)
                {
                    result<KTX0023> rel = new result<KTX0023>();
                    var check = db.KTX0023.SingleOrDefault(p => p.KTX0023_ID == k.KTX0023_ID);
                    if (check != null)
                    {
                        if (check.trangthai == false || check.trangthai == null)
                        {
                            db.KTX0023.Remove(check);
                            try
                            {
                                db.SaveChanges();
                                rel.set("OK", check, "Thành công");
                            }
                            catch (Exception fd)
                            {
                                rel.set("ERR", check, "Thất bại: " + fd.Message);
                            }
                        }
                        else
                        {
                            rel.set("ERR", check, "Thất bại: Đơn này đã được duyệt, không thể xóa, hãy liên hệ nới admin.");
                        }
                    }
                    else
                    {
                        rel.set("NaN", check, "Thất bại: không tìm thấy dữ liệu.");
                    }
                    list.add(rel);
                }
                return (list.ToHttpResponseMessage());
            }
        }
        [Route("Agree")]
        [HttpPut]
        public HttpResponseMessage Agree([FromBody]KTX0023[] values)
        {
            using (DB db = new DB())
            {
                results<KTX0023> list = new results<KTX0023>();
                foreach (var k in values)
                {
                    result<KTX0023> rel = new result<KTX0023>();
                    var check = (from kkk in db.KTX0023 where kkk.KTX0023_ID == k.KTX0023_ID select kkk).FirstOrDefault();
                    if (check != null)
                    {
                        var check_kt20 = (from temp in db.KTX0020 where temp.KTX0002_ID == k.KTX0002_ID && temp.MKV9999_ID == k.MKV9999_ID select temp).FirstOrDefault();
                        if (check_kt20 != null)
                        {

                            var kt02 = db.KTX0002.FirstOrDefault(p => p.KTX0002_ID == check_kt20.KTX0002_ID);
                            kt02.trangthai = false;
                            var kt03 = db.KTX0003.FirstOrDefault(p => p.KTX0003_ID == check_kt20.KTX0003_ID);
                            if (kt03 != null) kt03.trangthai = false;
                            check_kt20.trangthai2 = true;
                            db.SaveChanges();
                            check.trangthai = true;
                            check.nhanxet = k.nhanxet;
                            db.KTX0031.Where(p => p.MKV9999_ID == check.MKV9999_ID && p.trangthai == true).ToList().ForEach(val =>
                            {
                                val.trangthai = false;
                                val.ngaytra = DateTime.Now;
                                val.KTX0023_ID = check.KTX0023_ID;
                            });
                            db.SaveChanges();
                            rel.set("OK", k, "Thành công");

                            try
                            { }
                            catch (Exception fd)
                            {
                                rel.set("ERR", check, "Thất bại: " + fd.Message);

                            }
                        }
                        else
                        {
                            rel.set("NaN", check, "Không tìm thất dữ liệu KTX0020.");

                        }
                    }
                    else
                    {
                        rel.set("NaN", k, "Không tìm thấy bản ghi mã: KTX0023_ID " + k.KTX0023_ID);
                    }
                    list.add(rel);
                }
                return  (list.ToHttpResponseMessage());
            }
        }
    }
}
