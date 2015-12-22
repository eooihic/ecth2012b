using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Areas.B2B.Common;
using TDMT_DOAN.Areas.B2B.DAO;

namespace TDMT_DOAN.Areas.B2B.Controllers
{
    public class UserController : BaseController
    {
        // GET: B2B/User/name
        public ActionResult Index()
        {
            var supp = (UserLogin)Session[ConstantValues.USER_SESSION];
            if (supp != null)
            {
                var imp = new UserDAO();
                var res = imp.GetByUsername(supp.username);
                return View(res);
            }
            return View();

        }
        public ActionResult ContractsShow()
        {
            var supp = (UserLogin)Session[ConstantValues.USER_SESSION];
            if (supp != null)
            {
                var imp = new UserDAO();
                var res = imp.GetContractByUsername(supp.username);
                ViewBag.UserName = supp.username;
                return View(res);
            }
            return View();
        }
        public ActionResult AutionRecordShow()
        {
            var supp = (UserLogin)Session[ConstantValues.USER_SESSION];
            if (supp != null)
            {
                var imp = new UserDAO();
                var res = imp.GetAutionRecordByUsername(supp.username);
                ViewBag.UserName = supp.username;
                return View(res);
            }
            return View();
        }
    }
}