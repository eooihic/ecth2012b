using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.Admin.Models
{
    public class SellContractModel
    {
        private TMDT_DB3Entities context = null;
        public SellContractModel()
        {
            context = new TMDT_DB3Entities();
        }
        public List<HOPDONGBANHANG> ListAll()
        {
            var res = context.Database.SqlQuery<HOPDONGBANHANG>("SP_HOPDONGBANHANG").ToList();
            return res;
        }
        public string Insert(HOPDONGBANHANG temp)
        {
            if (GetByID(temp.MAHOPDONG) != null)
            {
                temp.DAXOA = false;
                Update(temp);
            }
            else
                context.HOPDONGBANHANGs.Add(temp);
            context.SaveChanges();
            return temp.MAHOPDONG;
        }
        public HOPDONGBANHANG GetByID(string ma)
        {
            return context.HOPDONGBANHANGs.SingleOrDefault(p => p.MAHOPDONG == ma);
        }
        
        public bool Update(HOPDONGBANHANG temp)
        {
            try 
            {
                HOPDONGBANHANG oder = GetByID(temp.MAHOPDONG);
                if (oder != null)
                {
                    oder.THANHVIEN = temp.THANHVIEN;
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
        public bool Delete(HOPDONGBANHANG temp)
        {
            try
            {
                HOPDONGBANHANG oder = GetByID(temp.MAHOPDONG);
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