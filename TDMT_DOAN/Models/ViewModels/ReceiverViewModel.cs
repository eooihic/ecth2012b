using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TDMT_DOAN.Models.ViewModels
{
    public class ReceiverViewModel
    {
        [Required(ErrorMessage="Không được bỏ trống")]
        public string name { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống")]
        public string phone { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống")]
        public string address { get; set; }
    }
}