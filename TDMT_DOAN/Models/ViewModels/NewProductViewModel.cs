using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDMT_DOAN.Models.ViewModels
{
    public class NewProductViewModel
    {
        public SANPHAM newproduct { get; set; }
        public double promotion { get; set; }

        public NewProductViewModel()
        {
            newproduct = new SANPHAM();
            promotion = 0;
        }

    }
}