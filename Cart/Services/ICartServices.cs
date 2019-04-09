using Cart.Core;
using Cart.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.Services
{
    public interface ICartServices
    {
        Task<int> Save(CartModel model);

        Task<bool> Delete(int id);

        Task<IList<CartModel>> GetCarts(int customerID);
    }

    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
