using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.DataModel
{
    public enum OrderStatus
    {
        OrderPlaced,
        Canceled,
        Completed
    }
}

public enum OrderHistoryStatus
{
    Ordered,
    Shipped,
    OutOfDelivery,
    Delivered
}
