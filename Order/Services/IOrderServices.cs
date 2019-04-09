
using Order.Core;
using Order.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Services
{
    public interface IOrderServices
    {
        Task<int> Save(List<OrderModel> model);

        Task<int> Update(OrderModel model);

        Task<bool> Delete(int id);

        Task<IList<OrderModel>> GetOrders(int customerID);

        Task<int> UpdateOrderStatus(OrderUpdateStatusModel model);
    }

    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
