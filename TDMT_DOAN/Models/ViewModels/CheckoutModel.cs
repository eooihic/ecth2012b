using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDMT_DOAN.Models.ViewModels
{
    public class CheckoutModel
    {
        public List<CartSession> listCartSession { get; set; }
        public THANHVIEN user { get; set; }


        public CheckoutModel()
        {
            listCartSession = new List<CartSession>();
            user = new THANHVIEN();
        }
    }
}