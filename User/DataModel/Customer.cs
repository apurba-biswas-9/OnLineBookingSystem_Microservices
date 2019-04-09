using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.DataModel
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public User User { get; set; }
        public string CustomerName { get; set; }
    }
}
