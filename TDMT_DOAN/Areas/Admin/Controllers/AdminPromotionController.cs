﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Models;
using TDMT_DOAN.Areas.Admin.Models;

namespace TDMT_DOAN.Areas.Admin.Controllers
{
    public class AdminPromotionController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var impPro = new PromotionModel();
            var model = impPro.ListAll();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(KHUYENMAI collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imlProc = new PromotionModel();
                    collection.DAXOA = false;
                    var res = imlProc.Insert(collection);
                    if (res.CompareTo(null) != 0)
                    {
                        return RedirectToAction("Index", "AdminPromotion");
                    }

                }
                ModelState.AddModelError("", "Không thể tạo mói được");
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var imp = new PromotionModel();
            var entity = imp.GetByID(id);
            return View(entity);
        }


        [HttpPost]
        public ActionResult Edit(KHUYENMAI collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imlProc = new PromotionModel();
                    collection.DAXOA = false;
                    var res = imlProc.Update(collection);
                    if (res)
                    {
                        return RedirectToAction("Index", "AdminPromotion");
                    }

                }
                ModelState.AddModelError("", "Không thể chỉnh sửa được mói được");
                return View(collection);
            }
            catch
            {
                ModelState.AddModelError("", "Không thể chỉnh sửa được mói được");
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            var imp = new PromotionModel();
            var entity = imp.GetByID(id);
            imp.Delete(entity);

            return RedirectToAction("Index");
        }

        // Delete: Admin/AdminProductManage/Delete/5
        [HttpDelete]
        public ActionResult Delete(KHUYENMAI collection)
        {
            try
            {

                var imlProc = new PromotionModel();
                var res = imlProc.Delete(collection);
                return RedirectToAction("Index", "AdminProducer");
            }
            catch
            {
                ModelState.AddModelError("", "Không thể xóa được");
                return View();
            }
        }
    }
}