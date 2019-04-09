using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order
{
    public class URLConfig
    {
        public class CartOperations
        {
            public static string GetDeleteApi(int id) => $"/api/Cart/{id}";
        }


        public string Cart { get; set; }
       
    }
}
