using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Service
{
    public interface ICustomerService
    {
         DataModel.Customer Login(string userId, string password);
    }
}
