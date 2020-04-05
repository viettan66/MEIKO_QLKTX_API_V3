using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers.TUYENDUNG
{
    [RoutePrefix("api/RM0015")]
    public class RM0015Controller : ApiController
    {
        [Route("Getall")]
        [HttpGet]
        public HttpResponseMessage Getall()
        {
            return REST.GetHttpResponseMessFromObject(getallRM0015());
        }
        public struct addlichhen
        {
            public DateTime thoigian { get; set; }
            public int diadiem  { get; set; }
            public RM0010[] RM0010 { get; set; }
            public MKV9999[] MKV9999 { get; set; }
        }
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]addlichhen values)
        {
            using (DB db = new DB())
            {
                results<object> list = new results<object>();
                values.RM0010.ToList().ForEach(value =>
                {
                    result<object> rel = new result<object>();
                    var check = db.RM0010.SingleOrDefault(p => p.RM0010_ID == value.RM0010_ID);
                    if (check != null)
                    {
                        RM0015 rm0015 = new RM0015()
                        {
                            RM0010_ID = value.RM0010_ID,
                            thoiGianPhongVan = values.thoigian,
                            trangThai = false,
                            vongPhongVan = db.RM0015.Where(p => p.RM0010_ID == value.RM0010_ID).Count() + 1,
                            ghiChu = "Thời gian tạo lịch hẹn" + DateTime.Now,
                        };
                        db.RM0015.Add(rm0015);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", getallRM0015(rm0015.RM0015_ID),"Thành công.");
                        }catch(Exception tr)
                        {
                            rel.set("ERR", null, "Thất bại: " + tr.Message) ;
                        }
                    }
                    else
                    {
                        rel.set("NaN", null, "Không tìm thấy dữ liệu.");
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }


        public object getallRM0015(int id=0)
        {
            using(DB db=new DB())
            {
                var data = db.RM0015.Select(p => new
                {
                    p.ghiChu,
                    p.ketQua,
                    p.RM0010_ID,
                    p.RM0015_ID,
                    p.thoiGianPhongVan,
                    p.trangThai,
                    p.vongPhongVan,
                    RM0015A = db.RM0015A.Where(f => f.RM0015_ID == p.RM0015_ID).Select(f => new
                    {
                        f.ghiChu,
                        f.MKV9999_ID,
                        f.RM0015A_ID,
                        f.RM0015_ID,
                        f.trangThai,
                        MKV9999 = db.MKV9999.Where(g => g.MKV9999_ID == f.MKV9999_ID).Select(g => new
                        {
                            g.MKV9999_ID,
                            g.manhansu,
                            g.matkhau,
                            g.id,
                            g.hodem,
                            g.ten,
                            g.type,
                            g.ngaysinh,
                            g.gioitinh,
                            g.noisinh,
                            g.quequan,
                            g.diachithuongtru,
                            g.diachitamtru,
                            g.cmtnd_so,
                            g.cmtnd_ngayhethan,
                            g.cmtnd_noicap,
                            g.hochieu_so,
                            g.hochieu_ngaycap,
                            g.hochieu_ngayhethan,
                            g.ngayvaocongty,
                            g.phong_id,
                            g.ban_id,
                            g.congdoan_id,
                            g.chucvu_id,
                            g.nganhang_stk,
                            g.nganhang_id,
                            g.sosobaohiem,
                            g.honnhantinhtrang,
                            g.datnuoc_id,
                            g.phuongxa,
                            g.suckhoetinhtrang,
                            g.dienthoai_nharieng,
                            g.dienthoai_didong,
                            g.email,
                            g.tinhtrangnhansu,
                            g.thutu,
                            g.chucvu,
                            g.capbac,
                            thetu_id=db.MKV9998.Where(o => o.phong_id == g.phong_id).Select(o => o.bophan_ten).FirstOrDefault(),
                        }).FirstOrDefault(),
                    }).ToList(),
                });
                if (id != 0)
                {
                    data = data.Where(p => p.RM0015_ID == id);
                    return REST.GetHttpResponseMessFromObject(data.FirstOrDefault());
                }
                return REST.GetHttpResponseMessFromObject(data.ToList());
            }
            
        }
    }
}
