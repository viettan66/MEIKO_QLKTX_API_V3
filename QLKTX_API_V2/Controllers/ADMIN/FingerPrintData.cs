using MEIKO_QLKTX_API_V1.Models;
using QLKTX_API_V2.Controllers.QLKTX;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QLKTX_API_V2.Controllers.ADMIN
{
    public class FingerPrintData
    {

        public struct filter
        {
            public string ip { get; set; }
            public string port { get; set; }
            public string commkey { get; set; }
            public string startdate { get; set; }
            public string enddate { get; set; }
        }
        public static DataTable Getdata(filter filter)
        {
            SDKHelper SDK = new SDKHelper();
            DataTable dt = new DataTable();
            dt.Columns.Add("STT");
            dt.Columns.Add("User_ID");
            dt.Columns.Add("Verify_Date");
            dt.Columns.Add("Verify_Type");
            dt.Columns.Add("Verify_State");
            dt.Columns.Add("WorkCode");
            dt.Columns.Add("sDeviceName");
            dt.Columns.Add("sSN");
            dt.Columns.Add("ip");
            if (filter.startdate == null || filter.enddate == null) return null;
            string lbSysOutputInfo = "";
            int ret = SDK.sta_ConnectTCP(ref lbSysOutputInfo, filter.ip, filter.port, filter.commkey);
            if (ret == 1)
            {
                SDK.sta_readLogByPeriod(ref lbSysOutputInfo, ref dt, filter.startdate, filter.enddate, filter.ip);
                SDK.sta_ConnectTCP(ref lbSysOutputInfo, filter.ip, filter.port, filter.commkey);
            }
            return dt;
        }
        public static void Getdata(filter filter,ref DataTable dt, List<KTX0050> list)
        {
            SDKHelper SDK = new SDKHelper();
            if (filter.startdate == null || filter.enddate == null) return;
            string lbSysOutputInfo = "";
            int ret = SDK.sta_ConnectTCP(ref lbSysOutputInfo, filter.ip, filter.port, filter.commkey);
            if (ret == 1)
            {
                SDK.sta_readLogByPeriod(ref lbSysOutputInfo, ref dt, filter.startdate, filter.enddate, filter.ip, list);
                SDK.sta_ConnectTCP(ref lbSysOutputInfo, filter.ip, filter.port, filter.commkey);
            }
        }

        public struct datasync
        {
            public Nullable<int> type { get; set; }

            public KTX0050[] KTX0050 { get; set; }
        }
        public static bool Syncdata(datasync datas)
        {
            using (DB db = new DB())
            {
                result<object> rel = new result<object>();
                if (datas.type == 1)
                {
                    datas.KTX0050.ToList().ForEach(value =>
                    {
                        var check = db.KTX0050.Where(p => p.ip == value.ip && p.sSN == value.sSN && p.User_ID == value.User_ID && p.Verify_Date == value.Verify_Date && p.Verify_Type == value.Verify_Type).FirstOrDefault();
                        if (check == null)
                        {
                            db.KTX0050.Add(value);
                        }
                    });
                    try
                    {
                        db.SaveChanges();
                        return true;
                    }
                    catch (Exception f)
                    {
                        return false;
                    }
                }
                        return true;

            }
        }
    }
}