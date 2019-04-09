using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User
{
    public class DAL
    {
        private  IList<DataModel.Customer> Coustomer { get; set; }
        public DAL()
        {
            Coustomer = new List<DataModel.Customer>();
            Coustomer.Add(new DataModel.Customer
            {
                CustomerId =1,
                CustomerName="Apurba Biswas",
                User = new DataModel.User
                {
                    UserId="BAPURBA",
                    Password ="password",
                    UserCategory =DataModel.UserType.User
                }
            });

            Coustomer.Add(new DataModel.Customer
            {
                CustomerId = 2,
                CustomerName = "Admin",
                User = new DataModel.User
                {
                    UserId = "Admin",
                    Password = "password",
                    UserCategory = DataModel.UserType.Admin
                }
            });

            Coustomer.Add(new DataModel.Customer
            {
                CustomerId = 3,
                CustomerName = "Arup Biswas",
                User = new DataModel.User
                {
                    UserId = "bisap",
                    Password = "password",
                    UserCategory = DataModel.UserType.User
                }
            });
        }

        public IList<DataModel.Customer> GetCustomers() => Coustomer;

    }
}
