using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TDMT_DOAN.Areas.API.Models
{
    public class OrderModel
    {
        public string order_id { get; set; }
        public string product_id { get; set; }
        public string product_name { get; set; }
        public int product_quantity { get; set; }
    }

    public class OrderShipping
    {
        public string supplier_key { get; set; }
        public string order_id { get; set; }
        public string product_id { get; set; }
        public int product_quantity { get; set; }
        public DateTime product_date { get; set; }
    }

    public class LoginViewModelAPI
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string request_token { get; set; }
    }

    public class Verifier
    {
        public string MyProperty { get; set; }
    }

    public class GetRequesttoken
    {
        public string consumer_key { get; set; }

        public Uri callback { get; set; }
    }

    public class GetVerifier_token
    {
        public string request_token { get; set; }

        public string UserName { get; set; }
    }

    public class GetAccess_token
    {
        public string consumer_key { get; set; }

        public string request_token { get; set; }

        public string verifier_token { get; set; }
    }

    public class Access_token
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public int expires_in { get; set; }

        public string username { get; set; }

        public DateTime issued { get; set; }

        public DateTime tokenType { get; set; }
    }
}