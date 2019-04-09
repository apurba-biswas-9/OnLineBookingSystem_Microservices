using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.DataModel
{
    public class OrderHistoryModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OrderStatusId { get; set; }

    }
}
