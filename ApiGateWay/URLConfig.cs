using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateWay
{
    public class URLConfig
    {
        public class CartOperations
        {
            public static string GetItemById(int id) => $"/api/Cart/Carts/{id}";
        }

        public class BookOperations
        {
            public static string GetItems() => $"/api/Book/GetBooks";

        }


        public class OrderOperations
        {
            public static string GetItems(int id) => $"/api/Order/Orders/{id}";

        }

        public string Cart { get; set; }
        public string Book { get; set;}
        public string Order { get; set;}
    }
}
