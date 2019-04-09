using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Order.DAL;
using Order.DataModel;

namespace Order.Services
{
    public class OrderHistoryService : BaseDataAccess, IOrderHistoryService
    {
        public OrderHistoryService(OrderContext context) : base(context)
        {
        }

        public async Task<IList<OrderHistoryModel>> GetOrderHistory(int OrderID)
        {
            var carts = await this.GetDBSet<Order.DAL.OrderHistory>()
               .Where(p => p.OrderId.Equals(OrderID)).ToListAsync();

            if (carts?.Count > 0)
                return carts.Select(p => new OrderHistoryModel
                {                    
                    Id = p.Id,
                    OrderId = p.OrderId,
                    OrderStatusId = p.OrderStatusId
                    
                }).ToList();
            else
                return null;
        }

        public async Task<int> Save(OrderHistoryModel model)
        {
            var order = new Order.DAL.OrderHistory
            {
               OrderId = model.OrderId,
               OrderStatusId = model.OrderStatusId
            };

            _context.OrderHistory.Add(order);
            return await this.UnitOfWork.SaveChangesAsync();
        }
    }
}
