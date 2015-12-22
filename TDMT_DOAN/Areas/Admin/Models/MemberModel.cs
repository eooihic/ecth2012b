using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDMT_DOAN.Areas.Admin.Code;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.Admin.Models
{
    public class MemberModel
    {
        private TMDT_DB3Entities context = null;
        public MemberModel()
        {
            context = new TMDT_DB3Entities();
        }
        public List<THANHVIEN> ListAll()
        {
            var res = context.Database.SqlQuery<THANHVIEN>("SP_THANHVIEN").ToList();
            return res;
        }
        public int Insert(THANHVIEN temp)
        {
            temp.MATKHAU = HashSHA.encryptSHA(temp.MATKHAU);
            if (GetByID(temp.MA) != null)
            {
                temp.DAXOA = false;
                Update(temp);
            }
            else
                context.THANHVIENs.Add(temp);
            context.SaveChanges();
            return temp.MA;
        }
        public THANHVIEN GetByID(int ma)
        {
            return context.THANHVIENs.SingleOrDefault(p => p.MA == ma);
        }
        
        public bool Update(THANHVIEN temp)
        {
            try 
            {
                THANHVIEN oder = GetByID(temp.MA);
                if (oder != null)
                {
                    oder.TENDANGNHAP = temp.TENDANGNHAP;
                    oder.MATKHAU = temp.MATKHAU;
                    oder.TEN = temp.TEN;
                    oder.DIACHI = temp.DIACHI;
                    oder.DIENTHOAI = temp.DIENTHOAI;
                    oder.EMAIL = temp.EMAIL;
                    oder.THONGTINMOTA = temp.THONGTINMOTA;
                    oder.CUSTOMER_KEY = temp.CUSTOMER_KEY;
                    oder.LoaiThanhVien = temp.LoaiThanhVien;
                    oder.DADANGNHAP = temp.DADANGNHAP;
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
        public bool Delete(THANHVIEN temp)
        {
            try
            {
                THANHVIEN oder = GetByID(temp.MA);
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