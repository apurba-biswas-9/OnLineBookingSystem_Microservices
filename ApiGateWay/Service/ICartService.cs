using ApiGateWay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateWay.CartService
{
    public interface ICartService
    {
        Task<List<BookModel>> GetByIdAsync(int id);
       
    }
}
