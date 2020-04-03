using MEIKO_QLKTX_API_V1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLKTX_API_V2.Controllers
{
    [RoutePrefix("api/Permistion")]
    public class PermistionController : ApiController
    {
        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            DB db = new DB();
            var re = from temp in db.MKV9980 select temp;
            return REST.GetHttpResponseMessFromObject(re.ToList());
        }
        [Route("GetAll/{id}")]
        [HttpGet]
        public HttpResponseMessage GetAll2(int id)
        {
            DB db = new DB();
            var re = from temp in db.MKV9981 where temp.MKV9980_ID == id select temp;
            return REST.GetHttpResponseMessFromObject(re.ToList());
        }
        [Route("GetGroup")]
        [HttpGet]
        public HttpResponseMessage GetGroup()
        {
            DB db = new DB();
            var re = from temp in db.MKV9983 select temp;
            return REST.GetHttpResponseMessFromObject(re.ToList());
        }
        [Route("AddGroup")]
        [HttpPost]
        public HttpResponseMessage AddPer([FromBody]MKV9983 value)
        {
            result<MKV9983> rel = new result<MKV9983>();
            DB db = new DB();
            db.MKV9983.Add(value);
            try
            {
                db.SaveChanges();
                rel.set("OK", value, "Thành Công");
            }
            catch (Exception ee)
            {
                rel.set("ERR", value, "Thất bại: " + ee.Message);
            }
            return (rel.ToHttpResponseMessage());
        }
        [Route("AddPer")]
        [HttpPost]
        public HttpResponseMessage AddPer([FromBody]MKV9980 value)
        {
            result<MKV9980> rel = new result<MKV9980>();
            DB db = new DB();
            db.MKV9980.Add(value);
            try
            {
                db.SaveChanges();
                rel.set("OK", value, "Thành Công");
            }
            catch (Exception ee)
            {
                rel.set("ERR", value, "Thất bại: " + ee.Message);
            }
            return(rel.ToHttpResponseMessage());
        }
        [Route("AddAction")]
        [HttpPost]
        public HttpResponseMessage AddAction([FromBody]MKV9981 value)
        {
            result<MKV9981> rel = new result<MKV9981>();
            DB db = new DB();
            db.MKV9981.Add(value);
            try
            {
                db.SaveChanges();
                rel.set("OK", value, "Thành Công");
            }
            catch (Exception ee)
            {
                rel.set("ERR", value, "Thất bại: " + ee.Message);
            }
            return (rel.ToHttpResponseMessage());
        }

        [Route("GetActionofgroup/{mkv9983_id}/{mkv9980_id}")]
        [HttpGet]
        public HttpResponseMessage GetActionofgroup(int mkv9983_id, int mkv9980_id)
        {
            DB db = new DB();
            var re = from temp in db.MKV9981
                     where temp.MKV9980_ID == mkv9980_id
                     select new { temp.TENHANHDONG, temp.CAPMENU, temp.MKV9981_ID, check = ((from t in db.MKV9982 where t.MKV9983_ID == mkv9983_id && t.MKV9981_ID == temp.MKV9981_ID select t.MKV9981_ID)) };
            return REST.GetHttpResponseMessFromObject(re.ToList());
        }
        [Route("AddAction/{mkv9983_id}/{mkv9981_id}")]
        [HttpGet]
        public HttpResponseMessage AddAction(int mkv9983_id, int mkv9981_id)
        {
            result<MKV9982> rel = new result<MKV9982>();
            DB db = new DB();
            MKV9982 check = (from kjkj in db.MKV9982 where kjkj.MKV9981_ID == mkv9981_id && kjkj.MKV9983_ID == mkv9983_id select kjkj).FirstOrDefault();
            if (check == null)
            {
                MKV9982 p = new MKV9982() { MKV9981_ID = mkv9981_id, MKV9983_ID = mkv9983_id };
                db.MKV9982.Add(p);
                try
                {
                    db.SaveChanges();
                    rel.set("OK", p, "Thành  công");
                }
                catch (Exception d)
                {
                    rel.set("ERR", p, "Thất bại: " + d.Message);

                }
            }
            else
            {
                db.MKV9982.Remove(check);
                try
                {
                    db.SaveChanges();
                    rel.set("OK", check, "Thành  công");
                }
                catch (Exception d)
                {
                    rel.set("ERR", check, "Thất bại: " + d.Message);

                }
            }
            return (rel.ToHttpResponseMessage());
        }
        [Route("GetAllUserOfGroup/{mkv9983_id}")]
        [HttpGet]
        public HttpResponseMessage GetAllUserOfGroup(int mkv9983_id)
        {
            DB db = new DB();
            var re = from l in db.MKV9999 where (from temp in db.MKV9984 where temp.MKV9983_ID == mkv9983_id select temp.MKV9999_ID).Contains(l.MKV9999_ID) select l;
            return REST.GetHttpResponseMessFromObject(re.ToList());
        }

        [Route("AddUserToGr")]
        [HttpPost]
        public HttpResponseMessage AddUserToGr([FromBody]MKV9984[] values)
        {
           results<MKV9999> rel = new results<MKV9999>();
            DB db = new DB();
            foreach (MKV9984 val in values)
            {
                result<MKV9999> tm = new result<MKV9999>();
                MKV9984 check = (from kjkj in db.MKV9984 where kjkj.MKV9999_ID == val.MKV9999_ID && kjkj.MKV9983_ID == val.MKV9983_ID select kjkj).FirstOrDefault();
                if (check == null)
                {
                    db.MKV9984.Add(val);
                    try
                    {
                        db.SaveChanges();
                        tm.set("OK", db.MKV9999.SingleOrDefault(p => p.MKV9999_ID == val.MKV9999_ID), "Thành  công");
                    }
                    catch (Exception d)
                    {
                        tm.set("ERR", db.MKV9999.SingleOrDefault(p => p.MKV9999_ID == val.MKV9999_ID), "Thất bại: " + d.Message);

                    }
                }
                else
                {

                }
                rel.add(tm);
            }
            return ((rel.ToHttpResponseMessage()));
        }
        [Route("RmUserToGr")]
        [HttpPost]
        public HttpResponseMessage RmUserToGr([FromBody]MKV9984[] values)
        {
            results<MKV9999>  rel = new  results<MKV9999 >();
            DB db = new DB();
            foreach (MKV9984 val in values)
            {
                result<MKV9999> tm = new result<MKV9999>();
                MKV9984 check = (from kjkj in db.MKV9984 where kjkj.MKV9999_ID == val.MKV9999_ID && kjkj.MKV9983_ID == val.MKV9983_ID select kjkj).FirstOrDefault();
                if (check == null)
                {
                }
                else
                {
                    db.MKV9984.Remove(check);
                    try
                    {
                        db.SaveChanges();
                        tm.set("OK", db.MKV9999.SingleOrDefault(p => p.MKV9999_ID == val.MKV9999_ID), "Thành  công");
                    }
                    catch (Exception d)
                    {
                        tm.set("ERR", db.MKV9999.SingleOrDefault(p => p.MKV9999_ID == val.MKV9999_ID), "Thất bại: " + d.Message);

                    }

                }
                rel.add(tm);
            }
            return ((rel.ToHttpResponseMessage()));
        }

        [Route("GetAcctionWidthMKV9999ID/{MKV9999ID}")]
        [HttpGet]
        public HttpResponseMessage GetAcctionWidthMKV9999ID(int MKV9999ID)
        {
            DB db = new DB();
            var arr = (from temp in db.MKV9981
                       where
                         (from mkv82 in db.MKV9982
                          where (from mkv83 in db.MKV9983
                                 where (from mkv84 in db.MKV9984 where mkv84.MKV9999_ID == MKV9999ID select mkv84.MKV9983_ID).Contains(mkv83.MKV9983_ID)
                                 select mkv83.MKV9983_ID).Contains(mkv82.MKV9983_ID)
                          select mkv82.MKV9981_ID).Contains(temp.MKV9981_ID)
                       select temp).OrderBy(p => p.THUTU);
            return (REST.GetHttpResponseMessFromObject(arr.ToList()));
        }
    }
}
