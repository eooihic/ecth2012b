using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Areas.B2B.Common;
using TDMT_DOAN.Areas.B2B.DAO;
using TDMT_DOAN.Areas.B2B.Models.ViewModels;

namespace TDMT_DOAN.Areas.B2B.Controllers
{
    public class ManageAutionResultController : Controller
    {
        // GET: B2B/ManageAutionResult
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ListAutionRecord()
        {
            var list = AutionRecoreList.GetInstance();
            var res = list.GetList();
            return View(res);
        }
        public ActionResult AcceptAutionRecord(int id)
        {
            var list = AutionRecoreList.GetInstance();
            var entity = list.GetByID(id);
            if (entity != null)
            {
                try
                {
                    MailHelper sender = new MailHelper();
                    string customer_email = entity.email;
                    string productname = new ProductDAO().GetProductNameById(entity.productID);
                    string content = System.IO.File.ReadAllText(Server.MapPath("~/Areas/B2B/Common/AutionReply.html"));
                    content = content.Replace("{{Customer_Name}}", entity.username);
                    content = content.Replace("{{Customer_Phone}}", entity.phone);
                    content = content.Replace("{{Customer_Email}}", entity.email);
                    content = content.Replace("{{Product_Name}}", productname);
                    content = content.Replace("{{Quantity}}", entity.quantity.ToString());
                    content = content.Replace("{{Price}}", entity.price.ToString());
                    bool result = sender.sendMail(customer_email, "Chap nhan don dau gia", content);
                    if (result)
                    {
                        list.RemoveById(id);
                        return RedirectToAction("ListAutionRecord", "ManageAutionResult");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View();
        }
    }
}