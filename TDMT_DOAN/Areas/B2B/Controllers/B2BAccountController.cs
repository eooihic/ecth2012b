using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Areas.B2B.Common;
using TDMT_DOAN.Areas.B2B.DAO;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.B2B.Controllers
{
    public class B2BAccountController : BaseController
    {
        // GET: B2B/Account
        public ActionResult Index()
        {
            var supp = (UserLogin)Session[ConstantValues.USER_SESSION];
            if (supp != null)
            {
                var imp = new UserDAO();
                var res = imp.GetByUsername(supp.username);
                return View(res);
            }
            else return View();
        }
    }
}