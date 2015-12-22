using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Models;
using TDMT_DOAN.Areas.Admin.Models;

namespace TDMT_DOAN.Areas.Admin.Controllers
{
    public class AdminPurchaseContractController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var impPro = new PurchaseContractModel();
            var model = impPro.ListAll();
            return View(model);
        }
        // GET: Admin/AdminProductManage/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HOPDONGMUAHANG collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imlProc = new PurchaseContractModel();
                    collection.DAXOA = false;
                    var res = imlProc.Insert(collection);
                    if (res.CompareTo(null) != 0)
                    {
                        return RedirectToAction("Index", "AdminPurchaseContract");
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
            var imp = new PurchaseContractModel();
            var entity = imp.GetByID(id);
            return View(entity);
        }

        // POST: Admin/AdminProductManage/Edit/5
        [HttpPost]
        public ActionResult Edit(HOPDONGMUAHANG collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imlProc = new PurchaseContractModel();
                    collection.DAXOA = false;
                    var res = imlProc.Update(collection);
                    if (res)
                    {
                        return RedirectToAction("Index", "AdminPurchaseContract");
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
            var imp = new PurchaseContractModel();
            var entity = imp.GetByID(id);
            imp.Delete(entity);

            return RedirectToAction("Index");
        }

        // Delete: Admin/AdminProductManage/Delete/5
        [HttpDelete]
        public ActionResult Delete(HOPDONGMUAHANG collection)
        {
            try
            {

                var imlProc = new PurchaseContractModel();
                var res = imlProc.Delete(collection);
                return RedirectToAction("Index", "AdminPurchaseContract");
            }
            catch
            {
                ModelState.AddModelError("", "Không thể xóa được");
                return View();
            }
        }
    }
}