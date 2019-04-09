using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateWay.Model
{
    public class BookModel
    {

        public int Id { get; set; }
        public string BooksTitle { get; set; }
        public int BookCategories { get; set; }
        public double Price { get; set; }
        public int Units { get; set; } = 1;
        public bool isSelected { get; set; }
        public int CartId { get; set; }

    }
}
