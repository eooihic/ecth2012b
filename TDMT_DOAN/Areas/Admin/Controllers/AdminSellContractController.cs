using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Models;
using TDMT_DOAN.Areas.Admin.Models;

namespace TDMT_DOAN.Areas.Admin.Controllers
{
    public class AdminSellContractController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var impPro = new SellContractModel();
            var model = impPro.ListAll();
            return View(model);
        }
        // GET: Admin/AdminProductManage/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HOPDONGBANHANG collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imlProc = new SellContractModel();
                    collection.DAXOA = false;
                    var res = imlProc.Insert(collection);
                    if (res.CompareTo(null) != 0)
                    {
                        return RedirectToAction("Index", "AdminSellContract");
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

        public ActionResult Edit(string id)
        {
            var imp = new SellContractModel();
            var entity = imp.GetByID(id);
            return View(entity);
        }

        // POST: Admin/AdminProductManage/Edit/5
        [HttpPost]
        public ActionResult Edit(HOPDONGBANHANG collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imlProc = new SellContractModel();
                    collection.DAXOA = false;
                    var res = imlProc.Update(collection);
                    if (res)
                    {
                        return RedirectToAction("Index", "AdminSellContract");
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
        // GET: Admin/AdminProductManage/Delete/5
        public ActionResult Delete(string id)
        {
            var imp = new SellContractModel();
            var entity = imp.GetByID(id);
            imp.Delete(entity);

            return RedirectToAction("Index");
        }

        // Delete: Admin/AdminProductManage/Delete/5
        [HttpDelete]
        public ActionResult Delete(HOPDONGBANHANG collection)
        {
            try
            {

                var imlProc = new SellContractModel();
                var res = imlProc.Delete(collection);
                return RedirectToAction("Index", "AdminSellContract");
            }
            catch
            {
                ModelState.AddModelError("", "Không thể xóa được");
                return View();
            }
        }
    }
}