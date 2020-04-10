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
    [RoutePrefix("api/KTX0002")]
    public class KTX0002Controller : ApiController
    {

        [Route("Add")]
        [HttpPost]
        public HttpResponseMessage Add([FromBody]KTX0002[] values)
        {
            if (values == null) return null;
            using (DB db = new DB())
            {
                results<KTX0002> list = new results<KTX0002>();
                foreach (var value in values)
                {
                    result<KTX0002> rel = new result<KTX0002>();
                    var checkphong = db.KTX0001.Where(p => p.KTX0001_ID == value.KTX0001_ID || p.ten == value.ghichu).FirstOrDefault();
                    if (checkphong != null)
                    {
                        var checkmakhoa = db.KTX0002.FirstOrDefault(p => p.ten == value.ten);
                        if (checkmakhoa == null)
                        {
                            KTX0002 k = new KTX0002() { KTX0001_ID = checkphong.KTX0001_ID, ghichu = value.ghichu, ten = value.ten,   trangthai = value.trangthai, type = value.type };
                            db.KTX0002.Add(k);
                            try
                            {
                                db.SaveChanges();
                                //k.KTX0001 = null;
                                rel.set("OK", k, "Thành Công.");
                            }
                            catch (Exception t)
                            {
                                rel.set("ERR", value, "Thất bại: " + t.Message);
                            }
                        }
                        else
                        {
                            rel.set("ERR", value, "Thất bại: Mã khóa phòng này đã tồn tại.");
                        }
                    }
                    else
                    {
                        rel.set("NaN", value, "Thất bại: Không tìm thấy thông tin phòng.");
                    }
                    list.add(rel);
                }
                return list.ToHttpResponseMessage();
            }
        }
        [Route("Getall/{id}")]
        [HttpGet]
        public HttpResponseMessage Getall(int id)
        {

            using (DB db = new DB())
            {
                var data = (from temp in db.KTX0002
                            where temp.KTX0001_ID == id
                            select new
                            {
                                temp.ghichu,
                                temp.KTX0001_ID,
                                temp.KTX0002_ID,
                                temp.ten,
                                temp.thutu,
                                temp.trangthai,
                                KTX0001 = db.KTX0001.Where(p=>p.KTX0001_ID==temp.KTX0001_ID).Select(p=>new { p.ghichu,p.idcha,p.khu,p.KTX0001_ID,p.makhoa,p.slot,p.ten,p.thutu,p.trangthai,p.type}).FirstOrDefault(),
                                KTX0020 = (from k in db.KTX0020
                                           where k.KTX0002_ID == temp.KTX0002_ID && k.trangthai2 != true
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
                                                              //thetu_id = (from t in db.MKV9998 where t.phong_id == f.phong_id select t.bophan_ten).FirstOrDefault(),
                                                          }).FirstOrDefault(),
                                           }).FirstOrDefault()
                            }).OrderBy(p => p.ten);
                return  REST.GetHttpResponseMessFromObject(data.ToList());
            }
        }
        [Route("Get/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {

            using (DB db = new DB())
            {
                var data = (from temp in db.KTX0002
                            where temp.KTX0002_ID == id
                            select new
                            {
                                temp.ghichu,
                                temp.KTX0001_ID,
                                temp.KTX0002_ID,
                                temp.ten,
                                temp.thutu,
                                temp.trangthai,
                                KTX0001 = (from l in db.KTX0001 where l.KTX0001_ID == temp.KTX0001_ID select new { l.ten }).FirstOrDefault(),
                                KTX0020 = (from k in db.KTX0020
                                           where k.KTX0002_ID == temp.KTX0002_ID && k.trangthai2 != true
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
                                           }).FirstOrDefault()
                            }).FirstOrDefault();
                return  REST.GetHttpResponseMessFromObject(data);
            }
        }

        [Route("Delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            using (DB db = new DB())
            {
                result<KTX0002> rel = new result<KTX0002>();
                var check = db.KTX0002.SingleOrDefault(p => p.KTX0002_ID == id);
                if (check != null)
                {
                    var check2 = db.KTX0020.FirstOrDefault(p => p.KTX0002_ID == check.KTX0002_ID);
                    if (check2 != null)
                    {
                        rel.set("ERR", check, "Thất bại: Giường này đang có người ở, Hãy chuyển người này ra ngoài trước khi xóa giường.");
                    }
                    else
                    {
                        db.KTX0002.Remove(check);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", check, "Thành công.");
                        }
                        catch (Exception t)
                        {
                            rel.set("ERR", check, "Thất bại: " + t.Message);
                        }
                    }
                }
                return rel.ToHttpResponseMessage();
            }
        }
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage update([FromBody]KTX0002 value)
        {
            using (DB db = new DB())
            {
                result<KTX0002> rel = new result<KTX0002>();
                var check = db.KTX0002.SingleOrDefault(p => p.KTX0002_ID == value.KTX0002_ID);
                if (check != null)
                {
                    check.ten = value.ten;
                    check.ghichu = value.ghichu;
                    try
                    {
                        db.SaveChanges();
                        rel.set("OK", check, "Thành công.");
                    }
                    catch (Exception t)
                    {
                        rel.set("ERR", check, "Thất bại: " + t.Message);
                    }
                }
                else
                    rel.set("NaN", check, "Thất bại: Không tìm thấy bản ghi.");
                return  rel.ToHttpResponseMessage();
            }
        }
        public struct datacount
        {
            public int countphongtrong { get; set; }
            public int countphongdung { get; set; }
            public int sumphong { get; set; }
            public int countgiuongtrong { get; set; }
            public int countgiuongdung { get; set; }
            public int sumgiuong { get; set; }
        }
        [Route("getcount")]
        [HttpGet]
        public HttpResponseMessage getcount()
        {
            using (DB db = new DB())
            {
                datacount data = new datacount()
                {
                    sumphong = (from temp in db.KTX0001 where temp.type == 4 select temp.KTX0001_ID).Count(),
                    countphongtrong = (from temp in db.KTX0001 where temp.type == 4 && !(from k in db.KTX0020 where k.KTX0001_ID != null select k.KTX0001_ID).Distinct().Contains(temp.KTX0001_ID) select temp.KTX0001_ID).Count(),
                    countphongdung = (from temp in db.KTX0001 where temp.type == 4 && !(from k in db.KTX0020 where k.KTX0001_ID != null select k.KTX0001_ID).Distinct().Contains(temp.KTX0001_ID) select temp.KTX0001_ID).Count(),
                    sumgiuong = (from temp in db.KTX0002 select temp.KTX0002_ID).Count(),
                    countgiuongtrong = (from temp in db.KTX0002 where temp.trangthai == false || temp.trangthai == null select temp.KTX0002_ID).Distinct().Count(),
                    countgiuongdung = (from temp in db.KTX0002 where temp.trangthai == true select temp.KTX0002_ID).Distinct().Count(),

                };
               return  REST.GetHttpResponseMessFromObject(data);
            }
        }
    }
}
