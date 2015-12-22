using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.Admin.Models
{
    public class StyleMemberModel
    {
        private TMDT_DB3Entities context = null;
        public StyleMemberModel()
        {
            context = new TMDT_DB3Entities();
        }
        public List<LOAITHANHVIEN> ListAll()
        {
            var res = context.Database.SqlQuery<LOAITHANHVIEN>("SP_LOAITHANHVIEN").ToList();
            return res;
        }
        public int Insert(LOAITHANHVIEN temp)
        {
            if (GetByID(temp.LoaiTV) != null)
            {
                temp.DAXOA = false;
                Update(temp);
            }
            else
                context.LOAITHANHVIENs.Add(temp);
            context.SaveChanges();
            return temp.LoaiTV;
        }
        public LOAITHANHVIEN GetByID(int ma)
        {
            return context.LOAITHANHVIENs.SingleOrDefault(p => p.LoaiTV  == ma);
        }
        public bool Update(LOAITHANHVIEN temp)
        {
            try
            {
                LOAITHANHVIEN oder = GetByID(temp.LoaiTV);
                if (oder != null)
                {
                    oder.LoaiTV = temp.LoaiTV;
                    oder.TENLOAI = temp.TENLOAI;
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
        public bool Delete(LOAITHANHVIEN temp)
        {
            try
            {
                LOAITHANHVIEN oder = GetByID(temp.LoaiTV);
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