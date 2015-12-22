using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Models;
using TDMT_DOAN.Areas.Admin.Models;

namespace TDMT_DOAN.Areas.Admin.Controllers
{
    public class AdminSupplierController : Controller
    {
        [Authorize]
        // GET: /Admin/AdminSupplier/
        public ActionResult Index()
        {
            var impPro = new SupplierModel();
            var model = impPro.ListAll();
            return View(model);
        }

        // GET: Admin/AdminSupplier/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NHACUNGCAP collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imlProc = new SupplierModel();
                    collection.DAXOA = false;
                    var res = imlProc.Insert(collection);
                    if (res.CompareTo(null) != 0)
                    {
                        return RedirectToAction("Index", "AdminSupplier");
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
            var imp = new SupplierModel();
            var entity = imp.GetByID(id);
            return View(entity);
        }

        // POST: Admin/AdminSupplier/Edit/5
        [HttpPost]
        public ActionResult Edit(NHACUNGCAP collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imlProc = new SupplierModel();
                    collection.DAXOA = false;
                    var res = imlProc.Update(collection);
                    if (res)
                    {
                        return RedirectToAction("Index", "AdminSupplier");
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
        // GET: Admin/AdminSupplier/Delete/5
        public ActionResult Delete(string id)
        {
            var imp = new SupplierModel();
            var entity = imp.GetByID(id);
            imp.Delete(entity);

            return RedirectToAction("Index");
        }

        // Delete: Admin/AdminSupplier/Delete/5
        [HttpDelete]
        public ActionResult Delete(NHACUNGCAP collection)
        {
            try
            {

                var imlProc = new SupplierModel();
                var res = imlProc.Delete(collection);
                return RedirectToAction("Index", "AdminSupplier");
            }
            catch
            {
                ModelState.AddModelError("", "Không thể xóa được");
                return View();
            }
        }
    }
}

