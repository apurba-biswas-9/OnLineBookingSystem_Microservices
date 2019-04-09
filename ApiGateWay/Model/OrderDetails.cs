using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateWay.Model
{
    public class OrderDetails
    { 
        public int Id { get; set; }
        public string BookName { get; set;  }
        public int Units { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus{ get; set; }

        public double UnitPrice { get; set; }

        public bool IsCancled { get; set; }
    }
}
