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
            public string ngay { get; set; }
            public int MKV9999_ID { get; set; }
            public string ngaycohieuluc { get; set; }
            public string phong { get; set; }
            public string hoten { get; set; }
            public string User_ID { get; set; }
            public string manhansu { get; set; }
            public string bophan_ten { get; set; }
            public string capbac { get; set; }
            public string cmtnd_so { get; set; }
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
            public string id { get; set; }
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
                     data = db.Database.SqlQuery<getdataOnDB>(@"DECLARE @ip ListIP;
INSERT INTO @ip ( ip ) VALUES ("+ iptemp.TrimEnd(',').Replace(",","),(") + @")
EXECUTE Getravaocong2 @List=@ip,@startdate='" + startdate + "',@enddate='" + enddate + "'").ToList() ;
                   else if(filter.style==1)
                     data = db.Database.SqlQuery<getdataOnDB2>(@"DECLARE @ip ListIP;
INSERT INTO @ip ( ip ) VALUES ("+ iptemp.TrimEnd(',').Replace(",","),(") + @")
EXECUTE getxuatan @List=@ip,@startdate='" + startdate + "',@enddate='" + enddate + "'").AsEnumerable().Select(p => new
                     {
                         p.buasang,
                         p.buatoi,
                         p.buatrua,
                         p.User_ID,
                         p.thanhtienbuasang,
                         p.thanhtienbuatoi,
                         p.thanhtienbuatrua,
                         ngayvao=db.Database.SqlQuery<Nullable< DateTime>>("execute getngayvao @id='"+p.User_ID+"'").FirstOrDefault(),
                         phong=db.Database.SqlQuery<string>("execute Getphong @id='" + p.User_ID+"'").FirstOrDefault()
                     }).ToList() ;
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
        public struct datareturn
        {
            public string User_ID { get; set; }
            public Nullable<DateTime> Verify_Date { get; set; }
            public string loaibuaan { get; set; }
        }
    [Route("getdetail")]
    [HttpPost]
    public HttpResponseMessage getdetail([FromBody]filter filter)
        {
            string startdate = DateTime.Parse(filter.startdate.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            string enddate = DateTime.Parse(filter.enddate.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            string iptemp = "";
            filter.ip.ToList().ForEach(fff =>
            {
                iptemp += "'" + fff.ip + "'" + ",";
            });
            using (DB db=new DB())
        {
            var data = db.Database.SqlQuery<datareturn>(@"select  User_ID ,Verify_Date,
             CASE 
                  WHEN CONVERT(varchar, Verify_Date,108)>='05:00:00' and CONVERT(varchar, Verify_Date,108)<='09:30:00' THEN N'Bữa sáng' 
                  WHEN CONVERT(varchar, Verify_Date,108)>='10:00:00' and CONVERT(varchar, Verify_Date,108)<='13:00:00' THEN N'Bữa trưa' 
                  WHEN CONVERT(varchar, Verify_Date,108)>='16:30:00' and CONVERT(varchar, Verify_Date,108)<='20:00:00' THEN N'Bữa tối' 
                  ELSE N'Không tính tiền'
             END as loaibuaan

from KTX0050 as G where 
					Verify_Date>='" + startdate + "' and  Verify_Date<='" + enddate + "'  and ip in (" + iptemp.TrimEnd(',') + ") and User_ID='" + filter.id+"' ");
            return REST.GetHttpResponseMessFromObject(data);
        }
    }
    }


}
