using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.ExternalService
{
    public interface ICartService
    {
        Task DeleteAsync(int id);
    }
}
