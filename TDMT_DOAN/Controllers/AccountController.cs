﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Models;
using TDMT_DOAN.Models.ViewModels;

namespace TDMT_DOAN.Controllers
{
    public class AccountController : Controller
    {
        LoginCode login = new LoginCode();
        TMDT_DB3Entities tmdt = new TMDT_DB3Entities();

        //
        // GET: /Account/
        [ChildActionOnly]
        public ActionResult Index()
        {
            if (SessionHelper.GetUserSession() == null)
                return PartialView("Index");
            return PartialView("LoginSucess");
        }

        [ChildActionOnly]
        public ActionResult LoginSucess()
        {
            return PartialView();
        }

        public ActionResult Login()
        {
            LoginViewModel loginview = new LoginViewModel();
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
            {
                loginview.UserName = Request.Cookies["UserName"].Value;
                loginview.Password = Request.Cookies["Password"].Value;
            }
            return View(loginview);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginview)
        {
            var user = (from u in tmdt.THANHVIENs where u.TENDANGNHAP == loginview.UserName select u).SingleOrDefault();
            string password = login.encryptSHA(loginview.Password);  // Encode password

            if (password == user.MATKHAU)
            {
                if(loginview.RememberMe == true)
                {
                    Response.Cookies["UserName"].Value = loginview.UserName;
                    Response.Cookies["Password"].Value = loginview.Password;
                }
                SessionHelper.SetUserSession(loginview.UserName);

                //check
                if (SessionHelper.GetCartSession("cart") != null)
                {
                    //copy
                    List<CartSession> list = SessionHelper.GetCartSession("cart");
                    SessionHelper.SetCartSession(loginview.UserName, list);
                }

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Email hoặc mật khẩu không đúng");
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                THANHVIEN thanhvien = new THANHVIEN();
                var user = (from u in tmdt.THANHVIENs where u.TENDANGNHAP == register.UserName || u.EMAIL == register.Email select u).SingleOrDefault();

                if (user != null)
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc Email đã tồn tại");
                    return View();
                }
                else
                {
                    if (!login.CheckEmail(register.Email))  // Check email valid
                    {
                        ModelState.AddModelError("", "Email không có thật");
                    }
                    else
                    {
                        user = (from u in tmdt.THANHVIENs orderby u.MA descending select u).Take(1).SingleOrDefault();
                        if (user == null)
                            thanhvien.MA = 1;
                        else
                            thanhvien.MA = user.MA + 1;
                        thanhvien.TENDANGNHAP = register.UserName;
                        thanhvien.MATKHAU = login.encryptSHA(register.Password);  // Encode password
                        thanhvien.TEN = register.Name;
                        thanhvien.EMAIL = register.Email;
                        tmdt.THANHVIENs.Add(thanhvien);
                        tmdt.SaveChanges();
                        ModelState.AddModelError("", "Đăng kí tài khoản thành công");
                    }
                }
            }

            return View();
        }

        public ActionResult forgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult forgotPassword(ForgotPasswordViewModel forgot)
        {
            // First we must check Email valid
            if (ModelState.IsValid)
            {
                var user = (from u in tmdt.THANHVIENs where u.EMAIL == forgot.Email select u).SingleOrDefault();

                if (user != null)
                {
                    string NewPass = login.RandomPass(8);
                    login.SendPasswordResetEmail(forgot.Email, NewPass);
                    user.MATKHAU = login.encryptSHA(NewPass);
                    tmdt.SaveChanges();
                    ModelState.AddModelError("", "Vui lòng kiểm tra Email để lấy mật khẩu mới");

                }
                else
                    ModelState.AddModelError("", "Email này chưa đăng kí tài khoản");
            }
            return View();
        }


        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ResetPasswordViewModel reset)
        {
            if (SessionHelper.GetUserSession() == null)
                return Redirect("Login");

            if (ModelState.IsValid)
            {
                string username = SessionHelper.GetUserSession();
                var user = (from u in tmdt.THANHVIENs where u.TENDANGNHAP == username select u).SingleOrDefault();
                string PassOld = login.encryptSHA(reset.PasswordOld);

                if (user.MATKHAU == PassOld)
                {
                   user.MATKHAU = login.encryptSHA(reset.Password);
                   tmdt.SaveChanges();
                   ModelState.AddModelError("", "Đổi mật khẩu thành công");
                   
                }
                else
                {
                    ModelState.AddModelError("", "Mật khẩu cũ không đúng");
                }
            }

            return View();
        }

        public ActionResult UpdateAccount()
        {
            if (SessionHelper.GetUserSession() == null)
                return Redirect("Login");
            string username = SessionHelper.GetUserSession();
            var user = (from u in tmdt.THANHVIENs where u.TENDANGNHAP == username select u).SingleOrDefault();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAccount(FormCollection collection)
        {
            string username = SessionHelper.GetUserSession();
            var user = (from u in tmdt.THANHVIENs where u.TENDANGNHAP == username select u).SingleOrDefault();
            user.TEN = collection["TEN"];
            user.DIACHI = collection["DIACHI"];
            user.DIENTHOAI = collection["DIENTHOAI"];
            string EMAIL = collection["EMAIL"];
            user.THONGTINMOTA = collection["THONGTINMOTA"];
            var userofemail = tmdt.THANHVIENs.Where(us => us.EMAIL == EMAIL && us.TENDANGNHAP != username).SingleOrDefault();

            if (userofemail != null)
                ModelState.AddModelError("", "Lỗi, Email đã đăng kí rồi ");
            else
            {
                ModelState.AddModelError("", "Cập nhật tài khoản thành công ");
                tmdt.SaveChanges();
            }

            return View(user);
        }

        public ActionResult SignUpSuccess()
        {
            return View();
        }

        public ActionResult Logout()
        {
            //SessionHelper.SetCartSession(SessionHelper.GetUserSession(), null);
            if (SessionHelper.GetCartSession(SessionHelper.GetUserSession()) != null)
            {
                List<CartSession> list = SessionHelper.GetCartSession(SessionHelper.GetUserSession());
                SessionHelper.SetCartSession("cart", list);
            }
            SessionHelper.SetUserSession(null);
            return Redirect("Login");
        }

    }
}