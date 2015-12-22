using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.Admin.Models
{
    public class PurchaseContractModel
    {
        private TMDT_DB3Entities context = null;
        public PurchaseContractModel()
        {
            context = new TMDT_DB3Entities();
        }
        public List<HOPDONGMUAHANG> ListAll()
        {
            var res = context.Database.SqlQuery<HOPDONGMUAHANG>("SP_HOPDONGMUAHANG").ToList();
            return res;
        }
        public string Insert(HOPDONGMUAHANG temp)
        {
            if (GetByID(temp.MAHOPDONG) != null)
            {
                temp.DAXOA = false;
                Update(temp);
            }
            else
                context.HOPDONGMUAHANGs.Add(temp);
            context.SaveChanges();
            return temp.MAHOPDONG;
        }
        public HOPDONGMUAHANG GetByID(string ma)
        {
            return context.HOPDONGMUAHANGs.SingleOrDefault(p => p.MAHOPDONG == ma);
        }
        
        public bool Update(HOPDONGMUAHANG temp)
        {
            try 
            {
                HOPDONGMUAHANG oder = GetByID(temp.MAHOPDONG);
                if (oder != null)
                {
                    oder.NHACUNGCAP = temp.NHACUNGCAP;
                    oder.SANPHAM =temp.SANPHAM;
                    oder.SOLUONGTONKHOTOITHIEU = temp.SOLUONGTONKHOTOITHIEU;
                    oder.THOIGIANGIAOHANGCHAPNHAN = temp.THOIGIANGIAOHANGCHAPNHAN;
                    oder.THOIGIANKI = temp.THOIGIANKI;
                    oder.THOIGIANHOPTAC = temp.THOIGIANHOPTAC;
                    oder.THOIGIANCHUYENTIEN = temp.THOIGIANCHUYENTIEN;
                    oder.SOLUONGGIAOHANG = temp.SOLUONGGIAOHANG;
                    oder.LINKWEBAPI = temp.LINKWEBAPI;
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
        public bool Delete(HOPDONGMUAHANG temp)
        {
            try
            {
                HOPDONGMUAHANG oder = GetByID(temp.MAHOPDONG);
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