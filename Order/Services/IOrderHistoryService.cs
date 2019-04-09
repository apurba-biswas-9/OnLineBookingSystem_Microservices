using Order.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Services
{
    public interface IOrderHistoryService
    {
        Task<int> Save(OrderHistoryModel model);

        Task<IList<OrderHistoryModel>> GetOrderHistory(int customerID);
    }
}
