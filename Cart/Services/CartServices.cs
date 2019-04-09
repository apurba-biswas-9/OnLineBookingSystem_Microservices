using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cart.DAL;
using Cart.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Cart.Services
{
    public class CartServices : BaseDataAccess, ICartServices
    {
        public CartServices(CartContext context) : base(context)
        {
        }

        public async Task<IList<CartModel>> GetCarts(int customerID)
        {
            var carts =  await this.GetDBSet<Cart.DAL.Cart>().Where(p => p.CustomerId.Equals(customerID)).ToListAsync();
            if (carts?.Count> 0)
                return carts.Select(p => new CartModel
                {
                    Id = p.Id,
                    BookId = p.BookId,
                    CustomerId = p.CustomerId,
                    Quentity = p.Quentity
                }).ToList();
            else
                return null;
        }

        public async Task<int> Save(CartModel model)
        {
            var cart = new Cart.DAL.Cart
            {
                BookId = model.BookId,
                CustomerId = model.CustomerId,
                Quentity = model.Quentity
            };

            _context.Cart.Add(cart);
            return await this.UnitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
           var cart =  this.GetDBSet<Cart.DAL.Cart>().FirstOrDefault(p => p.Id.Equals(id));
            if (cart != null)
            {
                _context.Entry(cart).State = EntityState.Deleted;
                return await this.UnitOfWork.SaveChangesAsync() != 0;
            }
            return false;
        }
    }
}
