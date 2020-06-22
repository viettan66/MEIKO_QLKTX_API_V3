using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MEIKO_QLKTX_API_V1.Models;

namespace QLKTX_API_V2.Controllers
{
    public static class AccountGett
    { 
        public struct filter { 
            public Nullable<int> id { get; set; }
            public string manhansu { get; set; }
        }
        public static object GetAccount(filter filter)
        {

            using (DB db = new DB())
            {
                var acc = db.Database.SqlQuery<MKV9999>(@"SELECT [MKV9999_ID]
      ,[manhansu]
      ,[matkhau]
      ,[id]
      ,[hodem]
      ,[ten]
      ,[ngaysinh]
      ,[gioitinh]
      ,[noisinh]
      ,[quequan]
      ,[diachithuongtru]
      ,[diachitamtru]
      ,[cmtnd_so]
      ,[cmtnd_ngayhethan]
      ,[cmtnd_noicap]
      ,[hochieu_so]
      ,[hochieu_ngaycap]
      ,[hochieu_ngayhethan]
      ,[ngayvaocongty]
      ,[phong_id]
      ,[ban_id]
      ,[congdoan_id]
      ,[chucvu_id]
      ,[nganhang_stk]
      ,[nganhang_id]
      ,[sosobaohiem]
      ,[honnhantinhtrang]
      ,[datnuoc_id]
      ,[phuongxa]
      ,[suckhoetinhtrang]
      ,[dienthoai_nharieng]
      ,[dienthoai_didong]
      ,[email]
      ,[tinhtrangnhansu]
      ,[thutu]
      ,[chucvu]
      ,[capbac]
      ,thetu_id=(SELECT bophan_ten FROM MKV9998 where phong_id=G.phong_id )
      ,[type]
  FROM MKV9999 as G " + ((filter.id!=null||filter.manhansu!=null)?" where ":"")+(filter.id!=null?(" MKV9999_ID ="+filter.id):"")+(filter.manhansu!=null?(" manhansu ='" + filter.manhansu+"'"):"") );
                if (filter.id != null)
                {
                    return acc.FirstOrDefault();
                }
                if (filter.manhansu != null)
                {
                    return acc.FirstOrDefault();
                }
                return acc;
            }
        }
    }
}