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
    [RoutePrefix("api/QLSP")]
    public class QLSPController : ApiController
    {
        [Route("GetAllEp")]
        [HttpGet]
        public HttpResponseMessage GetAllEp()
        {
            using (var db = new DB())
            {
                var table = from k in db.KTX0020
                            where k.KTX0002_ID == null && k.trangthai == true && k.trangthai2 != true
                            select new
                            {
                                k.KTX0020_ID,
                                k.MKV9999_ID,
                                k.okitucxa,
                                k.ngayokitucxa,
                                k.quaylaikytucxa,
                                k.ngayquaylaikytucxa,
                                k.thoigiantralantruoc,
                                k.lydodangkyoktx,
                                k.nguyenvongophongso,
                                k.lydonguyenvong,
                                k.somayle,
                                k.didong,
                                k.capbac,
                                k.nharieng,
                                k.chunhiemnoilamviec,
                                k.truongphongnoilamviec,
                                k.bqlktx,
                                k.truongphongGA,
                                k.KTX0001_ID,
                                k.KTX0002_ID,
                                k.khoaphong,
                                k.sotu,
                                k.sokhoatu,
                                k.ngaycohieuluc,
                                k.bengiao,
                                k.bennhan,
                                k.hotenkhaisinh,
                                k.gioitinh,
                                k.hotenkhac,
                                k.ngaysinh,
                                k.noisinh,
                                k.quequan,
                                k.dantoc,
                                k.tongiao,
                                k.cmtnd_so,
                                k.cmtnd_ngaycap,
                                k.cmtnd_noicap,
                                k.noithuongtru,
                                k.choohiennay,
                                k.trinhdohocvan,
                                k.trinhdchuyenmon,
                                k.biettiengdantocitnguoi,
                                k.bietngoaingu,
                                k.nghenghiepchucvunoilam,
                                k.lamgiodautu14tuoi,
                                k.ngaytaodon,
                                k.ngayduyetdon,
                                k.noidung,
                                k.lydo,
                                k.ghichu,
                                k.trangthai,
                                MKV9999 = (from f in db.MKV9999
                                           where k.MKV9999_ID == f.MKV9999_ID
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
                                               thetu_id = (from t in db.MKV9998 where t.phong_id == f.phong_id select t.bophan_ten).FirstOrDefault(),
                                           }).FirstOrDefault(),
                            };
                return (REST.GetHttpResponseMessFromObject(table));
            }
        }



        [Route("AddEPToGiuong/{id}")]
        [HttpPost]
        public HttpResponseMessage AddEPToGiuong(int id, [FromBody]KTX0020 EP)
        {
            using (var db = new DB())
            {
                result<KTX0020> rel = new result<KTX0020>();
                if (EP.KTX0002_ID == null)
                {
                    var check = (from temp in db.KTX0020 where temp.KTX0020_ID == EP.KTX0020_ID select temp).FirstOrDefault();
                    if (check != null)
                    {
                        var ktx02 = db.KTX0002.SingleOrDefault(p => p.KTX0002_ID == id);
                        if (ktx02.trangthai == false)
                        {
                            var ktx1 = db.KTX0001.SingleOrDefault(p => p.KTX0001_ID == ktx02.KTX0001_ID);
                            check.khoaphong = ktx1 != null ? ktx1.makhoa : "";
                            check.KTX0002_ID = id;
                            check.KTX0001_ID = ktx02.KTX0001_ID;
                            try
                            {
                                db.SaveChanges();
                                ktx02.trangthai = true;
                                db.SaveChanges();
                                check.MKV9999 = EP.MKV9999;
                                rel.set("OK", check, "Thành công");
                            }
                            catch (Exception d)
                            {
                                rel.set("ERR", EP, "Thất bại: " + d.Message);
                            }
                        }
                        else
                            rel.set("ERR", EP, "Thất bại: Giường này đã có người ở.");
                    }
                }
                return ( rel.ToHttpResponseMessage());
            }
        }
        public struct arr
        {
            public KTX0001[] arrPhong { get; set; }
            public KTX0020[] EPs { get; set; }
        }
        [Route("AddEPToGiuongAuto")]
        [HttpPost]
        public HttpResponseMessage AddEPToGiuongAuto([FromBody]arr values)
        {
            //return null;
            using (var db = new DB())
            {
                results<KTX0020>  rels = new results<KTX0020> ();
                var li = values.arrPhong.ToList().Select(p => p.KTX0001_ID).ToList();
                var listgiuong = (from t in db.KTX0002 where li.Contains(t.KTX0001_ID) && t.trangthai == false select t).ToList();
                for (int i = 0; i < values.EPs.Length; i++)
                {
                    result<KTX0020> rel = new result<KTX0020>();
                    if (i < listgiuong.Count)
                    {
                        if (values.EPs[i].KTX0002_ID == null)
                        {
                            int idd = values.EPs[i].KTX0020_ID;
                            var check = (from temp in db.KTX0020 where  temp.KTX0020_ID==idd select temp).FirstOrDefault();
                            if (check != null && check.KTX0002_ID == null)
                            {
                                int idg = listgiuong[i].KTX0002_ID;
                                var ktx02 = db.KTX0002.SingleOrDefault(p => p.KTX0002_ID ==idg );
                                var chiakhoa = (from chia in db.KTX0003 where (chia.trangthai == false || chia.trangthai == null) && chia.KTX0001_ID == ktx02.KTX0001_ID select chia).FirstOrDefault();

                                var ktx1 = db.KTX0001.SingleOrDefault(p => p.KTX0001_ID == ktx02.KTX0001_ID);
                                check.khoaphong = ktx1 != null ? ktx1.makhoa : "";
                                values.EPs[i].khoaphong=check.khoaphong;

                                check.KTX0002_ID = ktx02.KTX0002_ID;
                                check.KTX0001_ID = ktx02.KTX0001_ID;
                                if (chiakhoa != null)
                                {
                                    check.KTX0003_ID = chiakhoa.KTX0003_ID;
                                    check.sokhoatu = chiakhoa.MaKhoa;
                                    check.sotu = chiakhoa.SoTu;
                                    values.EPs[i].KTX0003_ID = chiakhoa.KTX0003_ID;
                                    values.EPs[i].sokhoatu = chiakhoa.MaKhoa;
                                    values.EPs[i].sotu = chiakhoa.SoTu;
                                    chiakhoa.trangthai = true;
                                }
                                try
                                {
                                    db.SaveChanges();
                                    ktx02.trangthai = true;
                                    db.SaveChanges();
                                    values.EPs[i].KTX0001_ID = ktx02.KTX0001_ID;
                                    values.EPs[i].KTX0002_ID = ktx02.KTX0002_ID;
                                    rel.set("OK", values.EPs[i], "Thành công");
                                }
                                catch (Exception d)
                                {
                                    rel.set("ERR", values.EPs[i], "Thất bại: " + d.Message);
                                }

                            }
                            else if (check != null)
                            {
                                var kk = db.KTX0002.FirstOrDefault(p => p.KTX0002_ID == check.KTX0002_ID);
                                rel.set("ERR", values.EPs[i], "Thất bại: Người này đã ở một giường khác mã: " + (kk != null ? kk.ten : ""));
                            }
                        }
                        else
                        {
                            //người này đã có giường rồi
                            rel.set("ERR", values.EPs[i], "Thất bại: người này đã có giường rồi");
                        }
                    }
                    else
                    {

                    }
                    rels.add(rel);
                }
                return  (rels.ToHttpResponseMessage());
            }
        }

        [Route("DeleteBed")]
        [HttpPost]
        public HttpResponseMessage DeleteBed([FromBody]KTX0002[] EPs)
        {
            using (var db = new DB())
            {
                results<KTX0002> list = new results<KTX0002>();
                foreach (var EP in EPs)
                {
                    result<KTX0002> rel = new result<KTX0002>();
                    var check = (from temp in db.KTX0020 where temp.KTX0002_ID == EP.KTX0002_ID select temp).FirstOrDefault();
                    if (check != null)
                    {
                        check.KTX0002_ID = null;
                        check.KTX0001_ID = null;
                        check.KTX0003_ID = null;
                        check.khoaphong = null;
                        check.sotu = null;
                        string sokhoatu = check.sokhoatu;
                        check.sokhoatu = null;
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", EP, "Thành công");
                            var k = db.KTX0002.FirstOrDefault(p => p.KTX0002_ID == EP.KTX0002_ID);
                            k.trangthai = false;
                            db.SaveChanges();
                            if (sokhoatu != null)
                            {
                                var kk = db.KTX0003.FirstOrDefault(p => p.MaKhoa == sokhoatu);
                                if (kk != null)
                                {
                                    kk.trangthai = false;
                                    db.SaveChanges();
                                }

                            }
                        }
                        catch (Exception j)
                        {
                            rel.set("ERR", EP, "Thất bại: " + j.Message);
                        }
                    }
                    else
                    {
                        rel.set("ERR", EP, "Không có dữ liệu");
                    }
                    list.add(rel);
                }
                return (list.ToHttpResponseMessage());
            }
        }
    }
}
