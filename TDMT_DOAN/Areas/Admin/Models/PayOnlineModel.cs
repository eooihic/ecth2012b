using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.Admin.Models
{
    public class PayOnlineModel
    {
        private TMDT_DB3Entities context = null;
        public PayOnlineModel()
        {
            context = new TMDT_DB3Entities();
        }
        public List<THANHTOANONLINE> ListAll()
        {
            var res = context.Database.SqlQuery<THANHTOANONLINE>("SP_THANHTOANONLINE").ToList();
            return res;
        }
        public int Insert(THANHTOANONLINE temp)
        {
            if (GetByID(temp.MA) != null)
            {
                temp.DAXOA = false;
                Update(temp);
            }
            else
                context.THANHTOANONLINEs.Add(temp);
            context.SaveChanges();
            return temp.MA;
        }
        public THANHTOANONLINE GetByID(int ma)
        {
            return context.THANHTOANONLINEs.SingleOrDefault(p => p.MA == ma);
        }
        
        public bool Update(THANHTOANONLINE temp)
        {
            try 
            {
                THANHTOANONLINE oder = GetByID(temp.MA);
                if (oder != null)
                {
                    oder.EMAIL = temp.EMAIL;
                    oder.MATHANHVIEN = temp.MATHANHVIEN;
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
        public bool Delete(THANHTOANONLINE temp)
        {
            try
            {
                THANHTOANONLINE oder = GetByID(temp.MA);
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
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}