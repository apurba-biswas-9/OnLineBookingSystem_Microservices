using Order.Core;
using System;
using System.Collections.Generic;

namespace Order.DAL
{
    public partial class OrderHistory :IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OrderStatusId { get; set; }

        public Order Order { get; set; }
    }
}
