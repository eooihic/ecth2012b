using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TDMT_DOAN.Areas.B2B.Models
{
    public class AutionRecordModel
    {
        [DisplayName("ID")]
        public int id { get; set; }

        [DisplayName("Tên đăng nhập")]
        public string username { get; set; }

        [DisplayName("Mật khẩu")]
        public string passwork { get; set; }

        [DisplayName("Là khách")]
        public bool isGest { get; set; }

        [DisplayName("Email")]
        public string email { get; set; }

        [DisplayName("Điện thoại")]
        public string phone { get; set; }

        [DisplayName("Mã sản phẩm")]
        public string productID { get; set; }

        [DisplayName("Số lượng")]
        public int quantity { get; set; }

        [DisplayName("Giá cả")]
        public double price { get; set; }
    }
}