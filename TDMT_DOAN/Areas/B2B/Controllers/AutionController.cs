using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Areas.B2B.Common;
using TDMT_DOAN.Areas.B2B.DAO;
using TDMT_DOAN.Areas.B2B.Models;
using TDMT_DOAN.Areas.B2B.Models.ViewModels;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.B2B.Controllers
{
    public class AutionController : BaseController
    {
        // GET: B2B/Aution

        public ActionResult Index(BANGGHIDAUGIA model)
        {
            if (ModelState.IsValid)
            {
                if (model.SANPHAM == "" || model.SANPHAM == null)
                {
                    ModelState.AddModelError("", "Thieu email de lien lac");
                }
                return View(model);
            }
            ModelState.AddModelError("", "Ban ghi khong duoc chap nhan");
            return View(model);
        }
        [HttpGet]
        public ActionResult CompleteAution(string id)
        {
            BANGGHIDAUGIA temp = new BANGGHIDAUGIA();

            var userSession = (UserLogin)Session[ConstantValues.USER_SESSION];
            if (userSession != null)
            {
                temp.NHACUNGCAP = userSession.username;
                temp.SANPHAM = id;
                return View(temp);
            }
            ModelState.AddModelError("", "Sai mẫu bảng đấu giá");
            return View(temp);
        }

        [HttpPost]
        public ActionResult AddAutionRecord(BANGGHIDAUGIA entity)
        {
            if (ModelState.IsValid)
            {
                var imp = new AutionDAO();
                var res = imp.AddAution(entity);
                if (res)
                {
                    return RedirectToAction("Index", "B2BHome");
                }
            }
            ModelState.AddModelError("", "Bản đấu giá không được chấp nhận");
            return View();
            //if (ModelState.IsValid)
            //{
            //    var res = AutionRecoreList.GetInstance();
            //    bool result = res.AddAutionRecord(model);
            //    if (result)
            //    {
            //        if (model.email == "" || model.email == null)
            //        {
            //            return RedirectToAction("Index", "Aution", model);
            //        }
            //        return RedirectToAction("Index", "B2BHome");
            //    }
            //    else
            //    {
            //        return RedirectToAction("Index", "Aution");
            //    }
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Bản đấu giá không được chấp nhận");
            //    return View();
            //}

        }
    }
}