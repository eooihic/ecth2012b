using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Models;
using TDMT_DOAN.Areas.Admin.Models;

namespace TDMT_DOAN.Areas.Admin.Controllers
{
    public class AdminProductManageController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var impPro = new ProductModel();
            var model = impPro.ListAll();
            var stylepro = new StyleProductModel();
            ViewBag.style = stylepro;
            var producer = new ProducerModel();
            ViewBag.producer = producer;
            return View(model);
        }
        // GET: Admin/AdminProductManage/Create
        public ActionResult Create()
        {
            var stylepro = new StyleProductModel().ListAll();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in stylepro)
            {
                list.Add(new SelectListItem() { Text = item.TEN, Value = item.MA.ToString() });
            }
            ViewBag.list = list;
            var producer = new ProducerModel().ListAll();
            List<SelectListItem> listpro = new List<SelectListItem>();
            foreach (var item in producer)
            {
                listpro.Add(new SelectListItem() { Text = item.TEN, Value = item.MA.ToString() });
            }
            ViewBag.listpro = listpro;
            return View();
        }
        [HttpPost]
        public ActionResult Create(SANPHAM collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imlProc = new ProductModel();
                    collection.DAXOA = false;
                    var res = imlProc.Insert(collection);
                    if (res.CompareTo(null) != 0)
                    {
                        return RedirectToAction("Index", "AdminProductManage");
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
            var imp = new ProductModel();
            var entity = imp.GetByID(id);
            var stylepro = new StyleProductModel().ListAll();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in stylepro)
            {
                list.Add(new SelectListItem() { Text = item.TEN, Value = item.MA.ToString() });
            }
            ViewBag.list = list;
            var producer = new ProducerModel().ListAll();
            List<SelectListItem> listpro = new List<SelectListItem>();
            foreach (var item in producer)
            {
                listpro.Add(new SelectListItem() { Text = item.TEN, Value = item.MA.ToString() });
            }
            ViewBag.listpro = listpro;
            return View(entity);
        }

        // POST: Admin/AdminProductManage/Edit/5
        [HttpPost]
        public ActionResult Edit(SANPHAM collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imlProc = new ProductModel();
                    collection.DAXOA = false;
                    var res = imlProc.Update(collection);
                    if (res)
                    {
                        return RedirectToAction("Index", "AdminProductManage");
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
            var imp = new ProductModel();
            var entity = imp.GetByID(id);
            imp.Delete(entity);

            return RedirectToAction("Index");
        }

        // Delete: Admin/AdminProductManage/Delete/5
        [HttpDelete]
        public ActionResult Delete(SANPHAM collection)
        {
            try
            {

                var imlProc = new ProductModel();
                var res = imlProc.Delete(collection);
                return RedirectToAction("Index", "AdminProductManage");
            }
            catch
            {
                ModelState.AddModelError("", "Không thể xóa được");
                return View();
            }
        }
    }
}