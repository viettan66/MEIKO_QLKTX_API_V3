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
    [RoutePrefix("api/KTX0049")]
    public class KTX0049Controller : ApiController
    {
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage Getall([FromBody] KTX0049[] values)
        {
            using(DB db=new DB())
            {
                results<KTX0049> list = new results<KTX0049>();
                values.ToList().ForEach(value=>
                {
                result<KTX0049> rel = new result<KTX0049>();
                    var check = db.KTX0049.SingleOrDefault(ppp => ppp.User_ID == value.User_ID);
                    if (check == null)
                    {
                       var k= db.Database.SqlQuery<object>(@"insert into ktx0049(User_ID,startdate,enddate,ghichu,trangthai) values ('"+value.User_ID+ "','" + value.startdate + "','" + value.enddate + "',N'" + value.ghichu + "'," + (value.trangthai==true?1:0) + ");").ToList();
                        //if (k.FirstOrDefault() == 1)
                            rel.set("OK", value);
                    }
                    else
                    {
                        if (value.startdate < check.startdate) check.startdate = value.startdate;
                        if (value.enddate > check.enddate) check.enddate = value.enddate;
                        check.ghichu = value.ghichu;
                        check.trangthai = value.trangthai;
                        rel.set("OK", value);
                    }
                    list.add(rel);
                });
                db.SaveChanges();
                return list.ToHttpResponseMessage();
            }
        }
        public struct thanh
        {
            public string User_ID { get; set; }
            public Nullable<float> thanhtien { get; set; }
            
        }
        [Route("GetPay")]
        [HttpPost]
        public HttpResponseMessage GetPay([FromBody] KTX0049 values)
        {
            using (DB db = new DB())
            {
                var check = db.Database.SqlQuery<KTX0049>(@"select * from ktx0049 where user_ID='" + values.User_ID + @"'").FirstOrDefault();
                if (check == null)
                {
                    return REST.GetHttpResponseMessFromObject(new {User_ID=values.User_ID,thanhtien=0 });
                }
                int k=0;
                if(int.TryParse(values.User_ID, out k))
                {
                    values.User_ID = k + "";
                }
                var startdate = check.startdate < values.startdate ? values.startdate : check.startdate;
                var enddate = check.enddate < values.enddate ? check.enddate  :values.enddate;
                var data = db.Database.SqlQuery<thanh>(@"select  User_ID ,
					thanhtien=(( select count( CONVERT(varchar, Verify_Date,108))*(select top (1) buasang from KTX0053 where  ngay<='"+startdate+@"' order by ngay desc)  from ktx0050  where 
					Verify_Date>='"+startdate+@"'  and  
					Verify_Date<='"+enddate+@"' and 
					CONVERT(varchar, Verify_Date,108)>='06:30:00' and 
					CONVERT(varchar, Verify_Date,108)<='09:00:00' and 
					G.User_ID= ktx0050.User_ID    ))
					+(( select count( CONVERT(varchar, Verify_Date,108))*(select top (1) buatrua from KTX0053 where  ngay<='"+startdate+@"' order by ngay desc)  from ktx0050  where 
					Verify_Date>='"+startdate+@"'  and  
					Verify_Date<='"+enddate+@"' and 
					CONVERT(varchar, Verify_Date,108)>='10:30:00' and 
					CONVERT(varchar, Verify_Date,108)<='12:30:00' and 
					G.User_ID= ktx0050.User_ID    ))+(( select count( CONVERT(varchar, Verify_Date,108))*(select top (1) buatoi from KTX0053 where  ngay<='"+startdate+@"' order by ngay desc)  from ktx0050  where 
					Verify_Date>='"+startdate+@"'  and  
					Verify_Date<='"+enddate+@"' and 
					CONVERT(varchar, Verify_Date,108)>='17:30:00' and 
					CONVERT(varchar, Verify_Date,108)<='19:30:00' and 
					G.User_ID= ktx0050.User_ID    ))
from KTX0050 as G where Verify_Date>='"+startdate+@"' and  Verify_Date<='"+enddate+@"' and User_ID = '"+values.User_ID+@"'
group by User_ID").FirstOrDefault();
               return REST.GetHttpResponseMessFromObject(data);
            }
        }
    }
}
