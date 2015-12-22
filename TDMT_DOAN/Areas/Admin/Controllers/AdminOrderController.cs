using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Models;
using TDMT_DOAN.Areas.Admin.Models;

namespace TDMT_DOAN.Areas.Admin.Controllers
{
    public class AdminOrderController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var impPro = new OrderModel();
            var model = impPro.ListAll();
            var statusorder = new StatusOrderModel();
            ViewBag.status = statusorder;
            return View(model);
        }

        public ActionResult Create()
        {
            var statusorder = new StatusOrderModel().ListAll();
            List<SelectListItem> list =new List<SelectListItem>();
            foreach(var item in statusorder)
            {
                list.Add(new SelectListItem() { Text = item.TINHTRANG, Value = item.MA.ToString() });
            }
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult Create(DONHANG collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imlProc = new OrderModel();
                    collection.DAXOA = false;
                    var res = imlProc.Insert(collection);
                    if (res.CompareTo(null) != 0)
                    {
                        return RedirectToAction("Index", "AdminOrder");
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
            var imp = new OrderModel();
            var entity = imp.GetByID(id);
            var statusorder = new StatusOrderModel().ListAll();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in statusorder)
            {
                list.Add(new SelectListItem() { Text = item.TINHTRANG, Value = item.MA.ToString() });
            }
            ViewBag.list = list;
            return View(entity);
        }

        
        [HttpPost]
        public ActionResult Edit(DONHANG collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imlProc = new OrderModel();
                    collection.DAXOA = false;
                    var res = imlProc.Update(collection);
                    if (res)
                    {
                        return RedirectToAction("Index", "AdminOrder");
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
        public ActionResult Delete(string id)
        {
            var imp = new OrderModel();
            var entity = imp.GetByID(id);
            imp.Delete(entity);

            return RedirectToAction("Index");
        }

        // Delete: Admin/AdminProductManage/Delete/5
        [HttpDelete]
        public ActionResult Delete(DONHANG collection)
        {
            try
            {

                var imlProc = new OrderModel();
                var res = imlProc.Delete(collection);
                return RedirectToAction("Index", "AdminOrder");
            }
            catch
            {
                ModelState.AddModelError("", "Không thể xóa được");
                return View();
            }
        }
    }
}