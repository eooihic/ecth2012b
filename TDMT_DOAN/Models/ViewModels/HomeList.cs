using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDMT_DOAN.Models.ViewModels
{
    public class HomeList
    {
        public List<SANPHAM> newList { get; set; }
        public List<double> newListPromotion { get; set; }
        public List<SANPHAM> specialList { get; set; }
        public List<double> specialListPromotion { get; set; }

        public HomeList()
        {
            newList = new List<SANPHAM>();
            newListPromotion = new List<double>();
            specialList = new List<SANPHAM>();
            specialListPromotion = new List<double>();

        }
    }
}