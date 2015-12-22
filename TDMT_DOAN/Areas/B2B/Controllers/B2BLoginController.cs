using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Areas.B2B.Common;
using TDMT_DOAN.Areas.B2B.DAO;
using TDMT_DOAN.Areas.B2B.Models;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.B2B.Controllers
{
    public class B2BLoginController : Controller
    {
        // GET: B2B/Login
        public ActionResult Index()
        {
           
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(NHACUNGCAP model)
        {
            if (ModelState.IsValid)
            {
                var imp = new UserDAO();
                var res = imp.Login(model.TENDANGNHAP, model.MATKHAU);
                var sess = (UserLogin)Session[ConstantValues.USER_SESSION];
                if (sess != null)
                {
                    ModelState.AddModelError("", "Tài khoản đã đăng nhập");
                    return View(model);
                }

                if (res == -1)
                {
                    ModelState.AddModelError("", "Không tồn tại tài khoản này");
                    return View(model);
                }
                if (res == -2)
                {
                    ModelState.AddModelError("", "Tài khoản bị khóa");
                    return View(model);
                }
                if (res == -3)
                {
                    ModelState.AddModelError("", "Tài khoản đã được đăng nhập");
                }
                if (res == 1)
                {
                    UserLogin u = new UserLogin() { username = model.TENDANGNHAP, password = model.MATKHAU };
                    var supplier_name = u.username;
                    Session.Add(ConstantValues.USER_SESSION, u);
                    return RedirectToAction("Index", "User");
                }
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu sai");
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu sai");
                return View();
            }
        }
        public ActionResult Logout()
        {
            var sess = Session[ConstantValues.USER_SESSION];
            if (sess != null)
            {
                Session.Remove(ConstantValues.USER_SESSION);
                return RedirectToAction("Index", "B2BHome");
            }
            else
            {
                ModelState.AddModelError("", "Chưa đăng nhập");
                return RedirectToAction("Index", "B2BLogin");
            }
        }
    }
}