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
    [RoutePrefix("api/KTX0003")]
    public class KTX0003Controller : ApiController
    {
        [Route("Get/onPhong/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            using (DB db = new DB())
            {
                var data = (from temp in db.KTX0003
                            where temp.KTX0001_ID == id
                            select new
                            {
                                temp.KTX0001_ID,
                                temp.KTX0003_ID,
                                temp.MaKhoa,
                                temp.trangthai,
                                temp.ghichu,
                                temp.SoTu,
                                temp.type,
                                KTX0001 = (from k in db.KTX0001
                                           where k.KTX0001_ID == temp.KTX0001_ID
                                           select new
                                           {
                                               k.ghichu,
                                               k.idcha,
                                               k.khu,
                                               k.KTX0001_ID,
                                               k.slot,
                                               k.ten,
                                               k.thutu,
                                               k.trangthai,
                                               k.type
                                           }),
                                KTX0020 = (from k in db.KTX0020
                                           where k.sokhoatu == temp.MaKhoa && k.trangthai2 != true
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
                            });
                return REST.GetHttpResponseMessFromObject(data.ToList());
            }
        }
        [Route("Add")]
        [HttpPost]
        public HttpResponseMessage Add([FromBody]KTX0003[] values)
        {
            if (values == null) return null;
            using (DB db = new DB())
            {
                results<KTX0003> list = new results<KTX0003>();
                foreach (var value in values)
                {
                    result<KTX0003> rel = new result<KTX0003>();
                    var checkphong = db.KTX0001.Where(p => p.KTX0001_ID == value.KTX0001_ID||p.ten==value.ghichu).FirstOrDefault();
                    if (checkphong != null)
                    {
                        var checkmakhoa = db.KTX0003.SingleOrDefault(p => p.MaKhoa == value.MaKhoa&&value.MaKhoa!=null);
                        if (checkmakhoa == null)
                        {
                            KTX0003 k = new KTX0003() { KTX0001_ID = checkphong.KTX0001_ID, ghichu = value.ghichu, MaKhoa = value.MaKhoa, SoTu = value.SoTu, trangthai = value.trangthai, type = value.type };
                            db.KTX0003.Add(k);
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
                return  list.ToHttpResponseMessage();
            }
        }
        [Route("delete")]
        [HttpPost]
        public HttpResponseMessage delete([FromBody]KTX0003[] values)
        {
            using (DB db = new DB())
            {
                results<KTX0003> list = new results<KTX0003>();
                foreach (var value in values)
                {
                    result<KTX0003> rel = new result<KTX0003>();
                    var check = db.KTX0003.SingleOrDefault(p => p.KTX0003_ID == value.KTX0003_ID);
                    if (check != null)
                    {
                        db.KTX0003.Remove(check);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", value, "Thành Công.");
                            var k20 = db.KTX0020.FirstOrDefault(p => p.sokhoatu == value.MaKhoa);
                            if (k20 != null)
                            {
                                k20.sokhoatu = null;
                                k20.sotu = null;
                                db.SaveChanges();
                            }
                        }
                        catch (Exception t)
                        {
                            rel.set("ERR", value, "Thất bại: " + t.Message);
                        }
                    }
                    else
                        rel.set("NaN", value, "Thất bại: Không tìm thấy thông tin phòng.");
                    list.add(rel);
                }
                return  list.ToHttpResponseMessage();
            }
        }
        [Route("update")]
        [HttpPost]
        public HttpResponseMessage update([FromBody]KTX0003[] values)
        {
            using (DB db = new DB())
            {
                results<KTX0003> list = new results<KTX0003>();
                foreach (var value in values)
                {
                    result<KTX0003> rel = new result<KTX0003>();
                    var check = db.KTX0003.SingleOrDefault(p => p.KTX0003_ID == value.KTX0003_ID);
                    if (check != null)
                    {
                        check.ghichu = value.ghichu;
                        check.MaKhoa = value.MaKhoa;
                        check.SoTu = value.SoTu;
                        check.trangthai = value.trangthai;
                        check.type = value.type;
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", value, "Thành Công.");
                            var k20 = db.KTX0020.FirstOrDefault(p => p.KTX0003_ID == value.KTX0003_ID);
                            if (k20 != null)
                            {
                                k20.sokhoatu = value.MaKhoa;
                                k20.sotu = value.SoTu;
                                db.SaveChanges();
                            }
                        }
                        catch (Exception t)
                        {
                            rel.set("ERR", value, "Thất bại: " + t.Message);
                        }
                    }
                    else
                        rel.set("NaN", value, "Thất bại: Không tìm thấy thông tin phòng.");
                    list.add(rel);
                }
                return  list.ToHttpResponseMessage();
            }
        }
    }
}
