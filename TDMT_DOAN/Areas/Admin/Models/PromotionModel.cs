using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.Admin.Models
{
    public class PromotionModel
    {
        private TMDT_DB3Entities context = null;
        public PromotionModel()
        {
            context = new TMDT_DB3Entities();
        }
        public List<KHUYENMAI> ListAll()
        {
            var res = context.Database.SqlQuery<KHUYENMAI>("SP_KHUYENMAI").ToList();
            return res;
        }
        public int Insert(KHUYENMAI temp)
        {
            if (GetByID(temp.MA) != null)
            {
                temp.DAXOA = false;
                Update(temp);
            }
            else
                context.KHUYENMAIs.Add(temp);
            context.SaveChanges();
            return temp.MA;
        }
        public KHUYENMAI GetByID(int ma)
        {
            return context.KHUYENMAIs.SingleOrDefault(p => p.MA == ma);
        }
        
        public bool Update(KHUYENMAI temp)
        {
            try 
            {
                KHUYENMAI oder = GetByID(temp.MA);
                if (oder != null)
                {
                    //oder.MA = temp.MA;
                    oder.NGAYBATDAU = temp.NGAYBATDAU;
                    oder.NGAYKETTHUC = temp.NGAYKETTHUC;
                    oder.NOIDUNG = temp.NOIDUNG;
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
        public bool Delete(KHUYENMAI temp)
        {
            try
            {
                KHUYENMAI oder = GetByID(temp.MA);
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