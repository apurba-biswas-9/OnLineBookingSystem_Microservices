using Order.Core;
using System;
using System.Collections.Generic;

namespace Order.DAL
{
    public partial class Order : IEntity
    {
        public Order()
        {
            OrderHistory = new HashSet<OrderHistory>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public int? OrderCurrentStatus { get; set; }

        public ICollection<OrderHistory> OrderHistory { get; set; }
    }
}
