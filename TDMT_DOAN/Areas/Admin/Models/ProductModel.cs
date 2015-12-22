using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.Admin.Models
{
    public class ProductModel
    {
        private TMDT_DB3Entities context = null;
        public ProductModel()
        {
            context = new TMDT_DB3Entities();
        }
        public List<SANPHAM> ListAll()
        {
            var res = context.Database.SqlQuery<SANPHAM>("SP_LAYSANPHAM").ToList();
            return res;
        }
        public string Insert(SANPHAM temp)
        {
            if (GetByID(temp.MA) != null)
            {
                temp.DAXOA = false;
                Update(temp);
            }
            else
                context.SANPHAMs.Add(temp);
            context.SaveChanges();
            return temp.MA;
        }
        public SANPHAM GetByID(string ma)
        {
            return context.SANPHAMs.SingleOrDefault(p => p.MA == ma);
        }
        
        public bool Update(SANPHAM temp)
        {
            try 
            {
                SANPHAM oder = GetByID(temp.MA);
                if (oder != null)
                {
                    oder.TEN = temp.TEN;
                    oder.DONGIAMUA = temp.DONGIAMUA;
                    oder.DONGIABAN = temp.DONGIABAN;
                    oder.HINHANH = temp.HINHANH;
                    oder.MOTA = temp.MOTA;
                    oder.SOLUONG= temp.SOLUONG;
                    oder.LOAISANPHAM = temp.LOAISANPHAM;
                    oder.SANPHAMMOI= temp.SANPHAMMOI;
                    oder.NHASANXUAT = temp.NHASANXUAT;
                    oder.SANPHAMBANCHAY = temp.SANPHAMBANCHAY;
                    oder.DAXOA = temp.DAXOA;
                    oder.DAUGIA = temp.DAUGIA;
                    oder.SANPHAMBAN = temp.SANPHAMBAN;
                    oder.MAKHUYENMAI = temp.MAKHUYENMAI;
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
        public bool Delete(SANPHAM temp)
        {
            try
            {
                SANPHAM oder = GetByID(temp.MA);
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