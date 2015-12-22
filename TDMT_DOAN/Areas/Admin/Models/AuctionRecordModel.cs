using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.Admin.Models
{
    public class AuctionRecordModel
    {
        private TMDT_DB3Entities context = null;
        public AuctionRecordModel()
        {
            context = new TMDT_DB3Entities();
        }
        public List<BANGGHIDAUGIA> ListAll()
        {
            var res = context.Database.SqlQuery<BANGGHIDAUGIA>("SP_DAUGIA").ToList();
            return res;
        }
        
        public int Insert(BANGGHIDAUGIA temp)
        {
           
            context.BANGGHIDAUGIAs.Add(temp);   
            context.SaveChanges();
            return temp.MA;
        }
        public BANGGHIDAUGIA GetByID(int ma)
        {
            return context.BANGGHIDAUGIAs.SingleOrDefault(p => p.MA == ma);
        }
        public bool Update(BANGGHIDAUGIA temp)
        {
            try
            {
                BANGGHIDAUGIA oder = GetByID(temp.MA);
                if (oder != null)
                {
                    oder.NHACUNGCAP = temp.NHACUNGCAP;
                    oder.SANPHAM = temp.SANPHAM;
                    oder.SOLUONG = temp.SOLUONG;
                    oder.NGAYBATDAU = temp.NGAYBATDAU;
                    oder.NGAYKETTHUC = temp.NGAYKETTHUC;
                    oder.GIA = temp.GIA;
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
        public bool Delete(BANGGHIDAUGIA temp)
        {
            try
            {
                BANGGHIDAUGIA oder = GetByID(temp.MA);
                
                if (oder != null)
                {
                    context.BANGGHIDAUGIAs.Remove(oder);
                    //temp.DAXOA = true;
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