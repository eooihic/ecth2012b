using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.Admin.Models
{
    public class LinkAPIModel
    {
        private TMDT_DB3Entities context = null;
        public LinkAPIModel()
        {
            context = new TMDT_DB3Entities();
        }
        public List<TDMT_DOAN.Models.API> ListAll()
        {
            var res = context.Database.SqlQuery<TDMT_DOAN.Models.API>("SP_API").ToList();
            return res;
        }

        public int Insert(TDMT_DOAN.Models.API temp)
        {
            if (GetByID(temp.MA) != null)
            {
                temp.DAXOA = false;
                Update(temp);
            }
            else
                context.APIs.Add(temp);
            context.SaveChanges();
            return temp.MA;
        }
        public TDMT_DOAN.Models.API GetByID(int ma)
        {
            return context.APIs.SingleOrDefault(p => p.MA == ma);
        }
        public bool Update(TDMT_DOAN.Models.API temp)
        {
            try
            {
                TDMT_DOAN.Models.API oder = GetByID(temp.MA);
                if (oder != null)
                {
                    oder.LINK = temp.LINK;
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
        public bool Delete(TDMT_DOAN.Models.API temp)
        {
            try
            {
                TDMT_DOAN.Models.API oder = GetByID(temp.MA);
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