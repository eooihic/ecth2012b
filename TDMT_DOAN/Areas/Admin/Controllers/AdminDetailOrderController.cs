using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Models;
using TDMT_DOAN.Areas.Admin.Models;

namespace TDMT_DOAN.Areas.Admin.Controllers
{
    public class AdminDetailOrderController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var impPro = new DetailOrderModel();
            var model = impPro.ListAll();
            return View(model);
        }

        public ActionResult Create()
        {
            var order = new OrderModel().ListAll();
            List<SelectListItem> listorder = new List<SelectListItem>();
            foreach (var item in order)
            {
                listorder.Add(new SelectListItem() { Text = item.MA, Value = item.MA });
            }
            ViewBag.listorder = listorder;

            var pro = new ProductModel().ListAll();
            List<SelectListItem> listpro = new List<SelectListItem>();
            foreach (var item in pro)
            {
                listpro.Add(new SelectListItem() { Text = item.MA,Value =item.MA });
            }
            ViewBag.listpro = listpro;
            return View();
        }
        [HttpPost]
        public ActionResult Create(CHITIETDONHANG collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imlProc = new DetailOrderModel();
                    collection.DAXOA = false;
                    var res = imlProc.Insert(collection);
                    if (res.CompareTo(null) != 0)
                    {
                        return RedirectToAction("Index", "AdminDetailOrder");
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
        public ActionResult Edit(string Donhang,string Sanpham)
        {
            var imp = new DetailOrderModel();
            var entity = imp.GetByID(Donhang,Sanpham);
            var order = new OrderModel().ListAll();
            List<SelectListItem> listorder = new List<SelectListItem>();
            foreach (var item in order)
            {
                listorder.Add(new SelectListItem() { Text = item.MA, Value = item.MA });
            }
            ViewBag.listorder = listorder;

            var pro = new ProductModel().ListAll();
            List<SelectListItem> listpro = new List<SelectListItem>();
            foreach (var item in pro)
            {
                listpro.Add(new SelectListItem() { Text = item.MA, Value = item.MA });
            }
            ViewBag.listpro = listpro;
            return View(entity);
        }

        
        [HttpPost]
        public ActionResult Edit(CHITIETDONHANG collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imlProc = new DetailOrderModel();
                    collection.DAXOA = false;
                    var res = imlProc.Update(collection);
                    if (res)
                    {
                        return RedirectToAction("Index", "AdminDetailOrder");
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
        public ActionResult Delete(string Donhang, string Sanpham)
        {
            var imp = new DetailOrderModel();
            var entity = imp.GetByID(Donhang,Sanpham);
            imp.Delete(entity);

            return RedirectToAction("Index");
        }

        // Delete: Admin/AdminProductManage/Delete/5
        [HttpDelete]
        public ActionResult Delete(CHITIETDONHANG collection)
        {
            try
            {

                var imlProc = new DetailOrderModel();
                var res = imlProc.Delete(collection);
                return RedirectToAction("Index", "AdminDetailOrder");
            }
            catch
            {
                ModelState.AddModelError("", "Không thể xóa được");
                return View();
            }
        }
    }
}