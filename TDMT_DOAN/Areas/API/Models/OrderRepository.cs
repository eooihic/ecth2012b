using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.API.Models
{
    public class OrderRepository : IOrderRepository
    {
        public OrderRepository()
        {
        }

        public IEnumerable<OrderModel> GetAll(Guid supplier_key)
        {
            using (TMDT_DB3Entities entiti = new TMDT_DB3Entities())
            {
                string keystring = supplier_key.ToString();
                NHACUNGCAP nhacungcap = entiti.NHACUNGCAPs.Where(f => f.supplier_key == keystring).First();
                string ma = nhacungcap.MA;
                List<HOPDONGMUAHANG> list = entiti.HOPDONGMUAHANGs.Where(f => f.NHACUNGCAP == ma).ToList();
                List<OrderModel> kq = new List<OrderModel>();
                for (int i = 0; i < list.Count; i++)
                {
                    OrderModel temp = new OrderModel();
                    string masp = list[i].SANPHAM;
                    SANPHAM sanpham = entiti.SANPHAMs.Where(f => f.MA == masp).First();
                    temp.order_id = list[i].MAHOPDONG;
                    temp.product_id = sanpham.MA;
                    temp.product_name = sanpham.TEN;
                    temp.product_quantity = sanpham.SOLUONG.Value;
                    kq.Add(temp);
                }
                return kq;
            }
        }

        public void Add(OrderShipping item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            using (TMDT_DB3Entities entiti = new TMDT_DB3Entities())
            {
                var sp = entiti.SANPHAMs.Where(f => f.MA == item.product_id).First();
                sp.SOLUONG += item.product_quantity;
                entiti.SaveChanges();
            }
            //add to database
        }
    }
}