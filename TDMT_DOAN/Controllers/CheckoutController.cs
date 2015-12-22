using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Models;
using TDMT_DOAN.Models.ViewModels;

namespace TDMT_DOAN.Controllers
{
    public class CheckoutController : Controller
    {
        //
        // GET: /Checkout/
        TMDT_DB3Entities db = new TMDT_DB3Entities();
        public ActionResult Index()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult Index(ReceiverViewModel receiver)
        {
          
            if (ModelState.IsValid)
            {
                //Luu session cho receiver
                SessionHelper.SetReceiverSession(receiver);
                return RedirectToAction("CheckoutByPayPal", "Checkout");
            }
            else
            {
                return View();
            }

          
        }


        public ActionResult CheckoutByPayPal()
        {
            //kiem tra coi da dang nhap hay chua de hien thi View tuong ung
            string username = SessionHelper.GetUserSession();
            CheckoutModel checkout = new CheckoutModel();
            if (username != null)
            {
                checkout.listCartSession = SessionHelper.GetCartSession(username);
                checkout.user = (from u in db.THANHVIENs where u.TENDANGNHAP == username select u).SingleOrDefault();
                ViewBag.summoney = Summoney(checkout.listCartSession);
                return View(checkout);
            }
            else
            {
                checkout.listCartSession = SessionHelper.GetCartSession("cart");
                ViewBag.summoney = Summoney(checkout.listCartSession);
                return View(checkout);
            }
             
            
        }


        public double Summoney(List<CartSession> listcartsession)
        {
            double sum = 0;
            foreach (var item in listcartsession)
            {
                sum += (double)(item.sp.DONGIABAN) * (item.soluong);
            }

            return sum;
        }


        public ActionResult CheckoutSuccess()
        {

            //Luu thong tin don hang tai day dua vao thong tin session
            //kiem tra coi da dang nhap hay chua de hien thi View tuong ung

            string username = SessionHelper.GetUserSession();
            ReceiverViewModel receiver = SessionHelper.GetReceiverSession();
            List<CartSession> list = new List<CartSession>();
            

            

            if (username != null)//da dang nhap //thong tin nguoi mua
            {
                list = SessionHelper.GetCartSession(username); //san pham
                if (receiver != null) //thong tin nguoi nhan
                {
                    //khoi tao id
                    string id = CreateId();
                    if (id != "")
                    {
                        //thêm đơn hàng
                        DONHANG order = new DONHANG();
                        order.MA = id;
                        order.TONGTIEN = Summoney(list);
                        order.NGAYDATHANG = DateTime.Now;
                        order.NGAYNHANHANG = DateTime.Now.AddDays(3);
                        order.TENNGUOINHAN = receiver.name;
                        order.DIACHINHAN = receiver.address;
                        order.DIENTHOAINGUOINHAN = receiver.phone;
                        order.TRANGTHAI = 1;
                        order.DAXOA = false;

                        //phai bo sung them database cho thanh vien mua hang la ai
                    }
                }
            }
            else
            {
                list = SessionHelper.GetCartSession("cart"); //san pham
                if (receiver != null) //thong tin nguoi nhan
                {

                }
            }
            

            //Giam so luong san pham xuong

            //xóa session giỏ hàng và người nhận đi.

            //gui email thong bao

            return View();
        }


        public string CreateId()
        {
            string idcreated = "";
            //lấy mã số đơn hàng cuối cùng trong bảng
            DONHANG lastitem = db.DONHANGs.ToList().Last();
            if (lastitem != null)
            {
                //tien hanh tach chuoi de lay 3 so cuoi cung
                string lastitemid = lastitem.MA.ToString();
                string idfigure = lastitemid.Substring(1);
                int figure = int.Parse(idfigure);
                figure ++ ;
                if (figure <= 99) //  co 2 chu so
                {
                    idcreated = "A0" + figure;
                }
                else
                {
                    idcreated = "A" + figure;
                }
            }else
            {
                idcreated = "A001";
            }

            return idcreated;
        }
	}
}