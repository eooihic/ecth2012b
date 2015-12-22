using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.Admin.Models
{
    public class SupplierModel
    {
        private TMDT_DB3Entities context = null;
        public SupplierModel()
        {
            context = new TMDT_DB3Entities();
        }
        public List<NHACUNGCAP> ListAll()
        {
            var res = context.Database.SqlQuery<NHACUNGCAP>("SP_LAYNHACUNGCAP").ToList();
            return res;
        }

        public string Insert(NHACUNGCAP temp)
        {
            if (GetByID(temp.MA) != null)
            {
                temp.DAXOA = false;
                Update(temp);
            }
            else
                context.NHACUNGCAPs.Add(temp);
            context.SaveChanges();
            return temp.MA;
        }
        public NHACUNGCAP GetByID(string ma)
        {
            return context.NHACUNGCAPs.SingleOrDefault(p => p.MA == ma);
        }
        public NHACUNGCAP ViewDetails(string ma)
        {
            return context.NHACUNGCAPs.SingleOrDefault(p => p.MA == ma);
        }
        public bool Update(NHACUNGCAP temp)
        {
            try
            {
                NHACUNGCAP oder = GetByID(temp.MA);
                if (oder != null)
                {
                    oder.TENDANGNHAP = temp.TENDANGNHAP;
                    oder.MATKHAU = temp.MATKHAU;
                    oder.TEN = temp.TEN;
                    oder.DIACHI = temp.DIACHI;
                    oder.DIENTHOAI = temp.DIENTHOAI;
                    oder.EMAIL = temp.EMAIL;
                    oder.supplier_key = temp.supplier_key;
                    oder.request_token = temp.request_token;
                    oder.verifier_token = temp.verifier_token;
                    oder.callback = temp.callback;
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
        public bool Delete(NHACUNGCAP temp)
        {
            try
            {
                NHACUNGCAP oder = GetByID(temp.MA);
                if (oder != null)
                {
                    temp.DAXOA = true;
                    //context.NHACUNGCAPs.Remove(oder);
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