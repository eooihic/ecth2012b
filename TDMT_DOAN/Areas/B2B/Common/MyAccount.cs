using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TDMT_DOAN.Areas.B2B.Common
{
    public class MyAccount
    {
        [DisplayName("Tên đăng nhập")]
        public string TENDANGNHAP { get; set; }

        [DisplayName("Mật khẩu")]
        public string MATKHAU { get; set; }

        [DisplayName("Họ tên")]
        public string TEN { get; set; }

        [DisplayName("Địa chỉ")]
        public string DIACHI { get; set; }

        [DisplayName("Điện thoại")]
        public string DIENTHOAI { get; set; }

        [DisplayName("Email")]
        public string EMAIL { get; set; }
    }
}