using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.Admin.Models
{
    public class StatusOrderModel
    {
        private TMDT_DB3Entities context = null;
        public StatusOrderModel()
        {
            context = new TMDT_DB3Entities();
        }
        public List<TRANGTHAIDONHANG> ListAll()
        {
            var res = context.Database.SqlQuery<TRANGTHAIDONHANG>("SP_TRANGTHAIDONHANG").ToList();
            return res;
        }
        public string GetStatusOrderByID(int ma)
        {
            return context.TRANGTHAIDONHANGs.SingleOrDefault(p => p.MA == ma).TINHTRANG;
        }
        public int Insert(TRANGTHAIDONHANG temp)
        {
            if (GetByID(temp.MA) != null)
            {
                temp.DAXOA = false;
                Update(temp);
            }
            else
                context.TRANGTHAIDONHANGs.Add(temp);
            context.SaveChanges();
            return temp.MA;
        }
        public TRANGTHAIDONHANG GetByID(int ma)
        {
            return context.TRANGTHAIDONHANGs.SingleOrDefault(p => p.MA == ma);
        }
        public bool Update(TRANGTHAIDONHANG temp)
        {
            try
            {
                TRANGTHAIDONHANG oder = GetByID(temp.MA);
                if (oder != null)
                {
                    oder.TINHTRANG = temp.TINHTRANG;
                    oder.DAXOA = temp.DAXOA;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
        public bool Delete(TRANGTHAIDONHANG temp)
        {
            try
            {
                TRANGTHAIDONHANG oder = GetByID(temp.MA);
                if (oder != null)
                {
                    temp.DAXOA = true;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}