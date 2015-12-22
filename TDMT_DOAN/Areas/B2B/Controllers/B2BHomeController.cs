using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Areas.B2B.DAO;

namespace TDMT_DOAN.Areas.B2B.Controllers
{
    public class B2BHomeController : Controller
    {
        // GET: B2B/Home
        public ActionResult Index()
        {
            var imp = new ProductDAO();
            var res = imp.ListAllAutionProducts();
            return View(res);
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult MyAccount()
        {
            return View();
        }
    }
}