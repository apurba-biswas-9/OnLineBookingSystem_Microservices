using ApiGateWay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateWay.Service
{
   public  interface IOrderService
    {
        Task<List<OrderDetails>> GetOrders(int id);
    }
}
