using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TDMT_DOAN.Areas.B2B.Common;

namespace TDMT_DOAN.Areas.B2B.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (UserLogin) Session[ConstantValues.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { action = "Index", controller = "B2BLogin", Area = "B2B" }));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}