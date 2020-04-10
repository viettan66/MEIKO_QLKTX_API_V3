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
    [RoutePrefix("api/KTX0001")]
    public class KTX0001Controller : ApiController
    {
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]KTX0001[] values)
        {

            if (values == null) return null;
            DB db = new DB();
            results<KTX0001> list = new results<KTX0001>();
            foreach (var value in values)
            {
                result<KTX0001> rel = new result<KTX0001>();
                var checkgiuong = db.KTX0001.FirstOrDefault(p => p.ten == value.ten&&p.type== 4);
                if (checkgiuong == null)
                {

                    KTX0001 t = value;
                    try
                    {

                        var kkk = db.KTX0001.Add(t);
                        db.SaveChanges();
                        for (int i = 0; i < t.slot; i++)
                        {
                            db.KTX0002.Add(new KTX0002() { ghichu = "Giường trống", KTX0001_ID = t.KTX0001_ID, ten = "GA-" /*+ t.ten.Replace("", "")*/+t.ten + "-G0" + (i + 1), thutu = i, trangthai = false });

                        }
                        db.SaveChanges();
                        if (t.type == 4)
                        {
                            var arrtaisan = db.KTX0010.Where(p => p.loai == 1).Select(p => new { p.KTX0010_ID, p.soluongmacdinh }).ToList();
                            arrtaisan.ForEach(val =>
                            {
                                var g = new KTX0011() { KTX0001_ID = t.KTX0001_ID, KTX0010_ID = val.KTX0010_ID, soluong = val.soluongmacdinh };
                                db.KTX0011.Add(g);
                                //t.KTX0011.Add(g);
                            });
                            try { db.SaveChanges(); }
                            catch
                            { }

                        }
                        rel.set("OK", t, "Thành công");
                    }
                    catch (Exception rr)
                    {

                        rel.set("ERR", t, "Thất bại: " + rr.Message);
                    }
                }
                else
                {
                    rel.set("ERR", value, "Thất bại: Phòng có mã " + value.ten + " đã tồn tại, xin nhập tên khác.");
                }
                list.add(rel);
            }
            return list.ToHttpResponseMessage();
        }
        [Route("Getall/{id}")]
        [HttpGet]
        public HttpResponseMessage Getall(int id = -1)
        {
            using (DB db = new DB())
            {
                var temp = (from p in db.KTX0001
                            where (id != -1 ? p.KTX0001_ID == id : true)
                            select new
                            {
                                slotuse = (from k in db.KTX0020 where k.KTX0001_ID == p.KTX0001_ID select k).Count(),
                                p.ghichu,
                                p.idcha,
                                p.makhoa,
                                p.KTX0001_ID,
                                p.slot,
                                p.khu,
                                p.ten,
                                p.capbac,
                                p.thutu,
                                p.trangthai,
                                p.type,
                                KTX0011 = (from k in db.KTX0011
                                           where p.KTX0001_ID == k.KTX0001_ID
                                           select new
                                           {
                                               k.KTX0001_ID,
                                               k.KTX0010_ID,
                                               k.KTX0011_ID,
                                               k.soluong,
                                               k.ghichu,
                                               KTX0010 = (from l in db.KTX0010
                                                          where l.KTX0010_ID == k.KTX0010_ID
                                                          select new
                                                          {
                                                              l.ghichu,
                                                              l.giatien,
                                                              l.KTX0010_ID,
                                                              l.loai,
                                                              l.soluongmacdinh,
                                                              l.ten,
                                                              l.thutu,
                                                              l.trangthai,
                                                          }).FirstOrDefault()
                                           })
                            }).OrderBy(p => p.ten);
                return REST.GetHttpResponseMessFromObject(temp.ToList());
            }
        }
        [Route("Getall/{khu}/{toa}/{tang}")]
        [HttpGet]
        public HttpResponseMessage Getall(string khu, int toa, int tang)
        {
            using (DB db = new DB())
            {
                var listkhu = (from k in db.KTX0001 where (k.type == 2) select k);
                if ((khu != "a")) listkhu = listkhu.Where(k => k.khu == khu);


                var listtoa = (from i in db.KTX0001 where (i.type == 3) select i);
                listtoa = listtoa.Where(k => listkhu.Select(p => p.KTX0001_ID).Contains((int)k.idcha));
                if (toa != 0) listtoa = listtoa.Where(k => k.idcha == toa);


                var listtang = (from i in db.KTX0001 where (i.type == 4) select i);
                listtang = listtang.Where(k => listtoa.Select(p => p.KTX0001_ID).Contains((int)k.idcha));
                if (tang != 0) listtang = listtang.Where(p => p.idcha == tang);

                return REST.GetHttpResponseMessFromObject(listtang.Select(p => new
                {
                    slotuse = (from k in db.KTX0020 where k.KTX0001_ID == p.KTX0001_ID && k.trangthai2 != true select k).Count(),
                    p.ghichu,
                    p.idcha,
                    p.khu,
                    p.KTX0001_ID,
                    p.slot,
                    p.ten,
                    p.capbac,
                    p.thutu,
                    p.trangthai,
                    p.type,
                    KTX0001=db.KTX0001.Where(y=>y.KTX0001_ID==p.idcha).Select(o=>new {
                        o.ghichu,
                        o.idcha,
                       o.khu,
                        o.KTX0001_ID,
                        o.slot,
                        o.ten,
                        o.capbac,
                        o.thutu,
                        o.trangthai,
                        o.type,
                        KTX0001 = db.KTX0001.Where(m => m.KTX0001_ID == o.idcha).Select(m => new
                        {
                            m.ghichu,
                            m.idcha,
                            m.khu,
                            m.KTX0001_ID,
                            m.slot,
                            m.ten,
                            m.capbac,
                            m.thutu,
                            m.trangthai,
                            m.type,

                        }).FirstOrDefault()
                    }).FirstOrDefault(),
                    KTX0011 = (from k in db.KTX0011
                               where p.KTX0001_ID == k.KTX0001_ID
                               select new
                               {
                                   k.KTX0001_ID,
                                   k.KTX0010_ID,
                                   k.KTX0011_ID,
                                   k.soluong,
                                   k.ghichu,
                                   KTX0010 = (from l in db.KTX0010
                                              where l.KTX0010_ID == k.KTX0010_ID
                                              select new
                                              {
                                                  l.ghichu,
                                                  l.giatien,
                                                  l.KTX0010_ID,
                                                  l.loai,
                                                  l.soluongmacdinh,
                                                  l.soluongfull,
                                                  l.ten,
                                                  l.thutu,
                                                  l.trangthai,
                                              }).FirstOrDefault()
                               }),
                    KTX0010=(from a in db.KTX0010 where a.loai==1&&a.trangthai==true orderby a.ten select new
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
                        KTX0011= (from k in db.KTX0011
                                  where p.KTX0001_ID == k.KTX0001_ID&&a.KTX0010_ID==k.KTX0010_ID
                                  select new
                                  {
                                      k.KTX0001_ID,
                                      k.KTX0010_ID,
                                      k.KTX0011_ID,
                                      k.soluong,
                                      k.ghichu,
                                  }).FirstOrDefault(),
                    })

                }).OrderBy(p => p.ten)); ;
            }
        }
        [Route("Get/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            using (DB db = new DB())
            {
                var temp = db.KTX0001.SingleOrDefault(p => p.KTX0001_ID == id);

                return REST.GetHttpResponseMessFromObject(temp);
            }
        }
        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Update([FromBody]KTX0001 value)
        {
            using (DB db = new DB())
            {
                result<KTX0001> rel = new result<KTX0001>();
                var check = db.KTX0001.SingleOrDefault(p => p.KTX0001_ID == value.KTX0001_ID);
                var countgiuong = db.KTX0002.Where(p => p.KTX0001_ID == value.KTX0001_ID).Count();
                if (check != null)
                {
                    if (countgiuong > value.slot)
                    {
                        rel.set("ERR", check, "Thất bại: Số lượng nhập đang nhỏ hơn số lượng giường đang có. Hãy Chuyển nhân viên ra khỏi phòng, xóa bớt giường và thử lại.");
                    }
                    else if (countgiuong <= value.slot)
                    {
                        if (countgiuong < value.slot)
                        {
                            int count = 0;
                            for (int i = 0; i < 100; i++)
                            {
                                var lo = db.KTX0002.SingleOrDefault(p => p.ten == "GA-" + check.ten.Replace("-", "") + "-G0" + (i + 1));
                                if (lo != null) continue;
                                else if (count == value.slot - countgiuong) break;
                                else
                                {
                                    db.KTX0002.Add(new KTX0002() { ghichu = "Giường trống", KTX0001_ID = check.KTX0001_ID, ten = "GA-" + check.ten.Replace("-", "") + "-G0" + (i + 1), thutu = i, trangthai = false });
                                    try
                                    {
                                        db.SaveChanges();
                                        count++;
                                    }
                                    catch { }
                                }
                            }
                            db.SaveChanges();
                        }
                        check.ghichu = value.ghichu;
                        check.idcha = value.idcha;
                        check.khu = value.khu;
                        check.slot = value.slot;
                        check.ten = value.ten;
                        check.capbac = value.capbac;
                        check.makhoa = value.makhoa;
                        check.thutu = value.thutu;
                        check.trangthai = value.trangthai;
                        check.type = value.type;
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", check, "Thành công.");
                            var some = db.KTX0020.Where(p => p.KTX0001_ID == check.KTX0001_ID).ToList();
                            some.ForEach(val => val.khoaphong = value.makhoa);
                            try { db.SaveChanges(); } catch { }

                        }
                        catch (Exception t)
                        {
                            rel.set("ERR", check, "Thất bại: " + t.Message);
                        }
                    }
                }
                return  rel.ToHttpResponseMessage();
            }
        }
        [Route("Update2")]
        [HttpPut]
        public HttpResponseMessage Update2([FromBody]KTX0001 value)
        {
            using (DB db = new DB())
            {
                result<KTX0001> rel = new result<KTX0001>();
                var check = db.KTX0001.SingleOrDefault(p => p.KTX0001_ID == value.KTX0001_ID);
                if (check != null)
                {
                    check.ghichu = value.ghichu;
                    check.khu = value.khu;
                    check.slot = value.slot;
                    check.capbac = value.capbac;
                    check.ten = value.ten;
                    check.thutu = value.thutu;
                    check.trangthai = value.trangthai;
                    check.type = value.type;
                    try
                    {
                        db.SaveChanges();
                        rel.set("OK", check, "Thành công: ");
                    }
                    catch (Exception d)
                    {
                        rel.set("ERR", check, "Thất bại: " + d.Message);
                    }
                }
                return  rel.ToHttpResponseMessage();
            }
        }

        [Route("Delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            using (DB db = new DB())
            {
                result<KTX0001> rel = new result<KTX0001>();
                var check = db.KTX0001.SingleOrDefault(p => p.KTX0001_ID == id);
                if (check != null)
                {
                    var check2 = db.KTX0001.FirstOrDefault(p => p.idcha == id);
                    if (check2 == null)
                    {
                        var check3 = (from l in db.KTX0020 where l.KTX0001_ID == check.KTX0001_ID && l.trangthai2 != true select l).FirstOrDefault();
                        if (check3 == null)
                        {
                            try
                            {
                                db.KTX0001.Remove(check);
                                db.SaveChanges();
                                rel.set("OK", check, "Thành công");
                            }
                            catch (Exception t)
                            {
                                rel.set("ERR", check, "Thất bại: " + t.Message);
                            }
                        }
                        else
                        {
                            rel.set("ERR", check, "Thất bại: Phòng này đang có người ở, hãy chuyển hết nhân viên trong phòng ra ngoài rồi thực hiện lại.");
                        }
                    }
                    else
                    {
                        rel.set("ERR", check, "Thất bại: Tòa nhà hoặc tầng này đang chứa phòng, hãy xóa phòng hoặc tầng bên trong nó.");
                    }
                }
                else rel.set("ERR", check, "Thất bại: Không tồn tại bản ghi.");
                return  rel.ToHttpResponseMessage();
            }
        }
    }
}
