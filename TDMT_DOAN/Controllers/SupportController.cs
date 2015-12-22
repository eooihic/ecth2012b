using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Controllers
{
    public class SupportController : Controller
    {
        public TMDT_DB3Entities db = new TMDT_DB3Entities();
        //
        // GET: /Support/
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Newsletter()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult SupportOnline()
        {
            var listsupport = db.HOTROONLINEs.Where(s => s.DAXOA == false).ToList();
            return PartialView(listsupport);
        }
	}
}