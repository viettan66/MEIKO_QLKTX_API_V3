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
    [RoutePrefix("api/KTX0020")]
    public class KTX0020Controller : ApiController
    {
        public struct GetKTX0020
        {
            public Nullable<int> KTX0020_ID { get; set; }
            public Nullable<int> MKV9999_ID { get; set; }
            public Nullable<bool> trangthai { get; set; }
            public Nullable<DateTime> startdate { get; set; }
            public Nullable<DateTime> enddate { get; set; }
        }
        [Route("Getall")]
        [HttpPost]
        public HttpResponseMessage Getall([FromBody]GetKTX0020 filter)
        {
            var db = new DB();
            
                var table = db.KTX0020.AsEnumerable().Select(check => new
                {
                    check.KTX0020_ID,
                    check.MKV9999_ID,
                    check.ngaytaodon,
                    check.capbac,
                    check.trangthai,
                    check.bengiao,
                    check.bennhan,
                    check.bietngoaingu,
                    check.biettiengdantocitnguoi,
                    check.bqlktx,
                    check.choohiennay,
                    check.chunhiemnoilamviec,
                    check.cmtnd_ngaycap,
                    check.cmtnd_noicap,
                    check.cmtnd_so,
                    check.dantoc,
                    check.didong,
                    check.ghichu,
                    check.gioitinh,
                    check.hotenkhac,
                    check.hotenkhaisinh,
                    check.khoaphong,
                    check.KTX0001_ID,
                    check.KTX0002_ID,
                    check.KTX0003_ID,
                    check.lamgiodautu14tuoi,
                    check.lydo,
                    check.lydodangkyoktx,
                    check.lydonguyenvong,
                    check.ngaycohieuluc,
                    check.ngayduyetdon,
                    check.ngayokitucxa,
                    check.ngayquaylaikytucxa,
                    check.ngaysinh,
                    check.nghenghiepchucvunoilam,
                    check.nguyenvongophongso,
                    check.nharieng,
                    check.noidung,
                    check.noisinh,
                    check.noithuongtru,
                    check.okitucxa,
                    check.quaylaikytucxa,
                    check.quequan,
                    check.sokhoatu,
                    check.somayle,
                    check.sotu,
                    check.thoigiantralantruoc,
                    check.tienantoidanhhinhphat,
                    check.tongiao,
                    check.trinhdchuyenmon,
                    check.trinhdohocvan,
                    check.truongphongGA,
                    //timkiem = timkiem.tim(new searchkey() { key = check.cmtnd_so }),
                    check.truongphongnoilamviec,
                    KTX0001 = db.Database.SqlQuery<KTX0001>("select * from ktx0001 where KTX0001_id=" + (check.KTX0001_ID != null ? check.KTX0001_ID : 0)).FirstOrDefault(),
                    KTX0002 =db.Database.SqlQuery<KTX0002>("select * from ktx0002 where KTX0002_id="+(check.KTX0002_ID!=null?check.KTX0002_ID:0)).FirstOrDefault(),
                    KTX0003 =db.Database.SqlQuery<KTX0003>("select * from ktx0003 where KTX0003_id="+(check.KTX0003_ID!=null?check.KTX0003_ID:0)).FirstOrDefault(),
                    KTX0021 = db.Database.SqlQuery<KTX0021>("select * from ktx0021 where KTX0020_id=" + check.KTX0020_ID).ToList(),
                    KTX0022 = db.Database.SqlQuery<KTX0022>("select * from ktx0022 where KTX0020_id=" + check.KTX0020_ID ).ToList(),
                    MKV9999 = (db.MKV9999.Where(f => check.MKV9999_ID == f.MKV9999_ID)).ToList().Select(f => new
                    {
                        f.MKV9999_ID,
                        f.manhansu,
                        f.matkhau,
                        f.id,
                        f.type,
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
                        bophan = db.MKV9998.FirstOrDefault(klj => klj.phong_id == f.phong_id),
                        ban = db.MKV9998.FirstOrDefault(klj => klj.phong_id == f.ban_id),
                        thetu_id = db.MKV9998.FirstOrDefault(klj => klj.phong_id == f.phong_id) != null ? db.MKV9998.FirstOrDefault(klj => klj.phong_id == f.phong_id).bophan_ten : "",
                    }).FirstOrDefault(),
                });
                if (filter.trangthai != null)
                {
                    table = table.Where(p => p.trangthai == filter.trangthai);
                }
                if (filter.KTX0020_ID != null)
                {
                    table = table.Where(p => p.KTX0020_ID == filter.KTX0020_ID);
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
                return REST.GetHttpResponseMessFromObject(table.ToList());
            





        }
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]KTX0020 values)
        {
            result<KTX0020> rel = new result<KTX0020>();
            using (DB db = new DB())
            {
                try
                {
                    KTX0020 newktx0020 = new KTX0020()
                    {
                        KTX0020_ID = values.KTX0020_ID,
                        MKV9999_ID = values.MKV9999_ID,
                        ngaytaodon = values.ngaytaodon,
                        trangthai = values.trangthai,
                        trangthai2 = values.trangthai2,
                        bengiao = values.bengiao,
                        bennhan = values.bennhan,
                        bietngoaingu = values.bietngoaingu,
                        biettiengdantocitnguoi = values.biettiengdantocitnguoi,
                        bqlktx = values.bqlktx,
                        choohiennay = values.choohiennay,
                        chunhiemnoilamviec = values.chunhiemnoilamviec,
                        cmtnd_ngaycap = values.cmtnd_ngaycap,
                        cmtnd_noicap = values.cmtnd_noicap,
                        cmtnd_so = values.cmtnd_so,
                        dantoc = values.dantoc,
                        didong = values.didong,
                        ghichu = values.ghichu,
                        gioitinh = values.gioitinh,
                        hotenkhac = values.hotenkhac,
                        hotenkhaisinh = values.hotenkhaisinh,
                        khoaphong = values.khoaphong,
                        KTX0001_ID = values.KTX0001_ID,
                        KTX0002_ID = values.KTX0002_ID,
                        KTX0003_ID = values.KTX0003_ID,
                        lamgiodautu14tuoi = values.lamgiodautu14tuoi,
                        lydo = values.lydo,
                        lydodangkyoktx = values.lydodangkyoktx,
                        lydonguyenvong = values.lydonguyenvong,
                        ngaycohieuluc = values.ngaycohieuluc,
                        ngayduyetdon = values.ngayduyetdon,
                        ngayokitucxa = values.ngayokitucxa,
                        ngayquaylaikytucxa = values.ngayquaylaikytucxa,
                        ngaysinh = values.ngaysinh,
                        nghenghiepchucvunoilam = values.nghenghiepchucvunoilam,
                        nguyenvongophongso = values.nguyenvongophongso,
                        nharieng = values.nharieng,
                        noidung = values.noidung,
                        noisinh = values.noisinh,
                        noithuongtru = values.noithuongtru,
                        okitucxa = values.okitucxa,
                        quaylaikytucxa = values.quaylaikytucxa,
                        quequan = values.quequan,
                        sokhoatu = values.sokhoatu,
                        somayle = values.somayle,
                        sotu = values.sotu,
                        thoigiantralantruoc = values.thoigiantralantruoc,
                        tongiao = values.tongiao,
                        trinhdchuyenmon = values.trinhdchuyenmon,
                        trinhdohocvan = values.trinhdohocvan,
                        tienantoidanhhinhphat = values.tienantoidanhhinhphat,
                        truongphongGA = values.truongphongGA,
                        truongphongnoilamviec = values.truongphongnoilamviec,
                        KTX0021 = values.KTX0021,
                        KTX0022 = values.KTX0022 ,
                        capbac = values.capbac
                    };
                    newktx0020.ngaytaodon = DateTime.Now;
                    newktx0020.trangthai = false;
                    newktx0020.trangthai2 = false;
                    newktx0020.MKV9999 = null;
                    db.KTX0020.Add(newktx0020);
                    db.SaveChanges();
                    values.KTX0020_ID = newktx0020.KTX0020_ID;
                    rel.set("OK", values, "Thành công");
                }
                catch (ContextMarshalException rr)
                {

                    rel.set("ERR", values, "Thất bại: " + rr.Message);
                }
            }
            return rel.ToHttpResponseMessage();
        }
        [Route("edit")]
        [HttpPut]
        public HttpResponseMessage edit([FromBody]KTX0020 values)
        {
            result<KTX0020> rel = new result<KTX0020>();
            using (DB db = new DB())
            {
                if (values.trangthai == true)
                {
                    rel.set("ERR", values, "Thất bại: Đơn đã duyệt, không thể sửa");
                }
                else
                {
                    var check = db.KTX0020.SingleOrDefault(p => p.KTX0020_ID == values.KTX0020_ID);
                    if (check != null)
                    {
                        try
                        {
                            values.ngaytaodon = DateTime.Now;
                            values.trangthai = false;
                            check.bengiao = values.bengiao;
                            check.bennhan = values.bennhan;
                            check.bietngoaingu = values.bietngoaingu;
                            check.biettiengdantocitnguoi = values.biettiengdantocitnguoi;
                            check.bqlktx = values.bqlktx;
                            check.choohiennay = values.choohiennay;
                            check.chunhiemnoilamviec = values.chunhiemnoilamviec;
                            check.cmtnd_ngaycap = values.cmtnd_ngaycap;
                            check.cmtnd_noicap = values.cmtnd_noicap;
                            check.cmtnd_so = values.cmtnd_so;
                            check.dantoc = values.dantoc;
                            check.didong = values.didong;
                            check.ghichu = values.ghichu;
                            check.gioitinh = values.gioitinh;
                            check.hotenkhac = values.hotenkhac;
                            check.hotenkhaisinh = values.hotenkhaisinh;
                            check.khoaphong = values.khoaphong;
                            check.KTX0001_ID = values.KTX0001_ID;
                            check.KTX0002_ID = values.KTX0002_ID;
                            check.KTX0003_ID = values.KTX0003_ID;
                            check.lamgiodautu14tuoi = values.lamgiodautu14tuoi;
                            check.lydo = values.lydo;
                            check.lydodangkyoktx = values.lydodangkyoktx;
                            check.lydonguyenvong = values.lydonguyenvong;
                            check.MKV9999_ID = values.MKV9999_ID;
                            check.ngaycohieuluc = values.ngaycohieuluc;
                            check.ngayduyetdon = values.ngayduyetdon;
                            check.ngayokitucxa = values.ngayokitucxa;
                            check.ngayquaylaikytucxa = values.ngayquaylaikytucxa;
                            check.ngaysinh = values.ngaysinh;
                            check.ngaytaodon = values.ngaytaodon;
                            check.nghenghiepchucvunoilam = values.nghenghiepchucvunoilam;
                            check.nguyenvongophongso = values.nguyenvongophongso;
                            check.nharieng = values.nharieng;
                            check.noidung = values.noidung;
                            check.noisinh = values.noisinh;
                            check.noithuongtru = values.noithuongtru;
                            check.okitucxa = values.okitucxa;
                            check.quaylaikytucxa = values.quaylaikytucxa;
                            check.quequan = values.quequan;
                            check.sokhoatu = values.sokhoatu;
                            check.somayle = values.somayle;
                            check.sotu = values.sotu;
                            check.thoigiantralantruoc = values.thoigiantralantruoc;
                            check.tongiao = values.tongiao;
                            check.trangthai = values.trangthai;
                            check.trinhdchuyenmon = values.trinhdchuyenmon;
                            check.trinhdohocvan = values.trinhdohocvan;
                            check.capbac = values.capbac;
                            check.truongphongGA = values.truongphongGA;
                            check.tienantoidanhhinhphat = values.tienantoidanhhinhphat;
                            check.truongphongnoilamviec = values.truongphongnoilamviec;
                            db.SaveChanges();
                            rel.set("OK", values, "Thành công");
                            db.KTX0021.RemoveRange(db.KTX0021.Where(p => p.KTX0020_ID == values.KTX0020_ID).ToArray());
                            db.SaveChanges();
                            foreach (var k in values.KTX0021)
                            {
                                db.KTX0021.Add(new KTX0021() { batdau = k.batdau, choo = k.choo, ketthuc = k.ketthuc, KTX0020_ID = check.KTX0020_ID, nghenghiepnoilam = k.nghenghiepnoilam });
                                db.SaveChanges();
                            }
                            db.KTX0022.RemoveRange(db.KTX0022.Where(p => p.KTX0020_ID == values.KTX0020_ID).ToArray());
                            db.SaveChanges();
                            foreach (var k in values.KTX0022)
                            {
                                db.KTX0022.Add(new KTX0022() { ChoOHienNay = k.ChoOHienNay, HoTen = k.HoTen, KTX0020_ID = check.KTX0020_ID, NamSinh = k.NamSinh, NgheNghiep = k.NgheNghiep, QuanHe = k.QuanHe });
                                db.SaveChanges();
                            }
                        }
                        catch (ContextMarshalException rr)
                        {

                            rel.set("ERR", values, "Thất bại: " + rr.Message);
                        }

                    }
                }
            }
            return rel.ToHttpResponseMessage();
        }
        [Route("approval")]
        [HttpPost]
        public HttpResponseMessage approval([FromBody]KTX0020[] values)
        {
            results<KTX0020> rel = new results<KTX0020>();
            using (DB db = new DB())
            {
                foreach (var k in values)
                {
                    result<KTX0020> re = new result<KTX0020>();
                    var check = db.KTX0020.SingleOrDefault(p => p.KTX0020_ID == k.KTX0020_ID);
                    if (check != null)
                    {
                        check.trangthai = true;
                        check.hotenbengiao = k.hotenbengiao;
                        check.ngayduyetdon = DateTime.Now;
                        check.ngaycohieuluc = DateTime.Now;
                        try
                        {
                            db.SaveChanges();
                            k.ngayduyetdon = DateTime.Now;
                            k.ngaycohieuluc = DateTime.Now;
                            k.trangthai = true;
                            re.set("OK", k, "Thành công");
                        }
                        catch (Exception fd)
                        {
                            re.set("ERR", k, "Thất bại: " + fd.Message);
                        }
                    }
                    rel.add(re);
                }
                return rel.ToHttpResponseMessage();
            }
        }
        [Route("delete")]
        [HttpPut]
        public HttpResponseMessage delete([FromBody]KTX0020[] values)
        {
            using (DB db = new DB())
            {
                results<KTX0020> list = new results<KTX0020>();
                foreach (var k in values)
                {
                    result<KTX0020> rel = new result<KTX0020>();
                    var check = db.KTX0020.SingleOrDefault(p => p.KTX0020_ID == k.KTX0020_ID);
                    if (check != null)
                    {
                        if (check.trangthai == false || check.trangthai == null)
                        {
                            db.KTX0020.Remove(check);
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
        [Route("Get/{MKV9999_ID}")]
        [HttpGet]
        public HttpResponseMessage Get(int MKV9999_ID)
        {
            using (DB db = new DB())
            {
                var k = (from check in db.KTX0020
                         where check.MKV9999_ID == MKV9999_ID && (check.trangthai2 == false || check.trangthai2 == null)
                         select new
                         {
                             check.KTX0020_ID,
                             check.MKV9999_ID,
                             check.ngaytaodon,
                             check.trangthai,
                             check.bengiao,
                             check.bennhan,
                             check.capbac,
                             check.bietngoaingu,
                             check.biettiengdantocitnguoi,
                             check.bqlktx,
                             check.choohiennay,
                             check.chunhiemnoilamviec,
                             check.cmtnd_ngaycap,
                             check.cmtnd_noicap,
                             check.cmtnd_so,
                             check.dantoc,
                             check.didong,
                             check.ghichu,
                             check.gioitinh,
                             check.hotenkhac,
                             check.hotenkhaisinh,
                             check.khoaphong,
                             check.KTX0001_ID,
                             check.KTX0002_ID,
                             check.KTX0003_ID,
                             check.lamgiodautu14tuoi,
                             check.lydo,
                             check.lydodangkyoktx,
                             check.lydonguyenvong,
                             check.ngaycohieuluc,
                             check.ngayduyetdon,
                             check.ngayokitucxa,
                             check.ngayquaylaikytucxa,
                             check.ngaysinh,
                             check.nghenghiepchucvunoilam,
                             check.nguyenvongophongso,
                             check.nharieng,
                             check.noidung,
                             check.noisinh,
                             check.noithuongtru,
                             check.okitucxa,
                             check.quaylaikytucxa,
                             check.quequan,
                             check.sokhoatu,
                             check.somayle,
                             check.sotu,
                             check.thoigiantralantruoc,
                             check.tienantoidanhhinhphat,
                             check.tongiao,
                             check.trinhdchuyenmon,
                             check.trinhdohocvan,
                             check.truongphongGA,
                             check.truongphongnoilamviec,
                             KTX0001 = db.KTX0001.Where(p => p.KTX0001_ID == check.KTX0001_ID).FirstOrDefault(),
                             KTX0002 = db.KTX0002.Where(p => p.KTX0002_ID == check.KTX0002_ID).FirstOrDefault(),
                             KTX0021 = db.KTX0021.Where(p => p.KTX0020_ID == check.KTX0020_ID).ToList(),
                             KTX0022 = db.KTX0022.Where(p => p.KTX0020_ID == check.KTX0020_ID).ToList(),
                             MKV9999 = (from f in db.MKV9999
                                        where check.MKV9999_ID == f.MKV9999_ID
                                        select new
                                        {
                                            f.MKV9999_ID,
                                            f.manhansu,
                                            f.matkhau,
                                            f.id,
                                            f.type,
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
                         }).FirstOrDefault();
                return REST.GetHttpResponseMessFromObject (k);
            }
        }
        public struct search
        {
            public Nullable<DateTime> startdate { get; set; }
            public Nullable<DateTime> enddate { get; set; }
            public Nullable<bool> trangthai { get; set; }
            public Nullable<bool> trangthai2 { get; set; }
            public string ID { get; set; }
        }
        [Route("DangOKTX")]
        [HttpPost]
        public HttpResponseMessage DangOKTX([FromBody]search value)
        {
            var db = new DB();

            var table = db.KTX0020.Where(p=>p.trangthai==value.trangthai&&p.trangthai2==value.trangthai2).AsEnumerable().Select(check => new
            {
                check.KTX0020_ID,
                check.MKV9999_ID,
                check.ngaytaodon,
                check.capbac,
                check.trangthai,
                check.bengiao,
                check.bennhan,
                check.bietngoaingu,
                check.biettiengdantocitnguoi,
                check.bqlktx,
                check.choohiennay,
                check.chunhiemnoilamviec,
                check.cmtnd_ngaycap,
                check.cmtnd_noicap,
                check.cmtnd_so,
                check.dantoc,
                check.didong,
                check.ghichu,
                check.gioitinh,
                check.hotenkhac,
                check.hotenkhaisinh,
                check.khoaphong,
                check.KTX0001_ID,
                check.KTX0002_ID,
                check.KTX0003_ID,
                check.lamgiodautu14tuoi,
                check.lydo,
                check.lydodangkyoktx,
                check.lydonguyenvong,
                check.ngaycohieuluc,
                check.ngayduyetdon,
                check.ngayokitucxa,
                check.ngayquaylaikytucxa,
                check.ngaysinh,
                check.nghenghiepchucvunoilam,
                check.nguyenvongophongso,
                check.nharieng,
                check.noidung,
                check.noisinh,
                check.noithuongtru,
                check.okitucxa,
                check.quaylaikytucxa,
                check.quequan,
                check.sokhoatu,
                check.somayle,
                check.sotu,
                check.thoigiantralantruoc,
                check.tienantoidanhhinhphat,
                check.tongiao,
                check.trinhdchuyenmon,
                check.trinhdohocvan,
                check.truongphongGA,
                //timkiem = timkiem.tim(new searchkey() { key = check.cmtnd_so }),
                check.truongphongnoilamviec,
                KTX0001 = db.KTX0001.Where(p => p.KTX0001_ID == check.KTX0001_ID).Select(p => new { p.ghichu, p.idcha, p.khu, p.KTX0001_ID, p.makhoa, p.slot, p.ten, p.thutu, p.trangthai, p.type }).FirstOrDefault(),
                KTX0002 = db.KTX0002.Where(p => p.KTX0002_ID == check.KTX0002_ID).Select(p => new { p.ghichu, p.KTX0001_ID,  p.KTX0002_ID,p.ten, p.thutu, p.trangthai, p.type }).FirstOrDefault(),
                KTX0003 = db.KTX0003.Where(p => p.KTX0003_ID == check.KTX0003_ID).Select(p => new { p.ghichu,  p.KTX0003_ID,p.MaKhoa,  p.trangthai, p.type }).FirstOrDefault(),
                KTX0021 = db.KTX0021.Where(p => p.KTX0020_ID == check.KTX0020_ID).Select(p => new { p.batdau, p.choo, p.ketthuc, p.KTX0020_ID, p.KTX0021_ID, p.nghenghiepnoilam }).ToList(),
                KTX0022 = db.KTX0022.Where(p => p.KTX0020_ID == check.KTX0020_ID).Select(p => new { p.ChoOHienNay, p.HoTen, p.KTX0020_ID, p.KTX0022_ID, p.NamSinh, p.NgheNghiep, p.QuanHe }).ToList(),
                MKV9999 = (db.MKV9999.Where(f => check.MKV9999_ID == f.MKV9999_ID)).ToList().Select(f => new
                {
                    f.MKV9999_ID,
                    f.manhansu,
                    f.matkhau,
                    f.id,
                    f.hodem,
                    f.type,
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
                    bophan = db.MKV9998.FirstOrDefault(klj => klj.phong_id == f.phong_id),
                    ban = db.MKV9998.FirstOrDefault(klj => klj.phong_id == f.ban_id),
                    thetu_id = db.MKV9998.FirstOrDefault(klj => klj.phong_id == f.phong_id) != null ? db.MKV9998.FirstOrDefault(klj => klj.phong_id == f.phong_id).bophan_ten : "",
                }).FirstOrDefault(),
            });
            if (value.ID != null&&value.ID.Trim()!="")
            {
                var ou = (db.MKV9999.SingleOrDefault(o => o.manhansu == (value.ID)));
                if(ou!=null)
                table = table.Where(p => p.MKV9999_ID==ou.MKV9999_ID);
                else table = table.Where(p => p.MKV9999_ID == 0);
            }
            if (value.startdate != null)
            {
                table = table.Where(p => p.ngaycohieuluc.Value.Date >= value.startdate.Value.Date);
            }
            if (value.enddate != null)
            {
                table = table.Where(p => p.ngaycohieuluc.Value.Date <= value.enddate.Value.Date);
            }
            return REST.GetHttpResponseMessFromObject(table.ToList());
        }

        [Route("upload")]
        [HttpPost]
        public HttpResponseMessage upload([FromBody]KTX0020[] valuess)
        {
            if (valuess == null) return null;
            using (DB db = new DB())
            {
                var taisan = db.KTX0010.Where(p => p.trangthai == true&&p.loai==2&&p.soluongmacdinh>0).Select(p => new
                {
                    p.ghichu,
                    p.giatien,
                    p.KTX0010_ID,
                    p.loai,
                    p.soluongmacdinh,
                    p.soluongfull,
                    p.ten,
                    p.thutu,
                    p.trangthai,
                    p.WH0007_ID,
                    p.maSanPham,
                });
                results<KTX0020> list = new results<KTX0020>();
                valuess.ToList().ForEach(values =>
                {
                    result<KTX0020> rel = new result<KTX0020>();
                    try
                    {
                        KTX0020 newktx0020 = new KTX0020()
                        {
                            KTX0020_ID = values.KTX0020_ID,
                            MKV9999_ID = values.MKV9999_ID,
                            ngaytaodon = values.ngaytaodon,
                            trangthai = values.trangthai,
                            trangthai2 = values.trangthai2,
                            bengiao = values.bengiao,
                            bennhan = values.bennhan,
                            bietngoaingu = values.bietngoaingu,
                            biettiengdantocitnguoi = values.biettiengdantocitnguoi,
                            bqlktx = values.bqlktx,
                            choohiennay = values.choohiennay,
                            chunhiemnoilamviec = values.chunhiemnoilamviec,
                            cmtnd_ngaycap = values.cmtnd_ngaycap,
                            cmtnd_noicap = values.cmtnd_noicap,
                            cmtnd_so = values.cmtnd_so,
                            dantoc = values.dantoc,
                            didong = values.didong,
                            ghichu = values.ghichu,
                            ghichu2 = values.ghichu2,
                            gioitinh = values.gioitinh,
                            hotenkhac = values.hotenkhac,
                            hotenkhaisinh = values.hotenkhaisinh,
                            khoaphong = db.KTX0001.Where(p => p.ten == values.ghichu2).Select(p => p.makhoa).FirstOrDefault(),
                            KTX0001_ID = db.KTX0001.Where(p=>p.ten==values.ghichu2).Select(p=>p.KTX0001_ID).FirstOrDefault(),
                            KTX0002_ID = db.KTX0002.Where(p => p.KTX0001_ID== db.KTX0001.Where(pp => pp.ten == values.ghichu2).Select(pp => pp.KTX0001_ID).FirstOrDefault()&&p.trangthai==false).Select(p => p.KTX0002_ID).FirstOrDefault(),
                            KTX0003_ID = db.KTX0003.Where(p => p.MaKhoa == values.sokhoatu).Select(p => p.KTX0003_ID).FirstOrDefault(),
                            lamgiodautu14tuoi = values.lamgiodautu14tuoi,
                            lydo = values.lydo,
                            lydodangkyoktx = values.lydodangkyoktx,
                            lydonguyenvong = values.lydonguyenvong,
                            ngaycohieuluc = values.ngaycohieuluc,
                            ngayduyetdon = values.ngayduyetdon,
                            ngayokitucxa = values.ngayokitucxa,
                            ngayquaylaikytucxa = values.ngayquaylaikytucxa,
                            ngaysinh = values.ngaysinh,
                            nghenghiepchucvunoilam = values.nghenghiepchucvunoilam,
                            nguyenvongophongso = values.nguyenvongophongso,
                            nharieng = values.nharieng,
                            noidung = values.noidung,
                            noisinh = values.noisinh,
                            noithuongtru = values.noithuongtru,
                            okitucxa = values.okitucxa,
                            quaylaikytucxa = values.quaylaikytucxa,
                            quequan = values.quequan,
                            sokhoatu = db.KTX0003.Where(p => p.KTX0001_ID == db.KTX0001.Where(pp => pp.ten == values.ghichu2).Select(pp => pp.KTX0001_ID).FirstOrDefault() && p.trangthai == false).Select(p => p.SoTu).FirstOrDefault(),
                            somayle = values.somayle,
                            sotu = db.KTX0003.Where(p => p.KTX0001_ID == db.KTX0001.Where(pp => pp.ten == values.ghichu2).Select(pp => pp.KTX0001_ID).FirstOrDefault() && p.trangthai == false).Select(p => p.MaKhoa).FirstOrDefault(),
                            thoigiantralantruoc = values.thoigiantralantruoc,
                            tongiao = values.tongiao,
                            trinhdchuyenmon = values.trinhdchuyenmon,
                            trinhdohocvan = values.trinhdohocvan,
                            tienantoidanhhinhphat = values.tienantoidanhhinhphat,
                            truongphongGA = values.truongphongGA,
                            truongphongnoilamviec = values.truongphongnoilamviec,
                            KTX0021 = values.KTX0021,
                            KTX0022 = values.KTX0022,
                            capbac = values.capbac
                        };
                        newktx0020.trangthai2 = false;
                        newktx0020.MKV9999 = null;
                        db.KTX0020.Add(newktx0020);
                        db.SaveChanges();
                         db.KTX0003.Where(p => p.KTX0003_ID == newktx0020.KTX0003_ID).ToList().ForEach(k =>
                        {
                            k.trangthai = true;
                        });
                         db.KTX0002.Where(p => p.KTX0002_ID == newktx0020.KTX0002_ID).ToList().ForEach(k =>
                        {
                            k.trangthai = true;
                        });
                        db.SaveChanges();
                        taisan.ToList().ForEach(val =>
                        {
                            var check = db.KTX0031.FirstOrDefault(p => p.KTX0010_ID == val.KTX0010_ID && p.MKV9999_ID == newktx0020.MKV9999_ID && p.trangthai == true);
                            if (check == null)
                            {
                                db.KTX0031.Add(new KTX0031()
                                {
                                    ghichu = "Thêm từ chức năng upload file excel",
                                    KTX0010_ID=val.KTX0010_ID,
                                    MKV9999_ID=newktx0020.MKV9999_ID,
                                    ngaycap=newktx0020.ngayduyetdon,
                                    soluongcap=val.soluongmacdinh,
                                    trangthai=true,
                                    
                                });
                                try
                                {
                                    //db.SaveChanges();
                                }
                                catch 
                                {
                                }
                            }
                        });
                        values.KTX0020_ID = newktx0020.KTX0020_ID;
                        rel.set("OK", values, "Thành công");
                    }
                    catch (ContextMarshalException rr)
                    {

                        rel.set("ERR", values, "Thất bại: " + rr.Message);
                    }
                    list.add(rel);
                }); db.SaveChanges();
                return list.ToHttpResponseMessage();
            }
        }
    }
}
