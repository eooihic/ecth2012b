using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDMT_DOAN.Areas.API.Models
{
    interface IOrderRepository
    {
        IEnumerable<OrderModel> GetAll(Guid supplier_key);

        void Add(OrderShipping item);
    }
}