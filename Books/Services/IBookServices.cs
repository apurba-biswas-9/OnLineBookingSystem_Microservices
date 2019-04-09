using Books.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Services
{
    public interface IBookServices
    {
        IDictionary<int, string> GetBooksCategories<T>();

        dynamic GetBooksCategories<T>(int id);

        IList<Book> GetBooks(BookCategories type);


        IList<Book> GetBooks();
    }
}
