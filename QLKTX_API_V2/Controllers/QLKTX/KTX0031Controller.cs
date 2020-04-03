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
    [RoutePrefix("api/KTX0031")]
    public class KTX0031Controller : ApiController
    {
        [Route("Add")]
        [HttpPost]
        public HttpResponseMessage Add([FromBody]KTX0031[] values)
        {
            using (DB db = new DB())
            {
                results<KTX0031> list = new results<KTX0031>();
                foreach (var value in values)
                {
                    result<KTX0031> rel = new result<KTX0031>();
                    var check = db.KTX0031.FirstOrDefault(p => p.KTX0010_ID == value.KTX0010_ID && p.MKV9999_ID == value.MKV9999_ID && p.trangthai == true);
                    if (check == null)
                    {
                        db.KTX0031.Add(value);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", value, "Thành Công.");
                        }
                        catch (Exception t)
                        {
                            rel.set("ERR", value, "Thất bại: " + t.Message);
                        }
                    }
                    else
                    {
                        check.soluongcap += value.soluongcap;
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", value, "Thành Công.");
                        }
                        catch (Exception t)
                        {
                            rel.set("ERR", value, "Thất bại: " + t.Message);
                        }
                    }
                    list.add(rel);
                }
                return (list.ToHttpResponseMessage());
            }
        }

        [Route("Get/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            using (var db = new DB())
            {
                var data = from temp in db.KTX0031
                           where temp.MKV9999_ID == id && temp.trangthai == true
                           select new
                           {
                               temp.ghichu,
                               temp.KTX0010_ID,
                               temp.KTX0031_ID,
                               temp.MKV9999_ID,
                               temp.ngaycap,
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
                           };
                return  REST.GetHttpResponseMessFromObject(data.ToList());
            }
        }
        [Route("Get23/{id}")]
        [HttpGet]
        public HttpResponseMessage Get23(int id)
        {
            using (var db = new DB())
            {
                var data = from temp in db.KTX0031
                           where temp.KTX0023_ID == id
                           select new
                           {
                               temp.ghichu,
                               temp.KTX0010_ID,
                               temp.KTX0031_ID,
                               temp.MKV9999_ID,
                               temp.ngaycap,
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
                           };
                return  REST.GetHttpResponseMessFromObject(data);
            }
        }
        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Update([FromBody]KTX0031[] values)
        {
            using (var db = new DB())
            {
                results<KTX0031> list = new results<KTX0031>();
                foreach (var value in values)
                {
                    result<KTX0031> rel = new result<KTX0031>();
                    var check = db.KTX0031.SingleOrDefault(p => p.KTX0031_ID == value.KTX0031_ID);
                    if (check != null)
                    {
                        check.soluongtra = value.soluongtra;
                        check.ngaytra = DateTime.Now;
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", check, "Thành công.");
                        }
                        catch
                        {
                            rel.set("ERR", value, REST.ERR);
                        }
                    }
                    else
                        rel.set("NaN", check, REST.NaN);
                    list.add(rel);
                }
                return (list.ToHttpResponseMessage());
            }
        }
    }
}
