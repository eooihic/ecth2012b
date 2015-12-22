using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDMT_DOAN.Models;
namespace TDMT_DOAN.Areas.B2B.DAO
{
    public class ProductDAO
    {
        private TDMT_DOAN.Models.TMDT_DB3Entities context = null;
        public ProductDAO()
        {
            context = new TDMT_DOAN.Models.TMDT_DB3Entities();
        }
        public List<SANPHAM> ListAllSellProduct()
        {
            return context.SANPHAMs.Where(x=>x.SANPHAMBAN == true && x.SOLUONG > 250).ToList();
        }
        public string GetProductNameById(string id)
        {
            var res = context.SANPHAMs.SingleOrDefault(x => x.MA == id);
            if (res != null)
            {
                return res.TEN;
            }
            return null;
        }
        public List<SANPHAM> ListAllAutionProducts()
        {
            return context.SANPHAMs.Where(x => x.DAUGIA == true).ToList();
        }
    }
}