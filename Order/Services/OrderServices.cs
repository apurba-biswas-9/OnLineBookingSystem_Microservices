using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Order.DAL;
using Order.DataModel;
using Microsoft.EntityFrameworkCore;
using Order.ExternalService;

namespace Order.Services
{
    public class OrderServices : BaseDataAccess, IOrderServices
    {
        private readonly ICartService _cartService;
        public OrderServices(OrderContext context, ICartService cartService) : base(context)
        {
            _cartService = cartService;
        }

        public async Task<IList<OrderModel>> GetOrders(int customerID)
        {
            var carts = await this.GetDBSet<Order.DAL.Order>()
                //.Where(p => p.CustomerId.Equals(customerID) && p.OurderCurrentStatus.Value == (int)OrderStatus.OrderPlaced).ToListAsync();
            .Where(p => p.CustomerId.Equals(customerID)).ToListAsync();
            if (carts?.Count > 0)
                return carts.Select(p => new OrderModel
                {
                    BookId = p.BookId,
                    CustomerId = p.CustomerId,
                    Quantity = p.Quantity,
                    Id = p.Id,
                    OrderDate = p.OrderDate,
                    OurderStatus = (OrderStatus)p.OrderCurrentStatus.Value
                }).ToList();
            else
                return null;
        }

        public async Task<int> Save(List<OrderModel> model)
        {
            List<DAL.Order> orders = new List<DAL.Order>();
            if (model?.Count > 0)
            {
                model.ForEach(p =>
                {
                    var order = new Order.DAL.Order
                    {
                        BookId = p.BookId,
                        CustomerId = p.CustomerId,
                        Quantity = p.Quantity,
                        OrderDate = DateTime.Now,
                        OrderCurrentStatus = (int)OrderStatus.OrderPlaced
                    };

                    orders.Add(order);
                    _cartService.DeleteAsync(p.CartId);
                });
            }
            await _context.Order.AddRangeAsync(orders);


            //delete from cart

            return await this.UnitOfWork.SaveChangesAsync();


        }

        public async Task<bool> Delete(int id)
        {
            var order = this.GetDBSet<Order.DAL.Order>().FirstOrDefault(p => p.Id.Equals(id));
            if (order != null)
            {
                _context.Entry(order).State = EntityState.Deleted;
                return await this.UnitOfWork.SaveChangesAsync() != 0;
            }
            return false;
        }

        public async Task<int> Update(OrderModel model)
        {
            var order = this.GetDBSet<Order.DAL.Order>().FirstOrDefault(p => p.Id.Equals(model.Id));
            if (order != null)
            {
                order.BookId = model.BookId;
                order.CustomerId = model.CustomerId;
                order.Quantity = model.Quantity;
                order.OrderDate = DateTime.Now;
                order.OrderCurrentStatus = (int)model.OurderStatus;

                _context.Entry(order).State = EntityState.Modified;
                return await this.UnitOfWork.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> UpdateOrderStatus(OrderUpdateStatusModel model)
        {
            foreach (var p in model.OrderIds)
            {
                var order = this.GetDBSet<Order.DAL.Order>().FirstOrDefault(x => x.Id.Equals(p));
                if (order != null)
                {
                    order.OrderCurrentStatus = (int)model.OrderStatus;
                    _context.Entry(order).State = EntityState.Modified;
                    await this.UnitOfWork.SaveChangesAsync();
                }
            }

            return 1;
        }
    }
}
