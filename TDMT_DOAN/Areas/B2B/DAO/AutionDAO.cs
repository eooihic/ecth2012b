using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.B2B.DAO
{
    public class AutionDAO
    {
        private TDMT_DOAN.Models.TMDT_DB3Entities context = null;
        public AutionDAO()
        {
            context = new TDMT_DOAN.Models.TMDT_DB3Entities();
        }
        public bool AddAution(BANGGHIDAUGIA item)
        {
            foreach (var record in context.BANGGHIDAUGIAs)
            {
                if (record.SANPHAM == item.SANPHAM && record.SOLUONG == item.SOLUONG && record.NHACUNGCAP == item.NHACUNGCAP)
                {
                    return false;
                }
            }
            item.MA = GetMaxIndexOfAutionRecord() + 1;
            context.BANGGHIDAUGIAs.Add(item);
            context.SaveChanges();
            return true;

        }
        public int GetMaxIndexOfAutionRecord()
        {
            int max = 0;
            foreach (var item in context.BANGGHIDAUGIAs)
            {
                if (item.MA > max)
                {
                    max = item.MA;
                }
            }
            return max;
        }

    }
}