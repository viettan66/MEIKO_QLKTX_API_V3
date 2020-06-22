using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MEIKO_QLKTX_API_V1.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

public static class timkiem
    {

        public static HttpResponseMessage tim(searchkey value)
        {
            using (var db = new DB())
            {
               valuesearch result = new valuesearch();
                result.KTX0020 =  db.KTX0020.AsEnumerable().Where(temp=>
                                  temp.hotenkhaisinh == value.key ||
                                    temp.hotenkhac == value.key ||
                                    temp.cmtnd_so == value.key ||
                                    temp.didong == value.key ||
                                    temp.MKV9999_ID == (db.MKV9999.Where(p => p.manhansu == value.key).Select(p=>p.MKV9999_ID).FirstOrDefault()) ||
                                    temp.khoaphong == value.key //||
                                    //temp.sotu == value.key ||
                                    //temp.sokhoatu == value.key ||
                                    //temp.KTX0001_ID != null && temp.KTX0001_ID == (db.KTX0001.Where(p => p.ten == value.key).Select(p => p.KTX0001_ID).FirstOrDefault()) ||
                                    //temp.KTX0002_ID != null && temp.KTX0002_ID == (db.KTX0002.Where(p => p.ten == value.key).Select(p => p.KTX0002_ID).FirstOrDefault()) ||
                                    //temp.KTX0003_ID != null && temp.KTX0003_ID == (db.KTX0003.Where(p => p.SoTu == value.key).Select(p => p.KTX0003_ID).FirstOrDefault())
                                  ).Select(temp=> new
                                  {
                                      temp.KTX0020_ID,
                                      temp.MKV9999_ID,
                                      temp.ngaytaodon,
                                      temp.trangthai,
                                      temp.bengiao,
                                      temp.bennhan,
                                      temp.bietngoaingu,
                                      temp.biettiengdantocitnguoi,
                                      temp.bqlktx,
                                      temp.choohiennay,
                                      temp.chunhiemnoilamviec,
                                      temp.cmtnd_ngaycap,
                                      temp.cmtnd_noicap,
                                      temp.cmtnd_so,
                                      temp.dantoc,
                                      temp.didong,
                                      temp.ghichu,
                                      temp.gioitinh,
                                      temp.hotenkhac,
                                      temp.hotenkhaisinh,
                                      temp.khoaphong,
                                      temp.KTX0001_ID,
                                      temp.KTX0002_ID,
                                      temp.KTX0003_ID,
                                      temp.lamgiodautu14tuoi,
                                      temp.lydo,
                                      temp.lydodangkyoktx,
                                      temp.lydonguyenvong,
                                      temp.ngaycohieuluc,
                                      temp.ngayduyetdon,
                                      temp.ngayokitucxa,
                                      temp.ngayquaylaikytucxa,
                                      temp.ngaysinh,
                                      temp.nghenghiepchucvunoilam,
                                      temp.nguyenvongophongso,
                                      temp.nharieng,
                                      temp.noidung,
                                      temp.noisinh,
                                      temp.noithuongtru,
                                      temp.okitucxa,
                                      temp.quaylaikytucxa,
                                      temp.quequan,
                                      temp.sokhoatu,
                                      temp.somayle,
                                      temp.sotu,
                                      temp.thoigiantralantruoc,
                                      temp.tongiao,
                                      temp.trinhdchuyenmon,
                                      temp.trinhdohocvan,
                                      temp.truongphongGA,
                                      temp.truongphongnoilamviec,
                                      KTX0001 = db.Database.SqlQuery<KTX0001>("select * from ktx0001 where KTX0001_id=" + (temp.KTX0001_ID != null ? temp.KTX0001_ID : 0)).FirstOrDefault(),
                                      KTX0002 = db.Database.SqlQuery<KTX0002>("select * from ktx0002 where KTX0002_id=" + (temp.KTX0002_ID != null ? temp.KTX0002_ID : 0)).FirstOrDefault(),
                                      KTX0003 = db.Database.SqlQuery<KTX0003>("select * from ktx0003 where KTX0003_id=" + (temp.KTX0003_ID != null ? temp.KTX0003_ID : 0)).FirstOrDefault(),
                                      //KTX0021 = db.KTX0021.Where(p => p.KTX0020_ID == temp.KTX0020_ID).ToList(),
                                      KTX0031 = (from temp2 in db.KTX0031
                                                 where temp2.MKV9999_ID == temp.MKV9999_ID && temp.trangthai == true
                                                 select new
                                                 {
                                                     temp2.ghichu,
                                                     temp2.KTX0010_ID,
                                                     temp2.KTX0031_ID,
                                                     temp2.MKV9999_ID,
                                                     temp2.ngaycap,
                                                     temp2.ngaytra,
                                                     temp2.soluongcap,
                                                     temp2.soluongtra,
                                                     temp2.thutu,
                                                     temp2.trangthai,
                                                     KTX0010 = (from l in db.KTX0010
                                                                where l.KTX0010_ID == temp2.KTX0010_ID
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
                                                 }),
                                      MKV9999 = (from f in db.MKV9999
                                                 where temp.MKV9999_ID == f.MKV9999_ID
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
                                  }).ToList();
                result.KTX0023 = (from temp in db.KTX0023
                                  where temp.nldhoten == value.key ||
                                    temp.MKV9999_ID == (db.MKV9999.FirstOrDefault(p => p.cmtnd_so == value.key).MKV9999_ID) ||
                                    temp.MKV9999_ID == (db.MKV9999.FirstOrDefault(p => p.manhansu == value.key).MKV9999_ID) ||
                                    temp.didong == value.key ||
                                    temp.khoaphong == value.key ||
                                    temp.sotu == value.key ||
                                    temp.sokhoatu == value.key ||
                                    temp.KTX0001_ID == (db.KTX0001.FirstOrDefault(p => p.ten == value.key).KTX0001_ID) ||
                                    temp.KTX0002_ID == (db.KTX0002.FirstOrDefault(p => p.ten == value.key).KTX0002_ID) ||
                                    temp.KTX0003_ID == (db.KTX0003.FirstOrDefault(p => p.MaKhoa == value.key).KTX0003_ID)
                                  select new
                                  {
                                      temp.banqlktx,
                                      temp.bqlhoten,
                                      temp.bqlkynhan,
                                      temp.chunhiemGA,
                                      temp.chunhiemnoilam,
                                      temp.didong,
                                      temp.khoaphong,
                                      temp.KTX0001_ID,
                                      temp.KTX0002_ID,
                                      temp.KTX0003_ID,
                                      temp.KTX0023_ID,
                                      temp.lydotra,
                                      temp.MKV9999_ID,
                                      temp.ngaycohieuluc,
                                      temp.ngaytrakytucxa,
                                      temp.nldhoten,
                                      temp.nhanxet,
                                      temp.nldkynhan,
                                      temp.sokhoatu,
                                      temp.somayle,
                                      temp.sotu,
                                      temp.tonggiatriboithuong,
                                      temp.trakytucxa,
                                      temp.truongphongnoilam,
                                      temp.trangthai,
                                      temp.ngaytaodon,
                                      KTX0001 = db.KTX0001.Where(p => p.KTX0001_ID == temp.KTX0001_ID).FirstOrDefault(),
                                      KTX0002 = db.KTX0002.Where(p => p.KTX0002_ID == temp.KTX0002_ID).FirstOrDefault(),
                                      MKV9999 = (from f in db.MKV9999
                                                 where temp.MKV9999_ID == f.MKV9999_ID
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
                                      KTX0031 = (from temp2 in db.KTX0031
                                                 where temp2.MKV9999_ID == temp.MKV9999_ID && temp.trangthai == true
                                                 select new
                                                 {
                                                     temp2.ghichu,
                                                     temp2.KTX0010_ID,
                                                     temp2.KTX0031_ID,
                                                     temp2.MKV9999_ID,
                                                     temp2.ngaycap,
                                                     temp2.ngaytra,
                                                     temp2.soluongcap,
                                                     temp2.soluongtra,
                                                     temp2.thutu,
                                                     temp2.trangthai,
                                                     KTX0010 = (from l in db.KTX0010
                                                                where l.KTX0010_ID == temp2.KTX0010_ID
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
                                  }).ToList();

                return (REST.GetHttpResponseMessFromObject( result));

            }
        }
    }

