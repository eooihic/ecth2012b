using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.Admin.Models
{
    public class DetailOrderModel
    {
        private TMDT_DB3Entities context = null;
        public DetailOrderModel()
        {
            context = new TMDT_DB3Entities();
        }
        public List<CHITIETDONHANG> ListAll()
        {
            var res = context.Database.SqlQuery<CHITIETDONHANG>("SP_CHITIETDONHANG").ToList();
            return res;
        }
        public string Insert(CHITIETDONHANG temp)
        {
            if (GetByID(temp.DONHANG,temp.SANPHAM) != null)
            {
                temp.DAXOA = false;
                Update(temp);
            }
            else
                context.CHITIETDONHANGs.Add(temp);
            context.SaveChanges();
            return temp.DONHANG;
        }
        public CHITIETDONHANG GetByID(string MaDonHang, string MaSanPham)
        {
            return context.CHITIETDONHANGs.SingleOrDefault(p => p.DONHANG == MaDonHang && p.SANPHAM == MaSanPham);
        }
        public bool Update(CHITIETDONHANG temp)
        {
            try
            {
                CHITIETDONHANG oder = GetByID(temp.DONHANG,temp.SANPHAM);
                if (oder != null)
                {
                    oder.SOLUONG = temp.SOLUONG;
                    oder.THANHTIEN = temp.THANHTIEN;
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
        public bool Delete(CHITIETDONHANG temp)
        {
            try
            {
                CHITIETDONHANG oder = GetByID(temp.DONHANG,temp.SANPHAM);
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