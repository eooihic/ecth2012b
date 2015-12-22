using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDMT_DOAN.Areas.Admin.Code
{
    public class SessionHelper
    {
        public static void SetSession(UserSession session)
        {
            HttpContext.Current.Session["loginSession"] = session;
        }
        public static UserSession GetSession()
        {
            var sesson = HttpContext.Current.Session["loginSession"];
            if (sesson == null)
                return null;
            else
            {
                return sesson as UserSession;
            }
        }
    }
}