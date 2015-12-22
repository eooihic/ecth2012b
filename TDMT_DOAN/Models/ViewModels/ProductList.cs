using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDMT_DOAN.Models.ViewModels
{
    public class ProductList
    {
      
        public List<SANPHAM> productList { get; set; }
        public List<double> productListPromotion { get; set; }
        public string path { get; set; }


        public ProductList()
        {
            productList = new List<SANPHAM>();
            productListPromotion = new List<double>();
            path = "";
        }
       
    }
}