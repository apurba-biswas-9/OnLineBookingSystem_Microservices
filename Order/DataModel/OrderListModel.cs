using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.DataModel
{
    public class OrderListModel
    {
        public OrderListModel()
        {
            OrderList = new List<OrderModel>();
        }
       List<OrderModel> OrderList { get; set; }

    }
}
