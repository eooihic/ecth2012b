using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.Admin.Models
{
    public class OrderModel
    {
        private TMDT_DB3Entities context = null;
        public OrderModel()
        {
            context = new TMDT_DB3Entities();
        }
        public List<DONHANG> ListAll()
        {
            var res = context.Database.SqlQuery<DONHANG>("SP_DONHANG").ToList();
            return res;
        }
        public string Insert(DONHANG temp)
        {
            if (GetByID(temp.MA) != null)
            {
                temp.DAXOA = false;
                Update(temp);
            }
            else
                context.DONHANGs.Add(temp);
            context.SaveChanges();
            return temp.MA;
        }
        public DONHANG GetByID(string ma)
        {
            return context.DONHANGs.SingleOrDefault(p => p.MA == ma);
        }
        public bool Update(DONHANG temp)
        {
            try
            {
                DONHANG oder = GetByID(temp.MA);
                if (oder != null)
                {
                    oder.MA = temp.MA;
                    oder.TONGTIEN = temp.TONGTIEN;
                    oder.NGAYDATHANG = temp.NGAYDATHANG;
                    oder.NGAYNHANHANG = temp.NGAYNHANHANG;
                    oder.TENNGUOINHAN = temp.TENNGUOINHAN;
                    oder.DIACHINHAN = temp.DIACHINHAN;
                    oder.DIENTHOAINGUOINHAN = temp.DIENTHOAINGUOINHAN;
                    oder.TRANGTHAI = temp.TRANGTHAI;
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
        public bool Delete(DONHANG temp)
        {
            try
            {
                DONHANG oder = GetByID(temp.MA);
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