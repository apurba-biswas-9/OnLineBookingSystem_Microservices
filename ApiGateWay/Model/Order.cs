using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateWay.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OurderStatus { get; set; }
        public int CartId { get; set; }
    }

    public enum OrderStatus
    {
        OrderPlaced,
        Canceled,
        Completed
    }
}
