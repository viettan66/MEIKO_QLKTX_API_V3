using MEIKO_QLKTX_API_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKTX_API_V2.Controllers.MESSAGE
{
    public static class MessageManager
    {
        public static MKV7000 CreateRoom(MKV7000 value)
        {
            using (DB db = new DB())
            {
                db.MKV7000.Add(value);
                try
                {
                    db.SaveChanges();
                    return value;
                }
                catch
                {
                    return null;
                }
            }
        }
        public static object CreateMessage(MKV7001 value)
        {
            using (DB db = new DB())
            {
                value.date = DateTime.Now;
                db.MKV7001.Add(value);
                try
                {
                    db.SaveChanges();
                    return GetAll(new filter() { MKV7001_ID = value.MKV7001_ID }) ;
                }
                catch
                {
                    return null;
                }
            }
        }
        public struct filter
        {
            public Nullable<int> MKV9999_ID { get; set; }
            public Nullable<int> MKV9999_ID2 { get; set; }
            public Nullable<int> length { get; set; }
            public Nullable<int> MKV7001_ID { get; set; }
            public Nullable<DateTime> point { get; set; }
            public Nullable<bool> trangthai { get; set; }
            public Nullable<bool> mybox { get; set; }
        }
        public static object GetAll(filter filter)
        {
            using (DB db = new DB())
            {
                var data = db.MKV7001.AsEnumerable().OrderByDescending(a=>a.date).Select(p => new
                {
                    p.ghiChu,p.date,
                    p.MKV7000_ID,
                    p.MKV7001_ID,
                    p.MKV9999_ID,
                    p.MKV9999_ID2,
                    p.noiDung,
                    p.tieuDe,
                    count=db.MKV7001.Where(j=>j.MKV9999_ID2==filter.MKV9999_ID&&j.MKV9999_ID==p.MKV9999_ID&&j.trangthai==false).Count(),
                    p.trangthai,
                    MKV9999 = AccountGett.GetAccount(new AccountGett.filter() { id=p.MKV9999_ID}),
                    MKV99992 = AccountGett.GetAccount(new AccountGett.filter() { id=p.MKV9999_ID2}),
                });
                if (filter.MKV7001_ID != null)
                {
                    return data.Where(p => p.MKV7001_ID == filter.MKV7001_ID).FirstOrDefault();
                }
                if (filter.MKV9999_ID != null)
                {
                    data = data.Where(p => p.MKV9999_ID == filter.MKV9999_ID|| p.MKV9999_ID2 == filter.MKV9999_ID);
                }
                if (filter.trangthai != null)
                {
                    data = data.Where(p => p.trangthai == filter.trangthai);
                }
                if (filter.mybox != null)
                {
                    data = data.GroupBy(f=>new { f.MKV9999_ID , f.MKV9999_ID2 }).Select(x=>x.FirstOrDefault());
                }
                if (filter.point != null)
                {
                    data = data.Where(p => p.MKV9999_ID == filter.MKV9999_ID&& p.MKV9999_ID2 == filter.MKV9999_ID2||p.MKV9999_ID == filter.MKV9999_ID2&& p.MKV9999_ID2 == filter.MKV9999_ID);
                    data = data.Where(a => a.date < filter.point).Take((int)filter.length);
                }
                return data.ToList();
            }
        }
    }
}