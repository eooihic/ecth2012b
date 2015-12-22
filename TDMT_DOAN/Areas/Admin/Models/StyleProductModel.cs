using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.Admin.Models
{
    public class StyleProductModel
    {
        private TMDT_DB3Entities context = null;
        public StyleProductModel()
        {
            context = new TMDT_DB3Entities();
        }
        public List<LOAISANPHAM> ListAll()
        {
            var res = context.Database.SqlQuery<LOAISANPHAM>("SP_LOAISANPHAM").ToList();
            return res;
        }
        public string GetStyleProductByID(int Ma)
        {
            return context.LOAISANPHAMs.SingleOrDefault(p => p.MA == Ma).TEN;
        }
        public int Insert(LOAISANPHAM temp)
        {
            if (GetByID(temp.MA) != null)
            {
                temp.DAXOA = false;
                Update(temp);
            }
            else
                context.LOAISANPHAMs.Add(temp);
            context.SaveChanges();
            return temp.MA;
        }
        public LOAISANPHAM GetByID(int ma)
        {
            return context.LOAISANPHAMs.SingleOrDefault(p => p.MA == ma);
        }
        public bool Update(LOAISANPHAM temp)
        {
            try
            {
                LOAISANPHAM oder = GetByID(temp.MA);
                if (oder != null)
                {
                    oder.TEN = temp.TEN;
                    oder.SANPHAMBAN = temp.SANPHAMBAN;
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
        public bool Delete(LOAISANPHAM temp)
        {
            try
            {
                LOAISANPHAM oder = GetByID(temp.MA);
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