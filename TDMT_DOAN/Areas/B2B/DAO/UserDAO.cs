using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.B2B.DAO
{
    public class UserDAO
    {
        private TDMT_DOAN.Models.TMDT_DB3Entities context = null;
        public UserDAO()
        {
            context = new TDMT_DOAN.Models.TMDT_DB3Entities();
        }
        //public List<THANHVIEN> ListAllSellProduct()
        //{
        //    return context.SANPHAMs.Where(x => x.SANPHAMBAN == true && x.SOLUONG > 250).ToList();
        //}
        //public int Logout(string username,string password)
        //{
        //    var res = context.NHACUNGCAPs.SingleOrDefault(x => x.TENDANGNHAP == username && x.MATKHAU == password);
        //    if (res == null)
        //    {
        //        return -1;// không có tài khoản
        //    }
        //    else
        //    {
        //        if (res.DADANGNHAP == false)
        //            return 0;//chưa đăng nhập
        //        res.DADANGNHAP = false;
        //        context.SaveChanges();

        //    }
        //}
        public int Login(string username, string password)
        {
            var res =  context.NHACUNGCAPs.SingleOrDefault(x => x.TENDANGNHAP == username && x.MATKHAU == password);
            if (res == null)
            {
                return -1;// không có tài khoản
            }
            else if (res.DAXOA == true)
            {
                return -2;// tài khoản bị khóa
            }
            //else
            //{
            //    if (res.DADANGNHAP == true)
            //    {
            //        return -3;//tài khoản đã đăng nhập
            //    }
            //    res.DADANGNHAP = true;
            //    context.SaveChanges();
            //    return 1;
            //}
            else
            {
                return 1;
            }
                
        }
        public NHACUNGCAP GetByUsername(string username)
        {
            return context.NHACUNGCAPs.SingleOrDefault(x => x.TENDANGNHAP == username);
        }
        public List<HOPDONGMUAHANG> GetContractByUsername(string username)
        {
            return context.HOPDONGMUAHANGs.Where(x => x.NHACUNGCAP == username).ToList();
        }
        public List<BANGGHIDAUGIA> GetAutionRecordByUsername(string username)
        {
            return context.BANGGHIDAUGIAs.Where(x=>x.NHACUNGCAP == username).ToList();
        }
    }
}