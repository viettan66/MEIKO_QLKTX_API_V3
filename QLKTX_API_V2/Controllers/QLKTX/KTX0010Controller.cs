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
    [RoutePrefix("api/KTX0010")]
    public class KTX0010Controller : ApiController
    {
        [Route("Getall")]
        [HttpGet]
        public HttpResponseMessage Getall()
        {
            using (DB db = new DB())
            {
                var temp = db.KTX0010.Where(p => p.trangthai == true).Select(p => new
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
                return  REST.GetHttpResponseMessFromObject(temp.ToList());
            }
        }
        [Route("Getalltaisancodinh")]
        [HttpGet]
        public HttpResponseMessage Getalltaisancodinh()
        {
            using (DB db = new DB())
            {
                var temp = (from a in db.KTX0010
                            where a.loai == 1 && a.trangthai == true
                            orderby a.ten
                            select new
                            {
                                a.ghichu,
                                a.giatien,
                                a.KTX0010_ID,
                                a.loai,
                                a.soluongmacdinh,
                                a.soluongfull,
                                a.ten,
                                a.thutu,
                                a.trangthai,
                            });
                return  REST.GetHttpResponseMessFromObject(temp.ToList());
            }
        }
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]KTX0010[] values)
        {
            DB db = new DB();
            results<KTX0010> list = new results<KTX0010>();
            foreach (var value in values)
            {
                result<KTX0010> rel = new result<KTX0010>();
                KTX0010 t = value;
                var check = db.KTX0010.FirstOrDefault(p => p.WH0007_ID == t.WH0007_ID && p.WH0007_ID != null);
                if (check == null)
                {
                    try
                    {
                        var kkk = db.KTX0010.Add(t);
                        db.SaveChanges();
                        rel.set("OK", t, "Thành công");
                    }
                    catch (Exception rr)
                    {

                        rel.set("ERR", t, "Thất bại: " + rr.Message);
                    }
                }
                else
                {
                    rel.set("ERR", t, "Thất bại: Mặt hàng này đã tồn tại trên hệ thống.");
                }
                list.add(rel);
            }
            return  list.ToHttpResponseMessage();
        }
        [Route("delete")]
        [HttpPost]
        public HttpResponseMessage delete([FromBody]KTX0010[] values)
        {
            DB db = new DB();
           results<KTX0010> list = new results<KTX0010>();
            foreach (var value in values)
            {
                result<KTX0010> rel = new result<KTX0010>();
                var check = db.KTX0010.SingleOrDefault(p => p.KTX0010_ID == value.KTX0010_ID);
                if (check != null)
                {
                    try
                    {
                        db.KTX0010.Remove(check);
                        db.SaveChanges();
                        rel.set("OK", value, "Thành công");
                    }
                    catch (Exception rr)
                    {
                        rel.set("ERR", value, "Thất bại: " + rr.Message);
                    }
                }
                else
                {
                    rel.set("ERR", value, "Không thấy dữ liệu bản ghi.");
                }
                list.add(rel);
            }
            return  list.ToHttpResponseMessage();
        }
        [Route("edit")]
        [HttpPut]
        public HttpResponseMessage edit([FromBody]KTX0010[] value)
        {
            DB db = new DB();
           results<KTX0010> list = new results<KTX0010>();
            foreach (var val in value)
            {
                result<KTX0010> rel = new result<KTX0010>();
                KTX0010 t = val;
                var data = db.KTX0010.SingleOrDefault(p => p.KTX0010_ID == t.KTX0010_ID);
                if (data != null)
                {
                    try
                    {
                        data.ghichu = t.ghichu;
                        data.giatien = t.giatien;
                        data.ten = t.ten;
                        data.thutu = t.thutu;
                        data.trangthai = t.trangthai;
                        data.loai = t.loai;
                        data.soluongmacdinh = t.soluongmacdinh;
                        data.soluongfull = t.soluongfull;
                        db.SaveChanges();
                        rel.set("OK", t, "Thành công");
                    }
                    catch (Exception rr)
                    {

                        rel.set("ERR", t, "Thất bại: " + rr.Message);
                    }
                }
                else
                {
                    rel.set("ERR", t, "Thất bại: Không tìm thấy dữ liệu.");
                }
                list.add(rel);
            }
            return (list.ToHttpResponseMessage());
        }
    }
}
