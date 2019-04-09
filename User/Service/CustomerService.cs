using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.DataModel;

namespace User.Service
{
    public class CustomerService : ICustomerService
    {
        DAL dal;
        public CustomerService()
        {
            dal = new DAL();
        }
        public  DataModel.Customer Login(string userId, string password) 
            => dal.GetCustomers().FirstOrDefault(p => p.User.UserId.ToUpper().Equals(userId.ToUpper()) && p.User.Password.ToUpper().Equals(password.ToUpper()));
    }
}
