using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.TUYENDUNG
{
    [RoutePrefix("api/RM0010")]
    public class RM0010Controller : ApiController
    {
        [Route("Getall")]
        [HttpPost]
        public HttpResponseMessage Getall([FromBody]ungvienget.filterungvien filter)
        {
            return REST.GetHttpResponseMessFromObject(ungvienget.Getallungvien(filter));
        }
        [Route("GetallCMTND")]
        [HttpPost]
        public HttpResponseMessage GetallCMTND([FromBody]ungvienget.filterungvien cmt)
        {
            return REST.GetHttpResponseMessFromObject(ungvienget.Getallungvien(cmt));
        }
        [Route("updatecomment")]
        [HttpPut]
        public HttpResponseMessage updatecomment([FromBody]RM0010 value)
        {
            using (DB db = new DB())
            {
                result<RM0010> rel = new result<RM0010>();
                var check = db.RM0010.SingleOrDefault(p => p.RM0010_ID == value.RM0010_ID);
                if (check != null)
                {
                    check.ghichu = value.ghichu;
                    try
                    {
                        db.SaveChanges();
                        rel.set("OK", null);
                    }
                    catch (Exception g)
                    {

                        rel.set("ERR", null, g.Message);
                    }
                }
                else rel.set("NaN", null);
                return rel.ToHttpResponseMessage();

            }
        }
        public struct kk
        {
            public string cmt { get; set; }
            public string sdt { get; set; }
            public string email { get; set; }
        }
        [Route("Getghichu")]
        [HttpPost]
        public HttpResponseMessage Getghichu([FromBody]kk values)
        {
            using (DB db = new DB())
            {
                var d = db.RM0010.Where(p => p.CMTND_SO == values.cmt || p.EMAIL == values.email || p.MOBILE == values.sdt).Select(p=>p.ghichu).FirstOrDefault();
                return REST.GetHttpResponseMessFromObject(d);
            }
        }
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]RM0010[] values)
        {
            using (DB db = new DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(value =>
                {
                    result<object> rel = new result<object>();
                    var check = db.RM0010.SingleOrDefault(p => p.RM0010_ID == value.RM0010_ID);
                    if (check == null)
                    {
                        RM0010 newj = value;
                        if (newj.sophieu != null)
                        {
                            newj.A0028_ID = db.A0028.Where(p => p.sophieu == newj.sophieu).Select(p => p.A0028_ID).FirstOrDefault();
                            var rm01_id = db.A0028.Where(p => p.sophieu == newj.sophieu).Select(p => p.T005C).FirstOrDefault();
                            newj.RM0001_ID = rm01_id != null ? int.Parse(rm01_id) : 0;
                            newj.bophanid = db.A0028.Where(p => p.sophieu == newj.sophieu).Select(p => p.T098C).FirstOrDefault();
                        }
                        newj.trangthai = true;
                        db.RM0010.Add(newj);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", ungvienget.Getallungvien(new ungvienget.filterungvien() { id = value.RM0010_ID }), "Thành công");
                        }
                        catch (Exception l)
                        {
                            rel.set("ERR", null, "Thất bại:" + l.Message);
                        }
                    }
                    else
                    {
                        if (ungvienget.updateungvien(value))
                        {
                            rel.set("OK", ungvienget.Getallungvien(new ungvienget.filterungvien() { id = value.RM0010_ID }), "Thành công");
                        }
                        else
                            rel.set("ERR", null, "Thất bại:" );
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }

        [Route("delete")]
        [HttpPut]
        public HttpResponseMessage delete([FromBody]RM0010[] values)
        {
            using (DB db = new DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(value =>
                {
                    result<object> rel = new result<object>();
                    var check = db.RM0010.SingleOrDefault(p => p.RM0010_ID == value.RM0010_ID);
                    if (check != null)
                    {
                        db.RM0010.Remove(check);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", value, "Thành công");
                        }
                        catch (Exception l)
                        {
                            rel.set("ERR", null, "Thất bại:" + l.Message);
                        }
                    }
                    else
                        rel.set("NaN", null, "Không thấy dữ liệu.");
                    list.add(rel);
                });
                return (list.ToHttpResponseMessage());
            }
        }
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage update([FromBody]RM0010 value)
        {
            result<object> rel = new result<object>();
            if (ungvienget.updateungvien(value))
            {
                rel.set("OK", ungvienget.Getallungvien(new ungvienget.filterungvien() { id = value.RM0010_ID }), "Thành công");
                return rel.ToHttpResponseMessage();
            }
            else
            {
                rel.set("ERR", null, "Thất bại:");
                return rel.ToHttpResponseMessage();
                
                //using (DB db = new DB())
                //{
                //    result<object> rel = new result<object>();
                //    var check = db.RM0010.SingleOrDefault(p => p.RM0010_ID == value.RM0010_ID);
                //    if (check != null)
                //    {
                //        check.maID = value.maID;
                //        check.HODEM = value.HODEM;
                //        check.TEN = value.TEN;
                //        check.NGAYSINH = value.NGAYSINH;
                //        check.NOISINH = value.NOISINH;
                //        check.CMTND_SO = value.CMTND_SO;
                //        check.CMTND_NGAYCAP = value.CMTND_NGAYCAP;
                //        check.CMTND_NOICAP = value.CMTND_NOICAP;
                //        check.GIOITINH = value.GIOITINH;
                //        check.HONNHAN = value.HONNHAN;
                //        check.TELEPHONE = value.TELEPHONE;
                //        check.MOBILE = value.MOBILE;
                //        check.CHIEUCAO = value.CHIEUCAO;
                //        check.CANNANG = value.CANNANG;
                //        check.EMAIL = value.EMAIL;
                //        check.THUONGTRU = value.THUONGTRU;
                //        check.TAMTRU = value.TAMTRU;
                //        check.RM0001_ID = value.RM0001_ID;
                //        check.RM0001_ID2 = value.RM0001_ID2;
                //        check.NGAYCOTHELAM = value.NGAYCOTHELAM;
                //        check.THUNHAPMONGMUON = value.THUNHAPMONGMUON;
                //        check.COTHELAMTHEM = value.COTHELAMTHEM;
                //        check.COTHEDICONGTAC = value.COTHEDICONGTAC;
                //        check.COTHETHAYDOIDIADIEM = value.COTHETHAYDOIDIADIEM;
                //        check.DATUNGTHITUYENMEIKO = value.DATUNGTHITUYENMEIKO;
                //        check.NEUDATUNGTHITUYENMEIKO = value.NEUDATUNGTHITUYENMEIKO;
                //        check.ID_NGUONTHONGTIN = value.ID_NGUONTHONGTIN;
                //        check.DUDINHTUONGLAI = value.DUDINHTUONGLAI;
                //        check.SOTHICH = value.SOTHICH;
                //        check.KHONGTHICH = value.KHONGTHICH;
                //        check.CACPHAMCHATKYNANG = value.CACPHAMCHATKYNANG;
                //        check.HOTENNGUOITHAN = value.HOTENNGUOITHAN;
                //        check.DIACHINGUOITHAN = value.DIACHINGUOITHAN;
                //        check.MOBILENGUOITHAN = value.MOBILENGUOITHAN;
                //        check.ANHCHANDUNG = value.ANHCHANDUNG;
                //        check.RM0011_ID1 = value.RM0011_ID1;
                //        check.RM0011_ID2 = value.RM0011_ID2;
                //        check.trangthai = value.trangthai;
                //        check.DUDINHHOCTIEPCHUYENNGANH = value.DUDINHHOCTIEPCHUYENNGANH;
                //        check.DUDINHHOCTIEP = value.DUDINHHOCTIEP;
                //        check.bophanid = value.bophanid;
                //        try
                //        {
                //            db.SaveChanges();

                //            db.RM0081_A.RemoveRange(check.RM0081_A);
                //            db.RM0081_B.RemoveRange(check.RM0081_B);
                //            db.RM0081_C.RemoveRange(check.RM0081_C);
                //            db.RM0081_D.RemoveRange(check.RM0081_D);
                //            db.RM0081_E.RemoveRange(check.RM0081_E);
                //            db.RM0081_F.RemoveRange(check.RM0081_F);
                //            db.RM0080.RemoveRange(check.RM0080);
                //            db.SaveChanges();
                //            check.RM0080 = value.RM0080;
                //            check.RM0081_A = value.RM0081_A;
                //            check.RM0081_B = value.RM0081_B;
                //            check.RM0081_C = value.RM0081_C;
                //            check.RM0081_D = value.RM0081_D;
                //            check.RM0081_E = value.RM0081_E;
                //            check.RM0081_F = value.RM0081_F;
                //            db.SaveChanges();
                //            rel.set("OK", ungvienget.Getallungvien(new ungvienget.filterungvien() { id = value.RM0010_ID }), "Thành công");
                //        }
                //        catch (Exception l)
                //        {
                //            rel.set("ERR", null, "Thất bại:" + l.Message);
                //        }
                //    }
                //    else
                //    {
                //        rel.set("NaN", null, "Không tìm thấy dữ liệu.");
                //    }
                //    return rel.ToHttpResponseMessage();
                //}


            }
        }
    }
}
