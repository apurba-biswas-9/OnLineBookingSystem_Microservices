using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.DataModel
{
    public class Book
    {
        public int Id { get; set; }
        public string BooksTitle { get; set; }
        public BookCategories BookCategories { get; set; }
        public double Price { get; set; }

        public int Units { get; set; } = 1;
    }
}
