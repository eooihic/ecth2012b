using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TDMT_DOAN.Areas.B2B.Models
{
    public partial class LoginModel
    {
        [Key]
        [Required(ErrorMessage = "Thiếu tên đăng nhập")]
        public string username;

        [Required(ErrorMessage = "Thiếu có mật khẩu")]
        public string passwork;

        public bool remberme;
    }
}