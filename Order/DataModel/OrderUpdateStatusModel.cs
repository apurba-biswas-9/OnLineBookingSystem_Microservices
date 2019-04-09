using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.DataModel
{
    public class OrderUpdateStatusModel
    {
        public OrderUpdateStatusModel()
        {
            this.OrderIds = new List<int>();
        }

        public List<int> OrderIds { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}
