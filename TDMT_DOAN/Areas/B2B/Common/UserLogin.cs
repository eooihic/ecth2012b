using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDMT_DOAN.Areas.B2B.Common
{
    [Serializable]
    public class UserLogin
    {
        public string username { set; get; }
        public string password { set; get; }
    }
}