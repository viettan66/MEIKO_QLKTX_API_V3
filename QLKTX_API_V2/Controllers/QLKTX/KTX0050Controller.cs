using MEIKO_QLKTX_API_V1.Models;
using Newtonsoft.Json;
using QLKTX_API_V2.Controllers.ADMIN;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLKTX_API_V2.Controllers
{
    [RoutePrefix("api/KTX0050")]
    public class KTX0050Controller : ApiController
    {
        public struct getdataOnDB
        {
            public int count { get; set; }
            public string User_ID { get; set; }
        }
        public struct getdataOnDB2
        {
            public int buasang { get; set; }
            public int buatrua { get; set; }
            public int buatoi { get; set; }
            public float thanhtienbuasang { get; set; }
            public float thanhtienbuatrua { get; set; }
            public float thanhtienbuatoi { get; set; }
            public string User_ID { get; set; }
        }
        public struct count
        {
            public int counts { get; set; }
        }
        public struct filter
        {
            public MKV8002[] ip { get; set; }
            public Nullable<DateTime> startdate { get; set; }
            public Nullable<DateTime> enddate { get; set; }
            public Nullable<int> style { get; set; }
        }
        [Route("Getall")]
        [HttpPost]
        public HttpResponseMessage Getall([FromBody] filter filter)
        {
            if (filter.startdate == null || filter.enddate == null) return null;

            List<KTX0050> list = new List<KTX0050>();
            DataTable dt = new DataTable();
            string iptemp = "";
            filter.ip.ToList().ForEach(fff =>
            {
                iptemp += "'"+fff.ip+"'" + ",";
                FingerPrintData.Getdata(new FingerPrintData.filter()
                    {
                        commkey = fff.commkey,
                        enddate = DateTime.Parse(filter.enddate.ToString()).ToString("yyyy-MM-dd HH:mm:ss"),
                        ip = fff.ip,
                        port = fff.port,
                        startdate = DateTime.Parse(filter.startdate.ToString()).ToString("yyyy-MM-dd HH:mm:ss")
                    }, ref dt, list
                );
            });

            using (DB db = new DB())
            {
                do
                {
                    string startdate = DateTime.Parse(filter.startdate.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    string enddate = DateTime.Parse(filter.enddate.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    var temp = db.Database.SqlQuery<count>("select count( User_ID ) as counts from KTX0050 where Verify_Date>='" + startdate + "' and  Verify_Date<='" + enddate + "' and ip in ("+iptemp.TrimEnd(',')+")");
                    object data = null;
                    if(filter.style==2)
                     data = db.Database.SqlQuery<getdataOnDB>("select distinct User_ID ,count=( select count (distinct CONVERT(char(10), Verify_Date,126)) from ktx0050 where Verify_Date>='" + startdate + "' and  Verify_Date<='" + enddate + "'and G.User_ID= ktx0050.User_ID ) from KTX0050 as G where Verify_Date>='" + startdate + "' and  Verify_Date<='" + enddate + "'  and ip in (" + iptemp.TrimEnd(',') + ")")
                        .Select(p => new
                        {
                            count = p.count,
                            list = db.Database.SqlQuery<string>("select  distinct CONVERT(varchar, Verify_Date,112)  from ktx0050 where Verify_Date>='" + startdate + "'  and  Verify_Date<='" + enddate + "' and  ktx0050.User_ID= '"+p.User_ID+ "'  and ip in (" + iptemp.TrimEnd(',') + ")"),
                        p.User_ID,
                            MKV9999 = (from l in db.MKV9999
                                       where l.manhansu == ("00000000".Substring(0, 6 - p.User_ID.Length) + p.User_ID)
                                       select new
                                       {
                                           l.MKV9999_ID,
                                           l.manhansu,
                                           l.id,
                                           l.hodem,
                                           l.ten,
                                           l.ngaysinh,
                                           l.gioitinh,
                                           l.noisinh,
                                           l.quequan,
                                           l.diachithuongtru,
                                           l.diachitamtru,
                                           l.cmtnd_so,
                                           l.cmtnd_ngayhethan,
                                           l.cmtnd_noicap,
                                           l.phong_id,
                                           l.ban_id,
                                           l.congdoan_id,
                                           l.chucvu_id,
                                           l.dienthoai_nharieng,
                                           l.dienthoai_didong,
                                           l.chucvu,
                                           l.capbac,
                                           thetu_id = db.MKV9998.Where(o => l.phong_id == o.phong_id).Select(o => o.bophan_ten).FirstOrDefault(),
                                       }).FirstOrDefault()
                        }) ;
                   else if(filter.style==1)
                     data = db.Database.SqlQuery<getdataOnDB2>(@"select  User_ID ,buasang=( select count( CONVERT(varchar, Verify_Date,108))  from ktx0050 where 
					Verify_Date>='" + startdate + @"'  and  
					Verify_Date<='" + enddate + @"' and 
					CONVERT(varchar, Verify_Date,108)>='06:30:00' and 
					CONVERT(varchar, Verify_Date,108)<='09:00:00' and 
					G.User_ID= ktx0050.User_ID  and ip in (" + iptemp.TrimEnd(',') + @")) ,

					thanhtienbuasang=(( select count( CONVERT(varchar, Verify_Date,108))*(select top (1) buasang from KTX0053 where  ngay<='" + startdate + @"' order by ngay desc)  from ktx0050  where 
					Verify_Date>='" + startdate + @"'  and  
					Verify_Date<='" + enddate + @"' and 
					CONVERT(varchar, Verify_Date,108)>='06:30:00' and 
					CONVERT(varchar, Verify_Date,108)<='09:00:00' and 
					G.User_ID= ktx0050.User_ID    and ip in (" + iptemp.TrimEnd(',') + @") ))
					,

				buatrua=( select count( CONVERT(varchar, Verify_Date,108))  from ktx0050 where 
					Verify_Date>='" + startdate + @"'  and  
					Verify_Date<='" + enddate + @"' and 
					CONVERT(varchar, Verify_Date,108)>='10:30:00' and 
					CONVERT(varchar, Verify_Date,108)<='12:30:00' and 
					G.User_ID= ktx0050.User_ID   and ip in (" + iptemp.TrimEnd(',') + @")  ) ,
					
					thanhtienbuatrua=(( select count( CONVERT(varchar, Verify_Date,108))*(select top (1) buatrua from KTX0053 where  ngay<='" + startdate + @"' order by ngay desc)  from ktx0050  where 
					Verify_Date>='" + startdate + @"'  and  
					Verify_Date<='" + enddate + @"' and 
					CONVERT(varchar, Verify_Date,108)>='10:30:00' and 
					CONVERT(varchar, Verify_Date,108)<='12:30:00' and 
					G.User_ID= ktx0050.User_ID   and ip in (" + iptemp.TrimEnd(',') + @")  )),
				buatoi=( select count( CONVERT(varchar, Verify_Date,108))  from ktx0050 where 
					Verify_Date>='" + startdate + @"'  and  
					Verify_Date<='" + enddate + @"' and 
					CONVERT(varchar, Verify_Date,108)>='17:30:00' and 
					CONVERT(varchar, Verify_Date,108)<='19:30:00' and 
					G.User_ID= ktx0050.User_ID    and ip in (" + iptemp.TrimEnd(',') + @") )  ,
					
					thanhtienbuatoi=(( select count( CONVERT(varchar, Verify_Date,108))*(select top (1) buatoi from KTX0053 where  ngay<='" + startdate + @"' order by ngay desc)  from ktx0050  where 
					Verify_Date>='" + startdate + @"'  and  
					Verify_Date<='" + enddate + @"' and 
					CONVERT(varchar, Verify_Date,108)>='17:30:00' and 
					CONVERT(varchar, Verify_Date,108)<='19:30:00' and 
					G.User_ID= ktx0050.User_ID   and ip in (" + iptemp.TrimEnd(',') + @")  ))
from KTX0050 as G where 
					Verify_Date>='" + startdate + @"'  and  
					Verify_Date<='" + enddate + @"'  and ip in (" + iptemp.TrimEnd(',') + @") 
group by User_ID")
                        .Select(p => new
                        {p.buasang,p.buatoi,p.buatrua,p.User_ID,p.thanhtienbuasang,p.thanhtienbuatoi,p.thanhtienbuatrua,
                            MKV9999 = (from l in db.MKV9999
                                       where l.manhansu == ("00000000".Substring(0, 6 - p.User_ID.Length) + p.User_ID)
                                       select new
                                       {
                                           l.MKV9999_ID,
                                           l.manhansu,
                                           l.id,
                                           l.hodem,
                                           l.ten,
                                           l.ngaysinh,
                                           l.gioitinh,
                                           l.noisinh,
                                           l.quequan,
                                           l.diachithuongtru,
                                           l.diachitamtru,
                                           l.cmtnd_so,
                                           l.cmtnd_ngayhethan,
                                           l.cmtnd_noicap,
                                           l.phong_id,
                                           l.ban_id,
                                           l.congdoan_id,
                                           l.chucvu_id,
                                           l.dienthoai_nharieng,
                                           l.dienthoai_didong,
                                           l.chucvu,
                                           l.capbac,
                                           thetu_id = db.MKV9998.Where(o => l.phong_id == o.phong_id).Select(o => o.bophan_ten).FirstOrDefault(),
                                       }).FirstOrDefault(),
                        }) ;
                    int kkkk = temp.FirstOrDefault().counts;
                    if (list.Count >kkkk )
                    {
                        FingerPrintData.Syncdata(new FingerPrintData.datasync() { KTX0050 = list.ToArray(), type = 1 });
                    }
                    else
                    {
                        return REST.GetHttpResponseMessFromObject(data);
                        
                    }
                }
                while (true);
            }

        }
    }
}
