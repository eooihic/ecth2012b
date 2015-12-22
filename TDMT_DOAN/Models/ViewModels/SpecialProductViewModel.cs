using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDMT_DOAN.Models.ViewModels
{
    public class SpecialProductViewModel
    {
        public SANPHAM specialproduct { get; set; }
        public double promotion { get; set; }

        public SpecialProductViewModel()
        {
            specialproduct = new SANPHAM();
            promotion = 0;
        }
    }
}